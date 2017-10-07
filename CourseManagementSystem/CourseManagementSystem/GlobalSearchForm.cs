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
        /// <summary>
        /// private table class for holding all data related to a table
        /// including column data and join information
        /// </summary>
        private class Table
        {
            public string Name { get; }
            public Type Form { get; }
            public BindingList<Column> Columns { get; }
            public BindingList<Column> GroupBy { get; }
            public BindingList<Column> Count { get; }
            public List<Foreign> Primaries { get; }
            public List<Foreign> Foreigns { get; }
            public List<Bridge> Bridges { get; }
            public List<Column> Calculations { get; }
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
                Count = new BindingList<Column>(Columns);
                Calculations = new List<Column>();
                Primaries = new List<Foreign>();
                Foreigns = new List<Foreign>();
                Bridges = new List<Bridge>();
            }

            /// <summary>
            /// Adds a dictionary to the table and stores a list to populate the dictionary search.
            /// </summary>
            public void AddDictionary(string columnName, Dictionary<string, int> dictionary)
            {
                Column column = Columns.First(c => c.Name?.Equals(columnName, StringComparison.InvariantCultureIgnoreCase) ?? false);
                column.Dictionary = new BindingList<Data<int>>(dictionary.Select((kvp) => new Data<int>(kvp.Key, kvp.Value)).ToList());
                column.DataType = typeof(Dictionary<string, int>);
            }

            /// <summary>
            /// Adds primary table join information.
            /// </summary>
            public void JoinPrimary(Table table, string primary, string foreign)
            {
                Primaries.Add(new Foreign(table, primary, foreign));
            }

            /// <summary>
            /// Adds foreign table join information.
            /// </summary>
            public void JoinForeign(Table table, string primary, string foreign)
            {
                Foreigns.Add(new Foreign(table, primary, foreign));
            }

            /// <summary>
            /// Adds bridging table join information.
            /// </summary>
            public void JoinBridge(Table table, string bridge, string primary, string foreign)
            {
                Bridges.Add(new Bridge(table, bridge, primary, foreign));
            }
            
            /// <summary>
            /// Adds an arithmetic calculation column to the table.
            /// </summary>
            public void AddCalculation(string name, string calculation)
            {
                Column column = new Column(name, name, Name, typeof(int));
                column.Calculation = calculation;
                Calculations.Add(column);
                Columns.Add(column);
            }

            /// <summary>
            /// Appends the relevant join information to a string builder
            /// based on the relation to the table specified.
            /// </summary>
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

        /// <summary>
        /// Column information, used by the table.
        /// </summary>
        public class Column
        {
            public string Name { get; }
            public string Display { get; }
            public string Table { get; }
            public Type DataType { get; set; }
            public BindingList<Data<int>> Dictionary { get; set; }
            public string Calculation { get; set; }

            public Column Value => this;

            public Column(string name, string display, string table, Type dataType)
            {
                Name = name;
                Display = display;
                Table = table;
                DataType = dataType;
            }

            public void Append(StringBuilder sb)
            {
                if (Calculation == null)
                {
                    sb.Append(Table);
                    sb.Append(".");
                    sb.Append(Name);
                }
                else
                {
                    sb.Append(Calculation);
                }
            }
        }

        /// <summary>
        /// Primary or Foreign table join information.
        /// </summary>
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

        /// <summary>
        /// Bridging table join infromation.
        /// </summary>
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

        //privates
        private BindingList<Table> tables;
        private Dictionary<Type, UserControl> userControls;
        private UserControl ucSearch;

        //combo box groups
        private ComboBox[] tableGroup;
        private ComboBox[] columnGroup;
        private ComboBox[] groupByGroup;
        private ComboBox[] countGroup;

        //string builders
        private StringBuilder select;
        private StringBuilder join;
        private StringBuilder from;
        private StringBuilder condition;
        private StringBuilder groupBy;

        /// <summary>
        /// Constructor
        /// </summary>
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
            countGroup = new ComboBox[] { cmbCount, cmbCount2, cmbCount3, cmbCount4 };
            LoadTables();
            LoadControls();
            Forms.SetDataSource(cmbTables, tables);
        }

        /// <summary>
        /// Loads all table information, dictionaries, look ups and joins.
        /// </summary>
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
            assessment.AddCalculation("Month Duration", "datediff(month, Assessments.assessmentStartDate, Assessments.assessmentDueDate)");
        }

        /// <summary>
        /// Gets look up table information from a database, turns it into a dictionary and
        /// adds it to all relevant tables.
        /// </summary>
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

        /// <summary>
        /// Loads all custom user controls and stores it in a dictionary.
        /// </summary>
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
            AddUserControl(typeof(SearchCount), typeof(SearchCount));
        }

        /// <summary>
        /// Add a user control to the dictionary and the matching data type.
        /// </summary>
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

        /// <summary>
        /// Validates all columns to make sure a condition is selected.
        /// </summary>
        private bool ValidateCondition()
        {
            if (ComboIndex(columnGroup) >= 0 || ComboIndex(countGroup) >= 0)
                return true;
            MessageBox.Show("No column condition or count condition selected.");
            return false;
        }

        /// <summary>
        /// Fills all combos related to the table and fills the next table based
        /// on relations to this table without and duplicates.
        /// </summary>
        private void UpdateTables(ComboBox combo)
        {
            int index = Array.IndexOf(tableGroup, combo);
            if (combo.SelectedIndex > 0)
            {
                if (index != tableGroup.Length - 1)
                {
                    BindingList<Table> list = new BindingList<Table>() { new Table("(Not Selected)", null) };
                    foreach (Foreign primary in tableGroup[index].Get<Table>().Primaries)
                        if (!tableGroup.Any(c => c.Get<Table>() == primary.Table))
                            list.Add(primary.Table);
                    foreach (Foreign foreign in tableGroup[index].Get<Table>().Foreigns)
                        if (!tableGroup.Any(c => c.Get<Table>() == foreign.Table))
                            list.Add(foreign.Table);
                    foreach (Bridge bridge in tableGroup[index].Get<Table>().Bridges)
                        if (!tableGroup.Any(c => c.Get<Table>() == bridge.Table))
                            list.Add(bridge.Table);
                    Forms.SetDataSource(tableGroup[index + 1], list);
                }
                Forms.SetDataSource(columnGroup[index], tableGroup[index].Get<Table>().Columns);
                Forms.SetDataSource(groupByGroup[index], tableGroup[index].Get<Table>().GroupBy);
            }
            else
            {
                for (int i = 3; i >= index; i--)
                {
                    if (i != index)
                        Forms.ClearDataSource(tableGroup[i]);
                    Forms.ClearDataSource(columnGroup[i]);
                    Forms.ClearDataSource(groupByGroup[i]);
                }
            }
        }

        /// <summary>
        /// Switches search control to relevant column data type and resets everthing else.
        /// </summary>
        private void UpdateColumns(ComboBox combo)
        {
            if (combo.SelectedIndex < 1)
            {
                if (!columnGroup.Any(c => c.SelectedIndex > 0))
                    ucSearch.Hide();
                return;
            }
            ResetCombos(columnGroup, combo);
            ResetCombos(groupByGroup);
            ResetCombos(countGroup);
            UpdateUserControl(combo.Get<Column>().DataType);
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
        }

        /// <summary>
        /// Switches focus to the count search control, loads the count combo and resets
        /// everything else.
        /// </summary>
        private void UpdateGroupBy(ComboBox combo)
        {
            if (combo.SelectedIndex < 1)
            {
                if (ComboIndex(groupByGroup) < 0)
                {
                    foreach (ComboBox cmb in countGroup)
                        Forms.ClearDataSource(cmb);
                }
                return;
            }
            for (int i = 0; i < TableCount(); i++)
                Forms.SetDataSource(countGroup[i], tableGroup[i].Get<Table>().Count);
            int countIndex = ComboIndex(countGroup);
            if (countIndex < 0)
            {
                int groupByIndex = ComboIndex(groupByGroup);
                countGroup[groupByIndex].SelectedIndex = combo.SelectedIndex;
            }
            ResetCombos(groupByGroup, combo);
        }

        /// <summary>
        /// Clears the other counts.
        /// </summary>
        private void UpdateCount(ComboBox combo)
        {
            if (combo.SelectedIndex < 1)
            {
                if (ComboIndex(countGroup) < 0)
                {
                    ucSearch.Hide();
                }
                return;
            }
            ResetCombos(columnGroup);
            ResetCombos(countGroup, combo);
            UpdateUserControl(typeof(SearchCount));
        }

        /// <summary>
        /// Switches the search control to the relevant type.
        /// </summary>
        private void UpdateUserControl(Type type)
        {
            ucSearch.Hide();
            ucSearch = userControls[type];
            ((ISearchControl)ucSearch).Reset();
            ucSearch.Show();
        }

        /// <summary>
        /// Resets all combos in a group to not selected.
        /// </summary>
        private void ResetCombos(ComboBox[] combos, ComboBox ignore = null)
        {
            foreach (ComboBox cmb in combos)
                if (cmb.Items.Count != 0)
                    if (ignore == null || ignore != cmb)
                        cmb.SelectedIndex = 0;
        }

        /// <summary>
        /// Gets the index of the selected combo in a group or returns a negative number.
        /// </summary>
        private int ComboIndex(ComboBox[] combos)
        {
            return Array.IndexOf(combos, combos.FirstOrDefault(c => (c.SelectedIndex > 0)));
        }

        /// <summary>
        /// Gets the amount of tables selected.
        /// </summary>
        private int TableCount()
        {
            int tables = 0;
            foreach (ComboBox combo in tableGroup)
                if (combo.SelectedIndex > 0)
                    tables++;
            return tables;
        }

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTables(cmbTables);
        }

        private void cmbTables2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTables(cmbTables2);
        }

        private void cmbTables3_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTables(cmbTables3);
        }

        private void cmbTables4_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTables(cmbTables4);
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

        private void cmbCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCount(cmbCount);
        }

        private void cmbCount2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCount(cmbCount2);
        }

        private void cmbCount3_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCount(cmbCount3);
        }

        private void cmbCount4_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCount(cmbCount4);
        }

        /// <summary>
        /// New Search.
        /// </summary>
        private void btnNewSearch_Click(object sender, EventArgs e)
        {
            if (!ValidateCondition())
                return;
            if (!Validation.Many(ucSearch))
                return;
            condition.Clear();
            groupBy.Clear();
            Append();
        }

        /// <summary>
        /// Appends Search.
        /// </summary>
        private void btnAddSearch_Click(object sender, EventArgs e)
        {
            if (!ValidateCondition())
                return;
            if (!Validation.Many(ucSearch))
                return;
            Append();
        }

        /// <summary>
        /// Search without conditions.
        /// </summary>
        private void btnViewAll_Click(object sender, EventArgs e)
        {
            if (cmbTables.SelectedIndex < 1)
            {
                MessageBox.Show("No table has been selected.");
                return;
            }
            condition.Clear();
            groupBy.Clear();
            AppendSelect();
            AppendFrom();
            AppendJoin();
            LoadDataGridViews();
        }

        /// <summary>
        /// Resets back to original state.
        /// </summary>
        private void btnClearForm_Click(object sender, EventArgs e)
        {
            condition.Clear();
            Forms.ClearControls(this);
        }

        /// <summary>
        /// Updates all string builders and appends condition.
        /// </summary>
        private void Append()
        {
            if (ComboIndex(columnGroup) >= 0)
                AppendCondition();
            else if (ComboIndex(groupByGroup) >= 0)
                AppendGroupBy();
            else
                throw new Exception("Not validated properly.");
            AppendSelect();
            AppendFrom();
            AppendJoin();
            LoadDataGridViews();
        }

        /// <summary>
        /// Appends select information.
        /// </summary>
        private void AppendSelect()
        {
            int groupByIndex = ComboIndex(groupByGroup);
            int countIndex = ComboIndex(countGroup);
            if (countIndex < 0)
            {
                if (groupBy.Length == 0)
                {
                    select.Clear();
                    select.Append("select *");
                    for (int i = 0; i < TableCount(); i++)
                    {
                        foreach (Column column in tableGroup[i].Get<Table>().Calculations)
                        {
                            select.Append(", ");
                            select.Append(column.Calculation);
                            select.Append(" as '");
                            select.Append(column.Display);
                            select.Append("'");
                        }
                    }
                }
            }
            else
            {
                select.Clear();
                select.Append("select ");
                select.Append(tableGroup[groupByIndex].Get<Table>().Name);
                select.Append(".");
                select.Append(groupByGroup[groupByIndex].Get<Column>().Name);
                select.Append(" as '");
                select.Append(groupByGroup[groupByIndex].Get<Column>().Display);
                select.Append("', count(");
                select.Append(tableGroup[countIndex].Get<Table>().Name);
                select.Append(".");
                select.Append(countGroup[countIndex].Get<Column>().Name);
                select.Append(") as '");
                select.Append(countGroup[countIndex].Get<Column>().Display);
                select.Append(" Count'");
            }
        }

        /// <summary>
        /// Appends from information.
        /// </summary>
        private void AppendFrom()
        {
            from.Clear();
            from.Append(" from ");
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

        /// <summary>
        /// Appends join information.
        /// </summary>
        private void AppendJoin()
        {
            join.Clear();
            int joins = TableCount() - 1;
            if (joins > 0)
            {
                for (int i = 0; i < joins; i++)
                {
                    tableGroup[i].Get<Table>().AppendJoin(join, tableGroup[i + 1].Get<Table>());
                    join.Append(" and ");
                }
                join.Length -= 5;
            }
        }

        /// <summary>
        /// Appends condition information.
        /// </summary>
        private void AppendCondition()
        {
            if (condition.Length != 0)
                condition.Append(" and ");
            int index = ComboIndex(columnGroup);
            columnGroup[index].Get<Column>().Append(condition);
            ISearchControl control = (ISearchControl)ucSearch;
            control.Append(condition);
        }

        /// <summary>
        /// Appends group by and having information.
        /// </summary>
        private void AppendGroupBy()
        {
            int groupByIndex = ComboIndex(groupByGroup);
            groupBy.Clear();
            groupBy.Append(" group by ");
            groupByGroup[groupByIndex].Get<Column>().Append(groupBy);
            int countIndex = ComboIndex(countGroup);
            SearchCount count = (SearchCount)ucSearch;
            if (count.AllChecked)
                return;
            groupBy.Append(" having count(");
            countGroup[countIndex].Get<Column>().Append(groupBy);
            groupBy.Append(")");
            count.Append(groupBy);
        }

        /// <summary>
        /// Combines all string builder, executes the query and loads the data grid views.
        /// </summary>
        private void LoadDataGridViews()
        {
            string sql = select.ToString() + from.ToString();
            if (join.Length != 0 || condition.Length != 0) 
                sql += " where ";
            sql += join.ToString();
            if (join.Length != 0 && condition.Length != 0)
                sql += " and ";
            sql += condition.ToString() + groupBy.ToString();
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

        /// <summary>
        /// Opens the relevant form based on supplied information.
        /// </summary>
        private void dgvSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                Forms.ShowForm(cmbTables.Get<Table>().Form);
        }

        private void searchInt_Load(object sender, EventArgs e)
        {

        }

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to open this form in a new window", "Question",
                                              MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Forms.ShowForm(typeof(MainForm));
            }
            else if (result == DialogResult.No)
            {
                Forms.ShowForm(typeof(MainForm));
                Close();
            }
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to open this form in a new window", "Question",
                                              MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Forms.ShowForm(typeof(StudentForm));
            }
            else if (result == DialogResult.No)
            {
                Forms.ShowForm(typeof(StudentForm));
                Close();
            }
        }

        private void teacherCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to open this form in a new window", "Question",
                                             MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Forms.ShowForm(typeof(TeacherForm));
            }
            else if (result == DialogResult.No)
            {
                Forms.ShowForm(typeof(TeacherForm));
                Close();
            }
        }

        private void enrolmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to open this form in a new window", "Question",
                                              MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Forms.ShowForm(typeof(EnrolmentForm));
            }
            else if (result == DialogResult.No)
            {
                Forms.ShowForm(typeof(EnrolmentForm));
                Close();
            }
        }

        private void courseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to open this form in a new window", "Question",
                                              MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Forms.ShowForm(typeof(CourseForm));
            }
            else if (result == DialogResult.No)
            {
                Forms.ShowForm(typeof(CourseForm));
                Close();
            }
        }

        private void unitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to open this form in a new window", "Question",
                                              MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Forms.ShowForm(typeof(UnitForm));
            }
            else if (result == DialogResult.No)
            {
                Forms.ShowForm(typeof(UnitForm));
                Close();
            }
        }

        private void assessmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to open this form in a new window", "Question",
                                              MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Forms.ShowForm(typeof(AssessmentForm));
            }
            else if (result == DialogResult.No)
            {
                Forms.ShowForm(typeof(AssessmentForm));
                Close();
            }
        }

        private void skillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to open this form in a new window", "Question",
                                              MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Forms.ShowForm(typeof(SkillsForm));
            }
            else if (result == DialogResult.No)
            {
                Forms.ShowForm(typeof(SkillsForm));
                Close();
            }
        }

        private void allocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to open this form in a new window", "Question",
                                              MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Forms.ShowForm(typeof(AllocationForm));
            }
            else if (result == DialogResult.No)
            {
                Forms.ShowForm(typeof(AllocationForm));
                Close();
            }
        }
    }
}
