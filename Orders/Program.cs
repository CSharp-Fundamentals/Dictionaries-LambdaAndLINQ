using System;
using System.Collections.Generic;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> productPrice = new Dictionary<string, decimal>();
            Dictionary<string, int> productQuantity = new Dictionary<string, int>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line=="buy")
                {
                    break;
                }

                string[] parts = line.Split();

                string product = parts[0];
                decimal price = decimal.Parse(parts[1]);
                int quantity = int.Parse(parts[2]);

                if (productPrice.ContainsKey(product))
                {
                    productQuantity[product] += quantity;
                    productPrice[product] = price;
                }
                else
                {
                    productPrice.Add(product,price);
                    productQuantity.Add(product,quantity);
                }
            }

            foreach (var item in productPrice)
            {
                string product = item.Key;
                decimal price = item.Value;
                int quantity = productQuantity[product];

                decimal totalPrice = quantity * price;

                Console.WriteLine($"{product} -> {totalPrice}");

            }
        }
    }
}
