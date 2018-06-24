using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.PrintFigure
{
    class Program
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            PrintFigure(input);
        }

        private static void PrintFigure(int input)
        {
            if (input == 0)
                return;

            Console.WriteLine(new string('*', input));
            PrintFigure(input - 1);
            Console.WriteLine(new string('#', input));
        }
    }
}
