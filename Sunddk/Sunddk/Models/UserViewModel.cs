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
}