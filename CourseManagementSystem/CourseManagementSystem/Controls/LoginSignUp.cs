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
    public partial class LoginSignUp : UserControl, ILoginControl
    {
        public LoginSignUp()
        {
            InitializeComponent();
        }

        public TextBox TxtUsername => txtUsername;
        public TextBox TxtPassword => txtPassword;
        public TextBox TxtConfirmPassword => txtConfirmPassword;
    }
}
