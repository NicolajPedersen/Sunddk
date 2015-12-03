﻿using System;
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
        //CM06 #FB02
        Repository respo;
        [HttpPost]
        public bool CreateUser([FromBody] Person person)
        {
            respo = new Repository();
            return respo.CreateUser(person);

        }
        //hej
        //Bruges til WPF testing!
        //[HttpPost]
        //public void POSTTest([FromBody] Person person)
        //{
        //    DataMapper.Test(person.Name);
        //}

    }
}
