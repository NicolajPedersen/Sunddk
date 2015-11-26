using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SunddkAPI;
using SunddkAPI.Models;

namespace Unittests
{
    [TestClass]
    public class APITest
    {
        // Integration test
        [TestMethod]
        public void TestCreatePerson()
        {
            SunddkAPI.Controllers.PersonController controller = new SunddkAPI.Controllers.PersonController(); // nyt objekt
            Person p = new Person() { Name = "Testo", DateOfBirth = Convert.ToDateTime("2001-01-01"), IsAdmin = false, Gender = "Mand", Email = "test@live.dk", Password = "Test123" };
            p.Measurements = new System.Collections.Generic.List<Measurement>();
            p.Measurements.Add(new Measurement() { Date = DateTime.Now, Weight = 90, Height = 175, BMR = 1000 });
            bool isCreated = controller.CreateUser(p);
            Assert.AreEqual(true, isCreated);
            SunddkAPI.Database.DataMapper.DeleteUser("test@live.dk");

        }
    }
}
