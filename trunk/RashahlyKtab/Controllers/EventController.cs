using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Description;
using RashahlyKtab.Models;

namespace RashahlyKtab.Controllers
{
    
    public class EventController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }

        private async Task<List<Event>> GetAllEvents()
        {
            return await this.db.Events.ToListAsync();
        }

        // GET api/event
        [ResponseType(typeof(List<Event>))]
        public async Task<IHttpActionResult> Get()
        {
            var userId = User.Identity.Name;

            List<Event> allEvents = await this.GetAllEvents();

            if (allEvents == null)
            {
                return this.NotFound();
            }

            return this.Ok(allEvents);
        }


        [ResponseType(typeof(Event))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var @event = await this.db.Events.FirstOrDefaultAsync(e => e.Id == id);
            if (@event == null)
                return NotFound();

            return Ok(@event);
        }

        private async Task<Event> StoreAsync(Event newEvent)
        {
            newEvent.CreateionDate = DateTime.Now;           
            this.db.Events.Add(newEvent);
            try
            {
                await this.db.SaveChangesAsync();
                var savedEvent = await this.db.Events.FirstOrDefaultAsync(o => o.Id == newEvent.Id);

                return savedEvent;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

         //POST api/event
        [ResponseType(typeof(Event))]
        public async Task<IHttpActionResult> Post(Event newEvent)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }            

            var savedEvent = await this.StoreAsync(newEvent);
            return this.Ok<Event>(savedEvent);
        }
    }
}
