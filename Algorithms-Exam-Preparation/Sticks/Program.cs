using System;
using System.Collections.Generic;
using System.Linq;

namespace Sticks
{
    class Program
    {
        static void Main()
        {
            int sticks = int.Parse(Console.ReadLine());
            int stickPlacings = int.Parse(Console.ReadLine());
            Dictionary<int, HashSet<int>> reverseGraph = new Dictionary<int, HashSet<int>>();
            BuildGraphs(sticks, stickPlacings, reverseGraph);
            List<int> removed = RemoveOrphanNodes(reverseGraph);

            if (removed.Count < sticks)
            {
                Console.WriteLine("Cannot lift all sticks");
            }
            Console.WriteLine(string.Join(" ", removed));
        }

        private static List<int> RemoveOrphanNodes(Dictionary<int, HashSet<int>> reverseGraph)
        {
            var itemToRemove = reverseGraph
                            .Where(x => x.Value.Count == 0)
                            .OrderByDescending(x => x.Key)
                            .FirstOrDefault();

            List<int> removed = new List<int>();
            while (!itemToRemove.Equals(default(KeyValuePair<int, HashSet<int>>)))
            {
                reverseGraph.Remove(itemToRemove.Key);
                foreach (var node in reverseGraph)
                {
                    node.Value.Remove(itemToRemove.Key);
                }
                removed.Add(itemToRemove.Key);
                itemToRemove = reverseGraph
                    .Where(x => x.Value.Count == 0)
                    .OrderByDescending(x => x.Key)
                    .FirstOrDefault();
            }

            return removed;
        }

        private static void BuildGraphs(int sticks, int stickPlacings, Dictionary<int, HashSet<int>> reverseGraph)
        {
            for (int i = 0; i < sticks; i++)
            {
                reverseGraph.Add(i, new HashSet<int>());
            }
            for (int i = 0; i < stickPlacings; i++)
            {
                int[] connections = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                reverseGraph[connections[1]].Add(connections[0]);
            }
            
        }
    }
}
