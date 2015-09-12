using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoneyTracker.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        
        public DateTime CreateDate { get; set; }

        [MaxLength(64)]
        [Required]
        [Display (Name = "Category")]
        public String CategoryName { get; set; }

        [Display(Name = "Description")]
        public String CategoryDescription { get; set; }

        public string UserID { get; set; }
        public virtual User User { set; get; }
    }
}