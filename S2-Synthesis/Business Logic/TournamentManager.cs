using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Interfaces;
using System.Data;

namespace Business_Logic
{
    public class TournamentManager
    {
        private readonly ITournamentData src;
        private readonly IPlayerTournamentData playerSrc;

        public TournamentManager(ITournamentData src, IPlayerTournamentData playerSrc)
        {
            this.src = src;
            this.playerSrc = playerSrc;
        }

        public List<Tournament> GetTournaments() => this.src.GetTournaments();

        public void CreateTournament(Tournament t) => this.src.CreateTournament(t);

        public int DeleteTournament(int tID) => this.src.DeleteTournament(tID);

        public void UpdateTournament(Tournament t) => this.src.UpdateTournament(t);

        public Tournament GetTournament(int id)
        {
            Tournament found = GetTournaments().Find(x => x.Id == id);
            return found is null ? null : found;
        }

        private Game[] ScheduleGames(Tournament t)
        {
            User[] players = playerSrc.GetPlayersForTournament(t.Id);
            t.Players = players.ToList();
            List<Game> games = new();
            int maxRounds = t.Players.Count - 1;
            int rounds = 0;
            if (t.Players.Count < t.MinPlayers) return Array.Empty<Game>();

            while (rounds < maxRounds)
            {
                User temp;
                User[] tempList = new User[t.Players.Count];
                t.Players.CopyTo(tempList);
                List<User> secondList = tempList.ToList();
                if(secondList.Count % 2 != 0)
                {
                   secondList = secondList.Append(new User(0, "Bye", "123")).ToList();
                }
                for (int i = 0; i < rounds; i++)
                {
                    temp = secondList.Last();
                    secondList.Remove(secondList.Last());
                    secondList.Insert(1, temp);

                }
                while (secondList.Count > 1)
                {
                    games.Add(new Game(secondList.First(), secondList.Last()));
                    secondList.Remove(secondList.Last());
                    secondList.Remove(secondList.First());

                }
                rounds++;
            }
            return games.ToArray();
        }

        public void ScheduleGamesForTournament(int tID)
        {
            Game[] games = ScheduleGames(FindTournament(tID));
            this.src.ScheduleGamesForTournament(games, tID);
        }

        public Game[] GetGamesForTournament(int tID) => this.src.GetGamesForTournament(tID);

        public Tournament FindTournament(int tID) => GetTournaments().Find(x => x.Id == tID);

        public List<int> GetWinnersForTournament(int tID)
        {

            List<int> winners = new();
            foreach (Game g in GetGamesForTournament(tID))
            {
                if(g.Winner.Id == 0 || g.Winner == null)
                {
                    return null;
                }
                winners.Add(g.Winner.Id);
            }
            var topWinners = winners.GroupBy(i => i).OrderByDescending(grp => grp.Count())
      .Select(grp => grp.Key).Take(3);
            return topWinners.ToList();

        }
    }
}
