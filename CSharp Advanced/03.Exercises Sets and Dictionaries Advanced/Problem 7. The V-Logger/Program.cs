using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_7._The_V_Logger
{
    class VloggerData
    {
        public HashSet<string> followers;
        public HashSet<string> following;

        public VloggerData()
        {
            followers = new HashSet<string>();
            following = new HashSet<string>();
        }

        public int GetFollowers()
        {
            return followers.Count;
        }

        public int GetFollowing()
        {
            return following.Count;
        }
    }
    class Program
    {
        static void Main()
        {
            var vloggers = new Dictionary<string, VloggerData>();
            string input;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string [] commands  = input.Split();
                string name = commands[0];
                string command = commands[1];
                if (command == "joined")
                {
                    if (!vloggers.ContainsKey(name)) vloggers.Add(name, new VloggerData());
                }
                else if (command == "followed")
                {
                    string name2 = commands[2]; 
                    if (name != name2 && vloggers.ContainsKey(name) && vloggers.ContainsKey(name2))
                    {
                        vloggers[name].following.Add(name2);
                        vloggers[name2].followers.Add(name);
                    }
                }                
            }
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            var sortedVloggers = vloggers.OrderByDescending(x => x.Value.followers.Count)
                .ThenBy(x => x.Value.following.Count);
            int count = 1;
            foreach (var vlogger in sortedVloggers)
            {
                Console.WriteLine($"{count}. {vlogger.Key} : {vlogger.Value.followers.Count} followers, {vlogger.Value.following.Count} following");
                if (count == 1)
                {
                    foreach (var follower in vlogger.Value.followers.OrderBy(x=>x))
                        Console.WriteLine($"*  {follower}");
                }
                count++;
            }
        }
    }
}
