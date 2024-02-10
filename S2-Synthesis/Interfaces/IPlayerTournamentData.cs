using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Interfaces
{
   public interface IPlayerTournamentData
    {
        void RegisterPlayerForTournament(int tID, int uID);
        void ExitTournament(int tID, int uID);
        User[] GetPlayersForTournament(int tID);
        bool IsPlayerRegisteredForTournament(int tID, int uID);
        int GetPlayerCountForTournament(int tID);
        Tournament[] GetTournamentsForPlayer(int uID);
    }
}
