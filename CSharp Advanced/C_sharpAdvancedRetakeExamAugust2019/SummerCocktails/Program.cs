using System;
using System.Collections.Generic;
using System.Linq;

namespace SummerCocktails
{
    public class Cocktail
    {
        public string Name { get;}
        public int FreshnessLevel  { get;}
        public int Count { get;set; }
        
        public Cocktail(string name, int fLevel)
        {
            this.Name = name;
            this.FreshnessLevel = fLevel;
            this.Count = 0;
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
                    bool found = false;
                    foreach (var item in cocktailsTable)
                    {
                        if (item.FreshnessLevel == result)
                        {
                            item.Count++;
                            found = true;
                            break;
                        }
                    }
                    if (!found) ingredients.Enqueue(currentIngredient + 5);
                }
            }
            var sortedCocktails = cocktailsTable.OrderBy(x => x.Name).Where(x => x.Count > 0);
            if (sortedCocktails.Count() > 3)  Console.WriteLine("It's party time! The cocktails are ready!");
            else
            {
                Console.WriteLine("What a pity! You didn't manage to prepare all cocktails.");
                if (ingredients.Count>0) Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }
            foreach(var item in sortedCocktails)
            {
                Console.WriteLine($" # {item.Name} --> {item.Count}");
            }

        }

        private static HashSet<Cocktail> PopulateCocktailsTable()
        {
            var set = new HashSet<Cocktail>();
            set.Add(new Cocktail("Mimosa", 150));
            set.Add(new Cocktail("Daiquiri", 250));
            set.Add(new Cocktail("Sunshine", 300));
            set.Add(new Cocktail("Mojito", 400));
            return set;
        }

        private static IEnumerable<int> takeInputIntegers()
        {
            return Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
        }
    }
}