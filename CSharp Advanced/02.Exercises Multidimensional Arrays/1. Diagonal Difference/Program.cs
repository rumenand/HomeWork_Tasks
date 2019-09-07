using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int [][] matrix = new int [matrixSize][];
            for (int i=0;i<matrixSize;i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse);
                matrix[i] = new int[input.Count()];
                matrix[i] = input.ToArray();                
            }
            int primaryDiag = 0;
            int secondaryDiag = 0;
            for (int i=0; i<matrixSize; i++)
            {
                primaryDiag += matrix[i][i];
                secondaryDiag += matrix[i][matrixSize-1-i];
            }
            
        }
    }
}
