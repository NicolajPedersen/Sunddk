using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sunddk.Models {
    public class MealPlans {
        public MealPlanViewModel mealPlan { get; set; }
        public MealViewModel meal { get; set; }
        public List<MealViewModel> meals { get; set; }
    }


    public class MealPlanViewModel {
        public int MealPlanId { get; set; }
        public string Name { get; set; }
        public double MaxCalories { get; set; }
        public string Description { get; set; }
    }

    public class MealViewModel {
        public int MealPlanId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Calories { get; set; }
        public double Weight { get; set; }
        public string Type { get; set; }
    }
}