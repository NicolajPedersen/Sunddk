using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sunddk.Models;

namespace Sunddk.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult UserProfile(string email)
        {
            using(var db = new Models.MealPlanContext()) {
                Person person = new Person();
                Measurement measurements = new Measurement();
                ProfileViewModel profile = new ProfileViewModel();

                person = db.Persons.First(p => p.Email == email);
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
    }
}