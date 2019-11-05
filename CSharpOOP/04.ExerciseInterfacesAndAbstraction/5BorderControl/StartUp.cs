using System;
using System.Collections.Generic;
using System.Linq;

namespace _5BorderControl
{
    class StartUp
    {
        static void Main()
        {
            var userList = new List<IID>();
            string input;
            while((input = Console.ReadLine()) != "End")
            {
                var args = input.Split();
                if (args.Length == 2)
                {
                    userList.Add(new Robot(args[0], args[1]));
                }
                else if (args.Length == 3)
                {
                    userList.Add(new Citizen(args[0],int.Parse(args[1]),args[2]));
                }
            }
            var fakeNum = Console.ReadLine();
            foreach (var item in userList)
            {
                if (item.Id.EndsWith(fakeNum)) Console.WriteLine(item.Id);
            }
        }
    }
}
