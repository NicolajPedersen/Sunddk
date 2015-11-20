using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunddkAPI.Models
{
    public class Meal
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Calories { get; set; }
        public double Weight { get; set; }
        public List<MealPlan> MealPlan { get; set; }

    }
}