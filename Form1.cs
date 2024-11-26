using prjloginmetlagenoefenenenenenen.DA;
using prjloginmetlagenoefenenenenenen.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjloginmetlagenoefenenenenenen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login L = new Login();
            L.Username = txtGebruikersnaam.Text;
            L.Password = txtWachtwoord.Text;

            LoginDA.LoginValidation(L);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Login L = new Login();
            L.Username = txtGebruikersnaam.Text;
            L.Password = txtWachtwoord.Text;

            LoginDA.AddUser(L);
        }

        private void btnWijzig_Click(object sender, EventArgs e)
        {
            Login L = new Login();
            L.Username = txtGebruikersnaam.Text;
            L.Password = txtWachtwoord.Text;

            LoginDA.ChangePass(L, txtNewPass.Text);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Login L = new Login();
            L.Username = txtGebruikersnaam.Text;
            L.Password = txtWachtwoord.Text;

            LoginDA.Delete(L);
        }
    }
}
