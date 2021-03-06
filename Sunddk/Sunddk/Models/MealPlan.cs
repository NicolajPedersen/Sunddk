﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sunddk.Models
{
    public class MealPlan
    {
        [Key]
        public int MealPlanId { get; set; }
        public string Name { get; set; }
        public double MaxCalories { get; set; }
        public string Description { get; set; }
        public bool IsAdmin { get; set; }
        public virtual List<Meal> Meals { get; set; }
        public List<int> MealsId { get; set; }
    }
}