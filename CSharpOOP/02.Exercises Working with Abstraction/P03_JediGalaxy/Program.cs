using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {        
        static void Main()
        {
            int[] dimestions = GetItegerInput(Console.ReadLine());                          
            int[,] matrix = new int [dimestions[0],dimestions[1]];
            FillMatrix(matrix); 

            Func<int, int, bool> EvilRestrict = (x, y) => x >= 0 && y >= 0;
            Func<int, int, bool> IvoRestrict = (x, y) => x >= 0 && y < matrix.GetLength(1);
            Func<int, int, bool> IsInMatrix = (x, y) => x >= 0 && x<matrix.GetLength(0) && y >= 0 && y<matrix.GetLength(1);

            string command;
            long sum = 0;
            while ((command= Console.ReadLine())!= "Let the Force be with you")
            {
                int[] ivoS = GetItegerInput(command);
                int[] evil = GetItegerInput(Console.ReadLine());
                MoveInMatrix(evil, matrix, EvilRestrict, IsInMatrix, true);
                sum += MoveInMatrix(ivoS, matrix, IvoRestrict, IsInMatrix, false);             
            }
            Console.WriteLine(sum);
        }        

        private static int[] GetItegerInput(string v)
        {
            return v.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }

        private static void FillMatrix(int[,] matrix)
        {
            int value = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = value++;
                }
            }
        }

        private static long MoveInMatrix(int [] coord, int [,] matrix, Func<int,int,bool> Restrict, Func<int,int,bool> Check, bool evil)
        {
            long sum = 0;
            int x = coord[0];
            int y = coord[1];

            while (Restrict(x, y))
            {
                if (Check(x, y))
                {
                    if (evil) matrix[x, y] = 0;
                    else sum += matrix[x, y];
                }
                x--;
                y = (evil) ? y - 1 : y + 1;
            }
            return sum;
        }
    }
}
