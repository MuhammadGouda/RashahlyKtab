using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RashahlyKtab.Models
{
    public class Event
    {
        public int Id { get; set; }
        public bool IsAtive { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateionDate { get; set; }
        //public ApplicationUser Creator { get; set; }
    }
}