using System;
using System.Collections.Generic;
using System.Linq;
using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private CarRepository cars;
        private DriverRepository drivers;
        private RaceRepository races;

        public ChampionshipController()
        {
            cars = new CarRepository();
            drivers = new DriverRepository();
            races = new RaceRepository();
        }

        public string CreateDriver(string driverName)
        {
            if (drivers.Models.Any(x=>x.Name == driverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            IDriver driver = new Driver(driverName);

            drivers.Add(driver);

            return String.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (cars.Models.Any(x => x.Model == model))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            ICar car = null;

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }
            cars.Add(car);

            return String.Format(OutputMessages.CarCreated, car.GetType().Name, model );
        }

        public string CreateRace(string name, int laps)
        {
            if (races.Models.Any(x=>x.Name == name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            IRace race = new Race(name, laps);
            races.Add(race);
            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (!races.Models.Any(x=>x.Name == raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (!drivers.Models.Any(x=>x.Name == driverName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            IRace race = races.GetByName(raceName);
            IDriver driver= drivers.GetByName(driverName);

            race.AddDriver(driver);
            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            if (!drivers.Models.Any(x=>x.Name == driverName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            if (!cars.Models.Any(x=>x.Model == carModel))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            IDriver driver = drivers.GetByName(driverName);
            ICar car = cars.GetByName(carModel);

            driver.AddCar(car);
            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string StartRace(string raceName)
        {
            if (!races.Models.Any(x => x.Name == raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            IRace race = races.GetByName(raceName);
            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            IEnumerable<IDriver> drivers = race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)).Take(3);

            IDriver first = drivers.First();
            IDriver second = drivers.Skip(1).First();
            IDriver third = drivers.Skip(2).First();

            races.Remove(race);

            return string.Format(OutputMessages.DriverFirstPosition, first.Name, raceName) + Environment.NewLine +
                   string.Format(OutputMessages.DriverSecondPosition, second.Name, raceName) + Environment.NewLine +
                   string.Format(OutputMessages.DriverThirdPosition, third.Name, raceName);
        }
    }
}