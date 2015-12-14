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
        //CM07 #FB03
        [HttpGet]
        public ActionResult List(string email) {
            List<MealPlan> mealplans = new List<MealPlan>();
            MealPlan userMealPlan = new MealPlan();
            PersonMealPlan personMealPlan = new PersonMealPlan();
            userMealPlan.IsAdmin = false;
            ViewBag.Email = email;
            using (var db = new Models.MealPlanContext()) {
                mealplans = db.MealPlans.Where(p => p.IsAdmin == true).ToList(); //Skal kunne hente ud sådan at det er indenfor de kalorier som man må få (BMR)
                personMealPlan = db.PersonMealPlans.FirstOrDefault(mp => mp.Person.Email == email && mp.IsActive == true);
                if (personMealPlan == null) {
                    return View(mealplans);
                }
                else {
                    personMealPlan.IsActive = false;
                    db.SaveChanges();
                }  
            }
            return View(mealplans);
        }
        
        //CM07 #FB03
        //[HttpPost]
        //public ActionResult List(int mealPlanId, string email) {
        //    PersonMealPlan personMealPlan = new PersonMealPlan();
        //    Person person = new Person();
        //    MealPlan mealPlan = new MealPlan();
        //    using (var db = new Models.MealPlanContext()) {
        //        person = db.Persons.First(p => p.Email == email);
        //        mealPlan = db.MealPlans.First(m => m.MealPlanId == mealPlanId);
        //        personMealPlan.BeginDate = DateTime.Now.Date;
        //        personMealPlan.EndDate = DateTime.Now.Date;
        //        personMealPlan.IsActive = true;
        //        personMealPlan.MealPlan = mealPlan;
        //        personMealPlan.Person = person;
        //        db.PersonMealPlans.Add(personMealPlan);
        //        db.SaveChanges();

        //        return RedirectToAction("UserProfile", "User", new { Email = email });
        //    }
        //}

        //CM07 #FB03
        [HttpGet]
        public ActionResult Categories(int mealPlanId, string email) { //Skal bruge mealplanid til at hente de meals ud som der er koblet til den mealplan (og evt sortere dem efter kategorier)
            ViewBag.MealPlanId = mealPlanId;
            ViewBag.Email = email;
            return View();
        }

        //CM07 #FB03
        [HttpGet]
        public ActionResult Meals(string type, string mealPlanId, string email) {
            ViewBag.Type = type;
            ViewBag.Email = email;
            int mealplanId = Convert.ToInt32(mealPlanId);
            List<MealPlan> mealPlan = new List<MealPlan>();
            using (var db = new Models.MealPlanContext()) {
                mealPlan = db.MealPlans.Include(mealplan => mealplan.Meals).Where(mealplan => mealplan.MealPlanId == mealplanId).ToList();
            }

            List<Meal> meals = new List<Meal>();
            foreach (var mp in mealPlan) {
                foreach(var m in mp.Meals) {
                    if (m.Type == type) {
                        m.MealPlansId = new List<int>();
                        m.MealPlansId.Add(mealplanId);
                        meals.Add(m);
                    }
                }
            }
            return View(meals);
        }

        [HttpPost]
        public ActionResult AddtoBasket(int mealId, string email) {
            Basket basket = new Basket();
            Person person = new Person();
            using (var db = new MealPlanContext()) {
                person = db.Persons.First(p => p.Email == email);
                basket.MealId = mealId;
                basket.Person = person;
                db.Baskets.Add(basket);
                db.SaveChanges();
            }

            return Content("Ok");
        }

        [HttpGet]
        public ActionResult Done(string email) {
            MealPlan userMealPlan = new MealPlan();
            Person person = new Person();
            Basket basket = new Basket();

            PersonMealPlan personMealPlan = new PersonMealPlan();
            using (var db = new MealPlanContext()) {
                person = db.Persons.First(p => p.Email == email);
                userMealPlan.IsAdmin = false;
                db.MealPlans.Add(userMealPlan);
                foreach (var b in db.Baskets) {
                    if (person.PersonId == b.PersonId) {
                        foreach (var m in db.Meals) {
                            if (m.MealId == b.MealId) {
                                m.MealPlans.Add(userMealPlan);
                            }
                        }
                    }
                }
                personMealPlan.BeginDate = DateTime.Now.Date;
                personMealPlan.EndDate = DateTime.Now.Date;
                personMealPlan.IsActive = true;
                personMealPlan.MealPlan = userMealPlan;
                personMealPlan.Person = person;
                db.PersonMealPlans.Add(personMealPlan);
                db.SaveChanges();

                db.Baskets.RemoveRange(db.Baskets.Where(b => b.PersonId == person.PersonId));
                db.SaveChanges();
            }
            return RedirectToAction("UserProfile", "User", new { Email = email });
        }

        //CM07 #FB03
        [HttpGet]
        public ActionResult CurrentMealPlan(string email) {
            PersonMealPlan personMealPlan = new PersonMealPlan();
            List<MealPlan> mealPlan = new List<MealPlan>();
            PersonMealPlanViewModel personMealPlanViewModel;
            using (var db = new Models.MealPlanContext()) {
                personMealPlan = db.PersonMealPlans.First(pmp => pmp.Person.Email == email && pmp.IsActive == true);
                mealPlan = db.MealPlans.Include(mp => mp.Meals).Where(mp => mp.MealPlanId == personMealPlan.MealPlan.MealPlanId).ToList();
                personMealPlanViewModel = new PersonMealPlanViewModel(personMealPlan, mealPlan[0].Meals);
            }
            return View(personMealPlanViewModel);
        }
    }
}