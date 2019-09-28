using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class Program
    {
        static void Main()
        {
            var trainers = new Dictionary<string, Trainer>();
            string input;
            while((input = Console.ReadLine()) != "Tournament")
            {
                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (!trainers.ContainsKey(tokens[0])) trainers.Add(tokens[0],new Trainer(tokens[0]));
                trainers[tokens[0]].Pokemons.Add(new Pokemon(tokens));
            }
            while((input = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    trainer.Value.ElementFlow(input);
                }
            }
            foreach (var sorted in trainers.OrderByDescending(x=>x.Value.NumberOfBadges))
            {
                Console.WriteLine($"{sorted.Key} {sorted.Value.NumberOfBadges} {sorted.Value.Pokemons.Count}");
            }
        }
    }
}
