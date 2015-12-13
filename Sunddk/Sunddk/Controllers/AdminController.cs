using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sunddk.Models;

namespace Sunddk.Controllers
{
    public class AdminController : Controller
    {
        //Skal lige have kigget på det her sådan at man ikke behøver en static liste
        private static List<Meal> meals = new List<Meal>();
        // GET: Admin
        [HttpGet]
        public ActionResult AdminProfile() {
            return View();
        }
        //CM01 #FA01
        [HttpGet]
        public ActionResult CreateMealPlan() {
            MealPlanViewModel mealPlan = new MealPlanViewModel();

            return View(mealPlan);
        }

        //CM01 #FA01
        [HttpPost]
        public ActionResult CreateMealPlan(MealPlanViewModel mealPlanView) {
            MealPlan mealPlan = new MealPlan();
            using (var db = new Models.MealPlanContext()) {
                mealPlan.Name = mealPlanView.Name;
                mealPlan.MaxCalories = mealPlanView.MaxCalories;
                mealPlan.Description = mealPlanView.Description;
                mealPlan.IsAdmin = true;
                db.MealPlans.Add(mealPlan);
                db.SaveChanges();

                mealPlan = db.MealPlans.First(m => m.Name == mealPlanView.Name);
            }
                return RedirectToAction("CreateMeal", "Admin", new { MealPlanId = mealPlan.MealPlanId });
        }

        //CM01 #FA01
        [HttpGet]
        public ActionResult CreateMeal(int mealPlanId) {
            MealViewModel meal = new MealViewModel();
            meal.MealPlanId = mealPlanId;

            return View(meal);
        }

        //CM01 #FA01
        [HttpPost]
        public ActionResult CreateMeal(MealViewModel mealView) {
            Meal meal = new Meal();
            MealPlan mealPlan = new MealPlan();
            using (var db = new Models.MealPlanContext()) {
                mealPlan = db.MealPlans.First(m => m.MealPlanId == mealView.MealPlanId);

                meal.Name = mealView.Name;
                meal.Description = mealView.Description;
                meal.Calories = mealView.Calories;
                meal.Weight = mealView.Weight;
                meal.MealPlans = new List<MealPlan>();
                meal.MealPlans.Add(mealPlan);
                db.Meals.Add(meal);
                db.SaveChanges();

                meal = db.Meals.First(m => m.Name == mealView.Name);
                meals.Add(meal);
            }
            return RedirectToAction("CreateMeal", "Admin", new { MealPlanId = mealView.MealPlanId});
        }

        [HttpGet]
        public ActionResult Done() {
            return RedirectToAction("AdminProfile", "Admin");
        }





        //[HttpGet]
        //public ActionResult CreateMealPlanTest(string name) {
        //    if (name != null) {
        //        using (var db = new Models.MealPlanContext()) {
        //            MealPlans mealplan = new MealPlans();
        //            MealPlan mplan = new MealPlan();
        //            mplan = db.MealPlans.First(m => m.Name == mplan.Name);
        //            mealplan.mealPlan.MealPlanId = mplan.MealPlanId;
        //            mealplan.mealPlan.Name = mplan.Name;
        //            mealplan.mealPlan.MaxCalories = mplan.MaxCalories;
        //            mealplan.mealPlan.Description = mplan.Description;

        //            return View(mealplan);
        //        }
        //    }
        //    else {
        //        MealPlans mealplan = new MealPlans();
        //        return View(mealplan);
        //    }

        //}

        //[HttpPost]
        //public ActionResult CreateMealPlanTest(MealPlans mealplan) {
        //    if (mealplan.meal == null) {
        //        using (var db = new Models.MealPlanContext()) {
        //            MealPlan mplan = new MealPlan();
        //            mplan.Name = mealplan.mealPlan.Name;
        //            mplan.MaxCalories = mealplan.mealPlan.MaxCalories;
        //            mplan.Description = mealplan.mealPlan.Description;
        //            db.MealPlans.Add(mplan);
        //            db.SaveChanges();
        //        }
        //    }
        //    else {
        //        using (var db = new Models.MealPlanContext()) {
        //            MealPlan mplan = new MealPlan();
        //            Meal meal = new Meal();
        //            mplan.Name = mealplan.mealPlan.Name;
        //            mplan.MaxCalories = mealplan.mealPlan.MaxCalories;
        //            mplan.Description = mealplan.mealPlan.Description;
        //            meal.Name = mealplan.meal.Name;
        //            meal.Description = mealplan.meal.Description;
        //            meal.Calories = mealplan.meal.Calories;
        //            meal.Weight = mealplan.meal.Weight;
        //            mplan.Meals.Add(meal);
        //            db.MealPlans.Add(mplan);
        //            db.SaveChanges();
        //        }
        //    }
        //    return RedirectToAction("CreatMealPlan", "Admin", new { name = mealplan.mealPlan.Name });
        //}

        //[HttpPost]
        //public ActionResult CreateMealTest(MealPlans meal) {
        //    using (var db = new Models.MealPlanContext()) {
        //        Meal Meal = new Meal();
        //        MealPlan MealPlan = new MealPlan();
        //        Meal.Name = meal.meal.Name;
        //        Meal.Description = meal.meal.Description;
        //        Meal.Calories = meal.meal.Calories;
        //        Meal.Weight = meal.meal.Weight; 
        //        MealPlan.MealPlanId = meal.mealPlan.MealPlanId;
        //        MealPlan.Name = meal.mealPlan.Name;
        //        MealPlan.MaxCalories = meal.mealPlan.MaxCalories;
        //        MealPlan.Description = meal.mealPlan.Description;
        //        Meal.MealPlans.Add(MealPlan);
        //        db.Meals.Add(Meal);
        //        db.SaveChanges();

        //        return RedirectToAction("CreateMealPlan", "Admin", new { Mealplans = meal });
        //    }
        //}
    }
}