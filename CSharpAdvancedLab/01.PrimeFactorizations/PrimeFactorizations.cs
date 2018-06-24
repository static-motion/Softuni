using System;
using System.Collections.Generic;
using System.Linq;

class PrimeFactorizations
{
    static void Main()
    {
        int inputNumber = int.Parse(Console.ReadLine());
        int inputNumberBackUp = inputNumber;

        List<int> divisors = new List<int>();
        List<int> primeNumbers = Enumerable.Range(2, inputNumber - 1).ToList();

        for (int i = 0; i < primeNumbers.Count; i++)
        {
            int sss = primeNumbers[i];
            int sqr = sss * sss;
            primeNumbers.RemoveAll(j => j >= sqr && j % sss == 0);
        }

        foreach (var divisor in primeNumbers)
        {
            while (inputNumber % divisor == 0)
            {
                divisors.Add(divisor);
                inputNumber /= divisor;
            }
        }
        Console.WriteLine("{0} = {1}",inputNumberBackUp, String.Join(" * ", divisors));
    }
}

