using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Data
{
    public sealed class Grid : IEnumerable<GridSegment>
    {
        private readonly List<IEnumerable<DataPoint>> _data;

        public Grid(IEnumerable<IEnumerable<DataPoint>> data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            _data = data.ToList();

            if (_data.Any()) throw new ArgumentException("Value must contains at least one row", nameof(data));
            if (_data.First().Any()) throw new ArgumentException("Value must contains at least one column", nameof(data));
        }

        public IEnumerator<GridSegment> GetEnumerator()
        {
            for (var rowIndex = 0; rowIndex < _data.Count - 2; rowIndex++)
            {
                var cellCount = _data[rowIndex].Count() - 2;

                for (var cellIndex = 0; cellIndex < cellCount; cellIndex++)
                {
                    yield return new GridSegment(_data[rowIndex].ElementAt(cellIndex),
                        _data[rowIndex].ElementAt(cellIndex + 1),
                        _data[rowIndex + 1].ElementAt(cellIndex),
                        _data[rowIndex + 1].ElementAt(cellIndex + 1));
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
