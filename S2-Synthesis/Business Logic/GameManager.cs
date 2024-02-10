using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Models;

namespace Business_Logic
{
    public class GameManager
    {
        private readonly IGameData src;

        public GameManager(IGameData src) => this.src = src;

        public Game[] GetGames() => this.src.GetGames();

        public void RegisterResultForGame(Game g) => this.src.RegisterResultForGame(g);

        public Game GetGame(int gID)
        {
            foreach(Game g in GetGames())
            {
                if (g.Id == gID) return g;
            }
            return null;
            
        }

        public bool IsGameScored(int gID) => this.src.IsGameScored(gID);
        public void FixByes(Game[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Player1.Id == 0)
                {
                    arr[i].Winner = arr[i].Player2;
                }
                else if (arr[i].Player2.Id == 0)
                {
                    arr[i].Winner = arr[i].Player1;
                }
            }
            this.src.FixByes(arr);
        }
    }
}
