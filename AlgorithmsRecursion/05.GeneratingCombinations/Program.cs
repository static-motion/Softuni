using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.GeneratingCombinations
{
    class Program
    {
        static void Main()
        {
            int[] set = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());
            GenerateCombinations(set, new int[n]);
        }

        private static void GenerateCombinations(int[] set, int[] vector, int index = 0, int border = 0)
        {
            if (index > vector.Length - 1)
            {
                Print(vector);
                return;
            }


            for (int i = border; i < set.Length; i++)
            {
                vector[index] = set[i];
                GenerateCombinations(set, vector, index + 1, ++border);
            }
            

        }

        private static void Print(int[] vector)
        {
            Console.WriteLine(string.Join(" ", vector));
        }
    }
}
