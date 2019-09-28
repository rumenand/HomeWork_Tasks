using System;
using System.Collections.Generic;
using System.Linq;

namespace OpinionPoll
{
    class StartUp
    {
        static void Main()
        {
            List<Person> pepole = new List<Person>();
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                var person = Console.ReadLine().Split();
                pepole.Add(new Person(person[0], int.Parse(person[1])));
            }
            var sortedPeople = pepole.Where(x => x.Age > 30).OrderBy(x => x.Name);
            foreach (var person in sortedPeople)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
