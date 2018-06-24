using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SortWords
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> wordSequence = Console.ReadLine().Split(' ').ToList();
            wordSequence.Sort();
            Console.WriteLine(string.Join(" ", wordSequence));
        }
    }
}
