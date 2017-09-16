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
    public partial class SearchInt : UserControl, ISearchControl
    {
        public SearchInt()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            Forms.ClearControls(this);
            Forms.CheckRadio(pnlOperator, "Equal To");
        }

        public bool ValidateControl()
        {
            if (!Validation.Numeric(txtValue) || (rdbBetween.Checked && !Validation.Numeric(txtValue2)))
                return false;
            return true;
        }

        public void Append(StringBuilder sb)
        {
            switch (Forms.RadioString(pnlOperator))
            {
                case "Equal To":
                    sb.Append(" = ");
                    sb.Append(txtValue.Int());
                    break;
                case "Less Than":
                    sb.Append(" < ");
                    sb.Append(txtValue.Int());
                    break;
                case "Greater Than":
                    sb.Append(" > ");
                    sb.Append(txtValue.Int());
                    break;
                case "Or Less":
                    sb.Append(" <= ");
                    sb.Append(txtValue.Int());
                    break;
                case "Or More":
                    sb.Append(" >= ");
                    sb.Append(txtValue.Int());
                    break;
                case "Between":
                    sb.Append(" between ");
                    sb.Append(txtValue.Int());
                    sb.Append(" and ");
                    sb.Append(txtValue2.Int());
                    break;
            }
        }

        private void rdbBetween_CheckedChanged(object sender, EventArgs e)
        {
            txtValue2.Enabled = rdbBetween.Checked;
            if (!rdbBetween.Checked)
                txtValue2.Text = string.Empty;
        }
    }
}
