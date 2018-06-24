using System;
using System.Collections.Generic;
using System.Linq;

namespace TowersOfHanoi
{
    class Program
    {
        private static Stack<int> source;
        private static readonly Stack<int> destination = new Stack<int>();
        private static readonly Stack<int> spare = new Stack<int>();
        private static int stepsTaken = 1;

        static void Main()
        {
            int bottomDisc = int.Parse(Console.ReadLine());
            source = new Stack<int>(Enumerable.Range(1, bottomDisc).Reverse());
            PrintRods();
            MoveDiscs(bottomDisc, source, destination, spare);

        }

        private static void MoveDiscs(int bottomDisc, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            if (bottomDisc == 1)
            {
                Console.WriteLine($"Step #{stepsTaken}: Moved disk");
                stepsTaken++;
                destination.Push(source.Pop());
                PrintRods();
            }
            else
            {
                MoveDiscs(bottomDisc - 1, source, spare, destination);
                Console.WriteLine($"Step #{stepsTaken}: Moved disk");
                stepsTaken++;
                destination.Push(source.Pop());
                PrintRods();
                MoveDiscs(bottomDisc - 1, spare, destination, source);
            }
        }

        private static void PrintRods()
        {
            Console.WriteLine("Source: {0}", string.Join(", ", source.Reverse()));
            Console.WriteLine("Destination: {0}", string.Join(", ", destination.Reverse()));
            Console.WriteLine("Spare: {0}", string.Join(", ", spare.Reverse()));
            Console.WriteLine();
        }
    }
}