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
        enum Date { Year = 1, Month = 2, Day = 3 }

        public SearchDate()
        {
            InitializeComponent();
            cmbMonth.DisplayMember = "Display";
            cmbMonth.ValueMember = "Value";
            BindingList<Data<int>> monthList = new BindingList<Data<int>>()
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
            cmbMonth.DisplayMember = "Display";
            cmbMonth.ValueMember = "Value";
            cmbMonth.DataSource = monthList;
            cmbMonth2.DisplayMember = "Display";
            cmbMonth2.ValueMember = "Value";
            cmbMonth2.DataSource = new BindingList<Data<int>>(monthList);
        }

        public void Reset()
        {
            Forms.ClearControls(this);
            Forms.CheckRadio(pnlOperator, "Exact Date");
            cmbMonth.SelectedIndex = 0;
        }

        public bool ValidateControl()
        {
            if (!Validation.YearMonthDay(txtYear, cmbMonth, txtDay))
                return false;
            if (rdbBetween.Checked)
            {
                if (!Validation.YearMonthDay(txtYear2, cmbMonth2, txtDay2))
                    return false;
            }
            return true;
        }

        public void Append(StringBuilder sb)
        {
            int lastIndex = sb.ToString().LastIndexOf(' ') + 1;
            string column = sb.ToString(lastIndex, sb.Length - lastIndex);
            sb.Length -= sb.Length - lastIndex;
            sb.Append("(");
            Date date = Date.Year;
            if (cmbMonth.Int() != 0)
                date += 1;
            if (!string.IsNullOrEmpty(txtDay.Text))
                date += 1;
            switch (Forms.RadioString(pnlOperator))
            {
                case "Exact Date":
                    //year equal
                    AppendYear(sb, column);
                    sb.Append(" = ");
                    sb.Append(txtYear.Int());
                    //month equal
                    if (date == Date.Month)
                    {
                        sb.Append(" and ");
                        AppendMonth(sb, column);
                        sb.Append(" = ");
                        sb.Append(cmbMonth.Int());
                    }
                    //day equal
                    if (date == Date.Day)
                    {
                        sb.Append(" and ");
                        AppendMonth(sb, column);
                        sb.Append(" = ");
                        sb.Append(txtDay.Int());
                    }
                    break;
                case "Before":
                    //year less than
                    AppendYear(sb, column);
                    sb.Append(" < ");
                    sb.Append(txtYear.Int());
                    //year equal and month less than
                    if (date == Date.Month)
                    {
                        sb.Append(" or (");
                        AppendYear(sb, column);
                        sb.Append(" = ");
                        sb.Append(txtYear.Int());
                        sb.Append(" and ");
                        AppendMonth(sb, column);
                        sb.Append(" < ");
                        sb.Append(cmbMonth.Int());
                        sb.Append(")");
                    }
                    //year equal, month equal, day less than
                    if (date == Date.Day)
                    {
                        sb.Append(" or (");
                        AppendYear(sb, column);
                        sb.Append(" = ");
                        sb.Append(txtYear.Int());
                        sb.Append(" and ");
                        AppendMonth(sb, column);
                        sb.Append(" = ");
                        sb.Append(cmbMonth.Int());
                        sb.Append(" and ");
                        AppendDay(sb, column);
                        sb.Append(" < ");
                        sb.Append(txtDay.Int());
                        sb.Append(")");
                    }
                    break;
                case "After":
                    //year greater than
                    AppendYear(sb, column);
                    sb.Append(" > ");
                    sb.Append(txtYear.Int());
                    //year equal, month greater than
                    if (date == Date.Month)
                    {
                        sb.Append(" or (");
                        AppendYear(sb, column);
                        sb.Append(" = ");
                        sb.Append(txtYear.Int());
                        sb.Append(" and ");
                        AppendMonth(sb, column);
                        sb.Append(" > ");
                        sb.Append(cmbMonth.Int());
                        sb.Append(")");
                    }
                    //year equal, month equal, day greater than
                    if (date == Date.Day)
                    {
                        sb.Append(" or (");
                        AppendYear(sb, column);
                        sb.Append(" = ");
                        sb.Append(txtYear.Int());
                        sb.Append(" and ");
                        AppendMonth(sb, column);
                        sb.Append(" = ");
                        sb.Append(cmbMonth.Int());
                        sb.Append(" and ");
                        AppendDay(sb, column);
                        sb.Append(" > ");
                        sb.Append(txtDay.Int());
                        sb.Append(")");
                    }
                    break;
                case "On or Before":
                    switch (date)
                    {
                        //year less or equal
                        case Date.Year:
                            AppendYear(sb, column);
                            sb.Append(" <= ");
                            sb.Append(txtYear.Int());
                            break;
                        //year less or year equal and month less than or equal
                        case Date.Month:
                            AppendYear(sb, column);
                            sb.Append(" < ");
                            sb.Append(txtYear.Int());
                            sb.Append(" or (");
                            AppendYear(sb, column);
                            sb.Append(" = ");
                            sb.Append(txtYear.Int());
                            sb.Append(" and ");
                            AppendMonth(sb, column);
                            sb.Append(" <= ");
                            sb.Append(cmbMonth.Int());
                            sb.Append(")");
                            break;
                        //year less or year equal and month less than or year equal, month equal and day less than or equal
                        case Date.Day:
                            AppendYear(sb, column);
                            sb.Append(" < ");
                            sb.Append(txtYear.Int());
                            sb.Append(" or (");
                            AppendYear(sb, column);
                            sb.Append(" = ");
                            sb.Append(txtYear.Int());
                            sb.Append(" and ");
                            AppendMonth(sb, column);
                            sb.Append(" < ");
                            sb.Append(cmbMonth.Int());
                            sb.Append(") or (");
                            AppendYear(sb, column);
                            sb.Append(" = ");
                            sb.Append(txtYear.Int());
                            sb.Append(" and ");
                            AppendMonth(sb, column);
                            sb.Append(" = ");
                            sb.Append(cmbMonth.Int());
                            sb.Append(" and ");
                            AppendDay(sb, column);
                            sb.Append(" <= ");
                            sb.Append(txtDay.Int());
                            sb.Append(")");
                            break;
                    }
                    break;
                case "On or After":
                    switch (date)
                    {
                        //year greater or equal
                        case Date.Year:
                            AppendYear(sb, column);
                            sb.Append(" >= ");
                            sb.Append(txtYear.Int());
                            break;
                        //year greater or year equal and mont greater than or equal
                        case Date.Month:
                            AppendYear(sb, column);
                            sb.Append(" > ");
                            sb.Append(txtYear.Int());
                            sb.Append(" or (");
                            AppendYear(sb, column);
                            sb.Append(" = ");
                            sb.Append(txtYear.Int());
                            sb.Append(" and ");
                            AppendMonth(sb, column);
                            sb.Append(" >= ");
                            sb.Append(cmbMonth.Int());
                            sb.Append(")");
                            break;
                        //year greater or year equal and month greater than or year equal, month equal and day greater than or equal
                        case Date.Day:
                            AppendYear(sb, column);
                            sb.Append(" > ");
                            sb.Append(txtYear.Int());
                            sb.Append(" or (");
                            AppendYear(sb, column);
                            sb.Append(" = ");
                            sb.Append(txtYear.Int());
                            sb.Append(" and ");
                            AppendMonth(sb, column);
                            sb.Append(" > ");
                            sb.Append(cmbMonth.Int());
                            sb.Append(") or (");
                            AppendYear(sb, column);
                            sb.Append(" = ");
                            sb.Append(txtYear.Int());
                            sb.Append(" and ");
                            AppendMonth(sb, column);
                            sb.Append(" = ");
                            sb.Append(cmbMonth.Int());
                            sb.Append(" and ");
                            AppendDay(sb, column);
                            sb.Append(" >= ");
                            sb.Append(txtDay.Int());
                            sb.Append(")");
                            break;
                    }
                    break;
                case "Between":
                    switch (date)
                    {
                        //year between
                        case Date.Year:
                            AppendYear(sb, column);
                            sb.Append(" between ");
                            sb.Append(txtYear.Int());
                            sb.Append(" and ");
                            sb.Append(txtYear2.Int());
                            break;
                        //year between or year1 equal and month1 greater or equal or year2 equal and month2 less than or equal
                        case Date.Month:
                            sb.Append("(");
                            AppendYear(sb, column);
                            sb.Append(" > ");
                            sb.Append(txtYear.Int());
                            sb.Append(" and ");
                            AppendYear(sb, column);
                            sb.Append(" < ");
                            sb.Append(txtYear2.Int());
                            sb.Append(") or (");
                            AppendYear(sb, column);
                            sb.Append(" = ");
                            sb.Append(txtYear.Int());
                            sb.Append(" and ");
                            AppendMonth(sb, column);
                            sb.Append(" >= ");
                            sb.Append(cmbMonth.Int());
                            sb.Append(") or (");
                            AppendYear(sb, column);
                            sb.Append(" = ");
                            sb.Append(txtYear2.Int());
                            sb.Append(" and ");
                            AppendMonth(sb, column);
                            sb.Append(" <= ");
                            sb.Append(cmbMonth2.Int());
                            sb.Append(")");
                            break;
                        //year between or year1 equal and month1 greater or year 1 equal month 1 equal and day1 greater or equal or year2 equal and month 2 less than or year2 equal month2 equal and day less than or equal.
                        case Date.Day:
                            sb.Append("(");
                            AppendYear(sb, column);
                            sb.Append(" > ");
                            sb.Append(txtYear.Int());
                            sb.Append(" and ");
                            AppendYear(sb, column);
                            sb.Append(" < ");
                            sb.Append(txtYear2.Int());
                            sb.Append(") or (");
                            AppendYear(sb, column);
                            sb.Append(" = ");
                            sb.Append(txtYear.Int());
                            sb.Append(" and ");
                            AppendMonth(sb, column);
                            sb.Append(" > ");
                            sb.Append(cmbMonth.Int());
                            sb.Append(") or (");
                            AppendYear(sb, column);
                            sb.Append(" = ");
                            sb.Append(txtYear.Int());
                            sb.Append(" and ");
                            AppendMonth(sb, column);
                            sb.Append(" = ");
                            sb.Append(cmbMonth.Int());
                            sb.Append(" and ");
                            AppendDay(sb, column);
                            sb.Append(" >= ");
                            sb.Append(txtDay.Int());
                            sb.Append(") or (");
                            AppendYear(sb, column);
                            sb.Append(" = ");
                            sb.Append(txtYear2.Int());
                            sb.Append(" and ");
                            AppendMonth(sb, column);
                            sb.Append(" < ");
                            sb.Append(cmbMonth2.Int());
                            sb.Append(") or (");
                            AppendYear(sb, column);
                            sb.Append(" = ");
                            sb.Append(txtYear2.Int());
                            sb.Append(" and ");
                            AppendMonth(sb, column);
                            sb.Append(" = ");
                            sb.Append(cmbMonth2.Int());
                            sb.Append(" and ");
                            AppendDay(sb, column);
                            sb.Append(" <= ");
                            sb.Append(txtDay2.Int());
                            sb.Append(")");
                            break;
                    }
                    break;
            }
            sb.Append(")");
        }

        private void AppendYear(StringBuilder sb, string column)
        {
            sb.Append("year(");
            sb.Append(column);
            sb.Append(")");
        }

        private void AppendMonth(StringBuilder sb, string column)
        {
            sb.Append("month(");
            sb.Append(column);
            sb.Append(")");
        }

        private void AppendDay(StringBuilder sb, string column)
        {
            sb.Append("day(");
            sb.Append(column);
            sb.Append(")");
        }

        private void rdbBetween_CheckedChanged(object sender, EventArgs e)
        {
            txtDay2.Enabled = rdbBetween.Checked;
            cmbMonth2.Enabled = rdbBetween.Checked;
            txtYear2.Enabled = rdbBetween.Checked;
            if (!rdbBetween.Checked)
            {
                txtDay2.Text = string.Empty;
                cmbMonth2.SelectedIndex = 0;
                txtYear2.Text = string.Empty;
            }
        }
    }
}
