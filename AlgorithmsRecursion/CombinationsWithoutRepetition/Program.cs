using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationsWithoutRepetition
{
    class Program
    {
        static void Main()
        {
            int maxNum = int.Parse(Console.ReadLine());
            int count = int.Parse(Console.ReadLine());
            int[] iterations = new int[count];
            GetIterations(count, maxNum, iterations, 1);
        }

        private static void GetIterations(int count, int maxNum, int[] iterations, int border, int index = 0)
        {
            if (index == count)
            {
                Console.WriteLine(string.Join(" ", iterations));
                return;
            }

            for (int i = border; i <= maxNum; i++)
            {
                iterations[index] = i;
                GetIterations(count, maxNum, iterations, ++border, index + 1);
            }
        }
    }
}
