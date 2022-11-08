namespace CarLibrary;

public interface ICarManager
{
    double GetKmLeft(Car car, double fuel);
    double GetTravelTimeInHours(Car car, double distanceByKm, double fuel, double speed);
}