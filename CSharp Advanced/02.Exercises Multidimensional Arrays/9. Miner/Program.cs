using System;
using System.Collections.Generic;

namespace _9._Miner
{
    class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            char[,] field = new char[size, size];
            string[] commands = Console.ReadLine().Split();
            int coalsField = 0;
            int[] startIndex = new int[2];
            List<int[]> endIndexes = new List<int[]>();
            for (int i = 0; i < size; i++)
            {
                string [] row = Console.ReadLine().Split();
                for (int j = 0; j < size; j++)
                {
                    char currentField = char.Parse(row[j]);
                    if (currentField == 'c') coalsField++;
                    if(currentField == 's')
                    {
                        startIndex[0] = i;
                        startIndex[1] = j;
                    }
                    if(currentField == 'e')
                    {
                        endIndexes.Add(new int[2] { i, j });
                    }
                    field[i, j] = currentField;
                }
            }
            int coalsCollected = 0;
            bool gameStoped = false;
            int currentXpos = startIndex[0];
            int currentYpos = startIndex[1];
            foreach (string command in commands)
            {
                bool move = false;
                switch (command)
                {
                    case "left":
                        if (currentYpos > 0)
                        {
                            currentYpos--;
                            move = true;
                        }
                        break;
                    case "right":
                        if (currentYpos < field.GetLength(1)-1)
                        {
                            currentYpos++;
                            move = true;
                        }
                        break;
                    case "up":
                        if (currentXpos > 0)
                        {
                            currentXpos --;
                            move = true;
                        }
                        break;
                    case "down":
                        if (currentXpos < field.GetLength(0)-1)
                        {
                            currentXpos++;
                            move = true;
                        }
                        break;
                }
                if (move)
                {
                    if (field[currentXpos,currentYpos] == 'c')
                    {
                        field[currentXpos, currentYpos] = '*';
                        coalsCollected++;
                        if (coalsCollected >= coalsField)
                        {
                            Console.WriteLine($"You collected all coals! ({currentXpos}, {currentYpos})");
                            gameStoped = true;
                            break;
                        }
                    }
                    if (field[currentXpos, currentYpos] == 'e')
                    {
                        Console.WriteLine($"Game over! ({currentXpos}, {currentYpos})");
                        gameStoped = true;
                        break;
                    }
                }
            }
            if (!gameStoped) Console.WriteLine($"{coalsField - coalsCollected} coals left. ({currentXpos}, {currentYpos})");
        }
    }
}
