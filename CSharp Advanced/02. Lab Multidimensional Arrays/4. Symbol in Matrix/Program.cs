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
            char forSearch = (char)Console.Read();
            bool found = false;
            for (int x = 0; x < matrix.GetLength(0); x += 1)
            {
                for (int y = 0; y < matrix.GetLength(1); y += 1)
                {
                    if ( forSearch == matrix[x, y])
                    {
                        found = true;
                        Console.WriteLine($"({x}, {y})");
                        break;
                    }                   
                }
                if (found) break;
            }
            if (!found) Console.WriteLine($"{forSearch} does not occur in the matrix");
        }
    }
}
