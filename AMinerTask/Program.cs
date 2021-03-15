using System;
using System.Collections.Generic;

namespace AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input=="stop")
                {
                    break;
                }
                
                int quantity =int.Parse(Console.ReadLine());

                if (words.ContainsKey(input))
                {
                    words[input] += quantity;
                }
                else
                {
                    words.Add(input, quantity);
                }
            }

            foreach (var item in words)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");

            }
        }
    }
}
