using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinomialCoefficient
{
    class Program
    {
        static void Main()
        {
            int set = int.Parse(Console.ReadLine());
            int len = int.Parse(Console.ReadLine());
            long result = GetBinomialCoeff(set, len);
            Console.WriteLine(result);
        }

        private static long GetBinomialCoeff(int set, int len)
        {
            long result = 1;
            for (int i = 1; i <= len; i++)
            {
                result *= set--;
                result /= i;
            }
            return result;
        }
    }
}
