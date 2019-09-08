using System;
using System.Linq;

namespace _2._2x2_Squares_in_Matrix
{
    class Program
    {
        static void Main()
        {
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] matrix = new char [matrixSize[0], matrixSize[1]];
            for (int i=0; i<matrixSize[0];i++)
            {
                char [] input = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int j=0;j<matrixSize[1];j++)
                {
                    matrix[i, j] = input[j];
                }
            }
        }
    }
}
