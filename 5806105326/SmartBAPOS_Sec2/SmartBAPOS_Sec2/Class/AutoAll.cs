using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SmartBAPOS_Sec2.Class
{
    public class AutoTextClearAll
    {
        public void ClearTextAll(Control ParentCtr)
        {
            try
            {

                foreach (Control Ctr in ParentCtr.Controls)
                {
                    if (Ctr is TextBox)
                    {
                        Ctr.Text = "";
                    }
                    else if (Ctr is ComboBox)
                    {
                        //DirectCast(Ctr, ComboBox).SelectedIndex = 0
                    }
                    if (Ctr.Controls.Count > 0)
                    {
                        ClearTextAll(Ctr);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

    }
}
