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
    public partial class frmFindCompany : Form
    {
        public frmFindCompany()
        {
            InitializeComponent();
        }

        SqlConnection Conn;
        SqlCommand com;

        private void frmFindCompany_Load(object sender, EventArgs e)
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

        private void dgvShow_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dgvShow.Rows.Count) { return; }
            if (e.RowIndex == -1) { return; }

            DBConnString.pCpID = dgvShow.Rows[e.RowIndex].Cells["CpID"].Value.ToString();
            DBConnString.pCpName = dgvShow.Rows[e.RowIndex].Cells["CpName"].Value.ToString();
            DBConnString.pCpAddress = dgvShow.Rows[e.RowIndex].Cells["CpAddress"].Value.ToString();
            DBConnString.pCpContact = dgvShow.Rows[e.RowIndex].Cells["CpContact"].Value.ToString();
            DBConnString.pCpContact += " ( Tel : " + dgvShow.Rows[e.RowIndex].Cells["CpContactTel"].Value.ToString();
            DBConnString.pCpContact += " )";

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ShowData()//แสดงข้อมูลใน DataGridView
        {
            string sqltblBuilding;
            sqltblBuilding = "SELECT CpID, CpName, CpAddress, CpTel, CpEmail, CpWebsite, CpContact, ";
            sqltblBuilding += " CpContactTel, CpDate FROM tblSetCompany ORDER BY CpID";

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
                dgvShow.Columns[0].HeaderText = "รหัส";
                dgvShow.Columns[1].HeaderText = "ผู้จำหน่าย";
                dgvShow.Columns[2].HeaderText = "ที่อยู่";
                dgvShow.Columns[2].Visible = false;
                dgvShow.Columns[3].HeaderText = "โทรศัพท์";
                dgvShow.Columns[4].HeaderText = "เว็ปไซต์";
                dgvShow.Columns[4].Visible = false;
                dgvShow.Columns[5].HeaderText = "อีเมล์";
                dgvShow.Columns[5].Visible = false;
                dgvShow.Columns[6].HeaderText = "ผู้ติดต่อ";
                dgvShow.Columns[7].HeaderText = "โทรศัพท์";
                dgvShow.Columns[8].HeaderText = "วันที่";

                dgvShow.Columns[0].Width = 60;
                dgvShow.Columns[1].Width = 170;
                dgvShow.Columns[2].Width = 110;
                dgvShow.Columns[3].Width = 80;
                dgvShow.Columns[4].Width = 80;
                dgvShow.Columns[5].Width = 60;
                dgvShow.Columns[6].Width = 100;
                dgvShow.Columns[7].Width = 90;
                dgvShow.Columns[8].Width = 80;

                dgvShow.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvShow.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvShow.Columns[8].DefaultCellStyle.Format = "dd MMM yyyy";

                dgvShow.ClearSelection();
                dgvShow.CurrentCell = null;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFind_Click(sender, e);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text.Trim())) { return; }

            string sqltblBuilding;
            sqltblBuilding = "SELECT CpID, CpName, CpAddress, CpTel, CpEmail, CpWebsite, CpContact, ";
            sqltblBuilding += " CpContactTel, CpDate FROM tblSetCompany ";
            sqltblBuilding += " WHERE CpName Like '" + txtSearch.Text.Trim() + "%' ORDER BY CpID";

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

            if (dgvShow.RowCount > 0)
            {
                dgvShow.Columns[0].HeaderText = "รหัส";
                dgvShow.Columns[1].HeaderText = "ผู้จำหน่าย";
                dgvShow.Columns[2].HeaderText = "ที่อยู่";
                dgvShow.Columns[2].Visible = false;
                dgvShow.Columns[3].HeaderText = "โทรศัพท์";
                dgvShow.Columns[4].HeaderText = "เว็ปไซต์";
                dgvShow.Columns[4].Visible = false;
                dgvShow.Columns[5].HeaderText = "อีเมล์";
                dgvShow.Columns[5].Visible = false;
                dgvShow.Columns[6].HeaderText = "ผู้ติดต่อ";
                dgvShow.Columns[7].HeaderText = "โทรศัพท์";
                dgvShow.Columns[8].HeaderText = "วันที่";

                dgvShow.Columns[0].Width = 60;
                dgvShow.Columns[1].Width = 170;
                dgvShow.Columns[2].Width = 110;
                dgvShow.Columns[3].Width = 80;
                dgvShow.Columns[4].Width = 80;
                dgvShow.Columns[5].Width = 60;
                dgvShow.Columns[6].Width = 100;
                dgvShow.Columns[7].Width = 90;
                dgvShow.Columns[8].Width = 80;

                dgvShow.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvShow.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvShow.Columns[8].DefaultCellStyle.Format = "dd MMM yyyy";

                dgvShow.ClearSelection();
                dgvShow.CurrentCell = null;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (Conn != null)
            {
                Conn.Close();
            }
            this.Close();
        }
    }
}
