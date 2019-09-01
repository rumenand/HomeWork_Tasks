using System;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            for (int i = 0; i < matrixSize; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = row[j];
                }
            }
        }
    }
}
