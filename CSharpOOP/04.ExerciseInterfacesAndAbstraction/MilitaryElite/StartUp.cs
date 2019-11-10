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
            while((input = Console.ReadLine()) != "End")
            {
                var commands = input.Split();
                switch(commands[0])
                {
                    case "Private":
                        records.Add(new Private(int.Parse(commands[1]),
                            commands[2], commands[3], decimal.Parse(commands[4])));
                        break;
                    case "LieutenantGeneral":                        
                        records.Add(new LieutenantGeneral(int.Parse(commands[1]),
                            commands[2], commands[3], decimal.Parse(commands[4]),
                            GetPrivates(commands,records)));
                        break;
                    case "Engineer":
                        try
                        {
                            records.Add(new Engineer(int.Parse(commands[1]), commands[2], commands[3], decimal.Parse(commands[4]),
                                commands[5], commands.Skip(6).ToArray()));
                        }
                        catch (ArgumentException e)
                        {
                            //Console.WriteLine(e.Message);
                        }
                        break;
                    case "Commando":
                        try
                        {
                            records.Add(new Commando(int.Parse(commands[1]), commands[2], commands[3], decimal.Parse(commands[4]),
                                commands[5], commands.Skip(6).ToArray()));
                        }
                        catch (ArgumentException e)
                        {
                            //Console.WriteLine(e.Message);
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine,records));
        }
             
        private static Private[] GetPrivates(string[] commands, List<Soldier> records)
        {
            var listOfPrivates = new List<Private>();
            var privatesNumbers = commands.Skip(4).Select(x => int.Parse(x));
            foreach (var num in privatesNumbers)
            {
                var currentPrivate = records.Where(x => x.Id == num && x.GetType().Equals(typeof(Private))).FirstOrDefault();
                if (currentPrivate != null)
                {
                    listOfPrivates.Add(currentPrivate as Private);
                }
            }
            return listOfPrivates.ToArray();
        }
    }
}
