using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.TeamworkProjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cntOfTeamsBeCreated = int.Parse(Console.ReadLine());
            var teams = new List<Team>();
            for (int i = 0; i < cntOfTeamsBeCreated; i++)
            {
                var curTeamCommands = Console.ReadLine().Split("-");
                var user = curTeamCommands[0];
                var teamName = curTeamCommands[1];
                if (teams.Any(currTeamNew => currTeamNew.Name == teamName)) // if already a team was created 
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (teams.Any(team => team.User == user))
                {
                    Console.WriteLine($"{user} cannot create another team!");
                }
                else
                {
                    var team = new Team();
                    team.Name = teamName;
                    team.User = user;
                    team.Members = new List<string>();
                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {user}!");
                }
            }
            var commandOne = Console.ReadLine();
            while (commandOne != "end of assignment")
            {
                var memberInfo = commandOne.Split(new string[] {"->"}, StringSplitOptions.RemoveEmptyEntries);
                var memberName = memberInfo[0];
                var teamToJoin = memberInfo[1];
                if (teams.Any(team => team.Members.Contains(memberName)) || teams.Any(user => user.User == memberName)) 
                { 
                    Console.WriteLine($"Member {memberName} cannot join team {teamToJoin}!"); 
                }                    
                else if (teams.All(team => team.Name != teamToJoin))
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                }
                else
                {
                    var currTeam = teams.Find(team => team.Name == teamToJoin);
                    currTeam.Members.Add(memberName);
                }
                commandOne = Console.ReadLine();                
                
            }
            var completeTeams = teams.Where(x => x.Members.Count > 0);
            var disTeams = teams.Where(teams => teams.Members.Count == 0);
            foreach (var teamOne in completeTeams.OrderByDescending(x => x.Members.Count).ThenBy(y => y.Name))
            {
                Console.WriteLine($"{teamOne.Name}");
                Console.WriteLine($"- {teamOne.User}");
                foreach (var member in teamOne.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }
            Console.WriteLine("Teams to disband:");
            if (disTeams != null)
            {
                foreach (var dissbanedTeam in disTeams.OrderBy(x => x.Name))
                {
                    Console.WriteLine($"{dissbanedTeam.Name}");
                }
            }
        }
    }
    class Team
    {
        public string Name { get; set; }
        public string User { get; set; }
        public List<string> Members { get; set; }
    }


}
