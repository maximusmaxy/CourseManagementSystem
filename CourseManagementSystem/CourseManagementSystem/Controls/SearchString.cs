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
    public partial class SearchString : UserControl, ISearchControl
    {
        public SearchString()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            Forms.ClearControls(this);
            Forms.CheckRadio(pnlOperator, "Exact Match");
        }

        public bool ValidateControl()
        {
            if (!Validation.Empty(txtString))
                return false;
            return true;
        }

        public void Append(StringBuilder sb)
        {
            switch (Forms.RadioString(pnlOperator))
            {
                case "Exact Match":
                    sb.Append(" = '");
                    sb.Append(txtString.Text);
                    sb.Append("'");
                    break;
                case "Partial Match":
                    sb.Append(" like '%");
                    sb.Append(txtString.Text);
                    sb.Append("%'");
                    break;
                case "Exclude":
                    sb.Append(" != '");
                    sb.Append(txtString.Text);
                    sb.Append("'");
                    break;
            }
        }
    }
}
