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
    public class DashboardController : Controller
    {
        MoneyTrackerContext db = new MoneyTrackerContext();


        // GET: /Dashboard/
        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            var CurretnUser = db.Users.Find(id);
            return View(CurretnUser.UserEntries);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Entry entry)
        {
            if (ModelState.IsValid)
            
            {
                entry.UserID = User.Identity.GetUserId();
                db.Entries.Add(entry);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = entry.UserID });
            }
            return View(entry);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
	}
}