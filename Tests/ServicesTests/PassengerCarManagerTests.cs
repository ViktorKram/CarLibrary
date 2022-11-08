﻿namespace Tests;

[TestClass]
public class PassengerCarManagerTests
{
    private readonly PassengerCarManager _carManager = new();

    [TestMethod]
    public void CreateCar_ValidParams_CarIsNotNull()
    {
        var car = _carManager.CreateCar(1, 1, 1);

        Assert.IsNotNull(car);
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
    public void CreateCar_ParamsAreInvalid_ThrowsException(double tankCapacity, double averageFuelRate)
    {
        Assert.ThrowsException<ArgumentException>(() => _carManager.CreateCar(tankCapacity, averageFuelRate, 1));
    }

    [TestMethod]
    public void GetKmLeftWithPassengers_ReturnsCorrectDistance()
    {
        var car = _carManager.CreateCar(2, 1, 1);
        var expectedDistance = 188.67924528301885;

        var actualDistance = _carManager.GetKmLeftWithPassengers(car, 1, 2);

        Assert.AreEqual(expectedDistance, actualDistance);
    }

    [TestMethod]
    [DataRow(double.NaN)]
    [DataRow(double.PositiveInfinity)]
    [DataRow(double.NegativeInfinity)]
    [DataRow(-1)]
    [DataRow(0)]
    public void GetKmLeftWithPassengers_InvalidFuelValue_ThrowsException(double fuel)
    {
        var car = _carManager.CreateCar(2, 1, 1);

        Assert.ThrowsException<ArgumentException>(() => _carManager.GetKmLeftWithPassengers(car, 1, fuel));
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