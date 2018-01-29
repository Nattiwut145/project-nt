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
using SmartBAPOS_Sec2.Class;

namespace SmartBAPOS_Sec2
{
    public partial class frmPOS : Form
    {
        public frmPOS()
        {
            InitializeComponent();
        }

        SqlConnection Conn;
        SqlCommand com;
        SqlTransaction tr;
        StringBuilder sb;
        string sqlTmp = "";
        SqlDataReader drTmp;
        Timer clock;
        SqlDataAdapter da;//ใช้สำหรับโหลด Combo
        string xUnDetail = "";//หน่วยนับ
        string xPtDetail = "";//ประเภทสินค้า
        double xTotal = 0;//ราคารวม
        string SqlText = "";

        private void frmPOS_Load(object sender, EventArgs e)
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

                clock = new Timer();//นาฬิกาแสดงเวลาบน Form
                clock.Interval = 1000;
                clock.Start();
                clock.Tick += new EventHandler(timer1_Tick);
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด : " + ex.Message + " โปรดตรวจสอบ", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AutoGENID()//หมายเลขใบสั่งซื้ออัตโนมัติ
        {
            int tmpID = 0; //ตัวแปรเก็บรหัส
            string tmpQuoID = ""; //ตัวแปรเก็บรหัส
            string tmpDate; //ตัวแปรเก็บวันขึ้นปีใหม่
            string tmpBrDate;//ตัวแปรเก็บวันที่ใน DB
            sqlTmp = "";

            sqlTmp = "SELECT TOP 1 PosID FROM tblPos ORDER BY PosID DESC";//สร้างชุดคำสั่ง SQL เพื่อเลือกรหัสตำแหน่งล่าสุด
            try
            {
                com = new SqlCommand();//เอาไว้ค้นใน DataSet
                com.CommandType = CommandType.Text;
                com.CommandText = sqlTmp;
                com.Connection = Conn;

                drTmp = com.ExecuteReader();//ประเภทเรียกดูหรืออ่านข้อมูล     //ทำหน้าที่รันชุดคำสั่ง SQL ผลลัพธ์เก็บไว้ใน DataReader
                drTmp.Read(); //เริ่มอ่านข้อมูล

                tmpQuoID = drTmp["PosID"].ToString();//อ่านรหัส 
                tmpBrDate = tmpQuoID.Substring(3, 2);
                tmpDate = StringExt.StringFromRight("1/1/" + Convert.ToInt32(DateTime.Now.Year + 543), 2);

                if (Convert.ToInt16(tmpDate) == Convert.ToInt16(tmpBrDate))
                {
                    tmpID = Convert.ToInt32(StringExt.StringFromRight(tmpQuoID, 5)) + 1;
                    lblPosID.Text = "PS-" + StringExt.StringFromRight("1/1/" + Convert.ToInt32(DateTime.Now.Year + 543), 2) + tmpID.ToString("00000");
                }
                else
                {
                    tmpID = 1;
                    lblPosID.Text = "PS-" + StringExt.StringFromRight("1/1/" + Convert.ToInt32(DateTime.Now.Year + 543), 2) + tmpID.ToString("00000");
                }
                drTmp.Close(); //ปิดการทำงาน
            }
            catch
            {
                tmpID = 1;
                lblPosID.Text = "PS-" + StringExt.StringFromRight("1/1/" + Convert.ToInt32(DateTime.Now.Year + 543), 2) + tmpID.ToString("00000");
                drTmp.Close();
            }
        }

        public bool isNumeric(string val, System.Globalization.NumberStyles NumberStyle)//ตรวจสอบตัวเลข
        {
            Double result;
            return Double.TryParse(val, NumberStyle, System.Globalization.CultureInfo.CurrentCulture, out result);
        }

