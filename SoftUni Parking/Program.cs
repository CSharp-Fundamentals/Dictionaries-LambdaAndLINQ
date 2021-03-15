using System;
using System.Collections.Generic;

namespace SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> info = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string command = tokens[0];
                string username = tokens[1];

                if (command=="register")
                {
                    string licensePlateNumber = tokens[2];
                    if (info.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {info[username]}");
                    }
                    else
                    {
                        info.Add(username,licensePlateNumber);
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                    }
                }
                else
                {
                    if (!(info.ContainsKey(username)))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else
                    {
                        info.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                }
            }
            foreach (var item in info)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
