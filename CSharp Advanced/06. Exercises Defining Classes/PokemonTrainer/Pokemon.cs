using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    class Pokemon
    {
        public string Name { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }

        public Pokemon(string [] args)
        {
            this.Name = args[1];
            this.Element = args[2];
            this.Health = int.Parse(args[3]);
        }
    }
}
