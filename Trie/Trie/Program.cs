using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trie
{
    class Program
    {
        static void Main(string[] args)
        {
            Trie<string> trie = new Trie<string>();
            string pesho = "pesho";
            char[] peshoReverse = pesho.ToCharArray();
            Array.Reverse(peshoReverse);
            pesho = new string(peshoReverse);
            trie.Insert(pesho, pesho);
            foreach (var strink in trie.GetByPrefix("oh"))
            {
                peshoReverse = strink.ToCharArray();
                Array.Reverse(peshoReverse);
                pesho = new string(peshoReverse);
                Console.WriteLine(pesho);
            }
            
        }
    }
}
