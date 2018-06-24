using System;

namespace FractionCalculator
{
    class Program
    {
        static void Main()
        {
            var fraction1 = new Fraction(22, 7);
            var fraction2 = new Fraction(40, 4);
            var result = fraction1 + fraction2;
            Console.WriteLine(result.Numerator);
            Console.WriteLine(result.Denominator);
            Console.WriteLine(result);
        }
    }
}
