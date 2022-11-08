namespace CarLibrary;

public class SportCarManager : CarManagerBase
{
    public SportCar CreateCar(double tankCapacity, double averageFuelRate)
    {
        if (tankCapacity is <= 0 or double.NaN or double.PositiveInfinity)
            throw new ArgumentException("Invalid value", nameof(tankCapacity));

        if (averageFuelRate is <= 0 or double.NaN or double.PositiveInfinity)
            throw new ArgumentException("Invalid value", nameof(averageFuelRate));

        return new SportCar(tankCapacity, averageFuelRate);
    }
}