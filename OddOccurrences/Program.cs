using System;
using System.Collections.Generic;

namespace OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Dictionary<string, int> words = new Dictionary<string, int>();

            foreach (var item in input)
            {
                string toLower = item.ToLower();
                if (words.ContainsKey(toLower))
                {
                    words[toLower]++;
                }
                else
                {
                    words.Add(toLower, 1);
                }

            }
            foreach (var item in words)
            {
                if (item.Value%2==1)
                {
                    Console.Write($"{item.Key} ");

                }
            }
            
        }
    }
}