namespace Domain.UnitConverter
{
    public static class UnitConversions
    {
        private const decimal FeetToMeterConversion = 0.3048m;
        private const decimal CubicFeetToCubicMeterConversion = 0.0283168466m;
        private const decimal CubicFeetToBarrelsOfOilConversion = 0.17810760667903522m;

        public static decimal FeetToMeter(decimal feet)
        {
            return feet * FeetToMeterConversion;
        }

        public static decimal MeterToFeet(decimal meter)
        {
            return meter / FeetToMeterConversion;
        }

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
