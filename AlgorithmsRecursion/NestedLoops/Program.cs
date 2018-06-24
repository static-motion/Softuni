using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedLoops
{
    class Program
    {
        
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            int[] iterations = new int[count];
            GetIterations(count, iterations);
        }

        private static void GetIterations(int count,int[] iterations, int index = 0)
        {
            if (index == count)
            {
                Console.WriteLine(string.Join(" ", iterations));
                return;
            }

            for (int i = 1; i <= count; i++)
            {
                iterations[index] = i;
                GetIterations(count, iterations, index + 1);
            }
        }
    }
}
