using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CmsLibrary
{
    public enum ValidationType
    {
        Numeric,
        Word,
        Empty,
        Date,
        Email,
        Range,
        Length,
        UnitCode,
        NumericEmpty,
        Cost,
        Phone,
        ForceEmpty
    }

    public class Validation
    {
        private static Regex numericRegex = new Regex(@"^[\d\.]+$");
        private static Regex wordRegex = new Regex(@"^[A-z\s]+$");
        private static Regex dateRegex = new Regex(@"^(\d{1,2})([-/])(\d{1,2})\2(\d{4})$");
        private static Regex emailRegex = new Regex(@"^[^@]+@(?<!\.@)[^\.@]+\.[^@]+$");
        private static Regex unitCodeRegex = new Regex(@"^[a-zA-z]{6}\d{3}$");
        private static Regex costRegex = new Regex(@"^\$?\d+(?:\.\d{1,2})?$");
        private static Regex phoneRegex = new Regex(@"^(\d{8}|\d{10})$");

        public struct Text
        {
            public Control Control;
            public ValidationType Type;
            public string Error;

            public Text(Control control, ValidationType type, string error)
            {
                Control = control;
                Type = type;
                Error = error;
            }
        }

        public struct IntRange
        {
            public Control Control;
            public int Min;
            public int Max;
            public string Error;

            public IntRange(Control control, int min, int max, string error)
            {
                Control = control;
                Min = min;
                Max = max;
                Error = error;
            }
        }

        public struct Size
        {
            public Control Control;
            public int Length;
            public string Error;

            public Size(Control control, int length, string error)
            {
                Control = control;
                Length = length;
                Error = error;
            }
        }

        public struct Error
        {
            public Control Control;
            public string error;

            public Error(Control control, string error)
            {
                Control = control;
                this.error = error;
            }
        }

        public static void ShowError(Control control, string userError, string defaultError)
        {
            if (userError != null)
            {
                if (userError.Length == 0)
                    return;
                MessageBox.Show(userError);
            }
            else
                MessageBox.Show(defaultError);
        }

        public static bool Numeric(Control control, string error = null)
        {
            if (!Empty(control, error)) {
                return false;
            }
            int i;
            if (!int.TryParse(control.Text, out i))
            {
                ShowError(control, error, $"{control.Tag} is invalid. A numeric value is required.");
                return false;
            }
            return true;
        }

        public static bool Empty(Control control, string error = null)
        {
            if (string.IsNullOrEmpty(control.Text))
            {
                ShowError(control, error, $"{control.Tag} is invalid. It must not be empty.");
                return false;
            }
            return true;
        }

        public static bool ForceEmpty(Control control, string error = null)
        {
            if (!string.IsNullOrEmpty(control.Text))
            {
                ShowError(control, error, $"{control.Tag} is invalid. It must be empty.");
                    return false;
            }
            return true;
        }

        public static bool NumericEmpty(Control control, string error = null)
        {
            if (string.IsNullOrEmpty(control.Text))
                return true;
            else
                return Numeric(control, error);
        }

        public static bool Word(Control control, string error = null)
        {
            if (!Empty(control, error))
            {
                return false;
            }
            if (!wordRegex.IsMatch(control.Text))
            {
                ShowError(control, error, $"{control.Tag} is invalid. It may only contain word characters (a-z).");
                return false;
            }
            return true;
        }

        public static bool Date(DateTimePicker dtp, string error = null)
        {
            if (dtp.Value.Date == DateTime.Now.Date)
            {
                ShowError(dtp, error, $"The date for {dtp.Tag} cannot be todays date.");
                return false;
            }
            return true;
        }

        public static bool Email(Control control, string error = null)
        {
            if (!Empty(control, error))
            {
                return false;
            }
            if (!emailRegex.IsMatch(control.Text))
            {
                ShowError(control, error, $"{control.Text} is an invalid email address. Must be in the format (someone@email.com)");
                return false;
            }
            return true;
        }

        public static bool Cost(Control control, string error = null)
        {
            if (!Empty(control, error))
            {
                return false;
            }
            if (!costRegex.IsMatch(control.Text))
            {
                ShowError(control, error, $"{control.Tag} is invalid. A currency value is required.");
                return false;
            }
            return true;
        }

        public static bool Phone(Control control, string error = null)
        {
            if (!Empty(control, error))
            {
                return false;
            }
            if (!phoneRegex.IsMatch(control.Text))
            {
                ShowError(control, error, $"{control.Tag} is not a valid phone number. It must be 8 or 10 digits.");
                return false;
            }
            return true;
        }

        public static bool Radio(Panel pnl, string error = null)
        {
            RadioButton[] radios = pnl.Controls.OfType<RadioButton>().ToArray();
            if (radios.Length == 0)
                return true;
            foreach (RadioButton button in radios)
            {
                if (button.Checked)
                    return true;
            }
            ShowError(pnl, error, $"{pnl.Tag} requires an option to be selected.");
            return false;
        }

        public static bool Combo(ListControl combo, string error = null)
        {
            if (combo.SelectedIndex == -1 || (combo.DataSource != null && 
                (combo.SelectedValue == DBNull.Value || combo.SelectedValue == null)))
            {
                ShowError(combo, error, $"{combo.Tag} has no option selected. Please select an option.");
                return false;
            }
            return true; 
        }

        public static bool Range(Control control, int min, int max, string error = null)
        {
            if (!Numeric(control, error))
                return false;
            else
            {
                int range = int.Parse(control.Text);
                if (range < min || range > max)
                {
                    ShowError(control, error, $"{control.Tag} is invalid. The value must be within the range ({min}-{max}).");
                    return false;
                }
            }
            return true;
        }

        public static bool Length(Control control, int length, string error = null)
        {
            if (!Empty(control, error))
                return false;
            else
            {
                if (control.Text.Length != length)
                {
                    ShowError(control, error, $"{control.Tag} is not the required length of characters ({length}).");
                    return false;
                }
            }
            return true;
        }

        public static bool UnitCode(Control control, string error = null)
        {
            if (!Empty(control, error))
                return false;
            else
            {
                if (!unitCodeRegex.IsMatch(control.Text))
                {
                    ShowError(control, error, $"{control.Tag} is invalid. It must be in the format: 6 Letters, 3 Numbers Eg. ICTWEB413.");
                    return false;
                }
            }
            return true;
        }

        public static bool YearMonthDay(TextBox year, ComboBox month, TextBox day)
        {
            if (!Numeric(year))
                return false;
            else if (year.Int() < 0 || year.Int() > 9999)
            {
                MessageBox.Show($"Year {year.Int()} is out of range.");
                return false;
            }
            if (!string.IsNullOrEmpty(day.Text))
            {
                if (!Numeric(day))
                    return false;
                else if (month.SelectedIndex == 0)
                {
                    MessageBox.Show("Day cannot be selected while Month has not been selected.");
                    return false;
                }
                else if (!DayOfMonthInRange(year, month, day))
                {
                    MessageBox.Show($"Day number {day.Int()} is invalid for {month.Text}, {year.Int()}.");
                    return false;
                }
            }
            return true;
        }

        private static bool DayOfMonthInRange(TextBox year, ComboBox month, TextBox day)
        {
            if (day.Int() < 1)
                return false;
            switch (month.Int())
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return !(day.Int() > 31);
                case 4:
                case 6:
                case 9:
                case 11:
                    return !(day.Int() > 30);
                case 2:
                    if (year.Int() % 4 == 0)
                        return !(day.Int() > 29);
                    else
                        return !(day.Int() > 28);
            }
            throw new Exception("How did you get here?");
        }

        public static bool Many(params Object[] all)
        {
            foreach (Object obj in all)
            {
                if (obj is Text)
                {
                    Text text = (Text)obj;
                    switch (text.Type)
                    {
                        case ValidationType.Numeric:
                            if (!Numeric(text.Control, text.Error))
                                return false;
                            break;
                        case ValidationType.Word:
                            if (!Word(text.Control, text.Error))
                                return false;
                            break;
                        case ValidationType.Empty:
                            if (!Empty(text.Control, text.Error))
                                return false;
                            break;
                        case ValidationType.Email:
                            if (!Email(text.Control, text.Error))
                                return false;
                            break;
                        case ValidationType.UnitCode:
                            if (!UnitCode(text.Control, text.Error))
                                return false;
                            break;
                        case ValidationType.NumericEmpty:
                            if (!NumericEmpty(text.Control, text.Error))
                                return false;
                            break;
                        case ValidationType.Phone:
                            if (!Phone(text.Control, text.Error))
                                return false;
                            break;
                    }
                }
                else if (obj is Error)
                {
                    Error error = (Error)obj;
                    if (!ValidateControl(error.Control, error.error))
                        return false;
                }
                else if (obj is Control)
                {
                    if (!ValidateControl(obj))
                        return false;
                }
                else if (obj is IntRange)
                {
                    IntRange rng = (IntRange)obj;
                    if (!Range(rng.Control, rng.Min, rng.Max))
                        return false;
                }
                else if (obj is Size)
                {
                    Size size = (Size)obj;
                    if (!Length(size.Control, size.Length))
                        return false;
                }
                else
                {
                    throw new Exception($"{obj.GetType().Name} is invalid for the Validate Many method.");
                }
            }
            return true;
        }

        private static bool ValidateControl(object obj, string error = null)
        {
            if (obj is ListControl)
            {
                ListControl cmb = (ListControl)obj;
                if (!Combo(cmb, error))
                    return false;
            }
            else if (obj is Panel)
            {
                Panel pnl = (Panel)obj;
                if (!Radio(pnl, error))
                    return false;
            }
            else if (obj is DateTimePicker)
            {
                DateTimePicker dtp = (DateTimePicker)obj;
                if (!Date(dtp, error))
                    return false;
            }
            else if (obj is ISearchControl)
            {
                ISearchControl control = (ISearchControl)obj;
                if (!control.ValidateControl())
                    return false;
            }
            else
            {
                throw new Exception($"{obj.GetType().Name} is invalid for the Validate Many method.");
            }
            return true;
        }
    }
}
