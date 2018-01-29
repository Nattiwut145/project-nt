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
    public partial class frmFindOrder : Form
    {
        public frmFindOrder()
        {
            InitializeComponent();
        }


        SqlConnection Conn;
        SqlCommand com;

        private void frmFindOrder_Load(object sender, EventArgs e)//เชื่อมต่อฐานข้อมูล
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

                //btnStatus(true);
                com = new SqlCommand();
                txtSearch.Text = "";
                ShowData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด : " + ex.Message + " โปรดตรวจสอบ", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvShow_CellDoubleClick(object sender, DataGridViewCellEventArgs e)//เลือกรายการ
        {
            if (e.RowIndex == dgvShow.Rows.Count) { return; }
            if (e.RowIndex == -1) { return; }

            DBConnString.pOrdID = dgvShow.Rows[e.RowIndex].Cells["OrdID"].Value.ToString();
            DBConnString.pOrdDate = Convert.ToDateTime(dgvShow.Rows[e.RowIndex].Cells["OrdDate"].Value.ToString());
            DBConnString.pCpID = dgvShow.Rows[e.RowIndex].Cells["CpID"].Value.ToString();
            DBConnString.pCpName = dgvShow.Rows[e.RowIndex].Cells["CpName"].Value.ToString();
            DBConnString.pCpContact = dgvShow.Rows[e.RowIndex].Cells["CpContact"].Value.ToString();
            DBConnString.pCpContact += " Tel : " + dgvShow.Rows[e.RowIndex].Cells["CpContactTel"].Value.ToString();

            DBConnString.pTotal = Convert.ToDecimal(dgvShow.Rows[e.RowIndex].Cells["OrdTotal"].Value.ToString());
            DBConnString.pDisc = Convert.ToDecimal(dgvShow.Rows[e.RowIndex].Cells["OrdDisc"].Value.ToString());
            DBConnString.pNet = Convert.ToDecimal(dgvShow.Rows[e.RowIndex].Cells["OrdNet"].Value.ToString());

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ShowData()//แสดงข้อมูลใน DataGridView
        {
            string sqltblBuilding;
            sqltblBuilding = "SELECT A.OrdID,A.OrdDate,A.CpID,B.CpName,B.CpAddress,B.CpTel,B.CpContact,B.CpContactTel,";
            sqltblBuilding += " A.OrdTotal,A.OrdDisc,A.OrdNet, CASE A.OrdStatus WHEN 0 THEN 'ค้างรับ' ELSE 'รับแล้ว' END AS OrdStatus";
            sqltblBuilding += " FROM tblOrder A INNER JOIN tblSetCompany B ON A.CpID=B.CpID WHERE A.OrdStatus=0";
            sqltblBuilding += " AND B.CpName LIKE '" + txtSearch.Text.Trim() + "%'";
            sqltblBuilding += " ORDER BY A.OrdID DESC";

            SqlDataReader dr;
            com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = sqltblBuilding;
            com.Connection = Conn;
            dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgvShow.DataSource = dt;
            }
            else
            {
                dgvShow.DataSource = null;
            }
            dr.Close();

            FormatdgvShow();
        }

        private void FormatdgvShow()//กำหนดรูปแบบการแสดงผลใน DataGridView
        {
            if (dgvShow.RowCount > 0)
            {
                dgvShow.Columns[0].HeaderText = "เลขที่ใบสั่งซื้อ";
                dgvShow.Columns[1].HeaderText = "วันที่สั่งซื้อ";
                dgvShow.Columns[2].HeaderText = "รหัสผู้จำหน่าย";
                dgvShow.Columns[2].Visible = false;
                dgvShow.Columns[3].HeaderText = "ผู้จำหน่าย";
                dgvShow.Columns[4].HeaderText = "เว็ปไซต์";
                dgvShow.Columns[4].Visible = false;
                dgvShow.Columns[5].HeaderText = "อีเมล์";
                dgvShow.Columns[5].Visible = false;
                dgvShow.Columns[6].HeaderText = "ผู้ติดต่อ";
                dgvShow.Columns[7].HeaderText = "โทรศัพท์";
                dgvShow.Columns[8].HeaderText = "รวม";
                dgvShow.Columns[8].Visible = false;
                dgvShow.Columns[9].HeaderText = "ส่วนลด";
                dgvShow.Columns[9].Visible = false;
                dgvShow.Columns[10].HeaderText = "สุทธิ";
                dgvShow.Columns[11].HeaderText = "สถานะ";

                dgvShow.Columns[0].Width = 95;
                dgvShow.Columns[1].Width = 90;
                dgvShow.Columns[2].Width = 110;
                dgvShow.Columns[3].Width = 180;
                dgvShow.Columns[4].Width = 80;
                dgvShow.Columns[5].Width = 60;
                dgvShow.Columns[6].Width = 130;
                dgvShow.Columns[7].Width = 110;
                dgvShow.Columns[8].Width = 80;
                dgvShow.Columns[10].Width = 110;
                dgvShow.Columns[11].Width = 60;

                dgvShow.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvShow.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvShow.Columns[1].DefaultCellStyle.Format = "dd MMM yyyy";
                dgvShow.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvShow.Columns[10].DefaultCellStyle.Format = "#,##0.00 ";

                dgvShow.ClearSelection();
                dgvShow.CurrentCell = null;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)//ค้นหาข้อมูลใบสั่งซื้อสินค้า
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFind_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                txtSearch.Text = "";
                ShowData();
            }
        }

        private void btnFind_Click(object sender, EventArgs e)//ค้นหาข้อมูลใบสั่งซ์้อสินค้า
        {
            if (string.IsNullOrEmpty(txtSearch.Text.Trim())) { return; }
            ShowData();
        }

        private void btnClose_Click(object sender, EventArgs e)//ปิดฟอร์ม
        {
            if (Conn != null) { Conn.Close(); }
            this.Close();
        }
    }
}
