using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaForum.Models
{
    public class User
    {
        public User()
        {
            this.Topics = new HashSet<Topic>();
        }

        public int Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public virtual HashSet<Topic> Topics { get; set; }

        public bool IsAdmin { get; set; }
    }
}
