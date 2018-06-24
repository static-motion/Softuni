using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        private static Dictionary<int, List<int>> _graph;
        static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            int pairsCount = int.Parse(Console.ReadLine());
            _graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < nodesCount; i++)
            {
                string[] input = Console.ReadLine().Split(':');
                int node = int.Parse(input[0]);
                string children = input[1];
                if (!_graph.ContainsKey(node))
                {
                    _graph[node] = new List<int>();
                }
                if (!string.IsNullOrEmpty(children))
                {
                    _graph[node].AddRange(children.Split(' ').Select(int.Parse).ToList());
                }
                
            }
            for (int i = 0; i < pairsCount; i++)
            {
                string[] pair = Console.ReadLine().Split('-').ToArray();
                int start = int.Parse(pair[0]);
                int end = int.Parse(pair[1]);
                int distance = BFS(start, end);
                Console.WriteLine($"{{{start}, {end}}} -> {distance}");
            }
        }

        private static int BFS(int start, int end)
        {
            Queue<int> nodes = new Queue<int>();
            Dictionary<int, int> distance = new Dictionary<int, int>();
            nodes.Enqueue(start);
            foreach (var node in _graph)
            {
                distance[node.Key] = -1;
            }
            distance[start] = 0;
            while (nodes.Count > 0)
            {
                int current = nodes.Dequeue();
                foreach (var node in _graph[current])
                {
                    
                    if (distance[node] == -1)
                    {
                        distance[node] = distance[current] + 1;
                        if (node == end)
                        {
                            return distance[node];
                        }
                        nodes.Enqueue(node);
                    }
                }
            }
            return distance[end];
        }
    }
}