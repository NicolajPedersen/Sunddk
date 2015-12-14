using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sunddk.Models {
    public class ProfileViewModel {
        public string Email { get; set; }
        [Display(Name = "Navn")]
        public string Name { get; set; }
        [Display(Name = "Fødselsdag")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Køn")]
        public string Gender { get; set; }
        [Display(Name = "Vægt")]
        public double Weight { get; set; }
        [Display(Name = "Højde")]
        public int Height { get; set; }
        public double BMR { get; set; }
        //public double BMI { get; set; }
    }

    public class PersonMealPlanViewModel {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public List<Meal> Meals { get; set; }

        public PersonMealPlanViewModel(PersonMealPlan personMealPlan, List<Meal> meals) {
            this.BeginDate = personMealPlan.BeginDate;
            this.EndDate = personMealPlan.EndDate;
            this.IsActive = personMealPlan.IsActive;
            this.Meals = meals;
        }
    }
}