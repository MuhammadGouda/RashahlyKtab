using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RashahlyKtab.Models
{
    public class Event
    {
        public int Id { get; set; }
        public bool IsAtive { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateionDate { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
        //public ApplicationUser Creator { get; set; }

        [NotMapped]
        public EventStatistics Statistics { get; set; }
    }
}