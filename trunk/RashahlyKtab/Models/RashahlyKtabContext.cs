using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RashahlyKtab.Models
{
    public class RashahlyKtabContext : DbContext
    {
        public RashahlyKtabContext()
            : base("name=DefaultConnection")
        {
        }

        public DbSet<Event> Events { get; set; }

        
    }
}