namespace CarLibrary;

public class PassengerCar : Car
{
    public override CarType Type { get; }
    public override double TankCapacity { get; }
    public override double AverageFuelRate { get; }
    public double PassengersPenalty { get; }
    public uint Seats { get; }

    internal PassengerCar(
        double tankCapacity,
        double averageFuelRate,
        uint seats,
        double passengersPenalty)
    {
        Type = CarType.PassengerCar;
        TankCapacity = tankCapacity;
        AverageFuelRate = averageFuelRate;
        Seats = seats;
        PassengersPenalty = passengersPenalty;
    }
}