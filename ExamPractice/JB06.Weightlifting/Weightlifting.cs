using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Weightlifting
{
    static void Main()
    {
        var info = new SortedDictionary<string, SortedDictionary<string, List<long>>>();
        string input = Console.ReadLine();
        int lines;
        try
        {
            lines = int.Parse(input);
        }
        catch(SystemException)
        {
            lines = char.Parse(input);
        }
        
        
        
        for (int i = 0; i < lines; i++)
        {
            string[] lifters = Console.ReadLine().Split(' ');
            if (!info.ContainsKey(lifters[0]))
            {
                info.Add(lifters[0], new SortedDictionary<string, List<long>>());
            }
            if (!info[lifters[0]].ContainsKey(lifters[1]))
            {
                info[lifters[0]].Add(lifters[1], new List<long>());
            }
            info[lifters[0]][lifters[1]].Add(int.Parse(lifters[2]));
        }
        List<string> asdf = new List<string>();
        foreach(var lifter in info)
        {
            Console.Write("{0} : ", lifter.Key);
            foreach (var exercise in lifter.Value)
            {
                asdf.Add(String.Format("{0} - {1} kg", exercise.Key, exercise.Value.Sum()));
            }
            Console.Write(string.Join(", ", asdf));
            asdf.Clear();
            Console.WriteLine();
        }
    }
}

