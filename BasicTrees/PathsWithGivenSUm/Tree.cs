using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootNode
{
    class Tree<T>
    {
        public T Value { get; set; }
        public IList<Tree<T>> Children { get; private set; }
        public Tree<T> ParentNode { get; private set; }
        private static int LongestPathDepth = 0;
        private static T DeepestNode;
        private static int CurrentPathDepth;
        public Tree(T value, params Tree<T>[] children)
        {
            this.Value = value;
            this.Children = new List<Tree<T>>();

            foreach (var child in children)
            {
                this.Children.Add(child);
            }
        }

        public void SetParent(Tree<T> parentNode)
        {
            this.ParentNode = parentNode;
        }

        public void Print(int indentation = 0)
        {
            
            Console.Write(new string(' ', indentation * 2));
            Console.WriteLine(this.Value);
            foreach (var child in this.Children)
            {
                child.Print(indentation + 1);
            }
        }
        public IEnumerable<T> GetLeaves()
        {
            var resultList = new List<T>();
            this.GetLeavesDFS(this, resultList);

            return resultList;
        }

        private void GetLeavesDFS(Tree<T> tree, List<T> resultList)
        {
            foreach (var child in tree.Children)
            {
                this.GetLeavesDFS(child, resultList);
            }
            if (tree.Children.Count == 0)
            {
                resultList.Add(tree.Value);
            }            
        }

        public IEnumerable<T> GetLongestPath()
        {
            var resultList = new List<T>();
            this.GetLongestPathDFS(this, resultList);

            return resultList;
        }

        private void GetLongestPathDFS(Tree<T> tree, List<T> resultList)
        {
            foreach (var child in tree.Children)
            {
                if (tree.Children.Count > 0)
                {
                    CurrentPathDepth++;
                }
                if (CurrentPathDepth > LongestPathDepth)
                {
                    LongestPathDepth = CurrentPathDepth;
                    DeepestNode = child.Value;
                    if (resultList.Count > 0)
                    {
                        resultList.RemoveAt(resultList.Count - 1);
                    }       
                    resultList.Add(child.ParentNode.Value);
                    resultList.Add(DeepestNode);
                }
                this.GetLongestPathDFS(child, resultList);
            }
            CurrentPathDepth--;
        }
    }
}
