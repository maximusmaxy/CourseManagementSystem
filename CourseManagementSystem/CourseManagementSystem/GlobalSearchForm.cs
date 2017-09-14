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
            public BindingList<Column> Columns { get; }
            public Type Form { get; }

            public string Display => Name;
            public Table Value => this;

            public Table(string name, Type form)
            {
                Name = name;
                Form = form;
                Columns = new BindingList<Column>();
                foreach (SqlDataReader row in Database.StoredProcedure(
                    "sp_columns", new SqlParameter("@table_name", name))) {
                    Columns.Add(new Column(
                        (string)row["COLUMN_NAME"],
                        Extensions.CamelToHuman((string)row["COLUMN_NAME"]),
                        Extensions.DatabaseType((string)row["TYPE_NAME"])));
                }
            }

            public void AddDictionary(string columnName, Dictionary<string, int> dictionary)
            {
                Column column = Columns.First(c => c.Name.Equals(columnName, StringComparison.InvariantCultureIgnoreCase));
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

        BindingList<Table> tables;
        Dictionary<Type, UserControl> userControls;

        public GlobalSearchForm()
        {
            InitializeComponent();
            LoadTables();
            LoadControls();
            cmbColumns.DisplayMember = "Display";
            cmbColumns.ValueMember = "Value";
            cmbTables.DisplayMember = "Display";
            cmbTables.ValueMember = "Value";
            cmbTables.DataSource = tables;
        }

        private void LoadTables()
        {
            tables = new BindingList<Table>();
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
            BindingList<Data<int>> dictionary = new BindingList<Data<int>>();
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
            userControls[typeof(int)] = ucSearch;
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
                control.cmbValue.DataSource = cmbColumns.Get<Column>().Dictionary;
            }
            ucSearch.Show();
        }

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbColumns.DataSource = cmbTables.Get<Table>().Columns;
        }


        private void cmbColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeUserControl(cmbColumns.Get<Column>().DataType);
        }

        private void btnNewSearch_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder("select * from ");
            sb.Append(cmbTables.Get<Table>().Name);
            sb.Append(" where ");
            sb.Append(cmbColumns.Get<Column>());
            if (ucSearch is SearchInt)
            {
                SearchInt control = (SearchInt)ucSearch;
                switch (Forms.RadioString(control.pnlOperator))
                {
                    case "Equal To":
                        sb.Append(" = ");
                        sb.Append(control.txtValue.Int());
                        break;
                    case "Less Than":
                        sb.Append(" < ");
                        sb.Append(control.txtValue.Int());
                        break;
                    case "Greater Than":
                        sb.Append(" > ");
                        sb.Append(control.txtValue.Int());
                        break;
                }    
            } 
            var x = sb.ToString();
            dgvSearch.DataSource = Database.CreateDataTable(sb.ToString());
        }

        private void btnAddSearch_Click(object sender, EventArgs e)
        {
            if (dgvSearch.DataSource == null)
            {
                btnNewSearch_Click(sender, e);
            }
        }

        private void dgvSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Forms.ShowForm(cmbTables.Get<Table>().Form);
        }
    }
}
