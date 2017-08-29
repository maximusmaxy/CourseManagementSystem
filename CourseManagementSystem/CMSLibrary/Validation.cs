using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CmsLibrary
{
    public enum ValidationType { Numeric, Word, Empty, Date, Email, Range, Length, UnitCode, NumericEmpty }

    public class Validation
    {
        static Regex numericRegex = new Regex(@"^[\d\.]+$");
        static Regex wordRegex = new Regex(@"^[A-z\s]+$");
        static Regex dateRegex = new Regex(@"^(\d{1,2})([-/])(\d{1,2})\2(\d{4})$");
        static Regex emailRegex = new Regex(@"^[^@]+@(?<!\.@)[^\.@]+\.[^@]+$");
        static Regex unitCodeRegex = new Regex(@"^\w{6}\d{3}$");

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

        public static bool Numeric(Control control, string error = null)
        {
            if (!Empty(control)) {
                return false;
            }
            int i;
            if (!int.TryParse(control.Text, out i))
            {
                if (error == null)
                    MessageBox.Show($"{control.Tag} is invalid. A numeric value is required.");
                else
                    MessageBox.Show(error);
                
                return false;
            }
            return true;
        }

        public static bool Empty(Control control, string error = null)
        {
            if (string.IsNullOrEmpty(control.Text))
            {
                if (error == null)
                    MessageBox.Show($"{control.Tag} is invalid. It must not be empty.");
                else
                    MessageBox.Show(error);
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
            if (!Empty(control))
            {
                return false;
            }
            if (!wordRegex.IsMatch(control.Text))
            {
                if (error == null)
                    MessageBox.Show($"{control.Tag} is invalid. It may only contain word characters (a-z).");
                else
                    MessageBox.Show(error);
                return false;
            }
            return true;
        }

        public static bool Date(Control control, string error = null)
        { 
            if (!Empty(control))
            {
                return false;
            }
            Match match = dateRegex.Match(control.Text);
            if (!match.Success)
            {
                MessageBox.Show($"{control.Tag} is invalid. Date is not in the correct format (DD-MM-YYYY).");
                return false;
            }
            int day = int.Parse(match.Groups[1].Value);
            if (day < 1 || day > 31)
            {
                MessageBox.Show($"{control.Tag} is invalid. The day value is out of range.");
                return false;
            }
            int month = int.Parse(match.Groups[3].Value);
            if (month < 1 || month > 12)
            {
                MessageBox.Show($"{control.Tag} is invalid. The month value is out of range.");
                return false;
            }
            int year = int.Parse(match.Groups[4].Value);
            if (year < 0)
            {
                MessageBox.Show($"{control.Tag} is invalid. The year value is out of range.");
                return false;
            }
            return true;
        }

        public static bool Email(Control control, string error = null)
        {
            if (!Empty(control))
            {
                return false;
            }
            if (!emailRegex.IsMatch(control.Text))
            {
                if (error == null)
                    MessageBox.Show($"{control.Text} is an invalid email address. Must be in the format (someone@email.com)");
                else
                    MessageBox.Show(error);
                return false;
            }
            return true;
        }

        public static bool Radio(params RadioButton[] radios)
        {
            foreach (RadioButton button in radios)
            {
                if (button.Checked)
                    return true;
            }
            MessageBox.Show($"{radios[0].Tag} requires an option to be selected.");
            return false;
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
            if (error == null)
                MessageBox.Show($"{pnl.Tag} requires an option to be selected.");
            else
                MessageBox.Show(error);
            return false;
        }

        public static bool Combo(ComboBox combo, string error = null)
        {
            if (combo.SelectedIndex == -1)
            {
                if (error == null)
                    MessageBox.Show($"{combo.Tag} has no option selected. Please select an option.");
                else
                    MessageBox.Show(error);
                return false;
            }
            return true; 
        }

        public static bool Range(Control control, int min, int max, string error = null)
        {
            if (!Numeric(control))
                return false;
            else
            {
                int range = int.Parse(control.Text);
                if (range < min || range > max)
                {
                    if (error == null)
                        MessageBox.Show($"{control.Tag} is invalid. The value must be within the range ({min}-{max}).");
                    else
                        MessageBox.Show(error);
                    return false;
                }
            }
            return true;
        }

        public static bool Length(Control control, int length, string error = null)
        {
            if (!Empty(control))
                return false;
            else
            {
                if (control.Text.Length != length)
                {
                    if (error == null)
                        MessageBox.Show($"{control.Tag} is not the required length of characters ({length}).");
                    else
                        MessageBox.Show(error);
                    return false;
                }
            }
            return true;
        }

        public static bool UnitCode(Control control, string error = null)
        {
            if (!Empty(control))
                return false;
            else
            {
                if (unitCodeRegex.IsMatch(control.Text))
                {
                    if (error == null)
                        MessageBox.Show($"{control.Tag} is invalid.It must be in the format(ICTWEB413).");
                    else
                        MessageBox.Show(error);
                }
            }
            return true;
        }

        public static bool Many(params Object[] all)
        {
            return Many(all.ToList());
        }

        public static bool Many(List<Object> all)
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
                        case ValidationType.Date:
                            if (!Date(text.Control, text.Error))
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
                    }
                }
                else if (obj is ComboBox)
                {
                    ComboBox cmb = (ComboBox)obj;
                    if (!Combo(cmb))
                    {
                        return false;
                    }
                }
                else if (obj is Panel)
                {
                    Panel pnl = (Panel)obj;
                    if (!Radio(pnl))
                    {
                        return false;
                    }
                }
                else if (obj is IntRange)
                {
                    IntRange rng = (IntRange)obj;
                    if (!Range(rng.Control, rng.Min, rng.Max))
                    {
                        return false;
                    }
                }
                else if (obj is Size)
                {
                    Size size = (Size)obj;
                    if (!Length(size.Control, size.Length))
                    {
                        return false;
                    }
                }
                else
                {
                    throw new Exception($"{obj} is invalid for the Validate Many method.");
                }
            }
            return true;
        }
    }
}
