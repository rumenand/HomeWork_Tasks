using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using PlayersAndMonsters.Common;
using System;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private int health;
        private string name;
      
        protected Player(ICardRepository cardRepository, string username, int health)
        {            
            this.Username = username;
            this.Health = health;
            this.CardRepository = cardRepository;
        }
        public ICardRepository CardRepository { get; }

        public string Username { get => this.name;
            private set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value, "Player's username cannot be null or an empty string.");
                this.name = value;
            }
        }

        public int Health { 
            get =>this.health; 
            set
            {
                Validator.ThrowIfNumberIsOrNegative(value, "Player's health bonus cannot be less than zero.");
                this.health = value;
            }
        }

        public bool IsDead => this.Health<=0;

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0) throw new ArgumentException("Damage points cannot be less than zero.");
            if (this.Health >= damagePoints) this.Health -= damagePoints;
            else this.Health = 0;
        }
    }
}
