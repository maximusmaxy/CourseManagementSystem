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
using VBProject;

namespace CMS
{
    public partial class LoginForm : Form
    {
        private ILoginControl userControl;
        private int attempts;

        public LoginForm()
        {
            InitializeComponent();
            userControl = ucLogin;
            attempts = 0;
#if !DEBUG
            userControl.TxtUsername.Text = string.Empty;
            userControl.TxtPassword.Text = string.Empty;
#endif
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (attempts >= 5)
            {
                MessageBox.Show("You have entered an incorrect username or password too many times. Please see an administrator.");
                return;
            }
            if (!Validation.Many(userControl.TxtUsername.ValidateEmpty(), userControl.TxtPassword.ValidateEmpty()))
            {
                return;
            }
            string username = userControl.TxtUsername.Text;
            string password = userControl.TxtPassword.Text;
            if (!Database.Login(username, password))
            {
                MessageBox.Show("Username or password was incorrect.");
                attempts++;
                return;
            }
            Forms.ShowForm(typeof(MainForm));
            Close();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented Yet.");
        }
    }
}
