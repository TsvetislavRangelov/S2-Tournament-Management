using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Interfaces;

namespace Unit_Tests.TestData
{
   public class FakeGameData : IGameData
    {
        private readonly List<Game> games;

        public FakeGameData()
        {
            this.games = new()
            {
                new Game(new User(0, "Whatever", "123"), new User(1, "whatever", "123")),
                 new Game(new User(2, "Whatever", "123"), new User(3, "whatever", "123")),
                  new Game(new User(4, "Whatever", "123"), new User(5, "whatever", "123")),
                   new Game(new User(6, "Whatever", "123"), new User(7, "whatever", "123"))
            };
        }

        public Game[] GetGames() => this.games.ToArray();

        public Game GetGame(int gID) => this.games.Find(x => x.Id == gID);

        public bool IsGameScored(int gID)
        {
            Game scored = GetGame(gID);
            return scored.Winner is not null;
        }

        public void RegisterResultForGame(Game g)
        {
            int index = this.games.FindIndex(0, 4, x => x.Id == g.Id);
            this.games[index].Player1Score = g.Player1Score;
            this.games[index].Player2Score = g.Player2Score;
            this.games[index].Winner = g.Winner;
        }

        public void FixByes(Game[] arr) => throw new NotImplementedException();
        


    }
}
