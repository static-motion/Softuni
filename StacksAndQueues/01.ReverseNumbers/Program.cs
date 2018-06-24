using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ReverseNumbers
{
    class Program
    {
        static void Main()
        {
            Stack<int> sequence = new Stack<int>();
            Console.ReadLine().Split(' ').ToList().ForEach(a => sequence.Push(int.Parse(a)));
            int stackSize = sequence.Count;
            for (int i = 0; i < stackSize; i++)
            {
                Console.Write(sequence.Pop() + " ");
            }

        }
    }
}
