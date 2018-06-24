using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Travelling_Policeman
{
    class Street : IComparable<Street>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public int Pokemons { get; set; }
        public int Damage { get; set; }
        public double Rating { get; set; }
        public bool Processed;

        public Street(int id, string name, int length, int pokemons, int damage, double rating)
        {
            this.Id = id;
            this.Name = name;
            this.Length = length;
            this.Pokemons = pokemons;
            this.Damage = damage;
            this.Rating = rating;
        }

        public override string ToString()
        {
            return this.Name;
        }

        public int CompareTo(Street other)
        {
            int cmp = other.Rating.CompareTo(this.Rating);
            if (cmp == 0)
            {
                cmp = this.Length.CompareTo(other.Length);
            }
            if (cmp == 0)
            {
                cmp = other.Pokemons.CompareTo(other.Pokemons);
            }
            return cmp;
        }
    }
    class Program
    {
        static void Main()
        {
            int fuel = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            List<Street> streets = new List<Street>();
            int id = 1;
            List<Street> byEntry = new List<Street>();
            while (command != "End")
            {
                Match match = Regex.Match(command, @"(.*), (\d+), (\d+), (\d+)");
                int carDamage = int.Parse(match.Groups[2].Value);
                int pokemons = int.Parse(match.Groups[3].Value);
                int length = int.Parse(match.Groups[4].Value);
                double rating = ((double)(pokemons * 10 - carDamage) / length) * pokemons;
                command = Console.ReadLine();
                if (rating < 0) { continue;}
                Street street = new Street(id++, match.Groups[1].Value, length, pokemons, carDamage, rating);
                streets.Add(street);
                byEntry.Add(street);
            }
            streets.Sort();
            int pokemonsCaught = 0;
            int totalDamage = 0;
            foreach (var street in streets)
            {
                if(fuel - street.Length < 0) { continue;}
                fuel -= street.Length;
                pokemonsCaught += street.Pokemons;
                totalDamage += street.Damage;
                byEntry[street.Id - 1].Processed = true;
            }
            Console.WriteLine(string.Join(" -> ", byEntry.Where(s => s.Processed).Select(s => s)));
            Console.WriteLine($"Total pokemons caught -> {pokemonsCaught}");
            Console.WriteLine($"Total car damage -> {totalDamage}");
            Console.WriteLine($"Fuel Left -> {fuel}");
        }
    }
}