namespace CarLibrary;

public abstract class CarManagerBase : ICarManager
{
    public double GetKmLeft(Car car, double fuel)
    {
        if (fuel is <= 0 or double.NaN or double.PositiveInfinity)
            throw new ArgumentException("Invalid value", nameof(fuel));
        
        if (fuel > car.TankCapacity)
            throw new ArgumentOutOfRangeException(nameof(fuel), "Too much fuel for the car's tank");

        return fuel / car.AverageFuelRate * 100;
    }

    public double GetTravelTimeInHours(Car car, double distanceByKm, double fuel, double speed)
    {
        if (distanceByKm is <= 0 or double.NaN or double.PositiveInfinity)
            throw new ArgumentException("Invalid value", nameof(distanceByKm));

        if (fuel is <= 0 or double.NaN or Double.PositiveInfinity)
            throw new ArgumentException("Invalid value", nameof(fuel));

        if (fuel > car.TankCapacity)
            throw new ArgumentOutOfRangeException(nameof(fuel), "Too much fuel for the car's tank");

        if (speed is <= 0 or double.NaN or Double.PositiveInfinity)
            throw new ArgumentException("Invalid value", nameof(speed));

        var fuelNeeded = car.AverageFuelRate / 100 * distanceByKm;

        if (fuelNeeded > fuel)
            throw new ArgumentOutOfRangeException(nameof(fuel), "Fuel amount is less than needed.");

        return distanceByKm / speed;
    }
}