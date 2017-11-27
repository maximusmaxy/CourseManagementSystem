using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CmsLibrary;
using System.Data.SqlClient;

namespace CMS
{
    public partial class ViewAllForm : Form
    {
        private class Column
        {
            public string Table { get; }
            public string IdColumn { get; }
            public string DisplayColumn { get; }

            public Column(string table, string idColumn, string displayColumn)
            {
                Table = table;
                IdColumn = idColumn;
                DisplayColumn = displayColumn;
            }
        }

        public int Id { get; private set; } = -1;

        private string table;
        private List<Column> addColumns = new List<Column>();
        private List<Column> replaceColumns = new List<Column>();
        private List<string> hideColumns = new List<string>();
        private Dictionary<string, Dictionary<string, int>> dictionaries = new Dictionary<string, Dictionary<string, int>>();
        private Dictionary<string, Dictionary<int, string>> lookUps = new Dictionary<string, Dictionary<int, string>>();
        private List<Bridge> bridges = new List<Bridge>();
        private List<int> storedIdColumn;

        /// <summary>
        /// Constructs a data grid view form for a specified table.
        /// </summary>
        /// <param name="table">The table to create.</param>
        public ViewAllForm(string table)
        {
            InitializeComponent();
            this.table = table;
        }

        /// <summary>
        /// Adds a column to the data grid view from a foreign table.
        /// </summary>
        /// <param name="table">The foreign table name.</param>
        /// <param name="foreignKeyName">The foreign key id column name.</param>
        /// <param name="foreignColumnName">The name of the column from the foreign table you want to add.</param>
        public void AddColumn(string table, string foreignKeyName, string foreignColumnName)
        {
            addColumns.Add(new Column(table, foreignKeyName, foreignColumnName));
        }

        /// <summary>
        /// Replaces a foreign key with a column from another table.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="foreignKeyName"></param>
        /// <param name="foreignColumnName"></param>
        public void ReplaceColumn(string table, string foreignKeyName, string foreignColumnName)
        {
            replaceColumns.Add(new Column(table, foreignKeyName, foreignColumnName));
        }

        public void HideColumn(string column)
        {
            hideColumns.Add(column);
        }

        /// <summary>
        /// Replaces values on a grid with their human readable string representation.
        /// </summary>
        /// <param name="columnName">The name of the column to replace.</param>
        /// <param name="dictionary">The dictionary to recieve the strings from in the Types class.</param>
        public void AddType(string columnName, Dictionary<string, int> dictionary)
        {
            dictionaries[columnName] = dictionary;
        }

        public void AddLookUp(string table, string columnName, string id, string value)
        {
            string sql = $"select {id} as id, {value} as value from {table}";
            lookUps[columnName] = new Dictionary<int, string>();
            foreach (var row in Database.ExecuteQuery(sql))
            {
                lookUps[columnName][Convert.ToInt32(row["id"])] = Convert.ToString(row["value"]);
            }
        }

        /// <summary>
        /// Adds a bridging tables values to the data grid view.
        /// </summary>
        /// <param name="bridgingTable">The name of the briding table in the database.</param>
        /// <param name="foreignTable">The name of the table to join to in the database.</param>
        /// <param name="idColumn">The name of the id column in the briding table.</param>
        /// <param name="foreignColumn">The name of the foreign id column in the bridging table.</param>
        /// <param name="foreignDisplay">The column in the foreign table to display in the data grid view.</param>
        public void AddBridging(string bridgingTable, string foreignTable, string idColumn, string foreignColumn, string foreignDisplay)
        {
            bridges.Add(new Bridge(bridgingTable, foreignTable, idColumn, foreignColumn, foreignDisplay));
        }

