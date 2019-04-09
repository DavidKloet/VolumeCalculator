namespace Domain.Calculator
{
    /// <summary>
    /// Creates volume calculators
    /// </summary>
    public static class VolumeCalculatorFactory
    {
        /// <summary>
        /// Returns a volume calculator
        /// </summary>
        public static VolumeCalculator GetCalculator()
        {
            return new VolumeCalculator(new SimpleCalculationStrategy());
        }
    }
}
