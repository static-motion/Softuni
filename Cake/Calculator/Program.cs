using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Content-Type: text/html\r\n");
            string pageContent = File.ReadAllText("../htdocs/calculator.html");
            Console.WriteLine(pageContent);
            string[] queryData = Console.ReadLine().Split('&');

            long firstNumber = 0;
            long secondNumber = 0;
            long result = 0;
            bool validSign = true;

            try
            {
                firstNumber = long.Parse(queryData[0].Split('=')[1]);
                secondNumber = long.Parse(queryData[2].Split('=')[1]);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number entered in the form!");
            }

            string sign = WebUtility.UrlDecode(queryData[1].Split('=')[1]);

            switch (sign)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    result = firstNumber / secondNumber;
                    break;
                default:
                    Console.WriteLine("Invalid Sign!");
                    validSign = false;
                    break;
            }

            if(validSign)
                Console.WriteLine($"Result: {result:##.###}");
        }
    }
}
