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
    public partial class frmSetUser : Form
    {
        public frmSetUser()
        {
            InitializeComponent();
        }

        SqlConnection Conn;
        SqlCommand com;
        SqlTransaction tr;
        StringBuilder sb;
        string SqlText = "";

        SqlDataAdapter da;//ใช้สำหรับโหลด Combo

        private void frmSetUser_Load(object sender, EventArgs e)//เชื่อมต่อฐานข้อมูล
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

                btnStatus(true);
                com = new SqlCommand();                
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด : " + ex.Message + " โปรดตรวจสอบ", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStatus(bool xStatus)//สถานะปุ่ม
        {
            LoadComboAll();//ดึงข้อมูลแสดงใน ComboBox
            ShowData();//ดึงข้อมูลมาแสดงใน DataGridView
            if (xStatus == true)
            {
                ClearAllText(this);
                txtUsID.Focus();
                lblLevel.Text = "";
                rdoEnable.Checked = true;
                btnAdd.Enabled = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            else if (xStatus == false)
            {
                btnAdd.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void ClearAllText(Control con)//เคลียร์ TextBox
        {
            foreach (Control c in con.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                else
                    ClearAllText(c);
            }
        }

        private void LoadComboAll()//นำข้อมูลใส่ใน ComboBox
        {
            try
            {
                DataSet dsTitle = new DataSet();
                SqlText = "";
                SqlText = "SELECT TiID,TiDetail FROM tblSetTitle ORDER BY TiID";//คำนำหน้าชื่อ
                dsTitle.Clear();
                da = new SqlDataAdapter(SqlText, Conn);
                da.Fill(dsTitle, "tblSetTitle");
                cboTiID.DataSource = dsTitle.Tables["tblSetTitle"];
                cboTiID.DisplayMember = "TiDetail";
                cboTiID.ValueMember = "TiID";
                cboTiID.SelectedItem = null;
                cboTiID.Text = "- คำนำหน้าชื่อ";

                DataSet dsPosition = new DataSet();
                SqlText = "";
                SqlText = "SELECT PsID,PsDetail FROM tblSetPosition ORDER BY PsID";//ตำแหน่ง
                dsPosition.Clear();
                da = new SqlDataAdapter(SqlText, Conn);
                da.Fill(dsPosition, "tblSetPosition");
                cboPsID.DataSource = dsPosition.Tables["tblSetPosition"];
                cboPsID.DisplayMember = "PsDetail";
                cboPsID.ValueMember = "PsID";
                cboPsID.SelectedItem = null;
                cboPsID.Text = "- ตำแหน่ง";
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด เนื่องจาก " + ex.Message, DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }        

        private void btnAdd_Click(object sender, EventArgs e)//เพิ่มข้อมูล
        {
            if (string.IsNullOrEmpty(txtUsID.Text))//string.IsNullOrEmpty คือไม่ใช่ค่าว่างและไม่เป็นค่า Null
            {
                MessageBox.Show("กรุณาป้อน ชื่อล๊อกอิน !!!", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsID.Focus();
                txtUsID.SelectAll();
                return;
            }

            if (txtUsID.Text.Length != 5)
            {
                MessageBox.Show("กรุณาป้อนชื่อล๊อกอินต้องไม่น้อยกว่า 5 อักษร !!!" , DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsID.Focus();
                txtUsID.SelectAll();
                return;
            }

            if (txtUsPassword.Text.Length != 6 && txtRetryUsPassword.Text.Length != 6)
            {
                MessageBox.Show("กรุณาป้อนรหัสผ่านต้องไม่น้อยกว่า 6 อักษร !!!", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsPassword.Focus();
                txtUsPassword.SelectAll();
                return;
            }

            if (txtUsPassword.Text.Trim() != txtRetryUsPassword.Text.Trim())
            {
                MessageBox.Show("รหัสผ่านที่กรอกไม่เหมือนกัน!!!", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsPassword.Focus();
                txtUsPassword.SelectAll();
                return;
            }

            if (cboPsID.SelectedItem == null)
            {
                MessageBox.Show("กรุณาเลือกตำแหน่ง !!!", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboPsID.Focus();
                cboPsID.SelectAll();
                return;
            }

            if (cboTiID.SelectedItem == null)
            {
                MessageBox.Show("กรุณาเลือกคำนำหน้า !!!", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTiID.Focus();
                cboTiID.SelectAll();
                return;
            }

            if (string.IsNullOrEmpty(txtUsFirstName.Text.Trim()))
            {
                MessageBox.Show("กรุณาป้อน ชื่อ ก่อน !!!", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsFirstName.Focus();
                txtUsFirstName.SelectAll();
                return;
            }

            if (string.IsNullOrEmpty(txtUsLastName.Text.Trim()))
            {
                MessageBox.Show("กรุณาป้อน นามสกุล ก่อน !!!", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsLastName.Focus();
                txtUsLastName.SelectAll();
                return;
            }

            if (MessageBox.Show("คุณต้องการเพิ่ม ข้อมูลผู้ใช้งาน ใช่หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                tr = Conn.BeginTransaction();
                try
                {
                    sb = new StringBuilder();
                    sb.Append("INSERT INTO tblSetUser(UsID ,TiID ,UsFirstName ,UsLastName ,PsID ,UsPassword ,UsCreateDate ,UsStatus)");
                    sb.Append(" VALUES(@UsID ,@TiID ,@UsFirstName ,@UsLastName ,@PsID ,@UsPassword ,@UsCreateDate ,@UsStatus)");
                    SqlText = "";
                    SqlText = sb.ToString();
                    com.CommandText = SqlText;
                    com.CommandType = CommandType.Text;
                    com.Connection = Conn;
                    com.Transaction = tr;
                    com.Parameters.Clear();
                    com.Parameters.Add("@UsID", SqlDbType.NVarChar).Value = txtUsID.Text.Trim().ToUpper();
                    com.Parameters.Add("@TiID", SqlDbType.NVarChar).Value = cboTiID.SelectedValue;
                    com.Parameters.Add("@UsFirstName", SqlDbType.NVarChar).Value = txtUsFirstName.Text.Trim();
                    com.Parameters.Add("@UsLastName", SqlDbType.NVarChar).Value = txtUsLastName.Text.Trim();
                    com.Parameters.Add("@PsID", SqlDbType.NVarChar).Value = cboPsID.SelectedValue;
                    com.Parameters.Add("@UsPassword", SqlDbType.NVarChar).Value = CryptorEngine.Encrypt(txtUsPassword.Text.Trim(),true);//ใช้ Class CryptorEngine เพื่อเข้ารหัส รหัสผ่าน
                    com.Parameters.Add("@UsCreateDate", SqlDbType.DateTime).Value = DateTime.Now;
                    if (rdoEnable.Checked == true)
                    {
                        com.Parameters.Add("@UsStatus", SqlDbType.Bit).Value = true;
                    }
                    if (rdoDisable.Checked == true)
                    {
                        com.Parameters.Add("@UsStatus", SqlDbType.Bit).Value = false;
                    }

                    com.ExecuteNonQuery();
                    tr.Commit();

                    MessageBox.Show("เพิ่มข้อมูล ผู้ใช้งาน เรียบร้อยแล้ว !!!",DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาด เนื่องจาก " + ex.Message,DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tr.Rollback();
                }
            }
            btnStatus(true);
        }

        private void btnEdit_Click(object sender, EventArgs e)//แก้ไขข้อมูล
        {
            if (string.IsNullOrEmpty(txtUsID.Text))//string.IsNullOrEmpty คือไม่ใช่ค่าว่างและไม่เป็นค่า Null
            {
                MessageBox.Show("กรุณาป้อน ชื่อล๊อกอิน !!!", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsID.Focus();
                txtUsID.SelectAll();
                return;
            }

            if (txtUsID.Text.Length != 5)
            {
                MessageBox.Show("กรุณาป้อนชื่อล๊อกอินต้องไม่น้อยกว่า 5 อักษร !!!", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsID.Focus();
                txtUsID.SelectAll();
                return;
            }

            if (txtUsPassword.Text.Length != 6 && txtRetryUsPassword.Text.Length != 6)
            {
                MessageBox.Show("กรุณาป้อนรหัสผ่านต้องไม่น้อยกว่า 6 อักษร !!!", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsPassword.Focus();
                txtUsPassword.SelectAll();
                return;
            }

            if (txtUsPassword.Text.Trim() != txtRetryUsPassword.Text.Trim())
            {
                MessageBox.Show("รหัสผ่านที่กรอกไม่เหมือนกัน!!!", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsPassword.Focus();
                txtUsPassword.SelectAll();
                return;
            }

            if (cboPsID.SelectedItem == null)
            {
                MessageBox.Show("กรุณาเลือกตำแหน่ง !!!", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboPsID.Focus();
                cboPsID.SelectAll();
                return;
            }

            if (cboTiID.SelectedItem == null)
            {
                MessageBox.Show("กรุณาเลือกคำนำหน้า !!!", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTiID.Focus();
                cboTiID.SelectAll();
                return;
            }

            if (string.IsNullOrEmpty(txtUsFirstName.Text.Trim()))
            {
                MessageBox.Show("กรุณาป้อน ชื่อ ก่อน !!!", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsFirstName.Focus();
                txtUsFirstName.SelectAll();
                return;
            }

            if (string.IsNullOrEmpty(txtUsLastName.Text.Trim()))
            {
                MessageBox.Show("กรุณาป้อน นามสกุล ก่อน !!!", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsLastName.Focus();
                txtUsLastName.SelectAll();
                return;
            }

            if (MessageBox.Show("คุณต้องการแก้ไข ข้อมูลผู้ใช้งาน ใช่หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                tr = Conn.BeginTransaction();
                try
                {
                    sb = new StringBuilder();
                    sb.Append("UPDATE tblSetUser SET TiID=@TiID ,UsFirstName=@UsFirstName");
                    sb.Append(" ,UsLastName=@UsLastName ,PsID=@PsID ,UsPassword=@UsPassword, UsStatus=@UsStatus");
                    sb.Append(" WHERE UsID=@UsID");
                    SqlText = "";
                    SqlText = sb.ToString();
                    com.CommandText = SqlText;
                    com.CommandType = CommandType.Text;
                    com.Connection = Conn;
                    com.Transaction = tr;
                    com.Parameters.Clear();
                    com.Parameters.Add("@UsID", SqlDbType.NVarChar).Value = txtUsID.Text.Trim().ToUpper();
                    com.Parameters.Add("@TiID", SqlDbType.NVarChar).Value = cboTiID.SelectedValue;
                    com.Parameters.Add("@UsFirstName", SqlDbType.NVarChar).Value = txtUsFirstName.Text.Trim();
                    com.Parameters.Add("@UsLastName", SqlDbType.NVarChar).Value = txtUsLastName.Text.Trim();
                    com.Parameters.Add("@PsID", SqlDbType.NVarChar).Value = cboPsID.SelectedValue;
                    com.Parameters.Add("@UsPassword", SqlDbType.NVarChar).Value = CryptorEngine.Encrypt(txtUsPassword.Text.Trim(), true);//ใช้ Class CryptorEngine เพื่อเข้ารหัส รหัสผ่าน
                    com.Parameters.Add("@UsCreateDate", SqlDbType.DateTime).Value = DateTime.Now;
                    if (rdoEnable.Checked == true)
                    {
                        com.Parameters.Add("@UsStatus", SqlDbType.Bit).Value = true;
                    }
                    if (rdoDisable.Checked == true)
                    {
                        com.Parameters.Add("@UsStatus", SqlDbType.Bit).Value = false;
                    }

                    com.ExecuteNonQuery();
                    tr.Commit();

                    MessageBox.Show("แก้ไขข้อมูล ผู้ใช้งาน เรียบร้อยแล้ว !!!", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาด เนื่องจาก " + ex.Message, DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tr.Rollback();
                }
            }
            btnStatus(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)//ลบข้อมูล
        {
            if (string.IsNullOrEmpty(txtUsID.Text))//string.IsNullOrEmpty คือไม่ใช่ค่าว่างและไม่เป็นค่า Null
            {
                MessageBox.Show("กรุณาป้อน ชื่อล๊อกอิน !!!", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsID.Focus();
                txtUsID.SelectAll();
                return;
            }

            if (MessageBox.Show("คุณต้องการลบ ข้อมูลผู้ใช้งาน ใช่หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                tr = Conn.BeginTransaction();
                try
                {
                    sb = new StringBuilder();
                    sb.Append("DELETE FROM tblSetUser WHERE UsID=@UsID");
                    SqlText = "";
                    SqlText = sb.ToString();
                    com.CommandText = SqlText;
                    com.CommandType = CommandType.Text;
                    com.Connection = Conn;
                    com.Transaction = tr;
                    com.Parameters.Clear();
                    com.Parameters.Add("@UsID", SqlDbType.NVarChar).Value = txtUsID.Text.Trim().ToUpper();
                    com.ExecuteNonQuery();
                    tr.Commit();

                    MessageBox.Show("ลบข้อมูล ผู้ใช้งาน เรียบร้อยแล้ว !!!", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาด เนื่องจาก " + ex.Message,DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tr.Rollback();
                }
            }
            btnStatus(true);
        }

        private void ShowData()//แสดงข้อมูลใน DataGridView
        {
            string sqltblBuilding;
            sqltblBuilding = "SELECT * FROM vwSetUser ORDER BY UsID";

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
                dgvShow.Columns[0].HeaderText = "ชื่อล๊อกอิน";
                dgvShow.Columns[1].HeaderText = "คำนำหน้า";
                dgvShow.Columns[2].HeaderText = "ชื่อ";
                dgvShow.Columns[3].HeaderText = "นามสกุล";
                dgvShow.Columns[4].HeaderText = "ตำแหน่ง";
                dgvShow.Columns[5].HeaderText = "สิทธิ์";
                dgvShow.Columns[6].HeaderText = "วันที่สร้าง";
                dgvShow.Columns[7].HeaderText = "สถานะ";
                dgvShow.Columns[8].Visible = false;//ซ่อนรหัสผ่าน

                dgvShow.Columns[0].Width = 120;
                dgvShow.Columns[1].Width = 75;
                dgvShow.Columns[2].Width = 160;
                dgvShow.Columns[3].Width = 160;
                dgvShow.Columns[4].Width = 100;
                dgvShow.Columns[5].Width = 60;
                dgvShow.Columns[6].Width = 80;
                dgvShow.Columns[7].Width = 40;

                dgvShow.Columns[6].DefaultCellStyle.Alignment =DataGridViewContentAlignment.MiddleCenter;
                dgvShow.Columns[6].DefaultCellStyle.Format = "dd MMM yyyy";
            }

            dgvShow.ClearSelection();
            dgvShow.CurrentCell = null;
        }

        private void dgvShow_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)//เลือกข้อมูลแสดงบน TextBox
        {
            if (e.RowIndex == dgvShow.Rows.Count) { return; }
            if (e.RowIndex == -1) { return; }

            btnStatus(false);

            txtUsID.Text = dgvShow.Rows[e.RowIndex].Cells["UsID"].Value.ToString();
            txtUsPassword.Text = CryptorEngine.Decrypt(dgvShow.Rows[e.RowIndex].Cells["UsPassword"].Value.ToString(), true);
            txtRetryUsPassword.Text = txtUsPassword.Text;
            cboPsID.Text = dgvShow.Rows[e.RowIndex].Cells["PsDetail"].Value.ToString();
            cboPsID_DropDownClosed(sender,e);

            if (Convert.ToBoolean(dgvShow.Rows[e.RowIndex].Cells["UsStatus"].Value.ToString()) == true)
            {
                rdoEnable.Checked = true;
            }

            if (Convert.ToBoolean(dgvShow.Rows[e.RowIndex].Cells["UsStatus"].Value.ToString()) == false)
            {
                rdoDisable.Checked = true;
            }

            cboTiID.Text = dgvShow.Rows[e.RowIndex].Cells["TiDetail"].Value.ToString();
            txtUsFirstName.Text = dgvShow.Rows[e.RowIndex].Cells["UsFirstName"].Value.ToString();
            txtUsLastName.Text = dgvShow.Rows[e.RowIndex].Cells["UsLastName"].Value.ToString();

        }

        private void btnClear_Click(object sender, EventArgs e)//ล้างสถานะปุ่ม
        {
            btnStatus(true);
        }

        private void btnClose_Click(object sender, EventArgs e)//ปิดฟอร์ม
        {
            if (Conn != null) { Conn.Close(); }
            this.Close();
        }

        private void cboPsID_DropDownClosed(object sender, EventArgs e)//หาคำอธิบาย ระดับสิทธิ์
        {
            if (cboPsID.SelectedIndex == -1) { return; }//ถ้า Combobox ไม่ถูกเลือก

            SqlDataReader reader = null;
            try
            {
                SqlText = "SELECT * FROM tblSetPosition WHERE PsID='" + cboPsID.SelectedValue.ToString() + "'";
                SqlCommand cmd = new SqlCommand(SqlText, Conn);
                reader = cmd.ExecuteReader();

                lblLevel.Text = "";
                while (reader.Read()) { lblLevel.Text = reader["PsLevel"].ToString(); }
                reader.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด เนื่องจาก " + ex.Message, DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}
