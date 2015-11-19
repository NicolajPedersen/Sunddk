using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunddkAPI.Models
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsAdmin { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public PersonMealPlanLine PersonMealPlanLine { get; set; }
        public List<Measurement> Measurements { get; set; }


    }
}