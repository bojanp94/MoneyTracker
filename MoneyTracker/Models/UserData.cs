using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MoneyTracker.Models
{
    public class UserData
    {
        [Key, ForeignKey("User")]
        public string UserDataId { get; set; }
        [MaxLength(64)]
        public String UserLegalName { get; set; }
        public String UserCurrency { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }

    }
}