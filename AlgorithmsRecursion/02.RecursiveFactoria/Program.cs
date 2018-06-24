using System;

namespace _02.RecursiveFactorial
{
    class Program
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            int result = CalculateFactorial(input);
            Console.WriteLine(result);
        }

        private static int CalculateFactorial(int input)
        {
            if (input == 1)
            {
                return input;
            }

            return input * CalculateFactorial(--input);
        }
    }
}
