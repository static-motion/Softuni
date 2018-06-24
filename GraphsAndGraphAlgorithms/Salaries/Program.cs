using System;
using System.Collections.Generic;
using System.Linq;

namespace Salaries
{
    class Program
    {
        private static List<int>[] hierarchy;
        private static bool[] hasManager;
        private static long[] salaries;
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            hierarchy = new List<int>[n];
            hasManager = new bool[n];
            salaries = new long[n];
            for (int i = 0; i < n; i++)
            {
                hierarchy[i] = new List<int>(n);
                string line = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    if (line[j] == 'Y' && j != i)
                    {
                        hierarchy[i].Add(j);
                        hasManager[j] = true;
                    }
                }
            }
            List<int> bosses = new List<int>();
            for (int i = 0; i < hasManager.Length; i++)
            {
                if (!hasManager[i])
                {
                    bosses.Add(i);
                }
            }
            foreach (var boss in bosses)
            {
                GetSalaries(boss);
            }
            Console.WriteLine(salaries.Sum());
        }

        private static long GetSalaries(int boss)
        {
            if (salaries[boss] != 0)
            {
                return salaries[boss];
            }
            if (hierarchy[boss].Count == 0)
            {
                salaries[boss] = 1;
                return 1;
            }
            foreach (var employee in hierarchy[boss])
            {
               salaries[boss] += GetSalaries(employee);
            }
            return salaries[boss];
        }
    }
}
