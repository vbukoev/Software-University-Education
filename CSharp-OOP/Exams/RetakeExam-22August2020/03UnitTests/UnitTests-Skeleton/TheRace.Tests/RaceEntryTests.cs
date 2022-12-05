using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {
        private const string carModel = "modelCar";
        private const int carHorsePower = 200;
        private const double carCubicCM = 1700;
        private const string driverName = "name";

        private UnitCar car;
        private UnitDriver driver;
        private RaceEntry raceEntry;
        private string addResult;

        [SetUp]
        public void Setup()
        {
            car = new UnitCar(carModel, carHorsePower, carCubicCM);
            driver = new UnitDriver(driverName, car);
            raceEntry = new RaceEntry();
            addResult = raceEntry.AddDriver(driver);
        }

        [Test]
        public void TestOne()
        {
            Assert.AreEqual($"Driver {driver.Name} added in race.", addResult);
            Assert.AreEqual(raceEntry.Counter, 1);
        }

        [Test]
        public void AddDriver_ThrowsWhenNull()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null));
        }

        [Test]
        public void AddDriver_AlreadyAdded()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(driver));
        }

        [Test]
        public void CalculateAverageHorsePowerThrowsWhenNotEnoughCompetitors()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePowerReturnsCorrectResult()
        {
            raceEntry.AddDriver(new UnitDriver("secName", new UnitCar("new Model", 300, 2000)));
            Assert.AreEqual((carHorsePower + 300)/2, raceEntry.CalculateAverageHorsePower());
        }
    }
}