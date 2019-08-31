using System;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];
            for (int i=0; i<matrixSize;i++)
            {
                string[] row = Console.ReadLine().Split();
                for (int j=0;j<matrixSize;j++)
                {
                    matrix[i, j] = int.Parse(row[j]);
                }
            }
            int diagonalSum = 0;
            for (int i=0;i<matrixSize;i++)
            {
                diagonalSum += matrix[i, i];
            }
            Console.WriteLine(diagonalSum);
        }
    }
}
