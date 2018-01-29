using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SmartBAPOS_Sec2.Class;//อิมพอตใช้โปรเจค :C

namespace SmartBAPOS_Sec2
{
    public partial class frmStartUp : Form
    {
        public frmStartUp()
        {
            InitializeComponent();
        }

        SqlConnection Conn;
        SqlCommand com;
        SqlCommand comTmp = new SqlCommand();//ตัวแปรออบเจ็กต์ SqlCommand ทำหน้าที่ประมวลผลชุดคำสั่ง SQL และผลลัพธ์ที่ได้คือออบเจ็กต์ DataReader
        DataSet ds = new DataSet();
        string SqlText;

        private void frmStartUp_Load(object sender, EventArgs e)
        {
            try
            {
                string strConn;
                strConn = DBConnString.strConn;
                Conn = new SqlConnection();
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
                Conn.ConnectionString = strConn;
                Conn.Open();

                com = new SqlCommand();

                ClearAllText(this);//ล้างข้อมูลทั้งหมดใน Text
                LoadStartUp();//แสดงข้อมูล บริษัท หน่วยงาน ร้านค้า
            }
            catch (Exception errToUser)
            {
                MessageBox.Show("เกิดข้อผิดพลาด : " + errToUser.Message + " โปรดตรวจสอบ", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearAllText(Control con)//เคลียร์คอนโทรล TextBox
        {
            foreach (Control c in con.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                else
                    ClearAllText(c);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (Conn != null) { Conn.Close(); }
            this.Close();
        }

        private void LoadStartUp()
        {
            SqlDataReader reader = null;
            try
            {
                SqlText = "SELECT * FROM tblStartUp";

                SqlCommand cmd = new SqlCommand(SqlText, Conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    txtSuName.Text = reader["SuName"].ToString();
                    txtSuTaxID.Text = reader["SuTaxID"].ToString();
                    txtSuAddress.Text = reader["SuAddress"].ToString();
                    txtSuTel.Text = reader["SuTel"].ToString();
                    txtSuEmail.Text = reader["SuEmail"].ToString();

                    txtSuName.SelectAll();
                    txtSuName.Focus();
                }
                reader.Close();
                cmd.Dispose();
            }
            catch
            {
                MessageBox.Show("ไม่พบข้อมูลเริ่มต้นระบบ", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            reader.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSuName.Text))
            {
                MessageBox.Show("กรุณาป้อน ชื่อบริษัท หน่วยงาน ร้านค้า !!!", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSuName.Focus();
                return;
            }

            if (MessageBox.Show("คุณต้องการบันทึกข้อมูล บริษัท หน่วยงาน ร้านค้า ใช่หรือไม่?", DBConnString.xMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "usp_tblStartUpDelete";
                com.Parameters.Clear();
                com.Connection = Conn;

                if (Conn.State == ConnectionState.Open) { Conn.Close(); }
                Conn.Open();
                com.ExecuteNonQuery();

                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "usp_tblStartUpInsert";
                com.Parameters.Clear();
                com.Parameters.Add("@SuTaxID", SqlDbType.NVarChar).Value = txtSuTaxID.Text.Trim();
                com.Parameters.Add("@SuName", SqlDbType.NVarChar).Value = txtSuName.Text.Trim();
                com.Parameters.Add("@SuAddress", SqlDbType.NVarChar).Value = txtSuAddress.Text.Trim();
                com.Parameters.Add("@SuTel", SqlDbType.NVarChar).Value = txtSuTel.Text.Trim();
                com.Parameters.Add("@SuEmail", SqlDbType.NVarChar).Value = txtSuEmail.Text.Trim();
                com.Connection = Conn;

                if (Conn.State == ConnectionState.Open) { Conn.Close(); }
                Conn.Open();

                com.ExecuteNonQuery();
                Conn.Close();
            }
        }
    }
}
