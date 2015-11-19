using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sunddk.Models
{
    public class PersonMealPlan
    {
        [Key]
        public int PersonMealPlanId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public virtual MealPlan MealPlan { get; set; }
        public virtual Person Person { get; set; }
    }
}