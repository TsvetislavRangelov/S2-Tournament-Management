using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Interfaces
{
   public interface IGameData
    {
        void RegisterResultForGame(Game g);
        Game[] GetGames();
        bool IsGameScored(int gID);
        void FixByes(Game[] arr);
    }
}
