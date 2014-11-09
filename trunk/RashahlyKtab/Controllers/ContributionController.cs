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
    public class ContributionController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET api/Contribution
        [ResponseType(typeof(List<Contribution>))]
        public async Task<IHttpActionResult> Get()
        {
            var userId = User.Identity.GetUserId();
            List<Contribution> userContributions = null;
            try
            {
                userContributions = await GetUserActiveContributions(userId);
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
            return this.Ok(userContributions);
        }

        private async Task<List<Contribution>> GetUserActiveContributions(string userId)
        {
            var userContributions = from contributions in db.Contributions.Include(c=>c.Book)
                                    where contributions.Contributer.User.Id == userId
                                          && contributions.Contributer.CurrentEvent.IsAtive
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