using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyTracker.Models.View_Models
{
    public class ExternalLoginViewModel
    {
        public string Action { get; set; }
        public string ReturnUrl { get; set; }
    }
}