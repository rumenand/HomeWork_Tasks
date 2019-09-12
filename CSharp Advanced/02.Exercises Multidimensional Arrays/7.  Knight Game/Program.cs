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
            int counterRemoved = 0;
            bool removed = true;
            while (removed)
            {
                removed = false;
                int maxHits = 0;
                int maxX = -1;
                int maxY = -1;
                for (int i=0; i<size;i++)
                {
                    for (int j=0; j<size; j++)
                    {
                        if (board[i, j] == 'K')
                        {
                            int hits = CheckForHits(board, i, j);
                            if (hits < maxHits)
                            {
                                maxHits = hits;
                                maxX = i;
                                maxY = j;
                            }
                        }
                    }
                }
                if (maxHits > 0)
                {
                    board[maxX, maxY] = '0';
                    removed = true;
                    counterRemoved++;
                }                
            }
            Console.WriteLine(counterRemoved);
        }

        static int CheckForHits(char[,] board, int Xpos, int Ypos)
        {
            int hits = CheckCoord(board, Xpos-2, Ypos-1);
            hits += CheckCoord(board, Xpos - 2, Ypos + 1);
            hits += CheckCoord(board, Xpos + 2, Ypos - 1);
            hits += CheckCoord(board, Xpos + 2, Ypos + 1);
            hits += CheckCoord(board, Xpos - 1, Ypos + 2);
            hits += CheckCoord(board, Xpos + 1, Ypos + 2);
            hits += CheckCoord(board, Xpos - 1, Ypos - 2);
            hits += CheckCoord(board, Xpos + 1, Ypos - 2);
            return hits;
        }        

        static int CheckCoord(char[,] board, int Xpos, int Ypos)
        {
            if (Xpos > 0 && Xpos < board.GetLength(0) && Ypos > 0 && Ypos < board.GetLength(1) && board[Xpos, Ypos] == 'K') return 1;
            else return 0;
        }
    }
}