using System;
using System.Runtime.CompilerServices;
using NUnit.Framework;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            private const string DefaultCar = "Default Car";
            private const int DefaultCarIssues = 1;

            private const string DefaultGarageName = "Default Garage";
            private const int DefaultGarageMechanics = 2;

            private Car car;
            private Garage garage;

            [SetUp]
            public void SetUp()
            {
                car = new Car(DefaultCar, DefaultCarIssues);
                garage = new Garage(DefaultGarageName, DefaultGarageMechanics);
            }

            [Test]
            public void ConstructorOfTheCarWorks()
            {
                bool fix = false;
                car = new Car(DefaultCar, DefaultCarIssues);
                Assert.IsTrue(car.CarModel == DefaultCar &&
                              car.NumberOfIssues == DefaultCarIssues && 
                              car.IsFixed == fix);
            }

            [Test]
            public void CarFixedReturnsTrue()
            {
                car = new Car(DefaultCar, 0);
                Assert.AreEqual(car.IsFixed, true);
            }

            [Test]
            public void GarageWorksFine()
            {
                garage = new Garage(DefaultGarageName, DefaultGarageMechanics);
                Assert.IsTrue(garage.Name == DefaultGarageName &&
                              garage.MechanicsAvailable == DefaultGarageMechanics &&
                              garage.CarsInGarage == 0);
            }


            [TestCase("")]
            [TestCase(null)]
            public void GarageNameCanNotBeNullOrEmpty(string name)
            {
                Assert.Throws<ArgumentNullException>(() =>
                    garage = new Garage(name, DefaultGarageMechanics));
            }

            [Test]
            public void GarageMechanicsAvailableCantBeZero()
            {
                Assert.Throws<ArgumentException>(() => garage = new Garage(DefaultGarageName, 0));
            }

            [Test]
            public void AddCarIncreasesCount()
            {
                garage.AddCar(car);
                Assert.AreEqual(1, garage.CarsInGarage);
            }

            [Test]
            public void NoMechanicsThrowWhenNoOneAvailable()
            {
                Car car = new Car("Test", 0);
                Car car2 = new Car("Test2", 1);
                garage.AddCar(car);
                garage.AddCar(car2);
                Assert.Throws<InvalidOperationException>(() => garage.AddCar(car2));
            }

            [Test]
            public void GarageFixCar()
            {
                garage.AddCar(car);
                garage.FixCar(car.CarModel);
                Assert.True(car.IsFixed);
            }

            [Test]
            public void RemoveFixedCarsFromTheGarage()
            {
                garage.AddCar(car);
                Assert.Throws<InvalidOperationException>(()=>garage.RemoveFixedCar());
            }

            [Test]
            public void GarageRemoveReturnsFixedCarsProperly()
            {
                garage.AddCar(car);
                garage.FixCar(car.CarModel);
                Assert.AreEqual(1, garage.RemoveFixedCar());
            }

            //[Test]
            //public void ReportWorksFine()
            //{
            //    Car forFixing1 = new Car("Car1", 1);
            //    Car forFixing2 = new Car("Car2", 2);

            //    garage.AddCar(forFixing1);
            //    garage.AddCar(forFixing2);

            //    Assert.AreEqual(garage.Report(), $"There are 2 which are not fixed: {forFixing1.CarModel}, {forFixing2.CarModel}.");
            //}
        }
    }
}