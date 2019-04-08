namespace Domain.UnitConverter
{
    public interface IUnitConverter
    {
        decimal ToCubicFeet(decimal volume);

        decimal ToCubicMeter(decimal volume);

        decimal ToBarrels(decimal volume);
    }
}
