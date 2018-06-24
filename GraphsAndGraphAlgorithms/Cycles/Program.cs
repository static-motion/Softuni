using System;
using System.Collections.Generic;
using System.Linq;

namespace Cycles
{
    class Program
    {
        private static Dictionary<string, List<string>> _graph = new Dictionary<string, List<string>>();
        private static Dictionary<string, int> _predecessorCount;

        static void Main()
        {
            ReadGraph();
            GetPredecessorCount();
            Console.Write("Acyclic: ");
            Console.WriteLine(CheckIfAcyclic() ? "Yes" : "No");
        }

        private static void ReadGraph()
        {
            _predecessorCount = new Dictionary<string, int>();
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                string[] args = line.Split('–').ToArray();
                string node = args[0];
                string successor = args[1];
                if (!_graph.ContainsKey(node))
                {
                    _graph.Add(node, new List<string>());
                }
                if (!_graph.ContainsKey(successor))
                {
                    _graph.Add(successor, new List<string>());
                }
                _graph[node].Add(successor);
                _graph[successor].Add(node);
            }
        }

        private static bool CheckIfAcyclic()
        {
            GetPredecessorCount();
            var nodeToRemove = _predecessorCount.FirstOrDefault(x => x.Value == 1 || x.Value == 0);
            while (!nodeToRemove.Equals(default(KeyValuePair<string, int>)))
            {
                foreach (var node in _graph[nodeToRemove.Key])
                {
                    if(_predecessorCount.ContainsKey(node))
                        _predecessorCount[node]--;
                }
                _predecessorCount.Remove(nodeToRemove.Key);
                nodeToRemove = _predecessorCount.FirstOrDefault(x => x.Value == 1 || x.Value == 0);
            }
            return _predecessorCount.Count == 0;
        }
        private static void GetPredecessorCount()
        {
            _predecessorCount = new Dictionary<string, int>();
            foreach (var node in _graph)
            {
                if (!_predecessorCount.ContainsKey(node.Key))
                {
                    _predecessorCount.Add(node.Key, 0);
                }
                foreach (var child in node.Value)
                {
                    if (!_predecessorCount.ContainsKey(child))
                    {
                        _predecessorCount.Add(child, 0);
                    }
                    _predecessorCount[child]++;
                }
            }
        }
    }
}
