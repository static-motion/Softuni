using System;


class LargerThanNeighbours
{
    static void Main(string[] args)
    {
        int[] numbers = { 1, 3, 4, 5, 1, 0, 5 };
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(IsLargerThanNeighbours(numbers, i));
        }
        

    }

    private static bool IsLargerThanNeighbours(int[] numbers, int v)
    {
        bool check = false;

        if(v == 0)
        {
            check = numbers[v] > numbers[v + 1];
        }
        else if(v == numbers.Length - 1)
        {
            check = numbers[v] > numbers[v - 1];
        }
        else
        {
            check = numbers[v] > numbers[v + 1] && numbers[v] > numbers[v - 1];
        }
        return check;
    }
}

