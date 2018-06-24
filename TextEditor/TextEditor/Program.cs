using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TextEditor
{
    class Program
    {
        static void Main()
        {
            TextEditor editor = new TextEditor();
            List<string> inputData = new List<string>();
            inputData = Console.ReadLine().Split(' ').ToList();
            Type classType = editor.GetType();
            MethodInfo method;
            while (inputData[0] != "end")
            {
                string methodName = GetMethodName(ref inputData);
                
                if (methodName == "print")
                {
                    Console.WriteLine(editor.Print(inputData[0]));
                }
                else if (methodName == "length")
                {
                    Console.WriteLine(editor.Length(inputData[0]));
                }
                else
                {
                    object[] methodParams = ExtractMethodParameters(inputData);
                    method = classType.GetMethod(methodName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    method.Invoke(editor, methodParams);
                }
                inputData = Console.ReadLine().Split(' ').ToList();
            }
        }

        private static string GetMethodName(ref List<string> inputData)
        {
            string methodName;
            if (inputData[0] == "login" || inputData[0] == "logout")
            {
                methodName = inputData[0];
                inputData.RemoveAt(0);
            }
            else
            {
                methodName = inputData[1];
                inputData.RemoveAt(1);
            }
            return methodName;
        }


        private static object[] ExtractMethodParameters(List<string> inputData)
        {
            object[] methodParams = new object[inputData.Count];
            for (int i = 0; i < inputData.Count; i++)
            {
                int num;
                bool parsed = int.TryParse(inputData[i], out num);
                if (parsed)
                {
                    methodParams[i] = num;
                }
                else
                {
                    methodParams[i] = inputData[i];
                }
            }
            return methodParams;
        }
    }
}
