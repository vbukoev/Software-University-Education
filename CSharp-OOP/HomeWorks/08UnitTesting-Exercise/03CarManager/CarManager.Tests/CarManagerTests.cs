using System;

namespace CarManager.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private const string DefaultMake = "Nissan";
        private const string DefaultModel = "GTR";
        private const double DefaultFuelConsumption = 15.8;
        private const double DefaultFuelTank = 92.0;
        private Car car;

        [SetUp]
        public void SetUp()
        {
            car = new Car(DefaultMake, DefaultModel, DefaultFuelConsumption, DefaultFuelTank);
        }

        [Test]
        public void CreatingAProperCar()
        {
            Assert.AreEqual(DefaultModel, car.Model);
            Assert.AreEqual(DefaultFuelConsumption, car.FuelConsumption);
            Assert.AreEqual(DefaultMake, car.Make);
            Assert.AreEqual(DefaultFuelTank, car.FuelCapacity);
            Assert.AreEqual(car.FuelAmount, 0);
        }

        [TestCase(null)]
        [TestCase("")]
        public void PropertyMakeCannotBeNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() =>
                car = new Car(make, DefaultModel, DefaultFuelConsumption, DefaultFuelTank));
        }

        [TestCase(null)]
        [TestCase("")]
        public void PropertyModelCannotBeNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() =>
                car = new Car(DefaultMake, model, DefaultFuelConsumption, DefaultFuelTank));
        }

        [TestCase(0)]
        [TestCase(-1.213)]
        public void PropertyFuelConsumptionCannotBeZeroOrNegative(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
                car = new Car(DefaultMake, DefaultModel, fuelConsumption, DefaultFuelTank));
        }

        [TestCase(0)]
        [TestCase(-12.213)]
        public void PropertyFuelTankCapacityCannotBeZeroOrNegative(double fuelTankCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
                car = new Car(DefaultMake, DefaultModel, DefaultFuelConsumption, fuelTankCapacity));
        }

        
        [Test]
        public void PropertyFuelAmountCannotBeANegativeNumber()
        {
            Assert.Throws<InvalidOperationException>(() => car.Drive(20));
        }

        [TestCase(0)]
        [TestCase(-8.1)]
        public void FuelCannotBeZeroOrNegative(double value)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(value));
        }

        [TestCase(1.0)]
        [TestCase(15.8)]
        [TestCase(40.99)]
        public void RefuelShouldIncreaseTheFuel(double value)
        {
            double expectedRefuel = car.FuelAmount + value;
            car.Refuel(value);

            Assert.AreEqual(car.FuelAmount, expectedRefuel);
        }

        [Test]
        public void RefuelFuelShouldNotBeHigherThanCapacity()
        {
            double fuel = DefaultFuelTank + 10;
            car.Refuel(fuel);
            Assert.AreEqual(car.FuelAmount, DefaultFuelTank);
        }

        [TestCase(1)] 
        [TestCase(24.5)] 
        [TestCase(31.375)] 

        public void DriveDecreasesFuelAmount(double distance)
        {
            car.Refuel(50);
            double expectedAmount = car.FuelAmount - distance/100 * car.FuelConsumption;
            car.Drive(distance);
            Assert.AreEqual(expectedAmount, car.FuelAmount);
        }
    }
}