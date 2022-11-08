namespace CarLibrary;

public class PassengerCarManager : CarManagerBase
{
    public PassengerCar CreateCar(
        double tankCapacity,
        double averageFuelRate,
        uint seats,
        double passengersPenalty = 0.06)
    {
        if (tankCapacity is <= 0 or double.NaN or double.PositiveInfinity)
            throw new ArgumentException("Invalid value", nameof(tankCapacity));

        if (averageFuelRate is <= 0 or double.NaN or double.PositiveInfinity)
            throw new ArgumentException("Invalid value", nameof(averageFuelRate));

        if (passengersPenalty is <= 0 or double.NaN or double.PositiveInfinity)
            throw new ArgumentException("Invalid value", nameof(passengersPenalty));

        return new PassengerCar(tankCapacity, averageFuelRate, seats, passengersPenalty);
    }

    public double GetKmLeftWithPassengers(PassengerCar car, uint passengers, double fuel)
    {
        if (passengers > car.Seats)
            throw new ArgumentOutOfRangeException(nameof(passengers), "Passengers are more than seats");

        if (fuel is <= 0 or double.NaN or double.PositiveInfinity)
            throw new ArgumentException("Invalid value", nameof(fuel));

        if (fuel > car.TankCapacity)
            throw new ArgumentOutOfRangeException(nameof(fuel), "Too much fuel for the car's tank");

        var newAvgFuelRate = car.AverageFuelRate;

        for (var i = 0; i < passengers; i++)
        {
            newAvgFuelRate += newAvgFuelRate * car.PassengersPenalty;
        }

        return fuel / newAvgFuelRate * 100;
    }
}