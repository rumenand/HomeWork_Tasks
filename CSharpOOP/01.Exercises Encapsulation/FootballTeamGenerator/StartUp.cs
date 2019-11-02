using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    class StartUp
    {
        static void Main()
        {
            Func<string, int> parser = x => int.Parse(x);
            var teams = new List<Team>();
            string input;
           
          while ((input = Console.ReadLine()) != "END")
          {
                try
                {
                    var args = input.Split(";");
                    switch(args[0])
                    {
                        case "Team":
                            teams.Add(new Team(args[1]));
                            break;
                        case "Add":                           
                            GetTeam(args[1],teams).AddPlayer(new Player(args[2], parser(args[3]), parser(args[4])
                                , parser(args[5]), parser(args[6]), parser(args[7])));
                            break;
                        case "Remove":
                            GetTeam(args[1], teams).RemovePlayer(args[2]);
                            break;
                        case "Rating":
                            Console.WriteLine($"{args[1]} - {GetTeam(args[1],teams).Rating()}");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
        }

        static Team GetTeam(string name, List<Team> list)
        {
            var team = list.Where(x => x.Name == name).FirstOrDefault();
            if (team == null) throw new ArgumentException($"Team {name} does not exist.");
            return team;
        }
    }
}
