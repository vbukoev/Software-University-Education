using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Guild
{
    public class Guild
    {
        private readonly List<Player> roster;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.roster.Count; } }
        public Guild(string name, int capacity)
        {
            this.roster = new List<Player>();
            Name = name;
            Capacity = capacity;
        }
        public void AddPlayer(Player player)
        {
            if (this.roster.Count < this.Capacity) this.roster.Add(player);
        }
        public bool RemovePlayer(string name)
        {
            return this.roster.Remove(this.roster.Find(x => x.Name == name));
        }
        public void PromotePlayer(string name)
        {
            if (this.roster.Find(x => x.Name == name) != null) this.roster.Find(x => x.Name == name).Rank = "Member";

        }
        public void DemotePlayer(string name)
        {
            if (this.roster.Find(x => x.Name == name) != null) this.roster.Find(x => x.Name == name).Rank = "Trial";
        }
        public Player[] KickPlayersByClass(string @class)
        {
            Player[] players = this.roster.FindAll(x => x.Class == @class).ToArray();
            this.roster.RemoveAll(x => x.Class == @class);
            return players;
        }
        public string Report()
        {
            return $"Players in the guild: {this.Name}" + "\n" + String.Join("\n", this.roster);
        }
    }
}
