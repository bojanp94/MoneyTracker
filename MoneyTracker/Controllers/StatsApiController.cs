using MoneyTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace MoneyTracker.Controllers
{
    public class StatsApiController : ApiController
    {
        public object GetMostExpensivePurchase()
        {
            StatsViewModel model = new StatsViewModel(User.Identity.GetUserId());
            return (from entry in model.MostExpensivePurchases
                        select new {
                            Name = entry.EntryName,
                            Sum = entry.EntrySum,
                            Date = entry.EntryDate,
                            Description = entry.EntryDescription
                        }).First();
        }

        public double GetDailyAverageSpending()
        {
            return new StatsViewModel(User.Identity.GetUserId()).DailyAverageSpending;
        }
 
        public double GetWeeklyAverageSpending()
        {
            return new StatsViewModel(User.Identity.GetUserId()).WeeklyAverageSpending;
        }

        public double GetMonthlyAverageSpending()
        {
            return new StatsViewModel(User.Identity.GetUserId()).MonthlyAverageSpending;
        }

        public double GetTotalSpending()
        {
            return new StatsViewModel(User.Identity.GetUserId()).TotalSpending;
        }

        public object GetMostSpentOnCategory()
        {
            MoneyTrackerContext ctx = new MoneyTrackerContext();

            double max = 0;
            string name = "";
            foreach (var category in ctx.Categories)
            {
                var value = GetTotalSpentOnCategory(category.CategoryName);
                if (value > max)
                {
                    max = value;
                    name = category.CategoryName;
                }
            }
            return new { CategoryName = name, Total = max };
        }

        public double GetTotalSpentOnCategory(string categoryName)
        {
            MoneyTrackerContext ctx = new MoneyTrackerContext();
            var category = ctx.Categories.Where(x => x.CategoryName == categoryName).FirstOrDefault();

            if (category == null)
                throw new Exception("Category Name not found");

            var userId = User.Identity.GetUserId();
            
            double sum = 0;
            var entries = ctx.Entries.Where(x => x.CategoryID == category.CategoryID
                                                        && x.UserID == userId).ToList();
            foreach (var entry in entries)
            {
                sum += entry.EntrySum;
            }

            return sum;
        }
    }
}
