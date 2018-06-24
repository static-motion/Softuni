using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TaskTwo
{
    class Program
    {
        static void Main()
        {
            string message = Console.ReadLine();
            int messageLength = int.Parse(Console.ReadLine());
            Regex validation = new Regex("^(\\d+)([a-zA-Z]+)([^a-zA-Z]*)$");                      
            while (message != "Over!")
            {
                StringBuilder verificationCode = new StringBuilder();
                Match match = validation.Match(message);
                string validMessage = "";
                if (match.Success)
                {                   
                    validMessage = match.Groups[2].ToString();
                    if (validMessage.Length == messageLength)
                    {
                        string digits = match.Groups[1].ToString() + match.Groups[3];
                        foreach (char c in digits)
                        {
                            if (c >= '0' && c <= '9')
                            {
                                int index = int.Parse(c.ToString());
                                try
                                {
                                    verificationCode.Append(validMessage[index]);
                                }
                                catch (Exception)
                                {
                                    verificationCode.Append(" ");
                                }                          
                            }
                        }
                        Console.Write(validMessage);
                        if (verificationCode.Length > 0)
                        {
                            Console.WriteLine(" == {0}", verificationCode);
                        }
                    }
                }              
                message = Console.ReadLine();
                int.TryParse(Console.ReadLine(), out messageLength);
            }
        }
    }
}
