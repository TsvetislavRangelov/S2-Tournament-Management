using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Game
    {
        public int Id { get; set; }
        public int TournamentID { get; set; }
        public User Player1 { get; set; }
        public User Player2 { get; set; }
        public User Winner { get; set; }
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }

        public Game(User p1, User p2)
        {
            this.Player1 = p1;
            this.Player2 = p2;
        }

        public Game() 
        {
            this.Player1 = new User();
            this.Player2 = new User();
            this.Winner = new User();

        }
    }
}
