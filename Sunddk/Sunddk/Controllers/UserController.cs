using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sunddk.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Sunddk.Controllers
{
    public class UserController : Controller
    {
        
        // GET: User
        [HttpGet]
        public ActionResult UserProfile(string email)
        {
            using (var db = new Models.MealPlanContext()) {
                Person person = new Person();
                Measurement measurements = new Measurement();
                ProfileViewModel profile = new ProfileViewModel();
                person = db.Persons.First(p => p.Email == email);
                profile.Email = person.Email;
                profile.Name = person.Name;
                profile.DateOfBirth = person.DateOfBirth.Value.Date;
                profile.Gender = person.Gender;
                DateTime now = DateTime.Now.Date;
                measurements = db.Measurements.First(m => m.PersonId == person.PersonId /*&& m.Date == now*/);
                profile.Weight = measurements.Weight;
                profile.Height = measurements.Height;
                profile.BMR = measurements.BMR;

                return View(profile);
            }
        }

        [HttpPost]
        public ActionResult UserProfile(ProfileViewModel profile) {
            Sunddk.Utilities.Calculate utiliti = new Utilities.Calculate();
            double BMR = utiliti.CalculateBMR(profile.DateOfBirth, profile.Gender, profile.Weight, profile.Height);
            
            using (var db = new Models.MealPlanContext()) {
                Person person = new Person();
                Measurement measurements = new Measurement();
                person = db.Persons.FirstOrDefault(p => p.Email == profile.Email);
                measurements.Date = DateTime.Now;
                measurements.Weight = profile.Weight;
                measurements.Height = profile.Height;
                measurements.BMR = BMR;
                measurements.PersonId = person.PersonId;
                db.Measurements.Add(measurements);
                db.SaveChanges();

                return RedirectToAction("UserProfile", "User", new { Email = profile.Email});
            } 
        }

        //Er bare en test!!
        [HttpGet]
        public ActionResult List() {
            List<MealPlan> mealplans = new List<MealPlan>();
            using (var db = new Models.MealPlanContext()) {
                mealplans = db.MealPlans.ToList();
            }
            return View(mealplans);
        }

        [HttpGet]
        public ActionResult Categories(/*int MealPlanId*/) { //Skal bruge mealplanid til at hente de meals ud som der er koblet til den mealplan (og evt sortere dem efter kategorier)
            return View();
        }

        [HttpGet]
        public ActionResult Meals() {
            return View();
        }

        [HttpGet]
        public ActionResult CurrentMealPlan() {
            return View();
        }
    }
}