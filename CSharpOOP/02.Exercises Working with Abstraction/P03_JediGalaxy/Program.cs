using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {        
        static void Main()
        {
            Func<string, int[]> GetIntegerInput = x => x.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            
            int[] dimestions = GetIntegerInput(Console.ReadLine());                          
            int[,] matrix = new int [dimestions[0],dimestions[1]];
            FillMatrix(matrix);

            Func<int, int, bool> EvilRestrict = (x, y) => x >= 0 && y >= 0;
            Func<int, int, bool> IvoRestrict = (x, y) => x >= 0 && y < matrix.GetLength(1);

            string command;
            long sum = 0;
            while ((command= Console.ReadLine())!= "Let the Force be with you")
            {
                int[] ivoS = GetIntegerInput(command);
                int[] evil = GetIntegerInput(Console.ReadLine());
                MoveInMatrix(evil, matrix, EvilRestrict, true); //Evil's Move
                sum += MoveInMatrix(ivoS, matrix, IvoRestrict, false);  //Ivo's Move            
            }
            Console.WriteLine(sum);
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

        private static long MoveInMatrix(int [] coord, int [,] matrix, Func<int,int,bool> Restrict, bool evil)
        {
            Func<int, int, bool> IsInMatrix = (xPos, yPos) => xPos >= 0 && xPos < matrix.GetLength(0) && yPos >= 0 && yPos < matrix.GetLength(1);
            long sum = 0;
            int x = coord[0];
            int y = coord[1];           
            while (Restrict(x, y))
            {
                if (IsInMatrix(x, y))
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
