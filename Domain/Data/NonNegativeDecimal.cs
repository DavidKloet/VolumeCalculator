using System;

namespace Domain.Data
{
    /// <summary>
    /// Wrapper to enforce non-negativity of the decimal
    /// </summary>
    public struct NonNegativeDecimal : IEquatable<NonNegativeDecimal>
    {
        public decimal Value { get; }

        public NonNegativeDecimal(decimal value)
        {
            if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), "Value must be greater or equal to 0");

            Value = value;
        }

        public static bool TryParse(string input, out NonNegativeDecimal value)
        {
            value = new NonNegativeDecimal();

            if (string.IsNullOrWhiteSpace(input)) return false;
            if (!decimal.TryParse(input, out var d)) return false;
            if (d < 0m) return false;

            value = new NonNegativeDecimal(d);

            return true;
        }

        public static implicit operator decimal(NonNegativeDecimal d)
        {
            return d.Value;
        }

        public static explicit operator NonNegativeDecimal(decimal d)
        {
            return new NonNegativeDecimal(d);
        }

        public bool Equals(NonNegativeDecimal other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is NonNegativeDecimal other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(NonNegativeDecimal left, NonNegativeDecimal right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(NonNegativeDecimal left, NonNegativeDecimal right)
        {
            return !left.Equals(right);
        }
    }
}
