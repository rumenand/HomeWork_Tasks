using System;
using System.Collections.Generic;

namespace Problem_6._Wardrobe
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            var clothes = new Dictionary<string, Dictionary<string,int>>();
            for (int i = 0; i < N; i++)
            {
                var currentCommand = Console.ReadLine().Split(" -> ");
                string curColor = currentCommand[0];
                if (!clothes.ContainsKey(curColor))                
                    clothes.Add(curColor, new Dictionary<string, int>());
                var curClothes = currentCommand[1].Split(",");
                for (int j = 0; j < curClothes.Length; j++)
                {
                    string curCloth = curClothes[j];
                    if (!clothes[curColor].ContainsKey(curCloth))
                        clothes[curColor].Add(curCloth, 1);
                    else clothes[curColor][curCloth]++;
                }
            }
            string[] search = Console.ReadLine().Split();
            foreach (var color in clothes)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var cloth in color.Value)
                {
                    Console.Write($"* {cloth.Key} - {cloth.Value}");
                    if (search[0] == color.Key && search[1] == cloth.Key)
                        Console.WriteLine($" (found!)");
                    else Console.WriteLine();
                }

            }
        }
    }
}