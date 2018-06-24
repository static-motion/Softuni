using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exceptions_Class
{
    class Program
    {
        static void Main()
        {
            try
            {
                eException asd = new eException(null);
                Console.WriteLine(asd);
            }
            catch(Exception oe)
            {
                Console.WriteLine("Exception: " + oe.GetType());
            }
        }
    }
}