        private void btnStatus(bool xStatus)//สถานะปุ่ม
        {
            if (xStatus == true)
            {
                ClearAllText(this);
                txtProID.Focus();
                btnReceive.Enabled = false;
                btnPrint.Enabled = false;
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

            lblDisplay.Text = "0.00 ";
            gbReceive.Visible = false;

            lblTotal.Text = "0.00 ";
            txtDisc.Text = "0.00 ";
            lblNet.Text = "0.00 ";

            crvRep.Visible = false;

            lblUsID.Text = DBConnString.pUsID;
            lblUsFullName.Text = DBConnString.pUsFullName;
            AutoGENID();//หมายเลขใบสั่งซื้ออัตโนมัติ
            lsvFormat();//กำหนดรูปแบบ ListView

            txtProID.Focus();
        }

        private void lsvFormat()//กำหนดรูปแบบ ListView
        {
            lsvShow.Clear();
            lsvShow.Columns.Add("รหัสสินค้า", 120, HorizontalAlignment.Center);
            lsvShow.Columns.Add("รายการสินค้า", 280, HorizontalAlignment.Left);
            lsvShow.Columns.Add("ประเภทสินค้า", 180, HorizontalAlignment.Left);
            lsvShow.Columns.Add("หน่วยนับ", 120, HorizontalAlignment.Left);
            lsvShow.Columns.Add("ราคา:หน่วย", 100, HorizontalAlignment.Right);
            lsvShow.Columns.Add("จำนวน", 100, HorizontalAlignment.Right);
            lsvShow.Columns.Add("รวม", 150, HorizontalAlignment.Right);
            lsvShow.View = View.Details;
            lsvShow.GridLines = true;
            lsvShow.FullRowSelect = true;
        }

        private void timer1_Tick(object sender, EventArgs e)//แสดงเวลาปัจจุบัน
        {
            if (sender == clock)
            {
                lblTime.Text = " เวลา : " + DateTime.Now.ToString("HH:mm:ss");
            }
        }

        private void btnFindCp_Click(object sender, EventArgs e)
        {
            frmFindProduct FindProduct = new frmFindProduct();
            if (FindProduct.ShowDialog() == DialogResult.OK)
            {
                txtProID.Text = DBConnString.pProID;
                txtProID.Focus();
                SearchProduct();
            }
        }

        private void SearchProduct()//ค้นหาข้อมูลสินค้า
        {
            sqlTmp = "SELECT A.ProID,A.ProName,B.PtDetail,A.ProPrice,C.UnDetail";
            sqlTmp += " FROM tblProduct A";
            sqlTmp += " INNER JOIN tblSetProductType B ON A.PtID=B.PtID";
            sqlTmp += " LEFT JOIN tblSetUnit C ON C.UnID=A.UnID";
            sqlTmp += " WHERE A.ProID = '" + txtProID.Text.Trim() + "' ORDER BY A.ProID";

            try
            {
                com = new SqlCommand();//เอาไว้ค้นใน DataSet
                com.CommandType = CommandType.Text;
                com.CommandText = sqlTmp;
                com.Connection = Conn;

                drTmp = com.ExecuteReader();//ประเภทเรียกดูหรืออ่านข้อมูล     //ทำหน้าที่รันชุดคำสั่ง SQL ผลลัพธ์เก็บไว้ใน DataReader
                drTmp.Read(); //เริ่มอ่านข้อมูล

                txtProName.Text = drTmp["ProName"].ToString();//อ่านรหัส 
                txtProPrice.Text = Convert.ToDecimal(drTmp["ProPrice"]).ToString("#,##0.00 ");
                xPtDetail = drTmp["PtDetail"].ToString();
                xUnDetail = drTmp["UnDetail"].ToString();

                if (isNumeric(txtNum.Text, System.Globalization.NumberStyles.Number) == true)
                {
                    txtNum.SelectAll();
                    txtNum.Focus();
                }
                else
                {
                    txtNum.Text = "1";
                    txtNum.SelectAll();
                    txtNum.Focus();
                }

                drTmp.Close(); //ปิดการทำงาน
            }
            catch
            {
                MessageBox.Show("ไม่พบรหัสสินค้า : " + txtProID.Text.Trim() + " โปรดตรวจสอบ", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProName.Text = "";
                txtProPrice.Text = "";
                txtNum.Text = "";
                txtSum.Text = "";
                txtProID.SelectAll();
                txtProID.Focus();
                drTmp.Close();
            }
        }

        private void txtProID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { txtProID.Text = ""; txtProID.Focus(); }

            if (e.KeyCode == Keys.Enter)
            {
                if (StringExt.StringFromLeft(txtProID.Text, 1) == "*")
                {
                    txtNum.Text = txtProID.Text.Replace("*", "");
                    txtProID.Text = "";
                    return;
                }

                SearchProduct();//ค้นหาสินค้า
            }

            if (e.KeyCode == Keys.F5)
            {
                if (Convert.ToDecimal(lblNet.Text) > 0)
                {
                    btnReceive_Click(sender, e);
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            frmPOS_Load(sender, e);
        }

        private void txtNum_KeyDown(object sender, KeyEventArgs e)
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

            lblTotal.Text = xNet.ToString("#,##0.00 ");//ราคารวม
            lblNet.Text = (Convert.ToDouble(lblTotal.Text.ToString()) - Convert.ToDouble(txtDisc.Text.ToString())).ToString("#,##0.00 ");//ราคาสุทธิ

            lblDisplay.Text = lblNet.Text;

            if (xNet > 0)
            {
                btnReceive.Enabled = true;
            }
            else
            {
                btnReceive.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)//เพิ่มสินค้าที่ซื้อใน ListView
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

        private void lsvShow_DoubleClick(object sender, EventArgs e)//ลบรายการสินค้าใน ListView ที่เลือก
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
                txtProName.Text = "";
                txtProPrice.Text = "";
                txtNum.Text = "";
                txtSum.Text = "";
                txtProID.SelectAll();
                txtProID.Focus();
            }
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(lblNet.Text) > 0)
            {
                gbReceive.Visible = true;
                txtReceive.Text = "";
                txtReceive.Focus();
            }
        }

