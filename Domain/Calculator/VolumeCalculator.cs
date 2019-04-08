using Domain.Common;
using Domain.Common.Exceptions;
using Domain.Data;
using Services.Data;
using System;
using System.Threading.Tasks;
using Domain.UnitConverter;

namespace Domain.Calculator
{
    public sealed class VolumeCalculator
    {
        private readonly ICalculationStrategy _calculationStrategy;

        public VolumeCalculator(ICalculationStrategy calculationStrategy)
        {
            _calculationStrategy = calculationStrategy ?? throw new ArgumentNullException(nameof(calculationStrategy));
        }

        public async Task<decimal?> CalculateAsync(IReader baseReader, IReader topReader, NonNegativeDecimal gridWidth, NonNegativeDecimal gridHeight, NonNegativeDecimal fluidContact, IUnitConverter unitConverter, ILogger logger)
        {
            if (baseReader == null) throw new ArgumentNullException(nameof(baseReader));
            if (topReader == null) throw new ArgumentNullException(nameof(topReader));
            if (logger == null) throw new ArgumentNullException(nameof(logger));

            try
            {
                logger.Info("Reading base horizon measurements...");

                var baseHorizon = await baseReader.ReadAsync();

                logger.Info($"Found {baseHorizon.Columns * baseHorizon.Rows} values");

                logger.Info("Reading top horizon measurements...");

                var topHorizon = await topReader.ReadAsync();

                logger.Info($"Found {baseHorizon.Columns * baseHorizon.Rows} values");

                if (baseHorizon.Rows != topHorizon.Rows || baseHorizon.Columns != topHorizon.Columns)
                {
                    logger.Error("Invalid input: grids must have the same dimensions!");
                    return null;
                }

                logger.Info("Calculating volume...");

                return _calculationStrategy.GetVolume(baseHorizon, topHorizon, gridWidth, gridHeight, fluidContact);
            }
            catch (ReaderException e)
            {
                logger.Error($"Error while reading! {e.Message}");
            }

            return null;
        }
    }
}
