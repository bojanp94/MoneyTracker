using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyTracker.Models
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public double Sum { get; set; }
    }
}