using System;

namespace Fibonacci
{
    class Program
    {
        private static long[] memo;
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            memo = new long[n + 1];
            Console.WriteLine(CalculateFibonacci(n));
        }

        private static long CalculateFibonacci(int fib)
        {
            if (memo[fib] != 0)
            {
                return memo[fib];
            }
            if (fib <= 2)
            {
                memo[fib] = 1;
            }
            else
            {
                memo[fib] = CalculateFibonacci(fib - 1) + CalculateFibonacci(fib - 2);
            }
            return memo[fib];
        }
    }
}
