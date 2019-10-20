using System;
using System.Collections.Generic;

namespace Tron_Racers
{
    class Program
    {
        static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            var matrix = new char[size, size];
            var players = new Dictionary<char, PlayerCoord>();
            PopulateIntialStateMatrix(matrix,players);
            bool collision = false;
            while (!collision)
            {
                var commands = Console.ReadLine().Split();
                var sequence = 0;                
                foreach (var player in players)
                {
                    MakeMove(player.Value, matrix, commands[sequence]);
                    if (CheckForCollisionWithTrail(player.Value, matrix, player.Key))
                    {
                        matrix[player.Value.Xpos, player.Value.Ypos] = 'x';
                        collision = true;
                        break;
                    }
                    else matrix[player.Value.Xpos, player.Value.Ypos] = player.Key;
                    sequence++;
                }
            }
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }

        private static bool CheckForCollisionWithTrail(PlayerCoord currentPos, char[,] matrix, char playerTrail)
        {
            return matrix[currentPos.Xpos, currentPos.Ypos] != '*' && matrix[currentPos.Xpos,currentPos.Ypos] != playerTrail;
        }

        private static void MakeMove(PlayerCoord currentPos, char[,] matrix, string command)
        {
            switch(command)
            {
                case "up":
                    if (currentPos.Xpos == 0) currentPos.Xpos = matrix.GetLength(0);
                    currentPos.Xpos--;
                    break;
                case "down":
                    currentPos.Xpos++;
                    if (currentPos.Xpos == matrix.GetLength(0)) currentPos.Xpos = 0;                    
                    break;
                case "left":
                    if (currentPos.Ypos == 0) currentPos.Ypos = matrix.GetLength(1);
                    currentPos.Ypos--;
                    break;
                case "right":
                    currentPos.Ypos++;
                    if (currentPos.Ypos == matrix.GetLength(1)) currentPos.Ypos = 0;
                    break;
            }
        }        

        private static void PopulateIntialStateMatrix(char[,] matrix, Dictionary<char, PlayerCoord> players)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var row = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                    if (row[j] != '*' && !players.ContainsKey(row[j])) players.Add(row[j], new PlayerCoord(i, j));
                }
            }
        }
    }

    internal class PlayerCoord
    {
        public int Xpos { get; set; }
        public int Ypos { get; set; }

        public PlayerCoord(int xPos, int yPos)
        {
            this.Xpos = xPos;
            this.Ypos = yPos;
        }
    }
}