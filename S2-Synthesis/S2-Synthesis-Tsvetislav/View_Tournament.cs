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
using Data_Access;
using Models;

namespace S2_Synthesis_Tsvetislav
{
    public partial class View_Tournament : Form
    {
        private Tournament selected;
        private readonly TournamentManager tm;
        private readonly PlayerTournamentManager ptm;
        private readonly UserManager um;
        private List<User> players;
        private Game[] games;
        private readonly GameManager gm;

        private void GetPlayers()
        {
            for(int i = 0; i < games.Length; i++)
            {
                games[i].Player1 = um.FindUserById(games[i].Player1.Id);
                games[i].Player2 = um.FindUserById(games[i].Player2.Id);
            }
        }

        private void FillDGV()
        {
            GetPlayers();
            dataGridView1.Rows.Clear();
            foreach(var game in this.games)
            {
                int rowId = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[rowId];
                row.Cells["ID"].Value = game.Id;
                if(game.Player1 == null)
                {
                    row.Cells["Player1"].Value = "Bye";
                }
                else
                {
                    row.Cells["Player1"].Value = $"{game.Player1.FirstName}  {game.Player1.LastName}";
                }
                if(game.Player2 == null)
                {
                    row.Cells["Player2"].Value = "Bye";
                }
                else
                {
                    row.Cells["Player2"].Value = $"{game.Player2.FirstName}  {game.Player2.LastName}";
                }
                row.Cells["Player1Score"].Value = game.Player1Score;
                row.Cells["Player2Score"].Value = game.Player2Score;
                dataGridView1.Update();
            }
        }
       
        public View_Tournament(Tournament viewTournament)
        {

            this.tm = new(new TournamentData(), new PlayerTournamentData());
            this.ptm = new(new PlayerTournamentData());
            this.gm = new(new GameData());
            this.selected = viewTournament;
            this.players = ptm.GetPlayersForTournament(selected.Id).ToList();
            this.um = new UserManager(new UserData());
            this.games = tm.GetGamesForTournament(selected.Id);
            
            InitializeComponent();
            lblPlayersRegistered.Text = players.Count.ToString();
            lblMaxPlayers.Text = selected.MaxPlayers.ToString();
            lblMinPlayers.Text = selected.MinPlayers.ToString();
            FillDGV();
        }
        
        private void btnGenerateSchedule_Click(object sender, EventArgs e)
        {
            if(dataGridView1.RowCount > 1)
            {
                MessageBox.Show("The schedule for this tournament has already been generated");
            }
            else if(this.selected.Players.Count < this.selected.MinPlayers)
            {
                MessageBox.Show("Too few players are registered for this tournament.");
            }
            else
            {
                selected.Players = this.players;
                tm.ScheduleGamesForTournament(selected.Id);
                this.games = tm.GetGamesForTournament(selected.Id);
                gm.FixByes(this.games);
                FillDGV();
                dataGridView1.Update();
                this.Update();
            }

        }

        private void btnViewGame_Click(object sender, EventArgs e)
        {
            
            int rowIndex = dataGridView1.CurrentRow.Index;
            if (rowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
                if (selectedRow.Cells["ID"].Value == null)
                {
                    MessageBox.Show("Please select an existing game.");
                }
                else
                {
                    int id = Int32.Parse(selectedRow.Cells["ID"].Value.ToString());
                    Game g = gm.GetGame(id);
                    if (g.Player1.Id == 0 || g.Player2.Id == 0)
                    {
                        MessageBox.Show("This player has a bye and therefore cannot be scored.");
                    }
                    else if (gm.IsGameScored(g.Id))
                    {
                        MessageBox.Show("This game has already been scored.");
                    }
                    else
                    {   
                            Score_Game nf = new Score_Game(g, selected);
                            this.Hide();
                            nf.Show();
                    }
                }
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home nf = new Home();
            nf.Show();
        }
    }
}
