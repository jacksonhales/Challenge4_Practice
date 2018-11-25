using Challenge4_Practice.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Challenge4_Practice.Controllers
{
    public class CoffeeDateController : Controller
    {
        private Entities db = new Entities();

        // GET: CoffeeDate
        [Authorize]
        public ActionResult Index()
        {

            string userId = User.Identity.GetUserId();
            AspNetUser currentUser = db.AspNetUsers.SingleOrDefault(u => u.Id == userId);

            List<CoffeeDate> coffeeDates = new List<CoffeeDate>();

            if (currentUser.EmailConfirmed == true)
            {
                coffeeDates = db.CoffeeDates.Where(c => c.Date > DateTime.Today).ToList();
            }
            else
            {
                
            }

            return View("Index", coffeeDates);
        }

        public ActionResult Delete(CoffeeDate coffeeDate)
        {

            CoffeeDate c = db.CoffeeDates.SingleOrDefault(cd => cd.Id == coffeeDate.Id);

            db.CoffeeDates.Remove(c);

            try
            {
                db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

            return RedirectToAction("Index");
        }

        public ActionResult Create(CoffeeDate coffeeDate)
        {

            db.CoffeeDates.Add(coffeeDate);
            
            try
            {
                db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

            return RedirectToAction("Index");
        }

    }
}