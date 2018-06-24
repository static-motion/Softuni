using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.RecursiveSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int sum = SumArray(inputArray);
            Console.WriteLine(sum);
        }

        private static int SumArray(int[] inputArray, int index = 0)
        {
            if (index == inputArray.Length - 1)
            {
                return inputArray[index];
            }

            return inputArray[index] + SumArray(inputArray, ++index);
        }
    }
}
