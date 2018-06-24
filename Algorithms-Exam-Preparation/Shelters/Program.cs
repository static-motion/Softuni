using System;
using System.Collections.Generic;
using System.Linq;

namespace Shelters
{
    class Bunker
    {
        public int Capacity { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Bunker(int capacity, int x, int y)
        {
            this.Capacity = capacity;
            this.X = x;
            this.Y = y;
        }
    }

    class Soldier
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Soldier(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    class Program
    {
        private static List<Soldier> allSoldiers;
        private static List<Bunker> allBunkers;
        static void Main()
        {
            int[] parameters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int soldiers = parameters[0];
            allSoldiers = new List<Soldier>(soldiers);
            int bunkers = parameters[1];
            allBunkers = new List<Bunker>(bunkers);
            int bunkerCapacity = parameters[2];

            for (int i = 0; i < soldiers; i++)
            {
                int[] coords = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                allSoldiers.Add(new Soldier(coords[0], coords[1]));
            }

            for (int i = 0; i < bunkers; i++)
            {
                int[] coords = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                allBunkers.Add(new Bunker(bunkerCapacity, coords[0], coords[1]));
            }

        }
    }
}
