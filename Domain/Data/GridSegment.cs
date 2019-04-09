using System;

namespace Domain.Data
{
    /// <summary>
    /// A grid segment, consisting of 4 <see cref="DataPoint"/>
    /// </summary>
    public struct GridSegment : IEquatable<GridSegment>
    {
        public DataPoint TopLeft { get; }

        public DataPoint TopRight { get; }

        public DataPoint BottomLeft { get; }

        public DataPoint BottomRight { get; }

        public GridSegment(DataPoint topLeft, DataPoint topRight, DataPoint bottomLeft, DataPoint bottomRight)
        {
            if (topLeft.X - topRight.X != bottomLeft.X - bottomRight.X ||
               topLeft.Y - bottomLeft.Y != topRight.Y - bottomRight.Y) throw new ArgumentException("Segment must be a rectangle");

            TopLeft = topLeft;
            TopRight = topRight;
            BottomLeft = bottomLeft;
            BottomRight = bottomRight;
        }

        public bool Equals(GridSegment other)
        {
            return TopLeft.Equals(other.TopLeft) && TopRight.Equals(other.TopRight) && BottomLeft.Equals(other.BottomLeft) && BottomRight.Equals(other.BottomRight);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is GridSegment other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = TopLeft.GetHashCode();
                hashCode = (hashCode * 397) ^ TopRight.GetHashCode();
                hashCode = (hashCode * 397) ^ BottomLeft.GetHashCode();
                hashCode = (hashCode * 397) ^ BottomRight.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(GridSegment left, GridSegment right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(GridSegment left, GridSegment right)
        {
            return !left.Equals(right);
        }
    }
}
