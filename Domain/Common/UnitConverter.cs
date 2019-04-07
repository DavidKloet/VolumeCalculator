namespace Domain.Common
{
    public static class UnitConverter
    {
        private const decimal FeetToMeterConverion = 0.3048m;

        public static decimal FeetToMeter(decimal feet)
        {
            return feet / FeetToMeterConverion;
        }

        public static decimal MeterToFeet(decimal meter)
        {
            return meter * FeetToMeterConverion;
        }
    }
}
