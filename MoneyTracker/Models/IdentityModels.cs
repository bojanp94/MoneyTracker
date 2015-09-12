using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;

namespace MoneyTracker.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        public virtual List<Entry> UserEntries { get; set; }
        public virtual UserData UserData { get; set; }
    }

    public class MoneyTrackerContext : IdentityDbContext<User>
    {
        public MoneyTrackerContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Entry> Entries { get; set; }
        public DbSet<UserData> UsersData { get; set; }
    }
}