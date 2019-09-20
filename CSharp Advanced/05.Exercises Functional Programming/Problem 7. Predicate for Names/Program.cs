using System;
using System.Linq;

namespace Problem_7._Predicate_for_Names
{
    class Program
    {
        static void Main()
        {
            int length = int.Parse(Console.ReadLine());
            string names = Console.ReadLine();
            Func<string, bool> checker = n => n.Length <= length;
            var sortedNames = names.Split().Where(checker);
            Console.WriteLine(string.Join(Environment.NewLine, sortedNames));
        }
    }
}
