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
            string command;
           while ((command = Console.ReadLine()) != "END")
            {
                string [] commands = command.Split();
                if (checkForValid(commands) && checkInMatrix(commands,matrixSize))
                {
                    swapMatrix(commands, matrix);
                    printMatrix(matrix);
                }
                else Console.WriteLine("Invalid input!");
            }
        }

        static bool checkForValid(string [] input)
        {
            bool result = true;
            if (input[0] == "swap" && input.Length == 5)
            {
                for (int i=1; i<5;i++)
                {
                    int number;
                    result = int.TryParse(input[i], out number);
                }
            }
            else result = false;
            return result;
        }

        static bool checkInMatrix(string[] input, int [] matrix)
        {
            if (int.Parse(input[1]) < matrix[0] && int.Parse(input[3]) < matrix[0]
                && int.Parse(input[2]) < matrix[1] && int.Parse(input[4]) < matrix[1])
                return true;
            return false;
        }

        static void swapMatrix(string [] commands, string[,] matrix)
        {
            int row1 = int.Parse(commands[1]);
            int row2 = int.Parse(commands[3]);
            int col1 = int.Parse(commands[2]);
            int col2 = int.Parse(commands[4]);
            var temp = matrix[row1, col1];
            matrix[row1, col1] = matrix[row2, col2];
            matrix[row2, col2] = temp;
        }

        static void printMatrix(string [,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0} ", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
