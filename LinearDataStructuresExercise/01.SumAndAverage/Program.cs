using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _01.SumAndAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var sequence = Console.ReadLine().Split(' ');
                List<int> sequenceList = Array.ConvertAll(sequence, int.Parse).ToList();
                Console.WriteLine($"Sum={sequenceList.Sum()}; Average={sequenceList.Average():##.00}");
            }
            catch (Exception)
            {
                Console.WriteLine($"Sum=0; Average=0");
            }           
        }
    }
}
