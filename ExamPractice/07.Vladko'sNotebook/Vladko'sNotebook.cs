using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class VladkosNotebook
{
    static SortedDictionary<string, Dictionary<string, List<string>>> data = new SortedDictionary<string, Dictionary<string, List<string>>>();
    static void Main()
    {     
        string[] input = Console.ReadLine().Split('|');
        
        while (input[0] != "END")
        {
            if(!data.ContainsKey(input[0]))
            {
                data[input[0]] = new Dictionary<string, List<string>>();
            }
            if(!data[input[0]].ContainsKey(input[1]))
            {
                data[input[0]][input[1]] = new List<string>();
            }
            data[input[0]][input[1]].Add(input[2]);
            input = Console.ReadLine().Split('|');
        }
        CalculateWinLoss();
    }


    static void CalculateWinLoss()
    {
        int wins = 0;
        int losses = 0;
        int age = 0;
        string name = "";
        double rank;
        string sheetColor = String.Empty;
        List<string> opponents = new List<string>();
        foreach(var color in data)
        {
            foreach (var entry in color.Value)
            {
                sheetColor = entry.ToString();
                switch (entry.Key)
                {
                    case "win":
                        wins = entry.Value.Count;
                        opponents.AddRange(entry.Value);
                        break;
                    case "loss":
                        losses = entry.Value.Count;
                        opponents.AddRange(entry.Value);
                        break;
                    case "age":
                        age = int.Parse(entry.Value.ToString());
                        break;
                    case "name":
                        name = entry.Value.ToString();
                        break;
                }
            }
            opponents.Sort();
            rank = (1 + wins) / (1 + losses);
            if(age != 0 && name != "")
            {
                Console.WriteLine("Color: " + sheetColor);
                Console.WriteLine("-age: " + age);
                Console.WriteLine("-name " + name);
                if(opponents.Count == 0)
                {
                    Console.WriteLine("-opponents: " + String.Join(", ",opponents));
                }
                else
                {
                    Console.WriteLine("(empty)");
                }
                Console.WriteLine("-rank: " + rank);               
            }
            else
            {
                Console.WriteLine("No data recovered.");
            }
        }
        
    }
}

