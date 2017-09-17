using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using CmsLibrary;
using System.Data.SqlClient;

namespace CMS
{
    public partial class GlobalSearchForm : Form
    {
        private class Table
        {
            public string Name { get; }
            public Type Form { get; }
            public List<Column> Columns { get; }
            public List<Column> GroupBy { get; }

            public string Display => Name;
            public Table Value => this;

            public Table(string name, Type form)
            {
                Name = name;
                Form = form;
                Columns = new List<Column>();
                foreach (SqlDataReader row in Database.StoredProcedure(
                    "sp_columns", new SqlParameter("@table_name", name))) {
                    Columns.Add(new Column(
                        (string)row["COLUMN_NAME"],
                        Extensions.CamelToHuman((string)row["COLUMN_NAME"]),
                        Extensions.DatabaseType((string)row["TYPE_NAME"])));
                }
                GroupBy = new List<Column> { new Column(null, "(Not Selected)", null) };
                GroupBy.AddRange(Columns);
            }

            public void AddDictionary(string columnName, Dictionary<string, int> dictionary)
            {
                Column column = Columns.First(c => c.Name.Equals(columnName, StringComparison.InvariantCultureIgnoreCase));
                column.Dictionary = new List<Data<int>>(dictionary.Select((kvp) => new Data<int>(kvp.Key, kvp.Value)).ToList());
                column.DataType = typeof(Dictionary<string, int>);
            }
        }

        private class Column
        {
            public string Name { get; }
            public string Display { get; }
            public Type DataType { get; set; }
            public List<Data<int>> Dictionary { get; set; }

            public Column Value => this;

            public Column(string name, string display, Type dataType)
            {
                Name = name;
                Display = display;
                DataType = dataType;
            }
        }

        private List<Table> tables;
        private Dictionary<Type, UserControl> userControls;
        private UserControl ucSearch;

        private StringBuilder select;
        private StringBuilder sb;
        private StringBuilder groupBy;

        public GlobalSearchForm()
        {
            InitializeComponent();
            select = new StringBuilder();
            sb = new StringBuilder();
            groupBy = new StringBuilder();
            LoadTables();
            LoadControls();
            cmbColumns.DisplayMember = "Display";
            cmbColumns.ValueMember = "Value";
            cmbTables.DisplayMember = "Display";
            cmbTables.ValueMember = "Value";
            cmbGroupBy.DisplayMember = "Display";
            cmbGroupBy.ValueMember = "Value";
            cmbTables.DataSource = tables;
        }

        private void LoadTables()
        {
            tables = new List<Table>();
            Table table = new Table("Students", typeof(StudentForm));
            table.AddDictionary("studentGender", Types.GenderType);
            tables.Add(table);
            table = new Table("Enrolments", typeof(EnrolmentForm));
            table.AddDictionary("semester", Types.Semester);
            table.AddDictionary("results", Types.CourseResults);
            tables.Add(table);
            table = new Table("Teachers", typeof(TeacherForm));
            tables.Add(table);
            table = new Table("Courses", typeof(CourseForm));
            table.AddDictionary("courseDeliveryType", Types.DeliveryType);
            tables.Add(table);
            table = new Table("Units", typeof(UnitForm));
            table.AddDictionary("unitType", Types.UnitType);
            tables.Add(table);
            table = new Table("Assessments", typeof(AssessmentForm));
            tables.Add(table);
            table = new Table("Skills", typeof(SkillsForm));
            tables.Add(table);
            AddLookUpTable("departments", "departmentname", "departmentid");
        }

        private void AddLookUpTable(string tableName, string display, string value)
        {
            List<Data<int>> dictionary = new List<Data<int>>();
            foreach (SqlDataReader row in Database.ExecuteQuery(
                $"select {display} as Display, {value} as Value from {tableName}"))
            {
                dictionary.Add(new Data<int>((string)row["Display"], Convert.ToInt32(row["Value"])));
            }
            foreach (Table table in tables)
            {
                Column column = table.Columns.FirstOrDefault(c => c.Name.Equals(value, StringComparison.InvariantCultureIgnoreCase));
                if (column != null)
                {
                    column.DataType = typeof(Dictionary<string, int>);
                    column.Dictionary = dictionary;
                }   
            }
        }

        private void LoadControls()
        {
            userControls = new Dictionary<Type, UserControl>();
            ucSearch = searchInt;
            userControls[typeof(int)] = searchInt;
            AddUserControl(typeof(SearchDate), typeof(DateTime));
            AddUserControl(typeof(SearchBool), typeof(bool));
            AddUserControl(typeof(SearchCost), typeof(double));
            AddUserControl(typeof(SearchString), typeof(string));
            AddUserControl(typeof(SearchDictionary), typeof(Dictionary<string, int>));
        }

