using System;


class FirstLargerThanNeighbours
{
    static void Main()
    {
        int[] numbers = { 1, 3, 4, 5, 1, 0, 5 };
        int[] numbersTwo = { 1, 2, 3, 4, 5, 6, 6 };
        int[] numbersThree = { 1, 1, 1 };
        Console.WriteLine(IsLargerThanNeighbours(numbers));
        Console.WriteLine(IsLargerThanNeighbours(numbersTwo));
        Console.WriteLine(IsLargerThanNeighbours(numbersThree));


    }

    static int IsLargerThanNeighbours(int[] numbers)
    {
        bool check = false;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (i == 0)
            {
                check = numbers[i] > numbers[i + 1];
            }
            else if (i == numbers.Length - 1)
            {
                check = numbers[i] > numbers[i - 1];
            }
            else
            {
                check = numbers[i] > numbers[i + 1] && numbers[i] > numbers[i - 1];
            }
            if(check)
            {
                int indexPosition = i;
                return indexPosition;
            }
        }
        return -1;
        
        
    }

}

