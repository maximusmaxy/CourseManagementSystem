using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CmsLibrary
{
    public interface ILoginControl
    {
        TextBox TxtUsername { get; }
        TextBox TxtPassword { get; }
        TextBox TxtConfirmPassword { get; }
    }
}
