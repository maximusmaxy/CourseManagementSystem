using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CmsLibrary;

namespace CMS
{
    public partial class LoginLogin : UserControl, ILoginControl
    {
        public LoginLogin()
        {
            InitializeComponent();
        }

        public TextBox TxtUsername => txtUsername;
        public TextBox TxtPassword => txtPassword;
        public TextBox TxtConfirmPassword => null;
    }
}
