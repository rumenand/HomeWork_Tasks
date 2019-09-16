using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_5._Count_Symbols
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var characters = new Dictionary<char, int>();
            foreach (var ch in input)
            {
                if (!characters.ContainsKey(ch)) characters.Add(ch, 1);
                else characters[ch]++;
            }
            foreach (var item in characters.OrderBy(x=>x.Key))
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
        }
    }
}
