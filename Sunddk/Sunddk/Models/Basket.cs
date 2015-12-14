using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sunddk.Models {
    public class Basket {
        [Key]
        public int BasketId { get; set; }
        public int MealId { get; set; }
        public int PersonId { get; set; }
        //[ForeignKey("MealId")]
        public virtual Meal Meal { get; set; }
        //[ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
    }
}