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
using System.IO;

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
            public List<Foreign> Primaries { get; }
            public List<Foreign> Foreigns { get; }
            public List<Bridge> Bridges { get; }
            public string Display => Name;
            public Table Value => this;

            public Table(string name, Type form)
            {
                Name = name;
                if (form == null)
                    return;
                Form = form;
                Columns = new BindingList<Column>() { new Column(null, "(Not Selected)", null, null) };
                foreach (SqlDataReader row in Database.StoredProcedure(
                    "sp_columns", new SqlParameter("@table_name", name)))
                {
                    Columns.Add(new Column(
                        (string)row["COLUMN_NAME"],
                        Extensions.CamelToHuman((string)row["COLUMN_NAME"]),
                        Name,
                        Extensions.DatabaseType((string)row["TYPE_NAME"])));
                }
                GroupBy = new BindingList<Column>(Columns);
                Primaries = new List<Foreign>();
                Foreigns = new List<Foreign>();
                Bridges = new List<Bridge>();
            }

            public void AddDictionary(string columnName, Dictionary<string, int> dictionary)
            {
                Column column = Columns.First(c => c.Name?.Equals(columnName, StringComparison.InvariantCultureIgnoreCase) ?? false);
                column.Dictionary = new BindingList<Data<int>>(dictionary.Select((kvp) => new Data<int>(kvp.Key, kvp.Value)).ToList());
                column.DataType = typeof(Dictionary<string, int>);
            }

            public void JoinPrimary(Table table, string primary, string foreign)
            {
                Primaries.Add(new Foreign(table, primary, foreign));
            }

            public void JoinForeign(Table table, string primary, string foreign)
            {
                Foreigns.Add(new Foreign(table, primary, foreign));
            }

            public void JoinBridge(Table table, string bridge, string primary, string foreign)
            {
                Bridges.Add(new Bridge(table, bridge, primary, foreign));
            }

            public void AppendJoin(StringBuilder sb, Table table)
            {
                Foreign foreign = Primaries.FirstOrDefault(f => f.Table == table);
                if (foreign != null)
                {
                    sb.Append(Name);
                    sb.Append(".");
                    sb.Append(foreign.PrimaryId);
                    sb.Append(" = ");
                    sb.Append(table.Name);
                    sb.Append(".");
                    sb.Append(foreign.ForeignId);
                    return;
                }
                foreign = Foreigns.FirstOrDefault(f => f.Table == table);
                if (foreign != null)
                {
                    sb.Append(Name);
                    sb.Append(".");
                    sb.Append(foreign.ForeignId);
                    sb.Append(" = ");
                    sb.Append(table.Name);
                    sb.Append(".");
                    sb.Append(foreign.PrimaryId);
                    return;
                }
                Bridge bridge = Bridges.FirstOrDefault(b => b.Table == table);
                if (bridge != null)
                {
                    sb.Append(Name);
                    sb.Append(".");
                    sb.Append(bridge.PrimaryId);
                    sb.Append(" = ");
                    sb.Append(bridge.BridgeTable);
                    sb.Append(".");
                    sb.Append(bridge.PrimaryId);
                    sb.Append(" and ");
                    sb.Append(table.Name);
                    sb.Append(".");
                    sb.Append(bridge.ForeignId);
                    sb.Append(" = ");
                    sb.Append(bridge.BridgeTable);
                    sb.Append(".");
                    sb.Append(bridge.ForeignId);
                    return;
                }
                throw new Exception($"Failed to join {Name} with {table.Name}");
            }
        }

        public class Column
        {
            public string Name { get; }
            public string Display { get; }
            public string Table { get; }
            public Type DataType { get; set; }
            public BindingList<Data<int>> Dictionary { get; set; }

            public Column Value => this;

            public Column(string name, string display, string table, Type dataType)
            {
                Name = name;
                Display = display;
                Table = table;
                DataType = dataType;
            }
        }

        private class Foreign
        {
            public Table Table { get; }
            public string PrimaryId { get; }
            public string ForeignId { get; }

            public Foreign(Table table, string primaryId, string foreignId)
            {
                Table = table;
                PrimaryId = primaryId;
                ForeignId = foreignId;
            }
        }

        private class Bridge
        {
            public Table Table { get; }
            public string BridgeTable { get; }
            public string PrimaryId { get; }
            public string ForeignId { get; }

            public Bridge(Table table, string bridgeTable, string primaryId, string foreignId)
            {
                Table = table;
                BridgeTable = bridgeTable;
                PrimaryId = primaryId;
                ForeignId = foreignId;
            }
        }

        private BindingList<Table> tables;
        private Dictionary<Type, UserControl> userControls;
        private UserControl ucSearch;

        private ComboBox[] tableGroup;
        private ComboBox[] columnGroup;
        private ComboBox[] groupByGroup;

        private StringBuilder select;
        private StringBuilder join;
        private StringBuilder from;
        private StringBuilder condition;
        private StringBuilder groupBy;

        public GlobalSearchForm()
        {
            InitializeComponent();
            select = new StringBuilder();
            from = new StringBuilder();
            condition = new StringBuilder();
            groupBy = new StringBuilder();
            join = new StringBuilder();
            tableGroup = new ComboBox[] { cmbTables, cmbTables2, cmbTables3, cmbTables4 };
            columnGroup = new ComboBox[] { cmbColumns, cmbColumns2, cmbColumns3, cmbColumns4 };
            groupByGroup = new ComboBox[] { cmbGroupBy, cmbGroupBy2, cmbGroupBy3, cmbGroupBy4 };
            LoadTables();
            LoadControls();
            Forms.SetDataSource(cmbTables, tables);
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
            student.JoinPrimary(enrolment, "studentId", "studentId");
            enrolment.JoinForeign(student, "studentId", "studentId");
            enrolment.JoinForeign(course, "courseId", "courseId");
            teacher.JoinPrimary(assessment, "teacherId", "teacherId");
            teacher.JoinBridge(course, "Course_Teachers", "teacherId", "courseId");
            teacher.JoinBridge(unit, "Unit_Teachers", "teacherId", "unitId");
            teacher.JoinBridge(skill, "Teacher_Skills", "teacherId", "skillId");
            course.JoinPrimary(enrolment, "courseId", "courseId");
            course.JoinBridge(teacher, "Course_Teachers", "courseId", "teacherId");
            course.JoinBridge(unit, "Course_Units", "courseId", "unitId");
            unit.JoinPrimary(assessment, "unitId", "unitId");
            unit.JoinBridge(course, "Course_Units", "unitId", "courseId");
            unit.JoinBridge(teacher, "Unit_Teachers", "unitId", "teacherId");
            unit.JoinBridge(skill, "Unit_Skills", "unitId", "skillId");
            assessment.JoinForeign(teacher, "teacherId", "teacherId");
            assessment.JoinForeign(unit, "unitId", "unitId");
            skill.JoinBridge(teacher, "Teacher_Skills", "skillId", "teacherId");
            skill.JoinBridge(unit, "Unit_Skills", "skillId", "unitId");
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

        private void UpdateTables(ComboBox combo)
        {
            BindingList<Table> list = new BindingList<Table>() { new Table("(Not Selected)", null) };
            int index = Array.IndexOf(tableGroup, combo);
            foreach (Foreign primary in tableGroup[index - 1].Get<Table>().Primaries)
                if (!tableGroup.Any(c => c.Get<Table>() == primary.Table))
                    list.Add(primary.Table);
            foreach (Foreign foreign in tableGroup[index - 1].Get<Table>().Foreigns)
                if (!tableGroup.Any(c => c.Get<Table>() == foreign.Table))
                    list.Add(foreign.Table);
            foreach (Bridge bridge in tableGroup[index - 1].Get<Table>().Bridges)
                if (!tableGroup.Any(c => c.Get<Table>() == bridge.Table))
                    list.Add(bridge.Table);
            combo.DataSource = null;
            Forms.SetDataSource(combo, list);
        }

        private void UpdateColumns(ComboBox combo)
        {
            if (combo.SelectedIndex < 1)
            {
                if (!columnGroup.Any(c => c.SelectedIndex > 0))
                    ucSearch.Hide();
                return;
            }
            foreach (ComboBox cmb in columnGroup)
            {
                if (cmb != combo && cmb.Items.Count != 0)
                    cmb.SelectedIndex = 0;
            }
            ucSearch.Hide();
            ucSearch = userControls[combo.Get<Column>().DataType];
            ((ISearchControl)ucSearch).Reset();
            if (ucSearch is SearchDictionary)
            {
                SearchDictionary control = (SearchDictionary)ucSearch;
                control.cmbType.DataSource = combo.Get<Column>().Dictionary;
                control.lblType.Text = $"{combo.Get<Column>().Display}: ";
            }
            else if (ucSearch is SearchDate)
            {
                SearchDate control = (SearchDate)ucSearch;
                BindingList<Column> columns = new BindingList<Column>() { new Column(null, "(Not Selected)", null, null) };
                foreach (ComboBox cmb in tableGroup)
                {
                    if (cmb.SelectedIndex > 0)
                    {
                        foreach (Column column in cmb.Get<Table>().Columns)
                        {
                            if (column != combo.Get<Column>() && column.DataType == typeof(DateTime))
                                columns.Add(column);
                        }
                    }
                }
                control.cmbColumn.Enabled = columns.Count > 1;
                Forms.SetDataSource(control.cmbColumn, columns);
            }
            ucSearch.Show();
        }

        private void UpdateGroupBy(ComboBox combo)
        {
            if (combo.SelectedIndex < 1)
                return;
            foreach (ComboBox cmb in groupByGroup)
                if (cmb != combo && cmb.Items.Count != 0)
                    cmb.SelectedIndex = 0;
        }

        private int ComboIndex(ComboBox[] combos)
        {
            return Array.IndexOf(combos, combos.FirstOrDefault(c => (c.SelectedIndex > 0)));
        }

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbTables.SelectedIndex > 0)
            {
                Forms.SetDataSource(cmbColumns, cmbTables.Get<Table>().Columns);
                Forms.SetDataSource(cmbGroupBy, cmbTables.Get<Table>().GroupBy);
                UpdateTables(cmbTables2);
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
                cmbGroupBy2.DataSource = null;
                cmbGroupBy3.DataSource = null;
                cmbGroupBy4.DataSource = null;
            }
        }

        private void cmbTables2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTables2.SelectedIndex > 0)
            {
                Forms.SetDataSource(cmbColumns2, cmbTables2.Get<Table>().Columns);
                Forms.SetDataSource(cmbGroupBy2, cmbTables2.Get<Table>().GroupBy);
                UpdateTables(cmbTables3);
            }
            else
            {
                cmbTables3.DataSource = null;
                cmbTables4.DataSource = null;
                cmbColumns2.DataSource = null;
                cmbColumns3.DataSource = null;
                cmbColumns4.DataSource = null;
                cmbGroupBy2.DataSource = null;
                cmbGroupBy3.DataSource = null;
                cmbGroupBy4.DataSource = null;
            }
        }

        private void cmbTables3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTables3.SelectedIndex > 0)
            {
                Forms.SetDataSource(cmbColumns3, cmbTables3.Get<Table>().Columns);
                Forms.SetDataSource(cmbGroupBy3, cmbTables3.Get<Table>().GroupBy);
                UpdateTables(cmbTables4);
            }
            else
            {
                cmbTables4.DataSource = null;
                cmbColumns3.DataSource = null;
                cmbColumns4.DataSource = null;
                cmbGroupBy3.DataSource = null;
                cmbGroupBy4.DataSource = null;
            }
        }

        private void cmbTables4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTables3.SelectedIndex > 0)
            {
                Forms.SetDataSource(cmbColumns4, cmbTables4.Get<Table>().Columns);
                Forms.SetDataSource(cmbGroupBy4, cmbTables4.Get<Table>().GroupBy);
            }
            else
            {
                cmbColumns4.DataSource = null;
                cmbGroupBy4.DataSource = null;
            }
        }

        private void cmbColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateColumns(cmbColumns);
        }

        private void cmbColumns2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateColumns(cmbColumns2);
        }

        private void cmbColumns3_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateColumns(cmbColumns3);
        }

        private void cmbColumns4_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateColumns(cmbColumns4);
        }

        private void cmbGroupBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGroupBy(cmbGroupBy);
        }

        private void cmbGroupBy2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGroupBy(cmbGroupBy2);
        }

        private void cmbGroupBy3_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGroupBy(cmbGroupBy3);
        }

        private void cmbGroupBy4_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGroupBy(cmbGroupBy4);
        }

        private void btnNewSearch_Click(object sender, EventArgs e)
        {
            if (!ValidateColumns())
                return;
            if (!Validation.Many(ucSearch))
                return;
            condition.Clear();
            Append();
        }

        private void btnAddSearch_Click(object sender, EventArgs e)
        {
            if (!ValidateColumns())
                return;
            if (!Validation.Many(ucSearch))
                return;
            Append();
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            if (cmbTables.SelectedIndex < 1)
            {
                MessageBox.Show("No table has been selected.");
                return;
            }
            condition.Clear();
            AppendSelect();
            AppendFrom();
            AppendJoin();
            AppendGroupBy();
            LoadDataGridViews();
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            condition.Clear();
            Forms.ClearControls(this);
        }

        private void Append()
        {
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
            int index = ComboIndex(groupByGroup);
            if (index < 0)
            {
                select.Append("* ");
            }
            else
            {
                select.Append(tableGroup[index].Get<Table>().Name);
                select.Append(".");
                select.Append(groupByGroup[index].Get<Column>().Name);
                select.Append(" as '");
                select.Append(groupByGroup[index].Get<Column>().Display);
                select.Append("', count(");
                select.Append(tableGroup[index].Get<Table>().Name);
                select.Append(".");
                select.Append(groupByGroup[index].Get<Column>().Name);
                select.Append(") as '");
                select.Append(groupByGroup[index].Get<Column>().Display);
                select.Append(" Count' ");
            }
        }

        private void AppendFrom()
        {
            from.Clear();
            from.Append("from ");
            for (int i = 0; i < tableGroup.Length; i++)
            {
                if (tableGroup[i].SelectedIndex > 0)
                {
                    from.Append(tableGroup[i].Get<Table>().Name);
                    from.Append(", ");
                    if (i > 0)
                    {
                        foreach (Bridge bridge in tableGroup[i].Get<Table>().Bridges)
                        {
                            if (bridge.Table == tableGroup[i - 1].Get<Table>())
                            {
                                from.Append(bridge.BridgeTable);
                                from.Append(", ");
                            }
                        }
                    }
                }
            }
            from.Length -= 2;
        }

        private void AppendJoin()
        {
            join.Clear();
            int joins = -1;
            foreach (ComboBox combo in tableGroup)
                if (combo.SelectedIndex > 0)
                    joins++;
            if (joins > 0)
            {
                join.Append(" where ");
                for (int i = 0; i < joins; i++)
                {
                    tableGroup[i].Get<Table>().AppendJoin(join, tableGroup[i + 1].Get<Table>());
                    join.Append(" and ");
                }
                join.Length -= 5;
            }
        }

        private void AppendCondition()
        {
            if (join.Length == 0 && condition.Length == 0)
                condition.Append(" where ");
            else
                condition.Append(" and ");
            int index = ComboIndex(columnGroup);
            condition.Append(tableGroup[index].Get<Table>().Name);
            condition.Append(".");
            condition.Append(columnGroup[index].Get<Column>().Name);
            ISearchControl control = (ISearchControl)ucSearch;
            control.Append(condition);
        }

        private void AppendGroupBy()
        {
            groupBy.Clear();
            int index = ComboIndex(groupByGroup);
            if (index < 0)
                return;
            groupBy.Append(" group by ");
            groupBy.Append(tableGroup[index].Get<Table>().Name);
            groupBy.Append(".");
            groupBy.Append(groupByGroup[index].Get<Column>().Name);
        }

        private void LoadDataGridViews()
        {
            string sql = select.ToString() + from.ToString() + join.ToString() + condition.ToString() + groupBy.ToString();
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
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                Forms.ShowForm(cmbTables.Get<Table>().Form);
        }
    }
}
