using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> legendaryItems = new Dictionary<string, int>
            {
                {"shards",0},
                {"fragments",0},
                {"motes",0}
            };

            Dictionary<string, int> junkItems = new Dictionary<string, int>();

            bool isRunning = true;
            string winnerItem = "";

            while (isRunning)
            {
                string[] parts = Console.ReadLine().Split();

                for (int i = 0; i < parts.Length; i += 2)
                {
                    int quiantity = int.Parse(parts[i]);
                    string item = parts[i + 1].ToLower();

                    if (legendaryItems.ContainsKey(item))
                    {
                        legendaryItems[item] += quiantity;

                        if (legendaryItems[item] >= 250)
                        {
                            winnerItem = item;
                            legendaryItems[item] -= 250;
                            isRunning = false;
                            break;
                        }
                    }
                    else
                    {
                        if (junkItems.ContainsKey(item))
                        {
                            junkItems[item] += quiantity;
                        }
                        else
                        {
                            junkItems.Add(item, quiantity);
                        }
                    }
                }
            }
            if (winnerItem == "shards")
            {
                Console.WriteLine("Shadowmourne obtained!");
            }
            else if (winnerItem == "fragments")
            {
                Console.WriteLine("Valanyr obtained!");
            }
            else
            {
                Console.WriteLine("Dragonwrath obtained!");
            }

            Dictionary<string, int> sortedLegendaryItems = legendaryItems
                .OrderByDescending(i => i.Value)
                .ThenBy(i => i.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in sortedLegendaryItems)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            Dictionary<string, int> sortedJunkItems = junkItems
                .OrderBy(i => i.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in sortedJunkItems)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
