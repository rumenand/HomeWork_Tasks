using System;
using System.Collections.Generic;

namespace _5._Filter_by_Age
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            var people = new Dictionary<string, int>();
            for (int i=0; i<N; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                people.Add(input[0], int.Parse(input[1]));
            }
            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();
            Func<int, bool> tester = CreateTester(condition, age);
            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);

            PrintFilteredStudent(people, tester, printer);
        }

        public static Func<int, bool> CreateTester
                    (string condition, int age)
        {
            switch (condition)
            {
                case "younger": return x => x < age;
                case "older": return x => x >= age;
                default: return null;
            }
        }

        public static Action<KeyValuePair<string, int>>
                        CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return pe=> Console.WriteLine($"{pe.Key}");                    
                case "name age":
                    return person => Console.WriteLine($"{person.Key} - {person.Value}");
                case "age":
                    return person => Console.WriteLine($"{person.Value}");
                default: return null;
            }
        }

        public static void PrintFilteredStudent(Dictionary<string,int> people, Func<int, bool> tester, Action<KeyValuePair<string, int>> printer)
        {
            foreach (var person in people)
            {
                if (tester(person.Value)) printer(person);
            }
        }
    }
}
