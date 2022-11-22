using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;
using Formula1.Models.Contracts;
using Formula1.Utilities;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private readonly List<IPilot> pilots;
        private int laps;

        public Race(string raceName, int laps)
        {
            RaceName = raceName;
            NumberOfLaps = laps;
            TookPlace = false;
            pilots = new List<IPilot>();
        }

        public string RaceName
        {
            get => raceName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }
                raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get => laps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }
                laps = value;
            }

        }
        public bool TookPlace { get; set; }
        public ICollection<IPilot> Pilots => pilots.AsReadOnly();
        public void AddPilot(IPilot pilot)
        {
            pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();

            var tookPlace = TookPlace ? "Yes" : "No";

            sb.AppendLine($"The {RaceName} race has:");
            sb.AppendLine($"Participants: {pilots.Count}");
            sb.AppendLine($"Number of laps: {NumberOfLaps}");
            sb.Append($"Took place: {tookPlace}");

            return sb.ToString().TrimEnd();
        }
    }
}
