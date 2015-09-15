using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyTracker.Models
{
    public class StatsViewModel
    {
        private const int MonthsInYear = 12;
        private const int DaysInWeek = 7;
        private const int DaysInYear = 366;
        private const int DaysInMonth = 31;

        public List<double> SpendingsByMonth { get; private set; }
        public Dictionary<int, CategoryViewModel> SpendingsByCategory { get; private set; }
        public List<double> SpendingsByDayOfWeek { get; private set; }
        public List<double> SpendingsByDayOfYear { get; private set; }
        public List<Entry> MostExpensivePurchases { get; private set; }
        public List<Entry> entries { get; private set; }

        private DateTime firstEntry;
        private DateTime lastEntry;

        public double DailyAverageSpending 
        {
            get
            {
                TimeSpan span = lastEntry - firstEntry;
                return TotalSpending / (span.Days + 1);
            }
        }

        public double WeeklyAverageSpending
        {
            get
            {
                TimeSpan span = lastEntry - firstEntry;
                return TotalSpending / (span.Days + 1) * DaysInWeek;
            }
        }

        public double MonthlyAverageSpending
        {
            get
            {
                TimeSpan span = lastEntry - firstEntry;
                return TotalSpending / (span.Days + 1) * DaysInMonth;
            }
        }

        public double TotalSpending
        {
            get
            {
                double sum = 0;
                foreach (var item in entries)
                {
                    sum += item.EntrySum;
                }
                return sum;
            }
        }

        public StatsViewModel(string userId)
        {
            MoneyTrackerContext ctx = new MoneyTrackerContext();
            entries = ctx.Entries.Where(x => x.UserID == userId).ToList();
            if(entries.Count > 0)
            {
                firstEntry = entries.OrderBy(x => x.EntryDate).FirstOrDefault().EntryDate;
                lastEntry = entries.OrderBy(x => x.EntryDate).LastOrDefault().EntryDate;

                SetSpendingsByMonth(DateTime.Now.Year);
                SetSpendingsByCategory();
                SetSpendingsByDayOfWeek(DateTime.Now.Year);
                SetSpendingsByDayOfYear(DateTime.Now.Year);
                SetMostExpensivePurchases(5);
            }
   
        }

        private void SetSpendingsByMonth(int year)
        {
            SpendingsByMonth = new List<double>(new double[MonthsInYear]);

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
            SpendingsByCategory = new Dictionary<int, CategoryViewModel>();

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

        private void SetSpendingsByDayOfWeek(int year)
        {
            SpendingsByDayOfWeek = new List<double>(new double[DaysInWeek]);

            foreach (var item in entries)
            {
                if (item.EntryDate.Year == year)
                {
                    int dayOfWeek = (int)item.EntryDate.DayOfWeek;
                    SpendingsByDayOfWeek[dayOfWeek] += item.EntrySum;
                }
            }
        }

        private void SetSpendingsByDayOfYear(int year)
        {
            SpendingsByDayOfYear = new List<double>(new double[DaysInMonth]);

            foreach (var item in entries)
            {
                if (item.EntryDate.Year == year)
                {
                    int dayOfYear = item.EntryDate.Day - 1;
                    SpendingsByDayOfYear[dayOfYear] += item.EntrySum; 
                }
            }
        }

        public void SetMostExpensivePurchases(int count)
        {
            MostExpensivePurchases = entries.OrderByDescending(x => x.EntrySum).Take(count).ToList();
        }
    }
}