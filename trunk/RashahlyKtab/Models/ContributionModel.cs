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
        [Required]
        public Book Book { get; set; }
        [Required]
        public Contributor Contributer { get; set; }
        
        [Required]
        [DefaultValue(0)]
        public int CurrentPage { get; set; }
        
        public string ReviewURL { get; set; }
        public string ImageURL { get; set; }
        public string BookURL { get; set; }

        public DateTime LastModified { get; set; }

        [NotMapped]
        public int DaysSinceLastModifications
        { 
            get 
            {
                var dateDif = DateTime.Now - LastModified;
                return dateDif.Days;                
            } 
        }

        [NotMapped]
        public double Progress
        {
            get { return CurrentPage*100 / PagesCount; }
        }
            

        
        public DateTime StartDate { get; set; }
        public DateTime? EndtDate { get; set; }

    }
}