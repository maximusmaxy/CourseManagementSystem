using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Reflection;
using System.ComponentModel;

namespace CmsLibrary
{
    public static class Extensions
    {
        //dictionaries
        private static Dictionary<Control, string> defaultComboText = new Dictionary<Control, string>();
        private static Dictionary<Control, ValidationType> validationTypes = new Dictionary<Control, ValidationType>();
        private static Dictionary<Control, int> validationOptions1 = new Dictionary<Control, int>();
        private static Dictionary<Control, int> validationOptions2 = new Dictionary<Control, int>();

        /// <summary>
        /// Fills the combo box with data from a table.
        /// </summary>
        /// <param name="table">The name of the table in the database.</param>
        /// <param name="display">The name of the column in the database that represents the displayed value in the combo box.</param>
        /// <param name="value">The name of the column in the database that holds the underlying value of the combo box.</param>
        /// <param name="text">The text displayed in the combo box before an option has been selected.</param>
        public static void FillData(this ComboBox cmb, string table, string display, string value, string text)
        {
            string sql = $"select {display}, {value} from {table}";
            DataTable dataTable = Database.CreateDataTable(sql);
            cmb.DataSource = dataTable;
            cmb.DisplayMember = display;
            cmb.ValueMember = value;
            cmb.Text = text;
            defaultComboText[cmb] = text;
        }

        /// <summary>
        /// Parses the controls text into an integer.
        /// </summary>
        /// <returns>The parsed int.</returns>
        public static int Int(this Control control)
        {
            return int.Parse(control.Text);
        }

        /// <summary>
        /// Validate a textbox for a numeric value
        /// </summary>
        /// <param name="error">Optional error message to override the default.</param>
        public static Validation.Text ValidateNumeric(this TextBox control, string error = null)
        {
            return new Validation.Text(control, ValidationType.Numeric, error);
        }

        /// <summary>
        /// Validate a textbox for being empty
        /// </summary>
        /// <param name="error">Optional error message to override the default.</param>
        public static Validation.Text ValidateEmpty(this TextBox control, string error = null)
        {
            return new Validation.Text(control, ValidationType.Empty);
        }

        /// <summary>
        /// Validate a textbox for being in email format
        /// </summary>
        /// <param name="error">Optional error message to override the default.</param>
        public static Validation.Text ValidateEmail(this TextBox control, string error = null)
        {
            return new Validation.Text(control, ValidationType.Email);
        }

        /// <summary>
        /// Validate a textbox for being in Date format
        /// </summary>
        /// <param name="error">Optional error message to override the default.</param>
        public static Validation.Text ValidateDate(this TextBox control, string error = null)
        {
            return new Validation.Text(control, ValidationType.Date);
        }

        /// <summary>
        /// Validate a textbox for being a word with no numerals
        /// </summary>
        /// <param name="error">Optional error message to override the default.</param>
        public static Validation.Text ValidateWord(this TextBox control, string error = null)
        {
            return new Validation.Text(control, ValidationType.Word);
        }

        /// <summary>
        /// Validate a textbox for being a numeric value between a specific range.
        /// </summary>
        /// <param name="min">The minimum possible value.</param>
        /// <param name="max">The maximum possible value.</param>
        /// <param name="error">Optional error message to override the default.</param>
        public static Validation.IntRange ValidateRange(this TextBox control, int min, int max, string error = null)
        {
            return new Validation.IntRange(control, min, max);
        }

        /// <summary>
        /// Validates the text of a textbox for being a specific length.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="length"></param>
        /// <param name="error">Optional error message to override the default.</param>
        public static Validation.Size ValidateLength(this TextBox control, int length, string error = null)
        {
            return new Validation.Size(control, length);
        }

        /// <summary>
        /// Not Ready
        /// Sets the validation type of the control.
        /// Range options are option1 = min, option2 a = max.
        /// Length options are option1 = length
        /// </summary>
        /// <param name="type"></param>
        /// <param name="option1"></param>
        /// <param name="option2"></param>
        public static void SetValidationType(this TextBox control, ValidationType type, int option1 = 0, int option2 = 0)
        {
            ToolTip tt = GetToolTip(control);
            switch (type)
            {
                case ValidationType.Word:
                case ValidationType.Empty:
                case ValidationType.Date:
                case ValidationType.Email:
                case ValidationType.Numeric:
                case ValidationType.UnitCode:
                    validationTypes[control] = type;
                    break;
                case ValidationType.Length:
                    validationTypes[control] = type;
                    validationOptions1[control] = option1;
                    break;
                case ValidationType.Range:
                    validationTypes[control] = type;
                    validationOptions1[control] = option1;
                    validationOptions1[control] = option2;
                    break;
            }
        }

        /// <summary>
        /// Not ready
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        private static ToolTip GetToolTip(Control control)
        {
            FieldInfo fieldInfo = typeof(Form).GetField("components", BindingFlags.Instance | BindingFlags.NonPublic);
            IContainer container = (IContainer)fieldInfo.GetValue(control.FindForm());
            ToolTip tt = container.Components.OfType<ToolTip>().FirstOrDefault();
            if (tt == null)
                MessageBox.Show("Tool Tip not found. This is bad. Talk to Maxie.");
            return tt;
        }

        /// <summary>
        /// Validates all controls on a form.
        /// </summary>
        /// <param name="exceptions">Any controls you do not want to be validated.</param>
        /// <returns>The validation success.</returns>
        public static bool ValidateAll(this Form form, params Control[] exceptions)
        {
            List<Control> controls = new List<Control>();
            foreach (Control control in form.Controls)
            {
                if (control is TextBox || control is ComboBox || control is Panel)
                {
                    if (!exceptions.Contains(control))
                        controls.Add(control);
                }
            }
            return Validation.Many(controls);
        }

        /// <summary>
        /// Empties all form controls and sets indexes back to -1 and text back to default.
        /// </summary>
        public static void ClearControls(this Form form)
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
                    if (defaultComboText.ContainsKey(cb))
                        cb.Text = defaultComboText[cb];
                    else
                        cb.Text = "Please Select an Option";
                }
                else if (control is Panel)
                {
                    Panel pnl = (Panel)control;
                    foreach (RadioButton rdb in pnl.Controls.OfType<RadioButton>())
                        rdb.Checked = false;
                }
            }
        }
    }
}