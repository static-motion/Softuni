using System;
using System.Collections.Generic;
using System.Linq;

class TheSieveOfEratosthenes
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        List<int> numbers = Enumerable.Range(2, number - 1).ToList();
        int prime = 2;
        int counter = 1;
        while(counter * prime < number)
        {
            numbers[prime * counter] = 0;
            counter++;
        }
    }
}

