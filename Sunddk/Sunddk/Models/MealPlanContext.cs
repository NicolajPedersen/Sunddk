using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Sunddk.Models
{
    public class MealPlanContext : DbContext
    {
        public MealPlanContext() : base("DefaultConnection")
        {

        }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<PersonMealPlan> PersonMealPlans { get; set; }
        public DbSet<Basket> Baskets { get; set; }
    }
}