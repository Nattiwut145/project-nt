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
    public partial class frmReceive : Form
    {
        public frmReceive()
        {
            InitializeComponent();
        }



        SqlConnection Conn;
        SqlCommand com;
        SqlTransaction tr;
        StringBuilder sb;
        string SqlText = "";
        string sqlTmp = "";
        SqlDataReader drTmp;
        Timer clock;
        double xTotal = 0;//ราคารวม

        private void frmReceive_Load(object sender, EventArgs e)//เชื่อมต่อฐานข้อมูล
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

        private void AutoGENID()//หมายเลขใบรับสินค้าอัตโนมัติ
        {
            int tmpID = 0; //ตัวแปรเก็บรหัส
            string tmpQuoID = ""; //ตัวแปรเก็บรหัส
            string tmpDate; //ตัวแปรเก็บวันขึ้นปีใหม่
            string tmpBrDate;//ตัวแปรเก็บวันที่ใน DB
            sqlTmp = "";

            sqlTmp = "SELECT TOP 1 RecID FROM tblReceive ORDER BY RecID DESC";//สร้างชุดคำสั่ง SQL เพื่อเลือกรหัสตำแหน่งล่าสุด
            try
            {
                com = new SqlCommand();//เอาไว้ค้นใน DataSet
                com.CommandType = CommandType.Text;
                com.CommandText = sqlTmp;
                com.Connection = Conn;

                drTmp = com.ExecuteReader();//ประเภทเรียกดูหรืออ่านข้อมูล     //ทำหน้าที่รันชุดคำสั่ง SQL ผลลัพธ์เก็บไว้ใน DataReader
                drTmp.Read(); //เริ่มอ่านข้อมูล

                tmpQuoID = drTmp["RecID"].ToString();//อ่านรหัส 
                tmpBrDate = tmpQuoID.Substring(3, 2);
                tmpDate = StringExt.StringFromRight("1/1/" + Convert.ToInt32(DateTime.Now.Year + 543), 2);

                if (Convert.ToInt16(tmpDate) == Convert.ToInt16(tmpBrDate))
                {
                    tmpID = Convert.ToInt32(StringExt.StringFromRight(tmpQuoID, 5)) + 1;
                    txtRecID.Text = "RC-" + StringExt.StringFromRight("1/1/" + Convert.ToInt32(DateTime.Now.Year + 543), 2) + tmpID.ToString("00000");
                }
                else
                {
                    tmpID = 1;
                    txtRecID.Text = "RC-" + StringExt.StringFromRight("1/1/" + Convert.ToInt32(DateTime.Now.Year + 543), 2) + tmpID.ToString("00000");
                }
                drTmp.Close(); //ปิดการทำงาน
            }
            catch
            {
                tmpID = 1;
                txtRecID.Text = "RC-" + StringExt.StringFromRight("1/1/" + Convert.ToInt32(DateTime.Now.Year + 543), 2) + tmpID.ToString("00000");
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
                txtRecID.Focus();
                btnSave.Enabled = false;
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

            lblUsID.Text = "";
            lblCpID.Text = "";
            lblCpName.Text = "";
            lblCpContact.Text = "";
            lblTime.Text = "";

            AutoGENID();//เลขที่ใบรับ

            dtpOrdID.Value = DateTime.Now;
            dtpRecDate.Value = DateTime.Now;

            crvRep.Visible = false;

            lblUsID.Text = DBConnString.pUsFullName.ToString();
            lsvFormat();//กำหนดรูปแบบ ListView

            txtOrdTotal.Text = "0.00 ";
            txtOrdDisc.Text = "0.00 ";
            txtOrdNet.Text = "0.00 ";

            txtRecTotal.Text = "0.00 ";
            txtRecDisc.Text = "0.00 ";
            txtRecNet.Text = "0.00 ";
        }

        private void lsvFormat()//กำหนดรูปแบบ ListView
        {
            lsvShow.Clear();
            lsvShow.Columns.Add("รหัสสินค้า", 70, HorizontalAlignment.Center);
            lsvShow.Columns.Add("รายการสินค้า", 170, HorizontalAlignment.Left);
            lsvShow.Columns.Add("ประเภท", 100, HorizontalAlignment.Left);
            lsvShow.Columns.Add("หน่วยนับ", 65, HorizontalAlignment.Left);
            lsvShow.Columns.Add("ราคา", 80, HorizontalAlignment.Right);
            lsvShow.Columns.Add("จำนวน", 50, HorizontalAlignment.Right);
            lsvShow.Columns.Add("รวม", 90, HorizontalAlignment.Right);
            lsvShow.View = View.Details;
            lsvShow.GridLines = true;
            lsvShow.FullRowSelect = true;
        }

        private void timer1_Tick(object sender, EventArgs e)//แสดงนาฬิกา ณ เวลาปัจจุบัน
        {
            if (sender == clock)
            {
                lblTime.Text = " เวลา : " + DateTime.Now.ToString("HH:mm:ss");
            }
        }

        private void btnFindCp_Click(object sender, EventArgs e)//ค้นหาใบสั่งซื้อสินค้า
        {
            frmFindOrder FindOrder = new frmFindOrder();
            if (FindOrder.ShowDialog() == DialogResult.OK)
            {
                txtOrdID.Text = DBConnString.pOrdID;
                lblCpID.Text = DBConnString.pCpID;
                lblCpName.Text = DBConnString.pCpName;
                lblCpContact.Text = DBConnString.pCpContact;

                txtOrdTotal.Text = DBConnString.pTotal.ToString("#,##0.00 ");
                txtOrdDisc.Text = DBConnString.pDisc.ToString("#,##0.00 ");
                txtOrdNet.Text = DBConnString.pNet.ToString("#,##0.00 ");

                lsvFormat();//ล้าง ListView ใหม่

                txtRecGetID.Focus();

                if (Convert.ToDouble(txtOrdNet.Text) > 0) { btnSave.Enabled = true; }

                if (!string.IsNullOrEmpty(txtOrdID.Text.Trim()))
                {
                    ShowData();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (Conn != null) { Conn.Close(); }
            this.Close();
        }

        private void ShowData()//แสดงข้อมูลใน DataGridView
        {
            string sqltblBuilding;
            sqltblBuilding = " SELECT A.OrdID,A.OrdStatus,B.ProID,C.ProName,B.OrtPrice,B.OrtNum,B.OrtTotal,E.PtDetail,D.UnDetail";
            sqltblBuilding += " FROM tblOrder A INNER JOIN tblOrderTrn B ON A.OrdID=B.OrdID";
            sqltblBuilding += " LEFT JOIN tblProduct C ON B.ProID=C.ProID";
            sqltblBuilding += " LEFT JOIN tblSetUnit D ON D.UnID=C.UnID";
            sqltblBuilding += " LEFT JOIn tblSetProductType E ON E.PtID = C.PtID";
            sqltblBuilding += " WHERE A.OrdID='" + txtOrdID.Text.Trim() + "'";

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
                dgvShow.Columns[0].Visible = false;
                dgvShow.Columns[1].HeaderText = "สถานะสิน้า";
                dgvShow.Columns[1].Visible = false;
                dgvShow.Columns[2].HeaderText = "รหัสสินค้า";
                dgvShow.Columns[3].HeaderText = "รายการ";
                dgvShow.Columns[4].HeaderText = "ราคา:หน่วย";
                dgvShow.Columns[5].HeaderText = "จำนวน";
                dgvShow.Columns[6].HeaderText = "ราคารวม";
                dgvShow.Columns[7].Visible = false;
                dgvShow.Columns[8].Visible = false;

                dgvShow.Columns[0].Width = 80;
                dgvShow.Columns[1].Width = 100;
                dgvShow.Columns[2].Width = 80;
                dgvShow.Columns[3].Width = 180;
                dgvShow.Columns[4].Width = 80;
                dgvShow.Columns[5].Width = 80;
                dgvShow.Columns[6].Width = 80;

                dgvShow.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvShow.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvShow.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvShow.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvShow.Columns[4].DefaultCellStyle.Format = "#,##0.00 ";
                dgvShow.Columns[5].DefaultCellStyle.Format = "#,##0 ";
                dgvShow.Columns[6].DefaultCellStyle.Format = "#,##0.00 ";

                dgvShow.ClearSelection();
                dgvShow.CurrentCell = null;
            }
        }

        private void dgvShow_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dgvShow.Rows.Count) { return; }
            if (e.RowIndex == -1) { return; }

            foreach (ListViewItem item in lsvShow.Items)//ค้นหาสินค้าใน ListView ว่าถูกเลือกแล้วหรือยัง
            {
                var ProID = item.SubItems[0];
                if (ProID.Text == dgvShow.Rows[e.RowIndex].Cells["ProID"].Value.ToString())
                {
                    MessageBox.Show("รายการสินค้านี้ ถูกเลือกแล้ว", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            ListViewItem lvi;
            string[] anydata;
            anydata = new string[] { 
                dgvShow.Rows[e.RowIndex].Cells["ProID"].Value.ToString(), 
                dgvShow.Rows[e.RowIndex].Cells["ProName"].Value.ToString(), 
                dgvShow.Rows[e.RowIndex].Cells["PtDetail"].Value.ToString(), 
                dgvShow.Rows[e.RowIndex].Cells["UnDetail"].Value.ToString(), 
                Convert.ToDecimal(dgvShow.Rows[e.RowIndex].Cells["OrtPrice"].Value.ToString()).ToString("#,##0.00 "), 
                Convert.ToDecimal(dgvShow.Rows[e.RowIndex].Cells["OrtNum"].Value.ToString()).ToString("#,##0 "), 
                Convert.ToDecimal(dgvShow.Rows[e.RowIndex].Cells["OrtTotal"].Value.ToString()).ToString("#,##0.00 "), 
                };
            lvi = new ListViewItem(anydata);
            lsvShow.Items.Add(lvi);

            dgvShow.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
            dgvShow.ClearSelection();
            dgvShow.CurrentCell = null;

            SumPrice();
        }

        private void SumPrice()//หาผลรวมใบสั่งซื้อสินค้า
        {
            double xNet = 0;
            for (int i = 0; i <= lsvShow.Items.Count - 1; i++)
            {
                xNet = xNet + Convert.ToDouble(lsvShow.Items[i].SubItems[6].Text);
            }

            txtRecTotal.Text = xNet.ToString("#,##0.00 ");//ราคารวม
            txtRecNet.Text = (Convert.ToDouble(txtRecTotal.Text.ToString()) - Convert.ToDouble(txtRecDisc.Text.ToString())).ToString("#,##0.00 ");//ราคาสุทธิ

            if (xNet > 0)
            {
                btnSave.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)//บันทึกรายการรับสินค้า
        {
            if (string.IsNullOrEmpty(txtRecGetID.Text.Trim()))
            {
                MessageBox.Show("กรุณาป้อนใบรับสินค้า !!!", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtRecGetID.Focus();
                return;
            }

            if (MessageBox.Show("คุณต้องการบันทึกข้อมูลใบรับสินค้าเลขที่ : " + txtRecID.Text.Trim() + " ใช่หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                InstblRecive();
            }
        }

        private void InstblRecive()//เพิ่มข้อมูลใบรับสินค้าใน tblReceive
        {
            tr = Conn.BeginTransaction();
            try
            {
                sb = new StringBuilder();
                sb.Append(" INSERT INTO tblReceive(RecID,OrdID,RecGetID,RecDate,RecTotal,RecDisc,RecNet,UsID)");
                sb.Append(" VALUES(@RecID,@OrdID,@RecGetID,@RecDate,@RecTotal,@RecDisc,@RecNet,@UsID)");
                string sqlAdd;
                sqlAdd = sb.ToString();

                com.CommandText = sqlAdd;
                com.CommandType = CommandType.Text;
                com.Connection = Conn;
                com.Transaction = tr;
                com.Parameters.Clear();
                com.Parameters.Add("@RecID", SqlDbType.NVarChar).Value = txtRecID.Text.Trim();
                com.Parameters.Add("@OrdID", SqlDbType.NVarChar).Value = txtOrdID.Text.Trim();
                com.Parameters.Add("@RecGetID", SqlDbType.NVarChar).Value = txtRecGetID.Text.Trim();
                com.Parameters.Add("@RecDate", SqlDbType.DateTime).Value = dtpRecDate.Value;
                com.Parameters.Add("@RecTotal", SqlDbType.Money).Value = Convert.ToDouble(txtRecTotal.Text);
                com.Parameters.Add("@RecDisc", SqlDbType.Money).Value = Convert.ToDouble(txtRecDisc.Text);
                com.Parameters.Add("@RecNet", SqlDbType.Money).Value = Convert.ToDouble(txtRecNet.Text);
                com.Parameters.Add("@UsID", SqlDbType.NVarChar).Value = DBConnString.pUsID;
                com.ExecuteNonQuery();
                tr.Commit();

                InstblReceiveTrn();//เพิ่มรายละเอียดใบรับสินค้าใน tblReceiveTrn
                PrintReceive();//พิมพ์ใบรับสินค้าเข้า
                btnPrint.Enabled = true;//เปลี่ยนสถานะปุ่ม
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("บันทึกข้อมูลผิดพลาด !!! : " + ex, DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tr.Rollback();
            }
        }

        private void InstblReceiveTrn()//เพิ่มรายละเอียดใบรับสินค้าใน tblReceiveTrn
        {
            for (int i = 0; i <= lsvShow.Items.Count - 1; i++)
            {
                tr = Conn.BeginTransaction();
                sb = new StringBuilder();
                sb.Append("INSERT INTO tblRecTrn(RecID,ProID,RectPrice,RectNum,RectTotal)");
                sb.Append(" VALUES(@RecID,@ProID,@RectPrice,@RectNum,@RectTotal)");

                string sqlAdd;
                sqlAdd = sb.ToString();
                //anydata = new string[] { txtProID.Text, txtProName.Text, xPtDetail, xUnDetail, Convert.ToDouble(txtProPrice.Text).ToString("#,##0.00"), Convert.ToDouble(txtNum.Text).ToString("#,##0"), xTotal.ToString("#,##0.00") };
                com.CommandText = sqlAdd;
                com.CommandType = CommandType.Text;
                com.Connection = Conn;
                com.Transaction = tr;
                com.Parameters.Clear();
                com.Parameters.Add("@RecID", SqlDbType.NVarChar).Value = txtRecID.Text.Trim();
                com.Parameters.Add("@ProID", SqlDbType.NVarChar).Value = lsvShow.Items[i].SubItems[0].Text;
                com.Parameters.Add("@RectPrice", SqlDbType.Money).Value = Convert.ToDouble(lsvShow.Items[i].SubItems[4].Text);
                com.Parameters.Add("@RectNum", SqlDbType.Int).Value = Convert.ToDouble(lsvShow.Items[i].SubItems[5].Text);
                com.Parameters.Add("@RectTotal", SqlDbType.Money).Value = Convert.ToDouble(lsvShow.Items[i].SubItems[6].Text);
                com.ExecuteNonQuery();
                tr.Commit();

                UpdatetblOrderTrn(lsvShow.Items[i].SubItems[0].Text);//ปรับปรุงรหัสสินค้าว่ารับแล้ว
                UpdatetblProduct(lsvShow.Items[i].SubItems[0].Text, Convert.ToDouble(lsvShow.Items[i].SubItems[5].Text));//ปรับปรุงจำนวนสินค้าในตาราง tblProduct

            }

            UpdatetblOrder();//ปรับปรุงใบสั่งซื้อสินค้าว่ารับแล้ว
        }

        private void UpdatetblOrderTrn(string ProID)//ปรับปรุงรหัสสินค้าว่ารับแล้ว
        {
            tr = Conn.BeginTransaction();
            sb = new StringBuilder();
            sb.Append("UPDATE tblOrderTrn SET OrtStatus=1 WHERE OrdID=@OrdID");
            sb.Append(" AND ProID=@ProID");

            string sqlAdd;
            sqlAdd = sb.ToString();
            com.CommandText = sqlAdd;
            com.CommandType = CommandType.Text;
            com.Connection = Conn;
            com.Transaction = tr;
            com.Parameters.Clear();
            com.Parameters.Add("@OrdID", SqlDbType.NVarChar).Value = txtOrdID.Text.Trim();
            com.Parameters.Add("@ProID", SqlDbType.NVarChar).Value = ProID;
            com.ExecuteNonQuery();
            tr.Commit();
        }

        private void UpdatetblProduct(string ProID, double ProNum)
        {
            tr = Conn.BeginTransaction();
            sb = new StringBuilder();
            sb.Append("UPDATE tblProduct SET ProNum=ProNum+@ProNum WHERE ProID=@ProID");

            string sqlAdd;
            sqlAdd = sb.ToString();
            com.CommandText = sqlAdd;
            com.CommandType = CommandType.Text;
            com.Connection = Conn;
            com.Transaction = tr;
            com.Parameters.Clear();
            com.Parameters.Add("@ProID", SqlDbType.NVarChar).Value = ProID;
            com.Parameters.Add("@ProNum", SqlDbType.Decimal).Value = ProNum;
            com.ExecuteNonQuery();
            tr.Commit();
        }

        private void UpdatetblOrder()//ปรับปรุงใบสั่งซื้อสินค้าว่ารับแล้ว
        {
            tr = Conn.BeginTransaction();
            sb = new StringBuilder();
            sb.Append("UPDATE tblOrder SET OrdStatus=1 WHERE OrdID=@OrdID");

            string sqlAdd;
            sqlAdd = sb.ToString();
            com.CommandText = sqlAdd;
            com.CommandType = CommandType.Text;
            com.Connection = Conn;
            com.Transaction = tr;
            com.Parameters.Clear();
            com.Parameters.Add("@OrdID", SqlDbType.NVarChar).Value = txtOrdID.Text.Trim();
            com.ExecuteNonQuery();
            tr.Commit();
        }

        private void btnPrint_Click(object sender, EventArgs e)//พิมพ์ใบรับสินค้า
        {
            if (MessageBox.Show("คุณต้องการพิมพ์ใบรับสินค้าเลขที่ : " + txtRecGetID.Text + " ใช่หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                PrintReceive();
            }
        }

        private void PrintReceive()//พิมพ์ใบรับสินค้า
        {
            DropTmpTable();//ลบข้อมูลตารางชั่วคราว

            try
            {
                tr = Conn.BeginTransaction();
                sb = new StringBuilder();

                sb.Append(" SELECT G.CpID,G.CpName,G.CpAddress+ ' โทรศัพท์ : ' + G.CpTel AS CpAddress,");
                sb.Append(" G.CpContact + ' โทรศัพท์ : '+ G.CpContactTel AS CpContact,");
                sb.Append(" A.*,F.OrdDate,B.ProID,C.ProName,D.PtDetail,B.RectPrice,E.UnDetail,B.RectNum,B.RectTotal,");
                sb.Append(" I.TiDetail+H.UsFirstName+' '+ H.UsLastName AS UsFullName");
                sb.Append(" INTO _repReceive" + DBConnString.pUsID);//ใส่ในตารางที่สร้างขึ้นใหม่
                sb.Append(" FROM tblReceive");
                sb.Append(" A INNER JOIN tblRecTrn B ON A.RecID=B.RecID");
                sb.Append(" LEFT JOIN tblProduct C ON B.ProID=C.ProID");
                sb.Append(" LEFT JOIN tblSetProductType D ON D.PtID=C.PtID");
                sb.Append(" LEFT JOIN tblSetUnit E ON E.UnID=C.UnID");
                sb.Append(" LEFT JOIN tblOrder F ON F.OrdID=A.OrdID");
                sb.Append(" LEFT JOIN tblSetCompany G ON G.CpID=F.CpID");

                sb.Append(" LEFT JOIN tblSetUser H ON H.UsID=A.UsID");
                sb.Append(" LEFT JOIN tblSetTitle I ON I.TiID=H.TiID");

                sb.Append(" WHERE A.RecID=@RecID");

                SqlText = sb.ToString();
                com = new SqlCommand();
                com.CommandText = SqlText;
                com.CommandType = CommandType.Text;
                com.Connection = Conn;
                com.Transaction = tr;
                com.Parameters.Clear();
                com.Parameters.Add("@RecID", SqlDbType.NVarChar).Value = txtRecID.Text.Trim();
                com.ExecuteNonQuery();
                tr.Commit();

                SqlConnection cnn;
                string connectionString = null;
                string sql = null;

                connectionString = DBConnString.strConn;
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                sql = "SELECT * FROM " + "_repReceive" + DBConnString.pUsID;
                SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
                repReceive_Data ds = new repReceive_Data();
                dscmd.Fill(ds, "repReceive");
                cnn.Close();

                MoneyExt mne = new MoneyExt();
                string xThaiBath = "";
                xThaiBath = "(-" + mne.NumberToThaiWord(Convert.ToDouble(txtRecNet.Text)) + "-)";

                repReceive objRpt = new repReceive();
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
                sb.Append("DROP TABLE _repReceive" + DBConnString.pUsID);

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

        private void lsvShow_DoubleClick(object sender, EventArgs e)//ลบรายการรับเมื่อกดปุ่ม DoubleClick
        {
            if (MessageBox.Show("คุณต้องการลบรายการรับสินค้าสินค้าใช่หรือไม่ ?", DBConnString.xMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {

                ListViewItem lvi;

                string ProID = "";

                for (int i = 0; i <= lsvShow.SelectedItems.Count - 1; i++)
                {
                    lvi = lsvShow.SelectedItems[i];
                    ProID = lsvShow.SelectedItems[i].SubItems[0].Text;
                    lsvShow.Items.Remove(lvi);
                }

                int rowIndex = 0;
                foreach (DataGridViewRow row in dgvShow.Rows)
                {
                    if (row.Cells["ProID"].Value.ToString().Equals(ProID))
                    {
                        rowIndex = row.Index;
                        dgvShow.Rows[row.Index].DefaultCellStyle.BackColor = Color.White;//เปลี่ยนเป็นสีขาว
                        break;
                    }
                }

                SumPrice();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)//ล้างหน้าจอ
        {
            frmReceive_Load(sender, e);
            dgvShow.DataSource = null;
        }

        private void crvRep_DoubleClick(object sender, EventArgs e)//ปิดหน้าจอ CrystalReportViewer
        {
            crvRep.Visible = false;
        }

        private void txtRecDisc_KeyDown(object sender, KeyEventArgs e)//กรอกส่วนลดรับ และกดปุ่มต่าง ๆ
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtRecGetID.Text.Trim()))
                {
                    MessageBox.Show("โปรดกรอกเลขที่ใบรับสินค้า ", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRecGetID.Focus();
                    return;
                }

                if (isNumeric(txtRecDisc.Text, System.Globalization.NumberStyles.Number) == false)
                {
                    MessageBox.Show("โปรดป้อนส่วนลดให้ถูกต้อง !!!", DBConnString.xMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtRecDisc.SelectAll();
                    txtRecDisc.Focus();
                    return;
                }

                xTotal = Convert.ToDouble(txtRecDisc.Text);
                txtRecDisc.Text = xTotal.ToString("#,##0.00 ");
                SumPrice();
            }
        }

    }
}
