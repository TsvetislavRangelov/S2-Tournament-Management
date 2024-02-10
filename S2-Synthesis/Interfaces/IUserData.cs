using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Interfaces
{
   public interface IUserData
    {
        void RegisterUser(User u);
        List<User> GetUsers();
        //int[] GetUsersForGames(int tID);
        //User[] GetPlayersForGames(int[] ids);
    }
}
