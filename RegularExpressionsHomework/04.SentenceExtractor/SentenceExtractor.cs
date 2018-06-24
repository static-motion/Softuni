using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class SentenceExtractor
{
    static void Main()
    {
        StringBuilder hasan = new StringBuilder(Console.ReadLine());
        //string word = Console.ReadLine();
        //string input = Console.ReadLine();
        //string pattern = String.Format(@"[A-Z][a-z\s\,\']+\b{0}\b[a-z\s\,\']+[\.|!|\?]", word);
        //MatchCollection sentences = Regex.Matches(input, pattern);
        //foreach(Match validSentence in sentences)
        //{
        //    Console.WriteLine("{0} ", validSentence.Groups[0]);
        //}
        Console.WriteLine(hasan);
    }
}

