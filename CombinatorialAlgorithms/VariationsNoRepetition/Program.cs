using System;

namespace VariationsNoRepetition
{
    class Program
    {
        private static string[] elements;
        private static string[] vector;
        private static bool[] used;
        
        static void Main()
        {
            elements = Console.ReadLine().Split(' ');
            int length = int.Parse(Console.ReadLine());
            vector = new string[length];
            used = new bool[length];
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
                for (int i = 0; i < length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        vector[index] = elements[i];
                        Gen(length, index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        private static void Print()
        {
            Console.WriteLine(string.Join(" ", vector));
        }
    }
}
