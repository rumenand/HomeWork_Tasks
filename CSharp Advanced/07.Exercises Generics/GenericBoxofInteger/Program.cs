using System;

namespace GenericBoxofInteger
{
    class Program
    {
        static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                var input = int.Parse(Console.ReadLine());
                var newBox = new Box<int>(input);
                Console.WriteLine(newBox.ToString());
            }
        }
    }
}
