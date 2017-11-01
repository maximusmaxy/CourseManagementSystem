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
using System.Collections;
using System.Text.RegularExpressions;

namespace CmsLibrary
{
    public static class Extensions
    {
        public static HashSet<Type> IntTypes { get; } = new HashSet<Type> { typeof(byte), typeof(short), typeof(int), typeof(long) };
        public static HashSet<Type> FloatTypes { get; } = new HashSet<Type> { typeof(float), typeof(double) };

        private static Regex camelCapitalRegex = new Regex(@"[A-Z]");

        /// <summary>
        /// Parses the controls text into an integer.
        /// </summary>
        public static int Int(this Control control)
        {
            if (control is ListControl)
            {
                ListControl lb = (ListControl)control;
                return Convert.ToInt32(lb.SelectedValue);
            }
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

        public static Validation.Text ValidatePhone(this TextBox control, string error = null)
        {
            return new Validation.Text(control, ValidationType.Phone, error);
        }

        public static Validation.Error Error(this Control control, string error)
        {
            return new Validation.Error(control, error);
        }

        public static Validation.Text ValidateForceEmpty(this TextBox control, string error = null)
        {
            return new Validation.Text(control, ValidationType.ForceEmpty, error);
        }

        /// <summary>
        /// Extends the add with value method to accept null values.
        /// </summary>
        public static SqlParameter AddWithNullValue(this SqlParameterCollection collection, string param, object value)
        {
            return collection.AddWithValue(param, value ?? DBNull.Value);
        }

        /// <summary>
        /// Allows you to convert DBNull into proper null.
        /// </summary>
        public static string ConvertDBNullString<T>(T value)
        {
            if (Convert.IsDBNull(value))
                return null;
            else
                return Convert.ToString(value);
        }

        /// <summary>
        /// Allows you to convert DBNull into a proper null.
        /// </summary>
        public static int? ConvertDBNullInt<T>(T value)
        {
            if (Convert.IsDBNull(value))
                return null;
            else
                return Convert.ToInt32(value);
        }

        /// <summary>
        /// gets the generic type from the control
        /// </summary>
        public static T Get<T>(this ListControl control)
        {
            return (T)control.SelectedValue;
        }
            

        /// <summary>
        /// Converts camel casing to human readable casing and capitalizes first letter.
        /// </summary>
        public static string CamelToHuman(string camel)
        {
            string split = camelCapitalRegex.Replace(camel, (s) => $" {s}");
            return split.First().ToString().ToUpper() + split.Substring(1);
        }

        /// <summary>
        /// Converts a database type string into a C# type object.
        /// </summary>
        public static Type DatabaseType(string type)
        {
            string noIdentity = type.Replace(" identity", "");
            switch(noIdentity)
            {
                case "varchar":
                    return typeof(string);
                case "bit":
                    return typeof(bool);
                case "date":
                    return typeof(DateTime);
                case "tinyint":
                case "smallint":
                case "int":
                    return typeof(int);
                case "float":
                    return typeof(double);
            }
            throw new ArgumentException($"Cannot determine type of database type: {type}.");
        }
    }
}