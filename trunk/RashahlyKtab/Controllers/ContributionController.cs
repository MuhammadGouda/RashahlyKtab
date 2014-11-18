using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using RashahlyKtab.Models;
using System.Web;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace RashahlyKtab.Controllers
{
    public class ContributionController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET api/Contribution
        public async Task<List<Contribution>> GetContributions()
        {
            return await db.Contributions
                .Include(c=>c.Book)
                .Include(c=>c.Contributer.User)                              
                .ToListAsync();
        }

        // GET api/Contribution/Event/eventId
        [ActionName("Event")]
        public async Task<List<Contribution>> GetContributions(int eventId)
        {
            return await db.Contributions
                .Include(c => c.Book)
                .Include(c => c.Contributer.User)
                .Include(c => c.Contributer.CurrentEvent)
                .Where(c => c.Contributer.CurrentEvent.Id == eventId).OrderByDescending(c=>c.Id).Take(20)//load most recent 20 records only
                .ToListAsync();
        }

        // GET api/Contribution/CurrentContributor/eventId?userId=userId
        [ActionName("CurrentContributor")]
        public async Task<List<Contribution>> GetContributions(int eventId, string userId)
        {
            return await db.Contributions
                .Include(c => c.Book)
                .Include(c => c.Contributer.User)
                .Include(c => c.Contributer.CurrentEvent)
                .Where(c => c.Contributer.CurrentEvent.Id == eventId && c.Contributer.User.Id == userId)
                .ToListAsync();
        }

       
        // GET api/Contribution/5
        [ResponseType(typeof(Contribution))]        
        public async Task<IHttpActionResult> GetContribution(int id)
        {
            Contribution contribution = await db.Contributions.FindAsync(id);
            if (contribution == null)
            {
                return NotFound();
            }

            return Ok(contribution);
        }

        // PUT api/Contribution/5
        public async Task<IHttpActionResult> PutContribution(int id, Contribution contribution)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contribution.Id)
            {
                return BadRequest();
            }

            db.Entry(contribution).State = EntityState.Modified;
            

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContributionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        private Contribution GetContibutor(string userName, int eventId)
        {
            var result = db.Contributions
                //.Include(c => c.CurrentEvent)
                .Include(c => c.Contributer.User)
                .FirstOrDefault(c => c.Contributer.User.UserName == userName && c.Contributer.CurrentEvent.Id == eventId);
            //result.JoinDate = DateTime.Now;
            return result;
        }

        // POST api/Contribution
        [Authorize()]
        [ResponseType(typeof(Contribution))]
        public async Task<IHttpActionResult> PostContribution(Contribution contribution)
        {           
            
            UpdateContribution(contribution);
            
            db.Contributions.Add(contribution);
            try
            {
                await db.SaveChangesAsync();
                return CreatedAtRoute("DefaultApi", new { id = contribution.Id }, contribution);
            }
            catch (Exception ex)
            {
                return BadRequest(ModelState);
            }
            
        }

        //set properties that are not set from client side
        private void UpdateContribution(Contribution contribution)
        {
            contribution.StartDate = DateTime.Now;//to be entered by user
            contribution.EndtDate = DateTime.Now.AddDays(5);//to be entered by user
            string currentUserId = User.Identity.GetUserId();
            string strEventId = HttpContext.Current.Request.UrlReferrer.Segments[2];//the event id
            int currentEventId = 0;
            int.TryParse(strEventId, out currentEventId);
            if (currentEventId == 0)
                throw new Exception("Invalid Event ID");
            Event currentEvent = db.Events.Find(currentEventId);
            if (currentEvent == null)
                throw new Exception("Invalid Event ID");
            //check of current user already is a contributor
            var existingCont = db.Contributors.FirstOrDefault(c => c.User.Id == currentUserId);
            if (existingCont != null)//if yes use his record
                contribution.Contributer = existingCont;
            else //else create a new record using current logged in user
                contribution.Contributer = new Contributor() { 
                    JoinDate = DateTime.Now, 
                    User = db.Users.Find(currentUserId),
                    CurrentEvent = currentEvent
                };
            
        }

        private Event GetEvent(int eventId)
        {
            var result = db.Events.FirstOrDefault(e => e.Id == eventId);
          
            return result;
        }

        // DELETE api/Contribution/5
        [ResponseType(typeof(Contribution))]
        public async Task<IHttpActionResult> DeleteContribution(int id)
        {
            Contribution contribution = await db.Contributions.FindAsync(id);
            if (contribution == null)
            {
                return NotFound();
            }

            
            db.Contributions.Remove(contribution);
            await db.SaveChangesAsync();

            return Ok(contribution);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContributionExists(int id)
        {
            return db.Contributions.Count(e => e.Id == id) > 0;
        }
    }
}