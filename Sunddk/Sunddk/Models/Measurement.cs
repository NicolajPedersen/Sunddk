using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sunddk.Models
{
    public class Measurement
    {
        public int MeasurementId { get; set; }
        public DateTime Date { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double BMR { get; set; }
        public virtual Person Person { get; set; }
        public int PersonId { get; set; }
    }
}