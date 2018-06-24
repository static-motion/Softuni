using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaForum.Data
{
    public class Data
    {
        private static PizzaForumContext context;

        public static PizzaForumContext Context
        {
            get { return context ?? (context = new PizzaForumContext()); }
        }
    }
}
