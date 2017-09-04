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
        /// <summary>
        /// Parses the controls text into an integer.
        /// </summary>
        public static int Int(this Control control)
        {
            return Convert.ToInt32(control.Text);
        }

        /// <summary>
        /// parses the controls text into a double.
        /// </summary>
        public static double Cost(this Control control)
        {
            return Convert.ToDouble(control.Text);
        }

        /// <summary>
        /// Parses the controls text into a nullable integer.
        /// </summary>
        public static int? NullInt(this Control control)
        {
            return string.IsNullOrEmpty(control.Text) ? null : (int?) Convert.ToInt32(control.Text);
        }

        /// <summary>
        /// Returns null if the string is empty.
        /// </summary>
        public static string NullString(this Control control)
        {
            if (control is ComboBox)
            {
                ComboBox cm = (ComboBox) control;
                return cm.SelectedIndex == -1 ? null : control.Text;
            }
            return string.IsNullOrEmpty(control.Text) ? null : control.Text;
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
            return new Validation.Text(control, ValidationType.Empty, error);
        }

        public static Validation.Text ValidateNumericEmpty(this TextBox control, string error = null)
        {
            return new Validation.Text(control, ValidationType.NumericEmpty, error);
        }

        /// <summary>
        /// Validate a textbox for being in email format
        /// </summary>
        /// <param name="error">Optional error message to override the default.</param>
        public static Validation.Text ValidateEmail(this TextBox control, string error = null)
        {
            return new Validation.Text(control, ValidationType.Email, error);
        }

        /// <summary>
        /// Validate a textbox for being in Date format
        /// </summary>
        /// <param name="error">Optional error message to override the default.</param>
        public static Validation.Text ValidateDate(this TextBox control, string error = null)
        {
            return new Validation.Text(control, ValidationType.Date, error);
        }

        /// <summary>
        /// Validate a textbox for being a word with no numerals
        /// </summary>
        /// <param name="error">Optional error message to override the default.</param>
        public static Validation.Text ValidateWord(this TextBox control, string error = null)
        {
            return new Validation.Text(control, ValidationType.Word, error);
        }

        /// <summary>
        /// Validate a textbox for being a numeric value between a specific range.
        /// </summary>
        /// <param name="min">The minimum possible value.</param>
        /// <param name="max">The maximum possible value.</param>
        /// <param name="error">Optional error message to override the default.</param>
        public static Validation.IntRange ValidateRange(this TextBox control, int min, int max, string error = null)
        {
            return new Validation.IntRange(control, min, max, error);
        }

        /// <summary>
        /// Validates the text of a textbox for being a specific length.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="length"></param>
        /// <param name="error">Optional error message to override the default.</param>
        public static Validation.Size ValidateLength(this TextBox control, int length, string error = null)
        {
            return new Validation.Size(control, length, error);
        }

        /// <summary>
        /// Validate a textbox for being in the unit code format
        /// </summary>
        /// <param name="error">Optional error message to override the default.</param>
        public static Validation.Text ValidateUnitCode(this TextBox control, string error = null)
        {
            return new Validation.Text(control, ValidationType.UnitCode, error);
        }

        /// <summary>
        /// Validates a textbex for being a currency.
        /// </summary>
        /// <param name="error">Optional error message to override the default.</param>
        /// <returns></returns>
        public static Validation.Text ValidateCost(this TextBox control, string error = null)
        {
            return new Validation.Text(control, ValidationType.Cost, error);
        }

        /// <summary>
        /// Extends the add with value method to accept null values.
        /// </summary>
        public static SqlParameter AddWithNullValue(this SqlParameterCollection collection, string param, object value)
        {
            return collection.AddWithValue(param, value == null ? DBNull.Value : value);
        }

        /// <summary>
        /// allows you to convert DBNull into proper null.
        /// </summary>
        public static string ConvertDBNullString<T>(T value)
        {
            if (value.Equals(DBNull.Value))
                return null;
            else
                return Convert.ToString(value);
        }

        /// <summary>
        /// allows you to convert DBNull into a proper null.
        /// </summary>
        public static int? ConvertDBNullInt<T>(T value)
        {
            if (value.Equals(DBNull.Value))
                return null;
            else
                return Convert.ToInt32(value);
        }
    }
}