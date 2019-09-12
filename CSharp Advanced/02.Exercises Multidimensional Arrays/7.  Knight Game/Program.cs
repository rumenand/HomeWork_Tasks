using System;

namespace _7.__Knight_Game
{
    class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            char[,] board = new char[size, size];
            for (int i=0; i<size; i++)
            {
                string row = Console.ReadLine();
                for (int j=0; j<size; j++)
                {
                    board[i, j] = row[j];
                }
            }
        }
    }
}
