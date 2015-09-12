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
        // GET: /Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
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

        //
        // GET: /Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
