using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    class StartUp
    {
        static void Main()
        {
            var records = new List<Soldier>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                  var commands = input.Split();
                    switch (commands[0])
                    {
                        case "Private":
                            records.Add(new Private(int.Parse(commands[1]),
                            commands[2], commands[3], decimal.Parse(commands[4])));
                            break;

                        case "LieutenantGeneral":                            
                                records.Add(new LieutenantGeneral(int.Parse(commands[1]),
                                commands[2], commands[3], decimal.Parse(commands[4]),
                                GetPrivates(commands, records)));                            
                            break;
                        case "Engineer":
                        try
                        {
                            records.Add(new Engineer(int.Parse(commands[1]), commands[2], commands[3], decimal.Parse(commands[4]),
                            commands[5], commands.Skip(6).ToArray()));
                        }
                        catch (Exception)
                        {

                        }
                            break;
                        case "Commando":
                        try
                        {
                            records.Add(new Commando(int.Parse(commands[1]), commands[2], commands[3], decimal.Parse(commands[4]),
                            commands[5], commands.Skip(6).ToArray()));
                        }
                        catch (Exception)
                        {

                        }
                            break;
                        case "Spy":
                            records.Add(new Spy(int.Parse(commands[1]), commands[2], commands[3], int.Parse(commands[4])));
                            break;
                    }                
                             
            }
            Console.WriteLine(string.Join(Environment.NewLine, records));
        }
             
        private static Private[] GetPrivates(string[] commands, List<Soldier> records)
        {
            var listOfPrivates = new List<Private>();
            var privatesNumbers = commands.Skip(5).Select(x => int.Parse(x));
            foreach (var num in privatesNumbers)
            {
                
                    var currentPrivate = records.Where(x => x.Id == num && x.GetType().Equals(typeof(Private))).FirstOrDefault();
                    if (currentPrivate != null)
                    {
                        listOfPrivates.Add((Private)currentPrivate);
                    }             
            }
            return listOfPrivates.ToArray();
        }
    }
}
