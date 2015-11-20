using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sunddk.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            using (var db = new Models.MealPlanContext())
            {
                var Person = new Models.Person();
                Person.Name = "Mig";
                db.Persons.Add(Person);
                db.SaveChanges();
            }
            
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}