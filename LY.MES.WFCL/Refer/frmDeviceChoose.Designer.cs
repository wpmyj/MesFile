namespace LY.MES.WFCL.Refer
{
    partial class frmDeviceChoose
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
            Client.Utility.Controls.Paging paging1 = new Client.Utility.Controls.Paging();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbtniEnsure = new DevExpress.XtraBars.BarButtonItem();
            this.bbtniExit = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.deviceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BGW2 = new System.ComponentModel.BackgroundWorker();
            this.colAdminPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdminPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCallID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatePerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevCCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevImageUrl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevQRUrl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeviceId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFContactsTel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFactoryContacts = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFactoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIPUrl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocalAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrigin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSerialPort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUseStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.tvDevice = new System.Windows.Forms.TreeView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.gridViewPaging1 = new Client.Utility.Controls.GridViewPaging();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAdminPerson1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdminPhone1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCallID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateDate1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatePerson1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevCCode1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevCategory1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevCode1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevImageUrl1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevQRUrl1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevStd1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeviceId1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFContactsTel1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFactoryContacts1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFactoryName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIPUrl1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastDate1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastPerson1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocalAddress1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrigin1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPort1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSerialPort1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUseStatus1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SeekSimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.DevCCodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.搜索条件 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.DevCodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.DevNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DevCCodeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.搜索条件)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DevCodeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DevNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbtniEnsure,
            this.bbtniExit});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 2;
            this.barManager1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barManager1_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtniEnsure),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtniExit)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bbtniEnsure
            // 
            this.bbtniEnsure.Caption = "确定";
            this.bbtniEnsure.Id = 0;
            this.bbtniEnsure.Name = "bbtniEnsure";
            // 
            // bbtniExit
            // 
            this.bbtniExit.Caption = "退出";
            this.bbtniExit.Id = 1;
            this.bbtniExit.Name = "bbtniExit";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1092, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 551);
            this.barDockControlBottom.Size = new System.Drawing.Size(1092, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 527);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1092, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 527);
            // 
            // deviceBindingSource
            // 
            this.deviceBindingSource.DataSource = typeof(LY.MES.WFCL.SRDevice.Device);
            // 
            // BGW2
            // 
            this.BGW2.WorkerReportsProgress = true;
            this.BGW2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGW2_DoWork);
            this.BGW2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGW2_RunWorkerCompleted);
            // 
            // colAdminPerson
            // 
            this.colAdminPerson.Caption = "管理人";
            this.colAdminPerson.FieldName = "AdminPerson";
            this.colAdminPerson.Name = "colAdminPerson";
            this.colAdminPerson.Visible = true;
            this.colAdminPerson.VisibleIndex = 8;
            this.colAdminPerson.Width = 52;
            // 
            // colAdminPhone
            // 
            this.colAdminPhone.Caption = "管理人联系电话";
            this.colAdminPhone.FieldName = "AdminPhone";
            this.colAdminPhone.Name = "colAdminPhone";
            this.colAdminPhone.Visible = true;
            this.colAdminPhone.VisibleIndex = 9;
            this.colAdminPhone.Width = 101;
            // 
            // colCallID
            // 
            this.colCallID.Caption = "访问ID";
            this.colCallID.FieldName = "CallID";
            this.colCallID.Name = "colCallID";
            this.colCallID.Width = 61;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Caption = "创建时间";
            this.colCreateDate.FieldName = "CreateDate";
            this.colCreateDate.Name = "colCreateDate";
            this.colCreateDate.Visible = true;
            this.colCreateDate.VisibleIndex = 11;
            this.colCreateDate.Width = 66;
            // 
            // colCreatePerson
            // 
            this.colCreatePerson.Caption = "创建人";
            this.colCreatePerson.FieldName = "CreatePerson";
            this.colCreatePerson.Name = "colCreatePerson";
            this.colCreatePerson.Visible = true;
            this.colCreatePerson.VisibleIndex = 10;
            this.colCreatePerson.Width = 51;
            // 
            // colDevCCode
            // 
            this.colDevCCode.Caption = "设备分类";
            this.colDevCCode.FieldName = "DevCCode";
            this.colDevCCode.Name = "colDevCCode";
            this.colDevCCode.Visible = true;
            this.colDevCCode.VisibleIndex = 2;
            this.colDevCCode.Width = 73;
            // 
            // colDevCategory
            // 
            this.colDevCategory.Caption = "设备类别";
            this.colDevCategory.FieldName = "DevCategory";
            this.colDevCategory.Name = "colDevCategory";
            this.colDevCategory.Width = 53;
            // 
            // colDevCode
            // 
            this.colDevCode.Caption = "设备编码";
            this.colDevCode.FieldName = "DevCode";
            this.colDevCode.Name = "colDevCode";
            this.colDevCode.Visible = true;
            this.colDevCode.VisibleIndex = 0;
            this.colDevCode.Width = 62;
            // 
            // colDevImageUrl
            // 
            this.colDevImageUrl.Caption = "设备图片";
            this.colDevImageUrl.FieldName = "DevImageUrl";
            this.colDevImageUrl.Name = "colDevImageUrl";
            this.colDevImageUrl.Width = 20;
            // 
            // colDevName
            // 
            this.colDevName.Caption = "设备名称";
            this.colDevName.FieldName = "DevName";
            this.colDevName.Name = "colDevName";
            this.colDevName.Visible = true;
            this.colDevName.VisibleIndex = 1;
            this.colDevName.Width = 66;
            // 
            // colDevQRUrl
            // 
            this.colDevQRUrl.Caption = "设备二维码";
            this.colDevQRUrl.FieldName = "DevQRUrl";
            this.colDevQRUrl.Name = "colDevQRUrl";
            this.colDevQRUrl.Width = 107;
            // 
            // colDevStd
            // 
            this.colDevStd.Caption = "设备规格";
            this.colDevStd.FieldName = "DevStd";
            this.colDevStd.Name = "colDevStd";
            this.colDevStd.Visible = true;
            this.colDevStd.VisibleIndex = 3;
            this.colDevStd.Width = 64;
            // 
            // colDeviceId
            // 
            this.colDeviceId.Caption = "设备Id";
            this.colDeviceId.FieldName = "DeviceId";
            this.colDeviceId.Name = "colDeviceId";
            this.colDeviceId.Width = 77;
            // 
            // colFContactsTel
            // 
            this.colFContactsTel.Caption = "厂家联系电话";
            this.colFContactsTel.FieldName = "FContactsTel";
            this.colFContactsTel.Name = "colFContactsTel";
            this.colFContactsTel.Width = 43;
            // 
            // colFactoryContacts
            // 
            this.colFactoryContacts.Caption = "厂家联系人";
            this.colFactoryContacts.FieldName = "FactoryContacts";
            this.colFactoryContacts.Name = "colFactoryContacts";
            this.colFactoryContacts.Width = 63;
            // 
            // colFactoryName
            // 
            this.colFactoryName.Caption = "厂家名称";
            this.colFactoryName.FieldName = "FactoryName";
            this.colFactoryName.Name = "colFactoryName";
            this.colFactoryName.Visible = true;
            this.colFactoryName.VisibleIndex = 4;
            this.colFactoryName.Width = 62;
            // 
            // colIPUrl
            // 
            this.colIPUrl.Caption = "IP地址";
            this.colIPUrl.FieldName = "IPUrl";
            this.colIPUrl.Name = "colIPUrl";
            this.colIPUrl.Width = 20;
            // 
            // colLastDate
            // 
            this.colLastDate.Caption = "最后修改时间";
            this.colLastDate.FieldName = "LastDate";
            this.colLastDate.Name = "colLastDate";
            this.colLastDate.Width = 20;
            // 
            // colLastPerson
            // 
            this.colLastPerson.Caption = "最后修改人";
            this.colLastPerson.FieldName = "LastPerson";
            this.colLastPerson.Name = "colLastPerson";
            this.colLastPerson.Width = 20;
            // 
            // colLocalAddress
            // 
            this.colLocalAddress.Caption = "放置区域";
            this.colLocalAddress.FieldName = "LocalAddress";
            this.colLocalAddress.Name = "colLocalAddress";
            this.colLocalAddress.Visible = true;
            this.colLocalAddress.VisibleIndex = 6;
            this.colLocalAddress.Width = 60;
            // 
            // colOrigin
            // 
            this.colOrigin.Caption = "产地";
            this.colOrigin.FieldName = "Origin";
            this.colOrigin.Name = "colOrigin";
            this.colOrigin.Visible = true;
            this.colOrigin.VisibleIndex = 5;
            this.colOrigin.Width = 53;
            // 
            // colPort
            // 
            this.colPort.Caption = "端口";
            this.colPort.FieldName = "Port";
            this.colPort.Name = "colPort";
            this.colPort.Width = 20;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 12;
            this.colRemark.Width = 50;
            // 
            // colSerialPort
            // 
            this.colSerialPort.Caption = "串口号";
            this.colSerialPort.FieldName = "SerialPort";
            this.colSerialPort.Name = "colSerialPort";
            this.colSerialPort.Width = 20;
            // 
            // colUseStatus
            // 
            this.colUseStatus.Caption = "设备状态";
            this.colUseStatus.FieldName = "UseStatus";
            this.colUseStatus.Name = "colUseStatus";
            this.colUseStatus.Visible = true;
            this.colUseStatus.VisibleIndex = 7;
            this.colUseStatus.Width = 56;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.layoutControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.layoutControl2);
            this.splitContainer1.Size = new System.Drawing.Size(1092, 527);
            this.splitContainer1.SplitterDistance = 257;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 14;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.tvDevice);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(257, 527);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // tvDevice
            // 
            this.tvDevice.Location = new System.Drawing.Point(24, 44);
            this.tvDevice.Name = "tvDevice";
            this.tvDevice.Size = new System.Drawing.Size(209, 459);
            this.tvDevice.TabIndex = 4;
            this.tvDevice.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(257, 527);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(237, 507);
            this.layoutControlGroup2.Text = "设备分类";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.tvDevice;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(213, 463);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.DevNameTextEdit);
            this.layoutControl2.Controls.Add(this.DevCodeTextEdit);
            this.layoutControl2.Controls.Add(this.gridViewPaging1);
            this.layoutControl2.Controls.Add(this.gridControl1);
            this.layoutControl2.Controls.Add(this.SeekSimpleButton);
            this.layoutControl2.Controls.Add(this.DevCCodeTextEdit);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(0, 0);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup3;
            this.layoutControl2.Size = new System.Drawing.Size(830, 527);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // gridViewPaging1
            // 
            paging1.CurrentPage = ((long)(1));
            paging1.IsPaging = true;
            paging1.PageSize = ((long)(20));
            paging1.RowCount = ((long)(0));
            this.gridViewPaging1.DataPaging = paging1;
            this.gridViewPaging1.Location = new System.Drawing.Point(24, 475);
            this.gridViewPaging1.Name = "gridViewPaging1";
            this.gridViewPaging1.Size = new System.Drawing.Size(782, 28);
            this.gridViewPaging1.TabIndex = 7;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.deviceBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(24, 114);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(782, 357);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAdminPerson1,
            this.colAdminPhone1,
            this.colCallID1,
            this.colCreateDate1,
            this.colCreatePerson1,
            this.colDevCCode1,
            this.colDevCategory1,
            this.colDevCode1,
            this.colDevImageUrl1,
            this.colDevName1,
            this.colDevQRUrl1,
            this.colDevStd1,
            this.colDeviceId1,
            this.colFContactsTel1,
            this.colFactoryContacts1,
            this.colFactoryName1,
            this.colIPUrl1,
            this.colLastDate1,
            this.colLastPerson1,
            this.colLocalAddress1,
            this.colOrigin1,
            this.colPort1,
            this.colRemark1,
            this.colSerialPort1,
            this.colUseStatus1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colAdminPerson1
            // 
            this.colAdminPerson1.Caption = "管理人员";
            this.colAdminPerson1.FieldName = "AdminPerson";
            this.colAdminPerson1.Name = "colAdminPerson1";
            this.colAdminPerson1.Visible = true;
            this.colAdminPerson1.VisibleIndex = 8;
            this.colAdminPerson1.Width = 67;
            // 
            // colAdminPhone1
            // 
            this.colAdminPhone1.Caption = "管理联系电话";
            this.colAdminPhone1.FieldName = "AdminPhone";
            this.colAdminPhone1.Name = "colAdminPhone1";
            this.colAdminPhone1.Visible = true;
            this.colAdminPhone1.VisibleIndex = 9;
            this.colAdminPhone1.Width = 51;
            // 
            // colCallID1
            // 
            this.colCallID1.Caption = "访问ID";
            this.colCallID1.FieldName = "CallID";
            this.colCallID1.Name = "colCallID1";
            this.colCallID1.Width = 24;
            // 
            // colCreateDate1
            // 
            this.colCreateDate1.Caption = "创建时间";
            this.colCreateDate1.FieldName = "CreateDate";
            this.colCreateDate1.Name = "colCreateDate1";
            this.colCreateDate1.Visible = true;
            this.colCreateDate1.VisibleIndex = 11;
            this.colCreateDate1.Width = 49;
            // 
            // colCreatePerson1
            // 
            this.colCreatePerson1.Caption = "创建人";
            this.colCreatePerson1.FieldName = "CreatePerson";
            this.colCreatePerson1.Name = "colCreatePerson1";
            this.colCreatePerson1.Visible = true;
            this.colCreatePerson1.VisibleIndex = 10;
            this.colCreatePerson1.Width = 50;
            // 
            // colDevCCode1
            // 
            this.colDevCCode1.Caption = "设备分类编码";
            this.colDevCCode1.FieldName = "DevCCode";
            this.colDevCCode1.Name = "colDevCCode1";
            this.colDevCCode1.Visible = true;
            this.colDevCCode1.VisibleIndex = 3;
            this.colDevCCode1.Width = 156;
            // 
            // colDevCategory1
            // 
            this.colDevCategory1.Caption = "设备分类";
            this.colDevCategory1.FieldName = "DevCategory";
            this.colDevCategory1.Name = "colDevCategory1";
            this.colDevCategory1.Width = 73;
            // 
            // colDevCode1
            // 
            this.colDevCode1.Caption = "设备编码";
            this.colDevCode1.FieldName = "DevCode";
            this.colDevCode1.Name = "colDevCode1";
            this.colDevCode1.Visible = true;
            this.colDevCode1.VisibleIndex = 0;
            this.colDevCode1.Width = 102;
            // 
            // colDevImageUrl1
            // 
            this.colDevImageUrl1.Caption = "设备图片地址";
            this.colDevImageUrl1.FieldName = "DevImageUrl";
            this.colDevImageUrl1.Name = "colDevImageUrl1";
            this.colDevImageUrl1.Width = 20;
            // 
            // colDevName1
            // 
            this.colDevName1.Caption = "设备名称";
            this.colDevName1.FieldName = "DevName";
            this.colDevName1.Name = "colDevName1";
            this.colDevName1.Visible = true;
            this.colDevName1.VisibleIndex = 1;
            this.colDevName1.Width = 110;
            // 
            // colDevQRUrl1
            // 
            this.colDevQRUrl1.Caption = "设备二维码地址";
            this.colDevQRUrl1.FieldName = "DevQRUrl";
            this.colDevQRUrl1.Name = "colDevQRUrl1";
            this.colDevQRUrl1.Width = 20;
            // 
            // colDevStd1
            // 
            this.colDevStd1.Caption = "设备规格";
            this.colDevStd1.FieldName = "DevStd";
            this.colDevStd1.Name = "colDevStd1";
            this.colDevStd1.Visible = true;
            this.colDevStd1.VisibleIndex = 2;
            this.colDevStd1.Width = 125;
            // 
            // colDeviceId1
            // 
            this.colDeviceId1.Caption = "设备ID";
            this.colDeviceId1.FieldName = "DeviceId";
            this.colDeviceId1.Name = "colDeviceId1";
            this.colDeviceId1.Width = 20;
            // 
            // colFContactsTel1
            // 
            this.colFContactsTel1.Caption = "厂家联系电话";
            this.colFContactsTel1.FieldName = "FContactsTel";
            this.colFContactsTel1.Name = "colFContactsTel1";
            this.colFContactsTel1.Width = 81;
            // 
            // colFactoryContacts1
            // 
            this.colFactoryContacts1.Caption = "厂家联系人";
            this.colFactoryContacts1.FieldName = "FactoryContacts";
            this.colFactoryContacts1.Name = "colFactoryContacts1";
            this.colFactoryContacts1.Visible = true;
            this.colFactoryContacts1.VisibleIndex = 6;
            this.colFactoryContacts1.Width = 66;
            // 
            // colFactoryName1
            // 
            this.colFactoryName1.Caption = "厂家名称";
            this.colFactoryName1.FieldName = "FactoryName";
            this.colFactoryName1.Name = "colFactoryName1";
            this.colFactoryName1.Visible = true;
            this.colFactoryName1.VisibleIndex = 5;
            this.colFactoryName1.Width = 57;
            // 
            // colIPUrl1
            // 
            this.colIPUrl1.Caption = "IP地址";
            this.colIPUrl1.FieldName = "IPUrl";
            this.colIPUrl1.Name = "colIPUrl1";
            this.colIPUrl1.Width = 20;
            // 
            // colLastDate1
            // 
            this.colLastDate1.Caption = "最后修改时间";
            this.colLastDate1.FieldName = "LastDate";
            this.colLastDate1.Name = "colLastDate1";
            this.colLastDate1.Width = 20;
            // 
            // colLastPerson1
            // 
            this.colLastPerson1.Caption = "最后修改人";
            this.colLastPerson1.FieldName = "LastPerson";
            this.colLastPerson1.Name = "colLastPerson1";
            this.colLastPerson1.Width = 20;
            // 
            // colLocalAddress1
            // 
            this.colLocalAddress1.Caption = "放置区域";
            this.colLocalAddress1.FieldName = "LocalAddress";
            this.colLocalAddress1.Name = "colLocalAddress1";
            this.colLocalAddress1.Visible = true;
            this.colLocalAddress1.VisibleIndex = 7;
            this.colLocalAddress1.Width = 57;
            // 
            // colOrigin1
            // 
            this.colOrigin1.Caption = "设备产地";
            this.colOrigin1.FieldName = "Origin";
            this.colOrigin1.Name = "colOrigin1";
            this.colOrigin1.Width = 20;
            // 
            // colPort1
            // 
            this.colPort1.Caption = "端口";
            this.colPort1.FieldName = "Port";
            this.colPort1.Name = "colPort1";
            this.colPort1.Width = 20;
            // 
            // colRemark1
            // 
            this.colRemark1.Caption = "备注";
            this.colRemark1.FieldName = "Remark";
            this.colRemark1.Name = "colRemark1";
            this.colRemark1.Visible = true;
            this.colRemark1.VisibleIndex = 12;
            this.colRemark1.Width = 41;
            // 
            // colSerialPort1
            // 
            this.colSerialPort1.Caption = "串口号";
            this.colSerialPort1.FieldName = "SerialPort";
            this.colSerialPort1.Name = "colSerialPort1";
            this.colSerialPort1.Width = 20;
            // 
            // colUseStatus1
            // 
            this.colUseStatus1.Caption = "设备状态";
            this.colUseStatus1.FieldName = "UseStatus";
            this.colUseStatus1.Name = "colUseStatus1";
            this.colUseStatus1.Visible = true;
            this.colUseStatus1.VisibleIndex = 4;
            this.colUseStatus1.Width = 62;
            // 
            // SeekSimpleButton
            // 
            this.SeekSimpleButton.Location = new System.Drawing.Point(710, 44);
            this.SeekSimpleButton.Name = "SeekSimpleButton";
            this.SeekSimpleButton.Size = new System.Drawing.Size(96, 22);
            this.SeekSimpleButton.StyleController = this.layoutControl2;
            this.SeekSimpleButton.TabIndex = 5;
            this.SeekSimpleButton.Text = "搜索";
            this.SeekSimpleButton.Click += new System.EventHandler(this.SeekSimpleButton_Click);
            // 
            // DevCCodeTextEdit
            // 
            this.DevCCodeTextEdit.Location = new System.Drawing.Point(99, 44);
            this.DevCCodeTextEdit.MenuManager = this.barManager1;
            this.DevCCodeTextEdit.Name = "DevCCodeTextEdit";
            this.DevCCodeTextEdit.Size = new System.Drawing.Size(163, 20);
            this.DevCCodeTextEdit.StyleController = this.layoutControl2;
            this.DevCCodeTextEdit.TabIndex = 4;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "layoutControlGroup3";
            this.layoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup3.GroupBordersVisible = false;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup4,
            this.layoutControlGroup5});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(830, 527);
            this.layoutControlGroup3.Text = "layoutControlGroup3";
            this.layoutControlGroup3.TextVisible = false;
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.CustomizationFormText = "搜索条件";
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.搜索条件,
            this.layoutControlItem2,
            this.layoutControlItem6});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(810, 70);
            this.layoutControlGroup4.Text = "搜索条件";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.SeekSimpleButton;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(686, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(100, 26);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(100, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(100, 26);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // 搜索条件
            // 
            this.搜索条件.Control = this.DevCCodeTextEdit;
            this.搜索条件.CustomizationFormText = "layoutControlItem2";
            this.搜索条件.Location = new System.Drawing.Point(0, 0);
            this.搜索条件.Name = "搜索条件";
            this.搜索条件.Size = new System.Drawing.Size(242, 26);
            this.搜索条件.Text = "设备分类编码";
            this.搜索条件.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.CustomizationFormText = "档案参数列表";
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup5.Location = new System.Drawing.Point(0, 70);
            this.layoutControlGroup5.Name = "layoutControlGroup5";
            this.layoutControlGroup5.Size = new System.Drawing.Size(810, 437);
            this.layoutControlGroup5.Text = "档案参数列表";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gridControl1;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(786, 361);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.gridViewPaging1;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 361);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(786, 32);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // DevCodeTextEdit
            // 
            this.DevCodeTextEdit.Location = new System.Drawing.Point(319, 44);
            this.DevCodeTextEdit.MenuManager = this.barManager1;
            this.DevCodeTextEdit.Name = "DevCodeTextEdit";
            this.DevCodeTextEdit.Size = new System.Drawing.Size(174, 20);
            this.DevCodeTextEdit.StyleController = this.layoutControl2;
            this.DevCodeTextEdit.TabIndex = 8;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.DevCodeTextEdit;
            this.layoutControlItem2.CustomizationFormText = "设备编码";
            this.layoutControlItem2.Location = new System.Drawing.Point(242, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(231, 26);
            this.layoutControlItem2.Text = "设备编码";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // DevNameTextEdit
            // 
            this.DevNameTextEdit.Location = new System.Drawing.Point(550, 44);
            this.DevNameTextEdit.MenuManager = this.barManager1;
            this.DevNameTextEdit.Name = "DevNameTextEdit";
            this.DevNameTextEdit.Size = new System.Drawing.Size(156, 20);
            this.DevNameTextEdit.StyleController = this.layoutControl2;
            this.DevNameTextEdit.TabIndex = 9;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.DevNameTextEdit;
            this.layoutControlItem6.CustomizationFormText = "设备名称";
            this.layoutControlItem6.Location = new System.Drawing.Point(473, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(213, 26);
            this.layoutControlItem6.Text = "设备名称";
            this.layoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(48, 14);
            this.layoutControlItem6.TextToControlDistance = 5;
            // 
            // frmDeviceChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 551);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDeviceChoose";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设备档案参照";
            this.Load += new System.EventHandler(this.frmDeviceChoose_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceBindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DevCCodeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.搜索条件)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DevCodeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DevNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem bbtniEnsure;
        private DevExpress.XtraBars.BarButtonItem bbtniExit;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.BindingSource deviceBindingSource;
        private System.ComponentModel.BackgroundWorker BGW2;
        private DevExpress.XtraGrid.Columns.GridColumn colAdminPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colAdminPhone;
        private DevExpress.XtraGrid.Columns.GridColumn colCallID;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatePerson;
        private DevExpress.XtraGrid.Columns.GridColumn colDevCCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDevCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colDevCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDevImageUrl;
        private DevExpress.XtraGrid.Columns.GridColumn colDevName;
        private DevExpress.XtraGrid.Columns.GridColumn colDevQRUrl;
        private DevExpress.XtraGrid.Columns.GridColumn colDevStd;
        private DevExpress.XtraGrid.Columns.GridColumn colDeviceId;
        private DevExpress.XtraGrid.Columns.GridColumn colFContactsTel;
        private DevExpress.XtraGrid.Columns.GridColumn colFactoryContacts;
        private DevExpress.XtraGrid.Columns.GridColumn colFactoryName;
        private DevExpress.XtraGrid.Columns.GridColumn colIPUrl;
        private DevExpress.XtraGrid.Columns.GridColumn colLastDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colLocalAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colOrigin;
        private DevExpress.XtraGrid.Columns.GridColumn colPort;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colSerialPort;
        private DevExpress.XtraGrid.Columns.GridColumn colUseStatus;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private System.Windows.Forms.TreeView tvDevice;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private Client.Utility.Controls.GridViewPaging gridViewPaging1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colAdminPerson1;
        private DevExpress.XtraGrid.Columns.GridColumn colAdminPhone1;
        private DevExpress.XtraGrid.Columns.GridColumn colCallID1;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateDate1;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatePerson1;
        private DevExpress.XtraGrid.Columns.GridColumn colDevCCode1;
        private DevExpress.XtraGrid.Columns.GridColumn colDevCategory1;
        private DevExpress.XtraGrid.Columns.GridColumn colDevCode1;
        private DevExpress.XtraGrid.Columns.GridColumn colDevImageUrl1;
        private DevExpress.XtraGrid.Columns.GridColumn colDevName1;
        private DevExpress.XtraGrid.Columns.GridColumn colDevQRUrl1;
        private DevExpress.XtraGrid.Columns.GridColumn colDevStd1;
        private DevExpress.XtraGrid.Columns.GridColumn colDeviceId1;
        private DevExpress.XtraGrid.Columns.GridColumn colFContactsTel1;
        private DevExpress.XtraGrid.Columns.GridColumn colFactoryContacts1;
        private DevExpress.XtraGrid.Columns.GridColumn colFactoryName1;
        private DevExpress.XtraGrid.Columns.GridColumn colIPUrl1;
        private DevExpress.XtraGrid.Columns.GridColumn colLastDate1;
        private DevExpress.XtraGrid.Columns.GridColumn colLastPerson1;
        private DevExpress.XtraGrid.Columns.GridColumn colLocalAddress1;
        private DevExpress.XtraGrid.Columns.GridColumn colOrigin1;
        private DevExpress.XtraGrid.Columns.GridColumn colPort1;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark1;
        private DevExpress.XtraGrid.Columns.GridColumn colSerialPort1;
        private DevExpress.XtraGrid.Columns.GridColumn colUseStatus1;
        private DevExpress.XtraEditors.SimpleButton SeekSimpleButton;
        private DevExpress.XtraEditors.TextEdit DevCCodeTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem 搜索条件;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.TextEdit DevNameTextEdit;
        private DevExpress.XtraEditors.TextEdit DevCodeTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}