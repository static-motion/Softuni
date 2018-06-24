using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniStore.Models
{
    public class User
    {
        public User()
        {
            GamesList = new HashSet<Game>();
        }
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public HashSet<Game> GamesList { get; set; }

        public bool IsAdmin { get; set; }
    }
}
