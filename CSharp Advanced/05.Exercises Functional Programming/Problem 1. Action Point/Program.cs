using System;
using System.Linq;

namespace Problem_1._Action_Point
{
    class Program
    {
        static void Main()
        {
            Action<string> print = message =>Console.WriteLine(message);
            var words = Console.ReadLine().Split();
            foreach (var word in words)
                print(word);
        }

        
    }
}
