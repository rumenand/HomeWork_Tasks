using System;
using System.Collections.Generic;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System.Linq;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<IPlayer> list;
        public PlayerRepository()
        {
            this.list = new List<IPlayer>();
        }
        public int Count => this.list.Count;

        public IReadOnlyCollection<IPlayer> Players => this.list.AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player == null) throw new ArgumentException("Player cannot be null");
            var chPlayer = this.Find(player.Username);
            if (chPlayer != null) throw new ArgumentException($"Player {player.Username} already exists!");
            this.list.Add(player);
        }

        public IPlayer Find(string username)
        {
            return this.list.Where(x => x.Username == username).FirstOrDefault();
        }

        public bool Remove(IPlayer player)
        {
            if (player == null) throw new ArgumentException("Player cannot be null");
            return this.list.Remove(player);
        }
    }
}
