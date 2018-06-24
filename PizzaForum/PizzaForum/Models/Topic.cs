using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaForum.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual User Author { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public IList<Reply> Replies { get; set; }
    }
}
