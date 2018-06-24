using System;
using System.Collections.Generic;
using System.Linq;

namespace RootNode
{
    class Program
    {
        private static Dictionary<int, Tree<int>> nodes = new Dictionary<int, Tree<int>>();

        static void Main()
        {
            ReadTree();
            var root = nodes.Values.First(a => a.ParentNode == null);
            //Console.WriteLine("Deepest node: " + root.GetLongestPath().Last());
            Console.WriteLine("Longest path: " + string.Join(" ", root.GetLongestPath()));
            
        }

        private static void ReadTree()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < nodesCount - 1; i++)
            {
                var nodePair = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                Tree<int> parent = GetNode(nodePair[0]);

                Tree<int> child = GetNode(nodePair[1]);
                parent.Children.Add(child);
                child.SetParent(parent);
            }
        }

        private static Tree<int> GetNode(int value)
        {
            if (!nodes.ContainsKey(value))
            {
                nodes[value] = new Tree<int>(value);
            }
            return nodes[value];
        }

        private static void PrintLeafNodes(Tree<int> rootNode)
        {
            var leaves = rootNode.GetLeaves().OrderBy(a => a);
            Console.WriteLine("Leaf nodes: " + string.Join(" ", leaves));
        }

        static void PrintMiddleNodes()
        {
            var nodes = Program.nodes.Values
                .Where(x => x.ParentNode != null && x.Children.Count > 0)
                .Select(x => x.Value)
                .OrderBy(x => x)
                .ToList();

            Console.WriteLine("Middle nodes: " + string.Join(" ", nodes));
        }
    }
}
