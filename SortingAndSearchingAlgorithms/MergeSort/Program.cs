using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionCount
{

    class Program
    {
        static void Main()
        {
            int[] arr = {1, 5, 7, 3, 12};
            Mergesort<int>.Sort(arr);
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
