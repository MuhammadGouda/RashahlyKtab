using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RashahlyKtab.Models
{
    public class RashahlyKtabDatabaseInitializer : CreateDatabaseIfNotExists<RashahlyKtabContext>
    {
       
        protected override void Seed(RashahlyKtabContext context)
        {
            base.Seed(context);

            var events = new List<Event>();
            events.Add(new Event
            {
                Id =1,
                IsAtive= true,
                Title = "Week #1: Let's Start",
                CreateionDate = DateTime.Now.AddDays(-50),
                StartDate = DateTime.Now.AddDays(-50),
                EndDate = DateTime.Now.AddDays(-43)
            });

            events.Add(new Event
            {
                Id = 2,
                IsAtive = false,
                Title = "Week #2: Let's Start",
                CreateionDate = DateTime.Now.AddDays(-50),
                StartDate = DateTime.Now.AddDays(-50),
                EndDate = DateTime.Now.AddDays(-43)
            });

            events.Add(new Event
            {
                Id = 3,
                Title = "Week #3: Let's Start",
                CreateionDate = DateTime.Now.AddDays(-50),
                StartDate = DateTime.Now.AddDays(-50),
                EndDate = DateTime.Now.AddDays(-43)
            });
            
            events.ForEach(a => context.Events.Add(a));

            context.SaveChanges();
        }
    }
}