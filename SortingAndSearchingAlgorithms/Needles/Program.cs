using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Needles
{
    class Program
    {
        static void Main()
        {
            int[] initialInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            List<int> indexes = new List<int>();
            List<int> sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int lastIndex = sequence.Count;
            bool didNotInsert = true;
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] < sequence[0])
                {
                    indexes.Add(0);
                    continue;
                }
                for (int j = 0; j < sequence.Count; j++)
                {
                    if (nums[i] > sequence[j])
                    {
                        if (sequence[j] == 0)
                        {
                            int k = FindNextNonZeroIndex(j, sequence);
                            if (k != -1)
                            {
                                if (sequence[k] >= nums[i])
                                {
                                    indexes.Add(j);
                                    didNotInsert = false;
                                    break;
                                }
                                j = k;
                            }
                        }
                        continue;
                    }
                    indexes.Add(j);
                    didNotInsert = false;
                    break;
                }
                if (didNotInsert)
                {
                    indexes.Add(lastIndex++);
                    didNotInsert = false;
                }
            }
            Console.WriteLine(string.Join(" ", indexes));
        }

        private static int FindNextNonZeroIndex(int i, List<int> sequence)
        {
            for (int j = i; j < sequence.Count; j++)
            {
                if(sequence[j] == 0)
                    continue;
                return j;

            }
            return -1;
        }
    }
}
