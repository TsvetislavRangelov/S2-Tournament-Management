using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;

namespace Interfaces
{
   public interface ITournamentData
    {
        List<Tournament> GetTournaments();
        void CreateTournament(Tournament t);
        void UpdateTournament(Tournament t);
        int DeleteTournament(int tID);
        void ScheduleGamesForTournament(Game[] arr, int tID);
        Game[] GetGamesForTournament(int tID);
        
    }
}
