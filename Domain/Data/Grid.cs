using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Data
{
    /// <summary>
    /// A grid is made up of data points, that yield segments
    /// </summary>
    public sealed class Grid : IEnumerable<GridSegment>
    {
        private readonly List<DataPoint[]> _data;

        public Grid(IEnumerable<DataPoint[]> data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            _data = data.ToList();

            Height = _data.Count;
            Width = _data[0].Length;
        }

        public int Height { get; }

        public int Width { get; }

        public IEnumerator<GridSegment> GetEnumerator()
        {
            for (var rowIndex = 0; rowIndex < _data.Count - 1; rowIndex++)
            {
                var cellCount = _data[rowIndex].Length - 1;

                for (var cellIndex = 0; cellIndex < cellCount; cellIndex++)
                {
                    yield return new GridSegment(_data[rowIndex][cellIndex],
                        _data[rowIndex][cellIndex + 1],
                        _data[rowIndex + 1][cellIndex],
                        _data[rowIndex + 1][cellIndex + 1]);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
