using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.FootballTeamGenerator
{
    public class Program
    {
        static void Main()
        {
            List<Team> teams = new List<Team>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] args = cmd.Split(';');
                string cmdType = args[0];
                string teamName = args[1];

                try
                {
                    if (cmdType == "Team")
                    {
                        Team team = new Team(teamName);
                        teams.Add(team);
                    }
                    else
                    {
                        if (teams.All(t => t.Name != teamName))
                        {
                            throw new ArgumentException(string.Format(Exceptions.TeamException, teamName));
                        }

                        Team team = teams.First(t => t.Name == teamName);

                        switch (cmdType)
                        {
                            case "Add":
                            {
                                string playerName = args[2];
                                Stats stats = new Stats(int.Parse(args[3]), int.Parse(args[4]), int.Parse(args[5]), int.Parse(args[6]), int.Parse(args[7]));
                                Player player = new Player(playerName, stats);
                                team.AddPlayer(player);
                                break;
                            }
                            case "Remove":
                            {
                                string playerName = args[2];
                                team.RemovePlayer(playerName);
                                break;
                            }
                            case "Rating":
                                Console.WriteLine(team);
                                break;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
