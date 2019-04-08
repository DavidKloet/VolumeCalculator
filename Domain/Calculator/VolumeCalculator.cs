using Domain.Data;
using System;

namespace Domain.Calculator
{
    public sealed class SimpleVolumeCalculator
    {
        private readonly Grid _baseHorizon;
        private readonly Grid _topHorizon;
        private readonly decimal _width;
        private readonly decimal _height;
        private readonly decimal _fluidContact;

        public SimpleVolumeCalculator(Grid baseHorizon, Grid topHorizon, decimal width, decimal height, decimal fluidContact)
        {
            _baseHorizon = baseHorizon ?? throw new ArgumentNullException(nameof(baseHorizon));
            _topHorizon = topHorizon ?? throw new ArgumentNullException(nameof(topHorizon));
            _width = width;
            _height = height;
            _fluidContact = fluidContact;
        }

        public bool IsValid()
        {
            return _baseHorizon.Rows == _topHorizon.Rows &&
                   _baseHorizon.Columns == _topHorizon.Columns;
        }

        public decimal GetVolume()
        {
            var volume = 0.0m;
            var segmentArea = (_width / _baseHorizon.Columns) * (_height / _baseHorizon.Rows);

            using (var baseIterator = _baseHorizon.GetEnumerator())
            using (var topIterator = _topHorizon.GetEnumerator())
            {
                while (baseIterator.MoveNext() && topIterator.MoveNext())
                {
                    var baseDepth = GetAverageDepth(baseIterator.Current);
                    var topDepth = GetAverageDepth(topIterator.Current);

                    if (topDepth >= _fluidContact) continue;

                    if (baseDepth > _fluidContact) baseDepth = _fluidContact;

                    var deltaDepth = topDepth - baseDepth;

                    volume += segmentArea * deltaDepth;
                }
            }

            return volume;
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
