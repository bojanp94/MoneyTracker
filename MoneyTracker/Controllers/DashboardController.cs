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
        const int PageSize = 10;

        // GET: /Dashboard/
        public ActionResult Index(int page = 1)
        {
            var id = User.Identity.GetUserId();
            var CurrentUser = db.Users.Find(id);
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = CurrentUser.UserEntries.Count / PageSize + 1;
            return View(CurrentUser.UserEntries.Skip((page-1) * PageSize).Take(PageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Categories = GetCategories();

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

            ViewBag.Categories = GetCategories();
            return View(entry);
        }

        [HttpGet]
        public ActionResult Delete(int entryId)
        {
            db.Entries.Remove(db.Entries.Where(x => x.EntryID == entryId).FirstOrDefault());
            db.SaveChanges();

            var id = User.Identity.GetUserId();
            var CurrentUser = db.Users.Find(id);

            ViewBag.CurrentPage = 1;
            ViewBag.TotalPages = CurrentUser.UserEntries.Count / PageSize + 1;

            return View("Index", CurrentUser.UserEntries.Take(PageSize));
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private List<CategoryViewModel> GetCategories()
        {
            List<Category> temp = db.Categories.ToList().Where(x => x.UserID == null || x.UserID == User.Identity.GetUserId()).ToList();
            List<CategoryViewModel> categories = new List<CategoryViewModel>();
            foreach (var category in temp)
            {
                categories.Add(new CategoryViewModel { CategoryID = category.CategoryID, CategoryName = category.CategoryName });
            }

            return categories;
        }
	}
}