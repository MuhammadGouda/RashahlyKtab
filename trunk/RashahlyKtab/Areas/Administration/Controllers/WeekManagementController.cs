using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RashahlyKtab.Areas.Administration.Controllers
{
    public class WeekManagementController : Controller
    {
        // GET: Administration/WeekManagement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}