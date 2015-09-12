using MoneyTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace MoneyTracker.Controllers
{
    [Authorize]
    public class StatsController : Controller
    {
        //
        // GET: /Stats/
        public ActionResult Index()
        {
            StatsViewModel model = new StatsViewModel(User.Identity.GetUserId());
            return View(model);
        }

	}
}