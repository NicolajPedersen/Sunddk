using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SunddkAPI;

namespace Unittests
{
    [TestClass]
    public class APITest
    {
        [TestMethod]
        public void TestCreatePerson()
        {
            SunddkAPI.Controllers.PersonController controller = new SunddkAPI.Controllers.PersonController();
            bool isCreated = controller.CreateUser("Testo", Convert.ToDateTime("2001-01-01"), false, "Mand", "test@live.dk", "Test123", DateTime.Now, 90, 175, 1000);
            Assert.AreEqual(true, isCreated);
            SunddkAPI.Database.DataMapper.DeleteUser("test@live.dk");

        }
    }
}
