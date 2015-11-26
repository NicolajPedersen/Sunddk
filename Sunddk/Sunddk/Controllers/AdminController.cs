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
        // GET: Admin
        [HttpGet]
        public ActionResult CreateMealPlan(string name) {
            if (name != null) {
                using (var db = new Models.MealPlanContext()) {
                    MealPlans mealplan = new MealPlans();
                    MealPlan mplan = new MealPlan();
                    mplan = db.MealPlans.First(m => m.Name == mplan.Name);
                    mealplan.mealPlan.MealPlanId = mplan.MealPlanId;
                    mealplan.mealPlan.Name = mplan.Name;
                    mealplan.mealPlan.MaxCalories = mplan.MaxCalories;
                    mealplan.mealPlan.Description = mplan.Description;

                    return View(mealplan);
                }
            }
            else {
                MealPlans mealplan = new MealPlans();
                return View(mealplan);
            }
            
        }

        [HttpPost]
        public ActionResult CreateMealPlan(MealPlans mealplan) {
            if (mealplan.meal == null) {
                using (var db = new Models.MealPlanContext()) {
                    MealPlan mplan = new MealPlan();
                    mplan.Name = mealplan.mealPlan.Name;
                    mplan.MaxCalories = mealplan.mealPlan.MaxCalories;
                    mplan.Description = mealplan.mealPlan.Description;
                    db.MealPlans.Add(mplan);
                    db.SaveChanges();
                }
            }
            else {
                using (var db = new Models.MealPlanContext()) {
                    MealPlan mplan = new MealPlan();
                    Meal meal = new Meal();
                    mplan.Name = mealplan.mealPlan.Name;
                    mplan.MaxCalories = mealplan.mealPlan.MaxCalories;
                    mplan.Description = mealplan.mealPlan.Description;
                    meal.Name = mealplan.meal.Name;
                    meal.Description = mealplan.meal.Description;
                    meal.Calories = mealplan.meal.Calories;
                    meal.Weight = mealplan.meal.Weight;
                    mplan.Meals.Add(meal);
                    db.MealPlans.Add(mplan);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("CreatMealPlan", "Admin", new { name = mealplan.mealPlan.Name });
        }

        [HttpPost]
        public ActionResult CreateMeal(MealPlans meal) {
            using (var db = new Models.MealPlanContext()) {
                Meal Meal = new Meal();
                MealPlan MealPlan = new MealPlan();
                Meal.Name = meal.meal.Name;
                Meal.Description = meal.meal.Description;
                Meal.Calories = meal.meal.Calories;
                Meal.Weight = meal.meal.Weight; 
                MealPlan.MealPlanId = meal.mealPlan.MealPlanId;
                MealPlan.Name = meal.mealPlan.Name;
                MealPlan.MaxCalories = meal.mealPlan.MaxCalories;
                MealPlan.Description = meal.mealPlan.Description;
                Meal.MealPlans.Add(MealPlan);
                db.Meals.Add(Meal);
                db.SaveChanges();

                return RedirectToAction("CreateMealPlan", "Admin", new { Mealplans = meal });
            }
        }
    }
}