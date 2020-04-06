using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories.Contracts;
using ViceCity.Repositories;
using System;

namespace ViceCity.Models.Players
{
    public abstract class Player : IPlayer
    {
        protected Player(string name, int lifePoints)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Player's name cannot be null or a whitespace!");
            this.Name = name;
            if (lifePoints < 0) throw new
                ArgumentException("Player life points cannot be below zero!");
            this.LifePoints = lifePoints;
            this.GunRepository = new GunRepository();
        }
        public string Name { get; }

        public bool IsAlive => this.LifePoints > 0;

        public IRepository<IGun> GunRepository { get; }

        public int LifePoints { get; private set; }

        public void TakeLifePoints(int points)
        {
            if (this.LifePoints > points) this.LifePoints -= points;
            else this.LifePoints = 0;
        }
    }
}
