using System;
using System.Text;

namespace Basketball
{
    public class Player
    {
        public Player(string name, string position, double rating, int games)
        {
            this.Name = name;
            this.Position = position;
            this.Rating = rating;
            this.Games = games;
        }
        public string Name { get; private set; }
        public string Position { get; private set; }
        public double Rating { get; private set; }
        public int Games { get; private set; }
        public bool Retired { get; set; } = false;
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"-Player: {this.Name}");
            result.AppendLine($"--Position: {this.Position}");
            result.AppendLine($"--Rating: {this.Rating}");
            result.AppendLine($"--Games played: {this.Games}");
            return result.ToString().TrimEnd();
        }
    }
}
