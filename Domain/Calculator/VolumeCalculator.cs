using Domain.Common;
using Domain.Common.Exceptions;
using Domain.Data;
using Domain.UnitConverter;
using System;
using System.Threading.Tasks;

namespace Domain.Calculator
{
    /// <summary>
    /// Strategy context/template for actual calculations
    /// Reports progress to some log sink
    /// </summary>
    public sealed class VolumeCalculator
    {
        private readonly ICalculationStrategy _calculationStrategy;

        public VolumeCalculator(ICalculationStrategy calculationStrategy)
        {
            _calculationStrategy = calculationStrategy ?? throw new ArgumentNullException(nameof(calculationStrategy));
        }

        /// <summary>
        /// Calculates the volume using the provided input and strategy
        /// </summary>
        public async Task CalculateAsync(IReader baseReader, IReader topReader, NonNegativeDecimal gridWidth, NonNegativeDecimal gridHeight, NonNegativeDecimal fluidContact, IUnitConverter unitConverter, ILogger logger)
        {
            if (baseReader == null) throw new ArgumentNullException(nameof(baseReader));
            if (topReader == null) throw new ArgumentNullException(nameof(topReader));
            if (unitConverter == null) throw new ArgumentNullException(nameof(unitConverter));
            if (logger == null) throw new ArgumentNullException(nameof(logger));

            try
            {
                var baseHorizon = await baseReader.ReadAsync();

                logger.Info($"Found {baseHorizon.Width * baseHorizon.Height} data points for base horizon");

                var topHorizon = await topReader.ReadAsync();

                logger.Info($"Found {topHorizon.Width * topHorizon.Height} data points for top horizon");

                if (baseHorizon.Height != topHorizon.Height || baseHorizon.Width != topHorizon.Width)
                {
                    logger.Error("Invalid input: grids must have the same dimensions!");
                    return;
                }

                logger.Info("Calculating volume...");

                var volume = _calculationStrategy.GetVolume(baseHorizon, topHorizon, gridWidth, gridHeight, fluidContact);

                logger.Info("Success!");
                logger.Info("");
                logger.Info($"- {unitConverter.ToBarrels(volume):N0} barrels of oil");
                logger.Info($"- {unitConverter.ToCubicFeet(volume):N0} cubic feet");
                logger.Info($"- {unitConverter.ToCubicMeter(volume):N0} cubic meter");
                logger.Info("Volume between top horizon and base horizon/fluid contact is approximately:");
            }
            catch (ReaderException e)
            {
                logger.Error($"Error while reading! {e.Message}");
            }
        }
    }
}
