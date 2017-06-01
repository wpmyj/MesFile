namespace LY.MES.WFCL.Winder.Frm
{
    partial class frmPullDetectionReg
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
            this.qCPullDetectionRegBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colActualThick = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActualPull = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActualWidth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAutoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatePerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFrequency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThick = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModifyDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModifyPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProcessType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductionLine = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQualityInspector = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRegDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStandardPull = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrength = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTestResults = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWidth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbtniStart = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.ProductLevelComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.qCPullDetectionRegBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ActualPullTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ThickTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.OrderTypeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.RegDateDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.StandardPullTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.StrengthTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.TestResultsTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.WidthTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ProcessTypeSpinEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.QualityInspectorTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.OrderCodeTextEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.FrequencyTextEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ProductionLineTextEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForRegDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForWidth = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForStrength = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemCurrPull = new DevExpress.XtraLayout.EmptySpaceItem();
            this.ItemForActualPull = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForStandardPull = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForFrequency = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.ItemForTestResults = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForThick = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForOrderCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForProductionLine = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForProductLevel = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForQualityInspector = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForProcessType = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForOrderType = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.bgwWait = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qCPullDetectionRegBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductLevelComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qCPullDetectionRegBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActualPullTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThickTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderTypeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegDateDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegDateDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StandardPullTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrengthTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestResultsTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessTypeSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QualityInspectorTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderCodeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrequencyTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductionLineTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRegDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStrength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCurrPull)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForActualPull)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStandardPull)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTestResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForThick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOrderCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForProductionLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForProductLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForQualityInspector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForProcessType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOrderType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
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
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(373, 214, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(993, 511);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.qCPullDetectionRegBindingSource1;
            this.gridControl1.Location = new System.Drawing.Point(24, 231);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(945, 256);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // qCPullDetectionRegBindingSource1
            // 
            this.qCPullDetectionRegBindingSource1.DataSource = typeof(LY.MES.WFCL.SRPullDetectionReg.QC_PullDetectionReg);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colActualThick,
            this.colActualPull,
            this.colActualWidth,
            this.colAutoID,
            this.colCreateDate,
            this.colCreatePerson,
            this.colFrequency,
            this.colThick,
            this.colModifyDate,
            this.colModifyPerson,
            this.colOrderCode,
            this.colOrderType,
            this.colProcessType,
            this.colProductionLine,
            this.colQualityInspector,
            this.colRegDate,
            this.colStandardPull,
            this.colStrength,
            this.colTestResults,
            this.colWidth});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colProcessType, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView1_CustomColumnDisplayText);
            // 
            // colActualThick
            // 
            this.colActualThick.Caption = "实际厚度";
            this.colActualThick.FieldName = "ActualThick";
            this.colActualThick.Name = "colActualThick";
            // 
            // colActualPull
            // 
            this.colActualPull.Caption = "实际拉力";
            this.colActualPull.FieldName = "ActualPull";
            this.colActualPull.Name = "colActualPull";
            this.colActualPull.Visible = true;
            this.colActualPull.VisibleIndex = 11;
            // 
            // colActualWidth
            // 
            this.colActualWidth.Caption = "实际宽度";
            this.colActualWidth.FieldName = "ActualWidth";
            this.colActualWidth.Name = "colActualWidth";
            // 
            // colAutoID
            // 
            this.colAutoID.Caption = "编号";
            this.colAutoID.FieldName = "AutoID";
            this.colAutoID.Name = "colAutoID";
            this.colAutoID.Visible = true;
            this.colAutoID.VisibleIndex = 0;
            this.colAutoID.Width = 63;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Caption = "创建时间";
            this.colCreateDate.FieldName = "CreateDate";
            this.colCreateDate.Name = "colCreateDate";
            this.colCreateDate.Visible = true;
            this.colCreateDate.VisibleIndex = 14;
            this.colCreateDate.Width = 139;
            // 
            // colCreatePerson
            // 
            this.colCreatePerson.Caption = "创建人";
            this.colCreatePerson.FieldName = "CreatePerson";
            this.colCreatePerson.Name = "colCreatePerson";
            this.colCreatePerson.Visible = true;
            this.colCreatePerson.VisibleIndex = 15;
            // 
            // colFrequency
            // 
            this.colFrequency.Caption = "班次";
            this.colFrequency.FieldName = "Frequency";
            this.colFrequency.Name = "colFrequency";
            this.colFrequency.Visible = true;
            this.colFrequency.VisibleIndex = 5;
            this.colFrequency.Width = 92;
            // 
            // colThick
            // 
            this.colThick.Caption = "厚度";
            this.colThick.FieldName = "Thick";
            this.colThick.Name = "colThick";
            this.colThick.Visible = true;
            this.colThick.VisibleIndex = 7;
            // 
            // colModifyDate
            // 
            this.colModifyDate.Caption = "修改时间";
            this.colModifyDate.FieldName = "ModifyDate";
            this.colModifyDate.Name = "colModifyDate";
            this.colModifyDate.Width = 131;
            // 
            // colModifyPerson
            // 
            this.colModifyPerson.Caption = "修改人";
            this.colModifyPerson.FieldName = "ModifyPerson";
            this.colModifyPerson.Name = "colModifyPerson";
            // 
            // colOrderCode
            // 
            this.colOrderCode.Caption = "订单号";
            this.colOrderCode.FieldName = "OrderCode";
            this.colOrderCode.Name = "colOrderCode";
            this.colOrderCode.Visible = true;
            this.colOrderCode.VisibleIndex = 3;
            this.colOrderCode.Width = 154;
            // 
            // colOrderType
            // 
            this.colOrderType.Caption = "订单类型";
            this.colOrderType.FieldName = "OrderType";
            this.colOrderType.Name = "colOrderType";
            this.colOrderType.Visible = true;
            this.colOrderType.VisibleIndex = 2;
            // 
            // colProcessType
            // 
            this.colProcessType.Caption = "处理类型";
            this.colProcessType.FieldName = "ProcessType";
            this.colProcessType.Name = "colProcessType";
            this.colProcessType.Visible = true;
            this.colProcessType.VisibleIndex = 13;
            this.colProcessType.Width = 94;
            // 
            // colProductionLine
            // 
            this.colProductionLine.Caption = "产线";
            this.colProductionLine.FieldName = "ProductionLine";
            this.colProductionLine.Name = "colProductionLine";
            this.colProductionLine.Visible = true;
            this.colProductionLine.VisibleIndex = 4;
            this.colProductionLine.Width = 87;
            // 
            // colQualityInspector
            // 
            this.colQualityInspector.Caption = "质检员";
            this.colQualityInspector.FieldName = "QualityInspector";
            this.colQualityInspector.Name = "colQualityInspector";
            this.colQualityInspector.Visible = true;
            this.colQualityInspector.VisibleIndex = 6;
            // 
            // colRegDate
            // 
            this.colRegDate.Caption = "登记日期";
            this.colRegDate.FieldName = "RegDate";
            this.colRegDate.Name = "colRegDate";
            this.colRegDate.Visible = true;
            this.colRegDate.VisibleIndex = 1;
            this.colRegDate.Width = 115;
            // 
            // colStandardPull
            // 
            this.colStandardPull.Caption = "标准拉力";
            this.colStandardPull.FieldName = "StandardPull";
            this.colStandardPull.Name = "colStandardPull";
            this.colStandardPull.Visible = true;
            this.colStandardPull.VisibleIndex = 10;
            // 
            // colStrength
            // 
            this.colStrength.Caption = "强度";
            this.colStrength.FieldName = "Strength";
            this.colStrength.Name = "colStrength";
            this.colStrength.Visible = true;
            this.colStrength.VisibleIndex = 9;
            // 
            // colTestResults
            // 
            this.colTestResults.Caption = "检测结果";
            this.colTestResults.FieldName = "TestResults";
            this.colTestResults.Name = "colTestResults";
            this.colTestResults.Visible = true;
            this.colTestResults.VisibleIndex = 12;
            this.colTestResults.Width = 84;
            // 
            // colWidth
            // 
            this.colWidth.Caption = "宽度";
            this.colWidth.FieldName = "Width";
            this.colWidth.Name = "colWidth";
            this.colWidth.Visible = true;
            this.colWidth.VisibleIndex = 8;
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
            this.bbtniStart});
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
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtniStart)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bbtniStart
            // 
            this.bbtniStart.Caption = "开始检测";
            this.bbtniStart.Id = 1;
            this.bbtniStart.Name = "bbtniStart";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(993, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 535);
            this.barDockControlBottom.Size = new System.Drawing.Size(993, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 511);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(993, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 511);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.ProductLevelComboBoxEdit);
            this.dataLayoutControl1.Controls.Add(this.ActualPullTextEdit);
            this.dataLayoutControl1.Controls.Add(this.ThickTextEdit);
            this.dataLayoutControl1.Controls.Add(this.OrderTypeTextEdit);
            this.dataLayoutControl1.Controls.Add(this.RegDateDateEdit);
            this.dataLayoutControl1.Controls.Add(this.StandardPullTextEdit);
            this.dataLayoutControl1.Controls.Add(this.StrengthTextEdit);
            this.dataLayoutControl1.Controls.Add(this.TestResultsTextEdit);
            this.dataLayoutControl1.Controls.Add(this.WidthTextEdit);
            this.dataLayoutControl1.Controls.Add(this.ProcessTypeSpinEdit);
            this.dataLayoutControl1.Controls.Add(this.QualityInspectorTextEdit);
            this.dataLayoutControl1.Controls.Add(this.OrderCodeTextEdit);
            this.dataLayoutControl1.Controls.Add(this.FrequencyTextEdit);
            this.dataLayoutControl1.Controls.Add(this.ProductionLineTextEdit);
            this.dataLayoutControl1.DataSource = this.qCPullDetectionRegBindingSource;
            this.dataLayoutControl1.Location = new System.Drawing.Point(12, 12);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(475, 176, 432, 440);
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(969, 183);
            this.dataLayoutControl1.TabIndex = 4;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // ProductLevelComboBoxEdit
            // 
            this.ProductLevelComboBoxEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.qCPullDetectionRegBindingSource, "ProductLevel", true));
            this.ProductLevelComboBoxEdit.Location = new System.Drawing.Point(305, 2);
            this.ProductLevelComboBoxEdit.MenuManager = this.barManager1;
            this.ProductLevelComboBoxEdit.Name = "ProductLevelComboBoxEdit";
            this.ProductLevelComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ProductLevelComboBoxEdit.Properties.Items.AddRange(new object[] {
            "一级品",
            "二级品"});
            this.ProductLevelComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.ProductLevelComboBoxEdit.Size = new System.Drawing.Size(193, 20);
            this.ProductLevelComboBoxEdit.StyleController = this.dataLayoutControl1;
            this.ProductLevelComboBoxEdit.TabIndex = 23;
            // 
            // qCPullDetectionRegBindingSource
            // 
            this.qCPullDetectionRegBindingSource.DataSource = typeof(LY.MES.WFCL.SRPullDetectionReg.QC_PullDetectionReg);
            // 
            // ActualPullTextEdit
            // 
            this.ActualPullTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.qCPullDetectionRegBindingSource, "ActualPull", true));
            this.ActualPullTextEdit.Location = new System.Drawing.Point(317, 98);
            this.ActualPullTextEdit.MenuManager = this.barManager1;
            this.ActualPullTextEdit.Name = "ActualPullTextEdit";
            this.ActualPullTextEdit.Properties.ReadOnly = true;
            this.ActualPullTextEdit.Size = new System.Drawing.Size(181, 20);
            this.ActualPullTextEdit.StyleController = this.dataLayoutControl1;
            this.ActualPullTextEdit.TabIndex = 5;
            // 
            // ThickTextEdit
            // 
            this.ThickTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.qCPullDetectionRegBindingSource, "Thick", true));
            this.ThickTextEdit.Location = new System.Drawing.Point(281, 74);
            this.ThickTextEdit.MenuManager = this.barManager1;
            this.ThickTextEdit.Name = "ThickTextEdit";
            this.ThickTextEdit.Properties.ReadOnly = true;
            this.ThickTextEdit.Size = new System.Drawing.Size(217, 20);
            this.ThickTextEdit.StyleController = this.dataLayoutControl1;
            this.ThickTextEdit.TabIndex = 10;
            // 
            // OrderTypeTextEdit
            // 
            this.OrderTypeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.qCPullDetectionRegBindingSource, "OrderType", true));
            this.OrderTypeTextEdit.Location = new System.Drawing.Point(555, 26);
            this.OrderTypeTextEdit.MenuManager = this.barManager1;
            this.OrderTypeTextEdit.Name = "OrderTypeTextEdit";
            this.OrderTypeTextEdit.Properties.ReadOnly = true;
            this.OrderTypeTextEdit.Size = new System.Drawing.Size(193, 20);
            this.OrderTypeTextEdit.StyleController = this.dataLayoutControl1;
            this.OrderTypeTextEdit.TabIndex = 14;
            // 
            // RegDateDateEdit
            // 
            this.RegDateDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.qCPullDetectionRegBindingSource, "RegDate", true));
            this.RegDateDateEdit.EditValue = null;
            this.RegDateDateEdit.Location = new System.Drawing.Point(555, 2);
            this.RegDateDateEdit.MenuManager = this.barManager1;
            this.RegDateDateEdit.Name = "RegDateDateEdit";
            this.RegDateDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RegDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RegDateDateEdit.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
            this.RegDateDateEdit.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
            this.RegDateDateEdit.Size = new System.Drawing.Size(193, 20);
            this.RegDateDateEdit.StyleController = this.dataLayoutControl1;
            this.RegDateDateEdit.TabIndex = 18;
            // 
            // StandardPullTextEdit
            // 
            this.StandardPullTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.qCPullDetectionRegBindingSource, "StandardPull", true));
            this.StandardPullTextEdit.Location = new System.Drawing.Point(67, 98);
            this.StandardPullTextEdit.MenuManager = this.barManager1;
            this.StandardPullTextEdit.Name = "StandardPullTextEdit";
            this.StandardPullTextEdit.Properties.ReadOnly = true;
            this.StandardPullTextEdit.Size = new System.Drawing.Size(181, 20);
            this.StandardPullTextEdit.StyleController = this.dataLayoutControl1;
            this.StandardPullTextEdit.TabIndex = 19;
            // 
            // StrengthTextEdit
            // 
            this.StrengthTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.qCPullDetectionRegBindingSource, "Strength", true));
            this.StrengthTextEdit.Location = new System.Drawing.Point(531, 74);
            this.StrengthTextEdit.MenuManager = this.barManager1;
            this.StrengthTextEdit.Name = "StrengthTextEdit";
            this.StrengthTextEdit.Properties.ReadOnly = true;
            this.StrengthTextEdit.Size = new System.Drawing.Size(217, 20);
            this.StrengthTextEdit.StyleController = this.dataLayoutControl1;
            this.StrengthTextEdit.TabIndex = 20;
            // 
            // TestResultsTextEdit
            // 
            this.TestResultsTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.qCPullDetectionRegBindingSource, "TestResults", true));
            this.TestResultsTextEdit.Location = new System.Drawing.Point(555, 98);
            this.TestResultsTextEdit.MenuManager = this.barManager1;
            this.TestResultsTextEdit.Name = "TestResultsTextEdit";
            this.TestResultsTextEdit.Properties.ReadOnly = true;
            this.TestResultsTextEdit.Size = new System.Drawing.Size(193, 20);
            this.TestResultsTextEdit.StyleController = this.dataLayoutControl1;
            this.TestResultsTextEdit.TabIndex = 21;
            // 
            // WidthTextEdit
            // 
            this.WidthTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.qCPullDetectionRegBindingSource, "Width", true));
            this.WidthTextEdit.Location = new System.Drawing.Point(31, 74);
            this.WidthTextEdit.MenuManager = this.barManager1;
            this.WidthTextEdit.Name = "WidthTextEdit";
            this.WidthTextEdit.Properties.ReadOnly = true;
            this.WidthTextEdit.Size = new System.Drawing.Size(217, 20);
            this.WidthTextEdit.StyleController = this.dataLayoutControl1;
            this.WidthTextEdit.TabIndex = 22;
            // 
            // ProcessTypeSpinEdit
            // 
            this.ProcessTypeSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.qCPullDetectionRegBindingSource, "ProcessType", true));
            this.ProcessTypeSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ProcessTypeSpinEdit.Location = new System.Drawing.Point(305, 50);
            this.ProcessTypeSpinEdit.MenuManager = this.barManager1;
            this.ProcessTypeSpinEdit.Name = "ProcessTypeSpinEdit";
            this.ProcessTypeSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ProcessTypeSpinEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Item2", "Name1")});
            this.ProcessTypeSpinEdit.Properties.DisplayMember = "Item2";
            this.ProcessTypeSpinEdit.Properties.NullText = "";
            this.ProcessTypeSpinEdit.Properties.ShowHeader = false;
            this.ProcessTypeSpinEdit.Properties.ValueMember = "Item1";
            this.ProcessTypeSpinEdit.Size = new System.Drawing.Size(193, 20);
            this.ProcessTypeSpinEdit.StyleController = this.dataLayoutControl1;
            this.ProcessTypeSpinEdit.TabIndex = 15;
            // 
            // QualityInspectorTextEdit
            // 
            this.QualityInspectorTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.qCPullDetectionRegBindingSource, "QualityInspector", true));
            this.QualityInspectorTextEdit.Location = new System.Drawing.Point(293, 26);
            this.QualityInspectorTextEdit.MenuManager = this.barManager1;
            this.QualityInspectorTextEdit.Name = "QualityInspectorTextEdit";
            this.QualityInspectorTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.QualityInspectorTextEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("姓名", "Name2")});
            this.QualityInspectorTextEdit.Properties.DisplayMember = "姓名";
            this.QualityInspectorTextEdit.Properties.NullText = "";
            this.QualityInspectorTextEdit.Properties.ShowHeader = false;
            this.QualityInspectorTextEdit.Properties.ValueMember = "姓名";
            this.QualityInspectorTextEdit.Size = new System.Drawing.Size(205, 20);
            this.QualityInspectorTextEdit.StyleController = this.dataLayoutControl1;
            this.QualityInspectorTextEdit.TabIndex = 17;
            // 
            // OrderCodeTextEdit
            // 
            this.OrderCodeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.qCPullDetectionRegBindingSource, "OrderCode", true));
            this.OrderCodeTextEdit.Location = new System.Drawing.Point(43, 2);
            this.OrderCodeTextEdit.MenuManager = this.barManager1;
            this.OrderCodeTextEdit.Name = "OrderCodeTextEdit";
            this.OrderCodeTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.OrderCodeTextEdit.Properties.ReadOnly = true;
            this.OrderCodeTextEdit.Size = new System.Drawing.Size(205, 20);
            this.OrderCodeTextEdit.StyleController = this.dataLayoutControl1;
            this.OrderCodeTextEdit.TabIndex = 13;
            this.OrderCodeTextEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.OrderCodeTextEdit_ButtonClick);
            // 
            // FrequencyTextEdit
            // 
            this.FrequencyTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.qCPullDetectionRegBindingSource, "Frequency", true));
            this.FrequencyTextEdit.Location = new System.Drawing.Point(31, 26);
            this.FrequencyTextEdit.MenuManager = this.barManager1;
            this.FrequencyTextEdit.Name = "FrequencyTextEdit";
            this.FrequencyTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FrequencyTextEdit.Properties.Items.AddRange(new object[] {
            "日班",
            "中班",
            "晚班"});
            this.FrequencyTextEdit.Properties.PopupSizeable = true;
            this.FrequencyTextEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.FrequencyTextEdit.Size = new System.Drawing.Size(217, 20);
            this.FrequencyTextEdit.StyleController = this.dataLayoutControl1;
            this.FrequencyTextEdit.TabIndex = 9;
            // 
            // ProductionLineTextEdit
            // 
            this.ProductionLineTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.qCPullDetectionRegBindingSource, "ProductionLine", true));
            this.ProductionLineTextEdit.Location = new System.Drawing.Point(31, 50);
            this.ProductionLineTextEdit.MenuManager = this.barManager1;
            this.ProductionLineTextEdit.Name = "ProductionLineTextEdit";
            this.ProductionLineTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ProductionLineTextEdit.Properties.Items.AddRange(new object[] {
            "4号机A",
            "4号机B",
            "5号机A",
            "5号机B",
            "6号机A",
            "6号机B"});
            this.ProductionLineTextEdit.Properties.PopupSizeable = true;
            this.ProductionLineTextEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.ProductionLineTextEdit.Size = new System.Drawing.Size(217, 20);
            this.ProductionLineTextEdit.StyleController = this.dataLayoutControl1;
            this.ProductionLineTextEdit.TabIndex = 16;
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
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Size = new System.Drawing.Size(969, 183);
            this.Root.Text = "Root";
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.CustomizationFormText = "autoGeneratedGroup0";
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForRegDate,
            this.ItemForWidth,
            this.ItemForStrength,
            this.layoutControlGroup3,
            this.ItemForActualPull,
            this.ItemForStandardPull,
            this.ItemForFrequency,
            this.emptySpaceItem1,
            this.ItemForTestResults,
            this.ItemForThick,
            this.ItemForOrderCode,
            this.ItemForProductionLine,
            this.ItemForProductLevel,
            this.ItemForQualityInspector,
            this.ItemForProcessType,
            this.ItemForOrderType,
            this.emptySpaceItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(969, 183);
            this.layoutControlGroup2.Text = "autoGeneratedGroup0";
            // 
            // ItemForRegDate
            // 
            this.ItemForRegDate.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ItemForRegDate.AppearanceItemCaption.Options.UseForeColor = true;
            this.ItemForRegDate.Control = this.RegDateDateEdit;
            this.ItemForRegDate.CustomizationFormText = "登记日期";
            this.ItemForRegDate.Location = new System.Drawing.Point(500, 0);
            this.ItemForRegDate.Name = "ItemForRegDate";
            this.ItemForRegDate.Size = new System.Drawing.Size(250, 24);
            this.ItemForRegDate.Text = "登记日期";
            this.ItemForRegDate.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.ItemForRegDate.TextSize = new System.Drawing.Size(48, 14);
            this.ItemForRegDate.TextToControlDistance = 5;
            // 
            // ItemForWidth
            // 
            this.ItemForWidth.Control = this.WidthTextEdit;
            this.ItemForWidth.CustomizationFormText = "宽度";
            this.ItemForWidth.Location = new System.Drawing.Point(0, 72);
            this.ItemForWidth.Name = "ItemForWidth";
            this.ItemForWidth.Size = new System.Drawing.Size(250, 24);
            this.ItemForWidth.Text = "宽度";
            this.ItemForWidth.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.ItemForWidth.TextSize = new System.Drawing.Size(24, 14);
            this.ItemForWidth.TextToControlDistance = 5;
            // 
            // ItemForStrength
            // 
            this.ItemForStrength.Control = this.StrengthTextEdit;
            this.ItemForStrength.CustomizationFormText = "硬度";
            this.ItemForStrength.Location = new System.Drawing.Point(500, 72);
            this.ItemForStrength.Name = "ItemForStrength";
            this.ItemForStrength.Size = new System.Drawing.Size(250, 24);
            this.ItemForStrength.Text = "强度";
            this.ItemForStrength.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.ItemForStrength.TextSize = new System.Drawing.Size(24, 14);
            this.ItemForStrength.TextToControlDistance = 5;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "当前拉力";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemCurrPull});
            this.layoutControlGroup3.Location = new System.Drawing.Point(750, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(219, 183);
            this.layoutControlGroup3.Text = "当前拉力值";
            // 
            // ItemCurrPull
            // 
            this.ItemCurrPull.AllowHotTrack = false;
            this.ItemCurrPull.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 40F);
            this.ItemCurrPull.AppearanceItemCaption.Options.UseFont = true;
            this.ItemCurrPull.AppearanceItemCaption.Options.UseTextOptions = true;
            this.ItemCurrPull.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ItemCurrPull.CustomizationFormText = "80";
            this.ItemCurrPull.Location = new System.Drawing.Point(0, 0);
            this.ItemCurrPull.Name = "ItemCurrPull";
            this.ItemCurrPull.Size = new System.Drawing.Size(195, 139);
            this.ItemCurrPull.Text = "80";
            this.ItemCurrPull.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.ItemCurrPull.TextSize = new System.Drawing.Size(0, 0);
            this.ItemCurrPull.TextVisible = true;
            // 
            // ItemForActualPull
            // 
            this.ItemForActualPull.Control = this.ActualPullTextEdit;
            this.ItemForActualPull.CustomizationFormText = "实际拉力";
            this.ItemForActualPull.Location = new System.Drawing.Point(250, 96);
            this.ItemForActualPull.Name = "ItemForActualPull";
            this.ItemForActualPull.Size = new System.Drawing.Size(250, 24);
            this.ItemForActualPull.Text = "实际拉力值";
            this.ItemForActualPull.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.ItemForActualPull.TextSize = new System.Drawing.Size(60, 14);
            this.ItemForActualPull.TextToControlDistance = 5;
            // 
            // ItemForStandardPull
            // 
            this.ItemForStandardPull.Control = this.StandardPullTextEdit;
            this.ItemForStandardPull.CustomizationFormText = "标准拉力";
            this.ItemForStandardPull.Location = new System.Drawing.Point(0, 96);
            this.ItemForStandardPull.Name = "ItemForStandardPull";
            this.ItemForStandardPull.Size = new System.Drawing.Size(250, 24);
            this.ItemForStandardPull.Text = "标准拉力值";
            this.ItemForStandardPull.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.ItemForStandardPull.TextSize = new System.Drawing.Size(60, 14);
            this.ItemForStandardPull.TextToControlDistance = 5;
            // 
            // ItemForFrequency
            // 
            this.ItemForFrequency.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ItemForFrequency.AppearanceItemCaption.Options.UseForeColor = true;
            this.ItemForFrequency.Control = this.FrequencyTextEdit;
            this.ItemForFrequency.CustomizationFormText = "班次";
            this.ItemForFrequency.Location = new System.Drawing.Point(0, 24);
            this.ItemForFrequency.Name = "ItemForFrequency";
            this.ItemForFrequency.Size = new System.Drawing.Size(250, 24);
            this.ItemForFrequency.Text = "班次";
            this.ItemForFrequency.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.ItemForFrequency.TextSize = new System.Drawing.Size(24, 14);
            this.ItemForFrequency.TextToControlDistance = 5;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(500, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(250, 24);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ItemForTestResults
            // 
            this.ItemForTestResults.Control = this.TestResultsTextEdit;
            this.ItemForTestResults.CustomizationFormText = "检测结果";
            this.ItemForTestResults.Location = new System.Drawing.Point(500, 96);
            this.ItemForTestResults.Name = "ItemForTestResults";
            this.ItemForTestResults.Size = new System.Drawing.Size(250, 24);
            this.ItemForTestResults.Text = "检测结果";
            this.ItemForTestResults.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.ItemForTestResults.TextSize = new System.Drawing.Size(48, 14);
            this.ItemForTestResults.TextToControlDistance = 5;
            // 
            // ItemForThick
            // 
            this.ItemForThick.Control = this.ThickTextEdit;
            this.ItemForThick.CustomizationFormText = "厚度";
            this.ItemForThick.Location = new System.Drawing.Point(250, 72);
            this.ItemForThick.Name = "ItemForThick";
            this.ItemForThick.Size = new System.Drawing.Size(250, 24);
            this.ItemForThick.Text = "厚度";
            this.ItemForThick.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.ItemForThick.TextSize = new System.Drawing.Size(24, 14);
            this.ItemForThick.TextToControlDistance = 5;
            // 
            // ItemForOrderCode
            // 
            this.ItemForOrderCode.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ItemForOrderCode.AppearanceItemCaption.Options.UseForeColor = true;
            this.ItemForOrderCode.Control = this.OrderCodeTextEdit;
            this.ItemForOrderCode.CustomizationFormText = "订单号";
            this.ItemForOrderCode.Location = new System.Drawing.Point(0, 0);
            this.ItemForOrderCode.Name = "ItemForOrderCode";
            this.ItemForOrderCode.Size = new System.Drawing.Size(250, 24);
            this.ItemForOrderCode.Text = "订单号";
            this.ItemForOrderCode.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.ItemForOrderCode.TextSize = new System.Drawing.Size(36, 14);
            this.ItemForOrderCode.TextToControlDistance = 5;
            // 
            // ItemForProductionLine
            // 
            this.ItemForProductionLine.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ItemForProductionLine.AppearanceItemCaption.Options.UseForeColor = true;
            this.ItemForProductionLine.Control = this.ProductionLineTextEdit;
            this.ItemForProductionLine.CustomizationFormText = "产线";
            this.ItemForProductionLine.Location = new System.Drawing.Point(0, 48);
            this.ItemForProductionLine.Name = "ItemForProductionLine";
            this.ItemForProductionLine.Size = new System.Drawing.Size(250, 24);
            this.ItemForProductionLine.Text = "产线";
            this.ItemForProductionLine.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.ItemForProductionLine.TextSize = new System.Drawing.Size(24, 14);
            this.ItemForProductionLine.TextToControlDistance = 5;
            // 
            // ItemForProductLevel
            // 
            this.ItemForProductLevel.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ItemForProductLevel.AppearanceItemCaption.Options.UseForeColor = true;
            this.ItemForProductLevel.Control = this.ProductLevelComboBoxEdit;
            this.ItemForProductLevel.CustomizationFormText = "产品级别";
            this.ItemForProductLevel.Location = new System.Drawing.Point(250, 0);
            this.ItemForProductLevel.Name = "ItemForProductLevel";
            this.ItemForProductLevel.Size = new System.Drawing.Size(250, 24);
            this.ItemForProductLevel.Text = "产品级别";
            this.ItemForProductLevel.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.ItemForProductLevel.TextSize = new System.Drawing.Size(48, 14);
            this.ItemForProductLevel.TextToControlDistance = 5;
            // 
            // ItemForQualityInspector
            // 
            this.ItemForQualityInspector.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ItemForQualityInspector.AppearanceItemCaption.Options.UseForeColor = true;
            this.ItemForQualityInspector.Control = this.QualityInspectorTextEdit;
            this.ItemForQualityInspector.CustomizationFormText = "质检员";
            this.ItemForQualityInspector.Location = new System.Drawing.Point(250, 24);
            this.ItemForQualityInspector.Name = "ItemForQualityInspector";
            this.ItemForQualityInspector.Size = new System.Drawing.Size(250, 24);
            this.ItemForQualityInspector.Text = "质检员";
            this.ItemForQualityInspector.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.ItemForQualityInspector.TextSize = new System.Drawing.Size(36, 14);
            this.ItemForQualityInspector.TextToControlDistance = 5;
            // 
            // ItemForProcessType
            // 
            this.ItemForProcessType.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ItemForProcessType.AppearanceItemCaption.Options.UseForeColor = true;
            this.ItemForProcessType.Control = this.ProcessTypeSpinEdit;
            this.ItemForProcessType.CustomizationFormText = "处理类型";
            this.ItemForProcessType.Location = new System.Drawing.Point(250, 48);
            this.ItemForProcessType.Name = "ItemForProcessType";
            this.ItemForProcessType.Size = new System.Drawing.Size(250, 24);
            this.ItemForProcessType.Text = "处理类型";
            this.ItemForProcessType.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.ItemForProcessType.TextSize = new System.Drawing.Size(48, 14);
            this.ItemForProcessType.TextToControlDistance = 5;
            // 
            // ItemForOrderType
            // 
            this.ItemForOrderType.Control = this.OrderTypeTextEdit;
            this.ItemForOrderType.CustomizationFormText = "订单类型";
            this.ItemForOrderType.Location = new System.Drawing.Point(500, 24);
            this.ItemForOrderType.Name = "ItemForOrderType";
            this.ItemForOrderType.Size = new System.Drawing.Size(250, 24);
            this.ItemForOrderType.Text = "订单类型";
            this.ItemForOrderType.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.ItemForOrderType.TextSize = new System.Drawing.Size(48, 14);
            this.ItemForOrderType.TextToControlDistance = 5;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 120);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(750, 63);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlGroup4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(993, 511);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dataLayoutControl1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(973, 187);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.CustomizationFormText = "登记记录";
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 187);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(973, 304);
            this.layoutControlGroup4.Text = "拉力检测记录";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(949, 260);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // bgwWait
            // 
            this.bgwWait.WorkerReportsProgress = true;
            this.bgwWait.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwWait_DoWork);
            this.bgwWait.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwWait_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmPullDetectionReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 535);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmPullDetectionReg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "拉力检测登记表";
            this.Load += new System.EventHandler(this.frmPullDetectionReg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qCPullDetectionRegBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProductLevelComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qCPullDetectionRegBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActualPullTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThickTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderTypeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegDateDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegDateDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StandardPullTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrengthTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestResultsTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessTypeSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QualityInspectorTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderCodeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrequencyTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductionLineTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRegDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStrength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCurrPull)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForActualPull)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStandardPull)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTestResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForThick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOrderCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForProductionLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForProductLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForQualityInspector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForProcessType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForOrderType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private System.Windows.Forms.BindingSource qCPullDetectionRegBindingSource;
        private DevExpress.XtraEditors.TextEdit ActualPullTextEdit;
        private DevExpress.XtraEditors.TextEdit ThickTextEdit;
        private DevExpress.XtraEditors.TextEdit OrderTypeTextEdit;
        private DevExpress.XtraEditors.DateEdit RegDateDateEdit;
        private DevExpress.XtraEditors.TextEdit StandardPullTextEdit;
        private DevExpress.XtraEditors.TextEdit StrengthTextEdit;
        private DevExpress.XtraEditors.TextEdit TestResultsTextEdit;
        private DevExpress.XtraEditors.TextEdit WidthTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForActualPull;
        private DevExpress.XtraLayout.LayoutControlItem ItemForFrequency;
        private DevExpress.XtraLayout.LayoutControlItem ItemForThick;
        private DevExpress.XtraLayout.LayoutControlItem ItemForOrderCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForOrderType;
        private DevExpress.XtraLayout.LayoutControlItem ItemForProcessType;
        private DevExpress.XtraLayout.LayoutControlItem ItemForProductionLine;
        private DevExpress.XtraLayout.LayoutControlItem ItemForQualityInspector;
        private DevExpress.XtraLayout.LayoutControlItem ItemForRegDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForStandardPull;
        private DevExpress.XtraLayout.LayoutControlItem ItemForStrength;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTestResults;
        private DevExpress.XtraLayout.LayoutControlItem ItemForWidth;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraEditors.LookUpEdit ProcessTypeSpinEdit;
        private DevExpress.XtraEditors.LookUpEdit QualityInspectorTextEdit;
        private DevExpress.XtraEditors.ButtonEdit OrderCodeTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private System.Windows.Forms.BindingSource qCPullDetectionRegBindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colActualThick;
        private DevExpress.XtraGrid.Columns.GridColumn colActualPull;
        private DevExpress.XtraGrid.Columns.GridColumn colActualWidth;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoID;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatePerson;
        private DevExpress.XtraGrid.Columns.GridColumn colFrequency;
        private DevExpress.XtraGrid.Columns.GridColumn colThick;
        private DevExpress.XtraGrid.Columns.GridColumn colModifyDate;
        private DevExpress.XtraGrid.Columns.GridColumn colModifyPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderCode;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderType;
        private DevExpress.XtraGrid.Columns.GridColumn colProcessType;
        private DevExpress.XtraGrid.Columns.GridColumn colProductionLine;
        private DevExpress.XtraGrid.Columns.GridColumn colQualityInspector;
        private DevExpress.XtraGrid.Columns.GridColumn colRegDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStandardPull;
        private DevExpress.XtraGrid.Columns.GridColumn colStrength;
        private DevExpress.XtraGrid.Columns.GridColumn colTestResults;
        private DevExpress.XtraGrid.Columns.GridColumn colWidth;
        private DevExpress.XtraLayout.EmptySpaceItem ItemCurrPull;
        private System.ComponentModel.BackgroundWorker bgwWait;
        private DevExpress.XtraEditors.ComboBoxEdit FrequencyTextEdit;
        private DevExpress.XtraEditors.ComboBoxEdit ProductionLineTextEdit;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.ComboBoxEdit ProductLevelComboBoxEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForProductLevel;
        private DevExpress.XtraBars.BarButtonItem bbtniStart;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}