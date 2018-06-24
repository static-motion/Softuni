using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class ReplaceTag
{
    //"<ul> <li> <a href="http://softuni.bg">SoftUni</a> </li> </ul>"

    static void Main()
    {
        string input = Console.ReadLine();
        input = input.Substring(1, input.Length - 2);
        string pattern = @"(<a.*href=[\"" |\''](.+)[\""|\']>(\w+)<\/a>)";
        Regex replacer = new Regex(pattern);
        string replace = @"[URL href=$2]$3[/URL]";
        input = replacer.Replace(input, replace);
        StringBuilder remove = new StringBuilder(input);
        Console.WriteLine(input);
    }
}

