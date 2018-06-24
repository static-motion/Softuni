using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        var info = new Dictionary<string, Dictionary<string, int>>();
        string pattern = @"([a-zA-Z\s]+)\s@([a-zA-Z\s]+)\s(\d+)\s(\d+)";
        while (input != "End")
        {
            Match matches = Regex.Match(input, pattern);
            string venue = matches.Groups[2].Value;
            string singer = matches.Groups[1].Value;
            if(venue != "" && singer != "")
            {
                if (!info.ContainsKey(venue))
                {
                    info.Add(venue, new Dictionary<string, int>());
                }
                if (!info[venue].ContainsKey(singer))
                {
                    info[venue].Add(singer, 0);
                }
                info[venue][singer] += (int.Parse(matches.Groups[3].Value) * int.Parse(matches.Groups[4].Value));             
            }
            input = Console.ReadLine();
        }
        foreach (var singer in info)
        {
            Console.WriteLine("{0}", singer.Key);
            foreach (var item in singer.Value.OrderByDescending(i => i.Value))
            {
                Console.WriteLine("#  {0} -> {1}", item.Key, item.Value);
            }
        }
    }
}