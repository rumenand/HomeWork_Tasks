using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private List<Player> players;
        public Team(string name)
        {
            this.players = new List<Player>();
            this.Name = name;
        }
        public string Name { get; private set; }

        internal void AddPlayer(Player player)
        {
            players.Add(player);
        }

        internal void RemovePlayer(string name)
        {
            var currentPlayer = players.Where(x => x.Name == name).FirstOrDefault();
            if (currentPlayer == null) throw new ArgumentException($"Player {name} is not in {this.Name} team.");
            players.Remove(currentPlayer);
        }

        internal int Rating()
        {
           if (players.Any()) return (int) players.Sum(x => x.averageSkills) / players.Count;
            return 0;
        }

    }
}
