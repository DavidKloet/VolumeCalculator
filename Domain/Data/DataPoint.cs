using System;

namespace Domain.Data
{
    /// <summary>
    /// A data point with x, y and depth values
    /// </summary>
    public struct DataPoint : IEquatable<DataPoint>
    {
        public int X { get; }

        public int Y { get; }

        public decimal Depth { get; }

        public DataPoint(int x, int y, NonNegativeDecimal depth)
        {
            X = x;
            Y = y;
            Depth = depth.Value;
        }

        public bool Equals(DataPoint other)
        {
            return X == other.X && Y == other.Y && Depth == other.Depth;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is DataPoint other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X;
                hashCode = (hashCode * 397) ^ Y;
                hashCode = (hashCode * 397) ^ Depth.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(DataPoint left, DataPoint right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DataPoint left, DataPoint right)
        {
            return !left.Equals(right);
        }
    }
}
