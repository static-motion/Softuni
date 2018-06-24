using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_3
{
    class Program
    {
        static void Main()
        {
            int junctions = int.Parse(Console.ReadLine());
            int streetsCount = int.Parse(Console.ReadLine());
            int start = int.Parse(Console.ReadLine());
            List<int>[] graph = new List<int>[junctions];
            for (int i = 0; i < streetsCount; i++)
            {
                int[] line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (graph[line[0]] == null)
                {
                    graph[line[0]] = new List<int>();
                }
                if (graph[line[1]] == null)
                {
                    graph[line[1]] = new List<int>();
                }
                graph[line[0]].Add(line[1]);
            }
            Queue<int> bfsQueue = new Queue<int>();
            foreach (var node in graph[start])
            {
                bfsQueue.Enqueue(node);
            }
            int reachable = 1;
            bfsQueue.Enqueue(-1);
            int depth = 1;
            bool cycled = false;
            while (bfsQueue.Count > 0)
            {
                int node = bfsQueue.Dequeue();
                if (node == -1)
                {
                    depth++;
                    bfsQueue.Enqueue(-1);
                    if (bfsQueue.Peek() == -1) { break;}
                    continue;
                }
                if (node == start)
                {
                    cycled = true;
                    break;
                }
                reachable++;
                foreach (var child in graph[node])
                {
                   bfsQueue.Enqueue(child);
                }
            }
            Console.WriteLine(cycled ? depth : reachable);
        }
    }
}
