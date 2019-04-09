using System;

namespace Domain.UnitConverter
{
    /// <summary>
    /// Creates unit converters
    /// </summary>
    public static class UnitConverterFactory
    {
        /// <summary>
        /// Returns the appropriate converter for the given <see cref="Unit"/>
        /// </summary>
        public static IUnitConverter GetConverter(Unit unit)
        {
            switch (unit)
            {
                case Unit.Meter:
                    return new MeterConverter();
                case Unit.Feet:
                    return new FeetConverter();
                default:
                    throw new NotImplementedException($"Unsupported unit {unit}");
            }
        }
    }
}
