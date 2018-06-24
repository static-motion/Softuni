using SoftUniStore.Models;

namespace SoftUniStore.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SoftUniStoreContext : DbContext
    {
        public SoftUniStoreContext()
            : base("SoftUniStoreContext")
        {
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Game> Games { get; set; }

        public IDbSet<Login> Logins { get; set; }
    }
}