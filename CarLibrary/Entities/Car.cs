namespace CarLibrary;

public abstract class Car
{
    public abstract CarType Type { get; }
    public abstract double TankCapacity { get; }
    public abstract double AverageFuelRate { get; }
}