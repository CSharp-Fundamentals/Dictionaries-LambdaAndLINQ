using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> info = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!info.ContainsKey(student))
                {
                    info.Add(student, new List<double>());
                }

                info[student].Add(grade);
            }
            Dictionary<string, List<double>> sorted = info
                .Where(s=>s.Value.Average() >=4.5)
                .OrderByDescending(i => i.Value.Average())
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var student in sorted)
            {
                Console.WriteLine($"{student.Key} -> {student.Value.Average():F2}");
                
            }
        }
    }
}
