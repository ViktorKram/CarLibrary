namespace CarLibrary;

public class TruckCar : Car
{
    public override CarType Type { get; }
    public override double TankCapacity { get; }
    public override double AverageFuelRate { get; }
    public double LoadCapacity { get; }
    public double LoadPenalty { get; }
    public double PenaltyStep { get; }

    internal TruckCar(
        double tankCapacity,
        double averageFuelRate,
        double loadCapacity,
        double loadPenalty,
        double penaltyStep)
    {
        Type = CarType.TruckCar;
        TankCapacity = tankCapacity;
        AverageFuelRate = averageFuelRate;
        LoadCapacity = loadCapacity;
        LoadPenalty = loadPenalty;
        PenaltyStep = penaltyStep;
    }
}