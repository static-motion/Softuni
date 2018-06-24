using System;
using System.Linq;
using System.Numerics;

namespace Elections
{
    class Program
    {
        static void Main()
        {
            int minSeats =int.Parse(Console.ReadLine());
            int totalParties = int.Parse(Console.ReadLine());
            int[] seatsPerParty = new int[totalParties];
            for (int i = 0; i < totalParties; i++)
            {
                seatsPerParty[i] = int.Parse(Console.ReadLine());
            }
            BigInteger[] combinations = new BigInteger[seatsPerParty.Sum() + 1];
            combinations[0] = 1;
            foreach (int seatIndex in seatsPerParty)
            {
                for (int i = combinations.Length - 1; i >= 0; i--)
                {
                    if (combinations[i] != 0)
                    {
                        combinations[i + seatIndex] += combinations[i];
                    }
                }
            }
            BigInteger totalSum = 0;
            for (int i = minSeats; i < combinations.Length; i++)
            {
                totalSum += combinations[i];
            }
            Console.WriteLine(totalSum);
        }
    }
}
