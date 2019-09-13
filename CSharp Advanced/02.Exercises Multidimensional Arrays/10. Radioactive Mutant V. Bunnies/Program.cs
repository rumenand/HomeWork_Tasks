using System;
using System.Linq;

namespace _10._Radioactive_Mutant_V._Bunnies
{
    class Program
    {
        static void Main()
        {
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] lair = new char[matrixSize[0], matrixSize[1]];
            int[] playerStartCoord = new int[2];
            for (int i = 0; i < matrixSize[0]; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < matrixSize[1]; j++)
                {
                    if (row[j] == 'P')
                    {
                        playerStartCoord[0] = i;
                        playerStartCoord[1] = j;
                    }
                    lair[i, j] = row[j];
                }
            }
            string commands = Console.ReadLine();
            int currentXpos = playerStartCoord[1];
            int currentYpos = playerStartCoord[0];
            bool dead = false;
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'U':
                        currentYpos--;
                        break;
                    case 'D':
                        currentYpos++;
                        break;
                    case 'L':
                        currentXpos--;
                        break;
                    case 'R':
                        currentXpos++;
                        break;
                }
                if (CheckForEscaping(currentXpos, currentYpos, lair)) break;
                BunniesSpread(lair);
                if (CheckForBunniesReachPlayer(lair))
                {
                    dead = true;
                    break;
                }
            }
        }
        static bool CheckForEscaping(int Xpos, int Ypos, char [,] matrix)
        {
            return false;
        }

        static void BunniesSpread(char[,] matrix)
        {

        }

        static bool CheckForBunniesReachPlayer(char[,] matrix)
        {
            return false;
        }
    }
}
