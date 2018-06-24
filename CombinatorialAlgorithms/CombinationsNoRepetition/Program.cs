using System;

namespace CombinationsNoRepetition
{
    class Program
    {
        private static string[] elements;
        private static string[] vector;
        static void Main()
        {
            elements = Console.ReadLine().Split(' ');
            int vLength = int.Parse(Console.ReadLine());
            vector = new string[vLength];
            Gen(vLength);
        }

        private static void Gen(int vLength, int index = 0, int border = 0)
        {
            if (index >= vLength)
            {
                Print();
            }
            else
            {
                for (int i = border; i < elements.Length; i++)
                {
                    vector[index] = elements[i];
                    Gen(vLength, index + 1, ++border);
                }
            }
        }

        private static void Print()
        {
            Console.WriteLine(string.Join(" ", vector));
        }
    }
}
