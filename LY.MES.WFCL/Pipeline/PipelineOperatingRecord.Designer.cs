namespace LY.MES.WFCL.Pipeline
{
    partial class PipelineOperatingRecord
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.mainPipelineInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAutoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeveCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeveName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFrequency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOperatingTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOperator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOperatorReamrk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPipelineStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPromptDes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btn_Search = new DevExpress.XtraEditors.SimpleButton();
            this.te_CheckEndTime = new DevExpress.XtraEditors.DateEdit();
            this.te_CheckStartTime = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPipelineInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_CheckEndTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_CheckEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_CheckStartTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_CheckStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridViewPaging1);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.btn_Search);
            this.layoutControl1.Controls.Add(this.te_CheckEndTime);
            this.layoutControl1.Controls.Add(this.te_CheckStartTime);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(423, 309, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(943, 502);
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
            this.gridViewPaging1.Location = new System.Drawing.Point(24, 451);
            this.gridViewPaging1.MaximumSize = new System.Drawing.Size(0, 27);
            this.gridViewPaging1.Name = "gridViewPaging1";
            this.gridViewPaging1.Size = new System.Drawing.Size(895, 27);
            this.gridViewPaging1.TabIndex = 8;
            this.gridViewPaging1.PagingChanged += new Client.Utility.Controls.EventPagingChanged(this.gridViewPaging1_PagingChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.mainPipelineInfoBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(24, 114);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(895, 333);
            this.gridControl1.TabIndex = 7;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // mainPipelineInfoBindingSource
            // 
            this.mainPipelineInfoBindingSource.DataSource = typeof(LY.MES.WFCL.SRPiPeline.MainPipelineInfo);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAutoID,
            this.colCreateDate,
            this.colCreator,
            this.colDeveCode,
            this.colDeveName,
            this.colFrequency,
            this.colOperatingTime,
            this.colOperator,
            this.colOperatorReamrk,
            this.colPipelineStatus,
            this.colPromptDes});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colAutoID
            // 
            this.colAutoID.Caption = "自动编号";
            this.colAutoID.FieldName = "AutoID";
            this.colAutoID.Name = "colAutoID";
            this.colAutoID.Visible = true;
            this.colAutoID.VisibleIndex = 0;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Caption = "创建时间";
            this.colCreateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCreateDate.FieldName = "CreateDate";
            this.colCreateDate.Name = "colCreateDate";
            this.colCreateDate.Visible = true;
            this.colCreateDate.VisibleIndex = 10;
            // 
            // colCreator
            // 
            this.colCreator.Caption = "创建人";
            this.colCreator.FieldName = "Creator";
            this.colCreator.Name = "colCreator";
            this.colCreator.Visible = true;
            this.colCreator.VisibleIndex = 9;
            // 
            // colDeveCode
            // 
            this.colDeveCode.Caption = "管道编号";
            this.colDeveCode.FieldName = "DeveCode";
            this.colDeveCode.Name = "colDeveCode";
            this.colDeveCode.Visible = true;
            this.colDeveCode.VisibleIndex = 1;
            // 
            // colDeveName
            // 
            this.colDeveName.Caption = "管道名称";
            this.colDeveName.FieldName = "DeveName";
            this.colDeveName.Name = "colDeveName";
            this.colDeveName.Visible = true;
            this.colDeveName.VisibleIndex = 2;
            // 
            // colFrequency
            // 
            this.colFrequency.Caption = "班次";
            this.colFrequency.FieldName = "Frequency";
            this.colFrequency.Name = "colFrequency";
            this.colFrequency.Visible = true;
            this.colFrequency.VisibleIndex = 6;
            // 
            // colOperatingTime
            // 
            this.colOperatingTime.Caption = "操作时间";
            this.colOperatingTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOperatingTime.FieldName = "OperatingTime";
            this.colOperatingTime.Name = "colOperatingTime";
            this.colOperatingTime.OptionsFilter.ShowEmptyDateFilter = true;
            this.colOperatingTime.Visible = true;
            this.colOperatingTime.VisibleIndex = 8;
            // 
            // colOperator
            // 
            this.colOperator.Caption = "操作人";
            this.colOperator.FieldName = "Operator";
            this.colOperator.Name = "colOperator";
            this.colOperator.Visible = true;
            this.colOperator.VisibleIndex = 7;
            // 
            // colOperatorReamrk
            // 
            this.colOperatorReamrk.Caption = "操作说明";
            this.colOperatorReamrk.FieldName = "OperatorReamrk";
            this.colOperatorReamrk.Name = "colOperatorReamrk";
            this.colOperatorReamrk.Visible = true;
            this.colOperatorReamrk.VisibleIndex = 3;
            // 
            // colPipelineStatus
            // 
            this.colPipelineStatus.Caption = "管道阀门状态";
            this.colPipelineStatus.FieldName = "PipelineStatus";
            this.colPipelineStatus.Name = "colPipelineStatus";
            this.colPipelineStatus.Visible = true;
            this.colPipelineStatus.VisibleIndex = 4;
            // 
            // colPromptDes
            // 
            this.colPromptDes.Caption = "提示说明";
            this.colPromptDes.FieldName = "PromptDes";
            this.colPromptDes.Name = "colPromptDes";
            this.colPromptDes.Visible = true;
            this.colPromptDes.VisibleIndex = 5;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(621, 44);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(202, 22);
            this.btn_Search.StyleController = this.layoutControl1;
            this.btn_Search.TabIndex = 6;
            this.btn_Search.Text = "搜索";
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // te_CheckEndTime
            // 
            this.te_CheckEndTime.EditValue = null;
            this.te_CheckEndTime.Location = new System.Drawing.Point(379, 44);
            this.te_CheckEndTime.Name = "te_CheckEndTime";
            this.te_CheckEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.te_CheckEndTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.te_CheckEndTime.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
            this.te_CheckEndTime.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
            this.te_CheckEndTime.Size = new System.Drawing.Size(238, 20);
            this.te_CheckEndTime.StyleController = this.layoutControl1;
            this.te_CheckEndTime.TabIndex = 5;
            // 
            // te_CheckStartTime
            // 
            this.te_CheckStartTime.EditValue = null;
            this.te_CheckStartTime.Location = new System.Drawing.Point(99, 44);
            this.te_CheckStartTime.Name = "te_CheckStartTime";
            this.te_CheckStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.te_CheckStartTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.te_CheckStartTime.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
            this.te_CheckStartTime.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
            this.te_CheckStartTime.Size = new System.Drawing.Size(201, 20);
            this.te_CheckStartTime.StyleController = this.layoutControl1;
            this.te_CheckStartTime.TabIndex = 4;
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(943, 502);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "收索条件";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(923, 70);
            this.layoutControlGroup2.Text = "搜索条件";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.te_CheckStartTime;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(280, 26);
            this.layoutControlItem1.Text = "查询起始日期";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.te_CheckEndTime;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(280, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(317, 26);
            this.layoutControlItem2.Text = "查询结束日期";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btn_Search;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(597, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(206, 26);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(803, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(96, 26);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "主管道操作历史记录";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 70);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(923, 412);
            this.layoutControlGroup3.Text = "主管道操作历史记录";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gridControl1;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(899, 337);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.gridViewPaging1;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 337);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(899, 31);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // PipelineOperatingRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 502);
            this.Controls.Add(this.layoutControl1);
            this.Name = "PipelineOperatingRecord";
            this.Text = "主管道操作记录";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPipelineInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_CheckEndTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_CheckEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_CheckStartTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_CheckStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btn_Search;
        private DevExpress.XtraEditors.DateEdit te_CheckEndTime;
        private DevExpress.XtraEditors.DateEdit te_CheckStartTime;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private Client.Utility.Controls.GridViewPaging gridViewPaging1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource mainPipelineInfoBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoID;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCreator;
        private DevExpress.XtraGrid.Columns.GridColumn colDeveCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDeveName;
        private DevExpress.XtraGrid.Columns.GridColumn colFrequency;
        private DevExpress.XtraGrid.Columns.GridColumn colOperatingTime;
        private DevExpress.XtraGrid.Columns.GridColumn colOperator;
        private DevExpress.XtraGrid.Columns.GridColumn colOperatorReamrk;
        private DevExpress.XtraGrid.Columns.GridColumn colPipelineStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colPromptDes;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}