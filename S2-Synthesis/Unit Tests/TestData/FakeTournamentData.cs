using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Interfaces;

namespace Unit_Tests.TestData
{
    public class FakeTournamentData : ITournamentData
    {
        List<Tournament> tournaments;

        public FakeTournamentData()
        {
            this.tournaments = new()
            {
                new Tournament(0, "Badminton", "whatever", DateTime.Now, DateTime.Now.AddDays(2), 5, 10, "here",
                Models.Enums.PlayingSystem.ROUND_ROBIN),
                new Tournament(1, "Badminton", "whatever", DateTime.Now, DateTime.Now.AddDays(2), 10, 20, "here",
                Models.Enums.PlayingSystem.ROUND_ROBIN)
            };
            tournaments[0].Players.Add(new User(0, "First", "123"));
            tournaments[0].Players.Add(new User(1, "Second", "123"));
            tournaments[0].Players.Add(new User(2, "Third", "123"));
            tournaments[0].Players.Add(new User(3, "Fourth", "123"));
            tournaments[0].Players.Add(new User(4, "Fifth", "123"));
            tournaments[0].Players.Add(new User(5, "Sixth", "123"));
        }

        public List<Tournament> GetTournaments() => tournaments;

        public void CreateTournament(Tournament t) => tournaments.Add(t);

        private Tournament GetTournament(int tID) => GetTournaments().Find(x => x.Id == tID);

        public int DeleteTournament(int tID) => tournaments.Remove(GetTournament(tID)) is true ? 1 : 0;

        public Game[] GetGamesForTournament(int tID) => GetTournament(tID).Games.ToArray<Game>();
        
        public void ScheduleGamesForTournament(Game[] arr, int tID)
        {
            Tournament t = GetTournament(tID);
            t.Games = arr.ToList();

        }

        public void UpdateTournament(Tournament t)
        {
            throw new NotImplementedException();
        }
    }
}
