using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Xml;

namespace Cms20HockeyDemo
{
    class Program
    {
        static void Edit(int i)
        {
            i = i + 1;
        }


        static void Main(string[] args)
        {
            //int i = 1;
            //Edit(i);
            //Console.WriteLine(i);

            var team2 = new Team("AIK");
            team2.FromTown = "Solna";

            var player = new Player();
            player.Name = "Mats Alba";
            player.JerseyNumber = 4;
            player.Age = 51;



            team2.SetName("");
            if (team2.AddPlayer(player) == false)
            {
                
            }

            foreach (var p in team2.GetAllPlayers())
            {
                Console.WriteLine($"{p.JerseyNumber} {p.Name}");
            }


            //editteam(tea);
            //Console.WriteLine(tea.FromTown);

            var allTeams = new List<Team>();
            while (true)
            {
                Console.WriteLine("HUVUDMENY");
                Console.WriteLine("Select a team to work with:");

                int index = 0;
                foreach (var team in allTeams)
                {
                    Console.WriteLine($" {index+1}  {team.Name}, {team.FromTown}");
                    index++;
                }
                Console.WriteLine(" 99. Add new");
                Console.WriteLine(" 100. Exit");
                Console.Write(":>");
                int sel = Convert.ToInt32( Console.ReadLine() );
                if (sel == 100)
                    break;
                if (sel == 99)
                    allTeams.Add(AddNewTeam());
                else { 
                    var team = allTeams[sel - 1];
                    EditTeam(team);
                }
            }
        }

        private static Team AddNewTeam()
        {
            Console.WriteLine("Add new team");

            Console.Write("Name:");
            var namn = Console.ReadLine();
            Console.Write("From town:");
            var tows = Console.ReadLine();
            var team = new Team(namn);
            team.FromTown = tows;
            return team;
        }

        private static void EditTeam(Team team)
        {
            Console.WriteLine($"**** EDIT {team.Name} ****");
            Console.WriteLine($"Enter new name (leave blank to keep {team.Name}))");
            var namn = Console.ReadLine();
            if (!string.IsNullOrEmpty(namn))
                team.SetName(namn);
            Console.WriteLine($"Enter new town (leave blank to keep {team.FromTown}))");
            var city = Console.ReadLine();
            if (!string.IsNullOrEmpty(city))
                team.FromTown = city;
        }
    }
}
