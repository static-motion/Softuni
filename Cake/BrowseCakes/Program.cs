using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BrowseCakes
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Content-Type: text/html\r\n");
            string pageContent = File.ReadAllText("../htdocs/browsecakes.html");
            Console.WriteLine(pageContent);
            string[] searchQuery = Environment.GetEnvironmentVariable("QUERY_STRING").Split('=');
            string searchValue = WebUtility.UrlDecode(searchQuery[1]);
            string[] database = File.ReadAllLines("database.csv");
            foreach (var cake in database)
            {
                string cakeEntryName = cake.Split(',')[0];
                if (cakeEntryName.ToLower().Contains(searchValue.ToLower()))
                {
                    Console.WriteLine($"<p>{cakeEntryName.Replace("+"," ")}: ${cake.Split(',')[1]}</p>");
                }
            }
        }
    }
}
