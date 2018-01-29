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
    public partial class frmOrder : Form
    {
        public frmOrder()
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
        Timer clock;
        string sqlTmp = "";
        SqlDataReader drTmp;
        string xUnDetail = "";//หน่วยนับ
        string xPtDetail = "";//ประเภทสินค้า
        double xTotal = 0;//ราคารวม

        private void AutoGENID()//หมายเลขใบสั่งซื้ออัตโนมัติ
        {
            int tmpID = 0; //ตัวแปรเก็บรหัส
            string tmpQuoID = ""; //ตัวแปรเก็บรหัส
            string tmpDate; //ตัวแปรเก็บวันขึ้นปีใหม่
            string tmpBrDate;//ตัวแปรเก็บวันที่ใน DB
            sqlTmp = "";

            sqlTmp = "SELECT TOP 1 OrdID FROM tblOrder ORDER BY OrdID DESC";//สร้างชุดคำสั่ง SQL เพื่อเลือกรหัสตำแหน่งล่าสุด
            try
            {
                com = new SqlCommand();//เอาไว้ค้นใน DataSet
                com.CommandType = CommandType.Text;
                com.CommandText = sqlTmp;
                com.Connection = Conn;

                drTmp = com.ExecuteReader();//ประเภทเรียกดูหรืออ่านข้อมูล //ทำหน้าที่รันชุดคำสั่ง SQL ผลลัพธ์เก็บไว้ใน DataReader
                drTmp.Read(); //เริ่มอ่านข้อมูล

                tmpQuoID = drTmp["OrdID"].ToString();//อ่านรหัส 
                tmpBrDate = tmpQuoID.Substring(3, 2);
                tmpDate = StringExt.StringFromRight("1/1/" + Convert.ToInt32(DateTime.Now.Year + 543), 2);

                if (Convert.ToInt16(tmpDate) == Convert.ToInt16(tmpBrDate))
                {
                    tmpID = Convert.ToInt32(StringExt.StringFromRight(tmpQuoID, 5)) + 1;
                    txtOrdID.Text = "RD-" + StringExt.StringFromRight("1/1/" + Convert.ToInt32(DateTime.Now.Year + 543), 2) + tmpID.ToString("00000");
                }
                else
                {
                    tmpID = 1;
                    txtOrdID.Text = "RD-" + StringExt.StringFromRight("1/1/" + Convert.ToInt32(DateTime.Now.Year + 543), 2) + tmpID.ToString("00000");
                }
                drTmp.Close(); //ปิดการทำงาน
            }
            catch
            {
                tmpID = 1;
                txtOrdID.Text = "RD-" + StringExt.StringFromRight("1/1/" + Convert.ToInt32(DateTime.Now.Year + 543), 2) + tmpID.ToString("00000");
                drTmp.Close();
            }
        }

        private void lsvFormat()//กำหนดรูปแบบ ListView
        {
            lsvShow.Clear();
            lsvShow.Columns.Add("รหัสสินค้า", 100, HorizontalAlignment.Center);
            lsvShow.Columns.Add("รายการสินค้า", 250, HorizontalAlignment.Left);
            lsvShow.Columns.Add("ประเภทสินค้า", 150, HorizontalAlignment.Left);
            lsvShow.Columns.Add("หน่วยนับ", 100, HorizontalAlignment.Left);
            lsvShow.Columns.Add("ราคา:หน่วย", 100, HorizontalAlignment.Right);
            lsvShow.Columns.Add("จำนวน", 100, HorizontalAlignment.Right);
            lsvShow.Columns.Add("รวม", 150, HorizontalAlignment.Right);
            lsvShow.View = View.Details;
            lsvShow.GridLines = true;
            lsvShow.FullRowSelect = true;
        }

        private void btnStatus(bool xStatus)
        {
            if (xStatus == true)
            {
                aCa.ClearTextAll(this);
                lsvFormat();
                AutoGENID();
                lblCpAddress.Text = "";
                lblCpContact.Text = "";
                lblTime.Text = "";
                lblUsID.Text = "";

                crvRep.Visible = false;
                txtTotal.Text = "0.00";
                txtDisc.Text ="0.00";
                txtNet.Text = "0.00";

                btnSave.Enabled = false;
                btnPrint.Enabled = false;

                lblUsID.Text = DBConnString.pUsFullName;

                
            }
            else
            {
                btnSave.Enabled = false;
                btnPrint.Enabled = true;
                btnNext.Enabled = true;
            }
        }

        private void frmOrder_Load(object sender, EventArgs e)
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

                clock = new Timer();
                clock.Interval = 1000;
                clock.Start();
                clock.Tick += new EventHandler(timer1_Tick);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด : " + ex.Message + "โปรดตรวจสอบ", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = "เวลา : " +DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnFindCp_Click(object sender, EventArgs e)
        {
            frmFindCompany FindCompany = new frmFindCompany();
            if (FindCompany.ShowDialog() == DialogResult.OK)
            {
                txtCpID.Text = DBConnString.pCpID;
                txtCpName.Text = DBConnString.pCpName;
                lblCpAddress.Text = DBConnString.pCpAddress;
                lblCpContact.Text = DBConnString.pCpContact;
                txtProID.Focus();
            }
        }

        public bool isNumeric(string val, System.Globalization.NumberStyles NumberStyle)//ตรวจสอบตัวเลข
        {
            Double result;
            return Double.TryParse(val, NumberStyle, System.Globalization.CultureInfo.CurrentCulture, out result);
        }

        private void txtProID_KeyDown(object sender, KeyEventArgs e)//ตรวจสอบการกดปุ่ม Keyboard
        {
            if (e.KeyCode == Keys.Escape) { txtProID.Text = ""; txtProID.Focus(); }

            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtCpID.Text.Trim()))
                {
                    MessageBox.Show("โปรดตรวจสอบ ผู้จัดจำหน่ายสินค้า ", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCpName.Focus();
                    return;
                }
                SearchProduct();//ค้นหาสินค้า
            }

            if (e.KeyCode == Keys.F5)
            {
                if (Convert.ToDecimal(txtTotal.Text) > 0)
                {
                    btnSave_Click(sender, e);//กดปุ่ม btnSave
                }
            }

            if (e.KeyCode == Keys.F6)
            {
                if (btnPrint.Enabled == true)
                {
                    btnPrint_Click(sender, e);
                }
            }

            if (e.KeyCode == Keys.F7) { btnNext_Click(sender, e); }

            if (e.KeyCode == Keys.F10) { this.Close(); }
        }

        private void SearchProduct()//ค้นหาสินค้า
        {
            SqlDataReader reader = null;
            try
            {
                sqlTmp = "SELECT * FROM vwProduct WHERE ProID='" + txtProID.Text.Trim() + "' ";

                SqlCommand cmd = new SqlCommand(sqlTmp, Conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    txtProName.Text = reader["ProName"].ToString();
                    xUnDetail = reader["UnDetail"].ToString();
                    xPtDetail = reader["PtDetail"].ToString();
                    txtProPrice.Text = Convert.ToDecimal(reader["ProPrice"].ToString()).ToString("#,##0.00");
                    txtProPrice.SelectAll();
                    txtProPrice.Focus();
                }
                reader.Close();
                cmd.Dispose();
            }
            catch
            {
                MessageBox.Show("ระบบไม่พบรหัสสินค้า : [ " + txtProID.Text.Trim() + " ] ที่ป้อนโปรดตรวจสอบ", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            reader.Close();
        }

        private void txtNum_KeyDown(object sender, KeyEventArgs e)//ตรวจสอบการกดปุ่ม Keyboard
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (isNumeric(txtNum.Text, System.Globalization.NumberStyles.Integer) == false)
                {
                    MessageBox.Show("โปรดป้อนจำนวนสินค้า !!!", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNum.SelectAll();
                    txtNum.Focus();
                    return;
                }

                if (Convert.ToInt16(txtNum.Text) <= 0)
                {
                    MessageBox.Show("กรุณาป้อนจำนวน", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNum.SelectAll();
                    txtNum.Focus();
                    return;
                }
                //คำนวณ
                xTotal = 0;
                xTotal = Convert.ToDouble(txtProPrice.Text) * Convert.ToDouble(txtNum.Text);

                txtSum.Text = xTotal.ToString("#,##0.00 ");

                btnAdd.Focus();
            }

        }

        private void SumPrice()//หาผลรวมใบสั่งซื้อสินค้า
        {
            double xNet = 0;
            for (int i = 0; i <= lsvShow.Items.Count - 1; i++)
            {
                xNet = xNet + Convert.ToDouble(lsvShow.Items[i].SubItems[6].Text);
            }

            txtTotal.Text = xNet.ToString("#,##0.00 ");//ราคารวม
            txtNet.Text = (Convert.ToDouble(txtTotal.Text.ToString()) - Convert.ToDouble(txtDisc.Text.ToString())).ToString("#,##0.00 ");//ราคาสุทธิ

            if (xNet > 0)
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)//เพิ่มข้อมูลสินค้าใน ListView
        {
            if (isNumeric(txtNum.Text, System.Globalization.NumberStyles.Integer) == false)
            {
                MessageBox.Show("โปรดป้อนจำนวนสินค้า !!!", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNum.SelectAll();
                txtNum.Focus();
                return;
            }

            if (Convert.ToInt16(txtNum.Text) <= 0)
            {
                MessageBox.Show("กรุณาป้อนจำนวน", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNum.SelectAll();
                txtNum.Focus();
                return;
            }

            ListViewItem lvi;
            string[] anydata;
            anydata = new string[] { txtProID.Text, txtProName.Text, xPtDetail, xUnDetail, Convert.ToDouble(txtProPrice.Text).ToString("#,##0.00"), Convert.ToDouble(txtNum.Text).ToString("#,##0"), xTotal.ToString("#,##0.00") };
            lvi = new ListViewItem(anydata);
            lsvShow.Items.Add(lvi);

            SumPrice();

            txtProID.Text = "";
            txtProName.Text = "";
            txtProPrice.Text = "";
            txtNum.Text = "";
            txtSum.Text = "";
            txtProID.Focus();
        }

        private void txtProPrice_KeyDown(object sender, KeyEventArgs e)//ตรวจสอบการกดปุ่ม Keyboard
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการบันทึกข้อมูลใบสั่งซื้อเลขที่ : " + txtOrdID.Text + " ใช่หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                InstblOrder();
            }
        }

        private void InstblOrder()//เพิ่มข้อมูลใบสั่งซื้อใน tblOrder
        {
            tr = Conn.BeginTransaction();
            try
            {
                sb = new StringBuilder();
                sb.Append("INSERT INTO tblOrder(OrdID,CpID,OrdDate,OrdTotal,OrdDisc,OrdNet,UsID,OrdStatus)");
                sb.Append(" VALUES(@OrdID,@CpID,@OrdDate,@OrdTotal,@OrdDisc,@OrdNet,@UsID,@OrdStatus)");
                string sqlAdd;
                sqlAdd = sb.ToString();

                com.CommandText = sqlAdd;
                com.CommandType = CommandType.Text;
                com.Connection = Conn;
                com.Transaction = tr;
                com.Parameters.Clear();
                com.Parameters.Add("@OrdID", SqlDbType.NVarChar).Value = txtOrdID.Text.Trim();
                com.Parameters.Add("@CpID", SqlDbType.NVarChar).Value = txtCpID.Text.Trim();
                com.Parameters.Add("@OrdDate", SqlDbType.DateTime).Value = dtpOrdDate.Value;
                com.Parameters.Add("@OrdTotal", SqlDbType.Money).Value = Convert.ToDouble(txtTotal.Text);
                com.Parameters.Add("@OrdDisc", SqlDbType.Money).Value = Convert.ToDouble(txtDisc.Text);
                com.Parameters.Add("@OrdNet", SqlDbType.Money).Value = Convert.ToDouble(txtNet.Text);
                com.Parameters.Add("@UsID", SqlDbType.NVarChar).Value = DBConnString.pUsID;
                com.Parameters.Add("@OrdStatus", SqlDbType.Bit).Value = false;
                com.ExecuteNonQuery();
                tr.Commit();

                InstblOrderTrn();//เพิ่มรายละเอียดใบสั่งซื้อใน tblOrderTrn 
                PrintOrder();//พิมพ์ใบสั่งซื้อสินค้า
                btnPrint.Enabled = true;//เปลี่ยนสถานะปุ่ม
                btnSave.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("บันทึกข้อมูลผิดพลาด !!! : " + ex, DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tr.Rollback();
            }
        }

        private void InstblOrderTrn()//เพิ่มรายละเอียดใบสั่งซื้อใน tblOrderTrn
        {
            for (int i = 0; i <= lsvShow.Items.Count - 1; i++)
            {
                tr = Conn.BeginTransaction();
                sb = new StringBuilder();
                sb.Append("INSERT INTO tblOrderTrn(OrdID,ProID,OrtPrice,OrtNum,OrtTotal,OrtStatus)");
                sb.Append(" VALUES(@OrdID,@ProID,@OrtPrice,@OrtNum,@OrtTotal,@OrtStatus)");

                string sqlAdd;
                sqlAdd = sb.ToString();
                //anydata = new string[] { txtProID.Text, txtProName.Text, xPtDetail, xUnDetail, Convert.ToDouble(txtProPrice.Text).ToString("#,##0.00"), Convert.ToDouble(txtNum.Text).ToString("#,##0"), xTotal.ToString("#,##0.00") };
                com.CommandText = sqlAdd;
                com.CommandType = CommandType.Text;
                com.Connection = Conn;
                com.Transaction = tr;
                com.Parameters.Clear();
                com.Parameters.Add("@OrdID", SqlDbType.NVarChar).Value = txtOrdID.Text.Trim();
                com.Parameters.Add("@ProID", SqlDbType.NVarChar).Value = lsvShow.Items[i].SubItems[0].Text;
                com.Parameters.Add("@OrtPrice", SqlDbType.Money).Value = Convert.ToDouble(lsvShow.Items[i].SubItems[4].Text);
                com.Parameters.Add("@OrtNum", SqlDbType.Int).Value = Convert.ToDouble(lsvShow.Items[i].SubItems[5].Text);
                com.Parameters.Add("@OrtTotal", SqlDbType.Money).Value = Convert.ToDouble(lsvShow.Items[i].SubItems[6].Text);
                com.Parameters.Add("@OrtStatus", SqlDbType.Bit).Value = false;
                com.ExecuteNonQuery();
                tr.Commit();
            }
        }

        private void PrintOrder()
        {
            DropTmpTable();//ลบข้อมูลตารางชั่วคราว

            try
            {
                tr = Conn.BeginTransaction();
                sb = new StringBuilder();
                sb.Append(" SELECT A.OrdID,A.OrdDate,E.CpID,E.CpName,E.CpAddress,E.CpTel,E.CpContact,E.CpContactTel,A.UsID,");
                sb.Append(" G.TiDetail,F.UsFirstName,F.UsLastName,B.ProID,C.ProName,D.UnDetail,B.OrtPrice,B.OrtNum,B.OrtTotal,");
                sb.Append(" A.OrdStatus,A.OrdTotal,A.OrdDisc,A.OrdNet");
                sb.Append(" INTO _repOrder" + DBConnString.pUsID);//ใส่ในตารางที่สร้างขึ้นใหม่
                sb.Append(" FROM tblOrder A INNER JOIN tblOrderTrn B ON A.OrdID=B.OrdID");
                sb.Append(" LEFT JOIN tblProduct C ON B.ProID=C.ProID");
                sb.Append(" LEFT JOIN tblSetUnit D ON C.UnID=D.UnID");
                sb.Append(" LEFT JOIN tblSetCompany E ON E.CpID=A.CpID");
                sb.Append(" LEFT JOIN tblSetUser F ON F.UsID=A.UsID");
                sb.Append(" LEFT JOIN tblSetTitle G ON G.TiID=F.TiID");
                sb.Append(" WHERE A.OrdID=@OrdID");

                SqlText = sb.ToString();
                com = new SqlCommand();
                com.CommandText = SqlText;
                com.CommandType = CommandType.Text;
                com.Connection = Conn;
                com.Transaction = tr;
                com.Parameters.Clear();
                com.Parameters.Add("@OrdID", SqlDbType.NVarChar).Value = txtOrdID.Text.Trim();
                com.ExecuteNonQuery();
                tr.Commit();

                SqlConnection cnn;
                string connectionString = null;
                string sql = null;

                connectionString = DBConnString.strConn;
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                sql = "SELECT * FROM " + "_repOrder" + DBConnString.pUsID;
                SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
                repOrder_DATA ds = new repOrder_DATA();
                dscmd.Fill(ds, "repOrder");
                cnn.Close();

                MoneyExt mne = new MoneyExt();
                string xThaiBath = "";
                xThaiBath = "(-" + mne.NumberToThaiWord(Convert.ToDouble(txtNet.Text)) + "-)";

                repOrder objRpt = new repOrder();
                objRpt.SetDataSource(ds.Tables[1]);
                objRpt.DataDefinition.FormulaFields["xSuName"].Text = "'" + PublicVariable.pSuName + "'";
                objRpt.DataDefinition.FormulaFields["xSuAddress"].Text = "'" + PublicVariable.pSuAddress + "'";
                objRpt.DataDefinition.FormulaFields["xThaiBath"].Text = "'" + xThaiBath + "'";

                crvRep.Visible = true;
                crvRep.Dock = DockStyle.Fill;

                crvRep.ReportSource = objRpt;
                objRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                crvRep.Refresh();

                DropTmpTable();//ลบข้อมูลตารางชั่วคราว
            }
            catch (Exception Err)
            {
                MessageBox.Show("เกิดข้อผิดพลาด : " + Err.Message, DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tr.Rollback();
                return;
            }
        }

        private void DropTmpTable()//ลบข้อมูลในตารางชั่วคราวก่อน Query เพื่อเตรียมพิมพ์ใบสั่งซื้อ
        {
            tr = Conn.BeginTransaction();
            try
            {
                sb = new StringBuilder();
                sb.Append("DROP TABLE _repOrder" + DBConnString.pUsID);

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

            tr = Conn.BeginTransaction();
            try
            {
                sb = new StringBuilder();
                sb.Append("DROP TABLE _repStartUp" + DBConnString.pUsID);

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

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }

        private void lsvShow_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการลบรายการสั่งซื้อสินค้าใช่หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {

                ListViewItem lvi;

                for (int i = 0; i <= lsvShow.SelectedItems.Count - 1; i++)
                {
                    lvi = lsvShow.SelectedItems[i];
                    lsvShow.Items.Remove(lvi);
                }
                SumPrice();
            }
        }

        private void txtDisc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtCpID.Text.Trim()))
                {
                    MessageBox.Show("โปรดตรวจสอบ ผู้จัดจำหน่ายสินค้า ", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCpName.Focus();
                    return;
                }

                if (isNumeric(txtDisc.Text, System.Globalization.NumberStyles.Number) == false)
                {
                    MessageBox.Show("โปรดป้อนส่วนลดให้ถูกต้อง !!!", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDisc.SelectAll();
                    txtDisc.Focus();
                    return;
                }

                xTotal = Convert.ToDouble(txtDisc.Text);
                txtDisc.Text = xTotal.ToString("#,##0.00 ");
                SumPrice();
                btnSave.Focus();
            }
        }

        private void txtDisc_Click(object sender, EventArgs e)
        {
            txtDisc.SelectAll();
        }
    }
}
