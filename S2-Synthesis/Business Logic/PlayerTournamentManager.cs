using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Interfaces;

namespace Business_Logic
{
   public class PlayerTournamentManager
    {
        private readonly IPlayerTournamentData src;

        public PlayerTournamentManager(IPlayerTournamentData src) => this.src = src;

        public void RegisterPlayerForTournament(int tID, int uID) => this.src.RegisterPlayerForTournament(tID, uID);

        public void ExitTournament(int tID, int uID) => this.src.ExitTournament(tID, uID);

        public User[] GetPlayersForTournament(int tID) => this.src.GetPlayersForTournament(tID);

        public bool IsPlayerRegisteredForTournament(int tID, int uID) => this.src.IsPlayerRegisteredForTournament(tID, uID);

        public int GetPlayerCountForTournament(int tID) => this.src.GetPlayerCountForTournament(tID);

        public Tournament[] GetTournamentsForPlayer(int uID) => this.src.GetTournamentsForPlayer(uID);

       
    }
}
