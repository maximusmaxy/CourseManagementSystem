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
    public partial class SearchDictionary : UserControl, ISearchControl
    {
        public SearchDictionary()
        {
            InitializeComponent();
            cmbType.DisplayMember = "Display";
            cmbType.ValueMember = "Value";
        }

        public void Reset()
        {
            Forms.ClearControls(this);
        }

        public bool ValidateControl()
        {
            return true;
        }

        public void Append(StringBuilder sb)
        {
            sb.Append(" = ");
            sb.Append(cmbType.Int());
        }
    }
}