using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i=0; i<N;i++)
            {
                var person = Console.ReadLine().Split();
                family.AddMember(new Person(person[0], int.Parse(person[1])));
            }
            var oldestPerson = family.GetOldestMember();
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}
