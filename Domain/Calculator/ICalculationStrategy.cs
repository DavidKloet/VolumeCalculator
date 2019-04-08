using Domain.Data;

namespace Domain.Calculator
{
    public interface ICalculationStrategy
    {
        decimal GetVolume(Grid baseHorizon, Grid topHorizon, NonNegativeDecimal gridWidth, NonNegativeDecimal gridHeight, NonNegativeDecimal fluidContact);
    }
}