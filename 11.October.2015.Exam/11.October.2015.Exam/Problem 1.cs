using System;
using System.Collections.Generic;
using System.Linq;


class Problem1
{
    static void Main()
    {
        int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        List<string> commands = Console.ReadLine().Split(' ').ToList();
        int index;
        string evenOrOdd;
        int count;
        while (commands[0] != "end")
        {
            switch (commands[0])
            {
                case "exchange":
                    {
                        index = int.Parse(commands[1]);
                        if (index < input.Length && index >= 0)
                        {
                            input = ExchangeArray(input, index);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;
                    }
                case "max":
                    {
                        evenOrOdd = commands[1];
                        MaxEvenOrOdd(input, evenOrOdd);
                        break;
                    }
                case "min":
                    {
                        evenOrOdd = commands[1];
                        MinEvenOrOdd(input, evenOrOdd);
                        break;
                    }
                case "first":
                    {
                        count = int.Parse(commands[1]);
                        if (count <= input.Length)
                        {
                            evenOrOdd = commands[2];
                            FirstCountEvenOrOdd(input, count, evenOrOdd);
                        }
                        else
                        {
                            Console.WriteLine("Invalid count");
                        }
                        break;
                    }
                case "last":
                    {
                        count = int.Parse(commands[1]);
                        if (count <= input.Length)
                        {
                            evenOrOdd = commands[2];
                            LastCountEvenOrOdd(input, count, evenOrOdd);
                        }
                        else
                        {
                            Console.WriteLine("Invalid count");
                        }
                        break;
                    }
            }
            commands = Console.ReadLine().Split(' ').ToList();
        }
        Console.WriteLine("[" + string.Join(", ", input) + "]");
    }

    private static void LastCountEvenOrOdd(int[] input, int count, string evenOrOdd)
    {
        List<int> elements = new List<int>();
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] % 2 != 0 && evenOrOdd == "odd")
            {
                elements.Add(input[i]);
            }
            else if (input[i] % 2 == 0 && evenOrOdd == "even")
            {
                elements.Add(input[i]);
            }
        }
        if (elements.Count - count >= 0)
        {
            elements.RemoveRange(0, elements.Count - count);
        }
        Console.WriteLine("[" + String.Join(", ", elements) + "]");
    }

    private static void FirstCountEvenOrOdd(int[] input, int count, string evenOrOdd)
    {
        var elements = new List<int>();
        for (int i = 0; i < input.Length && elements.Count < count; i++)
        {
            if (input[i] % 2 != 0 && evenOrOdd == "odd")
            {
                elements.Add(input[i]);
            }
            else if (input[i] % 2 == 0 && evenOrOdd == "even")
            {
                elements.Add(input[i]);
            }
        }
        Console.WriteLine("[" + String.Join(", ", elements) + "]");
    }

    private static void MinEvenOrOdd(int[] input, string evenOrOdd)
    {
        int minNumber = int.MaxValue;
        int minNumberIndex = -1;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] % 2 == 0 && evenOrOdd == "even")
            {
                if (input[i] <= minNumber)
                {
                    minNumber = input[i];
                    minNumberIndex = i;
                }
            }
            else if (input[i] % 2 != 0 && evenOrOdd == "odd")
            {
                if (input[i] <= minNumber)
                {
                    minNumber = input[i];
                    minNumberIndex = i;
                }
            }
        }
        if (minNumberIndex != -1)
        {
            Console.WriteLine(minNumberIndex);
        }
        else
        {
            Console.WriteLine("No matches");
        }
    }

    private static void MaxEvenOrOdd(int[] input, string evenOrOdd)
    {
        int maxNumber = int.MinValue;
        int maxNumberIndex = -1;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] % 2 == 0 && evenOrOdd == "even")
            {
                if (input[i] >= maxNumber)
                {
                    maxNumber = input[i];
                    maxNumberIndex = i;
                }
            }
            else if (input[i] % 2 != 0 && evenOrOdd == "odd")
            {
                if (input[i] >= maxNumber)
                {
                    maxNumber = input[i];
                    maxNumberIndex = i;
                }
            }
        }
        if (maxNumberIndex == -1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine(maxNumberIndex);
        }
    }

    private static int[] ExchangeArray(int[] input, int index)
    {
        int[] exchangedArray = new int[input.Length];
        int j = 0;
        for (int i = index + 1; i < input.Length; i++, j++)
        {
            exchangedArray[j] = input[i];
        }
        for (int i = 0; i <= index; i++, j++)
        {
            exchangedArray[j] = input[i];
        }
        return exchangedArray;
    }
}

