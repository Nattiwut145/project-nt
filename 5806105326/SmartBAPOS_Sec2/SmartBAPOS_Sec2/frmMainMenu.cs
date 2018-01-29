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
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        SqlConnection Conn;
        SqlCommand com;
        SqlCommand comTmp = new SqlCommand();//ตัวแปรออบเจ็กต์ SqlCommand ทำหน้าที่ประมวลผลชุดคำสั่ง SQL และผลลัพธ์ที่ได้คือออบเจ็กต์ DataReader
        SqlTransaction tr;
        StringBuilder sb;
        DataSet ds = new DataSet();
        string SqlText = "";

        private void LoadStartUp()//โหลดข้อมูลเริ่มต้น บริษัท หน่วยงาน ร้านค้า
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด : " + ex.Message + " โปรดตรวจสอบ", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            SqlDataReader reader = null;
            try
            {
                SqlText = "SELECT * FROM tblStartUp";

                SqlCommand cmd = new SqlCommand(SqlText, Conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PublicVariable.pSuName = reader["SuName"].ToString();
                    PublicVariable.pSuAddress = "เลขประจำตัวผู้เสียภาษี : " + reader["SuTaxID"].ToString();
                    PublicVariable.pSuAddress += " ที่อยู่ : " + reader["SuAddress"].ToString();
                    PublicVariable.pSuAddress += " โทรศัพท์ : " + reader["SuTel"].ToString();
                    PublicVariable.pSuAddress += " อีเมล : " + reader["SuEmail"].ToString();
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

        private void CloseAllChildForm()//ปิดฟอร์มทั้งหมด
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }

            crvRep.Visible = false;
        }

        private void rbFiles_Exit_Click(object sender, EventArgs e)//เลิกงาน
        {
            if (MessageBox.Show("คุณต้องเลิกงาน ใช่หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (Conn != null) { Conn.Close(); }
                Application.Exit();
            }
        }

        private void rbPOS_SearchProduct_Click(object sender, EventArgs e)//เมนูค้นหาสินค้า
        {
            CloseAllChildForm();

            //frmProductSearch fMenu = new frmProductSearch();
            //fMenu.MdiParent = this;
            //fMenu.StartPosition = FormStartPosition.CenterScreen;
            //fMenu.Show();
        }

        private void rbPOS_Sales_Click(object sender, EventArgs e)//เมนูขายสินค้า
        {
            CloseAllChildForm();

            frmPOS fMenu = new frmPOS();
            fMenu.MdiParent = this;
            fMenu.StartPosition = FormStartPosition.CenterScreen;
            fMenu.Show();
        }

        private void rbFiles_POS_Click(object sender, EventArgs e)//เมนูขายสินค้า
        {
            rbPOS_Sales_Click(sender, e);
        }

        private void rbFiles_Product_Click(object sender, EventArgs e)//เมนูข้อมูลสินค้า
        {
            CloseAllChildForm();

            frmProduct fMenu = new frmProduct();
            fMenu.MdiParent = this;
            fMenu.StartPosition = FormStartPosition.CenterScreen;
            fMenu.Show();
        }

        private void rbSetup_SetTitle_Click(object sender, EventArgs e)//เมนูข้อมูลคำนำหน้าชื่อ
        {
            CloseAllChildForm();

            frmSetTitle fMenu = new frmSetTitle();
            fMenu.MdiParent = this;
            fMenu.StartPosition = FormStartPosition.CenterScreen;
            fMenu.Show();
        }

        private void rbSetup_SetPosition_Click(object sender, EventArgs e)//เมนูข้อมูลตำแหน่ง
        {
            CloseAllChildForm();

            frmSetPosition fMenu = new frmSetPosition();
            fMenu.MdiParent = this;
            fMenu.StartPosition = FormStartPosition.CenterScreen;
            fMenu.Show();
        }

        private void rbSetup_SetUser_Click(object sender, EventArgs e)//เมนูข้อมูลผู้ใช้งานระบบ
        {
            CloseAllChildForm();

            frmSetUser fMenu = new frmSetUser();
            fMenu.MdiParent = this;
            fMenu.StartPosition = FormStartPosition.CenterScreen;
            fMenu.Show();
        }

        private void rbSetup_StartUp_Click(object sender, EventArgs e)//เมนูข้อมูลบริษัท หน่วยงาน ร้านค้า
        {
            CloseAllChildForm();

            frmStartUp fMenu = new frmStartUp();
            fMenu.MdiParent = this;
            fMenu.StartPosition = FormStartPosition.CenterScreen;
            fMenu.Show();
        }

        private void rbSetup_SetProductType_Click(object sender, EventArgs e)//เมนูข้อมูลประเภทสินค้า
        {
            CloseAllChildForm();

            frmSetProductType fMenu = new frmSetProductType();
            fMenu.MdiParent = this;
            fMenu.StartPosition = FormStartPosition.CenterScreen;
            fMenu.Show();
        }

        private void rbSetup_SetUnit_Click(object sender, EventArgs e)//เมนูข้อมูลหน่วยนับ
        {
            CloseAllChildForm();

            frmSetUnit fMenu = new frmSetUnit();
            fMenu.MdiParent = this;
            fMenu.StartPosition = FormStartPosition.CenterScreen;
            fMenu.Show();
        }

        private void rbSetup_SetCompany_Click(object sender, EventArgs e)//เมนูข้อมูลผู้จำหน่าย
        {
            CloseAllChildForm();

            frmSetCompany fMenu = new frmSetCompany();
            fMenu.MdiParent = this;
            fMenu.StartPosition = FormStartPosition.CenterScreen;
            fMenu.Show();
        }

        private void rbOrdRec_Order_Click(object sender, EventArgs e)//เมนูข้อมูลสั่งซื้อสินค้า
        {
            CloseAllChildForm();

            frmOrder fMenu = new frmOrder();
            fMenu.MdiParent = this;
            fMenu.StartPosition = FormStartPosition.CenterScreen;
            fMenu.Show();
        }

        private void rbOrdRec_Receive_Click(object sender, EventArgs e)//เมนูข้อมูลรับเข้าสินค้า
        {
            CloseAllChildForm();

            frmReceive fMenu = new frmReceive();
            fMenu.MdiParent = this;
            fMenu.StartPosition = FormStartPosition.CenterScreen;
            fMenu.Show();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)//โหลดข้อมูลเริ่มต้น
        {
            lblUsFullName.Text = "";
            CloseAllChildForm();

            frmLogIn fMenu = new frmLogIn();
            //fMenu.MdiParent = this;
            fMenu.StartPosition = FormStartPosition.CenterScreen;
            fMenu.ShowDialog();

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด : " + ex.Message + " โปรดตรวจสอบ", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            AuthenCheck();            
        }

        private void AuthenCheck()//เมนูตรวจสอบสิทธิ์
        {
            lblUsFullName.Text = "ผู้ใช้งาน : " + DBConnString.pUsFullName + " ระดับสิทธิ์ : " + DBConnString.pUsLevel;
            if (DBConnString.pUsLevel.ToUpper()=="ADMIN")
            {
                rbOrdRec.Enabled=true;
                rbSetup.Enabled=true;
                rbSetup_SetStartUp.Enabled = true;
            }

            if (DBConnString.pUsLevel.ToUpper()=="USER")
            {
                rbOrdRec.Enabled=false;
                rbSetup.Enabled=false;
                rbSetup_SetStartUp.Enabled = false;
            }

            LoadStartUp();
        }

        private void frmMainMenu_Activated(object sender, EventArgs e)//Event สถานะ Active
        {
            lblUsFullName.Text = "";
            AuthenCheck();
        }

        private void rbAbout_Me_Click(object sender, EventArgs e)//เมนูข้อมูลเกี่ยวกับผู้พัฒนาระบบ
        {
            CloseAllChildForm();

            AuthenCheck();

            frmAboutMe fMenu = new frmAboutMe();
            fMenu.MdiParent = this;
            fMenu.StartPosition = FormStartPosition.CenterScreen;
            fMenu.Show();

            AuthenCheck();
        }

        private void rbReport_Product_Click(object sender, EventArgs e)//เมนูรายงานสินค้า
        {
            PrintRepProduct(true);
        }

        private void PrintRepProduct(bool xRepType)//พิมพ์รายงานสินค้า
        {
            DropTmpTable();//ลบข้อมูลตารางชั่วคราว

            try
            {
                tr = Conn.BeginTransaction();
                sb = new StringBuilder();

                sb.Append(" SELECT * INTO _repProduct" + DBConnString.pUsID);//ใส่ในตารางที่สร้างขึ้นใหม่
                sb.Append(" FROM vwProduct");
                if (xRepType == false)//รายงานสินค้าถึงจุดสั่งซื้อ
                {
                    sb.Append(" WHERE ProMin > ProNum");
                }
                SqlText = sb.ToString();
                com = new SqlCommand();
                com.CommandText = SqlText;
                com.CommandType = CommandType.Text;
                com.Connection = Conn;
                com.Transaction = tr;
                com.Parameters.Clear();
                com.ExecuteNonQuery();
                tr.Commit();

                //SqlConnection cnn;
                //string connectionString = null;
                //string sql = null;

                //connectionString = DBConnString.strConn;
                //cnn = new SqlConnection(connectionString);
                //cnn.Open();
                //sql = "SELECT * FROM " + "_repProduct" + DBConnString.pUsID;
                //SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
                //repProduct_DATA ds = new repProduct_DATA();
                //dscmd.Fill(ds, "repProduct");
                //cnn.Close();

                //repProduct objRpt = new repProduct();
                //objRpt.SetDataSource(ds.Tables[1]);

                //if (xRepType == true)//หัวรายงานสินค้า
                //{
                //    objRpt.DataDefinition.FormulaFields["xReportTitle"].Text = "'รายงานข้อมูลสินค้า'";
                //}
                //if (xRepType == false)//หัวรายงานสินค้าถึงจุดสั่งซื้อ
                //{
                //    objRpt.DataDefinition.FormulaFields["xReportTitle"].Text = "'รายงานข้อมูลสินค้าถึงจุดสั่งซื้อ'";
                //}
                
                //objRpt.DataDefinition.FormulaFields["xSuName"].Text = "'" + PublicVariable.pSuName + "'";
                //objRpt.DataDefinition.FormulaFields["xSuAddress"].Text = "'" + PublicVariable.pSuAddress + "'";
                //objRpt.DataDefinition.FormulaFields["xUsFullName"].Text = "'พิมพ์โดย : '" + "'" + DBConnString.pUsFullName + "'";

                //crvRep.Visible = true;
                //crvRep.Dock = DockStyle.Fill;

                //crvRep.ReportSource = objRpt;
                //objRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                //crvRep.Refresh();

                DropTmpTable();//ลบข้อมูลตารางชั่วคราว
            }
            catch (Exception Err)
            {
                MessageBox.Show("เกิดข้อผิดพลาด : " + Err.Message, DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tr.Rollback();
                return;
            }
        }

        private void DropTmpTable()//ลบข้อมูลในตารางชั่วคราวก่อน Query
        {
            tr = Conn.BeginTransaction();
            try
            {
                sb = new StringBuilder();
                sb.Append("DROP TABLE _repProduct" + DBConnString.pUsID);

                com = new SqlCommand();
                string sqlAdd;
                sqlAdd = sb.ToString();
                com.CommandType = CommandType.Text;
                com.CommandText = sqlAdd;
                com.Connection = Conn;
                com.Transaction = tr;
                com.Parameters.Clear();
                com.ExecuteNonQuery();
                tr.Commit();
            }
            catch
            {
                tr.Rollback();
            }
        }

        private void crvRep_DoubleClick(object sender, EventArgs e)//ปิด Crystal Report Viewer
        {
            crvRep.Visible = false;
        }

        private void rbSetup_ProductDecrease_Click(object sender, EventArgs e)//รายงานสินค้าถึงจุดสั่งซื้อ
        {
            PrintRepProduct(false);
        }

        private void rbReport_Income_Click(object sender, EventArgs e)//รายงานสรุปรายได้
        {
            CloseAllChildForm();

            //frmRepIncome fMenu = new frmRepIncome();
            //fMenu.MdiParent = this;
            //fMenu.StartPosition = FormStartPosition.CenterScreen;
            //fMenu.Show();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

    }
}
