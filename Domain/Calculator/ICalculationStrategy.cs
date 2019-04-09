using Domain.Data;

namespace Domain.Calculator
{
    /// <summary>
    /// Volume calculation strategy
    /// </summary>
    public interface ICalculationStrategy
    {
        /// <summary>
        /// Returns the volume from the given input
        /// </summary>
        decimal GetVolume(Grid baseHorizon, Grid topHorizon, NonNegativeDecimal gridWidth, NonNegativeDecimal gridHeight, NonNegativeDecimal fluidContact);
    }
}