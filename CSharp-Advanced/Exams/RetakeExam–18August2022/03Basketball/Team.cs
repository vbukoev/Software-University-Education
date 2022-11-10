using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private List<Player> players;
        public Team(string name, int openPositions, char group)
        {
            this.Name = name;
            this.OpenPositions = openPositions;
            this.Group = group;
            this.players = new List<Player>();
        }
        public string Name { get; private set; }
        public int OpenPositions { get; private set; }
        public char Group { get; private set; }

        public IReadOnlyCollection<Player> Players => this.players;
        public int Count => this.Players.Count;
        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position)) return "Ivalid player's information.";
            else if (this.OpenPositions == 0) return "There are no more positions.";
            else if (player.Rating < 80) return "Invalid player's rating.";
            else
            {
                this.players.Add(player);
                this.OpenPositions -= 1;
                return $"Successfully added {player.Name} to the team. Remaining open positions: {this.OpenPositions}.";
            }
        }
        public bool RemovePlayer(string name)
        {
            Player target = this.Players.FirstOrDefault(x => x.Name == name);
            if (target == null) return false;
            this.OpenPositions += 1;
            this.players.Remove(target);
            return true;
        }
        public int RemovePlayerByPosition(string position)
        {
            int cnt = 0;
            while (this.Players.FirstOrDefault(x => x.Position == position) != null)
            {
                Player target = this.Players.FirstOrDefault(x => x.Position == position);
                this.OpenPositions += 1;
                this.players.Remove(target);
                cnt += 1;
            }
            return cnt;
        }
        public Player RetirePlayer(string name)
        {
            Player target = this.Players.FirstOrDefault(x => x.Name == name);
            if (target == null) return null;
            target.Retired = true;
            return target;
        }
        public List<Player> AwardPlayers(int games)
        {
            List<Player> newList = new List<Player>();
            foreach (var item in this.Players.Where(x => x.Games >= games)) newList.Add(item);
            return newList;
        }
        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Active players competing for Team {this.Name} from Group {this.Group}:");
            foreach (var item in this.Players.Where(x => x.Retired != true)) result.AppendLine(item.ToString());
            return result.ToString().TrimEnd();
        }
    }
}
