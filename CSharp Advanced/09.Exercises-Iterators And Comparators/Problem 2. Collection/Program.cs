using System;
using System.Linq;

namespace IteratorsAndComparators
{
    class Program
    {
        static void Main()
        {
            var listy = CreateListy();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                switch (input)
                {
                    case "Move":
                        Console.WriteLine(listy.Move());
                        break;
                    case "Print":
                        listy.Print();
                        break;
                    case "HasNext":
                        Console.WriteLine(listy.HasNext());
                        break;
                    case "PrintAll":
                        try { Console.WriteLine(string.Join(" ", listy)); }
                        catch { Console.WriteLine("Invalid Operation!"); }
                        break;
                  
                }
            }
        }

        private static ListyIterator<string> CreateListy()
        {
            var input = Console.ReadLine().Split();
            if (input.Length < 2) return new ListyIterator<string>();
            return new ListyIterator<string>(input.Skip(1));
        }
    
    }
}
