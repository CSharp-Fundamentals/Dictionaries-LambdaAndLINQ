using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> info = new SortedDictionary<string, List<string>>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line=="End")
                {
                    break;
                }

                string[] tokens = line.Split(" -> ");
                string company = tokens[0];
                string employee = tokens[1];

                if (!info.ContainsKey(company))
                {
                    info.Add(company, new List<string>());
                }
                    info[company].Add(employee);
            }

            foreach (var company in info)
            {
                Console.WriteLine($"{company.Key}");

                List<string> uniqueEmployees = company.Value
                    .Distinct()
                    .ToList();

                foreach (var employee in uniqueEmployees)
                {
                    Console.WriteLine($"-- {employee}");
                }
            }
        }
    }
}
