using CarRacing.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using CarRacing.Models.Racers;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository carRepository;
        private RacerRepository racerRepository;
        private IMap map;

        public Controller()
        {
            carRepository = new CarRepository();
            racerRepository = new RacerRepository();
            map = new Map();
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car;
            if (type == "SuperCar")
            {
                car = new SuperCar(make, model, VIN, horsePower);
            } 
            else if (type == "TunedCar")
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            else throw new ArgumentException(ExceptionMessages.InvalidCarType);

            carRepository.Add(car);
            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            IRacer racer;
            ICar car = carRepository.FindBy(carVIN);
            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            if (type == "ProfessionalRacer")
            {
                racer = new ProfessionalRacer(username, car);
            }
            else if (type == "StreetRacer")
            {
                racer = new StreetRacer(username, car);
            }
            else throw new ArgumentException(ExceptionMessages.InvalidRacerType);

            racerRepository.Add(racer);
            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = racerRepository.FindBy(racerOneUsername);
            IRacer racerTwo = racerRepository.FindBy(racerTwoUsername);
            if (racerOne == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }
            if (racerTwo == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

            return map.StartRace(racerOne, racerTwo);
        }

        public string Report()
            => string.Join(Environment.NewLine,
                racerRepository.Models.OrderByDescending(x => x.DrivingExperience).ThenBy(x => x.Username));
    }
}
