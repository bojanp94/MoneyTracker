using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoneyTracker.Models
{
    public class SettingsViewModel
    {
        [MaxLength(64)]
        [Display(Name = "Name")]
        public String UserLegalName { get; set; }

        [Display(Name = "Currency")]
        public String UserCurrency { get; set; }

        [Display(Name = "Birth date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime UserDateOfBirth { get; set; }

        [Display(Name = "Gender")]
        public String UserGender { get; set; }

    }
}