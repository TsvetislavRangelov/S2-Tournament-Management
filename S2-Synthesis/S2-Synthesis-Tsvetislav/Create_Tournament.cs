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
using Models.Enums;

namespace S2_Synthesis_Tsvetislav
{
    public partial class Create_Tournament : Form
    {
        private void AddSystem()
        {
            for(int i = 0; i< systems.Length; i++)
            {
                cbSystem.Items.Add(systems[i]);
            }
        }
        PlayingSystem[] systems =
        {
            PlayingSystem.ROUND_ROBIN
        };

        private readonly TournamentManager tm;
        public Create_Tournament()
        {
            this.tm = new(new TournamentData(), null);
            InitializeComponent();
            AddSystem();
            cbSystem.SelectedItem = systems[0];

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Tournament t = new Tournament();
            try
            {
                t.Type = comboBox1.SelectedItem.ToString();
                t.Description = tbxDescription.Text;
                t.StartDate = dtpStart.Value;
                t.EndDate = dtpEnd.Value;
                t.MinPlayers = Int32.Parse(tbxMinPlayers.Text);
                t.MaxPlayers = Int32.Parse(tbxMaxPlayers.Text);
                t.Location = tbxLocation.Text;
                t.PlayingSystem = (PlayingSystem)Enum.Parse(typeof(PlayingSystem), cbSystem.SelectedItem.ToString());
                tm.CreateTournament(t);
                MessageBox.Show("Tournament created successfully");

            }
            catch (System.FormatException)
            {
                MessageBox.Show("One of the fields are invalid, please try again.");
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
