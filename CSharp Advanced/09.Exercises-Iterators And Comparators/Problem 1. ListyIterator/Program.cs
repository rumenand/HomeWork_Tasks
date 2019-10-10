using System;
using System.Linq;

namespace Problem_1._ListyIterator
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
                }
            }
        }

        private static ListyIterator<string> CreateListy()
        {
            var input = Console.ReadLine().Split();
            if (input.Length <2) return new ListyIterator<string>();
            return new ListyIterator<string>(input.Skip(1));
        }
        
    }
}
