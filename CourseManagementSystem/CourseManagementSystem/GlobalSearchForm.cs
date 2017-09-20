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
            public BindingList<Column> Columns { get; }
            public BindingList<Column> GroupBy { get; }
            public BindingList<Table> ForeignTables { get; }
            public Dictionary<string, ForeignKey> ForeignKeys { get; }

            public string Display => Name;
            public Table Value => this;

            public Table(string name, Type form)
            {
                Name = name;
                if (form == null)
                    return;
                Form = form;
                Columns = new BindingList<Column>() { new Column(null, "(Not Selected)", null) };
                foreach (SqlDataReader row in Database.StoredProcedure(
                    "sp_columns", new SqlParameter("@table_name", name))) {
                    Columns.Add(new Column(
                        (string)row["COLUMN_NAME"],
                        Extensions.CamelToHuman((string)row["COLUMN_NAME"]),
                        Extensions.DatabaseType((string)row["TYPE_NAME"])));
                }
                GroupBy = new BindingList<Column>();
                foreach (Column column in Columns)
                    GroupBy.Add(column);
                ForeignTables = new BindingList<Table>() { new Table("(Not Selected)", null) };
                ForeignKeys = new Dictionary<string, ForeignKey>();
                foreach (SqlDataReader row in Database.StoredProcedure("sp_fkeys",
                    new SqlParameter("@fktable_name", Name)))
                {
                    ForeignKeys[(string)row["PKTABLE_NAME"]] = new ForeignKey(
                        (string)row["FKTABLE_NAME"],
                        (string)row["FKCOLUMN_NAME"],
                        (string)row["PKTABLE_NAME"],
                        (string)row["PKCOLUMN_NAME"]);
                }
            }

            public void AddDictionary(string columnName, Dictionary<string, int> dictionary)
            {
                Column column = Columns.First(c => c.Name?.Equals(columnName, StringComparison.InvariantCultureIgnoreCase) ?? false);
                column.Dictionary = new BindingList<Data<int>>(dictionary.Select((kvp) => new Data<int>(kvp.Key, kvp.Value)).ToList());
                column.DataType = typeof(Dictionary<string, int>);
            }
        }

        private class Column
        {
            public string Name { get; }
            public string Display { get; }
            public Type DataType { get; set; }
            public BindingList<Data<int>> Dictionary { get; set; }

            public Column Value => this;

            public Column(string name, string display, Type dataType)
            {
                Name = name;
                Display = display;
                DataType = dataType;
            }
        }

        private class ForeignKey
        {
            public string MainTable { get; }
            public string MainId { get; }
            public string ForeignTable { get; }
            public string ForeignId { get; }

            public ForeignKey(string mainTable, string mainId, string foreignTable, string foreignId)
            {
                MainTable = mainTable;
                MainId = mainId;
                ForeignTable = foreignTable;
                ForeignId = foreignId;
            }
        }

        private BindingList<Table> tables;
        private Dictionary<Type, UserControl> userControls;
        private UserControl ucSearch;

        private StringBuilder select;
        private StringBuilder join;
        private StringBuilder from;
        private StringBuilder condition;
        private StringBuilder groupBy;
        private List<ComboBox> tableGroup;
        private List<ComboBox> columnGroup;

        public GlobalSearchForm()
        {
            InitializeComponent();
            select = new StringBuilder();
            from = new StringBuilder();
            condition = new StringBuilder();
            groupBy = new StringBuilder();
            join = new StringBuilder();
            tableGroup = new List<ComboBox> { cmbTables, cmbTables2, cmbTables3, cmbTables4 };
            columnGroup = new List<ComboBox> { cmbColumns, cmbColumns2, cmbColumns3, cmbColumns4 };
            LoadTables();
            LoadControls();
            cmbColumns.DisplayMember = "Display";
            cmbColumns.ValueMember = "Value";
            cmbColumns2.DisplayMember = "Display";
            cmbColumns2.ValueMember = "Value";
            cmbColumns3.DisplayMember = "Display";
            cmbColumns3.ValueMember = "Value";
            cmbColumns4.DisplayMember = "Display";
            cmbColumns4.ValueMember = "Value";
            cmbTables.DisplayMember = "Display";
            cmbTables.ValueMember = "Value";
            cmbTables2.DisplayMember = "Display";
            cmbTables2.ValueMember = "Value";
            cmbTables3.DisplayMember = "Display";
            cmbTables3.ValueMember = "Value";
            cmbTables4.DisplayMember = "Display";
            cmbTables4.ValueMember = "Value";
            cmbGroupBy.DisplayMember = "Display";
            cmbGroupBy.ValueMember = "Value";
            cmbTables.DataSource = tables;
        }

        private void LoadTables()
        {
            tables = new BindingList<Table>() { new Table("(Not Selected)", null) };
            Table student = new Table("Students", typeof(StudentForm));
            student.AddDictionary("studentGender", Types.GenderType);
            tables.Add(student);
            Table enrolment = new Table("Enrolments", typeof(EnrolmentForm));
            enrolment.AddDictionary("semester", Types.Semester);
            enrolment.AddDictionary("results", Types.CourseResults);
            tables.Add(enrolment);
            Table teacher = new Table("Teachers", typeof(TeacherForm));
            tables.Add(teacher);
            Table course = new Table("Courses", typeof(CourseForm));
            course.AddDictionary("courseDeliveryType", Types.DeliveryType);
            tables.Add(course);
            Table unit = new Table("Units", typeof(UnitForm));
            unit.AddDictionary("unitType", Types.UnitType);
            tables.Add(unit);
            Table assessment = new Table("Assessments", typeof(AssessmentForm));
            tables.Add(assessment);
            Table skill = new Table("Skills", typeof(SkillsForm));
            tables.Add(skill);
            student.ForeignTables.Add(enrolment);
            enrolment.ForeignTables.Add(student);
            enrolment.ForeignTables.Add(teacher);
            teacher.ForeignTables.Add(assessment);
            AddLookUpTable("departments", "departmentname", "departmentid");
        }

        private void AddLookUpTable(string tableName, string display, string value)
        {
            BindingList<Data<int>> dictionary = new BindingList<Data<int>>();
            foreach (SqlDataReader row in Database.ExecuteQuery(
                $"select {display} as Display, {value} as Value from {tableName}"))
            {
                dictionary.Add(new Data<int>((string)row["Display"], Convert.ToInt32(row["Value"])));
            }
            foreach (Table table in tables)
            {
                Column column = table.Columns?.FirstOrDefault(c => c.Name?.Equals(value, StringComparison.InvariantCultureIgnoreCase) ?? false);
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
            ucSearch.Hide();
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
                Column column = columnGroup.First(c => (c.SelectedIndex > 0)).Get<Column>();
                control.cmbType.DataSource = column.Dictionary;
                control.lblType.Text = $"{column.Display}: ";
            }
            ucSearch.Show();
        }

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cmbTables.SelectedIndex > 0)
            {
                Forms.SetDataSource(cmbColumns, "Display", "Value", cmbTables.Get<Table>().Columns);
                Forms.SetDataSource(cmbGroupBy, "Display", "Value", cmbTables.Get<Table>().GroupBy);
                cmbTables2.DataSource = cmbTables.Get<Table>().ForeignTables;
            }
            else
            {
                cmbTables2.DataSource = null;
                cmbTables3.DataSource = null;
                cmbTables4.DataSource = null;
                cmbColumns.DataSource = null;
                cmbColumns2.DataSource = null;
                cmbColumns3.DataSource = null;
                cmbColumns4.DataSource = null;
                cmbGroupBy.DataSource = null;
            }
        }

        private void cmbTables2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTables2.SelectedIndex > 0)
            {
                Forms.SetDataSource(cmbColumns2, "Display", "Value", cmbTables2.Get<Table>().Columns);
                Forms.SetDataSource(cmbGroupBy, "Display", "Value", cmbTables2.Get<Table>().GroupBy);
                //cmbTables3.DataSource = cmbTables2.Get<Table>().ForeignTables;
            }
            else
            {
                cmbTables3.DataSource = null;
                cmbTables4.DataSource = null;
                cmbColumns2.DataSource = null;
                cmbColumns3.DataSource = null;
                cmbColumns4.DataSource = null;
            }
        }

        private void cmbTables3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbTables4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbColumns.SelectedIndex > 0)
            {
                ChangeUserControl(cmbColumns.Get<Column>().DataType);
                ClearColumns(cmbColumns);
            } 
            else
                ucSearch.Hide();
        }

        private void cmbColumns2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbColumns2.SelectedIndex > 0)
            {
                ChangeUserControl(cmbColumns2.Get<Column>().DataType);
                ClearColumns(cmbColumns2);
            }
            else
                ucSearch.Hide();
        }

        private void cmbColumns3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbColumns4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClearColumns(ComboBox control)
        {
            foreach (ComboBox combo in columnGroup)
            {
                if (combo != control && combo.Items.Count != 0)
                    combo.SelectedIndex = 0;
            }
        }

        private bool ValidateColumns()
        {
            foreach (ComboBox combo in columnGroup)
            {
                if (combo.Items.Count != 0 && combo.SelectedIndex > 0)
                    return true;
            }
            MessageBox.Show("No condition is selected.");
            return false;
        }

        private void btnNewSearch_Click(object sender, EventArgs e)
        {
            condition.Clear();
            Append();
        }

        private void btnAddSearch_Click(object sender, EventArgs e)
        {
            Append();
        }

        private void Append()
        {
            if (!ValidateColumns())
                return;
            if (!Validation.Many(ucSearch))
                return;
            AppendSelect();
            AppendFrom();
            AppendJoin();
            AppendCondition();
            AppendGroupBy();
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
            from.Clear();
            from.Append("from ");
            foreach (ComboBox combo in tableGroup)
            {
                if (combo.SelectedIndex > 0)
                {
                    from.Append(combo.Get<Table>().Name);
                    from.Append(", ");
                }
            }
            from.Length -= 2;
        }

        private void AppendJoin()
        {
            join.Clear();
            for (int i = 0; i < tableGroup.Count - 1; i++)
            {
                if (tableGroup[i + 1].SelectedIndex > 0)
                {
                    ForeignKey fk = tableGroup[i + 1].Get<Table>().ForeignKeys[tableGroup[i].Get<Table>().Name];
                    join.Append(fk.MainTable);
                    join.Append(".");
                    join.Append(fk.MainId);
                    join.Append(" = ");
                    join.Append(fk.ForeignTable);
                    join.Append(".");
                    join.Append(fk.ForeignId);
                }
            }
        }

        private void AppendCondition()
        {
            if (join.Length != 0 || condition.Length != 0)
            {
                condition.Append(" and ");
            } 
            int index = columnGroup.IndexOf(columnGroup.First(c => (c.SelectedIndex > 0)));
            condition.Append(tableGroup[index].Get<Table>().Name);
            condition.Append(".");
            condition.Append(columnGroup[index].Get<Column>().Name);
            ISearchControl control = (ISearchControl)ucSearch;
            control.Append(condition);
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
            string sql = select.ToString() + from.ToString() + " where " + join.ToString() + condition.ToString() + groupBy.ToString();
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
