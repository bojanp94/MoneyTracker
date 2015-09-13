using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoneyTracker.Models
{
    public class Currency
    {
        [Key]
        public int CurrencyID { get; set; }
        public String CurrencyName { get; set; }
        public String CurrencyCode { get; set; }
    }
}