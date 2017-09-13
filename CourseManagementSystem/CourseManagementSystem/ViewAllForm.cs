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

namespace CMS
{
    public partial class ViewAllForm : Form
    {
        private struct Column
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
        private Dictionary<string, Dictionary<string, int>> dictionaries = new Dictionary<string, Dictionary<string, int>>();

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

        /// <summary>
        /// Replaces values on a grid with their human readable string representation.
        /// </summary>
        /// <param name="columnName">The name of the column to replace.</param>
        /// <param name="dictionary">The dictionary to recieve the strings from in the Types class.</param>
        public void AddType(string columnName, Dictionary<string, int> dictionary)
        {
            dictionaries[columnName] = dictionary;
        }

        private void ViewAllForm_Shown(object sender, EventArgs e)
        {
            string[] columnNames = Database.GetTableColumns(table);
            StringBuilder sb = new StringBuilder("select ");
            for (int i = 0; i < columnNames.Length; i++)
            {
                Column? replace = replaceColumns.FirstOrDefault((c) => c.IdColumn.Equals(columnNames[i], StringComparison.InvariantCultureIgnoreCase));
                if (!replace.Value.Equals(default(Column)))
                {
                    sb.Append(replace.Value.Table);
                    sb.Append(".");
                    sb.Append(replace.Value.DisplayColumn);
                    sb.Append(" as '");
                    sb.Append(Extensions.CamelToHuman(replace.Value.DisplayColumn));
                    sb.Append("', ");
                }
                IEnumerable<Column> adds = addColumns.Where((c) => c.IdColumn.Equals(columnNames[i], StringComparison.InvariantCultureIgnoreCase));
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
                else if (replace.Value.Equals(default(Column)))
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
            var uniqueTables = addColumns.GroupBy((c) => c.Table).Select((c) => c.FirstOrDefault());
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
                    sb.Append("and ");
                }
                sb.Length -= 4;
            }
            string x = sb.ToString();
            dgvViewAll.DataSource = Database.CreateDataTable(sb.ToString());
        }

        private void dgvViewAll_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvViewAll.RowCount)
            {
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
            Forms.ShowForm(typeof(MainForm));
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(StudentForm));
        }

        private void teacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(TeacherForm));
        }

        private void enrolmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(EnrolmentForm));
        }

        private void courseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(CourseForm));
        }

        private void unitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(UnitForm));
        }

        private void assessmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(AssessmentForm));
        }

        private void skillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(SkillsForm));
        }

        private void allocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(AllocationForm));
        }

        private void globalSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(GlobalSearchForm));
        }
    }
}