using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfCoins
{
    class SumOfCoins        
    {
        static void Main()
        {
            List<int> usedCoins = new List<int>();
            int[] coins = {10, 5, 2};
            int target = 18;
            int sum = 0;
            int index = 0;
            while (sum != target)
            {
                if (sum + coins[index] <= target)
                {
                    sum += coins[index];
                    usedCoins.Add(coins[index]);
                }
                else
                {
                    index++;
                    if (index > coins.Length - 1)
                    {
                        Console.WriteLine("No combination found");
                        break;
                    }
                }
            }
            Console.WriteLine(string.Join(" ", usedCoins));
        }
    }
}
