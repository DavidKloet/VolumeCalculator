namespace Domain.UnitConverter
{
    /// <inheritdoc />
    /// <summary>
    /// Converts a volume in cubic meter to other units
    /// </summary>
    internal sealed class MeterConverter : IUnitConverter
    {
        public decimal ToCubicFeet(decimal volume)
        {
            return UnitConversions.CubicMeterToCubicFeet(volume);
        }

        public decimal ToCubicMeter(decimal volume)
        {
            return volume;
        }

        public decimal ToBarrels(decimal volume)
        {
            return UnitConversions.CubicMeterToBarrels(volume);
        }
    }
}
