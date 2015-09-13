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
    public class SettingsController : Controller
    {
        MoneyTrackerContext db = new MoneyTrackerContext();
        //
        // GET: /Settings/
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.CurrencyList = db.Currencies.ToList();
            ViewBag.GenderList = db.Genders.ToList();

            UserData user = db.UsersData.Find(User.Identity.GetUserId());
            if (user == null)
            {
                return View();
            }
            else
            {
                SettingsViewModel model = new SettingsViewModel {
                    UserDateOfBirth = user.UserDateOfBirth,
                    UserCurrency = user.UserCurrency,
                    UserGender = user.UserGender,
                    UserLegalName = user.UserLegalName };

                return View(model);
            }

        }

        // POST: /Settings/
        [HttpPost]
        public ActionResult Index(SettingsViewModel model)
        {
            ViewBag.CurrencyList = db.Currencies.ToList();
            ViewBag.GenderList = db.Genders.ToList();

            if (ModelState.IsValid)
            {
                UserData user = db.UsersData.Find(User.Identity.GetUserId());
                if (user == null)
                {
                    user = new UserData();
                    user.UserDataId = User.Identity.GetUserId();
                    user.UserDateOfBirth = model.UserDateOfBirth;
                    user.UserGender = model.UserGender;
                    user.UserLegalName = model.UserLegalName;
                    user.UserCurrency = model.UserCurrency;
                    db.UsersData.Add(user);

                }
                else
                {
                    user.UserDateOfBirth = model.UserDateOfBirth;
                    user.UserGender = model.UserGender;
                    user.UserLegalName = model.UserLegalName;
                    user.UserCurrency = model.UserCurrency;
                }

                db.SaveChanges();
            }
            return View(model);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}