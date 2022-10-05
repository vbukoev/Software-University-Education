using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Basketball;

namespace Basketball
{
    public class Team : IEnumerable<Player>
    {
        private Player[] data = new Player[4];
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public int Count { get; private set; } = 0;
        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
        }
        public IEnumerator<Player> GetEnumerator()
        {
            foreach (var item in this)
            {
                yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public string AddPlayer(Player player)
        {
            if (player.Name == null || player.Name == "") return InvalidException();
            else if (player.Position == null || player.Position == "") return InvalidException();
            else if (OpenPositions == 0) return NoMorePositions();
            else if (player.Rating < 80) return InvalidRating();
            else
            {
                if (data.Length == Count) ExtensionOfTheData();
                data[Count] = player;
                Count += 1;
                OpenPositions -= 1;
                return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
            }
        }
        public bool RemovePlayer(string name)
        {
            Player[] dataNew = new Player[data.Length];
            int cnt = 0;
            bool haveAPlayer = false;
            for (int i = 0; i < Count; i++)
            {
                if (data[i].Name == name)
                {
                    haveAPlayer = true;
                    continue;
                }
                dataNew[cnt] = data[i];
                cnt += 1;
            }
            if (haveAPlayer)
            {
                cnt -= 1;
                OpenPositions += 1;
                data = dataNew;
            }
            return haveAPlayer;
        }
        public int RemovePlayerByPosition(string position)
        {
            Player[] dataNew = new Player[data.Length];
            int cnt = 0;
            int constant = 0;
            for (int i = 0; i < Count; i++)
            {
                if (data[i].Position == position)
                {
                    cnt++;
                    continue;
                }
                dataNew[constant] = data[i];
                constant++;
            }
            Count -= cnt;
            OpenPositions += cnt;
            data = dataNew;
            return cnt;
        }
        public Player RetirePlayer(string name)
        {
            for (int i = 0; i < Count; i++)
            {
                if (data[i].Name== "name")
                {
                    data[i].Retired = true;
                    return data[i];
                }
            }
            return null;
        }
        public List<Player> AwardPlayers(int games)
        {
            List<Player> newList = new List<Player>();
            for (int i = 0; i < Count; i++)
            {
                if (data[i].Games>=games)
                {
                    newList.Add(data[i]);
                }
            }
            return newList;
        }
        public string Report()
        {
            string result = $"Active players competing for Team {Name} from Group {Group}:";
            for (int i = 0; i < Count; i++)
            {
                if (!data[i].Retired)
                {
                    Console.WriteLine(result);
                    Console.WriteLine(data[i].Name);
                }
            }
            return result;
        }
        public void ExtensionOfTheData()
        {
            Player[] datNew = new Player[data.Length * 2];
            for (int i = 0; i < data.Length; i++)
            {
                datNew[i] = data[i];
            }
            data = datNew;
        }

        public static string InvalidRating()
        {
            return "Invalid player's rating.";
        }

        public static string NoMorePositions()
        {
            return "There are no more positions.";
        }

        public static string InvalidException()
        {
            return "Ivalid player's information.";
        }
    }
}
