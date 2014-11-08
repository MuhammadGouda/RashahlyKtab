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

namespace RashahlyKtab.Controllers
{
    public class ContributionController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET api/Contribution
        public async Task<List<Contribution>> GetContributions()
        {
            return await db.Contributions.ToListAsync();
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

        // POST api/Contribution
        [Authorize()]
        [ResponseType(typeof(Contribution))]
        public async Task<IHttpActionResult> PostContribution(Contribution contribution)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contributions.Add(contribution);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = contribution.Id }, contribution);
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