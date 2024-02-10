using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using Business_Logic;
using Data_Access;
using Models.Enums;


namespace S2_Synthesis_Tsvetislav
{
    public partial class Update_Tournament : Form
    {

        private readonly TournamentManager tm;
        private Tournament selected;
        PlayingSystem[] systems =
{
            PlayingSystem.ROUND_ROBIN
        };
        private void AddSystem()
        {
            for (int i = 0; i < systems.Length; i++)
            {
                cbSystem.Items.Add(systems[i]);
            }
        }

        public Update_Tournament(Tournament updatedTournament)
        {

            this.selected = updatedTournament;
            this.tm = new(new TournamentData(), null);
            InitializeComponent();
            AddSystem();
            cbSystem.SelectedItem = systems[0];

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
                selected.Type = tbxType.Text;
                selected.Description = tbxDescription.Text;
                selected.StartDate = dtpStart.Value;
                selected.EndDate = dtpEnd.Value;
                selected.Location = tbxLocation.Text;
                selected.MaxPlayers = Int32.Parse(tbxMaxPlayers.Text);
                selected.MinPlayers = Int32.Parse(tbxMinPlayers.Text);
                selected.PlayingSystem = (PlayingSystem)Enum.Parse(typeof(PlayingSystem), cbSystem.SelectedItem.ToString());
                tm.UpdateTournament(selected);
                MessageBox.Show("Tournament updated.");
        }
    }
}
