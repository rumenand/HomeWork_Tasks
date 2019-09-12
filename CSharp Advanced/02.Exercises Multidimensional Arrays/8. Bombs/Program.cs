using System;
using System.Linq;

namespace _8._Bombs
{
    class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int[,] board = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                int [] row = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < size; j++)
                {
                    board[i, j] = row[j];
                }
            }
            string[] bombs = Console.ReadLine().Split();
            foreach (var bomb in bombs)
            {
                int[] coord = bomb.Split(",").Select(int.Parse).ToArray();
                BombExplode(board, coord[0], coord[1]);
            }
            PrintAliveMatrix(board);
            PrintMatrix(board);
        }

        static void BombExplode(int [,] matrix, int xPos, int yPos)
        {           
          int bombPower = matrix[xPos, yPos];
            if (bombPower > 0)
            {
                for (int i = Math.Max(0, xPos - 1); i <= Math.Min(matrix.GetLength(0), xPos + 1); i++)
                {
                    for (int j = Math.Max(0, yPos - 1); j <= Math.Min(matrix.GetLength(0), yPos + 1); j++)
                    {
                        matrix[i, j] -= bombPower;
                    }
                }
            }            
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        static void PrintAliveMatrix(int[,] matrix)
        {
            int counter = 0;
            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] >0)
                    {
                        counter++;
                        sum += matrix[row, col];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {counter}");
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
