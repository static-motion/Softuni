using System;
using System.Collections.Generic;
using System.Linq;

namespace Chain_Lightning
{
    class Program
    {
        private static int[][] graph;
        private static int[] damaged;
        private static bool[] visited;
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());
            int lightnings = int.Parse(Console.ReadLine());
            graph = new int[count][];
            damaged =new int[count];
            
            for (int i = 0; i < count; i++)
            {
                graph[i] = new int[count];
                for (int j = 0; j < count; j++)
                {
                    graph[i][j] = -1;
                }
            }
            for (int i = 0; i < edges; i++)
            {
                int[] adj = Console.ReadLine().Split().Select(int.Parse).ToArray();
                graph[adj[0]][adj[1]] = adj[2];
                graph[adj[1]][adj[0]] = adj[2];
            }
            for (int i = 0; i < lightnings; i++)
            {
                int[] lightning = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int nodeHit = lightning[0];
                int damage = lightning[1];
                CalculateDamage(nodeHit, damage, count);
            }
            Console.WriteLine(damaged.Max());
        }

        private static void CalculateDamage(int nodeHit, int damage, int count)
        {
            List<int> nodesHit = new List<int>(count);
            visited = new bool[count];
            visited[nodeHit] = true;
            nodesHit.Add(nodeHit);
            damaged[nodeHit] += damage;
            int[] currentDamage = new int[count];
            currentDamage[nodeHit] = damage;
            for (int k = 0; k < count - 1; k++)
            {
                int minimum = int.MaxValue;
                int nodeRow = -1;
                int nodeCol = -1;
                foreach (var node in nodesHit)
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (graph[node][i] < minimum && graph[node][i] != -1 && !visited[i])
                        {
                            minimum = graph[nodeHit][i];
                            nodeCol = i;
                            nodeRow = node;
                        }
                    }
                }
                if (minimum == int.MaxValue)
                {
                    continue;
                }
                damaged[nodeCol] += currentDamage[nodeRow] / 2;
                currentDamage[nodeCol] = currentDamage[nodeRow] / 2;
                visited[nodeCol] = true;
                nodesHit.Add(nodeCol);
            }
        }
    }
}
