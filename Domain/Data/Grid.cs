using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Data
{
    public sealed class Grid : IEnumerable<GridSegment>
    {
        private readonly List<DataPoint[]> _data;

        public Grid(IEnumerable<DataPoint[]> data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            _data = data.ToList();

            if (_data.Count == 0) throw new ArgumentException("Value must contains at least one row", nameof(data));
            if (_data[0].Length == 0) throw new ArgumentException("Value must contains at least one column", nameof(data));

            Rows = _data.Count;
            Columns = _data[0].Length;
        }

        public int Rows { get; }

        public int Columns { get; }

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
