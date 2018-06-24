using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaForum.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string SessionId { get; set; }

        public virtual User User { get; set; }

        public bool IsActive { get; set; }

    }
}
