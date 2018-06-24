using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaForum.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IList<Topic> Topics { get; set; }
    }
}
