using System;
using System.IO;

class OddLines
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        using (var reader = new StreamReader(@"../../ReadMe.txt"))
        {
            int counter = 0;
            string line = reader.ReadLine();
            while (line != null)
            {
                if (counter % 2 != 0)
                {
                    Console.WriteLine(line);
                }
                counter++;
                line = reader.ReadLine();
            }
        }
    }
}

