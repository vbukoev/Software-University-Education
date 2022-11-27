using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        private const double Strict = 1.2;
        private const double Aggressive = 1.1;
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            if (racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            if (racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            
            racerOne.Race();
            racerTwo.Race();
            double raceMultiplyOne = racerOne.RacingBehavior == "strict" ? Strict : Aggressive;
            double racerOneScore = racerOne.Car.HorsePower * racerOne.DrivingExperience * raceMultiplyOne;
            double raceMultiplySecond = racerTwo.RacingBehavior == "strict" ? Strict : Aggressive;
            double racerTwoScore = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * raceMultiplySecond;
            IRacer winRacer = racerOneScore > racerTwoScore ? racerOne : racerTwo;

            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winRacer.Username);
        }
    }
}
