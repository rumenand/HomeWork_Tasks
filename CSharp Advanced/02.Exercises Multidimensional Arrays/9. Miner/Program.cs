using System;

namespace _9._Miner
{
    class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            char[,] field = new char[size, size];
            string[] commands = Console.ReadLine().Split();
            for (int i = 0; i < size; i++)
            {
                string [] row = Console.ReadLine().Split();
                for (int j = 0; j < size; j++)
                {
                    field[i, j] = char.Parse(row[j]);
                }
            }
        }
    }
}
