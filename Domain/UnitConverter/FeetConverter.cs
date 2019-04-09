namespace Domain.UnitConverter
{
    /// <inheritdoc />
    /// <summary>
    /// Converts a volume in cubic feet to other units
    /// </summary>
    internal sealed class FeetConverter : IUnitConverter
    {
        public decimal ToCubicFeet(decimal volume)
        {
            return volume;
        }

        public decimal ToCubicMeter(decimal volume)
        {
            return UnitConversions.CubicFeetToCubicMeter(volume);
        }

        public decimal ToBarrels(decimal volume)
        {
            return UnitConversions.CubicFeetToBarrels(volume);
        }
    }
}
