using System;
using System.Collections.Generic;

namespace Domain.Common
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<(TLeft, TRight)> Combine<TLeft, TRight>(this IEnumerable<TLeft> leftSource, IEnumerable<TRight> rightSource)
        {
            if (leftSource == null) throw new ArgumentNullException(nameof(leftSource));
            if (rightSource == null) throw new ArgumentNullException(nameof(rightSource));

            using (var leftIterator = leftSource.GetEnumerator())
            using (var rightIterator = rightSource.GetEnumerator())
            {
                while (leftIterator.MoveNext() && rightIterator.MoveNext())
                {
                    yield return (leftIterator.Current, rightIterator.Current);
                }
            }
        }
    }
}
