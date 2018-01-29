using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SmartBAPOS_Sec2.Class
{
    public class CurrencyTextBox
    {
        public static bool CurrencyOnly(TextBox TargetTextBox, char CurrentChar)
        {
            if ((int)CurrentChar >= 48 && (int)CurrentChar <= 57)
            {
                return false;
            }

            if (Convert.ToString(CurrentChar) == "." && TargetTextBox.Text.IndexOf(".") == -1)
            {
                return false;
            }

            if (CurrentChar == Convert.ToChar(Keys.Back))
            {
                return false;
            }

            return true;
        }
    }
}
