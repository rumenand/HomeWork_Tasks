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
            int maxSum2x2Mat = 0;
            int[] index = new int[2];
            for (int i = 0; i < matrixRows - 1; i++)
            {
                for (int j = 0; j < matrixColumns - 1; j++)
                {
                    int currentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];
                    if (currentSum > maxSum2x2Mat)
                    {
                        maxSum2x2Mat = currentSum;
                        index[0] = i;
                        index[1] = j;
                    }
                }
            }
            Console.WriteLine($"{matrix[index[0],index[1]]} {matrix[index[0], index[1]+1]}");
            Console.WriteLine($"{matrix[index[0]+1, index[1]]} {matrix[index[0]+1, index[1] + 1]}");
            Console.WriteLine(maxSum2x2Mat);
        }
    }
}
