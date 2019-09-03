using System;

namespace _5._Square_with_Maximum_Sum
{
    class Program
    {
        static void Main()
        {
            string [] input = Console.ReadLine().Split(",",StringSplitOptions.RemoveEmptyEntries);
            int matrixRows = int.Parse(input[0]);
            int matrixColumns = int.Parse(input[1]);
            int[,] matrix = new int[matrixRows, matrixColumns];
            for (int i=0;i<matrixRows;i++)
            {
                string[] row = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);
                for (int j=0;j<matrixColumns;j++)
                {
                    matrix[i, j] = int.Parse(row[j]);
                }
            }
        }
    }
}
