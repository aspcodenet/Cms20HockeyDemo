using System.Collections.Generic;

namespace Cms20HockeyDemo
{
    public class Player
    {
        public string Name { get; set; }
        public int JerseyNumber { get; set; }

        public int Age { get; set; }
    }

    public class Team
    {
        private List<Player> Players { get; set; }
        public string Name { get; private set; }

        public void SetName(string newName)
        {
            if (string.IsNullOrEmpty(newName)) return;

            Name = newName;
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return Players;
        }

        public bool AddPlayer(Player p)
        {
            if (Players.Count >= 18)
                return false;

            Players.Add(p);
            return true;
        }

        public string FromTown { get; set; }

        public Team(string name)
        {
            Name = name;
            Players = new List<Player>();
        }
    }
    

}