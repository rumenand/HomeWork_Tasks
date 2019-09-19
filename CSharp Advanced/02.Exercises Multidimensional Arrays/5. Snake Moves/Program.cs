using System;
using System.Linq;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main()
        {
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] matrix = new char[matrixSize[0], matrixSize[1]];
            string snake = Console.ReadLine();
            int index = 0;
            int maxIndex = snake.Length;
           for (int i=0; i<matrixSize[0]; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < matrixSize[1]; j++)
                    {
                        matrix[i, j] = snake[index];
                        index++;
                        if (index == maxIndex) index = 0;
                    }
                }
                else
                {
                    for (int j = matrixSize[1]-1; j >= 0; j--)
                    {
                        matrix[i, j] = snake[index];
                        index++;
                        if (index == maxIndex) index = 0;
                    }
                }
            }

            for (int i = 0; i < matrixSize[0]; i++)
            {
                for (int j = 0; j < matrixSize[1]; j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
