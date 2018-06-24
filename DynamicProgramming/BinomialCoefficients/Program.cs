using System;
using System.Diagnostics;

namespace BinomialCoefficients
{
    class Program
    {
        private static long[,] memo;
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            long k = long.Parse(Console.ReadLine());
            Stopwatch watch = Stopwatch.StartNew();
            memo = new long[n + 1, k + 1];
            Console.WriteLine(Binom(n, k));
            Console.WriteLine(watch.Elapsed);
        }

        private static long Binom(long n, long k)
        {
            if (memo[n, k] != 0)
            {
                return memo[n, k];
            }
            if (k == n || k == 0)
            {
                return 1;
            }
            memo[n, k] = Binom(n - 1, k - 1) + Binom(n - 1, k);
            return memo[n, k];
            //return Binom(n - 1, k - 1) + Binom(n - 1, k);
        }
    }
}