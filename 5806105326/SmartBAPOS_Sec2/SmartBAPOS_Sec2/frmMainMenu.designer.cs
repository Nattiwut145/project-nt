namespace SmartBAPOS_Sec2
{
    partial class frmMainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainMenu));
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.ribbonControl1 = new DevComponents.DotNetBar.RibbonControl();
            this.ribbonPanel1 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.rbFiles_POS = new DevComponents.DotNetBar.ButtonItem();
            this.rbFiles_Product = new DevComponents.DotNetBar.ButtonItem();
            this.rbFiles_Exit = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonPanel5 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar7 = new DevComponents.DotNetBar.RibbonBar();
            this.rbAbout_Me = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonPanel3 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar3 = new DevComponents.DotNetBar.RibbonBar();
            this.rbReport_Product = new DevComponents.DotNetBar.ButtonItem();
            this.rbReport_Income = new DevComponents.DotNetBar.ButtonItem();
            this.rbSetup_ProductDecrease = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonPanel4 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar5 = new DevComponents.DotNetBar.RibbonBar();
            this.rbSetup_SetCompany = new DevComponents.DotNetBar.ButtonItem();
            this.rbSetup_SetProductType = new DevComponents.DotNetBar.ButtonItem();
            this.rbSetup_SetUnit = new DevComponents.DotNetBar.ButtonItem();
            this.rbSetup_SetStartUp = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar4 = new DevComponents.DotNetBar.RibbonBar();
            this.rbSetup_SetTitle = new DevComponents.DotNetBar.ButtonItem();
            this.rbSetup_SetPosition = new DevComponents.DotNetBar.ButtonItem();
            this.rbSetup_SetUser = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonPanel2 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar2 = new DevComponents.DotNetBar.RibbonBar();
            this.rbPOS_Sales = new DevComponents.DotNetBar.ButtonItem();
            this.rbPOS_SearchProduct = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonPanel6 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar6 = new DevComponents.DotNetBar.RibbonBar();
            this.rbOrdRec_Order = new DevComponents.DotNetBar.ButtonItem();
            this.rbOrdRec_Receive = new DevComponents.DotNetBar.ButtonItem();
            this.rbFiles = new DevComponents.DotNetBar.RibbonTabItem();
            this.rbPOS = new DevComponents.DotNetBar.RibbonTabItem();
            this.rbOrdRec = new DevComponents.DotNetBar.RibbonTabItem();
            this.rbReport = new DevComponents.DotNetBar.RibbonTabItem();
            this.rbSetup = new DevComponents.DotNetBar.RibbonTabItem();
            this.rbAbout = new DevComponents.DotNetBar.RibbonTabItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.qatCustomizeItem1 = new DevComponents.DotNetBar.QatCustomizeItem();
            this.styleManager2 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem6 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem7 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem9 = new DevComponents.DotNetBar.ButtonItem();
            this.crvRep = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUsFullName = new System.Windows.Forms.ToolStripStatusLabel();
            this.ribbonControl1.SuspendLayout();
            this.ribbonPanel1.SuspendLayout();
            this.ribbonPanel5.SuspendLayout();
            this.ribbonPanel3.SuspendLayout();
            this.ribbonPanel4.SuspendLayout();
            this.ribbonPanel2.SuspendLayout();
            this.ribbonPanel6.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonControl1.CaptionVisible = true;
            this.ribbonControl1.Controls.Add(this.ribbonPanel1);
            this.ribbonControl1.Controls.Add(this.ribbonPanel5);
            this.ribbonControl1.Controls.Add(this.ribbonPanel3);
            this.ribbonControl1.Controls.Add(this.ribbonPanel4);
            this.ribbonControl1.Controls.Add(this.ribbonPanel2);
            this.ribbonControl1.Controls.Add(this.ribbonPanel6);
            this.ribbonControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ribbonControl1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.rbFiles,
            this.rbPOS,
            this.rbOrdRec,
            this.rbReport,
            this.rbSetup,
            this.rbAbout});
            this.ribbonControl1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.ribbonControl1.QuickToolbarItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1,
            this.qatCustomizeItem1});
            this.ribbonControl1.RibbonStripFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ribbonControl1.Size = new System.Drawing.Size(767, 147);
            this.ribbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonControl1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.ribbonControl1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.ribbonControl1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.ribbonControl1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.ribbonControl1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.ribbonControl1.SystemText.QatDialogAddButton = "&Add >>";
            this.ribbonControl1.SystemText.QatDialogCancelButton = "Cancel";
            this.ribbonControl1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.ribbonControl1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.ribbonControl1.SystemText.QatDialogOkButton = "OK";
            this.ribbonControl1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl1.SystemText.QatDialogRemoveButton = "&Remove";
            this.ribbonControl1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.ribbonControl1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.ribbonControl1.TabGroupHeight = 14;
            this.ribbonControl1.TabIndex = 2;
            this.ribbonControl1.Click += new System.EventHandler(this.ribbonControl1_Click);
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel1.Controls.Add(this.ribbonBar1);
            this.ribbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel1.Location = new System.Drawing.Point(0, 53);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel1.Size = new System.Drawing.Size(767, 91);
            // 
            // 
            // 
            this.ribbonPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel1.TabIndex = 1;
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar1.DragDropSupport = true;
            this.ribbonBar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ribbonBar1.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.rbFiles_POS,
            this.rbFiles_Product,
            this.rbFiles_Exit});
            this.ribbonBar1.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(201, 88);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar1.TabIndex = 0;
            this.ribbonBar1.Text = "Files";
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // rbFiles_POS
            // 
            this.rbFiles_POS.Image = ((System.Drawing.Image)(resources.GetObject("rbFiles_POS.Image")));
            this.rbFiles_POS.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.rbFiles_POS.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.rbFiles_POS.Name = "rbFiles_POS";
            this.rbFiles_POS.SubItemsExpandWidth = 14;
            this.rbFiles_POS.Text = "ขายสินค้า";
            this.rbFiles_POS.Click += new System.EventHandler(this.rbFiles_POS_Click);
            // 
            // rbFiles_Product
            // 
            this.rbFiles_Product.Image = ((System.Drawing.Image)(resources.GetObject("rbFiles_Product.Image")));
            this.rbFiles_Product.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.rbFiles_Product.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.rbFiles_Product.Name = "rbFiles_Product";
            this.rbFiles_Product.SubItemsExpandWidth = 14;
            this.rbFiles_Product.Text = "สินค้า";
            this.rbFiles_Product.Click += new System.EventHandler(this.rbFiles_Product_Click);
            // 
            // rbFiles_Exit
            // 
            this.rbFiles_Exit.Image = ((System.Drawing.Image)(resources.GetObject("rbFiles_Exit.Image")));
            this.rbFiles_Exit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.rbFiles_Exit.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.rbFiles_Exit.Name = "rbFiles_Exit";
            this.rbFiles_Exit.SubItemsExpandWidth = 14;
            this.rbFiles_Exit.Text = "จบการทำงาน";
            this.rbFiles_Exit.Tooltip = "จบการทำงาน";
            this.rbFiles_Exit.Click += new System.EventHandler(this.rbFiles_Exit_Click);
            // 
            // ribbonPanel5
            // 
            this.ribbonPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel5.Controls.Add(this.ribbonBar7);
            this.ribbonPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel5.Location = new System.Drawing.Point(0, 53);
            this.ribbonPanel5.Name = "ribbonPanel5";
            this.ribbonPanel5.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel5.Size = new System.Drawing.Size(767, 91);
            // 
            // 
            // 
            this.ribbonPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel5.TabIndex = 5;
            this.ribbonPanel5.Visible = false;
            // 
            // ribbonBar7
            // 
            this.ribbonBar7.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar7.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar7.ContainerControlProcessDialogKey = true;
            this.ribbonBar7.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar7.DragDropSupport = true;
            this.ribbonBar7.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.ribbonBar7.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.rbAbout_Me});
            this.ribbonBar7.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar7.Name = "ribbonBar7";
            this.ribbonBar7.Size = new System.Drawing.Size(100, 88);
            this.ribbonBar7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar7.TabIndex = 0;
            this.ribbonBar7.Text = "About Me";
            // 
            // 
            // 
            this.ribbonBar7.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar7.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // rbAbout_Me
            // 
            this.rbAbout_Me.Image = ((System.Drawing.Image)(resources.GetObject("rbAbout_Me.Image")));
            this.rbAbout_Me.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.rbAbout_Me.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.rbAbout_Me.Name = "rbAbout_Me";
            this.rbAbout_Me.SubItemsExpandWidth = 14;
            this.rbAbout_Me.Text = "ผู้พัฒนาระบบ";
            this.rbAbout_Me.Click += new System.EventHandler(this.rbAbout_Me_Click);
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel3.Controls.Add(this.ribbonBar3);
            this.ribbonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel3.Location = new System.Drawing.Point(0, 53);
            this.ribbonPanel3.Name = "ribbonPanel3";
            this.ribbonPanel3.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel3.Size = new System.Drawing.Size(767, 91);
            // 
            // 
            // 
            this.ribbonPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel3.TabIndex = 3;
            this.ribbonPanel3.Visible = false;
            // 
            // ribbonBar3
            // 
            this.ribbonBar3.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar3.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar3.ContainerControlProcessDialogKey = true;
            this.ribbonBar3.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar3.DragDropSupport = true;
            this.ribbonBar3.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.ribbonBar3.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.rbReport_Product,
            this.rbReport_Income,
            this.rbSetup_ProductDecrease});
            this.ribbonBar3.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar3.Name = "ribbonBar3";
            this.ribbonBar3.Size = new System.Drawing.Size(271, 88);
            this.ribbonBar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar3.TabIndex = 0;
            this.ribbonBar3.Text = "Reports";
            // 
            // 
            // 
            this.ribbonBar3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar3.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // rbReport_Product
            // 
            this.rbReport_Product.Image = ((System.Drawing.Image)(resources.GetObject("rbReport_Product.Image")));
            this.rbReport_Product.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.rbReport_Product.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.rbReport_Product.Name = "rbReport_Product";
            this.rbReport_Product.SubItemsExpandWidth = 14;
            this.rbReport_Product.Text = "รายงานสินค้า";
            this.rbReport_Product.Click += new System.EventHandler(this.rbReport_Product_Click);
            // 
            // rbReport_Income
            // 
            this.rbReport_Income.Image = ((System.Drawing.Image)(resources.GetObject("rbReport_Income.Image")));
            this.rbReport_Income.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.rbReport_Income.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.rbReport_Income.Name = "rbReport_Income";
            this.rbReport_Income.SubItemsExpandWidth = 14;
            this.rbReport_Income.Text = "รายงานสรุปรายได้";
            this.rbReport_Income.Click += new System.EventHandler(this.rbReport_Income_Click);
            // 
            // rbSetup_ProductDecrease
            // 
            this.rbSetup_ProductDecrease.Image = ((System.Drawing.Image)(resources.GetObject("rbSetup_ProductDecrease.Image")));
            this.rbSetup_ProductDecrease.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.rbSetup_ProductDecrease.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.rbSetup_ProductDecrease.Name = "rbSetup_ProductDecrease";
            this.rbSetup_ProductDecrease.SubItemsExpandWidth = 14;
            this.rbSetup_ProductDecrease.Text = "สินค้าถึงจุดสั่งซื้อ";
            this.rbSetup_ProductDecrease.Click += new System.EventHandler(this.rbSetup_ProductDecrease_Click);
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel4.Controls.Add(this.ribbonBar5);
            this.ribbonPanel4.Controls.Add(this.ribbonBar4);
            this.ribbonPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel4.Location = new System.Drawing.Point(0, 53);
            this.ribbonPanel4.Name = "ribbonPanel4";
            this.ribbonPanel4.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel4.Size = new System.Drawing.Size(767, 91);
            // 
            // 
            // 
            this.ribbonPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel4.TabIndex = 4;
            this.ribbonPanel4.Visible = false;
            // 
            // ribbonBar5
            // 
            this.ribbonBar5.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar5.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar5.ContainerControlProcessDialogKey = true;
            this.ribbonBar5.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar5.DragDropSupport = true;
            this.ribbonBar5.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.ribbonBar5.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.rbSetup_SetCompany,
            this.rbSetup_SetProductType,
            this.rbSetup_SetUnit,
            this.rbSetup_SetStartUp});
            this.ribbonBar5.Location = new System.Drawing.Point(225, 0);
            this.ribbonBar5.Name = "ribbonBar5";
            this.ribbonBar5.Size = new System.Drawing.Size(308, 88);
            this.ribbonBar5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar5.TabIndex = 1;
            this.ribbonBar5.Text = "Setup";
            // 
            // 
            // 
            this.ribbonBar5.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar5.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // rbSetup_SetCompany
            // 
            this.rbSetup_SetCompany.Image = ((System.Drawing.Image)(resources.GetObject("rbSetup_SetCompany.Image")));
            this.rbSetup_SetCompany.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.rbSetup_SetCompany.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.rbSetup_SetCompany.Name = "rbSetup_SetCompany";
            this.rbSetup_SetCompany.SubItemsExpandWidth = 14;
            this.rbSetup_SetCompany.Text = "ข้อมูลผู้จำหน่าย";
            this.rbSetup_SetCompany.Click += new System.EventHandler(this.rbSetup_SetCompany_Click);
            // 
            // rbSetup_SetProductType
            // 
            this.rbSetup_SetProductType.Image = ((System.Drawing.Image)(resources.GetObject("rbSetup_SetProductType.Image")));
            this.rbSetup_SetProductType.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.rbSetup_SetProductType.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.rbSetup_SetProductType.Name = "rbSetup_SetProductType";
            this.rbSetup_SetProductType.SubItemsExpandWidth = 14;
            this.rbSetup_SetProductType.Text = "ประเภทสินค้า";
            this.rbSetup_SetProductType.Click += new System.EventHandler(this.rbSetup_SetProductType_Click);
            // 
            // rbSetup_SetUnit
            // 
            this.rbSetup_SetUnit.Image = ((System.Drawing.Image)(resources.GetObject("rbSetup_SetUnit.Image")));
            this.rbSetup_SetUnit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.rbSetup_SetUnit.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.rbSetup_SetUnit.Name = "rbSetup_SetUnit";
            this.rbSetup_SetUnit.SubItemsExpandWidth = 14;
            this.rbSetup_SetUnit.Text = "หน่วยนับ";
            this.rbSetup_SetUnit.Click += new System.EventHandler(this.rbSetup_SetUnit_Click);
            // 
            // rbSetup_SetStartUp
            // 
            this.rbSetup_SetStartUp.Image = ((System.Drawing.Image)(resources.GetObject("rbSetup_SetStartUp.Image")));
            this.rbSetup_SetStartUp.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.rbSetup_SetStartUp.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.rbSetup_SetStartUp.Name = "rbSetup_SetStartUp";
            this.rbSetup_SetStartUp.SubItemsExpandWidth = 14;
            this.rbSetup_SetStartUp.Text = "ข้อมูลหน่วยงาน";
            this.rbSetup_SetStartUp.Click += new System.EventHandler(this.rbSetup_StartUp_Click);
            // 
            // ribbonBar4
            // 
            this.ribbonBar4.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar4.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar4.ContainerControlProcessDialogKey = true;
            this.ribbonBar4.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar4.DragDropSupport = true;
            this.ribbonBar4.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.ribbonBar4.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.rbSetup_SetTitle,
            this.rbSetup_SetPosition,
            this.rbSetup_SetUser});
            this.ribbonBar4.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar4.Name = "ribbonBar4";
            this.ribbonBar4.Size = new System.Drawing.Size(222, 88);
            this.ribbonBar4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar4.TabIndex = 0;
            this.ribbonBar4.Text = "User Account";
            // 
            // 
            // 
            this.ribbonBar4.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar4.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // rbSetup_SetTitle
            // 
            this.rbSetup_SetTitle.Image = ((System.Drawing.Image)(resources.GetObject("rbSetup_SetTitle.Image")));
            this.rbSetup_SetTitle.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.rbSetup_SetTitle.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.rbSetup_SetTitle.Name = "rbSetup_SetTitle";
            this.rbSetup_SetTitle.SubItemsExpandWidth = 14;
            this.rbSetup_SetTitle.Text = "คำนำหน้าชื่อ";
            this.rbSetup_SetTitle.Click += new System.EventHandler(this.rbSetup_SetTitle_Click);
            // 
            // rbSetup_SetPosition
            // 
            this.rbSetup_SetPosition.Image = ((System.Drawing.Image)(resources.GetObject("rbSetup_SetPosition.Image")));
            this.rbSetup_SetPosition.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.rbSetup_SetPosition.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.rbSetup_SetPosition.Name = "rbSetup_SetPosition";
            this.rbSetup_SetPosition.SubItemsExpandWidth = 14;
            this.rbSetup_SetPosition.Text = "ตำแหน่ง";
            this.rbSetup_SetPosition.Click += new System.EventHandler(this.rbSetup_SetPosition_Click);
            // 
            // rbSetup_SetUser
            // 
            this.rbSetup_SetUser.Image = ((System.Drawing.Image)(resources.GetObject("rbSetup_SetUser.Image")));
            this.rbSetup_SetUser.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.rbSetup_SetUser.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.rbSetup_SetUser.Name = "rbSetup_SetUser";
            this.rbSetup_SetUser.SubItemsExpandWidth = 14;
            this.rbSetup_SetUser.Text = "กำหนดผู้ใช้งาน";
            this.rbSetup_SetUser.Click += new System.EventHandler(this.rbSetup_SetUser_Click);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel2.Controls.Add(this.ribbonBar2);
            this.ribbonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel2.Location = new System.Drawing.Point(0, 53);
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel2.Size = new System.Drawing.Size(767, 91);
            // 
            // 
            // 
            this.ribbonPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel2.TabIndex = 2;
            this.ribbonPanel2.Visible = false;
            // 
            // ribbonBar2
            // 
            this.ribbonBar2.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar2.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar2.ContainerControlProcessDialogKey = true;
            this.ribbonBar2.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar2.DragDropSupport = true;
            this.ribbonBar2.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.ribbonBar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.rbPOS_Sales,
            this.rbPOS_SearchProduct});
            this.ribbonBar2.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar2.Name = "ribbonBar2";
            this.ribbonBar2.Size = new System.Drawing.Size(147, 88);
            this.ribbonBar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar2.TabIndex = 0;
            this.ribbonBar2.Text = "Point of Sales";
            // 
            // 
            // 
            this.ribbonBar2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar2.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // rbPOS_Sales
            // 
            this.rbPOS_Sales.Image = ((System.Drawing.Image)(resources.GetObject("rbPOS_Sales.Image")));
            this.rbPOS_Sales.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.rbPOS_Sales.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.rbPOS_Sales.Name = "rbPOS_Sales";
            this.rbPOS_Sales.SubItemsExpandWidth = 14;
            this.rbPOS_Sales.Text = "ขายสินค้า";
            this.rbPOS_Sales.Click += new System.EventHandler(this.rbPOS_Sales_Click);
            // 
            // rbPOS_SearchProduct
            // 
            this.rbPOS_SearchProduct.Image = ((System.Drawing.Image)(resources.GetObject("rbPOS_SearchProduct.Image")));
            this.rbPOS_SearchProduct.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.rbPOS_SearchProduct.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.rbPOS_SearchProduct.Name = "rbPOS_SearchProduct";
            this.rbPOS_SearchProduct.SubItemsExpandWidth = 14;
            this.rbPOS_SearchProduct.Text = "ค้นหาสินค้า";
            this.rbPOS_SearchProduct.Click += new System.EventHandler(this.rbPOS_SearchProduct_Click);
            // 
            // ribbonPanel6
            // 
            this.ribbonPanel6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel6.Controls.Add(this.ribbonBar6);
            this.ribbonPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel6.Location = new System.Drawing.Point(0, 53);
            this.ribbonPanel6.Name = "ribbonPanel6";
            this.ribbonPanel6.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel6.Size = new System.Drawing.Size(767, 91);
            // 
            // 
            // 
            this.ribbonPanel6.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel6.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel6.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel6.TabIndex = 6;
            this.ribbonPanel6.Visible = false;
            // 
            // ribbonBar6
            // 
            this.ribbonBar6.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar6.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar6.ContainerControlProcessDialogKey = true;
            this.ribbonBar6.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar6.DragDropSupport = true;
            this.ribbonBar6.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.ribbonBar6.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.rbOrdRec_Order,
            this.rbOrdRec_Receive});
            this.ribbonBar6.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar6.Name = "ribbonBar6";
            this.ribbonBar6.Size = new System.Drawing.Size(150, 88);
            this.ribbonBar6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar6.TabIndex = 0;
            this.ribbonBar6.Text = "Order and Receive";
            // 
            // 
            // 
            this.ribbonBar6.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar6.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // rbOrdRec_Order
            // 
            this.rbOrdRec_Order.Image = ((System.Drawing.Image)(resources.GetObject("rbOrdRec_Order.Image")));
            this.rbOrdRec_Order.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.rbOrdRec_Order.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.rbOrdRec_Order.Name = "rbOrdRec_Order";
            this.rbOrdRec_Order.SubItemsExpandWidth = 14;
            this.rbOrdRec_Order.Text = "สั่งซื้อสินค้า";
            this.rbOrdRec_Order.Click += new System.EventHandler(this.rbOrdRec_Order_Click);
            // 
            // rbOrdRec_Receive
            // 
            this.rbOrdRec_Receive.Image = ((System.Drawing.Image)(resources.GetObject("rbOrdRec_Receive.Image")));
            this.rbOrdRec_Receive.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.rbOrdRec_Receive.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.rbOrdRec_Receive.Name = "rbOrdRec_Receive";
            this.rbOrdRec_Receive.SubItemsExpandWidth = 14;
            this.rbOrdRec_Receive.Text = "รับเข้าสินค้า";
            this.rbOrdRec_Receive.Click += new System.EventHandler(this.rbOrdRec_Receive_Click);
            // 
            // rbFiles
            // 
            this.rbFiles.Checked = true;
            this.rbFiles.Name = "rbFiles";
            this.rbFiles.Panel = this.ribbonPanel1;
            this.rbFiles.Text = "แฟ้มข้อมูล";
            // 
            // rbPOS
            // 
            this.rbPOS.Name = "rbPOS";
            this.rbPOS.Panel = this.ribbonPanel2;
            this.rbPOS.Text = "ขายสินค้า";
            // 
            // rbOrdRec
            // 
            this.rbOrdRec.Name = "rbOrdRec";
            this.rbOrdRec.Panel = this.ribbonPanel6;
            this.rbOrdRec.Text = "สั่งซื้อสินค้า/รับเข้าสินค้า";
            // 
            // rbReport
            // 
            this.rbReport.Name = "rbReport";
            this.rbReport.Panel = this.ribbonPanel3;
            this.rbReport.Text = "รายงาน";
            // 
            // rbSetup
            // 
            this.rbSetup.Name = "rbSetup";
            this.rbSetup.Panel = this.ribbonPanel4;
            this.rbSetup.Text = "ตั้งค่าเริ่มต้น";
            // 
            // rbAbout
            // 
            this.rbAbout.Name = "rbAbout";
            this.rbAbout.Panel = this.ribbonPanel5;
            this.rbAbout.Text = "เกี่ยวกับเรา";
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "BiT BiS BA MJU";
            // 
            // qatCustomizeItem1
            // 
            this.qatCustomizeItem1.Name = "qatCustomizeItem1";
            // 
            // styleManager2
            // 
            this.styleManager2.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            this.styleManager2.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // buttonItem4
            // 
            this.buttonItem4.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem4.Image")));
            this.buttonItem4.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem4.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.buttonItem4.Name = "buttonItem4";
            this.buttonItem4.SubItemsExpandWidth = 14;
            this.buttonItem4.Text = "คำนำหน้าชื่อ";
            // 
            // buttonItem5
            // 
            this.buttonItem5.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem5.Image")));
            this.buttonItem5.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem5.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.buttonItem5.Name = "buttonItem5";
            this.buttonItem5.SubItemsExpandWidth = 14;
            this.buttonItem5.Text = "คำนำหน้าชื่อ";
            // 
            // buttonItem6
            // 
            this.buttonItem6.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem6.Image")));
            this.buttonItem6.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem6.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.buttonItem6.Name = "buttonItem6";
            this.buttonItem6.SubItemsExpandWidth = 14;
            this.buttonItem6.Text = "คำนำหน้าชื่อ";
            // 
            // buttonItem7
            // 
            this.buttonItem7.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem7.Image")));
            this.buttonItem7.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem7.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.buttonItem7.Name = "buttonItem7";
            this.buttonItem7.SubItemsExpandWidth = 14;
            this.buttonItem7.Text = "คำนำหน้าชื่อ";
            // 
            // buttonItem9
            // 
            this.buttonItem9.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem9.Image")));
            this.buttonItem9.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem9.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.buttonItem9.Name = "buttonItem9";
            this.buttonItem9.SubItemsExpandWidth = 14;
            this.buttonItem9.Text = "คำนำหน้าชื่อ";
            // 
            // crvRep
            // 
            this.crvRep.ActiveViewIndex = -1;
            this.crvRep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvRep.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvRep.Location = new System.Drawing.Point(308, 201);
            this.crvRep.Name = "crvRep";
            this.crvRep.Size = new System.Drawing.Size(210, 112);
            this.crvRep.TabIndex = 150;
            this.crvRep.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crvRep.Visible = false;
            this.crvRep.DoubleClick += new System.EventHandler(this.crvRep_DoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsFullName});
            this.statusStrip1.Location = new System.Drawing.Point(0, 427);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(767, 22);
            this.statusStrip1.TabIndex = 152;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblUsFullName
            // 
            this.lblUsFullName.Name = "lblUsFullName";
            this.lblUsFullName.Size = new System.Drawing.Size(84, 17);
            this.lblUsFullName.Text = "lblUsFullName";
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(767, 449);
            this.ControlBox = false;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.crvRep);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ระบบบริหารงานร้านขายปลีก - Smart BA-POS [สำหรับประกอบการเรียน การสอนรายวิชา สธ 31" +
    "7]";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.frmMainMenu_Activated);
            this.Load += new System.EventHandler(this.frmMainMenu_Load);
            this.ribbonControl1.ResumeLayout(false);
            this.ribbonControl1.PerformLayout();
            this.ribbonPanel1.ResumeLayout(false);
            this.ribbonPanel5.ResumeLayout(false);
            this.ribbonPanel3.ResumeLayout(false);
            this.ribbonPanel4.ResumeLayout(false);
            this.ribbonPanel2.ResumeLayout(false);
            this.ribbonPanel6.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.RibbonControl ribbonControl1;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel2;
        private DevComponents.DotNetBar.RibbonTabItem rbFiles;
        private DevComponents.DotNetBar.RibbonTabItem rbPOS;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.QatCustomizeItem qatCustomizeItem1;
        private DevComponents.DotNetBar.StyleManager styleManager2;
        private DevComponents.DotNetBar.ButtonItem rbFiles_Product;
        private DevComponents.DotNetBar.ButtonItem rbFiles_POS;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel4;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel5;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel3;
        private DevComponents.DotNetBar.RibbonTabItem rbReport;
        private DevComponents.DotNetBar.RibbonTabItem rbSetup;
        private DevComponents.DotNetBar.RibbonTabItem rbAbout;
        private DevComponents.DotNetBar.ButtonItem rbFiles_Exit;
        private DevComponents.DotNetBar.RibbonBar ribbonBar2;
        private DevComponents.DotNetBar.ButtonItem rbPOS_Sales;
        private DevComponents.DotNetBar.ButtonItem rbPOS_SearchProduct;
        private DevComponents.DotNetBar.RibbonBar ribbonBar3;
        private DevComponents.DotNetBar.RibbonBar ribbonBar5;
        private DevComponents.DotNetBar.ButtonItem rbSetup_SetStartUp;
        private DevComponents.DotNetBar.ButtonItem rbSetup_SetProductType;
        private DevComponents.DotNetBar.ButtonItem rbSetup_SetUnit;
        private DevComponents.DotNetBar.ButtonItem rbSetup_SetCompany;
        private DevComponents.DotNetBar.RibbonBar ribbonBar4;
        private DevComponents.DotNetBar.ButtonItem rbSetup_SetTitle;
        private DevComponents.DotNetBar.ButtonItem rbSetup_SetPosition;
        private DevComponents.DotNetBar.ButtonItem rbSetup_SetUser;
        private DevComponents.DotNetBar.ButtonItem buttonItem4;
        private DevComponents.DotNetBar.ButtonItem buttonItem5;
        private DevComponents.DotNetBar.ButtonItem buttonItem6;
        private DevComponents.DotNetBar.ButtonItem buttonItem7;
        private DevComponents.DotNetBar.ButtonItem buttonItem9;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel6;
        private DevComponents.DotNetBar.RibbonBar ribbonBar6;
        private DevComponents.DotNetBar.ButtonItem rbOrdRec_Order;
        private DevComponents.DotNetBar.ButtonItem rbOrdRec_Receive;
        private DevComponents.DotNetBar.RibbonTabItem rbOrdRec;
        private DevComponents.DotNetBar.ButtonItem rbReport_Product;
        private DevComponents.DotNetBar.ButtonItem rbReport_Income;
        private DevComponents.DotNetBar.ButtonItem rbSetup_ProductDecrease;
        private DevComponents.DotNetBar.RibbonBar ribbonBar7;
        private DevComponents.DotNetBar.ButtonItem rbAbout_Me;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvRep;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblUsFullName;

    }
}