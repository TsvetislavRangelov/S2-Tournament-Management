using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business_Logic;

namespace Unit_Tests
{
    [TestClass]
   public class PasswordsTest
    {
        [TestMethod]
        public void TestPasswordHash()
        {
            PasswordManager pm = new();

            string hash = pm.HashPassword("123");

            Assert.AreEqual(60, hash.Length);
        }

        [TestMethod]
        public void TestVerifyHash()
        {
            PasswordManager pm = new();

            string hash = pm.HashPassword("123");
            bool result = pm.Verify("123", hash);

            Assert.AreEqual(true, result);
        }
    }
}
