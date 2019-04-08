using Domain.Common;
using Domain.Data;
using System;
using System.Linq;

namespace Domain.Calculator
{
    public sealed class SimpleCalculationStrategy : ICalculationStrategy
    {
        public decimal GetVolume(Grid baseHorizon, Grid topHorizon, NonNegativeDecimal gridWidth, NonNegativeDecimal gridHeight, NonNegativeDecimal fluidContact)
        {
            if (baseHorizon == null) throw new ArgumentNullException(nameof(baseHorizon));
            if (topHorizon == null) throw new ArgumentNullException(nameof(topHorizon));
            if (baseHorizon.Rows != topHorizon.Rows || baseHorizon.Columns != topHorizon.Columns) throw new ArgumentException("Grids must have equal dimensions");

            var segmentArea = (gridWidth / (baseHorizon.Columns - 1)) * (gridHeight / (baseHorizon.Rows - 1));

            return baseHorizon.Combine(topHorizon).Sum(pair =>
            {
                var baseDepth = GetAverageDepth(pair.Item1);
                var topDepth = GetAverageDepth(pair.Item2);

                if (baseDepth > fluidContact) baseDepth = fluidContact;

                var deltaDepth = topDepth - baseDepth;

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
