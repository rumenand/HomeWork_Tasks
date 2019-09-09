using System;
using System.Linq;

namespace _4._Matrix_shuffling
{
    class Program
    {
        static void Main()
        {
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[,] matrix = new int[matrixSize[0], matrixSize[1]];
            bool converted = true;
            for (int i = 0; i < matrixSize[0]; i++)
            {
                var input = Console.ReadLine().Split().ToArray();
                for (int j = 0; j < matrixSize[1]; j++)
                {
                    int number;
                    bool success = int.TryParse(input[j], out number);
                    if (success) matrix[i, j] = number;
                    else
                    {
                        converted = false;
                        break;
                    }
                }
            }
            if (converted)
            {

            }
            }
    }
}
