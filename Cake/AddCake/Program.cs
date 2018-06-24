using System;
using System.IO;
using System.Net;
using System.Security.Policy;
using System.Web;

namespace AddCake
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Content-Type: text/html\r\n");
            string pageContent = File.ReadAllText(".../htdocs/addcake.html");
            Console.WriteLine(pageContent);
            string[] postContent = Console.ReadLine().Split('&');
            string cakeName = postContent[0].Split('=')[1];
            string cakePrice = postContent[1].Split('=')[1];
            if (!string.IsNullOrEmpty(cakeName) && !string.IsNullOrEmpty(cakePrice))
            {                
                File.AppendAllText("database.csv", $"{cakeName},{cakePrice}\r\n");
                Console.WriteLine($"<span>name:{WebUtility.UrlDecode(cakeName)}</span><br>");
                Console.WriteLine($"<span>price:{cakePrice}</span>");
            }            
        }
    }
}
