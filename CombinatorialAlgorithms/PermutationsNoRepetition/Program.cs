using System;
using System.Collections.Generic;

namespace PermutationsNoRepetition
{
    class Program
    {
        private static string[] elements;

        static void Main()
        {
            elements = Console.ReadLine().Split(' ');
            Gen(0);
        }

       

        private static void Gen(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
            }
            else
            {
                Gen(index + 1);
                HashSet<string> used = new HashSet<string>();
                used.Add(elements[index]);
                for (int i = index + 1; i < elements.Length; i++)
                {
                    if (!used.Contains(elements[i]))
                    {
                        used.Add(elements[i]);
                        Swap(index, i);
                        Gen(index + 1);
                        Swap(index, i);
                    }
                }
            }
        }

        private static void Swap(int index, int i)
        {
            string tmp = elements[index];
            elements[index] = elements[i];
            elements[i] = tmp;
        }
        private static void GenIterative()
        {
            int j = 0;
            int n = elements.Length;
            int[] p = new int[n + 1];
            for (int i = 0; i < p.Length; i++)
            {
                p[i] = i;
            }
            int index = 1;
            while (index < n)
            {
                --p[index];
                if (index % 2 != 0)
                {
                    j = p[index];
                }
                else
                {
                    j = 0;
                }
                Swap(j, index);
                index = 1;
                while (p[index] == 0)
                {
                    p[index] = index;
                    ++index;
                }
                Console.WriteLine(string.Join(" ", elements));
            }
        }
    }

}
