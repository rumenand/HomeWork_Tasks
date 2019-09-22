using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_10.___Predicate_Party_
{
    class Program
    {
        static void Main()
        {
            var partyPepole = Console.ReadLine().Split().ToList();
            RunIputCommands(partyPepole);
            PrintList(partyPepole);
        }

        static void RunIputCommands(List<string> list)
        {
            string input;
            while ((input = Console.ReadLine()) != "Party!")
            {
                var commands = input.Split();
                if (commands.Length == 3)
                {
                    var action = commands[0];
                    var possition = commands[1];
                    var value = commands[2];
                    switch (possition)
                    {
                        case "StartsWith":
                            CheckPersons(action, list, n => n.StartsWith(value));
                            break;
                        case "EndsWith":
                            CheckPersons(action, list, n => n.EndsWith(value));
                            break;
                        case "Length":
                            CheckPersons(action, list, n => n.Length == int.Parse(value));
                            break;
                    }
                }
            }
        }

        static void PrintList(List<string> list)
        {            
               if (list.Count>0) Console.WriteLine($"{string.Join(", ",list)} are going to the party!");
            else Console.WriteLine("Nobody is going to the party!");
        }

        static void CheckPersons(string action, List<string> list, Func<string,bool> predicate)
        {
            for (int i=list.Count-1; i>=0; i--)
            {
                if (predicate(list[i]))
                {
                    if (action == "Remove")  list.RemoveAt(i);        
                    if (action == "Double")  list.Insert(i, list[i]);                        
                }                
            }
        }
    }
}
