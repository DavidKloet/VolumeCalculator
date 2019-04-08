namespace Domain.Calculator
{
    public static class VolumeCalculatorFactory
    {
        public static VolumeCalculator GetCalculator()
        {
            return new VolumeCalculator(new SimpleCalculationStrategy());
        }
    }
}
