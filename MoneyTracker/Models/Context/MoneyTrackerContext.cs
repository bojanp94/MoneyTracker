using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MoneyTracker.Models
{
    public class MoneyTrackerContext : IdentityDbContext<User>
    {
        public MoneyTrackerContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Entry> Entries { get; set; }
        public DbSet<UserData> UsersData { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Gender> Genders { get; set; }
    }
}