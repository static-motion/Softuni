using PizzaForum.Models;

namespace PizzaForum.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PizzaForumContext : DbContext
    { 
        public PizzaForumContext()
            : base("PizzaForumContext")
        {
        }   
        
        public IDbSet<User> Users { get; set; }

        public IDbSet<Topic> Topics { get; set; }

        public IDbSet<Reply> Replies { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Session> Sessions { get; set; }
    }
}