namespace CarLibrary;

public class TruckCarManager : CarManagerBase
{
    public TruckCar CreateCar(
        double tankCapacity,
        double averageFuelRate,
        double loadCapacity,
        double loadPenalty = 0.04,
        double penaltyStep = 200)
    {
        if (tankCapacity is <= 0 or double.NaN or double.PositiveInfinity)
            throw new ArgumentException("Invalid value", nameof(tankCapacity));

        if (averageFuelRate is <= 0 or double.NaN or double.PositiveInfinity)
            throw new ArgumentException("Invalid value", nameof(averageFuelRate));

        if (loadCapacity is <= 0 or double.NaN or double.PositiveInfinity)
            throw new ArgumentException("Invalid value", nameof(loadCapacity));

        if (loadPenalty is <= 0 or double.NaN or double.PositiveInfinity)
            throw new ArgumentException("Invalid value", nameof(loadPenalty));

        return new TruckCar(tankCapacity, averageFuelRate, loadCapacity, loadPenalty, penaltyStep);
    }

    public double GetKmLeftWithLoad(TruckCar car, double load, double fuel)
    {
        if (load is <= 0 or double.NaN or double.PositiveInfinity)
            throw new ArgumentException("Invalid value", nameof(load));

        if (fuel is <= 0 or double.NaN or double.PositiveInfinity)
            throw new ArgumentException("Invalid value", nameof(fuel));
        
        if (fuel > car.TankCapacity)
            throw new ArgumentOutOfRangeException(nameof(fuel), "Too much fuel for the car's tank");

        if (load > car.LoadCapacity)
            throw new ArgumentOutOfRangeException(nameof(load), "Load is more than car's loadcapacity.");

        var newAvgFuelRate = car.AverageFuelRate;
        var penaltySteps = Math.Ceiling(load / car.PenaltyStep);

        for (var i = 0; i < penaltySteps; i++)
        {
            newAvgFuelRate += newAvgFuelRate * car.LoadPenalty;
        }

        return fuel / newAvgFuelRate * 100;
    }
}