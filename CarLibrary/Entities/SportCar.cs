namespace CarLibrary;

public class SportCar : Car
{
    public override CarType Type { get; }
    public override double TankCapacity { get; }
    public override double AverageFuelRate { get; }

    internal SportCar(double tankCapacity, double averageFuelRate)
    {
        Type = CarType.SportCar;
        TankCapacity = tankCapacity;
        AverageFuelRate = averageFuelRate;
    }
}