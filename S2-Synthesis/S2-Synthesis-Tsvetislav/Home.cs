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
    public partial class Home : Form
    {
        private void FillDGV()
        {
            dgvTournaments.Rows.Clear();
            foreach(Tournament t in tm.GetTournaments())
            {
                int rowId = dgvTournaments.Rows.Add();
                DataGridViewRow row = dgvTournaments.Rows[rowId];
                row.Cells["ID"].Value = t.Id;
                row.Cells["Type"].Value = t.Type;
                row.Cells["Description"].Value = t.Description;
                row.Cells["Location"].Value = t.Location;
            }
        }
        TournamentManager tm;
        public Home()
        {
            this.tm = new TournamentManager(new TournamentData(), null);
            InitializeComponent();
            FillDGV();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.Hide();
            Create_Tournament nf = new Create_Tournament();
            nf.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvTournaments.CurrentRow.Index;
            if(rowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvTournaments.Rows[rowIndex];
                if(selectedRow.Cells["ID"].Value == null)
                {
                    MessageBox.Show("Please select an existing tournament.");
                }
                else
                {
                    int id = Int32.Parse(selectedRow.Cells["ID"].Value.ToString());
                    Update_Tournament nf = new Update_Tournament(tm.FindTournament(id));
                    this.Hide();
                    nf.Show();

                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvTournaments.CurrentRow.Index;
            if(rowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvTournaments.Rows[rowIndex];
                if(selectedRow.Cells["ID"].Value == null)
                {
                    MessageBox.Show("Please select existing tournament");
                }
                else
                {
                    int id = Int32.Parse(selectedRow.Cells["ID"].Value.ToString());
                    if (tm.DeleteTournament(id) is 1)
                    {
                        MessageBox.Show("Deleted successfully");
                        FillDGV();
                    }
                    else
                    {
                        MessageBox.Show("Please select a tournament to delete");
                    }
                }
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvTournaments.CurrentRow.Index;
            if (rowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvTournaments.Rows[rowIndex];
                if (selectedRow.Cells["ID"].Value == null)
                {
                    MessageBox.Show("Please select an existing tournament.");
                }
                else
                {
                    int id = Int32.Parse(selectedRow.Cells["ID"].Value.ToString());
                    View_Tournament nf = new View_Tournament(tm.FindTournament(id));
                    this.Hide();
                    nf.Show();

                }
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            Login nf = new Login();
            nf.Show();
        }
    }
}
