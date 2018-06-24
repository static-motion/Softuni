using System;
using System.IO;

namespace Cake
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Content-Type: text/html; charset=utf-8\r\n");
            string htmlContent = File.ReadAllText("../htdocs/index.html");
            Console.WriteLine(htmlContent);
        }
    }
}
