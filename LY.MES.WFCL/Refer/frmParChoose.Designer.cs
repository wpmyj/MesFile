namespace LY.MES.WFCL.Refer
{
    partial class frmParChoose
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
            this.deviceParameterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbtiEnsure = new DevExpress.XtraBars.BarButtonItem();
            this.bbtiClear = new DevExpress.XtraBars.BarButtonItem();
            this.bbtiExit = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridViewPaging1 = new Client.Utility.Controls.GridViewPaging();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDevCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeviceInterfaces = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevpCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaxValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMinValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStandardValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FiltrateSimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.FiltrateTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.FiltrateControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.deviceParameterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FiltrateTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FiltrateControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // deviceParameterBindingSource
            // 
            this.deviceParameterBindingSource.DataSource = typeof(LY.MES.WFCL.SRDevice.DeviceParameter);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbtiEnsure,
            this.bbtiClear,
            this.bbtiExit});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 3;
            this.barManager1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barManager1_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtiEnsure),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtiClear),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtiExit)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bbtiEnsure
            // 
            this.bbtiEnsure.Caption = "确定";
            this.bbtiEnsure.Id = 0;
            this.bbtiEnsure.Name = "bbtiEnsure";
            // 
            // bbtiClear
            // 
            this.bbtiClear.Caption = "清除";
            this.bbtiClear.Id = 1;
            this.bbtiClear.Name = "bbtiClear";
            this.bbtiClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bbtiExit
            // 
            this.bbtiExit.Caption = "退出";
            this.bbtiExit.Id = 2;
            this.bbtiExit.Name = "bbtiExit";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(801, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 475);
            this.barDockControlBottom.Size = new System.Drawing.Size(801, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 451);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(801, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 451);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridViewPaging1);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.FiltrateSimpleButton);
            this.layoutControl1.Controls.Add(this.FiltrateTextEdit);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 24);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(801, 451);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridViewPaging1
            // 
            paging1.CurrentPage = ((long)(1));
            paging1.IsPaging = true;
            paging1.PageSize = ((long)(20));
            paging1.RowCount = ((long)(0));
            this.gridViewPaging1.DataPaging = paging1;
            this.gridViewPaging1.Location = new System.Drawing.Point(12, 412);
            this.gridViewPaging1.Name = "gridViewPaging1";
            this.gridViewPaging1.Size = new System.Drawing.Size(767, 27);
            this.gridViewPaging1.TabIndex = 7;
            this.gridViewPaging1.PagingChanged += new Client.Utility.Controls.EventPagingChanged(this.gridViewPaging1_PagingChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.deviceParameterBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 38);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(777, 370);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDevCode,
            this.colDevice,
            this.colDeviceInterfaces,
            this.colDevpCode,
            this.colDevpName,
            this.colMaxValue,
            this.colMinValue,
            this.colRemark,
            this.colStandardValue});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "参数列表";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            // 
            // colDevCode
            // 
            this.colDevCode.Caption = "设备编码";
            this.colDevCode.FieldName = "DevCode";
            this.colDevCode.Name = "colDevCode";
            this.colDevCode.Visible = true;
            this.colDevCode.VisibleIndex = 0;
            // 
            // colDevice
            // 
            this.colDevice.FieldName = "Device";
            this.colDevice.Name = "colDevice";
            // 
            // colDeviceInterfaces
            // 
            this.colDeviceInterfaces.FieldName = "DeviceInterfaces";
            this.colDeviceInterfaces.Name = "colDeviceInterfaces";
            // 
            // colDevpCode
            // 
            this.colDevpCode.Caption = "参数编码";
            this.colDevpCode.FieldName = "DevpCode";
            this.colDevpCode.Name = "colDevpCode";
            this.colDevpCode.Visible = true;
            this.colDevpCode.VisibleIndex = 1;
            // 
            // colDevpName
            // 
            this.colDevpName.Caption = "参数名称";
            this.colDevpName.FieldName = "DevpName";
            this.colDevpName.Name = "colDevpName";
            this.colDevpName.Visible = true;
            this.colDevpName.VisibleIndex = 2;
            // 
            // colMaxValue
            // 
            this.colMaxValue.Caption = "最大值";
            this.colMaxValue.FieldName = "MaxValue";
            this.colMaxValue.Name = "colMaxValue";
            this.colMaxValue.Visible = true;
            this.colMaxValue.VisibleIndex = 3;
            // 
            // colMinValue
            // 
            this.colMinValue.Caption = "最小值";
            this.colMinValue.FieldName = "MinValue";
            this.colMinValue.Name = "colMinValue";
            this.colMinValue.Visible = true;
            this.colMinValue.VisibleIndex = 4;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 6;
            // 
            // colStandardValue
            // 
            this.colStandardValue.Caption = "标准值";
            this.colStandardValue.FieldName = "StandardValue";
            this.colStandardValue.Name = "colStandardValue";
            this.colStandardValue.Visible = true;
            this.colStandardValue.VisibleIndex = 5;
            // 
            // FiltrateSimpleButton
            // 
            this.FiltrateSimpleButton.Location = new System.Drawing.Point(688, 12);
            this.FiltrateSimpleButton.Name = "FiltrateSimpleButton";
            this.FiltrateSimpleButton.Size = new System.Drawing.Size(101, 22);
            this.FiltrateSimpleButton.StyleController = this.layoutControl1;
            this.FiltrateSimpleButton.TabIndex = 5;
            this.FiltrateSimpleButton.Text = "过滤(Ctrl+F)";
            this.FiltrateSimpleButton.Click += new System.EventHandler(this.FiltrateSimpleButton_Click);
            // 
            // FiltrateTextEdit
            // 
            this.FiltrateTextEdit.EditValue = "";
            this.FiltrateTextEdit.Location = new System.Drawing.Point(63, 12);
            this.FiltrateTextEdit.MenuManager = this.barManager1;
            this.FiltrateTextEdit.Name = "FiltrateTextEdit";
            this.FiltrateTextEdit.Size = new System.Drawing.Size(621, 20);
            this.FiltrateTextEdit.StyleController = this.layoutControl1;
            this.FiltrateTextEdit.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.FiltrateControlItem,
            this.layoutControlItem2,
            this.emptySpaceItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(801, 451);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // FiltrateControlItem
            // 
            this.FiltrateControlItem.Control = this.FiltrateTextEdit;
            this.FiltrateControlItem.CustomizationFormText = "过滤条件";
            this.FiltrateControlItem.Location = new System.Drawing.Point(0, 0);
            this.FiltrateControlItem.Name = "FiltrateControlItem";
            this.FiltrateControlItem.Size = new System.Drawing.Size(676, 26);
            this.FiltrateControlItem.Text = "过滤条件";
            this.FiltrateControlItem.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.FiltrateSimpleButton;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(676, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(105, 26);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(771, 400);
            this.emptySpaceItem2.MaxSize = new System.Drawing.Size(10, 31);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(10, 31);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(10, 31);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(781, 374);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gridViewPaging1;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 400);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(771, 31);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // frmParChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 475);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmParChoose";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "参数选择列表";
            this.Load += new System.EventHandler(this.frmParChoose_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deviceParameterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FiltrateTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FiltrateControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource deviceParameterBindingSource;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private Client.Utility.Controls.GridViewPaging gridViewPaging1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colDevCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDevice;
        private DevExpress.XtraGrid.Columns.GridColumn colDeviceInterfaces;
        private DevExpress.XtraGrid.Columns.GridColumn colDevpCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDevpName;
        private DevExpress.XtraGrid.Columns.GridColumn colMaxValue;
        private DevExpress.XtraGrid.Columns.GridColumn colMinValue;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colStandardValue;
        private DevExpress.XtraEditors.SimpleButton FiltrateSimpleButton;
        private DevExpress.XtraEditors.TextEdit FiltrateTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem FiltrateControlItem;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraBars.BarButtonItem bbtiEnsure;
        private DevExpress.XtraBars.BarButtonItem bbtiClear;
        private DevExpress.XtraBars.BarButtonItem bbtiExit;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}