namespace LY.MES.WFCL.DataColl.List
{
    partial class frmDataCollcetion
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridViewPaging1 = new Client.Utility.Controls.GridViewPaging();
            this.Bt_Search = new DevExpress.XtraEditors.SimpleButton();
            this.TE_DevpCode = new DevExpress.XtraEditors.TextEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.TE_PDevCode = new DevExpress.XtraEditors.TextEdit();
            this.TE_DeveCode = new DevExpress.XtraEditors.TextEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.vCollectDataInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAutoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeveCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCollValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOriginalValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeviCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeviName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevpCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIFDevCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPDevName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIFDevName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPDevCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeviceExecute = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TE_DeviCode = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.colData = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsSuccess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStackTrace = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TE_DevpCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_PDevCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_DeveCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vCollectDataInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_DeviCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridViewPaging1);
            this.layoutControl1.Controls.Add(this.Bt_Search);
            this.layoutControl1.Controls.Add(this.TE_DevpCode);
            this.layoutControl1.Controls.Add(this.TE_PDevCode);
            this.layoutControl1.Controls.Add(this.TE_DeveCode);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.TE_DeviCode);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(635, 242, 641, 299);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(852, 385);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridViewPaging1
            // 
            paging1.CurrentPage = ((long)(1));
            paging1.IsPaging = true;
            paging1.PageSize = ((long)(20));
            paging1.RowCount = ((long)(0));
            this.gridViewPaging1.DataPaging = paging1;
            this.gridViewPaging1.Location = new System.Drawing.Point(24, 333);
            this.gridViewPaging1.Name = "gridViewPaging1";
            this.gridViewPaging1.Size = new System.Drawing.Size(804, 28);
            this.gridViewPaging1.TabIndex = 11;
            this.gridViewPaging1.PagingChanged += new Client.Utility.Controls.EventPagingChanged(this.gridViewPaging1_PagingChanged);
            // 
            // Bt_Search
            // 
            this.Bt_Search.Location = new System.Drawing.Point(741, 44);
            this.Bt_Search.MaximumSize = new System.Drawing.Size(100, 0);
            this.Bt_Search.Name = "Bt_Search";
            this.Bt_Search.Size = new System.Drawing.Size(87, 22);
            this.Bt_Search.StyleController = this.layoutControl1;
            this.Bt_Search.TabIndex = 10;
            this.Bt_Search.Text = "搜索";
            this.Bt_Search.Click += new System.EventHandler(this.Bt_Search_Click);
            // 
            // TE_DevpCode
            // 
            this.TE_DevpCode.Location = new System.Drawing.Point(632, 44);
            this.TE_DevpCode.MenuManager = this.barManager1;
            this.TE_DevpCode.Name = "TE_DevpCode";
            this.TE_DevpCode.Size = new System.Drawing.Size(105, 20);
            this.TE_DevpCode.StyleController = this.layoutControl1;
            this.TE_DevpCode.TabIndex = 8;
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.MaxItemId = 1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(852, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 385);
            this.barDockControlBottom.Size = new System.Drawing.Size(852, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 385);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(852, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 385);
            // 
            // TE_PDevCode
            // 
            this.TE_PDevCode.Location = new System.Drawing.Point(294, 44);
            this.TE_PDevCode.MenuManager = this.barManager1;
            this.TE_PDevCode.Name = "TE_PDevCode";
            this.TE_PDevCode.Size = new System.Drawing.Size(92, 20);
            this.TE_PDevCode.StyleController = this.layoutControl1;
            this.TE_PDevCode.TabIndex = 7;
            // 
            // TE_DeveCode
            // 
            this.TE_DeveCode.Location = new System.Drawing.Point(89, 44);
            this.TE_DeveCode.MenuManager = this.barManager1;
            this.TE_DeveCode.MinimumSize = new System.Drawing.Size(50, 0);
            this.TE_DeveCode.Name = "TE_DeveCode";
            this.TE_DeveCode.Size = new System.Drawing.Size(114, 20);
            this.TE_DeveCode.StyleController = this.layoutControl1;
            this.TE_DeveCode.TabIndex = 6;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.vCollectDataInfoBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(24, 114);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(804, 215);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // vCollectDataInfoBindingSource
            // 
            this.vCollectDataInfoBindingSource.DataSource = typeof(LY.MES.WFCL.SRDataColl.VCollectDataInfo);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAutoId,
            this.colDeveCode,
            this.colCollValue,
            this.colOriginalValue,
            this.colDeviCode,
            this.colDeviName,
            this.colDevpCode,
            this.colDevpName,
            this.colIFDevCode,
            this.colPDevName,
            this.colIFDevName,
            this.colPDevCode,
            this.colDeviceExecute,
            this.colCreateDate});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colOriginalValue, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colAutoId
            // 
            this.colAutoId.Caption = "自动编号";
            this.colAutoId.FieldName = "AutoId";
            this.colAutoId.Name = "colAutoId";
            this.colAutoId.OptionsColumn.ReadOnly = true;
            this.colAutoId.Visible = true;
            this.colAutoId.VisibleIndex = 0;
            this.colAutoId.Width = 67;
            // 
            // colDeveCode
            // 
            this.colDeveCode.Caption = "执行编号";
            this.colDeveCode.FieldName = "DeveCode";
            this.colDeveCode.Name = "colDeveCode";
            this.colDeveCode.OptionsColumn.ReadOnly = true;
            this.colDeveCode.Visible = true;
            this.colDeveCode.VisibleIndex = 1;
            this.colDeveCode.Width = 67;
            // 
            // colCollValue
            // 
            this.colCollValue.Caption = "采集值";
            this.colCollValue.FieldName = "CollValue";
            this.colCollValue.Name = "colCollValue";
            this.colCollValue.OptionsColumn.ReadOnly = true;
            this.colCollValue.Visible = true;
            this.colCollValue.VisibleIndex = 3;
            this.colCollValue.Width = 55;
            // 
            // colOriginalValue
            // 
            this.colOriginalValue.Caption = "初始值";
            this.colOriginalValue.FieldName = "OriginalValue";
            this.colOriginalValue.Name = "colOriginalValue";
            this.colOriginalValue.OptionsColumn.ReadOnly = true;
            this.colOriginalValue.Visible = true;
            this.colOriginalValue.VisibleIndex = 2;
            this.colOriginalValue.Width = 68;
            // 
            // colDeviCode
            // 
            this.colDeviCode.Caption = "接口编码";
            this.colDeviCode.FieldName = "DeviCode";
            this.colDeviCode.Name = "colDeviCode";
            this.colDeviCode.OptionsColumn.ReadOnly = true;
            this.colDeviCode.Visible = true;
            this.colDeviCode.VisibleIndex = 8;
            this.colDeviCode.Width = 67;
            // 
            // colDeviName
            // 
            this.colDeviName.Caption = "接口名称";
            this.colDeviName.FieldName = "DeviName";
            this.colDeviName.Name = "colDeviName";
            this.colDeviName.OptionsColumn.ReadOnly = true;
            this.colDeviName.Visible = true;
            this.colDeviName.VisibleIndex = 9;
            this.colDeviName.Width = 67;
            // 
            // colDevpCode
            // 
            this.colDevpCode.Caption = "参数编码";
            this.colDevpCode.FieldName = "DevpCode";
            this.colDevpCode.Name = "colDevpCode";
            this.colDevpCode.OptionsColumn.ReadOnly = true;
            this.colDevpCode.Visible = true;
            this.colDevpCode.VisibleIndex = 6;
            this.colDevpCode.Width = 67;
            // 
            // colDevpName
            // 
            this.colDevpName.Caption = "参数名称";
            this.colDevpName.FieldName = "DevpName";
            this.colDevpName.Name = "colDevpName";
            this.colDevpName.OptionsColumn.ReadOnly = true;
            this.colDevpName.Visible = true;
            this.colDevpName.VisibleIndex = 7;
            this.colDevpName.Width = 67;
            // 
            // colIFDevCode
            // 
            this.colIFDevCode.Caption = "接口设备编码";
            this.colIFDevCode.FieldName = "IFDevCode";
            this.colIFDevCode.Name = "colIFDevCode";
            this.colIFDevCode.OptionsColumn.ReadOnly = true;
            this.colIFDevCode.Visible = true;
            this.colIFDevCode.VisibleIndex = 4;
            this.colIFDevCode.Width = 91;
            // 
            // colPDevName
            // 
            this.colPDevName.Caption = "参数设备名称";
            this.colPDevName.FieldName = "PDevName";
            this.colPDevName.Name = "colPDevName";
            this.colPDevName.OptionsColumn.ReadOnly = true;
            this.colPDevName.Visible = true;
            this.colPDevName.VisibleIndex = 11;
            this.colPDevName.Width = 91;
            // 
            // colIFDevName
            // 
            this.colIFDevName.Caption = "接口设备名称";
            this.colIFDevName.FieldName = "IFDevName";
            this.colIFDevName.Name = "colIFDevName";
            this.colIFDevName.OptionsColumn.ReadOnly = true;
            this.colIFDevName.Visible = true;
            this.colIFDevName.VisibleIndex = 5;
            this.colIFDevName.Width = 91;
            // 
            // colPDevCode
            // 
            this.colPDevCode.Caption = "参数设备编码";
            this.colPDevCode.FieldName = "PDevCode";
            this.colPDevCode.Name = "colPDevCode";
            this.colPDevCode.OptionsColumn.ReadOnly = true;
            this.colPDevCode.Visible = true;
            this.colPDevCode.VisibleIndex = 10;
            this.colPDevCode.Width = 91;
            // 
            // colDeviceExecute
            // 
            this.colDeviceExecute.FieldName = "DeviceExecute";
            this.colDeviceExecute.Name = "colDeviceExecute";
            this.colDeviceExecute.OptionsColumn.ReadOnly = true;
            this.colDeviceExecute.Width = 104;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Caption = "创建时间";
            this.colCreateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCreateDate.FieldName = "CreateDate";
            this.colCreateDate.Name = "colCreateDate";
            this.colCreateDate.OptionsColumn.ReadOnly = true;
            this.colCreateDate.Visible = true;
            this.colCreateDate.VisibleIndex = 12;
            this.colCreateDate.Width = 67;
            // 
            // TE_DeviCode
            // 
            this.TE_DeviCode.Location = new System.Drawing.Point(455, 44);
            this.TE_DeviCode.MaximumSize = new System.Drawing.Size(110, 0);
            this.TE_DeviCode.MenuManager = this.barManager1;
            this.TE_DeviCode.Name = "TE_DeviCode";
            this.TE_DeviCode.Size = new System.Drawing.Size(108, 20);
            this.TE_DeviCode.StyleController = this.layoutControl1;
            this.TE_DeviCode.TabIndex = 9;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(852, 385);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "采集列表";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem7});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 70);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(832, 295);
            this.layoutControlGroup2.Text = "采集列表";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(808, 219);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.gridViewPaging1;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 219);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(0, 32);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(104, 32);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(808, 32);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "layoutControlGroup3";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem4,
            this.layoutControlItem6});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(832, 70);
            this.layoutControlGroup3.Text = "搜索条件";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.TE_DeveCode;
            this.layoutControlItem1.CustomizationFormText = "执行编号：";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(183, 26);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(183, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(183, 26);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "执行编号：";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(60, 14);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.TE_PDevCode;
            this.layoutControlItem3.CustomizationFormText = "设备编号：";
            this.layoutControlItem3.Location = new System.Drawing.Point(183, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(183, 26);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(183, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(183, 26);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "参数设备编号：";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(84, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.TE_DeviCode;
            this.layoutControlItem5.CustomizationFormText = "接口编号：";
            this.layoutControlItem5.Location = new System.Drawing.Point(366, 0);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(177, 26);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(177, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(177, 26);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "接口编号：";
            this.layoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(60, 14);
            this.layoutControlItem5.TextToControlDistance = 5;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.TE_DevpCode;
            this.layoutControlItem4.CustomizationFormText = "参数编号：";
            this.layoutControlItem4.Location = new System.Drawing.Point(543, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(174, 26);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(174, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(174, 26);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "参数编号：";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(60, 14);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.Bt_Search;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(717, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(91, 26);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // colData
            // 
            this.colData.FieldName = "Data";
            this.colData.Name = "colData";
            this.colData.Visible = true;
            this.colData.VisibleIndex = 0;
            // 
            // colIsSuccess
            // 
            this.colIsSuccess.FieldName = "IsSuccess";
            this.colIsSuccess.Name = "colIsSuccess";
            this.colIsSuccess.Visible = true;
            this.colIsSuccess.VisibleIndex = 1;
            // 
            // colMessage
            // 
            this.colMessage.FieldName = "Message";
            this.colMessage.Name = "colMessage";
            this.colMessage.Visible = true;
            this.colMessage.VisibleIndex = 2;
            // 
            // colStackTrace
            // 
            this.colStackTrace.FieldName = "StackTrace";
            this.colStackTrace.Name = "colStackTrace";
            this.colStackTrace.Visible = true;
            this.colStackTrace.VisibleIndex = 3;
            // 
            // frmDataCollcetion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 385);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmDataCollcetion";
            this.Text = "frmDataCollcetion";
            this.Load += new System.EventHandler(this.frmDataCollcetion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TE_DevpCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_PDevCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_DeveCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vCollectDataInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_DeviCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.TextEdit TE_DevpCode;
        private DevExpress.XtraEditors.TextEdit TE_PDevCode;
        private DevExpress.XtraEditors.TextEdit TE_DeveCode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraEditors.SimpleButton Bt_Search;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource vCollectDataInfoBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colDeviCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDeviName;
        private DevExpress.XtraGrid.Columns.GridColumn colDevpCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDevpName;
        private DevExpress.XtraGrid.Columns.GridColumn colIFDevCode;
        private DevExpress.XtraGrid.Columns.GridColumn colIFDevName;
        private DevExpress.XtraGrid.Columns.GridColumn colPDevCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPDevName;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoId;
        private DevExpress.XtraGrid.Columns.GridColumn colCollValue;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDeveCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDeviceExecute;
        private DevExpress.XtraGrid.Columns.GridColumn colOriginalValue;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colData;
        private DevExpress.XtraGrid.Columns.GridColumn colIsSuccess;
        private DevExpress.XtraGrid.Columns.GridColumn colMessage;
        private DevExpress.XtraGrid.Columns.GridColumn colStackTrace;
        private Client.Utility.Controls.GridViewPaging gridViewPaging1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.TextEdit TE_DeviCode;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
    }
}