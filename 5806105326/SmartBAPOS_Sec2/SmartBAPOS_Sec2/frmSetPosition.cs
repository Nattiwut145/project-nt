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
    public partial class frmSetPosition : Form
    {
        public frmSetPosition()
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
                txtPsID.Focus();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPsID.Text))
            {
                MessageBox.Show("กรุณาป้อนรหัส", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPsID.SelectAll();
                txtPsID.Focus();
                return;
            }
            else if (txtPsID.Text.Length != 6)
            {
                MessageBox.Show("กรุณาป้อนรหัส ให้ครบ6 อักษร", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPsID.SelectAll();
                txtPsID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPsDetail.Text))
            {
                MessageBox.Show("กรุณาป้อนข้อมูล ตำแหน่ง", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPsDetail.SelectAll();
                txtPsDetail.Focus();
                return;
            }

            if (MessageBox.Show("คุณต้องการเพิ่มข้อมูล ตำแหน่ง ใช่หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                tr = Conn.BeginTransaction();
                try
                {
                    sb = new StringBuilder();
                    sb.Append("INSERT INTO tblSetPosition(PsID,PsDetail,PsLevel)");                
                    sb.Append(" VALUES(@PsID,@PsDetail,@PsLevel)");
                    SqlText = sb.ToString();

                    com.CommandText = SqlText;
                    com.CommandType = CommandType.Text;
                    com.Connection = Conn;
                    com.Transaction = tr;
                    com.Parameters.Clear();
                    com.Parameters.Add("@PsID", SqlDbType.NVarChar).Value = txtPsID.Text.Trim();
                    com.Parameters.Add("@PsDetail", SqlDbType.NVarChar).Value = txtPsDetail.Text.Trim();

                    if (rdoAdmin.Checked == true)
                    {
                        com.Parameters.Add("@PsLevel", SqlDbType.NVarChar).Value = "Admin";
                    }
                    if (rdoUser.Checked == true)
                    {
                        com.Parameters.Add("@PsLevel", SqlDbType.NVarChar).Value = "User";
                    }

                    com.ExecuteNonQuery();
                    tr.Commit();
                    MessageBox.Show("เพิ่มข้อมูล ตำแหน่ง เรียบร้อยแล้ว", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void frmSetPosition_Load(object sender, EventArgs e)
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

        private void ShowData()
        {
            SqlText = "SELECT PsID,PsDetail,PsLevel FROM tblSetPosition ORDER BY PsID";

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
                dgvShow.Columns[1].HeaderText = "ตำแหน่ง";
                dgvShow.Columns[2].HeaderText = "ระดับสิทธิ์";
                dgvShow.Columns[0].Width = 120;
                dgvShow.Columns[1].Width = 320;
                dgvShow.Columns[2].Width = 100;

                dgvShow.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgvShow.ClearSelection();
            dgvShow.CurrentCell = null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPsID.Text))
            {
                MessageBox.Show("กรุณาป้อนรหัส", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPsID.SelectAll();
                txtPsID.Focus();
                return;
            }
            else if (txtPsID.Text.Length != 6)
            {
                MessageBox.Show("กรุณาป้อนรหัส ให้ครบ6 อักษร", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPsID.SelectAll();
                txtPsID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPsDetail.Text))
            {
                MessageBox.Show("กรุณาป้อนข้อมูล ตำแหน่ง", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPsDetail.SelectAll();
                txtPsDetail.Focus();
                return;
            }
           
            if (MessageBox.Show("คุณต้องการแก้ไขข้อมูล ตำแหน่ง ใช่หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                tr = Conn.BeginTransaction();
                try
                {
                    sb = new StringBuilder();
                    sb.Append("UPDATE tblSetPosition SET PsDetail=@PsDetail, PsLevel=@PsLevel");                  
                    sb.Append(" WHERE @PsID=PsID");
                    SqlText = sb.ToString();

                    com.CommandText = SqlText;
                    com.CommandType = CommandType.Text;
                    com.Connection = Conn;
                    com.Transaction = tr;
                    com.Parameters.Clear();
                    com.Parameters.Add("@PsID", SqlDbType.NVarChar).Value = txtPsID.Text.Trim();
                    com.Parameters.Add("@PsDetail", SqlDbType.NVarChar).Value = txtPsDetail.Text.Trim();
                    if (rdoAdmin.Checked == true)
                    {
                        com.Parameters.Add("@PsLevel", SqlDbType.NVarChar).Value = "Admin";
                    }
                    if (rdoUser.Checked == true)
                    {
                        com.Parameters.Add("@PsLevel", SqlDbType.NVarChar).Value = "User";
                    }
                    com.ExecuteNonQuery();
                    tr.Commit();
                    MessageBox.Show("แก้ไขข้อมูล ตำแหน่ง เรียบร้อยแล้ว", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (string.IsNullOrEmpty(txtPsID.Text))
            {
                MessageBox.Show("กรุณาป้อนรหัส", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPsID.SelectAll();
                txtPsID.Focus();
                return;
            }

            if (MessageBox.Show("คุณต้องการลบข้อมูล ตำแหน่ง ใช่หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                tr = Conn.BeginTransaction();
                try
                {
                    sb = new StringBuilder();
                    sb.Append("DELETE FROM tblSetPosition");
                    sb.Append(" WHERE @PsID=PsID");
                    SqlText = sb.ToString();

                    com.CommandText = SqlText;
                    com.CommandType = CommandType.Text;
                    com.Connection = Conn;
                    com.Transaction = tr;
                    com.Parameters.Clear();
                    com.Parameters.Add("@PsID", SqlDbType.NVarChar).Value = txtPsID.Text.Trim();
                    com.ExecuteNonQuery();
                    tr.Commit();
                    MessageBox.Show("ลบข้อมูล ตำแหน่ง เรียบร้อยแล้ว", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtPsID.Text = dgvShow.Rows[e.RowIndex].Cells["PsID"].Value.ToString();
            txtPsDetail.Text = dgvShow.Rows[e.RowIndex].Cells["PsDetail"].Value.ToString();

            if (dgvShow.Rows[e.RowIndex].Cells["PsLevel"].Value.ToString() == "Admin")
            {
                rdoAdmin.Checked = true;
            }

            if (dgvShow.Rows[e.RowIndex].Cells["PsLevel"].Value.ToString() == "User")
            {
                rdoUser.Checked = true;
            }
            btnStatus(false);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnStatus(true);
        }
    }
}
