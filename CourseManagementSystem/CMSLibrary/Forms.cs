using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CmsLibrary
{
    public class Forms
    {
        private static Regex aliasRegex = new Regex(@"\W");
        private static Dictionary<Type, Form> formsOpen = new Dictionary<Type, Form>();


        /// <summary>
        /// Gets the string of the checked radio from a panel.
        /// </summary>
        /// <param name="pnl">The Panel to get the string from.</param>
        /// <returns>The string of the cheked radio button.</returns>
        public static string RadioString(Panel pnl)
        {
            foreach (RadioButton button in pnl.Controls.OfType<RadioButton>())
            {
                if (button.Checked)
                    return button.Text;
            }
            return string.Empty;
        }

        /// <summary>
        /// Checks a specific radio button on a panel based on string.
        /// </summary>
        /// <param name="pnl">The panel holding the radio buttons.</param>
        /// <param name="str">The string of the option to check.</param>
        public static void CheckRadio(Panel pnl, string str)
        {
            pnl.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Text == str).Checked = true;
        }

        /// <summary>
        /// Checks a specific radio button on a panel based on a value specified by a dictionary.
        /// </summary>
        /// <param name="pnl">The panel holding the radio buttons.</param>
        /// <param name="dictionary">The dictionary to obtain the value from.</param>
        /// <param name="value">The value to check.</param>
        public static void CheckRadio(Panel pnl, Dictionary<string, int> dictionary, int value)
        {
            pnl.Controls.OfType<RadioButton>().
                FirstOrDefault(r => dictionary[r.Text] == value).Checked = true;
        }

        /// <summary>
        /// Disables all radios in a panel. Use EnableRadio to reverse.
        /// </summary>
        /// <param name="pnl">The panel containing the radios.</param>
        public static void DisableRadio(Panel pnl)
        {
            foreach (RadioButton rdb in pnl.Controls.OfType<RadioButton>())
                rdb.Enabled = false;
        }

        /// <summary>
        /// Enables all radios in a panel. Use DisableRadio to reverse.
        /// </summary>
        /// <param name="pnl">The panel containing the radios.</param>
        public static void EnableRadio(Panel pnl)
        {
            foreach (RadioButton rdb in pnl.Controls.OfType<RadioButton>())
                rdb.Enabled = true;
        }

        /// <summary>
        /// Sets all checked values of radio buttons on a panel to false.
        /// </summary>
        /// <param name="pnl">The panel holding the radio buttons.</param>
        public static void ClearRadio(Panel pnl)
        {
            foreach (RadioButton rdb in pnl.Controls.OfType<RadioButton>())
                rdb.Checked = false;
        }

        /// <summary>
        /// Gets the value of a radio specified by the dictionary.
        /// </summary>
        /// <param name="pnl">The panel containing the radio buttons.</param>
        /// <param name="dictionary">The dictionary supplying the values.</param>
        /// <returns></returns>
        public static int RadioValue(Panel pnl, Dictionary<string, int> dictionary)
        {
            return dictionary[RadioString(pnl)];
        }

        /// <summary>
        /// Fills the list control with data from a table.
        /// </summary>
        /// <param name="table">The name of the table in the database.</param>
        /// <param name="display">The name of the column in the database that represents the displayed value in the combo box.</param>
        /// <param name="value">The name of the column in the database that holds the underlying value of the combo box.</param>
        /// <param name="conditions">Every even value is a string for the column name. Every odd value is an object for the value to search for.</param>
        public static void FillData(ListControl control, string table, string display, string value, params object[] conditions)
        {
            if (conditions.Length > 1 && conditions[1] == null)
            {
                control.DataSource = null;
                return;
            }
            string displayAlias = aliasRegex.Replace(display, "");
            string valueAlias = aliasRegex.Replace(value, "");
            StringBuilder sql = new StringBuilder("select ");
            sql.Append(display);
            sql.Append(" as ");
            sql.Append(displayAlias);
            sql.Append(", ");
            sql.Append(value);
            sql.Append(" as ");
            sql.Append(valueAlias);
            sql.Append(" from ");
            sql.Append(table);
            if (conditions.Length> 0)
            {
                sql.Append(" where ");
                sql.Append(conditions[0]);
                sql.Append(" = ");
                sql.Append(conditions[1]);
                for (int i = 2; i < conditions.Length; i++)
                {
                    sql.Append(" and ");
                    sql.Append(conditions[i++]);
                    sql.Append(" = ");
                    sql.Append(conditions[i]);
                }
            }
            FillData(control, null, displayAlias, valueAlias, sql.ToString());
        }

        /// <summary>
        /// Fills the list control with data from a table.
        /// Use this method for non standard data fills, otherwise use the other one.
        /// </summary>
        /// <param name="table">The name of the table in the database.</param>
        /// <param name="display">The name of the column in the database that represents the displayed value in the combo box.</param>
        /// <param name="value">The name of the column in the database that holds the underlying value of the combo box.</param>
        /// <param name="sql">The sql to execute for non standard data fills.</param>
        public static void FillData(ListControl control, string table, string display, string value, string sql)
        {
            DataTable dataTable;
            try
            {
                dataTable = Database.CreateDataTable(sql);
            }
            catch (Exception)
            {
                control.DataSource = null;
                return;
            }
            if (control is ComboBox)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow[display] = "(Please select an option)";
                dataTable.Rows.InsertAt(dataRow, 0);
            }
            SetDataSource(control, display, value, dataTable);
        }

        /// <summary>
        /// Sets the datasource of a list control safely.
        /// </summary>
        /// <param name="control">The control to set.</param>
        /// <param name="display">The display member.</param>
        /// <param name="value">The value member.</param>
        /// <param name="table">The table to set as the data source.</param>
        public static void SetDataSource(ListControl control, string display, string value, object table)
        {
            control.DataSource = null;
            control.DisplayMember = display;
            control.ValueMember = value;
            control.DataSource = table;
        }

        /// <summary>
        /// Sets the datasource to default values.
        /// DisplayMember = "Display"
        /// ValueMember = "Value"
        /// </summary>
        /// <param name="control">The control to set.</param>
        /// <param name="table">The data source to set.</param>
        public static void SetDataSource(ListControl control, object table)
        {
            control.DataSource = null;
            control.DisplayMember = "Display";
            control.ValueMember = "Value";
            control.DataSource = table;
        }

        /// <summary>
        /// Clears the data source of a control
        /// </summary>
        /// <param name="control">The control to clear.</param>
        public static void ClearDataSource(ListControl control)
        {
            if (control is ComboBox)
            {
                ComboBox combo = (ComboBox)control;
                if (combo.Items.Count > 0)
                    combo.SelectedIndex = 0;
            }
            control.DataSource = null;
        }

        /// <summary>
        /// Selects items in a listbox based on data from a bridging table.
        /// </summary>
        /// <param name="table">The name of the bridging table in the database.</param>
        /// <param name="idName">The name of the id column in the database.</param>
        /// <param name="idValue">The value of the id.</param>
        /// <param name="selectName">The name of the column to select from in the database.</param>
        public static void SelectData(ListBox control, string table, string idName, int idValue, string selectName)
        {
            control.ClearSelected();
            string sql = $"select {selectName} from {table} where {idName} = {idValue}";
            foreach (SqlDataReader row in Database.ExecuteQuery(sql))
                control.SelectedValue = row[selectName];
        }

        /// <summary>
        /// Selects items in a listbox based on a one to many relationship.
        /// </summary>
        /// <param name="table">The name of the table holding many values.</param>
        /// <param name="id">The name of the id column in the database.</param>
        /// <param name="foreignId">The name of the one column in the database.</param>
        /// <param name="foreignValue">The value of the one column.</param>
        /// <param name="control">The listbox holding the many values.</param>
        public static void SelectOneToMany(string table, string id, string foreignId, int foreignValue, ListBox control)
        {
            control.ClearSelected();
            string sql = $"select {id} from {table} where {foreignId} = {foreignValue}";
            foreach (SqlDataReader row in Database.ExecuteQuery(sql))
                control.SelectedValue = row[0];
        }

        /// <summary>
        /// Updates a one to many relationship in the database.
        /// </summary>
        /// <param name="table">The name of the table holding many values.</param>
        /// <param name="id">The name of the id column in the database.</param>
        /// <param name="foreignId">The name of the one column in the database.</param>
        /// <param name="foreignValue">The value of the one column.</param>
        /// <param name="control">The listbox holding the many values.</param>
        public static bool UpdateOneToMany(string table, string id, string foreignId, int foreignValue, ListBox control)
        {
            StringBuilder sb = new StringBuilder("update ");
            sb.Append(table);
            sb.Append(" set ");
            sb.Append(foreignId);
            sb.Append(" = ");
            sb.Append(foreignValue);
            sb.Append(" where ");
            sb.Append(id);
            sb.Append(" = ");
            sb.Append(((DataRowView)control.SelectedItems[0])[control.ValueMember]);
            foreach (DataRowView row in control.SelectedItems)
            {
                sb.Append(" or ");
                sb.Append(id);
                sb.Append(" = ");
                sb.Append(row[control.ValueMember]);
            }
            try
            {
                Database.ExecuteNonQuery(sb.ToString());
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Opens the form or sets focus if it already exists.
        /// </summary>
        /// <param name="formType">The form type using the typeof(FormName) expression.</param>
        public static void ShowForm(Type formType)
        {
            if (formsOpen.ContainsKey(formType))
            {
                formsOpen[formType].Activate();
                formsOpen[formType].WindowState = FormWindowState.Normal;
            }
            else
            {
                Form form = (Form)Activator.CreateInstance(formType);
                formsOpen[formType] = form;
                form.FormClosed += OnClose;
                form.Show();
            }
        }

        /// <summary>
        /// Gets the specified form based on type
        /// </summary>
        /// <param name="formType">The form type using the typeof(FormName) expression.</param>
        /// <returns>The specified form or null if it isn't open.</returns>
        public static Form GetForm(Type formType)
        {
            if (formsOpen.ContainsKey(formType))
                return formsOpen[formType];
            else
                return null;
        }

        /// <summary>
        /// Finds and closes the form if it is open.
        /// </summary>
        /// <param name="formType">The form type using the typeof(FormName) expression.</param>
        public static void CloseForm(Type formType)
        {
            if (formsOpen.ContainsKey(formType))
            {
                formsOpen[formType].Close();
            }
        }

        /// <summary>
        /// Method called by the FormClosed event.
        /// </summary>
        public static void OnClose(object sender, FormClosedEventArgs e)
        {
            formsOpen.Remove(sender.GetType());
            if (formsOpen.Count == 0)
                Application.Exit();
        }

        /// <summary>
        /// Closes all forms and displays the specified form.
        /// </summary>
        /// <param name="formType">The login form form type.</param>
        public static void LogOut(Type formType)
        {
            ShowForm(formType);
            foreach (var kvp in formsOpen.ToDictionary(kvp => kvp.Key, kvp => kvp.Value))
            {
                if (kvp.Key != formType)
                    kvp.Value.Close();
            }
        }

        /// <summary>
        /// Gets the permission stored in the database user object.
        /// </summary>
        public static Permission Permission => Database.User.Permission;

        /// <summary>
        /// Gets the id stored in the database user object.
        /// </summary>
        public static int Id {
            get
            {
                if (Database.User.Id.HasValue)
                    return Database.User.Id.Value;
                else
                    return -1;
            }
        }

        /// <summary>
        /// Checks whether the user has the specified permission type. This uses cascading permissions.
        /// If you need a specific permissions use 'Database.Permission == Permission.Type'.
        /// </summary>
        /// <param name="type">The type of permission.</param>
        public static bool HasPermission(Permission type)
        {
            return (Database.User.Permission >= type);
        }

        /// <summary>
        /// Empties all form controls, sets indexes back to -1, clears checkboxes and radios and text back to default.
        /// </summary>
        /// /// <param name="form">The form to clear the controls from.</param>
        public static void ClearControls(Control form)
        {
            foreach (Control control in form.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = string.Empty;
                }
                else if (control is RadioButton)
                {
                    RadioButton rdb = (RadioButton)control;
                    rdb.Checked = false;
                }
                else if (control is CheckBox)
                {
                    CheckBox cb = (CheckBox)control;
                    cb.Checked = false;
                }
                else if (control is ComboBox)
                {
                    ComboBox cb = (ComboBox)control;
                    if(cb.Items.Count != 0)
                        cb.SelectedIndex = 0;
                }
                else if (control is Panel)
                {
                    ClearControls(control);
                }
                else if (control is ListBox)
                {
                    ListBox lb = (ListBox)control;
                    lb.ClearSelected();
                }
                else if (control is DataGridView)
                {
                    DataGridView dgv = (DataGridView)control;
                    dgv.DataSource = null;
                }
            }
        }
    }
}