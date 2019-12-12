using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Common;

namespace PlayersAndMonsters.Models.Cards
{
    public abstract class Card : ICard
    {
        private int damagePoints;
        private int healthPoints;
        private string name;
        protected Card(string name, int damagePoints, int healthPoints)
        {           
            this.Name = name;
            this.DamagePoints = damagePoints;           
            this.HealthPoints = healthPoints;
        }
        public string Name { get => this.name;
            private set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value, "Card's name cannot be null or an empty string.");
                this.name = value;
            }
        }

        public int DamagePoints 
        { get => this.damagePoints;
            set
            {
                Validator.ThrowIfNumberIsOrNegative(value, "Card's damage points cannot than zero.");
                this.damagePoints = value;
            }
        }

        public int HealthPoints
        {
            get => this.healthPoints;
            private set
            {
                Validator.ThrowIfNumberIsOrNegative(value, "Card's HP cannot be less than zero.");
                this.healthPoints = value;
            }
        }
    }
}
