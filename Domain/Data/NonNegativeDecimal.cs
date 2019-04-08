using System;

namespace Domain.Data
{
    public struct NonNegativeDecimal
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
    }
}
