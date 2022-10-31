using System;
using System.Collections.Generic;
using System.Linq;

namespace _05FootballTeamGenerator
{
    public class StartUp
    {
        private static List<Team> teamList;
        static void Main()
        {
            teamList = new List<Team>();
            RunEngine();            
        }
        static void RunEngine()
        {
            string cmd;
            
            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = cmd.Split(';');
                string cmdType = cmdArgs[0];
                string teamName = cmdArgs[1];
                try
                {
                    if (cmdType == "Team")
                    {
                        Team newTeam = new Team(teamName);
                        teamList.Add(newTeam);
                    }
                    else if (cmdType == "Add") //adding player to a team
                    {
                        Team joiningTeam = teamList.FirstOrDefault(t => t.Name == teamName);
                        if (joiningTeam == null)
                        {
                            throw new InvalidOperationException(string.Format(ExceptionMessages.InexistingTeamMessage, teamName));
                        }
                        string playerName = cmdArgs[2];
                        int endurance = int.Parse(cmdArgs[3]);
                        int sprint = int.Parse(cmdArgs[4]);
                        int dribble = int.Parse(cmdArgs[5]);
                        int passing = int.Parse(cmdArgs[6]);
                        int shooting = int.Parse(cmdArgs[7]);
                        Player joiningPlayer = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        joiningTeam.AddPlayer(joiningPlayer);
                    }
                    else if (cmdType == "Remove")
                    {
                        string playerName = cmdArgs[2];
                        Team removingTeam = teamList.FirstOrDefault(x => x.Name == teamName);
                        if (removingTeam == null)
                        {
                            throw new InvalidOperationException(string.Format(ExceptionMessages.InexistingTeamMessage, teamName));
                        }
                        removingTeam.RemovePlayer(playerName);
                    }
                    else if (cmdType == "Rating")
                    {
                        Team teamToRate = teamList.FirstOrDefault(x => x.Name == teamName);
                        if (teamToRate == null)
                        {
                            throw new InvalidOperationException(string.Format(ExceptionMessages.InexistingTeamMessage, teamName));
                        }
                        Console.WriteLine(teamToRate);
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
               
            }
        }
    }
}
