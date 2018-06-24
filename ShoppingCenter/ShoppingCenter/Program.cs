using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCenter
{
    class Program
    {
        static void Main()
        {
            ShoppingCenter center = new ShoppingCenter();

            Type type = center.GetType();

            int numberOfCommands = int.Parse(Console.ReadLine());
            string commandLine = "";
            string methodName = "";
            string commandArguments = "";
            MethodInfo[] method;
            for (int i = 0; i < numberOfCommands; i++)
            {
                commandLine = Console.ReadLine();
                int whitespaceIndex = commandLine.IndexOf(" ");
                methodName = commandLine.Substring(0, whitespaceIndex);
                method = type.GetMethods();
                var restOfString = commandLine.Substring(whitespaceIndex + 1, commandLine.Length - whitespaceIndex - 1);
                object[] arguments = SplitArguments(restOfString);
                method.First(m => m.Name == methodName && m.GetParameters().Length == arguments.Length).Invoke(center, arguments);
            }
        }

        private static object[] SplitArguments(string restOfString)
        {
            List<string> splitList = restOfString.Split(';').ToList();
            object[] arguments = new object[splitList.Count];
            double price = 0;
            int indexer = 0;
            foreach (var item in splitList)
            {
                if (double.TryParse(item, out price))
                {
                    arguments[indexer] = price;
                }
                else
                {
                    arguments[indexer] = item;
                }
                indexer++;
            }
            return arguments;
        }
    }
}
