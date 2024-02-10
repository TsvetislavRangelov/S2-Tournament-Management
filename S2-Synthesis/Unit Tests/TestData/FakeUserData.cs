using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Logic;
using Interfaces;
using Models;

namespace Unit_Tests.TestData
{
    
   public class FakeUserData : IUserData
    {
        private List<User> users;
        public FakeUserData()
        {
            this.users = new List<User>
            {
                 new User(0, "Test1", "123"),
                 new User(1, "Test2", "abc"),
                 new User(2, "Test3", "abc"),
                 new User(3, "Test4", "123")
            };
        }

        public void RegisterUser(User u) => users.Add(u);

        public List<User> GetUsers() => this.users;



    }
}