        private void ViewAllForm_Shown(object sender, EventArgs e)
        {
            string[] columnNames = Database.GetTableColumns(table);
            StringBuilder sb = new StringBuilder("select ");
            for (int i = 0; i < columnNames.Length; i++)
            {
                Column replace = replaceColumns.FirstOrDefault((c) => c.IdColumn.Equals(columnNames[i], StringComparison.InvariantCultureIgnoreCase));
                IEnumerable<Column> adds = addColumns.Where((c) => c.IdColumn.Equals(columnNames[i], StringComparison.InvariantCultureIgnoreCase));
                //Replace columns
                if (replace != null)
                {
                    sb.Append(replace.Table);
                    sb.Append(".");
                    sb.Append(replace.DisplayColumn);
                    sb.Append(" as '");
                    sb.Append(Extensions.CamelToHuman(replace.DisplayColumn));
                    sb.Append("'");
                    if (adds.Count() != 0)
                        sb.Append(", ");
                }
                //Add columns
                if (adds.Count() != 0)
                {
                    foreach (Column column in adds)
                    {
                        sb.Append(column.Table);
                        sb.Append(".");
                        sb.Append(column.DisplayColumn);
                        sb.Append(" as '");
                        sb.Append(Extensions.CamelToHuman(column.DisplayColumn));
                        sb.Append("', ");
                    }
                    sb.Length -= 2;
                }
                //Dictionaries
                if (dictionaries.ContainsKey(columnNames[i]))
                {
                    sb.Append(" case ");
                    sb.Append(table);
                    sb.Append(".");
                    sb.Append(columnNames[i]);
                    sb.Append(" ");
                    foreach (KeyValuePair<string, int> kvp in dictionaries[columnNames[i]])
                    {
                        sb.Append("when ");
                        sb.Append(kvp.Value);
                        sb.Append(" then '");
                        sb.Append(kvp.Key);
                        sb.Append("' ");
                    }
                    sb.Append("end as '");
                    sb.Append(Extensions.CamelToHuman(columnNames[i]));
                    sb.Append("'");
                }
                //Look ups
                else if (lookUps.ContainsKey(columnNames[i]))
                {
                    sb.Append(" case ");
                    sb.Append(table);
                    sb.Append(".");
                    sb.Append(columnNames[i]);
                    sb.Append(" ");
                    foreach (KeyValuePair<int, string> kvp in lookUps[columnNames[i]])
                    {
                        sb.Append("when ");
                        sb.Append(kvp.Key);
                        sb.Append(" then '");
                        sb.Append(kvp.Value);
                        sb.Append("' ");
                    }
                    sb.Append("end as '");
                    sb.Append(Extensions.CamelToHuman(columnNames[i]));
                    sb.Append("'");
                }
                //Unmodified
                else if (replace == null)
                {
                    sb.Append(table);
                    sb.Append(".");
                    sb.Append(columnNames[i]);
                    sb.Append(" as '");
                    sb.Append(Extensions.CamelToHuman(columnNames[i]));
                    sb.Append("'");
                }
                sb.Append(", ");
            }
            sb.Length -= 2;
            sb.Append(" from ");
            sb.Append(table);
            //Join unique tables
            var uniqueTables = addColumns.Union(replaceColumns).GroupBy((c) => c.Table).Select((c) => c.FirstOrDefault());
            if (uniqueTables.Count() != 0)
            {
                foreach (Column column in uniqueTables)
                {
                    sb.Append(", ");
                    sb.Append(column.Table);
                }
                sb.Append(" where ");
                foreach (Column column in uniqueTables)
                {
                    sb.Append(table);
                    sb.Append(".");
                    sb.Append(column.IdColumn);
                    sb.Append(" = ");
                    sb.Append(column.Table);
                    sb.Append(".");
                    sb.Append(column.IdColumn);
                    sb.Append(" and ");
                }
                sb.Length -= 4;
            }
            string debug = sb.ToString();
            DataTable dataTable = Database.CreateDataTable(sb.ToString());
            //Bridging tables
            foreach (Bridge bridge in bridges)
            {
                DataTable bridgingTable = Database.CreateBridgingTable(bridge);
                Database.AddBridgingTable(dataTable, bridgingTable, bridge);
            }
            //hide
            foreach (string column in hideColumns)
            {
                string human = Extensions.CamelToHuman(column);
                if (dataTable.Columns[human].Ordinal == 0)
                {
                    if (dataTable.Columns[human].DataType == typeof(Byte))
                        storedIdColumn = Database.RemoveColumn<Byte>(dataTable, human).Select(r => Convert.ToInt32(r)).ToList();
                    else if (dataTable.Columns[human].DataType == typeof(Int16))
                        storedIdColumn = Database.RemoveColumn<Int16>(dataTable, human).Select(r => Convert.ToInt32(r)).ToList();
                    else if (dataTable.Columns[human].DataType == typeof(Int64))
                        storedIdColumn = Database.RemoveColumn<Int64>(dataTable, human).Select(r => Convert.ToInt32(r)).ToList();
                    else
                        storedIdColumn = Database.RemoveColumn<int>(dataTable, human);
                }
                else
                    Database.RemoveColumn(dataTable, human);
            }
            dgvViewAll.DataSource = dataTable;
        }

        private void dgvViewAll_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvViewAll.RowCount)
            {
                if (storedIdColumn != null)
                    Id = storedIdColumn[e.RowIndex];
                else
                    Id = Convert.ToInt32(((DataRowView)dgvViewAll.Rows[e.RowIndex].DataBoundItem)[0]);
                Close();
            }
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
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

        private void teacherToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void globalSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to open this form in a new window", "Question",
                                              MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Forms.ShowForm(typeof(GlobalSearchForm));
            }
            else if (result == DialogResult.No)
            {
                Forms.ShowForm(typeof(GlobalSearchForm));
                Close();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VBProject.VBClass.ShowCredits();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.LogOut(typeof(LoginForm));
        }
    }
}