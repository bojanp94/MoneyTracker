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
        [Display(Name = "Name")]
        public String UserLegalName { get; set; }

        [Display(Name = "Currency")]
        public String UserCurrency { get; set; }

        [Display(Name = "Birth date")]
        [DataType(DataType.Date)]
        public DateTime UserDateOfBirth { get; set; }

        [Display(Name = "Gender")]
        public String UserGender { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }

    }
}