        private void txtReceive_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7)
            {
                btnNext_Click(sender, e);
            }

            if (e.KeyCode == Keys.F6)
            {
                btnPrint_Click(sender, e);
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (Convert.ToDouble(txtReceive.Text) < Convert.ToDouble(lblNet.Text))
                {
                    MessageBox.Show("จำนวนเงินที่ป้อน น้อยกว่ายอดจ่ายจริง", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtReceive.SelectAll();
                    txtReceive.Focus();
                }
                else
                {
                    lblDisplay.Text = (Convert.ToDouble(txtReceive.Text) - Convert.ToDouble(lblNet.Text)).ToString("-#,##0.00");

                    if (MessageBox.Show("คุณต้องการบันทึกข้อมูลการขายสินค้าเลขที่ : " + lblPosID.Text + " ใช่หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        InstblPOS();
                    }

                }

            }
        }

        private void InstblPOS()//เพิ่มข้อมูลใบเสร็จใน tblPOS
        {
            tr = Conn.BeginTransaction();
            try
            {
                sb = new StringBuilder();
                sb.Append("INSERT INTO tblPos(PosID,PosDate,PosTotal,PosDisc,PosNet,UsID,PosStatus,PosRemark)");
                sb.Append(" VALUES(@PosID,@PosDate,@PosTotal,@PosDisc,@PosNet,@UsID,@PosStatus,@PosRemark)");
                string sqlAdd;
                sqlAdd = sb.ToString();

                com.CommandText = sqlAdd;
                com.CommandType = CommandType.Text;
                com.Connection = Conn;
                com.Transaction = tr;
                com.Parameters.Clear();
                com.Parameters.Add("@PosID", SqlDbType.NVarChar).Value = lblPosID.Text;
                com.Parameters.Add("@PosDate", SqlDbType.DateTime).Value = dtpPosDate.Value;
                com.Parameters.Add("@PosTotal", SqlDbType.Money).Value = Convert.ToDecimal(lblTotal.Text);
                com.Parameters.Add("@PosDisc", SqlDbType.Money).Value = Convert.ToDecimal(txtDisc.Text);
                com.Parameters.Add("@PosNet", SqlDbType.Money).Value = Convert.ToDecimal(lblNet.Text);
                com.Parameters.Add("@UsID", SqlDbType.NVarChar).Value = DBConnString.pUsID;
                com.Parameters.Add("@PosStatus", SqlDbType.Bit).Value = 1;//0=ยกเลิกใบเสร็จ, 1=ปรกติ
                com.Parameters.Add("@PosRemark", SqlDbType.NVarChar).Value = "";
                com.ExecuteNonQuery();
                tr.Commit();

                InstblPosTrn();//เพิ่มรายละเอียดใบเสร็๗ tblPosTrn
                PrintPOS();//พิมพ์ใบเสร็จ
                btnPrint.Enabled = true;//เปลี่ยนสถานะปุ่ม
                btnReceive.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("บันทึกข้อมูลผิดพลาด !!! : " + ex, DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tr.Rollback();
            }
        }

        private void InstblPosTrn()//เพิ่มรายละเอียดใบสั่งซื้อใน tblPosTrn
        {
            for (int i = 0; i <= lsvShow.Items.Count - 1; i++)
            {
                tr = Conn.BeginTransaction();
                sb = new StringBuilder();
                sb.Append("INSERT INTO tblPosTrn(PosID,ProID,PostPrice,PostNum,PostTotal)");
                sb.Append(" VALUES(@PosID,@ProID,@PostPrice,@PostNum,@PostTotal)");

                string sqlAdd;
                sqlAdd = sb.ToString();
                //txtProID.Text, txtProName.Text, xPtDetail, xUnDetail, Convert.ToDouble(txtProPrice.Text).ToString("#,##0.00"), Convert.ToDouble(txtNum.Text).ToString("#,##0"), xTotal.ToString("#,##0.00")
                com.CommandText = sqlAdd;
                com.CommandType = CommandType.Text;
                com.Connection = Conn;
                com.Transaction = tr;
                com.Parameters.Clear();
                com.Parameters.Add("@PosID", SqlDbType.NVarChar).Value = lblPosID.Text;
                com.Parameters.Add("@ProID", SqlDbType.NVarChar).Value = lsvShow.Items[i].SubItems[0].Text;
                com.Parameters.Add("@PostPrice", SqlDbType.Money).Value = Convert.ToDouble(lsvShow.Items[i].SubItems[4].Text);
                com.Parameters.Add("@PostNum", SqlDbType.Int).Value = Convert.ToDouble(lsvShow.Items[i].SubItems[5].Text);
                com.Parameters.Add("@PostTotal", SqlDbType.Money).Value = Convert.ToDouble(lsvShow.Items[i].SubItems[6].Text);
                com.ExecuteNonQuery();
                tr.Commit();

                UpdateProduct(lsvShow.Items[i].SubItems[0].Text, Convert.ToInt16(lsvShow.Items[i].SubItems[5].Text));

            }
        }

        private void UpdateProduct(string ProID, int ProNum)//ปรับปรุงจำนวนสินค้า (จำนวนสินค้าที่มี - จำนวนที่ขาย)
        {
            tr = Conn.BeginTransaction();
            sb = new StringBuilder();
            sb.Append("UPDATE tblProduct SET ProNum=ProNum-@ProNum WHERE ProID=@ProID");

            string sqlAdd;
            sqlAdd = sb.ToString();
            com.CommandText = sqlAdd;
            com.CommandType = CommandType.Text;
            com.Connection = Conn;
            com.Transaction = tr;
            com.Parameters.Clear();
            com.Parameters.Add("@ProID", SqlDbType.NVarChar).Value = ProID;
            com.Parameters.Add("@ProNum", SqlDbType.Int).Value = ProNum;
            com.ExecuteNonQuery();
            tr.Commit();
        }

        private void btnPrint_Click(object sender, EventArgs e)//พิมพ์ใบเสร็จ
        {
            if (MessageBox.Show("คุณต้องการพิมพ์ใบสั่งซื้อเลขที่ : " + lblPosID.Text + " ใช่หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                PrintPOS();
            }
        }

        private void PrintPOS()//พิมพ์ใบเสร็จ
        {
            DropTmpTable();//ลบข้อมูลตารางชั่วคราว

            try
            {
                tr = Conn.BeginTransaction();
                sb = new StringBuilder();

                sb.Append(" SELECT A.PosID,A.PosDate,A.PosTotal,A.PosDisc,A.PosNet,B.ProID,C.ProName,D.PtDetail,E.UnDetail,B.PostPrice,B.PostNum,B.PostTotal");
                sb.Append(" INTO _repPOS" + DBConnString.pUsID);//ใส่ในตารางที่สร้างขึ้นใหม่
                sb.Append(" FROM tblPos A");
                sb.Append(" INNER JOIN tblPosTrn B ON A.PosID=B.PosID");
                sb.Append(" LEFT JOIN tblProduct C ON C.ProID=B.ProID");
                sb.Append(" LEFT JOIN tblSetProductType D ON D.PtID=C.PtID");
                sb.Append(" LEFT JOIN tblSetUnit E ON E.UnID=C.UnID");
                sb.Append(" WHERE A.PosID=@PosID");

                SqlText = sb.ToString();
                com = new SqlCommand();
                com.CommandText = SqlText;
                com.CommandType = CommandType.Text;
                com.Connection = Conn;
                com.Transaction = tr;
                com.Parameters.Clear();
                com.Parameters.Add("@PosID", SqlDbType.NVarChar).Value = lblPosID.Text.Trim();
                com.ExecuteNonQuery();
                tr.Commit();

                SqlConnection cnn;
                string connectionString = null;
                string sql = null;

                connectionString = DBConnString.strConn;
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                sql = "SELECT * FROM " + "_repPOS" + DBConnString.pUsID;
                SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
                repPOS_DATA ds = new repPOS_DATA();
                dscmd.Fill(ds, "repPOS");
                cnn.Close();

                MoneyExt mne = new MoneyExt();
                string xThaiBath = "";
                xThaiBath = "(-" + mne.NumberToThaiWord(Convert.ToDouble(lblNet.Text)) + "-)";

                repPOS objRpt = new repPOS();
                objRpt.SetDataSource(ds.Tables[1]);
                objRpt.DataDefinition.FormulaFields["xSuName"].Text = "'" + PublicVariable.pSuName + "'";
                objRpt.DataDefinition.FormulaFields["xSuAddress"].Text = "'" + PublicVariable.pSuAddress + "'";
                objRpt.DataDefinition.FormulaFields["xThaiBath"].Text = "'" + xThaiBath + "'";
                objRpt.DataDefinition.FormulaFields["xUsFullName"].Text = "'('+'" + DBConnString.pUsFullName + "'+')'";

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

        private void DropTmpTable()//ลบข้อมูลในตารางชั่วคราวก่อน Query เพื่อเตรียมพิมพ์ใบเสร็จ
        {
            tr = Conn.BeginTransaction();
            try
            {
                sb = new StringBuilder();
                sb.Append("DROP TABLE _repPOS" + DBConnString.pUsID);

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

        private void btnExit_Click(object sender, EventArgs e)//ปิดฟอร์ม
        {
            if (Conn != null) { Conn.Close(); }
            this.Close();
        }

        private void crvRep_DoubleClick(object sender, EventArgs e)
        {
            crvRep.Visible = false;
        }

        private void txtDisc_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(lblNet.Text) > 0)
            {
                txtDisc.SelectAll();
                txtDisc.Focus();
            }
        }

        private void txtDisc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)//รับเงิน
            {
                if (Convert.ToDecimal(lblNet.Text) > 0)
                {
                    btnReceive_Click(sender, e);
                }
            }

            if (e.KeyCode == Keys.F6)//พิมพ์
            {
                if (btnPrint.Enabled == true)
                {
                    btnPrint_Click(sender, e);
                }
            }

            if (e.KeyCode == Keys.F7) { btnNext_Click(sender, e); }

            if (e.KeyCode == Keys.F10) { this.Close(); }

            if (e.KeyCode == Keys.Enter)
            {
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
            }
        }



    }
}
