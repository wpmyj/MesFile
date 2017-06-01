namespace LY.MES.WFCL.Base.List
{
    partial class frmDevInterfaceList
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
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.deviceInterfaceBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevCode2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeviCode2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeviName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevice1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeviceExecutes1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeviceParameter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevpAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConAccAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevpCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsTwoWay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSendFormat2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserStatus2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bmButton = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbtnAdd1 = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnModify = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnDel = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnExit = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnCheck = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnFind = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnSeek = new DevExpress.XtraBars.BarButtonItem();
            this.dataLayoutControl2 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.ConAccAddress = new DevExpress.XtraEditors.TextEdit();
            this.deviceInterfaceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataTypeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.DevCodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.DeviCodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.DeviNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.DevpAddressTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.SendFormatTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.RemarkTextEdit = new DevExpress.XtraEditors.MemoEdit();
            this.UserStatusEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.DevpCodeTextEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.IsTwoWayTextEdit = new DevExpress.XtraEditors.CheckEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForDevCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDeviCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForRemark = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForUserStatus = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDataType = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDeviName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForIsTwoWay = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDevpCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDevpAddress = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForSendFormat = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridViewPaging1 = new Client.Utility.Controls.GridViewPaging();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.colDeviCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeviName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSendFormat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bgwWait1 = new System.ComponentModel.BackgroundWorker();
            this.colDevCode1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeviCode1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeviName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeviceExecutes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSendFormat1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserStatus1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceInterfaceBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl2)).BeginInit();
            this.dataLayoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConAccAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceInterfaceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTypeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DevCodeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeviCodeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeviNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DevpAddressTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendFormatTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemarkTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserStatusEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DevpCodeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsTwoWayTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDevCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeviCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUserStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDataType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeviName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIsTwoWay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDevpCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDevpAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSendFormat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.gridControl1);
            this.dataLayoutControl1.Controls.Add(this.dataLayoutControl2);
            this.dataLayoutControl1.Controls.Add(this.gridViewPaging1);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 24);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(314, 159, 538, 436);
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(830, 554);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.deviceInterfaceBindingSource1;
            this.gridControl1.Location = new System.Drawing.Point(24, 239);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.bmButton;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(782, 259);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick_1);
            // 
            // deviceInterfaceBindingSource1
            // 
            this.deviceInterfaceBindingSource1.DataSource = typeof(LY.MES.WFCL.SRDevice.DeviceInterface);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDataType,
            this.colDevCode2,
            this.colDeviCode2,
            this.colDeviName2,
            this.colDevice1,
            this.colDeviceExecutes1,
            this.colDeviceParameter,
            this.colDevpAddress,
            this.colConAccAddress,
            this.colDevpCode,
            this.colIsTwoWay,
            this.colRemark2,
            this.colSendFormat2,
            this.colUserStatus2});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "设备接口列表";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView1_CustomColumnDisplayText);
            // 
            // colDataType
            // 
            this.colDataType.Caption = "数据类型";
            this.colDataType.FieldName = "DataType";
            this.colDataType.Name = "colDataType";
            this.colDataType.Visible = true;
            this.colDataType.VisibleIndex = 6;
            this.colDataType.Width = 66;
            // 
            // colDevCode2
            // 
            this.colDevCode2.Caption = "设备编码";
            this.colDevCode2.FieldName = "DevCode";
            this.colDevCode2.Name = "colDevCode2";
            this.colDevCode2.Visible = true;
            this.colDevCode2.VisibleIndex = 0;
            this.colDevCode2.Width = 69;
            // 
            // colDeviCode2
            // 
            this.colDeviCode2.Caption = "接口编码";
            this.colDeviCode2.FieldName = "DeviCode";
            this.colDeviCode2.Name = "colDeviCode2";
            this.colDeviCode2.Visible = true;
            this.colDeviCode2.VisibleIndex = 2;
            this.colDeviCode2.Width = 69;
            // 
            // colDeviName2
            // 
            this.colDeviName2.Caption = "接口名称";
            this.colDeviName2.FieldName = "DeviName";
            this.colDeviName2.Name = "colDeviName2";
            this.colDeviName2.Visible = true;
            this.colDeviName2.VisibleIndex = 3;
            this.colDeviName2.Width = 69;
            // 
            // colDevice1
            // 
            this.colDevice1.FieldName = "Device";
            this.colDevice1.Name = "colDevice1";
            // 
            // colDeviceExecutes1
            // 
            this.colDeviceExecutes1.FieldName = "DeviceExecutes";
            this.colDeviceExecutes1.Name = "colDeviceExecutes1";
            // 
            // colDeviceParameter
            // 
            this.colDeviceParameter.FieldName = "DeviceParameter";
            this.colDeviceParameter.Name = "colDeviceParameter";
            // 
            // colDevpAddress
            // 
            this.colDevpAddress.Caption = "接口地址";
            this.colDevpAddress.FieldName = "DevpAddress";
            this.colDevpAddress.Name = "colDevpAddress";
            this.colDevpAddress.Visible = true;
            this.colDevpAddress.VisibleIndex = 4;
            this.colDevpAddress.Width = 69;
            // 
            // colConAccAddress
            // 
            this.colConAccAddress.Caption = "控制设备地址";
            this.colConAccAddress.FieldName = "ConAccAddress";
            this.colConAccAddress.Name = "colConAccAddress";
            this.colConAccAddress.Visible = true;
            this.colConAccAddress.VisibleIndex = 5;
            this.colConAccAddress.Width = 80;
            // 
            // colDevpCode
            // 
            this.colDevpCode.Caption = "参数编码";
            this.colDevpCode.FieldName = "DevpCode";
            this.colDevpCode.Name = "colDevpCode";
            this.colDevpCode.Visible = true;
            this.colDevpCode.VisibleIndex = 1;
            this.colDevpCode.Width = 69;
            // 
            // colIsTwoWay
            // 
            this.colIsTwoWay.Caption = "是否双向通讯";
            this.colIsTwoWay.FieldName = "IsTwoWay";
            this.colIsTwoWay.Name = "colIsTwoWay";
            this.colIsTwoWay.Visible = true;
            this.colIsTwoWay.VisibleIndex = 7;
            this.colIsTwoWay.Width = 66;
            // 
            // colRemark2
            // 
            this.colRemark2.Caption = "备注";
            this.colRemark2.FieldName = "Remark";
            this.colRemark2.Name = "colRemark2";
            this.colRemark2.Visible = true;
            this.colRemark2.VisibleIndex = 8;
            this.colRemark2.Width = 66;
            // 
            // colSendFormat2
            // 
            this.colSendFormat2.Caption = "发送格式";
            this.colSendFormat2.FieldName = "SendFormat";
            this.colSendFormat2.Name = "colSendFormat2";
            this.colSendFormat2.Visible = true;
            this.colSendFormat2.VisibleIndex = 9;
            this.colSendFormat2.Width = 66;
            // 
            // colUserStatus2
            // 
            this.colUserStatus2.Caption = "使用状态";
            this.colUserStatus2.FieldName = "UserStatus";
            this.colUserStatus2.Name = "colUserStatus2";
            this.colUserStatus2.Visible = true;
            this.colUserStatus2.VisibleIndex = 10;
            // 
            // bmButton
            // 
            this.bmButton.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.bmButton.DockControls.Add(this.barDockControlTop);
            this.bmButton.DockControls.Add(this.barDockControlBottom);
            this.bmButton.DockControls.Add(this.barDockControlLeft);
            this.bmButton.DockControls.Add(this.barDockControlRight);
            this.bmButton.Form = this;
            this.bmButton.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.bbtnAdd,
            this.bbtnModify,
            this.bbtnDel,
            this.bbtnExit,
            this.bbtnCheck,
            this.bbtnSave,
            this.bbtnFind,
            this.bbtnSeek,
            this.bbtnAdd1});
            this.bmButton.MainMenu = this.bar2;
            this.bmButton.MaxItemId = 10;
            this.bmButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bmButton_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnAdd1),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnModify),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnDel),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnExit)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bbtnAdd1
            // 
            this.bbtnAdd1.Caption = "新增";
            this.bbtnAdd1.Id = 9;
            this.bbtnAdd1.Name = "bbtnAdd1";
            // 
            // bbtnSave
            // 
            this.bbtnSave.Caption = "保存";
            this.bbtnSave.Id = 6;
            this.bbtnSave.Name = "bbtnSave";
            // 
            // bbtnModify
            // 
            this.bbtnModify.Caption = "修改";
            this.bbtnModify.Id = 2;
            this.bbtnModify.Name = "bbtnModify";
            // 
            // bbtnDel
            // 
            this.bbtnDel.Caption = "删除";
            this.bbtnDel.Id = 3;
            this.bbtnDel.Name = "bbtnDel";
            // 
            // bbtnExit
            // 
            this.bbtnExit.Caption = "退出";
            this.bbtnExit.Id = 4;
            this.bbtnExit.Name = "bbtnExit";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(830, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 578);
            this.barDockControlBottom.Size = new System.Drawing.Size(830, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 554);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(830, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 554);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "增加";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // bbtnAdd
            // 
            this.bbtnAdd.Caption = "增加";
            this.bbtnAdd.Id = 1;
            this.bbtnAdd.Name = "bbtnAdd";
            // 
            // bbtnCheck
            // 
            this.bbtnCheck.Caption = "查询";
            this.bbtnCheck.Id = 5;
            this.bbtnCheck.Name = "bbtnCheck";
            // 
            // bbtnFind
            // 
            this.bbtnFind.Caption = "查询";
            this.bbtnFind.Id = 7;
            this.bbtnFind.Name = "bbtnFind";
            // 
            // bbtnSeek
            // 
            this.bbtnSeek.Caption = "查询";
            this.bbtnSeek.Id = 8;
            this.bbtnSeek.Name = "bbtnSeek";
            this.bbtnSeek.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // dataLayoutControl2
            // 
            this.dataLayoutControl2.Controls.Add(this.ConAccAddress);
            this.dataLayoutControl2.Controls.Add(this.DataTypeTextEdit);
            this.dataLayoutControl2.Controls.Add(this.DevCodeTextEdit);
            this.dataLayoutControl2.Controls.Add(this.DeviCodeTextEdit);
            this.dataLayoutControl2.Controls.Add(this.DeviNameTextEdit);
            this.dataLayoutControl2.Controls.Add(this.DevpAddressTextEdit);
            this.dataLayoutControl2.Controls.Add(this.SendFormatTextEdit);
            this.dataLayoutControl2.Controls.Add(this.RemarkTextEdit);
            this.dataLayoutControl2.Controls.Add(this.UserStatusEdit);
            this.dataLayoutControl2.Controls.Add(this.DevpCodeTextEdit);
            this.dataLayoutControl2.Controls.Add(this.IsTwoWayTextEdit);
            this.dataLayoutControl2.DataSource = this.deviceInterfaceBindingSource;
            this.dataLayoutControl2.Location = new System.Drawing.Point(12, 12);
            this.dataLayoutControl2.Name = "dataLayoutControl2";
            this.dataLayoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(272, 111, 594, 476);
            this.dataLayoutControl2.Root = this.Root;
            this.dataLayoutControl2.Size = new System.Drawing.Size(806, 191);
            this.dataLayoutControl2.TabIndex = 4;
            this.dataLayoutControl2.Text = "dataLayoutControl2";
            // 
            // ConAccAddress
            // 
            this.ConAccAddress.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.deviceInterfaceBindingSource, "ConAccAddress", true));
            this.ConAccAddress.Location = new System.Drawing.Point(480, 159);
            this.ConAccAddress.MenuManager = this.bmButton;
            this.ConAccAddress.Name = "ConAccAddress";
            this.ConAccAddress.Size = new System.Drawing.Size(314, 20);
            this.ConAccAddress.StyleController = this.dataLayoutControl2;
            this.ConAccAddress.TabIndex = 17;
            // 
            // deviceInterfaceBindingSource
            // 
            this.deviceInterfaceBindingSource.DataSource = typeof(LY.MES.WFCL.SRDevice.DeviceInterface);
            // 
            // DataTypeTextEdit
            // 
            this.DataTypeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.deviceInterfaceBindingSource, "DataType", true));
            this.DataTypeTextEdit.Location = new System.Drawing.Point(480, 12);
            this.DataTypeTextEdit.MenuManager = this.bmButton;
            this.DataTypeTextEdit.Name = "DataTypeTextEdit";
            this.DataTypeTextEdit.Size = new System.Drawing.Size(314, 20);
            this.DataTypeTextEdit.StyleController = this.dataLayoutControl2;
            this.DataTypeTextEdit.TabIndex = 4;
            // 
            // DevCodeTextEdit
            // 
            this.DevCodeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.deviceInterfaceBindingSource, "DevCode", true));
            this.DevCodeTextEdit.Location = new System.Drawing.Point(87, 12);
            this.DevCodeTextEdit.MenuManager = this.bmButton;
            this.DevCodeTextEdit.Name = "DevCodeTextEdit";
            this.DevCodeTextEdit.Properties.ReadOnly = true;
            this.DevCodeTextEdit.Size = new System.Drawing.Size(314, 20);
            this.DevCodeTextEdit.StyleController = this.dataLayoutControl2;
            this.DevCodeTextEdit.TabIndex = 5;
            // 
            // DeviCodeTextEdit
            // 
            this.DeviCodeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.deviceInterfaceBindingSource, "DeviCode", true));
            this.DeviCodeTextEdit.Location = new System.Drawing.Point(87, 36);
            this.DeviCodeTextEdit.MenuManager = this.bmButton;
            this.DeviCodeTextEdit.Name = "DeviCodeTextEdit";
            this.DeviCodeTextEdit.Size = new System.Drawing.Size(314, 20);
            this.DeviCodeTextEdit.StyleController = this.dataLayoutControl2;
            this.DeviCodeTextEdit.TabIndex = 6;
            // 
            // DeviNameTextEdit
            // 
            this.DeviNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.deviceInterfaceBindingSource, "DeviName", true));
            this.DeviNameTextEdit.Location = new System.Drawing.Point(480, 36);
            this.DeviNameTextEdit.MenuManager = this.bmButton;
            this.DeviNameTextEdit.Name = "DeviNameTextEdit";
            this.DeviNameTextEdit.Size = new System.Drawing.Size(314, 20);
            this.DeviNameTextEdit.StyleController = this.dataLayoutControl2;
            this.DeviNameTextEdit.TabIndex = 7;
            // 
            // DevpAddressTextEdit
            // 
            this.DevpAddressTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.deviceInterfaceBindingSource, "DevpAddress", true));
            this.DevpAddressTextEdit.Location = new System.Drawing.Point(480, 60);
            this.DevpAddressTextEdit.MenuManager = this.bmButton;
            this.DevpAddressTextEdit.Name = "DevpAddressTextEdit";
            this.DevpAddressTextEdit.Size = new System.Drawing.Size(314, 20);
            this.DevpAddressTextEdit.StyleController = this.dataLayoutControl2;
            this.DevpAddressTextEdit.TabIndex = 11;
            // 
            // SendFormatTextEdit
            // 
            this.SendFormatTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.deviceInterfaceBindingSource, "SendFormat", true));
            this.SendFormatTextEdit.Location = new System.Drawing.Point(87, 84);
            this.SendFormatTextEdit.MenuManager = this.bmButton;
            this.SendFormatTextEdit.Name = "SendFormatTextEdit";
            this.SendFormatTextEdit.Size = new System.Drawing.Size(314, 20);
            this.SendFormatTextEdit.StyleController = this.dataLayoutControl2;
            this.SendFormatTextEdit.TabIndex = 15;
            // 
            // RemarkTextEdit
            // 
            this.RemarkTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.deviceInterfaceBindingSource, "Remark", true));
            this.RemarkTextEdit.Location = new System.Drawing.Point(87, 108);
            this.RemarkTextEdit.MenuManager = this.bmButton;
            this.RemarkTextEdit.Name = "RemarkTextEdit";
            this.RemarkTextEdit.Size = new System.Drawing.Size(707, 47);
            this.RemarkTextEdit.StyleController = this.dataLayoutControl2;
            this.RemarkTextEdit.TabIndex = 14;
            this.RemarkTextEdit.UseOptimizedRendering = true;
            // 
            // UserStatusEdit
            // 
            this.UserStatusEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.deviceInterfaceBindingSource, "UserStatus", true));
            this.UserStatusEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.UserStatusEdit.Location = new System.Drawing.Point(87, 159);
            this.UserStatusEdit.MenuManager = this.bmButton;
            this.UserStatusEdit.Name = "UserStatusEdit";
            this.UserStatusEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.UserStatusEdit.Properties.DisplayMember = "Item2";
            this.UserStatusEdit.Properties.NullText = "";
            this.UserStatusEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.UserStatusEdit.Properties.ValueMember = "Item1";
            this.UserStatusEdit.Size = new System.Drawing.Size(314, 20);
            this.UserStatusEdit.StyleController = this.dataLayoutControl2;
            this.UserStatusEdit.TabIndex = 16;
            // 
            // DevpCodeTextEdit
            // 
            this.DevpCodeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.deviceInterfaceBindingSource, "DevpCode", true));
            this.DevpCodeTextEdit.Location = new System.Drawing.Point(87, 60);
            this.DevpCodeTextEdit.MenuManager = this.bmButton;
            this.DevpCodeTextEdit.Name = "DevpCodeTextEdit";
            this.DevpCodeTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DevpCodeTextEdit.Properties.ReadOnly = true;
            this.DevpCodeTextEdit.Size = new System.Drawing.Size(314, 20);
            this.DevpCodeTextEdit.StyleController = this.dataLayoutControl2;
            this.DevpCodeTextEdit.TabIndex = 12;
            this.DevpCodeTextEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.DevpCodeTextEdit_ButtonClick);
            // 
            // IsTwoWayTextEdit
            // 
            this.IsTwoWayTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.deviceInterfaceBindingSource, "IsTwoWay", true));
            this.IsTwoWayTextEdit.EditValue = null;
            this.IsTwoWayTextEdit.Location = new System.Drawing.Point(405, 84);
            this.IsTwoWayTextEdit.MenuManager = this.bmButton;
            this.IsTwoWayTextEdit.Name = "IsTwoWayTextEdit";
            this.IsTwoWayTextEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.IsTwoWayTextEdit.Properties.Caption = "   是否双向通讯";
            this.IsTwoWayTextEdit.Size = new System.Drawing.Size(389, 19);
            this.IsTwoWayTextEdit.StyleController = this.dataLayoutControl2;
            this.IsTwoWayTextEdit.TabIndex = 13;
            // 
            // Root
            // 
            this.Root.CustomizationFormText = "Root";
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup3});
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(806, 191);
            this.Root.Text = "Root";
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.AllowDrawBackground = false;
            this.layoutControlGroup3.CustomizationFormText = "autoGeneratedGroup0";
            this.layoutControlGroup3.GroupBordersVisible = false;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForDevCode,
            this.ItemForDeviCode,
            this.ItemForRemark,
            this.ItemForUserStatus,
            this.ItemForDataType,
            this.ItemForDeviName,
            this.ItemForIsTwoWay,
            this.ItemForDevpCode,
            this.ItemForDevpAddress,
            this.ItemForSendFormat,
            this.layoutControlItem5});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "autoGeneratedGroup0";
            this.layoutControlGroup3.Size = new System.Drawing.Size(786, 171);
            this.layoutControlGroup3.Text = "autoGeneratedGroup0";
            // 
            // ItemForDevCode
            // 
            this.ItemForDevCode.Control = this.DevCodeTextEdit;
            this.ItemForDevCode.CustomizationFormText = "设备编码";
            this.ItemForDevCode.Location = new System.Drawing.Point(0, 0);
            this.ItemForDevCode.Name = "ItemForDevCode";
            this.ItemForDevCode.Size = new System.Drawing.Size(393, 24);
            this.ItemForDevCode.Text = "设备编码";
            this.ItemForDevCode.TextSize = new System.Drawing.Size(72, 14);
            // 
            // ItemForDeviCode
            // 
            this.ItemForDeviCode.Control = this.DeviCodeTextEdit;
            this.ItemForDeviCode.CustomizationFormText = "接口编码";
            this.ItemForDeviCode.Location = new System.Drawing.Point(0, 24);
            this.ItemForDeviCode.Name = "ItemForDeviCode";
            this.ItemForDeviCode.Size = new System.Drawing.Size(393, 24);
            this.ItemForDeviCode.Text = "接口编码";
            this.ItemForDeviCode.TextSize = new System.Drawing.Size(72, 14);
            // 
            // ItemForRemark
            // 
            this.ItemForRemark.Control = this.RemarkTextEdit;
            this.ItemForRemark.CustomizationFormText = "备注";
            this.ItemForRemark.Location = new System.Drawing.Point(0, 96);
            this.ItemForRemark.Name = "ItemForRemark";
            this.ItemForRemark.Size = new System.Drawing.Size(786, 51);
            this.ItemForRemark.Text = "备注";
            this.ItemForRemark.TextSize = new System.Drawing.Size(72, 14);
            // 
            // ItemForUserStatus
            // 
            this.ItemForUserStatus.Control = this.UserStatusEdit;
            this.ItemForUserStatus.CustomizationFormText = "使用状态";
            this.ItemForUserStatus.Location = new System.Drawing.Point(0, 147);
            this.ItemForUserStatus.Name = "ItemForUserStatus";
            this.ItemForUserStatus.Size = new System.Drawing.Size(393, 24);
            this.ItemForUserStatus.Text = "使用状态";
            this.ItemForUserStatus.TextSize = new System.Drawing.Size(72, 14);
            // 
            // ItemForDataType
            // 
            this.ItemForDataType.Control = this.DataTypeTextEdit;
            this.ItemForDataType.CustomizationFormText = "数据类型";
            this.ItemForDataType.Location = new System.Drawing.Point(393, 0);
            this.ItemForDataType.Name = "ItemForDataType";
            this.ItemForDataType.Size = new System.Drawing.Size(393, 24);
            this.ItemForDataType.Text = "数据类型";
            this.ItemForDataType.TextSize = new System.Drawing.Size(72, 14);
            // 
            // ItemForDeviName
            // 
            this.ItemForDeviName.Control = this.DeviNameTextEdit;
            this.ItemForDeviName.CustomizationFormText = "接口名称";
            this.ItemForDeviName.Location = new System.Drawing.Point(393, 24);
            this.ItemForDeviName.Name = "ItemForDeviName";
            this.ItemForDeviName.Size = new System.Drawing.Size(393, 24);
            this.ItemForDeviName.Text = "接口名称";
            this.ItemForDeviName.TextSize = new System.Drawing.Size(72, 14);
            // 
            // ItemForIsTwoWay
            // 
            this.ItemForIsTwoWay.Control = this.IsTwoWayTextEdit;
            this.ItemForIsTwoWay.CustomizationFormText = "是否双向通讯";
            this.ItemForIsTwoWay.Location = new System.Drawing.Point(393, 72);
            this.ItemForIsTwoWay.Name = "ItemForIsTwoWay";
            this.ItemForIsTwoWay.Size = new System.Drawing.Size(393, 24);
            this.ItemForIsTwoWay.Text = "是否双向通讯";
            this.ItemForIsTwoWay.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForIsTwoWay.TextToControlDistance = 0;
            this.ItemForIsTwoWay.TextVisible = false;
            // 
            // ItemForDevpCode
            // 
            this.ItemForDevpCode.Control = this.DevpCodeTextEdit;
            this.ItemForDevpCode.CustomizationFormText = "参数编码";
            this.ItemForDevpCode.Location = new System.Drawing.Point(0, 48);
            this.ItemForDevpCode.Name = "ItemForDevpCode";
            this.ItemForDevpCode.Size = new System.Drawing.Size(393, 24);
            this.ItemForDevpCode.Text = "参数编码";
            this.ItemForDevpCode.TextSize = new System.Drawing.Size(72, 14);
            // 
            // ItemForDevpAddress
            // 
            this.ItemForDevpAddress.Control = this.DevpAddressTextEdit;
            this.ItemForDevpAddress.CustomizationFormText = "接口地址";
            this.ItemForDevpAddress.Location = new System.Drawing.Point(393, 48);
            this.ItemForDevpAddress.Name = "ItemForDevpAddress";
            this.ItemForDevpAddress.Size = new System.Drawing.Size(393, 24);
            this.ItemForDevpAddress.Text = "接口地址";
            this.ItemForDevpAddress.TextSize = new System.Drawing.Size(72, 14);
            // 
            // ItemForSendFormat
            // 
            this.ItemForSendFormat.Control = this.SendFormatTextEdit;
            this.ItemForSendFormat.CustomizationFormText = "发送格式";
            this.ItemForSendFormat.Location = new System.Drawing.Point(0, 72);
            this.ItemForSendFormat.Name = "ItemForSendFormat";
            this.ItemForSendFormat.Size = new System.Drawing.Size(393, 24);
            this.ItemForSendFormat.Text = "发送格式";
            this.ItemForSendFormat.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.ConAccAddress;
            this.layoutControlItem5.CustomizationFormText = "控制访问地址";
            this.layoutControlItem5.Location = new System.Drawing.Point(393, 147);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(393, 24);
            this.layoutControlItem5.Text = "控制访问地址";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(72, 14);
            // 
            // gridViewPaging1
            // 
            paging1.CurrentPage = ((long)(1));
            paging1.IsPaging = true;
            paging1.PageSize = ((long)(20));
            paging1.RowCount = ((long)(0));
            this.gridViewPaging1.DataPaging = paging1;
            this.gridViewPaging1.Location = new System.Drawing.Point(24, 502);
            this.gridViewPaging1.Name = "gridViewPaging1";
            this.gridViewPaging1.Size = new System.Drawing.Size(782, 28);
            this.gridViewPaging1.TabIndex = 2;
            this.gridViewPaging1.PagingChanged += new Client.Utility.Controls.EventPagingChanged(this.gridViewPaging1_PagingChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(830, 554);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.CustomizationFormText = "autoGeneratedGroup0";
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(810, 195);
            this.layoutControlGroup2.Text = "autoGeneratedGroup0";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dataLayoutControl2;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(810, 195);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.CustomizationFormText = "设备接口列表";
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem3});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 195);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(810, 339);
            this.layoutControlGroup4.Text = "设备接口列表";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gridControl1;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(786, 263);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridViewPaging1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 263);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(0, 32);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(104, 32);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(786, 32);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // colDeviCode
            // 
            this.colDeviCode.Caption = "接口编码";
            this.colDeviCode.FieldName = "DeviCode";
            this.colDeviCode.Name = "colDeviCode";
            this.colDeviCode.Visible = true;
            this.colDeviCode.VisibleIndex = 0;
            // 
            // colDeviName
            // 
            this.colDeviName.Caption = "接口名称";
            this.colDeviName.FieldName = "DeviName";
            this.colDeviName.Name = "colDeviName";
            this.colDeviName.Visible = true;
            this.colDeviName.VisibleIndex = 1;
            // 
            // colDevCode
            // 
            this.colDevCode.Caption = "设备编码";
            this.colDevCode.FieldName = "DevCode";
            this.colDevCode.Name = "colDevCode";
            this.colDevCode.Visible = true;
            this.colDevCode.VisibleIndex = 2;
            // 
            // colSendFormat
            // 
            this.colSendFormat.Caption = "发送格式";
            this.colSendFormat.FieldName = "SendFormat";
            this.colSendFormat.Name = "colSendFormat";
            this.colSendFormat.Visible = true;
            this.colSendFormat.VisibleIndex = 3;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 4;
            // 
            // colUserStatus
            // 
            this.colUserStatus.Caption = "用户状态";
            this.colUserStatus.FieldName = "UserStatus";
            this.colUserStatus.Name = "colUserStatus";
            this.colUserStatus.Visible = true;
            this.colUserStatus.VisibleIndex = 5;
            // 
            // bgwWait1
            // 
            this.bgwWait1.WorkerReportsProgress = true;
            this.bgwWait1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwWait_DoWork);
            this.bgwWait1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwWait_RunWorkerCompleted);
            // 
            // colDevCode1
            // 
            this.colDevCode1.Caption = "设备编码";
            this.colDevCode1.FieldName = "DevCode";
            this.colDevCode1.Name = "colDevCode1";
            this.colDevCode1.Visible = true;
            this.colDevCode1.VisibleIndex = 0;
            this.colDevCode1.Width = 115;
            // 
            // colDeviCode1
            // 
            this.colDeviCode1.Caption = "接口编码";
            this.colDeviCode1.FieldName = "DeviCode";
            this.colDeviCode1.Name = "colDeviCode1";
            this.colDeviCode1.Visible = true;
            this.colDeviCode1.VisibleIndex = 1;
            this.colDeviCode1.Width = 115;
            // 
            // colDeviName1
            // 
            this.colDeviName1.Caption = "接口名称";
            this.colDeviName1.FieldName = "DeviName";
            this.colDeviName1.Name = "colDeviName1";
            this.colDeviName1.Visible = true;
            this.colDeviName1.VisibleIndex = 2;
            this.colDeviName1.Width = 88;
            // 
            // colDevice
            // 
            this.colDevice.FieldName = "Device";
            this.colDevice.Name = "colDevice";
            // 
            // colDeviceExecutes
            // 
            this.colDeviceExecutes.FieldName = "DeviceExecutes";
            this.colDeviceExecutes.Name = "colDeviceExecutes";
            // 
            // colRemark1
            // 
            this.colRemark1.Caption = "备注";
            this.colRemark1.FieldName = "Remark";
            this.colRemark1.Name = "colRemark1";
            this.colRemark1.Visible = true;
            this.colRemark1.VisibleIndex = 3;
            this.colRemark1.Width = 123;
            // 
            // colSendFormat1
            // 
            this.colSendFormat1.Caption = "发送格式";
            this.colSendFormat1.FieldName = "SendFormat";
            this.colSendFormat1.Name = "colSendFormat1";
            this.colSendFormat1.Visible = true;
            this.colSendFormat1.VisibleIndex = 4;
            this.colSendFormat1.Width = 141;
            // 
            // colUserStatus1
            // 
            this.colUserStatus1.Caption = "使用状态";
            this.colUserStatus1.FieldName = "UserStatus";
            this.colUserStatus1.Name = "colUserStatus1";
            this.colUserStatus1.Visible = true;
            this.colUserStatus1.VisibleIndex = 5;
            this.colUserStatus1.Width = 112;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 290);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(716, 107);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.CustomizationFormText = "emptySpaceItem5";
            this.emptySpaceItem5.Location = new System.Drawing.Point(0, 201);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(716, 89);
            this.emptySpaceItem5.Text = "emptySpaceItem5";
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 290);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(716, 53);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(50, 20);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // frmDevInterfaceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 578);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmDevInterfaceList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设备接口";
            this.Load += new System.EventHandler(this.Interface_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceInterfaceBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl2)).EndInit();
            this.dataLayoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ConAccAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceInterfaceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTypeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DevCodeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeviCodeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeviNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DevpAddressTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendFormatTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemarkTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserStatusEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DevpCodeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsTwoWayTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDevCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeviCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUserStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDataType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeviName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIsTwoWay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDevpCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDevpAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSendFormat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        // private LYMesSystemDataSet lYMesSystemDataSet;
        // private LYMesSystemDataSetTableAdapters.DeviceInterfaceTableAdapter deviceInterfaceTableAdapter;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraBars.BarManager bmButton;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem bbtnAdd;
        private DevExpress.XtraBars.BarButtonItem bbtnModify;
        private DevExpress.XtraBars.BarButtonItem bbtnDel;
        private DevExpress.XtraBars.BarButtonItem bbtnExit;
        private DevExpress.XtraBars.BarButtonItem bbtnCheck;
        private Client.Utility.Controls.GridViewPaging gridViewPaging1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        // private LYMesSystemDataSetTableAdapters.DeviceInterfaceTableAdapter deviceInterfaceTableAdapter;
        private System.Windows.Forms.BindingSource deviceInterfaceBindingSource;
        private System.Windows.Forms.BindingSource deviceInterfaceBindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colDeviCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDeviName;
        private DevExpress.XtraGrid.Columns.GridColumn colDevCode;
        private DevExpress.XtraGrid.Columns.GridColumn colSendFormat;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colUserStatus;
        private System.ComponentModel.BackgroundWorker bgwWait1;
        private DevExpress.XtraBars.BarButtonItem bbtnSave;
        private DevExpress.XtraBars.BarButtonItem bbtnFind;
        private DevExpress.XtraBars.BarButtonItem bbtnSeek;
        private DevExpress.XtraBars.BarButtonItem bbtnAdd1;
        private DevExpress.XtraGrid.Columns.GridColumn colDevCode1;
        private DevExpress.XtraGrid.Columns.GridColumn colDeviCode1;
        private DevExpress.XtraGrid.Columns.GridColumn colDeviName1;
        private DevExpress.XtraGrid.Columns.GridColumn colDevice;
        private DevExpress.XtraGrid.Columns.GridColumn colDeviceExecutes;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark1;
        private DevExpress.XtraGrid.Columns.GridColumn colSendFormat1;
        private DevExpress.XtraGrid.Columns.GridColumn colUserStatus1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colDevCode2;
        private DevExpress.XtraGrid.Columns.GridColumn colDeviCode2;
        private DevExpress.XtraGrid.Columns.GridColumn colDeviName2;
        private DevExpress.XtraGrid.Columns.GridColumn colDevice1;
        private DevExpress.XtraGrid.Columns.GridColumn colDeviceExecutes1;
        private DevExpress.XtraGrid.Columns.GridColumn colDeviceParameter;
        private DevExpress.XtraGrid.Columns.GridColumn colDevpAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colDevpCode;
        private DevExpress.XtraGrid.Columns.GridColumn colIsTwoWay;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark2;
        private DevExpress.XtraGrid.Columns.GridColumn colSendFormat2;
        private DevExpress.XtraGrid.Columns.GridColumn colUserStatus2;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl2;
        private DevExpress.XtraEditors.TextEdit DataTypeTextEdit;
        private DevExpress.XtraEditors.TextEdit DevCodeTextEdit;
        private DevExpress.XtraEditors.TextEdit DeviCodeTextEdit;
        private DevExpress.XtraEditors.TextEdit DeviNameTextEdit;
        private DevExpress.XtraEditors.TextEdit DevpAddressTextEdit;
        private DevExpress.XtraEditors.TextEdit SendFormatTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDevCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDeviCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDevpCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForRemark;
        private DevExpress.XtraLayout.LayoutControlItem ItemForUserStatus;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDataType;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDeviName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDevpAddress;
        private DevExpress.XtraLayout.LayoutControlItem ItemForIsTwoWay;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSendFormat;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.MemoEdit RemarkTextEdit;
        private DevExpress.XtraEditors.LookUpEdit UserStatusEdit;
        private DevExpress.XtraEditors.ButtonEdit DevpCodeTextEdit;
        private DevExpress.XtraEditors.CheckEdit IsTwoWayTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraEditors.TextEdit ConAccAddress;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.Columns.GridColumn colConAccAddress;
    }
}