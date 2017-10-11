using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CmsLibrary;

namespace CMS
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            //Database.ServerName = "MAXIMUMPENIS\\SQLEXPRESS";
         //  Database.LoadDatabase();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!Validation.Many(txtUsername.ValidateEmpty(), txtPassword.ValidateEmpty()))
            {
                return;
            }
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (!Database.Login(username, password))
            {
                MessageBox.Show("Username or password was incorrect.");
                return;
            }
            Forms.ShowForm(typeof(MainForm));
            Close();
        }
    }
}
