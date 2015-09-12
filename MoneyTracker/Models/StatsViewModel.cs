using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyTracker.Models
{
    public class StatsViewModel
    {
        public List<double> SpendingsByMonth { get; private set; }
        public Dictionary<int, CategoryViewModel> SpendingsByCategory { get; private set; }
        private List<Entry> entries;

        public StatsViewModel(string userId)
        {
            SpendingsByMonth = new List<double>(new double[12]);
            SpendingsByCategory = new Dictionary<int, CategoryViewModel>();
            MoneyTrackerContext ctx = new MoneyTrackerContext();
            entries = ctx.Entries.Where(x => x.UserID == userId).ToList();
            SetSpendingsByMonth(DateTime.Now.Year);
            SetSpendingsByCategory();
        }

        private void SetSpendingsByMonth(int year)
        {
            foreach (var item in entries)
            {
                if (item.EntryDate.Year == year)
                {
                    int month = item.EntryDate.Month - 1;
                    SpendingsByMonth[month] += item.EntrySum;
                }
            }
        }

        private void SetSpendingsByCategory()
        {
            foreach (var item in entries)
            {
                MoneyTrackerContext ctx = new MoneyTrackerContext();
                int categoryId = item.CategoryID;
                if (categoryId == 0)
                {
                    continue;
                }

                string categoryName = ctx.Categories.Where(x => x.CategoryID == categoryId).FirstOrDefault().CategoryName;

                if (SpendingsByCategory.ContainsKey(categoryId))
                {
                    SpendingsByCategory[categoryId].Sum += item.EntrySum;
                }
                else
                {
                    SpendingsByCategory[categoryId] = new CategoryViewModel { Sum = item.EntrySum, CategoryID = categoryId, CategoryName = categoryName };
                }
            }
        }
    }
}