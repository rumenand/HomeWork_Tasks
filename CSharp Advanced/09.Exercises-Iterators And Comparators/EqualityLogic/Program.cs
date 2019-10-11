using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    class Program
    {
        static void Main()
        {
            var hashSetPeople = new HashSet<Person>();
            var sortedSetPeople = new SortedSet<Person>();
            var count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split();
                var newPerson = new Person(input[0], int.Parse(input[1]));
                hashSetPeople.Add(newPerson);
                sortedSetPeople.Add(newPerson);
            }
            Console.WriteLine(hashSetPeople.Count);
            Console.WriteLine(sortedSetPeople.Count);
        }
    }
}
