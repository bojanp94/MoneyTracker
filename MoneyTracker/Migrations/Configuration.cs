namespace MoneyTracker.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MoneyTracker.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MoneyTracker.Models.MoneyTrackerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MoneyTracker.Models.MoneyTrackerContext context)
        {
            MoneyTrackerContext ctx = new MoneyTrackerContext();
            ctx.Categories.AddOrUpdate(new Category { CategoryName = "Shopping", CreateDate = DateTime.Now });
            ctx.Categories.AddOrUpdate(new Category { CategoryName = "Food", CreateDate = DateTime.Now });
            ctx.Categories.AddOrUpdate(new Category { CategoryName = "Travel", CreateDate = DateTime.Now });

            ctx.SaveChanges();
            ctx.Dispose();

            if(!context.Users.Any(u => u.UserName == "Admin"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User { UserName = "Admin" };

                manager.Create(user, "123456");
            }
        }
    }
}
