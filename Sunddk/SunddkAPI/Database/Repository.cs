using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunddkAPI.Database;
using SunddkAPI.Models;

namespace SunddkAPI.Database
{
    class Repository
    {
        public bool CreateUser(Person person)
        {
            bool isCreated = false;

            List<Person> PersonList = DataMapper.GetUsers();

            foreach (Person p in PersonList)
            {
                if(p.Email != person.Email)
                {
                    DataMapper.CreateUser(person);
                    isCreated = true;
                }
            }
            return isCreated;
        }
    }
}
