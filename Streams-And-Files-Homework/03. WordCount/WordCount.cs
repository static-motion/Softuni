using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class WordCount
{
    static void Main()
    {
        using (var wordReader = new StreamReader(@"../../words.txt"))
        using (var textReader = new StreamReader(@"../../text.txt"))
        using (var textWriter = new StreamWriter(@"../../result.txt"))
        {
            StringBuilder text = new StringBuilder();
            string currentLine = textReader.ReadLine();
            while (currentLine != null)
            {
                text.Append(currentLine);
                currentLine = textReader.ReadLine();
            }

            string[] textWords = Regex.Matches(text.ToString(), @"[\w+\']+")
                .Cast<Match>()
                .Select(match => match.Value)
                .ToArray();

            string word = wordReader.ReadLine();
            Dictionary<string, int> matchCount = new Dictionary<string, int>();

            int wordCounter = 0;

            while(word != null)
            {
                foreach(var textWord in textWords)
                {
                    if(textWord.ToLower() == word.ToLower())
                    {
                        wordCounter++;
                    }
                }
                matchCount.Add(word, wordCounter);
                wordCounter = 0;
                word = wordReader.ReadLine();
            }
            var items = from pair in matchCount
                        orderby pair.Value descending
                        select pair;

            foreach(var keyValuePair in items)
            {
                textWriter.WriteLine("{0} - {1}", keyValuePair.Key, keyValuePair.Value);
            }
        }                   
    }
}

