using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RashahlyKtab.Controllers
{
    public class EventsController : Controller
    {
        // GET: Events
        public ActionResult Index(int id)
        {
            ViewBag.id = id;
            return View();
        }
     
    }
}