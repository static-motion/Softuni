using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectedAreasInAMatrix
{
    class Program
    {
        private static int _size; 
        private static bool[,] _visited;
        private static List<char>[] _graph;
        static void Main()
        {
            _size = int.Parse(Console.ReadLine());
            _graph = new List<char>[_size];
            SortedDictionary<char, int> components = new SortedDictionary<char, int>();
            ReadGraph(components);
            _visited = new bool[_size, _graph[0].Count];
            FindConnectedComponents(components);
            PrintAreas(components);
        }

        private static void PrintAreas(IDictionary<char, int> components)
        {
            Console.WriteLine($"Areas: {components.Values.Sum()}");
            foreach (var component in components)
            {
                Console.WriteLine($"Letter '{component.Key}' -> {component.Value}");
            }
        }

        private static void ReadGraph(IDictionary<char, int> components)
        {
            for (int i = 0; i < _size; i++)
            {
                string line = Console.ReadLine();
                _graph[i] = new List<char>(line.Length);
                foreach (char letter in line)
                {
                    if (!components.ContainsKey(letter))
                    {
                        components.Add(letter, 0);
                    }
                    _graph[i].Add(letter);
                }
            }
        }

        private static void FindConnectedComponents(IDictionary<char, int> components)
        {
            for (int i = 0; i < _size; i++)
            {
                int listSize = _graph[i].Count;
                for (int j = 0; j < listSize; j++)
                {
                    if (!_visited[i, j])
                    {
                        DFS(i, j, _graph[i][j]);
                        components[_graph[i][j]]++;
                    }
                }
            }
        }

        private static void DFS(int row, int col, char letter)
        {
            if (!IsAValidCell(row, col, letter) || _visited[row, col])
            {
                return;
            }
            _visited[row, col] = true;
            DFS(row - 1, col, letter);
            DFS(row + 1, col, letter);
            DFS(row, col - 1, letter);
            DFS(row, col + 1, letter);

        }

        private static bool IsAValidCell(int row, int col, char letter)
        {
            bool isInside = row >= 0 && row < _size && col >= 0 && col < _graph[row].Count;
            bool isAValidLetter = false;
            if (isInside)
            {
                isAValidLetter = _graph[row][col] == letter;
            }
            return isInside && isAValidLetter;
        }
    }
}
