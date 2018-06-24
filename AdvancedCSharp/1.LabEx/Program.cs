using System;
using System.Collections.Generic;

class PrimeFactorization
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        List<int> primeFactors = new List<int>();

        var numberInput = number;

        while (number > 1)
        {
            var nextFactor = 2; // 2
            if (number % nextFactor > 0)
            {
                nextFactor = 3; // 3
                do
                {
                    if (number % nextFactor == 0)
                    {
                        break;
                    }

                    nextFactor += 2; // 5, 7, 9 etc.
                } while (nextFactor < number);
            }

            number /= nextFactor;
            primeFactors.Add(nextFactor);
        }

        Console.WriteLine("{0} = {1}", numberInput, string.Join(" * ", primeFactors));
    }
}