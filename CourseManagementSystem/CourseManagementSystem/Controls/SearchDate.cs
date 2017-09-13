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
    public partial class SearchDate : UserControl, ISearchControl
    {
        public SearchDate()
        {
            InitializeComponent();
            cmbMonth.DisplayMember = "Display";
            cmbMonth.ValueMember = "Value";
            cmbMonth.DataSource = new BindingList<Data<int>>()
            {
                new Data<int>("(Not Selected)", 0),
                new Data<int>("January", 1),
                new Data<int>("February", 2),
                new Data<int>("March", 3),
                new Data<int>("April", 4),
                new Data<int>("May", 5),
                new Data<int>("June", 6),
                new Data<int>("July", 7),
                new Data<int>("August", 8),
                new Data<int>("September", 9),
                new Data<int>("October", 10),
                new Data<int>("November", 11),
                new Data<int>("December", 12)
            };
        }

        public void Reset()
        {
            Forms.ClearControls(this);
            Forms.CheckRadio(pnlOperator, "Equal To");
            cmbMonth.SelectedIndex = 0;
        }

        public void ValidateControl()
        {
            throw new NotImplementedException();
        }
    }
}
