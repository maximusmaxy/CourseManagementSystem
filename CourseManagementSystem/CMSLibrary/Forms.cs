using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CmsLibrary
{
    public class Forms
    {
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
        /// Checks a specific radio button on a panel based on a value specified by an enum.
        /// </summary>
        /// <param name="pnl">The panel holding the radio buttons.</param>
        /// <param name="enumType">The enum to obtain the value from.</param>
        /// <param name="value">The value to check.</param>
        public static void CheckRadio(Panel pnl, Type enumType, int value)
        {
            pnl.Controls.OfType<RadioButton>().
                FirstOrDefault(r => (int)Enum.Parse(enumType, r.Text) == value).Checked = true;
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
        /// Sets all checked values of radio buttons on a panel to false.
        /// </summary>
        /// <param name="pnl">The panel holding the radio buttons.</param>
        public static void ClearRadio(Panel pnl)
        {
            foreach (RadioButton rdb in pnl.Controls.OfType<RadioButton>())
                rdb.Checked = false;
        }

        /// <summary>
        /// Gets the value of a radio specified by the enum.
        /// </summary>
        /// <param name="pnl">The panel containing the radio buttons.</param>
        /// <param name="enumType">The enum supplying the names and values.</param>
        /// <returns></returns>
        public static int RadioValue(Panel pnl, Type enumType)
        {
            return (int)Enum.Parse(enumType, RadioString(pnl));
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
        /// <param name="text">The text displayed in the combo box before an option has been selected.</param>
        public static void FillData(ListControl control, string table, string display, string value)
        {
            if (control is ListBox)
            {
                ListBox lb = (ListBox)control;
                lb.SelectionMode = SelectionMode.MultiSimple;
            }
            string sql = $"select {display}, {value} from {table}";
            DataTable dataTable = Database.CreateDataTable(sql);
            control.DataSource = dataTable;
            control.DisplayMember = display;
            control.ValueMember = value;
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
        /// Empties all form controls and sets indexes back to -1 and text back to default.
        /// </summary>
        public static void ClearControls(Form form)
        {
            foreach (Control control in form.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = string.Empty;
                }
                else if (control is ComboBox)
                {
                    ComboBox cb = (ComboBox)control;
                    cb.SelectedIndex = -1;
                    cb.Text = "";
                }
                else if (control is Panel)
                {
                    Panel pnl = (Panel)control;
                    foreach (RadioButton rdb in pnl.Controls.OfType<RadioButton>())
                        rdb.Checked = false;
                }
                else if (control is ListBox)
                {
                    ListBox lb = (ListBox)control;
                    lb.ClearSelected();
                }
            }
        }
    }
}