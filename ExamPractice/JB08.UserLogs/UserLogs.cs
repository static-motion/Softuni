using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class UserLogs
{
    static void Main()
    {
        string input = Console.ReadLine();
        var logs = new SortedDictionary<string, Dictionary<string, List<char>>>();
        
        while (input != "end")
        {
            MatchCollection ipsAndUsernames = Regex.Matches(input, @"(?<=IP=)(\S+).*(?<=user=)(.+)");
            foreach (Match match in ipsAndUsernames)
            {
                string ip = match.Groups[1].Value;
                string username = match.Groups[2].Value;
                if (!logs.ContainsKey(username))
                {
                    logs.Add(username, new Dictionary<string, List<char>>());
                }
                if (!logs[username].ContainsKey(ip))
                {
                    logs[username].Add(ip, new List<char>());
                }
                logs[username][ip].Add('x');
            }
            input = Console.ReadLine();
        }
        List<string> ips = new List<string>();  
        foreach (var username in logs)
        {
            Console.WriteLine("{0}:", username.Key);
            foreach (var ip in username.Value)
            {
                ips.Add(string.Format("{0} => {1}", ip.Key, ip.Value.Count()));
            }
            Console.Write(String.Join(", ", ips) + ".");
            Console.WriteLine();
            ips.Clear();
        }
    }
}

