using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumTaskAssignment
{
    class Program
    {
        private static bool[] visited;
        private static int[][] graph;
        private static int[] path;
        static void Main()
        {
            int persons = int.Parse(Console.ReadLine().Split(' ')[1]);
            int tasks = int.Parse(Console.ReadLine().Split(' ')[1]);
            BuildGraph(persons, tasks);
            path = new int[graph.Length];
            for (int i = 0; i < path.Length; i++)
            {
                path[i] = -1;
            }
            int start = 0;
            int end = graph.Length - 1;
            Dictionary<char, int> completedTasks = new Dictionary<char, int>();
            while (BFS(start, end))
            {
                int currentVertex = end;
                int previousVertex = path[currentVertex];
                graph[previousVertex][currentVertex] = 0;
                int task = previousVertex - tasks + 1;
                currentVertex = previousVertex;
                previousVertex = path[currentVertex];
                graph[previousVertex][currentVertex] = 0;
                char worker = (char) (previousVertex + '@');
                currentVertex = previousVertex;
                previousVertex = path[currentVertex];
                graph[previousVertex][currentVertex] = 0;
                completedTasks.Add(worker, task);
            }
            foreach (var task in completedTasks.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{task.Key}-{task.Value}");
            }
        }

        private static void BuildGraph(int persons, int tasks)
         {
            int size = persons + tasks + 2;
            graph = new int[size][];
            for (int i = 0; i < size; i++)
            {
                graph[i] = new int[size];
            }
            for (int i = 1; i <= persons; i++)
            {
                graph[0][i] = 1;
            }
            for (int i = tasks; i <= size - 1; i++)
            {
                graph[i][size - 1] = 1;
            }
            for (int person = 1; person <= persons; person++)
            {
                string line = Console.ReadLine();
                for (int task = tasks, i = 0; i < line.Length; task++, i++)
                {
                    if (line[i] == 'Y')
                    {
                        graph[person][task] = 1;
                    }
                }
            }
        }

        private static bool BFS(int start, int end)
        {
            visited = new bool[graph.Length];
            Queue<int> vertices = new Queue<int>();
            vertices.Enqueue(start);
            while (vertices.Count > 0)
            {
                int currentVertex = vertices.Dequeue();
                visited[currentVertex] = true;
                for (int i = 0; i < graph[currentVertex].Length; i++)
                {
                    if (graph[currentVertex][i] != 0)
                    {
                        vertices.Enqueue(i);
                        path[i] = currentVertex;
                    }
                    if (visited[end])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
