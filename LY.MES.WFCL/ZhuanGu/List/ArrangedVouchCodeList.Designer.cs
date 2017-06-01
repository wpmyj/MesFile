namespace LY.MES.WFCL.ZhuanGu.List
{
    partial class ArrangedVouchCodeList
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
            this.bt_Search = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gv_ArrangedVouchCode = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colArrangedVouchCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFormulaCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFormulaName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInputWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInterruptionRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInterruptionTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLicenseNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterialVouchCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModifyPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModifyTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutputWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProPlanNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRFIDCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTeachProgress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVehicleWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVouchDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVouchType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeighingPounds = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeightMan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.te_Date = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lb_Date = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.bgWait = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_ArrangedVouchCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Date.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_Date)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridViewPaging1);
            this.layoutControl1.Controls.Add(this.bt_Search);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.te_Date);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(454, 157, 507, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(648, 350);
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
            this.gridViewPaging1.Location = new System.Drawing.Point(12, 313);
            this.gridViewPaging1.MaximumSize = new System.Drawing.Size(0, 27);
            this.gridViewPaging1.Name = "gridViewPaging1";
            this.gridViewPaging1.Size = new System.Drawing.Size(624, 25);
            this.gridViewPaging1.TabIndex = 7;
            this.gridViewPaging1.PagingChanged += new Client.Utility.Controls.EventPagingChanged(this.gridViewPaging1_PagingChanged);
            // 
            // bt_Search
            // 
            this.bt_Search.Location = new System.Drawing.Point(444, 12);
            this.bt_Search.Name = "bt_Search";
            this.bt_Search.Size = new System.Drawing.Size(192, 22);
            this.bt_Search.StyleController = this.layoutControl1;
            this.bt_Search.TabIndex = 6;
            this.bt_Search.Text = "搜索";
            this.bt_Search.Click += new System.EventHandler(this.bt_Search_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.bindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 38);
            this.gridControl1.MainView = this.gv_ArrangedVouchCode;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(624, 271);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_ArrangedVouchCode});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(LY.MES.WFCL.SRArrangedVouch.ArrangedVouch);
            // 
            // gv_ArrangedVouchCode
            // 
            this.gv_ArrangedVouchCode.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colArrangedVouchCode,
            this.colCreateTime,
            this.colCreator,
            this.colFormulaCode,
            this.colFormulaName,
            this.colID,
            this.colInputWeight,
            this.colInterruptionRemark,
            this.colInterruptionTime,
            this.colLicenseNum,
            this.colMaterialVouchCode,
            this.colModifyPerson,
            this.colModifyTime,
            this.colOutputWeight,
            this.colProPlanNum,
            this.colRFIDCode,
            this.colTeachProgress,
            this.colUserStatus,
            this.colVehicleWeight,
            this.colVouchDate,
            this.colVouchType,
            this.colWeighingPounds,
            this.colWeightMan});
            this.gv_ArrangedVouchCode.GridControl = this.gridControl1;
            this.gv_ArrangedVouchCode.Name = "gv_ArrangedVouchCode";
            this.gv_ArrangedVouchCode.OptionsBehavior.Editable = false;
            this.gv_ArrangedVouchCode.OptionsView.ShowGroupPanel = false;
            this.gv_ArrangedVouchCode.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colUserStatus, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colArrangedVouchCode
            // 
            this.colArrangedVouchCode.Caption = "排配单号";
            this.colArrangedVouchCode.FieldName = "ArrangedVouchCode";
            this.colArrangedVouchCode.Name = "colArrangedVouchCode";
            this.colArrangedVouchCode.Visible = true;
            this.colArrangedVouchCode.VisibleIndex = 0;
            this.colArrangedVouchCode.Width = 159;
            // 
            // colCreateTime
            // 
            this.colCreateTime.Caption = "创建时间";
            this.colCreateTime.FieldName = "CreateTime";
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.Visible = true;
            this.colCreateTime.VisibleIndex = 1;
            this.colCreateTime.Width = 151;
            // 
            // colCreator
            // 
            this.colCreator.Caption = "创建者";
            this.colCreator.FieldName = "Creator";
            this.colCreator.Name = "colCreator";
            this.colCreator.Visible = true;
            this.colCreator.VisibleIndex = 2;
            this.colCreator.Width = 173;
            // 
            // colFormulaCode
            // 
            this.colFormulaCode.Caption = "配方编码";
            this.colFormulaCode.FieldName = "FormulaCode";
            this.colFormulaCode.Name = "colFormulaCode";
            this.colFormulaCode.Visible = true;
            this.colFormulaCode.VisibleIndex = 3;
            this.colFormulaCode.Width = 203;
            // 
            // colFormulaName
            // 
            this.colFormulaName.Caption = "配方名称";
            this.colFormulaName.FieldName = "FormulaName";
            this.colFormulaName.Name = "colFormulaName";
            this.colFormulaName.Visible = true;
            this.colFormulaName.VisibleIndex = 4;
            this.colFormulaName.Width = 168;
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Width = 85;
            // 
            // colInputWeight
            // 
            this.colInputWeight.FieldName = "InputWeight";
            this.colInputWeight.Name = "colInputWeight";
            this.colInputWeight.Width = 81;
            // 
            // colInterruptionRemark
            // 
            this.colInterruptionRemark.FieldName = "InterruptionRemark";
            this.colInterruptionRemark.Name = "colInterruptionRemark";
            this.colInterruptionRemark.Width = 118;
            // 
            // colInterruptionTime
            // 
            this.colInterruptionTime.FieldName = "InterruptionTime";
            this.colInterruptionTime.Name = "colInterruptionTime";
            this.colInterruptionTime.Width = 92;
            // 
            // colLicenseNum
            // 
            this.colLicenseNum.FieldName = "LicenseNum";
            this.colLicenseNum.Name = "colLicenseNum";
            this.colLicenseNum.Width = 124;
            // 
            // colMaterialVouchCode
            // 
            this.colMaterialVouchCode.FieldName = "MaterialVouchCode";
            this.colMaterialVouchCode.Name = "colMaterialVouchCode";
            this.colMaterialVouchCode.Width = 132;
            // 
            // colModifyPerson
            // 
            this.colModifyPerson.FieldName = "ModifyPerson";
            this.colModifyPerson.Name = "colModifyPerson";
            this.colModifyPerson.Width = 99;
            // 
            // colModifyTime
            // 
            this.colModifyTime.FieldName = "ModifyTime";
            this.colModifyTime.Name = "colModifyTime";
            this.colModifyTime.Width = 53;
            // 
            // colOutputWeight
            // 
            this.colOutputWeight.FieldName = "OutputWeight";
            this.colOutputWeight.Name = "colOutputWeight";
            this.colOutputWeight.Width = 103;
            // 
            // colProPlanNum
            // 
            this.colProPlanNum.FieldName = "ProPlanNum";
            this.colProPlanNum.Name = "colProPlanNum";
            this.colProPlanNum.Width = 99;
            // 
            // colRFIDCode
            // 
            this.colRFIDCode.FieldName = "RFIDCode";
            this.colRFIDCode.Name = "colRFIDCode";
            this.colRFIDCode.Width = 97;
            // 
            // colTeachProgress
            // 
            this.colTeachProgress.FieldName = "TeachProgress";
            this.colTeachProgress.Name = "colTeachProgress";
            this.colTeachProgress.Width = 65;
            // 
            // colUserStatus
            // 
            this.colUserStatus.Caption = "状态";
            this.colUserStatus.FieldName = "UserStatus";
            this.colUserStatus.Name = "colUserStatus";
            this.colUserStatus.Visible = true;
            this.colUserStatus.VisibleIndex = 5;
            this.colUserStatus.Width = 139;
            // 
            // colVehicleWeight
            // 
            this.colVehicleWeight.FieldName = "VehicleWeight";
            this.colVehicleWeight.Name = "colVehicleWeight";
            this.colVehicleWeight.Width = 62;
            // 
            // colVouchDate
            // 
            this.colVouchDate.FieldName = "VouchDate";
            this.colVouchDate.Name = "colVouchDate";
            this.colVouchDate.Width = 20;
            // 
            // colVouchType
            // 
            this.colVouchType.FieldName = "VouchType";
            this.colVouchType.Name = "colVouchType";
            this.colVouchType.Width = 20;
            // 
            // colWeighingPounds
            // 
            this.colWeighingPounds.FieldName = "WeighingPounds";
            this.colWeighingPounds.Name = "colWeighingPounds";
            this.colWeighingPounds.Width = 20;
            // 
            // colWeightMan
            // 
            this.colWeightMan.FieldName = "WeightMan";
            this.colWeightMan.Name = "colWeightMan";
            this.colWeightMan.Width = 20;
            // 
            // te_Date
            // 
            this.te_Date.EditValue = null;
            this.te_Date.Location = new System.Drawing.Point(65, 12);
            this.te_Date.Name = "te_Date";
            this.te_Date.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.te_Date.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.te_Date.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
            this.te_Date.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
            this.te_Date.Properties.Mask.EditMask = "";
            this.te_Date.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.te_Date.Size = new System.Drawing.Size(375, 20);
            this.te_Date.StyleController = this.layoutControl1;
            this.te_Date.TabIndex = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.lb_Date,
            this.layoutControlItem3,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(648, 350);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(628, 275);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // lb_Date
            // 
            this.lb_Date.Control = this.te_Date;
            this.lb_Date.CustomizationFormText = "日期时间";
            this.lb_Date.Location = new System.Drawing.Point(0, 0);
            this.lb_Date.Name = "lb_Date";
            this.lb_Date.Size = new System.Drawing.Size(432, 26);
            this.lb_Date.Text = "日期时间";
            this.lb_Date.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lb_Date.TextSize = new System.Drawing.Size(48, 14);
            this.lb_Date.TextToControlDistance = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.bt_Search;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(432, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(196, 26);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridViewPaging1;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 301);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(628, 29);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // bgWait
            // 
            this.bgWait.WorkerReportsProgress = true;
            this.bgWait.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWait_DoWork);
            this.bgWait.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWait_RunWorkerCompleted);
            // 
            // ArrangedVouchCodeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 350);
            this.Controls.Add(this.layoutControl1);
            this.Name = "ArrangedVouchCodeList";
            this.Text = "排配单号列表";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_ArrangedVouchCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Date.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_Date)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton bt_Search;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_ArrangedVouchCode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem lb_Date;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.ComponentModel.BackgroundWorker bgWait;
        private DevExpress.XtraEditors.DateEdit te_Date;
        private Client.Utility.Controls.GridViewPaging gridViewPaging1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colArrangedVouchCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colCreator;
        private DevExpress.XtraGrid.Columns.GridColumn colFormulaCode;
        private DevExpress.XtraGrid.Columns.GridColumn colFormulaName;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colInputWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colInterruptionRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colInterruptionTime;
        private DevExpress.XtraGrid.Columns.GridColumn colLicenseNum;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialVouchCode;
        private DevExpress.XtraGrid.Columns.GridColumn colModifyPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colModifyTime;
        private DevExpress.XtraGrid.Columns.GridColumn colOutputWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colProPlanNum;
        private DevExpress.XtraGrid.Columns.GridColumn colRFIDCode;
        private DevExpress.XtraGrid.Columns.GridColumn colTeachProgress;
        private DevExpress.XtraGrid.Columns.GridColumn colUserStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colVehicleWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colVouchDate;
        private DevExpress.XtraGrid.Columns.GridColumn colVouchType;
        private DevExpress.XtraGrid.Columns.GridColumn colWeighingPounds;
        private DevExpress.XtraGrid.Columns.GridColumn colWeightMan;
    }
}