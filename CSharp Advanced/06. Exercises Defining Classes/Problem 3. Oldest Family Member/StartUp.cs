using System;
using System.Reflection;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }
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
