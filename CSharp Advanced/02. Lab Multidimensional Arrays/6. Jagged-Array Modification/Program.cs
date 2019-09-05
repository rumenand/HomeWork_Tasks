using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rows][];
            for (int r = 0; r < rows; r++)
            {
                int[] col = Console.ReadLine().Split().Select(int.Parse).ToArray();
                matrix[r] = col;
            }
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split();
                string command = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);
                if (row < 0 || row >= matrix.Length || col <0 || col>=matrix[row].Length) Console.WriteLine("Invalid coordinates");
                else
                {
                    switch (command)
                    {
                        case "Add":
                            matrix[row][col] += value;
                            break;
                        case "Subtract":
                            matrix[row][col] -= value;
                            break;
                    }
                }
            }
             for (int i=0;i<rows;i++)
            {
                Console.WriteLine(string.Join(" ",matrix[i]));
            }
                
        }
    }
}
