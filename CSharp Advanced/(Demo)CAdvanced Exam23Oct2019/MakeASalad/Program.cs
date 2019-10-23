using System;
using System.Collections.Generic;
using System.Linq;

namespace MakeASalad
{
    class Program
    {
        static void Main()
        {
            var vegetablesData = PopulateData();
            var vegetables = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            var calories = new Stack<int>(Console.ReadLine()
                            .Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var prepared = new List<int>();
            while (vegetables.Count>0 && calories.Count>0)
            {
                var currentSaladCalories = calories.Pop();
                prepared.Add(currentSaladCalories);
                while (vegetables.Count>0)
                {
                    var currentVeg = vegetables.Dequeue();                    
                    if (vegetablesData.ContainsKey(currentVeg)) currentSaladCalories -= vegetablesData[currentVeg];
                    if (currentSaladCalories <= 0) break;
                }
            }
            Console.WriteLine(string.Join(" ",prepared));
            if (vegetables.Count == 0) Console.WriteLine(string.Join(" ",calories));
            else if(calories.Count == 0) Console.WriteLine(string.Join(" ", vegetables));
        }

        private static Dictionary<string,int> PopulateData()
        {
            var list = new Dictionary<string, int>();
            list.Add("tomato", 80);
            list.Add("carrot", 136);
            list.Add("lettuce", 109);
            list.Add("potato", 215);
            return list;
        }
    }
}