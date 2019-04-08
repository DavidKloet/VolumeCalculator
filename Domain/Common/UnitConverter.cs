namespace Domain.Common
{
    public static class UnitConverter
    {
        private const decimal FeetToMeterConversion = 0.3048m;

        public static decimal FeetToMeter(decimal feet)
        {
            return feet * FeetToMeterConversion;
        }

        public static decimal MeterToFeet(decimal meter)
        {
            return meter / FeetToMeterConversion;
        }
    }
}
