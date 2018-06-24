using System;
using System.Linq;

namespace InversionCount
{
    class Program
    {
        static void Main()
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int inversions = InversionCounter<int>.CountInversions(array);
            Console.WriteLine(inversions);
        }
    }
}
