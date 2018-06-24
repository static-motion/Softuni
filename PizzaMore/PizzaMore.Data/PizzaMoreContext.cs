using PizzaMore.Data.Models;

namespace PizzaMore.Data
{
    using System.Data.Entity;

    public class PizzaMoreContext : DbContext
    {
        public PizzaMoreContext()
            : base("PizzaMoreContext")
        {
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Session> Sessions { get; set; }

        public IDbSet<Pizza> Pizzas { get; set; }
    }
}