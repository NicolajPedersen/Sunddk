using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunddkAPI.Models
{
    public class PersonMealPlan
    {
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime BeginDate { get; set; }
        public List<Person> Persons { get; set; }
        public MealPlan MealPlan { get; set; }
    }
}