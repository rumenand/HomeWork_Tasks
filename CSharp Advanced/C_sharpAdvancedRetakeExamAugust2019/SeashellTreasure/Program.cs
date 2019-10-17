using System;
using System.Linq;
using System.Collections.Generic;

namespace SeashellTreasure
{
    class Program
    {
        static void Main()
        {
            const int thieftSteps = 3;
            var collectedShells = new List<string>();
            var stolenShells = 0;
            int rows = int.Parse(Console.ReadLine());
            var beachMap = new string[rows][];
            populateMap(beachMap);
            string input;
            while((input = Console.ReadLine())!= "Sunset")
            {
                var commands = input.Split();
                if (commands.Length > 2)
                {
                    int xPos = GetCoord(commands[1]);
                    int yPos = GetCoord(commands[2]);
                    if (commands[0] == "Collect")
                    {
                        if (checkInMap(beachMap, xPos, yPos) && beachMap[xPos][yPos] != "-")
                        {
                            collectedShells.Add(beachMap[xPos][yPos]);
                            beachMap[xPos][yPos] = "-";
                        }
                    }
                    if (commands[0] == "Steal")
                    {
                        for (int i = 0; i < thieftSteps + 1; i++)
                        {
                            if (checkInMap(beachMap, xPos, yPos))
                            {
                                if (beachMap[xPos][yPos] != "-")
                                {
                                    beachMap[xPos][yPos] = "-";
                                    stolenShells++;
                                }
                                switch (commands[3])
                                {
                                    case "up": xPos--; break;
                                    case "down": xPos++; break;
                                    case "left": yPos--; break;
                                    case "right": yPos++; break;
                                }
                            }
                            else break;
                        }
                    }
                }
            }

            for (int i = 0; i < beachMap.GetLength(0); i++)
            {
                for (int j = 0; j < beachMap[i].GetLength(0); j++)
                {
                    Console.Write($"{beachMap[i][j]} ");
                }
                Console.WriteLine();
            }
            Console.Write($"Collected seashells: {collectedShells.Count} ");
            if (collectedShells.Count > 0) Console.WriteLine($"-> {string.Join(", ",collectedShells)}");
            else Console.WriteLine();
            Console.WriteLine($"Stolen seashells: {stolenShells}");
        }

        private static int GetCoord(string v)
        {
            int number;
            bool success = Int32.TryParse(v, out number);
            if (success)  return number;
            return -1;
        }

        private static bool checkInMap(string[][] beachMap, int xPos, int yPos)
        {
            if (xPos > -1 && xPos < beachMap.GetLength(0) && yPos > -1 && yPos < beachMap[xPos].GetLength(0)) return true;
            else return false;
        }

        private static void populateMap(string[][] beachMap)
        {
            for (int i = 0; i < beachMap.GetLength(0); i++)
            {
                var row = Console.ReadLine().Split();
                beachMap[i] = row;
            }
        }
    }
}