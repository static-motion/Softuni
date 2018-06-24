using System;
using System.Linq;

namespace ReverseArray
{
    class Program
    {
        static void Main()
        {
            string[] arr = Console.ReadLine().Split(' ').ToArray();
            string[] reversed = new string[arr.Length];
            ReverseArray(arr, reversed, arr.Length - 1, 0);
        }

        private static void ReverseArray(string[] arr, string[] reversed, int length, int index)
        {
            if (length < 0)
            {
                Console.WriteLine(string.Join(" ", reversed));
                return;
            }

            reversed[index] = arr[length];
            ReverseArray(arr, reversed, length - 1, index + 1);
        }
    }
}
