using System;
using System.Linq;

namespace DividingPresents
{
    class Program
    {
        private static int[] _presents;
        private static int[] _sums;
        static void Main()
        {
            int total = GetInputData();
            _sums[0] = 0;
            GetPossibleSums(total);
            int half = total / 2;
            int bob = 0;
            int alan = 0;
            for (int i = half; i >= 0; i--)
            {
                if (_sums[i] != -1)
                {
                    bob = total - i;
                    alan = i;
                    break;
                }
            }
            PrintOutput(alan, bob);
        }

        private static int GetInputData()
        {
            _presents = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int total = _presents.Sum();
            _sums = new int[total + 1];
            for (int i = 0; i < _sums.Length; i++)
            {
                _sums[i] = -1;
            }

            return total;
        }

        private static void GetPossibleSums(int total)
        {
            for (int index = 0; index < _presents.Length; index++)
            {
                for (int i = total; i >= 0; i--)
                {
                    if (_sums[i] != -1)
                    {
                        if (_sums[i + _presents[index]] == -1)
                        {
                            _sums[i + _presents[index]] = index;
                        }
                    }
                }
            }
        }

        static void PrintOutput(int alan, int bob)
        {
            int sum = alan;
            Console.WriteLine($"Difference: {bob - alan}");
            Console.WriteLine($"Alan:{alan} Bob:{bob}");
            Console.Write("Alan takes: ");
            while (sum > 0)
            {
                int index = _sums[sum];
                
                Console.Write($"{_presents[index]} ");
                sum -= _presents[index];
            }
            Console.WriteLine();
            Console.WriteLine("Bob takes the rest.");
        }
    }
}