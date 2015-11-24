using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sunddk.Utilities {
    public class Calculate {
        public double CalculateBMR(DateTime DateOfBirth, string Gender, double Weight, int Height) {
            double BMR = 0.0;
            int Age = Convert.ToInt16(DateTime.Now.Date.Year) - Convert.ToInt32(DateOfBirth.Year);

            if (Gender == "Mand") {
                BMR = (66.5 + (13.75 * Weight) + (5.003 * Height) - (6.775 * Age)) * 4.186;
                return BMR;
            }
            else {
                BMR = (655.1 + (9.563 * Weight) + (1.850 * Height) - (4.676 * Age)) * 4.186;
                return BMR;
            }
        }
    }
}