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
using Microsoft.AspNet.Identity;
using RashahlyKtab.Models;

namespace RashahlyKtab.Controllers
{
    [Authorize]
    public class ContributionsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Contributions
        public IQueryable<Contribution> GetContributions()
        {
            return db.Contributions;
        }

        // GET api/Contributions?eventId={eventId}
        [ResponseType(typeof(List<Contribution>))]
        public async Task<IHttpActionResult> GetContribution(int eventId)
        {
            var userId = User.Identity.GetUserId();
            List<Contribution> userContributions = null;
            try
            {
                userContributions = await GetUserEventContributions(userId, eventId);
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
            return this.Ok(userContributions);
        }

        private async Task<List<Contribution>> GetUserEventContributions(string userId,int eventId)
        {
            var userContributions = from contributions in db.Contributions.Include(c=>c.Book)
                                    where contributions.Contributer.User.Id == userId
                                          && contributions.Contributer.CurrentEvent.Id == eventId
                                    select contributions;

            var userContributionsList = await userContributions.ToListAsync();
            return userContributionsList;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        
    }
}