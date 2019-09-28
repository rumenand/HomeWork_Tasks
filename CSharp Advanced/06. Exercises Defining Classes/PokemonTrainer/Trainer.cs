using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class Trainer
    {
        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public Trainer(string name)
        {
            this.Name = name;
            this.Pokemons = new List<Pokemon>();
        }

        public void ElementFlow(string element)
        {
            if (this.Pokemons.Any(x => x.Element == element)) this.NumberOfBadges++;
            else
            {
                foreach (var pockemon in Pokemons)
                {
                    pockemon.Health -= 10;                    
                }
                this.Pokemons = Pokemons.Where(x => x.Health > 0).ToList();
            }
        }
    }
}
