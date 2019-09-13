using System;
using System.Linq;

namespace _10._Radioactive_Mutant_V._Bunnies
{
    class Program
    {
        static void Main()
        {
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] matrix = new char[matrixSize[0], matrixSize[1]];
            for (int i = 0; i < matrixSize[0]; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < matrixSize[1]; j++)
                {
                    matrix[i, j] = row[j];
                }
            }
            string command = Console.ReadLine();
        }
    }
}
