using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Business_Logic;

namespace Unit_Tests
{
    [TestClass]
   public class UserTest
    {
        [TestMethod]
        public void TestRegisterUser()
        {
            User testUser = new User(0, "Test", "123");
            UserManager um = new(new FakeUserData());


            um.RegisterUser(testUser);
            int count = um.GetUsers().Count;


            Assert.AreEqual(5, count);
        }

        [TestMethod]
        public void TestGetUsers()
        {
            UserManager um = new(new FakeUserData());


            List<User> users = um.GetUsers();

            Assert.AreEqual(4, users.Count);
        }

        [TestMethod]
        public void TestFindUserById()
        {
            UserManager um = new(new FakeUserData());

            User found = um.FindUserById(1);

            Assert.AreEqual(1, found.Id);
        }

    }
}
