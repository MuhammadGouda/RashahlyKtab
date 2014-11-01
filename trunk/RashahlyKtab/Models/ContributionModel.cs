using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RashahlyKtab.Models
{
    public class Contribution
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PagesCount { get; set; }
        public string ReviewURL { get; set; }
        public string ImageURL { get; set; }
        public string BookURL { get; set; }
        [Required]
        public Book Book { get; set; }
        [Required]
        
        public Contributor Contributer { get; set; }
        [Required]
        [DefaultValue(0)]
        public int CurrentPage { get; set; }
        
        [NotMapped]
        public double Progress { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }

    }
}