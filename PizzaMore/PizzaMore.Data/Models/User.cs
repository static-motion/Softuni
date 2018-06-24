using System;
using System.Collections;
using System.Collections.Generic;

namespace PizzaMore.Data.Models
{
    public class User
    {
        public User(string email, string password)
        {
            Email = email;
            Password = password;
            this.Suggestions = new List<string>();
        }
        [Obsolete]
        public User()
        {
            
        }
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection Suggestions { get; set; }
    }
}