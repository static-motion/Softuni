using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FractionalKnapsack
{
    class Program
    {
        static void Main()
        {
            SortedList<double, Item> asd = new SortedList<double, Item>();
            int capacity = int.Parse(Regex.Match(Console.ReadLine(), @"\d+").Groups[0].Value);
            int items = int.Parse(Regex.Match(Console.ReadLine(), @"\d+").Groups[0].Value);
            double total = 0;
            for (int i = 0; i < items; i++)
            {
                Match match = Regex.Match(Console.ReadLine(), @"(\d+)\s\D+\s(\d+)");
                double price = double.Parse(match.Groups[1].Value);
                double weight = double.Parse(match.Groups[2].Value);
                double ptw = price / weight; //price to weight ratio
                Item item = new Item(price, weight);
                asd.Add(ptw, item);
            }

            foreach (var item in asd.Reverse())
            {
                double price = item.Value.Price;
                double weight = item.Value.Weight;
                double taken = capacity - item.Value.Weight;
                if (taken < 0) //can't fit whole item
                {
                    taken *= -1;
                    var percentTaken = 100 - (taken * 100 / weight);
                    total += percentTaken / 100 * price;
                    Console.WriteLine($"Take {percentTaken:##.00}% of item with price {price:##.00} and weight {weight:##.00}");
                    break;
                }
                total += item.Value.Price;
                Console.WriteLine($"Take 100% of item with price {price:##.00} and weight {weight:##.00}");
                capacity -= (int) weight;

                if(taken == 0)
                    break;
            }
            Console.WriteLine($"Total price: {total:##.00}");
        }
    }

    class Item
    {
        public double Price { get; set; }
        public double Weight { get; set; }

        public Item(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }
    }
}
