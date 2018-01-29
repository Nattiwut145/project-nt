namespace SmartBAPOS_Sec2
{
    partial class frmReceive
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReceive));
            this.label10 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lsvShow = new System.Windows.Forms.ListView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtOrdNet = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtOrdDisc = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtOrdTotal = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvShow = new System.Windows.Forms.DataGridView();
            this.txtRecID = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtRecNet = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtRecDisc = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtRecTotal = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.crvRep = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblUsID = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblCpContact = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCpName = new System.Windows.Forms.Label();
            this.lblCpID = new System.Windows.Forms.Label();
            this.dtpOrdID = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFindCp = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrdID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRecGetID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpRecDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(291, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 15);
            this.label10.TabIndex = 7;
            this.label10.Text = "เลขที่รับสินค้า";
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTime.Location = new System.Drawing.Point(7, 86);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(573, 28);
            this.lblTime.TabIndex = 6;
            this.lblTime.Text = "lblTime";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lsvShow
            // 
            this.lsvShow.Location = new System.Drawing.Point(6, 21);
            this.lsvShow.Name = "lsvShow";
            this.lsvShow.Size = new System.Drawing.Size(580, 386);
            this.lsvShow.TabIndex = 0;
            this.lsvShow.UseCompatibleStateImageBehavior = false;
            this.lsvShow.DoubleClick += new System.EventHandler(this.lsvShow_DoubleClick);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox4.Controls.Add(this.txtOrdNet);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.txtOrdDisc);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.txtOrdTotal);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.dgvShow);
            this.groupBox4.Location = new System.Drawing.Point(0, 167);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(593, 447);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "รายละเอียดใบสั่งซื้อสินค้า";
            // 
            // txtOrdNet
            // 
            this.txtOrdNet.ForeColor = System.Drawing.Color.Red;
            this.txtOrdNet.Location = new System.Drawing.Point(456, 417);
            this.txtOrdNet.Name = "txtOrdNet";
            this.txtOrdNet.Size = new System.Drawing.Size(126, 20);
            this.txtOrdNet.TabIndex = 6;
            this.txtOrdNet.Text = "txtOrdNet";
            this.txtOrdNet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Blue;
            this.label13.Location = new System.Drawing.Point(424, 421);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "สุทธิ";
            // 
            // txtOrdDisc
            // 
            this.txtOrdDisc.ForeColor = System.Drawing.Color.Red;
            this.txtOrdDisc.Location = new System.Drawing.Point(280, 418);
            this.txtOrdDisc.Name = "txtOrdDisc";
            this.txtOrdDisc.Size = new System.Drawing.Size(122, 20);
            this.txtOrdDisc.TabIndex = 4;
            this.txtOrdDisc.Text = "txtOrdDisc";
            this.txtOrdDisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Blue;
            this.label12.Location = new System.Drawing.Point(234, 421);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "ส่วนลด";
            // 
            // txtOrdTotal
            // 
            this.txtOrdTotal.ForeColor = System.Drawing.Color.Red;
            this.txtOrdTotal.Location = new System.Drawing.Point(81, 418);
            this.txtOrdTotal.Name = "txtOrdTotal";
            this.txtOrdTotal.Size = new System.Drawing.Size(133, 20);
            this.txtOrdTotal.TabIndex = 2;
            this.txtOrdTotal.Text = "txtOrdTotal";
            this.txtOrdTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(26, 422);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "ราคารวม";
            // 
            // dgvShow
            // 
            this.dgvShow.AllowUserToAddRows = false;
            this.dgvShow.AllowUserToDeleteRows = false;
            this.dgvShow.BackgroundColor = System.Drawing.Color.Linen;
            this.dgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvShow.Location = new System.Drawing.Point(6, 21);
            this.dgvShow.Name = "dgvShow";
            this.dgvShow.ReadOnly = true;
            this.dgvShow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvShow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShow.Size = new System.Drawing.Size(581, 386);
            this.dgvShow.TabIndex = 0;
            this.dgvShow.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShow_CellDoubleClick);
            // 
            // txtRecID
            // 
            this.txtRecID.Location = new System.Drawing.Point(378, 26);
            this.txtRecID.Name = "txtRecID";
            this.txtRecID.Size = new System.Drawing.Size(189, 21);
            this.txtRecID.TabIndex = 8;
            this.txtRecID.Text = "txtRecID";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox5.Controls.Add(this.txtRecNet);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.txtRecDisc);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.txtRecTotal);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.lsvShow);
            this.groupBox5.ForeColor = System.Drawing.Color.Black;
            this.groupBox5.Location = new System.Drawing.Point(592, 167);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(592, 447);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "รายละเอียดการรับสินค้า";
            // 
            // txtRecNet
            // 
            this.txtRecNet.ForeColor = System.Drawing.Color.Red;
            this.txtRecNet.Location = new System.Drawing.Point(454, 414);
            this.txtRecNet.Name = "txtRecNet";
            this.txtRecNet.Size = new System.Drawing.Size(126, 20);
            this.txtRecNet.TabIndex = 12;
            this.txtRecNet.Text = "txtRecNet";
            this.txtRecNet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Blue;
            this.label14.Location = new System.Drawing.Point(422, 420);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "สุทธิ";
            // 
            // txtRecDisc
            // 
            this.txtRecDisc.ForeColor = System.Drawing.Color.Red;
            this.txtRecDisc.Location = new System.Drawing.Point(281, 416);
            this.txtRecDisc.Name = "txtRecDisc";
            this.txtRecDisc.Size = new System.Drawing.Size(120, 20);
            this.txtRecDisc.TabIndex = 10;
            this.txtRecDisc.Text = "txtRecDisc";
            this.txtRecDisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRecDisc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRecDisc_KeyDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Blue;
            this.label15.Location = new System.Drawing.Point(235, 419);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "ส่วนลด";
            // 
            // txtRecTotal
            // 
            this.txtRecTotal.ForeColor = System.Drawing.Color.Red;
            this.txtRecTotal.Location = new System.Drawing.Point(97, 416);
            this.txtRecTotal.Name = "txtRecTotal";
            this.txtRecTotal.Size = new System.Drawing.Size(118, 20);
            this.txtRecTotal.TabIndex = 8;
            this.txtRecTotal.Text = "txtRecTotal";
            this.txtRecTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Blue;
            this.label16.Location = new System.Drawing.Point(42, 419);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "ราคารวม";
            // 
            // crvRep
            // 
            this.crvRep.ActiveViewIndex = -1;
            this.crvRep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvRep.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvRep.Location = new System.Drawing.Point(512, 0);
            this.crvRep.Name = "crvRep";
            this.crvRep.Size = new System.Drawing.Size(181, 67);
            this.crvRep.TabIndex = 13;
            this.crvRep.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crvRep.DoubleClick += new System.EventHandler(this.crvRep_DoubleClick);
            // 
            // lblUsID
            // 
            this.lblUsID.BackColor = System.Drawing.Color.White;
            this.lblUsID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUsID.Location = new System.Drawing.Point(378, 54);
            this.lblUsID.Name = "lblUsID";
            this.lblUsID.Size = new System.Drawing.Size(189, 24);
            this.lblUsID.TabIndex = 5;
            this.lblUsID.Text = "lblUsID";
            this.lblUsID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.SkyBlue;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnPrint,
            this.btnNext,
            this.btnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1184, 39);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 36);
            this.btnSave.Text = "บันทึก";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(66, 36);
            this.btnPrint.Text = "พิมพ์";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnNext
            // 
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(66, 36);
            this.btnNext.Text = "ต่อไป";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(57, 36);
            this.btnExit.Text = "ปิด";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.lblCpContact);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblCpName);
            this.groupBox1.Controls.Add(this.lblCpID);
            this.groupBox1.Controls.Add(this.dtpOrdID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnFindCp);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtOrdID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(5, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(588, 121);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "รายละเอียดใบสั่งซื้อสินค้า";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(0, 121);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1169, 328);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // lblCpContact
            // 
            this.lblCpContact.BackColor = System.Drawing.Color.White;
            this.lblCpContact.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCpContact.Location = new System.Drawing.Point(106, 88);
            this.lblCpContact.Name = "lblCpContact";
            this.lblCpContact.Size = new System.Drawing.Size(476, 23);
            this.lblCpContact.TabIndex = 12;
            this.lblCpContact.Text = "lblCpContact";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(260, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "บริษัท/ร้าน";
            // 
            // lblCpName
            // 
            this.lblCpName.BackColor = System.Drawing.Color.White;
            this.lblCpName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCpName.Location = new System.Drawing.Point(331, 53);
            this.lblCpName.Name = "lblCpName";
            this.lblCpName.Size = new System.Drawing.Size(239, 25);
            this.lblCpName.TabIndex = 10;
            this.lblCpName.Text = "lblCpName";
            // 
            // lblCpID
            // 
            this.lblCpID.BackColor = System.Drawing.Color.White;
            this.lblCpID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCpID.Location = new System.Drawing.Point(106, 53);
            this.lblCpID.Name = "lblCpID";
            this.lblCpID.Size = new System.Drawing.Size(147, 25);
            this.lblCpID.TabIndex = 2;
            this.lblCpID.Text = "lblCpID";
            // 
            // dtpOrdID
            // 
            this.dtpOrdID.Location = new System.Drawing.Point(388, 23);
            this.dtpOrdID.Name = "dtpOrdID";
            this.dtpOrdID.Size = new System.Drawing.Size(182, 21);
            this.dtpOrdID.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(314, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "วันที่สั่งซื้อ";
            // 
            // btnFindCp
            // 
            this.btnFindCp.Image = ((System.Drawing.Image)(resources.GetObject("btnFindCp.Image")));
            this.btnFindCp.Location = new System.Drawing.Point(259, 15);
            this.btnFindCp.Name = "btnFindCp";
            this.btnFindCp.Size = new System.Drawing.Size(31, 29);
            this.btnFindCp.TabIndex = 7;
            this.btnFindCp.UseVisualStyleBackColor = true;
            this.btnFindCp.Click += new System.EventHandler(this.btnFindCp_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "ผู้ติดต่อ/Tel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "บริษัท/ร้าน";
            // 
            // txtOrdID
            // 
            this.txtOrdID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtOrdID.Location = new System.Drawing.Point(106, 23);
            this.txtOrdID.Name = "txtOrdID";
            this.txtOrdID.Size = new System.Drawing.Size(147, 21);
            this.txtOrdID.TabIndex = 1;
            this.txtOrdID.Text = "txtOrdID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "เลขที่ใบสั่งซื้อ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(312, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "ผู้รับสินค้า";
            // 
            // txtRecGetID
            // 
            this.txtRecGetID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtRecGetID.Location = new System.Drawing.Point(121, 26);
            this.txtRecGetID.Name = "txtRecGetID";
            this.txtRecGetID.Size = new System.Drawing.Size(164, 21);
            this.txtRecGetID.TabIndex = 3;
            this.txtRecGetID.Text = "txtRecGetID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "เลขที่ใบส่งสินค้า";
            // 
            // dtpRecDate
            // 
            this.dtpRecDate.Location = new System.Drawing.Point(121, 54);
            this.dtpRecDate.Name = "dtpRecDate";
            this.dtpRecDate.Size = new System.Drawing.Size(164, 21);
            this.dtpRecDate.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "วันที่สั่งซื้อ";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupBox2.Controls.Add(this.txtRecID);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lblTime);
            this.groupBox2.Controls.Add(this.lblUsID);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtRecGetID);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.dtpRecDate);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox2.Location = new System.Drawing.Point(592, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(588, 121);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ข้อมูลใบสั่งซื้อสินค้า";
            // 
            // frmReceive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1184, 615);
            this.ControlBox = false;
            this.Controls.Add(this.crvRep);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmReceive";
            this.Text = "รับสินค้าเข้าสต๊อก";
            this.Load += new System.EventHandler(this.frmReceive_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.ListView lsvShow;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtOrdNet;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtOrdDisc;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtOrdTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dgvShow;
        private System.Windows.Forms.TextBox txtRecID;
        private System.Windows.Forms.GroupBox groupBox5;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvRep;
        private System.Windows.Forms.TextBox txtRecNet;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtRecDisc;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtRecTotal;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblUsID;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripButton btnNext;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblCpContact;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCpName;
        private System.Windows.Forms.Label lblCpID;
        private System.Windows.Forms.DateTimePicker dtpOrdID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFindCp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrdID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRecGetID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpRecDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}