using System;
using System.Collections.Generic;

namespace Basketball
{
    public class StartUp
    {
        static void Main()
        {
            // Initialize the repository (Team)
            Team team = new Team("BHTC", 5, 'A');

            // Initialize entity
            Player firstPlayer = new Player("Viktor", "Center", 97.5, 10);

            // Print player
            Console.WriteLine(firstPlayer);

            // Add Renovator
            Console.WriteLine(team.AddPlayer(firstPlayer));

            // Check count of added players
            Console.WriteLine(team.Count);

            // Remove Renovator
            Console.WriteLine(team.RemovePlayer("Slavi"));

            Player secondPlayer = new Player("Slavi", "Point Guard", 94.3, 47);
            Player thirdPlayer = new Player("Evgeni", "Shooting Guard", 93.7, 16);
            Player fourthPlayer = new Player("Momchil", "Small forward", 67.9, 3);
            Player fifthPlayer = new Player("Vasil", "Power forward", 86.9, 10);
            Player sixthPlayer = new Player("Stefan", "Center", 95.6, 25);
            Player seventhPlayer = new Player("Ivan", " Small forward ", 98.5, 89);

            // Add players
            Console.WriteLine(team.AddPlayer(secondPlayer));
            Console.WriteLine(team.AddPlayer(thirdPlayer));
            Console.WriteLine(team.AddPlayer(fourthPlayer));
            Console.WriteLine(team.AddPlayer(fifthPlayer));
            Console.WriteLine(team.AddPlayer(sixthPlayer));
            Console.WriteLine(team.AddPlayer(seventhPlayer));

            // Retire player by name
            Console.WriteLine(team.RetirePlayer("Slavi"));

            //Award player
            List<Player> players = team.AwardPlayers(15);
            foreach (var playerToBeAwarded in players)
            {
                Console.WriteLine(playerToBeAwarded);
            }

            //Remove player by position
            Console.WriteLine(team.RemovePlayerByPosition("Center"));

            // Report
            Console.WriteLine("----------------------Report----------------------");
            Console.WriteLine(team.Report());
        }
    }
}
