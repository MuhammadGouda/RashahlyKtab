using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RashahlyKtab.Models
{
    public class Contributor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Event CurrentEvent { get; set; }
        [Required]
        public ApplicationUser User { get; set; }
        [Required]
        public DateTime JoinDate { get; set; }
        [DefaultValue(0)]
        public int Points { get; set; }
    }
}