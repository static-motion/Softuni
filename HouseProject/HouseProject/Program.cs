using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int stars = 1;

            if (n % 2 == 0)
            {
                stars++;
            }

            for (int i = 0; i < (n + 1) / 2; i++)
            {
                int padding = (n - stars) / 2;
                Console.Write(new string('-', padding));
                Console.Write(new string('*', stars));
                Console.WriteLine(new string('-', padding));
                stars += 2;
            }

            for (int i = 0; i < n / 2; i++)
            {
                Console.Write(new string('|', 1));
                Console.Write(new string('*', n - 2));
                Console.WriteLine(new string('|', 1));
            }
        }
    }
}
