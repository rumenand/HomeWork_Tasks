using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            double[][] jagged = new double[N][];
            for (int i=0;i<N;i++)
            {
                var col = Console.ReadLine().Split().Select(double.Parse).ToArray();
                jagged[i] = col;
            }
            Func<double, bool, double> Calculate = (num, div) => (div ? num / 2 : num * 2);
            for (int i=0;i<N-1;i++)
            {
                bool divison = (jagged[i].Length != jagged[i + 1].Length);                                  
                    for (int j=0; j<jagged[i].Length; j++)
                    {
                        jagged[i][j]  = Calculate(jagged[i][j],divison);
                    }
                    for (int j = 0; j < jagged[i+1].Length; j++)
                    {
                        jagged[i + 1][j] = Calculate(jagged[i+1][j], divison);
                    }                              
            }
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var commands = input.Split();
                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);
                if (row > -1 && row < N && col > -1 && col < jagged[row].Length)
                {
                    switch (commands[0])
                    {
                        case "Add":
                            jagged[row][col] += value;
                            break;
                        case "Subtract":
                            jagged[row][col] -= value;
                            break;
                    }
                }
            }
            foreach (var row in jagged)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
