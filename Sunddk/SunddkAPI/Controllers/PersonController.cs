using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SunddkAPI.Models;
using SunddkAPI.Database;

namespace SunddkAPI.Controllers
{
    public class PersonController : ApiController
    {
        Repository respo; 
        [HttpPost]
        public bool CreateUser(string name, DateTime dateOfBirth, bool isAdmin, string gender, string email, string password, DateTime date, double weight, int height, double bmr)
        {
            Person person = new Person();
            person.Name = name;
            person.DateOfBirth = dateOfBirth;
            person.IsAdmin = isAdmin;
            person.Gender = gender;
            person.Email = email;
            person.Password = password;
            person.Measurements.Add(new Measurement());
            person.Measurements[0].Date = date;
            person.Measurements[0].Weight = weight;
            person.Measurements[0].Height = height;
            person.Measurements[0].BMR = bmr;

            respo = new Repository();
            return respo.CreateUser(person);
             
        }
    }
}
