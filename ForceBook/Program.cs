using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> info = new Dictionary<string, List<string>>();
            Dictionary<string, string> members = new Dictionary<string, string>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line=="Lumpawaroo")
                {
                    break;
                }

                if (line.Contains(" | "))
                {
                    string[] tokens = line.Split(" | ");
                    string forceSide = tokens[0];
                    string forceUser = tokens[1];

                    if (members.ContainsKey(forceUser))
                    {
                        continue;
                    }

                    if (!info.ContainsKey(forceSide))
                    {
                        info.Add(forceSide, new List<string>());
                    }

                    info[forceSide].Add(forceUser);
                    members.Add(forceUser,forceSide);
                }
                else
                {
                    string[] tokens = line.Split(" -> ");
                    string forceUser = tokens[0];
                    string forceSide = tokens[1];

                    if (!info.ContainsKey(forceSide))
                    {
                        info.Add(forceSide,new List<string>());
                    }

                    if (members.ContainsKey(forceUser))
                    {
                        string oldSide = members[forceUser];

                        info[oldSide].Remove(forceUser);
                        info[forceSide].Add(forceUser);
                        members[forceUser] = forceSide;
                    }
                    else
                    {
                        info[forceSide].Add(forceUser);
                        members.Add(forceUser, forceSide);
                    }
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
            }

            Dictionary<string, List<string>> output = info
                .Where(s => s.Value.Count > 0)
                .OrderByDescending(s => s.Value.Count)
                .ThenBy(s => s.Key)
                .ToDictionary(x=>x.Key, x=>x.Value);

            foreach (var item in output)
            {
                Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");

                item.Value.Sort();

                foreach (var member in item.Value)
                {
                    Console.WriteLine($"! {member}");
                }
            }
        }
    }
}