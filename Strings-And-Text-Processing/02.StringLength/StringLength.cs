using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class StringLength
{
    static void Main()
    {
        string input = Console.ReadLine();
        if(input.Length >= 20)
        {
            string substring = input.Substring(0, 20);
            Console.WriteLine(substring);
        }
        else
        {
            StringBuilder fillTheString = new StringBuilder();
            fillTheString.Append(input);
            fillTheString.Append(new string('*', 20 - input.Length));
            Console.WriteLine(fillTheString);
        }
    }
}

