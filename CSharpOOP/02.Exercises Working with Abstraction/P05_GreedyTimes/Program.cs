using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Program
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            string[] safe = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Bag(bagCapacity);    

            for (int i = 0; i < safe.Length; i += 2)
            {
                string name = safe[i];
                long amount = long.Parse(safe[i + 1]);

                string item = string.Empty;

                if (name.Length == 3)
                {
                    item = "Cash";
                }
                else if (name.ToLower().EndsWith("gem"))
                {
                    item = "Gem";
                }
                else if (name.ToLower() == "gold")
                {
                    item = "Gold";
                }
                bag.TryInsertInBag(name, item, amount);                
            }

            foreach (var item in bag.Items)
            {
                Console.WriteLine($"<{item.Key}> ${bag.GetItemSum(item.Key)}");
                foreach (var piece in item.Value.OrderByDescending(y => y.Name).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{piece.Name} - {piece.Value}");
                }
            }
        }
    }
}