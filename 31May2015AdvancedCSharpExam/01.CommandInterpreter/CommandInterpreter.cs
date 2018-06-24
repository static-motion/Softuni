using System;
using System.Collections.Generic;
using System.Linq;

class CommandInterpreter
{
    static List<string> input = Console.ReadLine().Split(new[] { @"\s+", " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
    static void Main()
    {
        
        List<string> commands = Console.ReadLine().Split(' ').ToList();
        while(commands[0] != "end")
        {
            switch (commands[0])
            {
                case "reverse": ReverseOrSort(commands);
                    break;

                case "sort": ReverseOrSort(commands);
                    break;

                case "rollLeft": Roll(commands);
                    break;

                case "rollRight": Roll(commands);
                    break;
            }
            commands = Console.ReadLine().Split(' ').ToList();
        }
        Console.WriteLine("[" + String.Join(", ", input) + "]");
    }
    static void ReverseOrSort(List<string> commands)
    {
        int start;
        int count;
        if (commands.Count == 5 
            && int.Parse(commands[2]) >= 0 
            && int.Parse(commands[4]) > 0
            && int.Parse(commands[2]) + int.Parse(commands[4]) <= input.Count)
        {
            start = int.Parse(commands[2]);
            count = int.Parse(commands[4]);
        }
        else
        {
            Console.WriteLine("Invalid input parameters.");
            return;
        }
        if(commands[0] == "reverse")
        {
            input.Reverse(start, count);
        }
        else
        {
            input.Sort(start, count, StringComparer.InvariantCulture);
        }               
    }
    static void Roll(List<string> commands)
    {
        int count;
        if(int.Parse(commands[1]) > 0)
        {
            count = int.Parse(commands[1]) % input.Count;
        }
        else
        {
            Console.WriteLine("Invalid input parameters.");
            return;
        }
        if(commands[0] == "rollLeft")
        {
            for (int i = 0; i < count; i++)
            {
                input.Insert(input.Count, input[0]);
                input.RemoveAt(0);
            }
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                input.Insert(0, input[input.Count - 1]);
                input.RemoveAt(input.Count - 1);
            }        
        }      
    }
}

