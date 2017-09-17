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
    public partial class SearchBool : UserControl, ISearchControl
    {
        public SearchBool()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            Forms.ClearControls(this);
            Forms.CheckRadio(pnlOperator, "Yes");
        }

        public bool ValidateControl()
        {
            return true;
        }

        public void Append(StringBuilder sb)
        {
            switch (Forms.RadioString(pnlOperator))
            {
                case "Yes":
                    sb.Append(" = 1 ");
                    break;
                case "No":
                    sb.Append(" = 0");
                    break;
            }
        }
    }
}
