using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.Diagnostics;
using SmartBAPOS_Sec2.Class;//อิมพอตใช้โปรเจค :C

namespace SmartBAPOS_Sec2
{
    public partial class frmLogIn : Form
    {
        public frmLogIn()
        {
            InitializeComponent();
        }

        string strConn;//ตัวแปรสำหรับสร้าง Connection Database
        SqlConnection Conn;
        SqlCommand com;
        SqlDataReader dr;
        StringBuilder sb;
        AutoClearAll aCa = new AutoClearAll();//Auto ทั้งหลายแหล่
        DataSet ds = new DataSet();

        string CurrentAuthentication;

        private void frmLogIn_Load(object sender, EventArgs e)
        {
            try
            {
                strConn = DBConnString.strConn;
                Conn = new SqlConnection();
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
                Conn.ConnectionString = strConn;
                Conn.Open();
            }
            catch (Exception errToUser)
            {
                MessageBox.Show("เกิดข้อผิดพลาด : " + errToUser.Message + " โปรดตรวจสอบ", "Smart Rent Book", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ClearAllData();
        }

        private void ClearAllData()
        {
            aCa.ClearTextAll(this);
            CurrentAuthentication = "";
            txtUsID.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if ((txtUsID.Text.Trim() == "") || (txtUsPassword.Text.Trim() == ""))
            {
                txtUsID.Focus();
                return;
            }

            bool CurrentLogin = false;
            CurrentLogin = Login(txtUsID.Text, txtUsPassword.Text);

            if (CurrentLogin == true)
            {
                if (Conn != null) { Conn.Close(); }

                DBConnString.pUsID = txtUsID.Text.Trim();
                DBConnString.pUsLevel = CurrentAuthentication;

                this.Close();
            }
            else
            {
                MessageBox.Show("ชื่อเข้าระบบ รหัสผ่าน ไม่ถูกต้อง โปรดตรวจสอบ",DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ClearAllData();
            }
        }

        private bool Login(string _UserName, string _Password)
        {
            sb = new StringBuilder();
            sb.Append("SELECT A.UsID,B.TiDetail,A.UsFirstName,A.UsLastName,C.PsLevel,A.UsPassword,A.UsStatus");
            sb.Append(" FROM tblSetUser A INNER JOIN tblSetTitle B ON A.TiID=B.TiID");
            sb.Append(" LEFT JOIN tblSetPosition C ON C.PsID=A.PsID");
            sb.Append(" WHERE A.UsStatus=1 AND UsID=@UsID AND UsPassword=@UsPassword ");

            string sqlLogin;
            sqlLogin = sb.ToString();

            error.Clear();
            string clearText = txtUsPassword.Text.Trim();
            string cipherText = CryptorEngine.Encrypt(clearText, true);

            com = new SqlCommand();
            com.CommandText = sqlLogin;
            com.CommandType = CommandType.Text;
            com.Connection = Conn;
            com.Parameters.Clear();

            com.Parameters.Add("@UsID", SqlDbType.NVarChar).Value = txtUsID.Text.Trim().ToString();
            com.Parameters.Add("@UsPassword", SqlDbType.NVarChar).Value =cipherText.Trim().ToString();

            dr = com.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                CurrentAuthentication = dr.GetString(dr.GetOrdinal("PsLevel"));
                DBConnString.pUsID = dr.GetString(dr.GetOrdinal("UsID"));
                DBConnString.pUsFullName = dr.GetString(dr.GetOrdinal("TiDetail"));
                DBConnString.pUsFullName += dr.GetString(dr.GetOrdinal("UsFirstName"));
                DBConnString.pUsFullName += " " + dr.GetString(dr.GetOrdinal("UsLastName"));
                dr.Close();
                return true;
            }
            else
            {
                dr.Close();
                return false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (Conn != null) { Conn.Close(); }
            Application.Exit();
        }

        private void txtUsId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { txtUsPassword.Focus(); }
        }

        private void txtUsPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnLogin_Click(sender, e); }
        }

        private void frmLogIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Conn != null) { Conn.Close(); }
        }
    }
}
