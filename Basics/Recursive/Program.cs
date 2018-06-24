using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)


        {
            int enter = int.Parse(Console.ReadLine());
            int lengh = (4 * enter) + 1;
            int height = (2 * enter);

            char dots = '.';
            char asterisk = '*';
            char slash = '/';
            char pipe = '|';
            char dash = '-';
            char leftSlash = '\\';
            string format = "{0}{1}{2}{3}{0}";
            string formatMid = "{0}{1}{2}{1}{2}{1}{0}";


            for (int i = 0; i < 1; i++)
            {
                string firstTwoRolls = string.Format(format,
                    new string(dots, lengh / 2),
                    new string(slash, 1),
                    new string(pipe, 1),
                    new string(leftSlash, 1));
                Console.WriteLine(firstTwoRolls);
                string secondRoll = string.Format(format,
                    new string(dots, lengh / 2),
                    new string(leftSlash, 1),
                    new string(pipe, 1),
                    new string(slash, 1));
                Console.WriteLine(secondRoll);
            }
            for (int i = 0; i < height; i++)
            {
                string fromating = string.Format(formatMid,
                    new string(dots, (lengh / 2) - i),
                    new string(asterisk, 1),
                    new string(dash, i));
                Console.WriteLine(fromating);

            }
        }
    }
}