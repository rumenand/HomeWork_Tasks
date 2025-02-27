﻿using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main ()
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
                    if (success)
                    {
                        matrix[i, j] = number;
                    }
                    else
                    {
                        converted = false;
                        break;
                    }
                    }
                }
            if (converted)
            {
                int maxSum = 0;
                int maxX = 0;
                int maxY = 0;
                for (int i = 0; i < matrixSize[0] - 2; i++)
                {
                    for (int j = 0; j < matrixSize[1] - 2; j++)
                    {
                        int currentSum = Get3x3Sum(matrix, i, j);
                        if (currentSum > maxSum)
                        {
                            maxSum = currentSum;
                            maxX = i;
                            maxY = j;
                        }
                    }
                }
                Console.WriteLine($"Sum = {maxSum}");
                for (int i = maxX; i < maxX + 3; i++)
                {
                    for (int j = maxY; j < maxY + 3; j++)
                    {
                        Console.Write($"{matrix[i, j]} ");
                    }
                    Console.WriteLine();
                }
            }
        }

        static int Get3x3Sum(int[,] matrix, int x, int y)
        {
            int sum = 0;
           for (int i = x; i<x+3; i++)
            {
                for (int j=y; j<y+3;j++)
                {
                    sum += matrix[i, j];
                }
            }
            return sum;
        }
    }
}