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
        public DateTime EntryDate { get; set; }
        [MaxLength(64)]
        [Required]
        public String EntryName { get; set; }
        [MaxLength(1024)]
        public String EntryDescription { get; set; }
        [Required]
        public double EntrySum { get; set; }

        public string UserID { get; set; }
        public virtual User User { get; set; }
    }
}