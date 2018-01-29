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
    public partial class frmSetTitle : Form
    {
        public frmSetTitle()
        {
            InitializeComponent();
        }
        SqlConnection Conn;
        SqlCommand com;
        SqlTransaction tr;
        StringBuilder sb;
        DataSet ds = new DataSet();
        string SqlText = "";
        AutoClearAll aCa = new AutoClearAll();

        private void btnStatus(bool xStatus)
        {
            if (xStatus == true)
            {
                aCa.ClearTextAll(this);
                txtTiID.Focus();
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

        private void ShowData()
        {
            SqlText = "SELECT TiID,TiDetail FROM tblSetTitle ORDER BY TiID";

            SqlDataReader dr;
            com = new SqlCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = SqlText;
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
                dgvShow.Columns[1].HeaderText = "คำนำหน้าชื่อ";
                dgvShow.Columns[0].Width = 120;
                dgvShow.Columns[1].Width = 430;

                dgvShow.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgvShow.ClearSelection();
            dgvShow.CurrentCell = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTiID.Text))
            {
                MessageBox.Show("กรุณาป้อนรหัส", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTiID.SelectAll();
                txtTiID.Focus();
                return;
            }
            else if (txtTiID.Text.Length != 6)
            {
                MessageBox.Show("กรุณาป้อนรหัส ให้ครบ6 อักษร", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTiID.SelectAll();
                txtTiID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtTiDetail.Text))
            {
                MessageBox.Show("กรุณาป้อนคำนำหน้าชื่อ", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTiDetail.SelectAll();
                txtTiDetail.Focus();
                return;
            }

            if (MessageBox.Show("คุณต้องการเพิ่มคำนำหน้าชื่อ ใช่หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                tr = Conn.BeginTransaction();
                try
                {
                    sb = new StringBuilder();
                    sb.Append("INSERT INTO tblSetTitle(TiID,TiDetail)");
                    sb.Append(" VALUES(@TiID,@TiDetail)");
                    SqlText = sb.ToString();

                    com.CommandText = SqlText;
                    com.CommandType = CommandType.Text;
                    com.Connection = Conn;
                    com.Transaction = tr;
                    com.Parameters.Clear();
                    com.Parameters.Add("@TiID", SqlDbType.NVarChar).Value = txtTiID.Text.Trim();
                    com.Parameters.Add("@TiDetail", SqlDbType.NVarChar).Value = txtTiDetail.Text.Trim();
                    com.ExecuteNonQuery();
                    tr.Commit();
                    MessageBox.Show("บันทึกข้อมูล คำนำหน้าชื่อ เรียบร้อยแล้ว", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (string.IsNullOrEmpty(txtTiID.Text))
            {
                MessageBox.Show("กรุณาป้อนรหัส", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTiID.SelectAll();
                txtTiID.Focus();
                return;
            }
            else if (txtTiID.Text.Length != 6)
            {
                MessageBox.Show("กรุณาป้อนรหัส ให้ครบ6 อักษร", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTiID.SelectAll();
                txtTiID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtTiDetail.Text))
            {
                MessageBox.Show("กรุณาป้อนคำนำหน้าชื่อ", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTiDetail.SelectAll();
                txtTiDetail.Focus();
                return;
            }

            if (MessageBox.Show("คุณต้องการแก้ไขคำนำหน้าชื่อ ใช่หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                tr = Conn.BeginTransaction();
                try
                {
                    sb = new StringBuilder();
                    sb.Append("UPDATE tblSetTitle SET TiDetail=@TiDetail");
                    sb.Append(" WHERE @TiID=TiID");
                    SqlText = sb.ToString();

                    com.CommandText = SqlText;
                    com.CommandType = CommandType.Text;
                    com.Connection = Conn;
                    com.Transaction = tr;
                    com.Parameters.Clear();
                    com.Parameters.Add("@TiID", SqlDbType.NVarChar).Value = txtTiID.Text.Trim();
                    com.Parameters.Add("@TiDetail", SqlDbType.NVarChar).Value = txtTiDetail.Text.Trim();
                    com.ExecuteNonQuery();
                    tr.Commit();
                    MessageBox.Show("แก้ไขข้อมูล คำนำหน้าชื่อ เรียบร้อยแล้ว", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (string.IsNullOrEmpty(txtTiID.Text))
            {
                MessageBox.Show("กรุณาป้อนรหัส", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTiID.SelectAll();
                txtTiID.Focus();
                return;
            }

            if (MessageBox.Show("คุณต้องการลบคำนำหน้าชื่อ ใช่หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                tr = Conn.BeginTransaction();
                try
                {
                    sb = new StringBuilder();
                    sb.Append("DELETE FROM tblSetTitle");
                    sb.Append(" WHERE @TiID=TiID");
                    SqlText = sb.ToString();

                    com.CommandText = SqlText;
                    com.CommandType = CommandType.Text;
                    com.Connection = Conn;
                    com.Transaction = tr;
                    com.Parameters.Clear();
                    com.Parameters.Add("@TiID", SqlDbType.NVarChar).Value = txtTiID.Text.Trim();
                    //com.Parameters.Add("@TiDetail", SqlDbType.NVarChar).Value = txtTiDetail.Text.Trim(); ไม่ใช่นะจ่ะ :D
                    com.ExecuteNonQuery();
                    tr.Commit();
                    MessageBox.Show("ลบข้อมูล คำนำหน้าชื่อ เรียบร้อยแล้ว", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtTiID.Text = dgvShow.Rows[e.RowIndex].Cells["TiID"].Value.ToString();
            txtTiDetail.Text = dgvShow.Rows[e.RowIndex].Cells["TiDetail"].Value.ToString();

            btnStatus(false);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnStatus(true);
        }

        private void frmSetTitle_Load(object sender, EventArgs e)
        {
            try
            {
                string strConn = DBConnString.strConn;
                Conn = new SqlConnection();
                if (Conn.State == ConnectionState.Open) //เช็คว่าต่ออยู่ไหม ต่อแล้วปิดก่อน ค่อยต่อใหม่ :D
                {
                    Conn.Close();
                }
                Conn.ConnectionString = strConn; //ต่อฐานข้อมูล <(^0^)>
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
    }
}
