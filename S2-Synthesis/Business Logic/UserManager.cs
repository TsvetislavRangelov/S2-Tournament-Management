using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Interfaces;

namespace Business_Logic
{
    public class UserManager
    {
        private readonly PasswordManager pm;
        private readonly IUserData src;

        public UserManager(IUserData src)
        {
            this.src = src;
            this.pm = new PasswordManager();
        }

        public void RegisterUser(User u) => this.src.RegisterUser(u);

        public User LoginUser(string email, string password)
        {

            User found = FindUser(email);
            if (found is null) return null;
            return pm.Verify(password, found.Password) is true ? found : null;
        }

        public User FindUser(string email)
        {
            User found = GetUsers().Find(x => x.Email == email);
            if (found is not null) return found;
            return null;
        }

        public User FindUserById(int id)
        {
            User found = GetUsers().Find(x => x.Id == id);
            return found is null ? null : found;
        }

        public List<User> GetUsers() => this.src.GetUsers();
    }
}
