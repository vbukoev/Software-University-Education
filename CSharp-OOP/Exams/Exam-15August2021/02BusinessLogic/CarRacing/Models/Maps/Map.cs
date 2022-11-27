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
            if (!racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            if (!racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            
            racerOne.Race();
            racerTwo.Race();
            
            double racerOneScore = DriveAndGetRacerScore(racerOne);
            
            double racerTwoScore = DriveAndGetRacerScore(racerTwo);
            IRacer winRacer = racerOneScore > racerTwoScore ? racerOne : racerTwo;

            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winRacer.Username);
        }
        private double DriveAndGetRacerScore(IRacer racer)
        {
            double racerMultiplier = racer.RacingBehavior == "strict" ? Strict : Aggressive;
            return racer.Car.HorsePower * racer.DrivingExperience * racerMultiplier;
        }
    }
}
