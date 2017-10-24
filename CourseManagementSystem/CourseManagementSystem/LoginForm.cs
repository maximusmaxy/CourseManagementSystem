﻿using System;
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

        public LoginForm()
        {
            InitializeComponent();
            //VBClass.ShowCredits();
            //Database.ServerName = "MAXIMUMPENIS\\SQLEXPRESS";
            Database.LoadDatabase();
            userControl = ucLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (!Validation.Many(userControl.TxtUsername.ValidateEmpty(), userControl.TxtPassword.ValidateEmpty()))
            {
                return;
            }
            string username = userControl.TxtUsername.Text;
            string password = userControl.TxtPassword.Text;
            if (!Database.Login(username, password))
            {
                MessageBox.Show("Username or password was incorrect.");
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
