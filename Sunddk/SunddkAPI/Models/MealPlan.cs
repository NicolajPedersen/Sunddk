using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunddkAPI.Models
{
    public class MealPlan
    {
        public string Name { get; set; }
        public double MaxCalories { get; set; }
        public string Description { get; set; }
        public List<PersonMealPlanLine> PersonMealPlanLine { get; set; }
        public List<Meal> Meal { get; set; }

    }
}