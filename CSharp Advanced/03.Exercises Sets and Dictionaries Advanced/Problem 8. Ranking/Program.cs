using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_8._Ranking
{    
    class Program
    {
        static void Main()
        {
            var exams = new Dictionary<string, string>();
            var submissions = new Dictionary<string, Dictionary<string,int>>();
            string input;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                var commands = input.Split(":");
                if (!exams.ContainsKey(commands[0])) exams.Add(commands[0], commands[1]);

            }
            while ((input = Console.ReadLine()) != "end of submissions")
            {
                var commands = input.Split("=>");
                if (exams.ContainsKey(commands[0]) && exams[commands[0]] == commands[1])
                {
                    string user = commands[2];
                    string exam = commands[0];
                    int points = int.Parse(commands[3]);
                    if (!submissions.ContainsKey(user)) submissions.Add(user, new Dictionary<string, int>());
                    if (!submissions[user].ContainsKey(exam)) submissions[user].Add(exam, points);
                    else if (submissions[user][exam] < points) submissions[user][exam] = points;
                }
            }
            int bestPoints = 0;
            string bestCandidate = "";
            foreach (var user in submissions)
            {
                int currentScore = 0;
                foreach (var submit in user.Value)
                {
                    currentScore += submit.Value;
                }
                if (currentScore > bestPoints)
                {
                    bestPoints = currentScore;
                    bestCandidate = user.Key;
                }
            }
            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var user in submissions.OrderBy(x=>x.Key))
            {
                Console.WriteLine(user.Key);
                foreach (var submit in user.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {submit.Key} -> {submit.Value}");
                }
            }
        }
    }
}
