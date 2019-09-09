using System;
using System.Linq;

namespace _4._Matrix_shuffling
{
    class Program
    {
        static void Main()
        {
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[,] matrix = new string[matrixSize[0], matrixSize[1]];        
            for (int i = 0; i < matrixSize[0]; i++)
            {
                var input = Console.ReadLine().Split().ToArray();
                for (int j = 0; j < matrixSize[1]; j++)
                {
                     matrix[i, j] = input[j];                   
                }
            }
           
            }
    }
}
