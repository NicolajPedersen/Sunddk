using System;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sunddk.Controllers;
using Sunddk.Models;


namespace Unittests
{
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1() {
        }

    }

    //Dette virker ikke for vores version på projektet er en nyere version end den version af System.Web.Mvc der er tilgængelig for at jeg kan få fat i controllerne
    //Men nu har jeg lavet dem sådan som de skulle laves, men kan bare ikke køre dem

    //[TestClass]
    //public class UnitTestCreateMealPlan {
    //    //Testing the View returned by the Controller
    //    [TestMethod]
    //    public void TestCreateMealPlanController() {
    //        MealPlanViewModel mealPlan = new MealPlanViewModel();
    //        mealPlan.MealPlanId = 100;
    //        mealPlan.Name = "Test";
    //        mealPlan.MaxCalories = 100;
    //        mealPlan.Description = "Test";

    //        AdminController controller = new AdminController();
    //        var result = controller.CreateMealPlan(mealPlan) as ViewResult;
    //        Assert.AreEqual("CreateMeal", result.ViewName);
    //    }

    //    //Testing the View Data returned by the Controller
    //    [TestMethod]
    //    public void TestCreateMealPlanViewData() {
    //        MealPlanViewModel mealPlan = new MealPlanViewModel();
    //        mealPlan.MealPlanId = 100;
    //        mealPlan.Name = "Test";
    //        mealPlan.MaxCalories = 100;
    //        mealPlan.Description = "Test";

    //        AdminController controller = new AdminController();
    //        var result = controller.CreateMealPlan(mealPlan) as ViewResult;
    //        var mealplanid = result.ViewData.Values;
    //        Assert.AreEqual(mealPlan.MealPlanId, mealplanid);
    //    }

    //    //Testing The ActionResult returned by the Controller
    //    [TestMethod]
    //    public void TestCreateMealPlanActionResult() {
    //        MealPlanViewModel mealPlan = new MealPlanViewModel();
    //        mealPlan.MealPlanId = 100;
    //        mealPlan.Name = "Test";
    //        mealPlan.MaxCalories = 100;
    //        mealPlan.Description = "Test";

    //        var controller = new AdminController();
    //        var result = (RedirectToRouteResult)controller.CreateMealPlan(mealPlan);
    //        Assert.AreEqual("CreateMeal", result.Values["action"]);
    //    }

    //    [TestClass]
    //    public class UnitTestCreateMeal {
    //        //Testing the View returned by the Controller
    //        [TestMethod]
    //        public void TestCreateMealController() {
    //            MealViewModel meal = new MealViewModel();
    //            meal.MealPlanId = 200;
    //            meal.Name = "Test2";
    //            meal.Description = "Test2";
    //            meal.Calories = 200;
    //            meal.Weight = 200;
    //            //Skal evt også tilføje type


    //            AdminController controller = new AdminController();
    //            var result = controller.CreateMeal(meal) as ViewResult;
    //            Assert.AreEqual("CreateMeal", result.ViewName);
    //        }

    //        //Testing the View Data returned by the Controller
    //        [TestMethod]
    //        public void TestCreateMealViewData() {
    //            MealViewModel meal = new MealViewModel();
    //            meal.MealPlanId = 200;
    //            meal.Name = "Test2";
    //            meal.Description = "Test2";
    //            meal.Calories = 200;
    //            meal.Weight = 200;
    //            //Skal evt også tilføje type

    //            AdminController controller = new AdminController();
    //            var result = controller.CreateMeal(meal);
    //            var mealtest = (MealViewModel)result.ViewData.Model;
    //            Assert.AreEqual(meal.MealPlanId, mealtest.MealPlanId);
    //        }

    //        //Testing The ActionResult returned by the Controller
    //        [TestMethod]
    //        public void TestCreateMealActionResult() {
    //            MealViewModel meal = new MealViewModel();
    //            meal.MealPlanId = 200;
    //            meal.Name = "Test2";
    //            meal.Description = "Test2";
    //            meal.Calories = 200;
    //            meal.Weight = 200;
    //            //Skal evt også tilføje type

    //            AdminController controller = new AdminController();
    //            var result = (RedirectToRouteResult)controller.CreateMeal(meal);
    //            Assert.AreEqual("CreateMeal", result.Values["action"]);
    //        }
    //    }
    //}
}
