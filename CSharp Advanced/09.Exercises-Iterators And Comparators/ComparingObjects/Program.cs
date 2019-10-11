using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    class Program
    {
        static void Main()
        {
            var listPeople = new List<Person>();
            string input;
            while((input = Console.ReadLine()) != "END")
            {
                var commands = input.Split();
                listPeople.Add(new Person(commands[0], int.Parse(commands[1]), commands[2]));
            }
            var comparePersonNum = int.Parse(Console.ReadLine())-1;
            var matches = 0;
            foreach (var person in listPeople)
            {
                if (listPeople[comparePersonNum].CompareTo(person) == 0) matches++;
            }
            if (matches < 2) Console.WriteLine("No matches");
            else Console.WriteLine($"{matches} {listPeople.Count-matches} {listPeople.Count}");
        }
    }
}
