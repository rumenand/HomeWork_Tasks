using System;
using System.Collections.Generic;
using System.Linq;

namespace SummerCocktails
{
    public class Cocktail
    {
        public string Name { get;}
        public int FreshnessLevel  { get;}
        
        public Cocktail(string name, int fLevel)
        {
            this.Name = name;
            this.FreshnessLevel = fLevel;         
        }

        public override bool Equals(object obj)
        {
            Cocktail other = obj as Cocktail;
            if (other == null) return false;
            else if (this.FreshnessLevel == other.FreshnessLevel) return true;
            return false;
        }

        public override int GetHashCode()
        {
            return this.FreshnessLevel.ToString().GetHashCode();
        }
    }

    class Program
    {
        static void Main()
        {
            var cocktailsTable = PopulateCocktailsTable();  
            var ingredients = new Queue<int>(takeInputIntegers());
            var freshness = new Stack<int>(takeInputIntegers());
            while(ingredients.Count>0 && freshness.Count>0)
            {
                var currentIngredient =0;
                while (currentIngredient ==0 && ingredients.Count>0)
                {
                    currentIngredient = ingredients.Dequeue();
                }
                if (currentIngredient > 0)
                {
                    var result = currentIngredient * freshness.Pop();
                    var searchCocktail = new Cocktail("", result);
                    if (cocktailsTable.ContainsKey(searchCocktail))
                    {
                        cocktailsTable[searchCocktail]++;
                    }
                    else ingredients.Enqueue(currentIngredient + 5);
                }
            }
            var sortedCocktails = cocktailsTable.OrderBy(x => x.Key.Name).Where(x => x.Value > 0);
            if (sortedCocktails.Count() > 3)  Console.WriteLine("It's party time! The cocktails are ready!");
            else
            {
                Console.WriteLine("What a pity! You didn't manage to prepare all cocktails.");
                if (ingredients.Count>0) Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }
            foreach(var item in sortedCocktails)
            {
                Console.WriteLine($" # {item.Key.Name} --> {item.Value}");
            }

        }

        private static Dictionary<Cocktail,int> PopulateCocktailsTable()
        {
            var set = new Dictionary<Cocktail,int>();
            set.Add(new Cocktail("Mimosa", 150),0);
            set.Add(new Cocktail("Daiquiri", 250),0);
            set.Add(new Cocktail("Sunshine", 300),0);
            set.Add(new Cocktail("Mojito", 400),0);
            return set;
        }

        private static IEnumerable<int> takeInputIntegers()
        {
            return Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
        }
    }
}