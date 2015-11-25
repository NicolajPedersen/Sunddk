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
                measurements = db.Measurements.First(m => m.PersonId == person.PersonId);
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
                Person personn = new Person();
                Measurement measurements = new Measurement();
                //personn = db.Persons.FirstOrDefault(p => p.Email == profile.Email);
                //personn.Email = profile.Email;
                //personn.Name = profile.Name;
                //personn.DateOfBirth = profile.DateOfBirth;
                //personn.Gender = profile.Gender;
                //personn.Measurements = new List<Models.Measurement>();
                //measurements.Weight = profile.Weight;
                //measurements.Height = profile.Height;
                //measurements.BMR = BMR;
                //personn.Measurements.Add(measurements);
                //db.Persons.Add(personn);
                //db.SaveChanges();

                return RedirectToAction("UserProfile", "User", new { Email = profile.Email});
            } 
        }
    }
}