namespace CarLibrary;

public abstract class CarManagerBase : ICarManager
{
    public double GetKmLeft(Car car, double fuel)
    {
        if (fuel is <= 0 or double.NaN or double.PositiveInfinity)
            throw new ArgumentException("Invalid value", nameof(fuel));

        return fuel / car.AverageFuelRate * 100;
    }

    public double GetTravelTimeInHours(Car car, double distanceByKm, double fuel, double speed)
    {
        if (distanceByKm is <= 0 or double.NaN or double.PositiveInfinity)
            throw new ArgumentException("Invalid value", nameof(distanceByKm));

        if (fuel is <= 0 or double.NaN or Double.PositiveInfinity)
            throw new ArgumentException("Invalid value", nameof(fuel));

        if (speed is <= 0 or double.NaN or Double.PositiveInfinity)
            throw new ArgumentException("Invalid value", nameof(speed));

        var fuelNeeded = car.AverageFuelRate / 100 * distanceByKm;

        if (fuelNeeded > fuel)
            throw new ArgumentOutOfRangeException(nameof(fuel), "Fuel amount is less than needed.");

        if (speed == 0)
            throw new ArgumentOutOfRangeException(nameof(speed));

        return distanceByKm / speed;
    }
}