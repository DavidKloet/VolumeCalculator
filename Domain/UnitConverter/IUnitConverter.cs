namespace Domain.UnitConverter
{
    /// <summary>
    /// Converts a volume in a given unit to other units
    /// </summary>
    public interface IUnitConverter
    {
        /// <summary>
        /// Returns the volume in cubic feet
        /// </summary>
        decimal ToCubicFeet(decimal volume);

        /// <summary>
        /// Returns the volume in cubic meter
        /// </summary>
        decimal ToCubicMeter(decimal volume);

        /// <summary>
        /// Returns the volume in barrels of oil
        /// </summary>
        decimal ToBarrels(decimal volume);
    }
}
