using System;

namespace VariationsWithRepetitions
{
    class VariationsWithRepetition
    {
        private static string[] elements;
        private static string[] vector;
        static void Main()
        {
            elements = Console.ReadLine().Split(' ');
            int length = int.Parse(Console.ReadLine());
            vector = new string[length];
            Gen(length);
        }

        private static void Gen(int length, int index = 0)
        {
            if (index >= length)
            {
                Print();
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    vector[index] = elements[i];
                    Gen(length, index + 1);
                }
            }
        }

        private static void Print()
        {
            Console.WriteLine(string.Join(" ", vector));
        }
    }
}
