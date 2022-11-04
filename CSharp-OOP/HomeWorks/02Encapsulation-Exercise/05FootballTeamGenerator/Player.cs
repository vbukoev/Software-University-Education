namespace _05FootballTeamGenerator
{
    using System;
    public class Player
    {
        private string name;
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Stats = new Stats(endurance, sprint, dribble, passing, shooting);
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    //we should never directly write on the console in getters/setters/ctors/methods...
                    //we should not access directly the console or another writer in the model class 
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }
        public Stats Stats { get; private set; }
        public double OverallRating => (this.Stats.Endurance + this.Stats.Sprint + this.Stats.Dribble + this.Stats.Passing + this.Stats.Shooting) / 5.0; // the overall rating of a player
    }
}
