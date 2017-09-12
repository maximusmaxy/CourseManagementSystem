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
            cmbValue.DisplayMember = "Display";
            cmbValue.ValueMember = "Value";
        }

        public void Reset()
        {
            Forms.ClearControls(this);
        }

        public void ValidateControl()
        {
            throw new NotImplementedException();
        }
    }
}
