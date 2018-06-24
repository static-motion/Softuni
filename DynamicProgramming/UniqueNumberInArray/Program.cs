using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace UniqueNumberInArray
{
    class Program
    {
        private static Random rng = new Random(1);

        public static void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        static void Main()
        {
            List<int> arr = new List<int>();
            int num = 0;
            for (int i = 0; i < 1000000; i++)
            {
                if (i % 10 == 0)
                {
                    num++;
                }
                arr.Add(num);
            }
            Shuffle(arr);
            arr[3] = 99999994;
            HashSet<int> unique = new HashSet<int>();
            HashSet<int> nonUnique = new HashSet<int>();
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            Stopwatch watch = Stopwatch.StartNew();
            int uniqueNum = XOR(arr);//Unique(arr, numbers);//FindUnique(arr, unique, nonUnique);
            Console.WriteLine(watch.Elapsed);
            Console.WriteLine(uniqueNum);
        }

        private static int XOR(List<int> arr)
        {
            int num = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                num ^= arr[i];
            }
            return num;
        }

        private static int Unique(List<int> arr, Dictionary<int, int> numbers)
        {

            foreach (var number in arr)
            {
                if (!numbers.ContainsKey(number))
                {
                    numbers.Add(number, 0);
                }
                numbers[number]++;
            }
            int unique = int.MinValue;
            foreach (var number in numbers)
            {
                if (number.Value == 1)
                {
                    unique = number.Key;
                    break;
                }
            }
            return unique;
        }

        private static int FindUnique(List<int> arr, HashSet<int> unique, HashSet<int> nonUnique)
        {
            foreach (var number in arr)
            {
                if (unique.Contains(number))
                {
                    unique.Remove(number);
                    nonUnique.Add(number);
                }
                if (!nonUnique.Contains(number))
                {
                    unique.Add(number);
                }
            }
            return unique.First();
        }
    }
}
