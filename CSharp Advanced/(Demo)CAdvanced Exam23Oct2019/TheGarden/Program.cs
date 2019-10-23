using System;
using System.Collections.Generic;
using System.Linq;

namespace TheGarden
{
    class Program
    {
        static void Main()
        {
            var harvested = PopulateVegetables();
            var harmed = 0;
            var rows = int.Parse(Console.ReadLine());
            var garden = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                var row = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .Select(char.Parse).ToArray();
                garden[i] = row;
            }
            Func<int, int, bool> IsInMargins = (x, y) => x > -1 && x < rows && y > -1 && y < garden[x].Count();
            string input;
            while((input = Console.ReadLine()) != "End of Harvest")
            {
                var commands = input.Split();
                var row = int.Parse(commands[1]);
                var col = int.Parse(commands[2]);
                switch (commands[0])
                {
                    case "Harvest":
                        if (IsInMargins(row, col))
                        {
                            if (harvested.ContainsKey(garden[row][col]))
                            {
                                harvested[garden[row][col]]++;
                                garden[row][col] = ' ';
                            }
                        }
                        break;
                    case "Mole":
                        var direction = commands[3];
                        var move = 0;
                        while(IsInMargins(row,col))
                        {
                            if (move % 2 == 0 && harvested.ContainsKey(garden[row][col]))
                            {
                                garden[row][col] = ' ';
                                harmed++;
                            }
                            if (direction == "up") row--;
                            if (direction == "down") row++;
                            if (direction == "left") col--;
                            if (direction == "right") col++;
                            move++;
                        }
                        break;
                }
            }
            for (int i = 0; i < garden.GetLength(0); i++)
            {
                Console.WriteLine(string.Join(" ",garden[i]));
            }
            Console.WriteLine($"Carrots: {harvested['C']}");
            Console.WriteLine($"Potatoes: {harvested['P']}");
            Console.WriteLine($"Lettuce: {harvested['L']}");
            Console.WriteLine($"Harmed vegetables: {harmed}");
        }

        private static Dictionary<char, int> PopulateVegetables()
        {
            var list = new Dictionary<char, int>();
            list.Add('L', 0);
            list.Add('P', 0);
            list.Add('C', 0);
            return list;
        }
    }
}