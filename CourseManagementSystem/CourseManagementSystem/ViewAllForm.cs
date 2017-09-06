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
        public class ForeignKey
        {
            public string Table { get; }
            public string IdColumn { get; }
            public string DisplayColumn { get; }

            public ForeignKey(string table, string idColumn, string displayColumn)
            {
                Table = table;
                IdColumn = idColumn;
                DisplayColumn = displayColumn;
            }
        }

        public string Table { get; set; }
        public List<ForeignKey> ForeignKeys { get; } = new List<ForeignKey>();
        public Dictionary<string, Dictionary<string, int>> Dictionaries { get; } = new Dictionary<string, Dictionary<string, int>>();

        public ViewAllForm(string table)
        {
            InitializeComponent();
            Table = table;
        }

        public void AddForeignKey(string table, string idColumnName, string displayColumn)
        {
            ForeignKeys.Add(new ForeignKey(table, idColumnName, displayColumn));
        }

        public void AddDictionary(string columnName, Dictionary<string, int> dictionary)
        {
            Dictionaries[columnName] = dictionary;
        }

        public void LoadDgv()
        {
            string[] tableNames = Database.GetTableColumns(Table);
            StringBuilder sb = new StringBuilder("select ");
            for (int i = 0; i < tableNames.Length; i++)
            {
                ForeignKey foreignKey = ForeignKeys.FirstOrDefault((fk) => fk.IdColumn == tableNames[i]);
                if (foreignKey != null)
                {
                    sb.Append(foreignKey.Table);
                    sb.Append(".");
                    sb.Append(foreignKey.DisplayColumn);
                    sb.Append("as");
                    sb.Append(foreignKey.DisplayColumn);
                }
                else if (Dictionaries.ContainsKey(tableNames[i]))
                {
                    sb.Append(" case ");
                    sb.Append(Table);
                    sb.Append(".");
                    sb.Append(tableNames[i]);
                    sb.Append(" ");
                    foreach (KeyValuePair<string, int> kvp in Dictionaries[tableNames[i]])
                    {
                        sb.Append("when ");
                        sb.Append(kvp.Value);
                        sb.Append(" then '");
                        sb.Append(kvp.Key);
                        sb.Append("' ");
                    }
                    sb.Append("end as ");
                    sb.Append(tableNames);
                }
                else
                {
                    sb.Append(Table);
                    sb.Append(".");
                    sb.Append(tableNames);
                }
                sb.Append(", ");
            }
            sb.Length -= 2;
            sb.Append(" from ");
            sb.Append(Table);
            foreach (ForeignKey fk in ForeignKeys)
            {
                sb.Append(", ");
                sb.Append(fk.Table);
            }
            sb.Append("where ");
            foreach (ForeignKey fk in ForeignKeys)
            {
                sb.Append(Table);
                sb.Append(".");
                sb.Append(fk.IdColumn);
                sb.Append(" = ");
                sb.Append(fk.Table);
                sb.Append(".");
                sb.Append(fk.IdColumn);
                sb.Append(", ");
            }
            sb.Length -= 2;
            dgvAll.DataSource = Database.CreateDataTable(sb.ToString());
        }
    }
}
