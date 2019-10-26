using System;
using System.Linq;

namespace BookWorm
{
    class Program
    {
        static void Main()
        {
            var initialString = Console.ReadLine();
            var row = int.Parse(Console.ReadLine());
            var matrix = new char[row][];
            for (int i = 0; i < row; i++)
            {
                string currentRow = Console.ReadLine();
                matrix[i] = new char[currentRow.Length];
                for (int j=0; j<currentRow.Length; j++)
                {
                    matrix[i][j] = currentRow[j];
                }
            }
            var playerPos = GetIntialPos(matrix);
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                var punished = false;
                switch (input)
                {
                    case "up":
                        if (playerPos[0] - 1 > -1) playerPos[0] -= 1;
                        else punished = true;
                        break;
                    case "down":
                        if (playerPos[0] + 1 < row) playerPos[0] += 1;
                        else punished = true;
                        break;
                    case "left":
                        if (playerPos[1] - 1 > -1) playerPos[1] -= 1;
                        else punished = true;
                        break;
                    case "right":
                        if (playerPos[1] + 1 < row) playerPos[1] += 1;
                        else punished = true;
                        break;
                }
                if (punished) initialString = initialString.Substring(0, initialString.Length - 1);
                else if (matrix[playerPos[0]][playerPos[1]] != '-')
                {
                    initialString += matrix[playerPos[0]][playerPos[1]];
                    matrix[playerPos[0]][playerPos[1]] = '-';
                }
            }
            Console.WriteLine(initialString);
            PrintMatrix(matrix, playerPos);
        }

        private static void PrintMatrix(char[][] matrix,  int [] playerPos)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix[i].GetLength(0); j++)
                {

                    if (i == playerPos[0] && j == playerPos[1]) Console.Write("P");
                    else Console.Write(matrix[i][j]);
                }
                Console.WriteLine();
            }
        }

        private static int[] GetIntialPos(char[][] matrix)
        {
            var result = new int[2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix[i].GetLength(0); j++)
                {
                    if (matrix[i][j] == 'P')
                    {
                        result[0] = i;
                        result[1] = j;
                        matrix[i][j] = '-';
                    }
                }
            }
            return result;
        }
    }
}
