using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Content-Type: text/html\r\n");
            string pageContent = File.ReadAllText("../htdocs/login.html");
            Console.WriteLine(pageContent);
            string[] loginInfo = Console.ReadLine().Split('&');
            string username = loginInfo[0].Split('=')[1];
            string password = loginInfo[1].Split('=')[1];
            Console.WriteLine($"Hi {username}, your password is {password}");
        }
    }
}
