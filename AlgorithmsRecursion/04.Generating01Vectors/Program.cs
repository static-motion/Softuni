using System;

namespace _04.Generating01Vectors
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] vectorArray = new int[n];
            GenerateVector(0, vectorArray);
        }

        private static void GenerateVector(int i, int[] vectorArray)
        {
            if (i > vectorArray.Length - 1)
            {
                Print(vectorArray);
            }
            else
            {
                vectorArray[i] = 0;
                GenerateVector(i + 1, vectorArray);

                vectorArray[i] = 1;
                GenerateVector(i + 1, vectorArray);
            }
        }

        private static void Print(int[] arrayToPrint)
        {
            Console.WriteLine(string.Join("", arrayToPrint));
        }
    }
}
