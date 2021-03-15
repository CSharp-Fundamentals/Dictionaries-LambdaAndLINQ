using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line=="end")
                {
                    break;
                }

                string[] tokens = line.Split(" : ");
                string courseName = tokens[0];
                string student = tokens[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>());
                }
                courses[courseName].Add(student);
            }
            Dictionary<string, List<string>> sorted=courses
                .OrderByDescending(i => i.Value.Count)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in sorted)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");

                item.Value.Sort();

                foreach (var student in item.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