        private void AddUserControl(Type controlType, Type dataType)
        {
            UserControl control = (UserControl)Activator.CreateInstance(controlType);
            control.Location = ucSearch.Location;
            control.Name = ucSearch.Name;
            control.Size = ucSearch.Size;
            control.TabIndex = ucSearch.TabIndex;
            control.Hide();
            Controls.Add(control);
            userControls[dataType] = control;
        }

        private void ChangeUserControl(Type type)
        {
            ucSearch.Hide();
            ucSearch = userControls[type];
            ((ISearchControl)ucSearch).Reset();
            if (ucSearch is SearchDictionary)
            {
                SearchDictionary control = (SearchDictionary)ucSearch;
                control.cmbType.DataSource = cmbColumns.Get<Column>().Dictionary;
                control.lblType.Text = $"{cmbColumns.Get<Column>().Display}:";
            }
            ucSearch.Show();
        }

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbColumns.DataSource = cmbTables.Get<Table>().Columns;
            cmbGroupBy.DataSource = cmbTables.Get<Table>().GroupBy;
        }

        private void cmbColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeUserControl(cmbColumns.Get<Column>().DataType);
        }

        private void btnNewSearch_Click(object sender, EventArgs e)
        {
            if (!Validation.Many(ucSearch))
                return;
            sb.Clear();
            AppendSelect();
            AppendFrom();
            AppendWhere();
            AppendGroupBy();
            string debug = sb.ToString();
            LoadDataGridViews();
        }

        private void btnAddSearch_Click(object sender, EventArgs e)
        {
            if (sb.Length == 0)
            {
                btnNewSearch_Click(sender, e);
                return;
            }
            if (!Validation.Many(ucSearch))
                return;
            AppendSelect();
            AppendAnd();
            AppendGroupBy();
            string debug = sb.ToString();
            LoadDataGridViews();
        }

        private void AppendSelect()
        {
            select.Clear();
            select.Append("select ");
            if (cmbGroupBy.SelectedIndex == 0)
            {
                select.Append("* ");
            }
            else
            {
                select.Append(cmbGroupBy.Get<Column>().Name);
                select.Append(" as '");
                select.Append(cmbGroupBy.Get<Column>().Display);
                select.Append("', count(");
                select.Append(cmbGroupBy.Get<Column>().Name);
                select.Append(") as 'Count' ");
            }
        }

        private void AppendFrom()
        {
            sb.Append("from ");
            sb.Append(cmbTables.Get<Table>().Name);
        }

        private void AppendWhere()
        {
            sb.Append(" where ");
            AppendCondition();
        }

        private void AppendAnd()
        {
            sb.Append(" and ");
            AppendCondition();
        }

        private void AppendCondition()
        {
            sb.Append(cmbColumns.Get<Column>().Name);
            ISearchControl control = (ISearchControl)ucSearch;
            control.Append(sb);
        }

        private void AppendGroupBy()
        {
            groupBy.Clear();
            if (cmbGroupBy.SelectedIndex != 0)
            {
                groupBy.Append(" group by ");
                groupBy.Append(cmbGroupBy.Get<Column>().Name);
            }
        }

        private void LoadDataGridViews()
        {
            string sql = select.ToString() + sb.ToString() + groupBy.ToString();
            DataTable dataTable = Database.CreateDataTable(sql);
            if (dataTable.Rows.Count == 0)
            {
                dgvSearch.DataSource = null;
                dgvTotals.DataSource = null;
                MessageBox.Show("Search found no results.");
                return;
            }
            DataTable totalTable = new DataTable();
            totalTable.Columns.Add("Row Total", typeof(int));
            foreach (DataColumn column in dataTable.Columns)
                totalTable.Columns.Add(new DataColumn(column.ColumnName, column.DataType));
            DataRow totals = totalTable.NewRow();
            totals.SetField(0, dataTable.Rows.Count);
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                if (Extensions.IntTypes.Contains(dataTable.Columns[i].DataType))
                    totals[i + 1] = dataTable.AsEnumerable().Aggregate(0, (a, r) => a += Convert.ToInt32(r[i]));
                else if (Extensions.FloatTypes.Contains(dataTable.Columns[i].DataType))
                    totals[i + 1] = dataTable.AsEnumerable().Aggregate(0.0, (a, r) => a += Convert.ToDouble(r[i]));
            }
            totalTable.Rows.Add(totals);
            dgvSearch.DataSource = dataTable;
            dgvTotals.DataSource = totalTable;
        }

        private void dgvSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Forms.ShowForm(cmbTables.Get<Table>().Form);
        }
    }
}
