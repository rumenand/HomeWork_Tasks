using System;
using System.Linq;

namespace _2._2x2_Squares_in_Matrix
{
    class Program
    {
        static void Main()
        {
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[,] matrix = new string [matrixSize[0], matrixSize[1]];
            for (int i=0; i<matrixSize[0];i++)
            {
              string [] input = Console.ReadLine().Split();
                for (int j=0;j<matrixSize[1];j++)
                {
                   matrix[i, j] = input[j];
                }
            }
            int equalSquare = 0;
            for (int i=0;i<matrixSize[0]-1;i++)
            {
                for (int j=0;j<matrixSize[1]-1;j++)
                {
                    if (matrix[i, j] == matrix[i + 1, j]
                        && matrix[i, j] == matrix[i, j + 1]
                        && matrix[i, j] == matrix[i + 1, j + 1])
                        equalSquare++;
                }
            }
            Console.WriteLine(equalSquare);
        }
    }
}
