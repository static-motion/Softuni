using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SchoolSystem
{
    static void Main()
    {
        int lineCount = int.Parse(Console.ReadLine());
        var data = new SortedDictionary<string, SortedDictionary<string, List<double>>>();
        for (int i = 0; i < lineCount; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            string name = input[0] + " " + input[1];
            string subject = input[2];
            int score = int.Parse(input[3]);
            if(!data.ContainsKey(name))
            {
                data.Add(name, new SortedDictionary<string, List<double>>());
            }
            if(!data[name].ContainsKey(subject))
            {
                data[name].Add(subject, new List<double>());
            }
            data[name][subject].Add(score);
        }
        List<string> values = new List<string>();         
        foreach(var student in data)
        {
            Console.Write("{0}: ", student.Key);
            foreach(var subject in student.Value)
            {
                values.Add(String.Format("{0} - {1:f2}", subject.Key, subject.Value.Average()));                             
            }
            Console.WriteLine("[" + String.Join(", ", values) + "]");
            values.Clear();
        }
    }
}

