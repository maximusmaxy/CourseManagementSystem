using System;
using System.Collections.Generic;
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
    }
}