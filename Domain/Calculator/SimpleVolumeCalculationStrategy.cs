using Domain.Common;
using Domain.Data;
using System;
using System.Linq;

namespace Domain.Calculator
{
    /// <inheritdoc />
    /// <summary>
    /// Simple volume calculation strategy
    /// Assumes that the error due to averaging depth values per segment will level out over all segments measured
    /// </summary>
    internal sealed class SimpleCalculationStrategy : ICalculationStrategy
    {
        public decimal GetVolume(Grid baseHorizon, Grid topHorizon, NonNegativeDecimal gridWidth, NonNegativeDecimal gridHeight, NonNegativeDecimal fluidContact)
        {
            if (baseHorizon == null) throw new ArgumentNullException(nameof(baseHorizon));
            if (topHorizon == null) throw new ArgumentNullException(nameof(topHorizon));
            if (baseHorizon.Height != topHorizon.Height || baseHorizon.Width != topHorizon.Width) throw new ArgumentException("Grids must have equal dimensions");

            var segmentArea = (gridWidth / (baseHorizon.Width - 1)) * (gridHeight / (baseHorizon.Height - 1));

            return baseHorizon.Combine(topHorizon).Sum(pair =>
            {
                var baseDepth = GetAverageDepth(pair.Item1);
                var topDepth = GetAverageDepth(pair.Item2);

                if (baseDepth > fluidContact) baseDepth = fluidContact;

                var deltaDepth = baseDepth - topDepth;

                if (deltaDepth < 0) return 0m; // top is either below base or below fluid contact

                return segmentArea * deltaDepth;
            });
        }

        private static decimal GetAverageDepth(GridSegment segment)
        {
            return (segment.TopLeft.Depth +
                    segment.TopRight.Depth +
                    segment.BottomLeft.Depth +
                    segment.BottomRight.Depth) / 4;
        }
    }
}
