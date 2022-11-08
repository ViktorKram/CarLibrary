namespace Tests;

[TestClass]
public class TruckCarManagerTests
{
    private readonly TruckCarManager _carManager = new();

    [TestMethod]
    public void CreateCar_ValidParams_CarIsNotNull()
    {
        var car = _carManager.CreateCar(1, 1, 1);

        Assert.IsNotNull(car);
    }

    [TestMethod]
    [DataRow(double.NaN, 1, 1)]
    [DataRow(1, double.NaN, 1)]
    [DataRow(1, 1, double.NaN)]
    [DataRow(double.PositiveInfinity, 1, 1)]
    [DataRow(1, double.PositiveInfinity, 1)]
    [DataRow(1, 1, double.PositiveInfinity)]
    [DataRow(double.NegativeInfinity, 1, 1)]
    [DataRow(1, double.NegativeInfinity, 1)]
    [DataRow(1, 1, double.NegativeInfinity)]
    [DataRow(-1, 1, 1)]
    [DataRow(1, -1, 1)]
    [DataRow(1, 1, -1)]
    [DataRow(0, 1, 1)]
    [DataRow(1, 0, 1)]
    [DataRow(1, 1, 0)]
    public void CreateCar_ParamsAreInvalid_ThrowsException(double tankCapacity, double averageFuelRate,
        double loadCapacity)
    {
        Assert.ThrowsException<ArgumentException>(() =>
            _carManager.CreateCar(tankCapacity, averageFuelRate, loadCapacity));
    }

    [TestMethod]
    public void GetKmLeftWithLoad_ReturnsCorrectDistance()
    {
        var car = _carManager.CreateCar(2, 1, 1);
        var expectedDistance = 192.3076923076923;

        var actualDistance = _carManager.GetKmLeftWithLoad(car, 1, 2);

        Assert.AreEqual(expectedDistance, actualDistance);
    }

    [TestMethod]
    [DataRow(double.NaN, 1)]
    [DataRow(1, double.NaN)]
    [DataRow(double.PositiveInfinity, 1)]
    [DataRow(1, double.PositiveInfinity)]
    [DataRow(double.NegativeInfinity, 1)]
    [DataRow(1, double.NegativeInfinity)]
    [DataRow(-1, 1)]
    [DataRow(1, -1)]
    [DataRow(0, 1)]
    [DataRow(1, 0)]
    public void GetKmLeftWithLoad_ParamsAreInvalid_ThrowsException(double load, double fuel)
    {
        var car = _carManager.CreateCar(2, 1, 1);

        Assert.ThrowsException<ArgumentException>(() => _carManager.GetKmLeftWithLoad(car, load, fuel));
    }
    
    [TestMethod]
    public void GetKmLeftWithLoad_LoadIsMoreThanLoadCapacity_ThrowsException()
    {
        var car = _carManager.CreateCar(2, 1, 1);

        Assert.ThrowsException<ArgumentOutOfRangeException>(() => _carManager.GetKmLeftWithLoad(car, 2, 1));
    }
    
    [TestMethod]
    public void GetKmLeft_ReturnsCorrectDistance()
    {
        var car = _carManager.CreateCar(2, 1, 1);
        var expectedDistance = 200;

        var actualDistance = _carManager.GetKmLeft(car, 2);

        Assert.AreEqual(expectedDistance, actualDistance);
    }
    
    [TestMethod]
    [DataRow(double.NaN)]
    [DataRow(double.PositiveInfinity)]
    [DataRow(double.NegativeInfinity)]
    [DataRow(-1)]
    [DataRow(0)]
    public void GetKmLeft_InvalidFuelValue_ThrowsException(double fuel)
    {
        var car = _carManager.CreateCar(2, 1, 1);

        Assert.ThrowsException<ArgumentException>(() => _carManager.GetKmLeft(car, fuel));
    }
    
    [TestMethod]
    public void GetTravelTimeInHours_ReturnsCorrectDistance()
    {
        var car = _carManager.CreateCar(2, 1, 1);
        var expectedTime = 1;

        var actualDistance = _carManager.GetTravelTimeInHours(car, 100, 2, 100);

        Assert.AreEqual(expectedTime, actualDistance);
    }
    
    [TestMethod]
    [DataRow(double.NaN, 2, 100)]
    [DataRow(100, double.NaN, 100)]
    [DataRow(100, 2, double.NaN)]
    [DataRow(double.NegativeInfinity, 2, 100)]
    [DataRow(100, double.NegativeInfinity, 100)]
    [DataRow(100, 2, double.NegativeInfinity)]
    [DataRow(double.PositiveInfinity, 2, 100)]
    [DataRow(100, double.PositiveInfinity, 100)]
    [DataRow(100, 2, double.PositiveInfinity)]
    [DataRow(-1, 2, 100)]
    [DataRow(100, -1, 100)]
    [DataRow(100, 2, -1)]
    [DataRow(0, 2, 100)]
    [DataRow(100, 0, 100)]
    [DataRow(100, 2, 0)]
    public void GetTravelTimeInHours_ParamsAreInvalid_ThrowsException(double distanceByKm, double fuel, double speed)
    {
        var car = _carManager.CreateCar(2, 1, 1);

        Assert.ThrowsException<ArgumentException>(
            () => _carManager.GetTravelTimeInHours(car, distanceByKm, fuel, speed));
    }
}