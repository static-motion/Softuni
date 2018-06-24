using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CubicAssault
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            var regions = new Dictionary<string, Dictionary<string, long>>();
            string pattern = "([\\w\\s]+) -> (\\w+) -> ([\\d\\-]+)";
            while (input != "Count em all")
            {
                Match match = Regex.Match(input, pattern);
                string region = match.Groups[1].Value;
                string meteorType = match.Groups[2].Value;
                long count = long.Parse(match.Groups[3].Value);
                if (!regions.ContainsKey(region))
                {
                    regions.Add(region, new Dictionary<string, long>());
                    regions[region].Add("Black", 0);
                    regions[region].Add("Red", 0);
                    regions[region].Add("Green", 0);
                }
                regions[region][meteorType] += count;
                long currentRegionGreens = regions[region]["Green"];

                if (currentRegionGreens >= 1000000)
                {
                    long combinedCount = currentRegionGreens / 1000000;
                    regions[region]["Green"] %= 1000000;
                    regions[region]["Red"] += combinedCount;
                }
                long currentRegionReds = regions[region]["Red"];
                if (currentRegionReds >= 1000000)
                {
                    long combinedCountRed = currentRegionReds / 1000000;
                    regions[region]["Red"] %= 1000000;
                    regions[region]["Black"] += combinedCountRed;
                }
                input = Console.ReadLine();
            }
            foreach (var region in regions)
            {
                long currentRegionGreens = regions[region.Key]["Green"];
                
                if (currentRegionGreens >= 1000000)
                {
                    long combinedCount = currentRegionGreens / 1000000;
                    regions[region.Key]["Green"] %= 1000000;
                    regions[region.Key]["Red"] += combinedCount;
                }
                long currentRegionReds = regions[region.Key]["Red"];
                if (currentRegionReds >= 1000000)
                {
                    long combinedCountRed = currentRegionReds / 1000000;
                    regions[region.Key]["Red"] %= 1000000;
                    regions[region.Key]["Black"] += combinedCountRed;
                }        
            }
            foreach (var region in regions.OrderByDescending(i => i.Value["Black"])
                .ThenBy(i => i.Key.Length)
                .ThenBy(i => i.Key))
            {
                Console.WriteLine(region.Key);
                foreach (var meteor in region.Value.OrderByDescending(i => i.Value)
                    .ThenBy(i => i.Key))
                {
                    Console.Write("-> {0} : {1}\n", meteor.Key, meteor.Value);
                }   
            }            
        }
    }
}
