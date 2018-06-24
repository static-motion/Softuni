using System;
using System.Collections.Generic;
using System.Linq;

namespace Robbery
{
    class Edge
    {
        public Edge(int to, int weight)
        {
            To = to;
            Weight = weight;
        }
        public int To { get; set; }
        public int Weight { get; set; }

        public override string ToString()
        {
            return $"{To}, {Weight}";
        }
    }
    class Program
    {
        private const bool White = true;
        private static bool[] colors;
        private static int[] distTo;
        private static int[] stepsTo;
        private static bool[] visited;

        static void Main()
        {
            string[] inputNodes = Console.ReadLine().Split(' ');
            colors = new bool[inputNodes.Length];
            for (int i = 0; i < inputNodes.Length; i++)
            {
                colors[i] = inputNodes[i][inputNodes[i].Length - 1] == 'w';
            }
            int energy = int.Parse(Console.ReadLine());
            int waitCost = int.Parse(Console.ReadLine());
            int startNode = int.Parse(Console.ReadLine());
            int endNode = int.Parse(Console.ReadLine());
            int edgeCount = int.Parse(Console.ReadLine());
            List<Edge>[] graph = new List<Edge>[inputNodes.Length];
            distTo = new int[graph.Length];
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<Edge>();
                distTo[i] = -1;
            }
            stepsTo = new int[graph.Length];
            visited = new bool[graph.Length];
            for (int i = 0; i < edgeCount; i++)
            {
                int[] edge = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var from = edge[0];
                var to = edge[1];
                var weight = edge[2];
                graph[from].Add(new Edge(to, weight));
            }

            Dijkstra(graph, startNode, endNode, waitCost);
        }

        private static void Dijkstra(List<Edge>[] graph, int startNode, int endNode, int waitCost)
        {
            distTo[startNode] = 0;

            while (true)
            {
                int vertex = GetCurrentVertex();

                if(vertex == -1) { break;}

                Visit(graph, vertex, waitCost);
            }
        }

        private static void Visit(List<Edge>[] graph, int vertex, int waitCost)
        {
            visited[vertex] = true;
            foreach (var edge in graph[vertex])
            {
                int steps = stepsTo[vertex] + 1;
                bool color = steps % 2 == 0 ? colors[edge.To] : !colors[edge.To];

            }
        }

        private static int GetCurrentVertex()
        {
            int index = -1;
            int lowestDist = int.MaxValue;
            for (int i = 0; i < distTo.Length; i++)
            {
                if (!visited[i] && distTo[i] < lowestDist)
                {
                    index = i;
                    lowestDist = distTo[i];
                }
            }
            return index;
        }
    }
}
