using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RashahlyKtab.Models
{
    public class Week
    {
        [Key]
        public int Id  { get; set; }
        
        [Required(AllowEmptyStrings=false)]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
    }
}