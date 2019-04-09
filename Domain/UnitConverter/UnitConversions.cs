namespace Domain.UnitConverter
{
    /// <summary>
    /// Convenience class for all unit conversions
    /// </summary>
    internal static class UnitConversions
    {
        private const decimal CubicFeetToCubicMeterConversion = 0.0283168466m;
        private const decimal CubicFeetToBarrelsOfOilConversion = 0.17810760667903522m;

        public static decimal CubicFeetToCubicMeter(decimal cubicFeet)
        {
            return cubicFeet * CubicFeetToCubicMeterConversion;
        }

        public static decimal CubicMeterToCubicFeet(decimal cubicMeter)
        {
            return cubicMeter / CubicFeetToCubicMeterConversion;

        }

        public static decimal CubicFeetToBarrels(decimal cubicFeet)
        {
            return cubicFeet * CubicFeetToBarrelsOfOilConversion;
        }

        public static decimal CubicMeterToBarrels(decimal cubicMeter)
        {
            return CubicFeetToBarrels(CubicMeterToCubicFeet(cubicMeter));
        }
    }
}
