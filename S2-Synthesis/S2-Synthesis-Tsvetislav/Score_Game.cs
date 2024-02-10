using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Logic;
using Models;
using Data_Access;

namespace S2_Synthesis_Tsvetislav
{
    public partial class Score_Game : Form
    {
        private Game selected;
        private readonly GameManager gm;
        private readonly UserManager um;
        private readonly TournamentManager tm;
        private Tournament selectedTournament;

        private void GetPlayers()
        {
            this.selected.Player1 = um.FindUserById(this.selected.Player1.Id);
            this.selected.Player2 = um.FindUserById(this.selected.Player2.Id);
        }
        
        public Score_Game(Game selected, Tournament selectedTournament)
        {
            this.gm = new(new GameData());
            this.um = new(new UserData());
            this.tm = new(new TournamentData(), null);
            this.selected = selected;
            this.selectedTournament = selectedTournament;
            
            InitializeComponent();
            GetPlayers();
            lblPlayer1.Text = $"{this.selected.Player1.FirstName} { this.selected.Player1.LastName}";
            lblPlayer2.Text = this.selected.Player2.FirstName + " " + this.selected.Player2.LastName;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                int p1 = Int32.Parse(tbxScore1.Text);
                int p2 = Int32.Parse(tbxScore2.Text);
                if(p1 < p2 && p2 == 21 && selectedTournament.Type == "Badminton")
                {
                    this.selected.Winner = this.selected.Player2;
                    this.selected.Player1Score = p1;
                    this.selected.Player2Score = p2;
                    this.selected.Winner.Wins += 1;
                    gm.RegisterResultForGame(this.selected);
                    MessageBox.Show(this.selected.Player2.FirstName + " " +  this.selected.Player2.LastName + " " + "Wins!");
                }
                else if(p2 < p1 && p1 == 21 && selectedTournament.Type == "Badminton")
                {
                    this.selected.Winner = this.selected.Player1;
                    this.selected.Player1Score = p1;
                    this.selected.Player2Score = p2;
                    this.selected.Winner.Wins += 1;
                    gm.RegisterResultForGame(this.selected);
                    MessageBox.Show(this.selected.Player1.FirstName + " " + this.selected.Player1.LastName + " " + "Wins!");
                }
                else if(p1 == 0 && p2 == 1 && selectedTournament.Type == "Chess")
                {
                    this.selected.Winner = this.selected.Player1;
                    this.selected.Player1Score = p1;
                    this.selected.Player2Score = p2;
                    this.selected.Winner.Wins += 1;
                    gm.RegisterResultForGame(this.selected);
                    MessageBox.Show(this.selected.Player2.FirstName + " " + this.selected.Player2.LastName + " " + "Wins!");
                }
                else if(p1 == 1 && p2 == 0 && selectedTournament.Type == "Chess")
                {
                    this.selected.Winner = this.selected.Player1;
                    this.selected.Player1Score = p1;
                    this.selected.Player2Score = p2;
                    this.selected.Winner.Wins += 1;
                    gm.RegisterResultForGame(this.selected);
                    MessageBox.Show(this.selected.Player1.FirstName + " " + this.selected.Player1.LastName + " " + "Wins!");
                }
                else
                {
                    MessageBox.Show($"The scores must follow the {selectedTournament.Type} regulations.");
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Please enter valid scores");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            View_Tournament nf = new View_Tournament(tm.FindTournament(selected.TournamentID));
            nf.Show();

        }
    }
}
