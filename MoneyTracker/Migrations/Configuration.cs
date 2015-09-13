namespace MoneyTracker.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MoneyTracker.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MoneyTracker.Models.MoneyTrackerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MoneyTracker.Models.MoneyTrackerContext context)
        {
            //add categories
            MoneyTrackerContext ctx = new MoneyTrackerContext();
            ctx.Categories.AddOrUpdate(x => x.CategoryName, new Category { CategoryName = "Shopping", CreateDate = DateTime.Now });
            ctx.Categories.AddOrUpdate(x => x.CategoryName, new Category { CategoryName = "Food", CreateDate = DateTime.Now });
            ctx.Categories.AddOrUpdate(x => x.CategoryName, new Category { CategoryName = "Travel", CreateDate = DateTime.Now });

            //add Genders
            ctx.Genders.AddOrUpdate(x => x.GenderName, new Gender { GenderName = "Male" });
            ctx.Genders.AddOrUpdate(x => x.GenderName, new Gender { GenderName = "Female" });
            ctx.Genders.AddOrUpdate(x => x.GenderName, new Gender { GenderName = "Unknown" });

            //add Currencies
              foreach (CultureInfo cultureInfo in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
              {
                  RegionInfo regionInfo = new RegionInfo(cultureInfo.LCID);
                  if (ctx.Currencies.Find(regionInfo.CurrencyEnglishName) == null)
                  {
                      ctx.Currencies.AddOrUpdate(x => x.CurrencyName, new Currency { CurrencyName = regionInfo.CurrencyEnglishName, CurrencyCode = regionInfo.ISOCurrencySymbol });
                  }          
              }
           

            //save changes
            ctx.SaveChanges();
            ctx.Dispose();

            //add a Test User
            if (!context.Users.Any(u => u.UserName == "Admin"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User { UserName = "Admin" };

                manager.Create(user, "123456");
            }
        }
    }
}
