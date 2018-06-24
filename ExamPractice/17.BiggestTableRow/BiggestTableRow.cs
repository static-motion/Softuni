using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _17.BiggestTableRow
{
    class BiggestTableRow
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"(?<=>)\d+\.\d+|(?<=>)\d+|(?<=>)-\d+\.\d+|(?<=>)-\d+";
            List<decimal> values = new List<decimal>();
            List<decimal> biggestValues = new List<decimal>();
            decimal biggestValue = decimal.MinValue;
            while(input != "</table>")
            {
                
                MatchCollection matches = Regex.Matches(input, pattern);
                foreach(Match match in matches)
                {
                    values.Add(decimal.Parse(match.ToString()));
                }
                if(values.Count != 0)
                {
                    if (values.Sum() > biggestValue)
                    {
                        biggestValues.Clear();
                        biggestValue = values.Sum();
                        biggestValues.AddRange(values);
                    }
                }
                
                values.Clear();
                input = Console.ReadLine();
            }
            if(biggestValues.Count != 0)
            {
                Console.WriteLine("{0} = {1}", double.Parse(biggestValue.ToString()), String.Join(" + ", biggestValues));
            }
            else
            {
                Console.WriteLine("no data");
            }
        }
    }
}
