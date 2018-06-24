using System;
using System.Collections.Generic;

namespace _02.CalculateSequence
{
    class Program
    {
        static void Main()
        {
            Queue<int> queue = new Queue<int>();
            int n = int.Parse(Console.ReadLine());
            int[] sequence = new int[50];
            queue.Enqueue(n);
            for (int i = 0; i < 50; i++)
            {
                queue.Enqueue(queue.Peek() + 1);
                queue.Enqueue(queue.Peek() * 2 + 1);
                queue.Enqueue(queue.Peek() + 2);
                sequence[i] = queue.Dequeue();
            }
            Console.WriteLine(string.Join(", ", sequence));
        }
    }
}
