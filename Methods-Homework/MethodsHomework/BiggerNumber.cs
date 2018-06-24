using System;

class BiggerNumber
{
    static void Main()
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());
        int max = GetMax(firstNumber, secondNumber);
        Console.WriteLine(max);
    }
    static int GetMax(int numOne,int numTwo)
    {
        int maxValue = Math.Max(numOne, numTwo);
        return maxValue;
    }
}

