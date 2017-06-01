namespace LY.MES.WFCL.Drums.Frm
{
    partial class frmIPRegitForm
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.iPRegistFormBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMACAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatorTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatorName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbtniAdd = new DevExpress.XtraBars.BarButtonItem();
            this.bbtniSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbtniUpdate = new DevExpress.XtraBars.BarButtonItem();
            this.bbtniDel = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnExit = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnseach = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.CreatorNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.iPRegistFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CreatorTimeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.IDSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.IPTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.MACAddressTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.StatusSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForMACAddress = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForID = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForIP = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCreatorTime = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForStatus = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCreatorName = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.BgwWait = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iPRegistFormBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CreatorNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iPRegistFormBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreatorTimeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreatorTimeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MACAddressTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMACAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreatorTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreatorName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.dataLayoutControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 24);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(885, 408);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.iPRegistFormBindingSource1;
            this.gridControl1.Location = new System.Drawing.Point(12, 146);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(861, 250);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // iPRegistFormBindingSource1
            // 
            this.iPRegistFormBindingSource1.DataSource = typeof(LY.MES.WFCL.SRCfPExecute.IPRegistForm);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colIP,
            this.colMACAddress,
            this.colStatus,
            this.colCreatorTime,
            this.colCreatorName});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colID
            // 
            this.colID.Caption = "自动编号";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            // 
            // colIP
            // 
            this.colIP.FieldName = "IP";
            this.colIP.Name = "colIP";
            this.colIP.Visible = true;
            this.colIP.VisibleIndex = 1;
            // 
            // colMACAddress
            // 
            this.colMACAddress.Caption = "MAC地址";
            this.colMACAddress.FieldName = "MACAddress";
            this.colMACAddress.Name = "colMACAddress";
            this.colMACAddress.Visible = true;
            this.colMACAddress.VisibleIndex = 2;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "状态";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 3;
            // 
            // colCreatorTime
            // 
            this.colCreatorTime.Caption = "创建时间";
            this.colCreatorTime.FieldName = "CreatorTime";
            this.colCreatorTime.Name = "colCreatorTime";
            this.colCreatorTime.Visible = true;
            this.colCreatorTime.VisibleIndex = 5;
            // 
            // colCreatorName
            // 
            this.colCreatorName.Caption = "创建人";
            this.colCreatorName.FieldName = "CreatorName";
            this.colCreatorName.Name = "colCreatorName";
            this.colCreatorName.Visible = true;
            this.colCreatorName.VisibleIndex = 4;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.bbtniAdd,
            this.bbtniSave,
            this.bbtniUpdate,
            this.bbtniDel,
            this.bbtnExit,
            this.bbtnseach});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 7;
            this.barManager1.StatusBar = this.bar3;
            this.barManager1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barManager1_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtniAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtniSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtniUpdate),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtniDel),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnExit),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnseach)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bbtniAdd
            // 
            this.bbtniAdd.Caption = "新增";
            this.bbtniAdd.Id = 1;
            this.bbtniAdd.Name = "bbtniAdd";
            // 
            // bbtniSave
            // 
            this.bbtniSave.Caption = "保存";
            this.bbtniSave.Id = 2;
            this.bbtniSave.Name = "bbtniSave";
            // 
            // bbtniUpdate
            // 
            this.bbtniUpdate.Caption = "修改";
            this.bbtniUpdate.Id = 3;
            this.bbtniUpdate.Name = "bbtniUpdate";
            // 
            // bbtniDel
            // 
            this.bbtniDel.Caption = "删除";
            this.bbtniDel.Id = 4;
            this.bbtniDel.Name = "bbtniDel";
            // 
            // bbtnExit
            // 
            this.bbtnExit.Caption = "退出";
            this.bbtnExit.Id = 5;
            this.bbtnExit.Name = "bbtnExit";
            // 
            // bbtnseach
            // 
            this.bbtnseach.Caption = "查询";
            this.bbtnseach.Id = 6;
            this.bbtnseach.Name = "bbtnseach";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(885, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 432);
            this.barDockControlBottom.Size = new System.Drawing.Size(885, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 408);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(885, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 408);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.CreatorNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.CreatorTimeDateEdit);
            this.dataLayoutControl1.Controls.Add(this.IDSpinEdit);
            this.dataLayoutControl1.Controls.Add(this.IPTextEdit);
            this.dataLayoutControl1.Controls.Add(this.MACAddressTextEdit);
            this.dataLayoutControl1.Controls.Add(this.StatusSpinEdit);
            this.dataLayoutControl1.DataSource = this.iPRegistFormBindingSource;
            this.dataLayoutControl1.Location = new System.Drawing.Point(12, 12);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(861, 112);
            this.dataLayoutControl1.TabIndex = 4;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // CreatorNameTextEdit
            // 
            this.CreatorNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.iPRegistFormBindingSource, "CreatorName", true));
            this.CreatorNameTextEdit.Location = new System.Drawing.Point(75, 60);
            this.CreatorNameTextEdit.Name = "CreatorNameTextEdit";
            this.CreatorNameTextEdit.Properties.ReadOnly = true;
            this.CreatorNameTextEdit.Size = new System.Drawing.Size(354, 20);
            this.CreatorNameTextEdit.StyleController = this.dataLayoutControl1;
            this.CreatorNameTextEdit.TabIndex = 4;
            // 
            // iPRegistFormBindingSource
            // 
            this.iPRegistFormBindingSource.DataSource = typeof(LY.MES.WFCL.SRCfPExecute.IPRegistForm);
            // 
            // CreatorTimeDateEdit
            // 
            this.CreatorTimeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.iPRegistFormBindingSource, "CreatorTime", true));
            this.CreatorTimeDateEdit.EditValue = null;
            this.CreatorTimeDateEdit.Location = new System.Drawing.Point(496, 60);
            this.CreatorTimeDateEdit.Name = "CreatorTimeDateEdit";
            this.CreatorTimeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CreatorTimeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CreatorTimeDateEdit.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
            this.CreatorTimeDateEdit.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
            this.CreatorTimeDateEdit.Properties.ReadOnly = true;
            this.CreatorTimeDateEdit.Size = new System.Drawing.Size(353, 20);
            this.CreatorTimeDateEdit.StyleController = this.dataLayoutControl1;
            this.CreatorTimeDateEdit.TabIndex = 5;
            // 
            // IDSpinEdit
            // 
            this.IDSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.iPRegistFormBindingSource, "ID", true));
            this.IDSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.IDSpinEdit.Location = new System.Drawing.Point(496, 12);
            this.IDSpinEdit.Name = "IDSpinEdit";
            this.IDSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.IDSpinEdit.Properties.ReadOnly = true;
            this.IDSpinEdit.Size = new System.Drawing.Size(353, 20);
            this.IDSpinEdit.StyleController = this.dataLayoutControl1;
            this.IDSpinEdit.TabIndex = 6;
            // 
            // IPTextEdit
            // 
            this.IPTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.iPRegistFormBindingSource, "IP", true));
            this.IPTextEdit.Location = new System.Drawing.Point(75, 12);
            this.IPTextEdit.Name = "IPTextEdit";
            this.IPTextEdit.Size = new System.Drawing.Size(354, 20);
            this.IPTextEdit.StyleController = this.dataLayoutControl1;
            this.IPTextEdit.TabIndex = 7;
            // 
            // MACAddressTextEdit
            // 
            this.MACAddressTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.iPRegistFormBindingSource, "MACAddress", true));
            this.MACAddressTextEdit.Location = new System.Drawing.Point(75, 36);
            this.MACAddressTextEdit.Name = "MACAddressTextEdit";
            this.MACAddressTextEdit.Size = new System.Drawing.Size(354, 20);
            this.MACAddressTextEdit.StyleController = this.dataLayoutControl1;
            this.MACAddressTextEdit.TabIndex = 8;
            // 
            // StatusSpinEdit
            // 
            this.StatusSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.iPRegistFormBindingSource, "Status", true));
            this.StatusSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.StatusSpinEdit.Location = new System.Drawing.Point(496, 36);
            this.StatusSpinEdit.Name = "StatusSpinEdit";
            this.StatusSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.StatusSpinEdit.Properties.ReadOnly = true;
            this.StatusSpinEdit.Size = new System.Drawing.Size(353, 20);
            this.StatusSpinEdit.StyleController = this.dataLayoutControl1;
            this.StatusSpinEdit.TabIndex = 9;
            // 
            // Root
            // 
            this.Root.CustomizationFormText = "Root";
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(861, 112);
            this.Root.Text = "Root";
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.CustomizationFormText = "autoGeneratedGroup0";
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForMACAddress,
            this.ItemForID,
            this.ItemForIP,
            this.ItemForCreatorTime,
            this.ItemForStatus,
            this.ItemForCreatorName});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(841, 92);
            this.layoutControlGroup2.Text = "autoGeneratedGroup0";
            // 
            // ItemForMACAddress
            // 
            this.ItemForMACAddress.Control = this.MACAddressTextEdit;
            this.ItemForMACAddress.CustomizationFormText = "MAC Address";
            this.ItemForMACAddress.Location = new System.Drawing.Point(0, 24);
            this.ItemForMACAddress.Name = "ItemForMACAddress";
            this.ItemForMACAddress.Size = new System.Drawing.Size(421, 24);
            this.ItemForMACAddress.Text = "MAC地址：";
            this.ItemForMACAddress.TextSize = new System.Drawing.Size(60, 14);
            // 
            // ItemForID
            // 
            this.ItemForID.Control = this.IDSpinEdit;
            this.ItemForID.CustomizationFormText = "ID";
            this.ItemForID.Location = new System.Drawing.Point(421, 0);
            this.ItemForID.Name = "ItemForID";
            this.ItemForID.Size = new System.Drawing.Size(420, 24);
            this.ItemForID.Text = "自动编号：";
            this.ItemForID.TextSize = new System.Drawing.Size(60, 14);
            // 
            // ItemForIP
            // 
            this.ItemForIP.Control = this.IPTextEdit;
            this.ItemForIP.CustomizationFormText = "IP";
            this.ItemForIP.Location = new System.Drawing.Point(0, 0);
            this.ItemForIP.Name = "ItemForIP";
            this.ItemForIP.Size = new System.Drawing.Size(421, 24);
            this.ItemForIP.Text = "IP";
            this.ItemForIP.TextSize = new System.Drawing.Size(60, 14);
            // 
            // ItemForCreatorTime
            // 
            this.ItemForCreatorTime.Control = this.CreatorTimeDateEdit;
            this.ItemForCreatorTime.CustomizationFormText = "Creator Time";
            this.ItemForCreatorTime.Location = new System.Drawing.Point(421, 48);
            this.ItemForCreatorTime.Name = "ItemForCreatorTime";
            this.ItemForCreatorTime.Size = new System.Drawing.Size(420, 44);
            this.ItemForCreatorTime.Text = "创建时间：";
            this.ItemForCreatorTime.TextSize = new System.Drawing.Size(60, 14);
            // 
            // ItemForStatus
            // 
            this.ItemForStatus.Control = this.StatusSpinEdit;
            this.ItemForStatus.CustomizationFormText = "Status";
            this.ItemForStatus.Location = new System.Drawing.Point(421, 24);
            this.ItemForStatus.Name = "ItemForStatus";
            this.ItemForStatus.Size = new System.Drawing.Size(420, 24);
            this.ItemForStatus.Text = "状态：";
            this.ItemForStatus.TextSize = new System.Drawing.Size(60, 14);
            // 
            // ItemForCreatorName
            // 
            this.ItemForCreatorName.Control = this.CreatorNameTextEdit;
            this.ItemForCreatorName.CustomizationFormText = "Creator Name";
            this.ItemForCreatorName.Location = new System.Drawing.Point(0, 48);
            this.ItemForCreatorName.Name = "ItemForCreatorName";
            this.ItemForCreatorName.Size = new System.Drawing.Size(421, 44);
            this.ItemForCreatorName.Text = "创建人：";
            this.ItemForCreatorName.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(885, 408);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 116);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(865, 18);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dataLayoutControl1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(865, 116);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 134);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(865, 254);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // BgwWait
            // 
            this.BgwWait.WorkerReportsProgress = true;
            this.BgwWait.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwWait_DoWork);
            this.BgwWait.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgwWait_RunWorkerCompleted);
            // 
            // frmIPRegitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 455);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmIPRegitForm";
            this.Text = "frmIPRegitForm";
            this.Load += new System.EventHandler(this.frmIPRegitForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iPRegistFormBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CreatorNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iPRegistFormBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreatorTimeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreatorTimeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MACAddressTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMACAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreatorTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCreatorName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.TextEdit CreatorNameTextEdit;
        private System.Windows.Forms.BindingSource iPRegistFormBindingSource;
        private DevExpress.XtraEditors.DateEdit CreatorTimeDateEdit;
        private DevExpress.XtraEditors.SpinEdit IDSpinEdit;
        private DevExpress.XtraEditors.TextEdit IPTextEdit;
        private DevExpress.XtraEditors.TextEdit MACAddressTextEdit;
        private DevExpress.XtraEditors.SpinEdit StatusSpinEdit;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForMACAddress;
        private DevExpress.XtraLayout.LayoutControlItem ItemForID;
        private DevExpress.XtraLayout.LayoutControlItem ItemForIP;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCreatorTime;
        private DevExpress.XtraLayout.LayoutControlItem ItemForStatus;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCreatorName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bbtniAdd;
        private DevExpress.XtraBars.BarButtonItem bbtniSave;
        private DevExpress.XtraBars.BarButtonItem bbtniUpdate;
        private DevExpress.XtraBars.BarButtonItem bbtniDel;
        private DevExpress.XtraBars.BarButtonItem bbtnExit;
        private System.ComponentModel.BackgroundWorker BgwWait;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colIP;
        private DevExpress.XtraGrid.Columns.GridColumn colMACAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatorTime;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatorName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraBars.BarButtonItem bbtnseach;
        private System.Windows.Forms.BindingSource iPRegistFormBindingSource1;
    }
}