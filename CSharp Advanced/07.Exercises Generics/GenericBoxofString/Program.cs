using System;

namespace GenericBoxofString
{
    class Program
    {
        static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine();
                var newBox = new Box<string>(input);
                Console.WriteLine(newBox.ToString());
            }
        }
    }
}
