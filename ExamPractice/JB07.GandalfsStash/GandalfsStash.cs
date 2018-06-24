using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class GandalfsStash
{
    static void Main()
    {
        int moodPoints = int.Parse(Console.ReadLine());
        string input = Console.ReadLine();
        MatchCollection foods = Regex.Matches(input, @"[a-zA-Z]+");
        foreach(Match food in foods)
        {
            switch(food.ToString().ToLower())
            {
                case "cram":
                    {
                        moodPoints += 2;
                        break;
                    }
                case "lembas":
                    {
                        moodPoints += 3;
                        break;
                    }
                case "apple":
                    {
                        moodPoints += 1;
                        break;
                    }
                case "melon":
                    {
                        moodPoints += 1;
                        break;
                    }
                case "honeycake":
                    {
                        moodPoints += 5;
                        break;
                    }
                case "mushrooms":
                    {
                        moodPoints += -10;
                        break;
                    }
                default:
                    {
                        moodPoints += -1;
                        break;
                    }
            }
            
        }
        string mood = String.Empty;
        if (moodPoints < -5)
        {
            mood = "Angry";
        }
        else if (moodPoints >= -5 && moodPoints < 0)
        {
            mood = "Sad";
        }
        else if (moodPoints >= 0 && moodPoints < 15)
        {
            mood = "Happy";
        }
        else
        {
            mood = "Special JavaScript mood";
        }
        Console.WriteLine(moodPoints);
        Console.WriteLine(mood);
    }
}

