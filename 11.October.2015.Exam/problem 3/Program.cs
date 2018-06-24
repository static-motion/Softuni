using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace problem_3
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            StringBuilder code = new StringBuilder();
            while (input != "//END_OF_CODE")
            {
                code.Append(input + " ");
                input = Console.ReadLine();
            }
            MatchCollection doubleMatches = Regex.Matches(code.ToString(), @"(?<=double\s)\w*(?=\b)");
            MatchCollection integersMatch = Regex.Matches(code.ToString(), @"(?<=int\s)\w*(?=\b)");
            List<string> ints = new List<string>();
            List<string> doubles = new List<string>();
            foreach (Match integer in integersMatch)
            {
                ints.Add(integer.Value);
            }
            foreach (Match doubleMatch in doubleMatches)
            {
                doubles.Add(doubleMatch.Value);
            }
            ints.Sort();
            doubles.Sort();
            if (ints.Count == 0)
            {
                ints.Add("None");
            }
            if (doubles.Count == 0)
            {
                doubles.Add("None");
            }
            Console.WriteLine("Doubles: {0}", String.Join(", ", doubles));
            Console.WriteLine("Ints: {0}", String.Join(", ", ints));
        }
    }
}