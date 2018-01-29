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
    public partial class frmSetProductType : Form
    {
        public frmSetProductType()
        {
            InitializeComponent();
        }
        SqlConnection Conn;
        SqlCommand com;
        SqlTransaction tr;
        StringBuilder sb;
        DataSet ds = new DataSet();
        string sqlText = "";
        AutoClearAll aCa = new AutoClearAll();

        private void btnStatus(bool xStatus)
        {
            if (xStatus == true)
            {
                aCa.ClearTextAll(this);
                txtPtID.Focus();
                btnAdd.Enabled = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSetProductType_Load(object sender, EventArgs e)
        {
            try
            {
                string strConn = DBConnString.strConn;
                Conn = new SqlConnection();
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
                Conn.ConnectionString = strConn;
                Conn.Open();

                btnStatus(true);
                com = new SqlCommand();
                ShowData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด : " + ex.Message + "โปรดตรวจสอบ", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void ShowData()
        {
            sqlText = "SELECT PtID,PtDetail FROM tblSetProductType ORDER BY PtID";

            SqlDataReader dr;
            com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = sqlText;
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
                dgvShow.Columns[0].HeaderText = "รหัสสินค้า";
                dgvShow.Columns[1].HeaderText = "ประเภทสินค้า";
                dgvShow.Columns[0].Width = 120;
                dgvShow.Columns[1].Width = 460;

                dgvShow.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgvShow.ClearSelection();
            dgvShow.CurrentCell = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPtID.Text))
            {
                MessageBox.Show("กรุณาป้อนรหัสสินค้า", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPtID.SelectAll();
                txtPtID.Focus();
                return;
            }
            else if (txtPtID.Text.Length != 6)
            {
                MessageBox.Show("กรุณาป้อนรหัส ให้ครบ 6 อักษร", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPtID.SelectAll();
                txtPtID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPtDetail.Text))
            {
                MessageBox.Show("กรุณาป้อนประเภทสินค้า", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPtDetail.SelectAll();
                txtPtDetail.Focus();
                return;
            }

            if (MessageBox.Show("คุณต้องการเพิ่มข้อมูลประเภทสินค้า ใช่หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                tr = Conn.BeginTransaction();
                try
                {
                    sb = new StringBuilder();
                    sb.Append("INSERT INTO tblSetProductType(PtID,PtDetail)");
                    sb.Append(" VALUES(@PtID,@PtDetail)");
                    sqlText = sb.ToString();

                    com.CommandText = sqlText;
                    com.CommandType = CommandType.Text;
                    com.Connection = Conn;
                    com.Transaction = tr;
                    com.Parameters.Clear();
                    com.Parameters.Add("@PtID", SqlDbType.NVarChar).Value = txtPtID.Text.Trim();
                    com.Parameters.Add("@PtDetail", SqlDbType.NVarChar).Value = txtPtDetail.Text.Trim();
                    com.ExecuteNonQuery();
                    tr.Commit();
                    MessageBox.Show("บันทึกข้อมูล ประเภทสินค้า เรียบร้อยแล้ว", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาด : " + ex.Message + "โปรดตรวจสอบ", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                btnStatus(true);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPtID.Text))
            {
                MessageBox.Show("กรุณาป้อนรหัสสินค้า", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPtID.SelectAll();
                txtPtID.Focus();
                return;
            }
            else if (txtPtID.Text.Length != 6)
            {
                MessageBox.Show("กรุณาป้อนรหัส ให้ครบ 6 อักษร", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPtID.SelectAll();
                txtPtID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPtDetail.Text))
            {
                MessageBox.Show("กรุณาป้อนประเภทสินค้า", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPtDetail.SelectAll();
                txtPtDetail.Focus();
                return;
            }

            if (MessageBox.Show("คุณต้องการแก้ไขข้อมูลประเภทสินค้า ใช่หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                tr = Conn.BeginTransaction();
                try
                {
                    sb = new StringBuilder();
                    sb.Append("UPDATE tblSetProductType SET PtDetail=@PtDetail");
                    sb.Append(" WHERE @PtID=PtID");
                    sqlText = sb.ToString();

                    com.CommandText = sqlText;
                    com.CommandType = CommandType.Text;
                    com.Connection = Conn;
                    com.Transaction = tr;
                    com.Parameters.Clear();
                    com.Parameters.Add("@PtID", SqlDbType.NVarChar).Value = txtPtID.Text.Trim();
                    com.Parameters.Add("@PtDetail", SqlDbType.NVarChar).Value = txtPtDetail.Text.Trim();
                    com.ExecuteNonQuery();
                    tr.Commit();
                    MessageBox.Show("แก้ไขข้อมูล ประเภทสินค้า เรียบร้อยแล้ว", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาด : " + ex.Message + "โปรดตรวจสอบ", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                btnStatus(true);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPtID.Text))
            {
                MessageBox.Show("กรุณาป้อนรหัสสินค้า  ", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPtID.SelectAll();
                txtPtID.Focus();
                return;
            }

            if (MessageBox.Show("คุณต้องการลบข้อมูลประเภทสินค้า ใช่หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                tr = Conn.BeginTransaction();
                try
                {
                    sb = new StringBuilder();
                    sb.Append("DELETE FROM tblSetProductType");
                    sb.Append(" WHERE @PtID=PtID");
                    sqlText = sb.ToString();

                    com.CommandText = sqlText;
                    com.CommandType = CommandType.Text;
                    com.Connection = Conn;
                    com.Transaction = tr;
                    com.Parameters.Clear();
                    com.Parameters.Add("@PtID", SqlDbType.NVarChar).Value = txtPtID.Text.Trim();
                    //com.Parameters.Add("@PtDetail", SqlDbType.NVarChar).Value = txtPtDetail.Text.Trim();
                    com.ExecuteNonQuery();
                    tr.Commit();
                    MessageBox.Show("ลบข้อมูล ประเภทสินค้า เรียบร้อยแล้ว", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาด : " + ex.Message + "โปรดตรวจสอบ", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                btnStatus(true);
            }
        }

        private void dgvShow_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.RowIndex == dgvShow.Rows.Count) || (e.RowIndex == -1))
            {
                return;
            }
            txtPtID.Text = dgvShow.Rows[e.RowIndex].Cells["PtID"].Value.ToString();
            txtPtDetail.Text = dgvShow.Rows[e.RowIndex].Cells["PtDetail"].Value.ToString();

            btnStatus(false);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnStatus(true);
        }
    }
}
