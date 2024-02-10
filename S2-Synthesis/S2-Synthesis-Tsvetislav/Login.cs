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
    public partial class Login : Form
    {
        private StaffManager sm;
        public Login()
        {
            this.sm = new StaffManager(new StaffData());
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            Staff newLogin = new();
            string username = tbxUsername.Text;
            string password = tbxPassword.Text;
            newLogin.Username = username;
            newLogin.Password = password;

            if (sm.LoginStaff(newLogin))
            {
                this.Hide();
                Home nf = new Home();
                nf.Show();
            }
            else
            {
                MessageBox.Show("Incorrect credentials.");
            }
        }
    }
}
