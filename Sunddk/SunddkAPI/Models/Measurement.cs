using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunddkAPI.Models
{
    public class Measurement
    {
        public DateTime Date { get; set; }
        public double Weight { get; set; }
        public int Height { get; set; }
        public double BMR { get; set; }
        public Person Person { get; set; }


    }
}