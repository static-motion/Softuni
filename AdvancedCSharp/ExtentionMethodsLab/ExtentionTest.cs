using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtentionMethods
{
    public static class ExtentionTest
    {
        public static string Substring (this StringBuilder stringBuild, int startingIndex, int count)
        {
            string letters = stringBuild.Substring(startingIndex, count);
            return letters;
        }
    }
}
