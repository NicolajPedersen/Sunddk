using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sunddk.Models
{
    public class Meal
    {
        public int MealId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Calories { get; set; }
        public double Weight { get; set; }
        public string Type { get; set; }
        public virtual List<MealPlan> MealPlans { get; set; }
        public List<int> MealPlansId { get; set; }
    }
}