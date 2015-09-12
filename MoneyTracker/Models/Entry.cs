using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoneyTracker.Models
{
    public class Entry
    {
        [Key]
        public int EntryID { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime EntryDate { get; set; }

        [MaxLength(64)]
        [Required]
        [Display(Name = "Name")]
        public String EntryName { get; set; }

        [MaxLength(1024)]
        [Display(Name = "Description")]
        public String EntryDescription { get; set; }

        [Required]
        [Display(Name = "Sum")]
        public double EntrySum { get; set; }

        public string UserID { get; set; }
        public virtual User User { get; set; }

        [Display(Name = "Category")]
        public int CategoryID { get; set; }
    }
}