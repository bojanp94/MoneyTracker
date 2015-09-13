using MoneyTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace MoneyTracker.Controllers
{
    public class CategoryController : Controller
    {
        MoneyTrackerContext db = new MoneyTrackerContext();
        //
        // GET: /Category/
        public ActionResult Index()
        {
            List<Category> model = db.Categories.ToList().Where(x => x.UserID == null || x.UserID == User.Identity.GetUserId()).ToList();
            return View(model);
        }

        
        //
        // GET: /Category/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Category/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                category.UserID = User.Identity.GetUserId();
                category.CreateDate = DateTime.Now;
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = category.UserID });
            }

            return View(category);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
