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
    public partial class frmSetCompany : Form
    {
        public frmSetCompany()
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

        private void frmSetCompany_Load(object sender, EventArgs e)
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

        public bool isNumeric(string val, System.Globalization.NumberStyles Numberstyle)
        {
            Double result;
            return double.TryParse(val, Numberstyle, System.Globalization.CultureInfo.CurrentCulture, out result);

        }
        
        private void btnStatus(bool xStatus)
        {
            if (xStatus == true)
            {
                aCa.ClearTextAll(this);
                txtCpID.Focus();
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
            if (string.IsNullOrEmpty(txtCpID.Text))
            {
                MessageBox.Show("กรุณาป้อนรหัสผู้จำหน่าย", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCpID.SelectAll();
                txtCpID.Focus();
                return;
            }
            else if (txtCpID.Text.Length != 6)
            {
                MessageBox.Show("กรุณาป้อนรหัสผู้จำหน่าย ให้ครบ6 อักษร", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCpID.SelectAll();
                txtCpID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtCpName.Text.Trim()))
            {
                MessageBox.Show("กรุณาป้อน ชื่อผู้จำหน่าย", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCpName.SelectAll();
                txtCpName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtCpContact.Text.Trim()))
            {
                MessageBox.Show("กรุณาป้อน ผู้ติดต่อ", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCpContact.SelectAll();
                txtCpContact.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtCpContactTel.Text.Trim()))
            {
                MessageBox.Show("กรุณาป้อน โทรศัพท์ผู้ติดต่อ", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCpContactTel.SelectAll();
                txtCpContactTel.Focus();
                return;
            }

            if (MessageBox.Show("คุณต้องการเพิ่มข้อมูล ผู้จำหน่าย ใช่หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                tr = Conn.BeginTransaction();
                try
                {
                    sb = new StringBuilder();
                    sb.Append("INSERT INTO tblSetCompany(CpID, CpDate, CpName, CpAddress, CpTel, CpEmail, CpWebsite, CpContact, CpContactTel)");
                    sb.Append(" VALUES(@CpID, @CpDate, @CpName, @CpAddress, @CpTel, @CpEmail, @CpWebsite, @CpContact, @CpContactTel)");
                    SqlText = sb.ToString();

                    com.CommandText = SqlText;
                    com.CommandType = CommandType.Text;
                    com.Connection = Conn;
                    com.Transaction = tr;
                    com.Parameters.Clear();
                    com.Parameters.Add("@CpID", SqlDbType.NVarChar).Value = txtCpID.Text.Trim().ToUpper();
                    com.Parameters.Add("@CpDate", SqlDbType.DateTime).Value = dtpCpDate.Value;
                    com.Parameters.Add("@CpName", SqlDbType.NVarChar).Value = txtCpName.Text.Trim();
                    com.Parameters.Add("@CpAddress", SqlDbType.NVarChar).Value = txtCpAddress.Text.Trim();
                    com.Parameters.Add("@CpTel", SqlDbType.NVarChar).Value = txtCpTel.Text.Trim();
                    com.Parameters.Add("@CpEmail", SqlDbType.NVarChar).Value = txtCpEmail.Text.Trim();
                    com.Parameters.Add("@CpWebsite", SqlDbType.NVarChar).Value = txtCpWebsite.Text.Trim();
                    com.Parameters.Add("@CpContact", SqlDbType.NVarChar).Value = txtCpContact.Text.Trim();
                    com.Parameters.Add("@CpContactTel", SqlDbType.NVarChar).Value = txtCpContactTel.Text.Trim();
                   
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCpID.Text))
            {
                MessageBox.Show("กรุณาป้อนรหัสผู้จำหน่าย", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCpID.SelectAll();
                txtCpID.Focus();
                return;
            }
            else if (txtCpID.Text.Length != 6)
            {
                MessageBox.Show("กรุณาป้อนรหัสผู้จำหน่าย ให้ครบ6 อักษร", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCpID.SelectAll();
                txtCpID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtCpName.Text.Trim()))
            {
                MessageBox.Show("กรุณาป้อน ชื่อผู้จำหน่าย", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCpName.SelectAll();
                txtCpName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtCpContact.Text.Trim()))
            {
                MessageBox.Show("กรุณาป้อน ผู้ติดต่อ", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCpContact.SelectAll();
                txtCpContact.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtCpContactTel.Text.Trim()))
            {
                MessageBox.Show("กรุณาป้อน ผู้ติดต่อ", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCpContactTel.SelectAll();
                txtCpContactTel.Focus();
                return;
            }


            if (MessageBox.Show("คุณต้องการแก้ไขข้อมูล ผู้จำหน่าย ใช่หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                tr = Conn.BeginTransaction();
                try
                {
                    sb = new StringBuilder();
                    sb.Append("UPDATE tblSetCompany SET CpDate=@CpDate, CpName=@CpName, CpAddress=@CpAddress, Cptel=@Cptel, CpEmail=@CpEmail, CpWebsite=@CpWebsite, CpContact=@CpContact, CpContactTel=@CpContactTel");
                    sb.Append(" WHERE @CpID=CpID");
                    SqlText = sb.ToString();

                    com.CommandText = SqlText;
                    com.CommandType = CommandType.Text;
                    com.Connection = Conn;
                    com.Transaction = tr;
                    com.Parameters.Clear();
                    com.Parameters.Add("@CpID", SqlDbType.NVarChar).Value = txtCpID.Text.Trim().ToUpper();
                    com.Parameters.Add("@CpDate", SqlDbType.DateTime).Value = dtpCpDate.Value;
                    com.Parameters.Add("@CpName", SqlDbType.NVarChar).Value = txtCpName.Text.Trim();
                    com.Parameters.Add("@CpAddress", SqlDbType.NVarChar).Value = txtCpAddress.Text.Trim();
                    com.Parameters.Add("@CpTel", SqlDbType.NVarChar).Value = txtCpTel.Text.Trim();
                    com.Parameters.Add("@CpEmail", SqlDbType.NVarChar).Value = txtCpEmail.Text.Trim();
                    com.Parameters.Add("@CpWebsite", SqlDbType.NVarChar).Value = txtCpWebsite.Text.Trim();
                    com.Parameters.Add("@CpContact", SqlDbType.NVarChar).Value = txtCpContact.Text.Trim();
                    com.Parameters.Add("@CpContactTel", SqlDbType.NVarChar).Value = txtCpContactTel.Text.Trim();
                   
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
            if (string.IsNullOrEmpty(txtCpID.Text))
            {
                MessageBox.Show("กรุณาป้อนรหัสผู้จำหน่าย", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCpID.SelectAll();
                txtCpID.Focus();
                return;
            }

            if (MessageBox.Show("คุณต้องการลบข้อมูล ผู้จำหน่าย ใช่หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                tr = Conn.BeginTransaction();
                try
                {
                    sb = new StringBuilder();
                    sb.Append("DELETE FROM tblSetCompany");
                    sb.Append(" WHERE CpID=@CpID");
                    SqlText = sb.ToString();

                    com.CommandText = SqlText;
                    com.CommandType = CommandType.Text;
                    com.Connection = Conn;
                    com.Transaction = tr;
                    com.Parameters.Clear();
                    com.Parameters.Add("@CpID", SqlDbType.NVarChar).Value = txtCpID.Text.Trim().ToUpper();
                    com.ExecuteNonQuery();
                    tr.Commit();
                    MessageBox.Show("ลบข้อมูล ผู้จำหน่าย เรียบร้อยแล้ว", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void ShowData()
        {
            SqlText = "SELECT CpID, CpName, CpAddress, CpTel, CpEmail, CpWebsite, CpContact, CpContactTel, CpDate FROM tblSetCompany ORDER BY CpID";

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
                dgvShow.Columns[1].HeaderText = "ผู้จำหน่าย";
                dgvShow.Columns[2].HeaderText = "ที่อยู่";
                dgvShow.Columns[3].HeaderText = "โทรศัพท์";
                dgvShow.Columns[4].HeaderText = "เว็บไซต์";
                dgvShow.Columns[5].HeaderText = "อีเมล";
                dgvShow.Columns[6].HeaderText = "ผู้ติดต่อ";
                dgvShow.Columns[7].HeaderText = "โทรศัพท์";
                dgvShow.Columns[8].HeaderText = "วันที่";

                dgvShow.Columns[0].Width = 45;
                dgvShow.Columns[1].Width = 150;
                dgvShow.Columns[2].Width = 110;
                dgvShow.Columns[3].Width = 70;
                dgvShow.Columns[4].Width = 80;
                dgvShow.Columns[5].Width = 90;
                dgvShow.Columns[6].Width = 100;
                dgvShow.Columns[7].Width = 70;
                dgvShow.Columns[8].Width = 80;

                dgvShow.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvShow.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvShow.Columns[8].DefaultCellStyle.Format = "dd MMM yyyy";
            }
            dgvShow.ClearSelection();
            dgvShow.CurrentCell = null;
        }

        private void dgvShow_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.RowIndex == dgvShow.Rows.Count) || (e.RowIndex == -1))
            {
                return;
            }

            btnStatus(false);

            dtpCpDate.Value = Convert.ToDateTime(dgvShow.Rows[e.RowIndex].Cells["CpDate"].Value.ToString());
            txtCpID.Text = dgvShow.Rows[e.RowIndex].Cells["CpID"].Value.ToString();
            txtCpName.Text = dgvShow.Rows[e.RowIndex].Cells["CpName"].Value.ToString();
            txtCpAddress.Text = dgvShow.Rows[e.RowIndex].Cells["CpAddress"].Value.ToString();
            txtCpTel.Text = dgvShow.Rows[e.RowIndex].Cells["CpTel"].Value.ToString();
            txtCpWebsite.Text = dgvShow.Rows[e.RowIndex].Cells["CpWebsite"].Value.ToString();
            txtCpEmail.Text = dgvShow.Rows[e.RowIndex].Cells["CpEmail"].Value.ToString();
            txtCpContact.Text = dgvShow.Rows[e.RowIndex].Cells["CpContact"].Value.ToString();
            txtCpContactTel.Text = dgvShow.Rows[e.RowIndex].Cells["CpContactTel"].Value.ToString();       
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnStatus(true);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { return; }

            if (e.KeyCode == Keys.Enter)
            {
                if (txtSearch.Text.Trim() == "") { return; }

                string sqltblBuilding;
                sqltblBuilding = "SELECT SELECT CpID, CpName, CpAddress, CpTel, CpEmail, CpWebsite, CpContact, CpContactTel, CpDate FROM tblSetCompany WHERE CpName Like '" + txtSearch.Text.Trim() + "%' ORDER BY CpID";
                                        
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

            }           
        }
    }
}
