namespace LY.MES.WFCL.Refer
{
    partial class frmInterfaceChoose
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
            Client.Utility.Controls.Paging paging2 = new Client.Utility.Controls.Paging();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbtnEnsure = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnExit = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.deviceInterfaceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeviCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeviName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevpAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevpCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsTwoWay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSendFormat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridViewPaging1 = new Client.Utility.Controls.GridViewPaging();
            this.CheckSimpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.CheckTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.BGW1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceInterfaceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
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
            this.bbtnEnsure,
            this.bbtnExit});
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
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnEnsure),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnExit)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bbtnEnsure
            // 
            this.bbtnEnsure.Caption = "确定";
            this.bbtnEnsure.Id = 0;
            this.bbtnEnsure.Name = "bbtnEnsure";
            // 
            // bbtnExit
            // 
            this.bbtnExit.Caption = "退出";
            this.bbtnExit.Id = 1;
            this.bbtnExit.Name = "bbtnExit";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(909, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 492);
            this.barDockControlBottom.Size = new System.Drawing.Size(909, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 468);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(909, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 468);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.gridViewPaging1);
            this.layoutControl1.Controls.Add(this.CheckSimpleButton);
            this.layoutControl1.Controls.Add(this.CheckTextEdit);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 24);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(909, 468);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.deviceInterfaceBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 38);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(885, 386);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // deviceInterfaceBindingSource
            // 
            this.deviceInterfaceBindingSource.DataSource = typeof(LY.MES.WFCL.SRDevice.DeviceInterface);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDataType,
            this.colDevCode,
            this.colDeviCode,
            this.colDeviName,
            this.colDevpAddress,
            this.colDevpCode,
            this.colIsTwoWay,
            this.colRemark,
            this.colSendFormat,
            this.colUserStatus});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "设备接口参数列表";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            // 
            // colDataType
            // 
            this.colDataType.Caption = "数据类型";
            this.colDataType.FieldName = "DataType";
            this.colDataType.Name = "colDataType";
            this.colDataType.Visible = true;
            this.colDataType.VisibleIndex = 5;
            this.colDataType.Width = 64;
            // 
            // colDevCode
            // 
            this.colDevCode.Caption = "设备编码";
            this.colDevCode.FieldName = "DevCode";
            this.colDevCode.Name = "colDevCode";
            this.colDevCode.Visible = true;
            this.colDevCode.VisibleIndex = 0;
            this.colDevCode.Width = 64;
            // 
            // colDeviCode
            // 
            this.colDeviCode.Caption = "接口编码";
            this.colDeviCode.FieldName = "DeviCode";
            this.colDeviCode.Name = "colDeviCode";
            this.colDeviCode.Visible = true;
            this.colDeviCode.VisibleIndex = 1;
            this.colDeviCode.Width = 64;
            // 
            // colDeviName
            // 
            this.colDeviName.Caption = "接口名称";
            this.colDeviName.FieldName = "DeviName";
            this.colDeviName.Name = "colDeviName";
            this.colDeviName.Visible = true;
            this.colDeviName.VisibleIndex = 2;
            this.colDeviName.Width = 64;
            // 
            // colDevpAddress
            // 
            this.colDevpAddress.Caption = "接口地址";
            this.colDevpAddress.FieldName = "DevpAddress";
            this.colDevpAddress.Name = "colDevpAddress";
            this.colDevpAddress.Visible = true;
            this.colDevpAddress.VisibleIndex = 4;
            this.colDevpAddress.Width = 80;
            // 
            // colDevpCode
            // 
            this.colDevpCode.Caption = "参数编码";
            this.colDevpCode.FieldName = "DevpCode";
            this.colDevpCode.Name = "colDevpCode";
            this.colDevpCode.Visible = true;
            this.colDevpCode.VisibleIndex = 3;
            this.colDevpCode.Width = 70;
            // 
            // colIsTwoWay
            // 
            this.colIsTwoWay.Caption = "是否双向通讯";
            this.colIsTwoWay.FieldName = "IsTwoWay";
            this.colIsTwoWay.Name = "colIsTwoWay";
            this.colIsTwoWay.Visible = true;
            this.colIsTwoWay.VisibleIndex = 6;
            this.colIsTwoWay.Width = 89;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 8;
            this.colRemark.Width = 45;
            // 
            // colSendFormat
            // 
            this.colSendFormat.Caption = "发送格式";
            this.colSendFormat.FieldName = "SendFormat";
            this.colSendFormat.Name = "colSendFormat";
            this.colSendFormat.Visible = true;
            this.colSendFormat.VisibleIndex = 7;
            this.colSendFormat.Width = 45;
            // 
            // colUserStatus
            // 
            this.colUserStatus.Caption = "使用状态";
            this.colUserStatus.FieldName = "UserStatus";
            this.colUserStatus.Name = "colUserStatus";
            this.colUserStatus.Visible = true;
            this.colUserStatus.VisibleIndex = 9;
            this.colUserStatus.Width = 57;
            // 
            // gridViewPaging1
            // 
            paging2.CurrentPage = ((long)(1));
            paging2.IsPaging = true;
            paging2.PageSize = ((long)(20));
            paging2.RowCount = ((long)(0));
            this.gridViewPaging1.DataPaging = paging2;
            this.gridViewPaging1.Location = new System.Drawing.Point(12, 428);
            this.gridViewPaging1.Name = "gridViewPaging1";
            this.gridViewPaging1.Size = new System.Drawing.Size(874, 28);
            this.gridViewPaging1.TabIndex = 7;
            this.gridViewPaging1.PagingChanged += new Client.Utility.Controls.EventPagingChanged(this.gridViewPaging1_PagingChanged);
            // 
            // CheckSimpleButton
            // 
            this.CheckSimpleButton.Location = new System.Drawing.Point(645, 12);
            this.CheckSimpleButton.Name = "CheckSimpleButton";
            this.CheckSimpleButton.Size = new System.Drawing.Size(252, 22);
            this.CheckSimpleButton.StyleController = this.layoutControl1;
            this.CheckSimpleButton.TabIndex = 5;
            this.CheckSimpleButton.Text = "搜索";
            this.CheckSimpleButton.Click += new System.EventHandler(this.CheckSimpleButton_Click);
            // 
            // CheckTextEdit
            // 
            this.CheckTextEdit.Location = new System.Drawing.Point(65, 12);
            this.CheckTextEdit.MenuManager = this.barManager1;
            this.CheckTextEdit.Name = "CheckTextEdit";
            this.CheckTextEdit.Size = new System.Drawing.Size(576, 20);
            this.CheckTextEdit.StyleController = this.layoutControl1;
            this.CheckTextEdit.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(909, 468);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.CheckTextEdit;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(633, 26);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(633, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(633, 26);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "搜索条件";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.CheckSimpleButton;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(633, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(256, 26);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(889, 390);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(878, 416);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(11, 32);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(11, 32);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(11, 32);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gridViewPaging1;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 416);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(878, 32);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // BGW1
            // 
            this.BGW1.WorkerReportsProgress = true;
            this.BGW1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGW1_DoWork);
            this.BGW1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGW1_RunWorkerCompleted);
            // 
            // frmInterfaceChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 492);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmInterfaceChoose";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设备接口列表";
            this.Load += new System.EventHandler(this.frmInterfaceChoose_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceInterfaceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit CheckTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton CheckSimpleButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private Client.Utility.Controls.GridViewPaging gridViewPaging1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private System.Windows.Forms.BindingSource deviceInterfaceBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colDevCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDeviCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDeviName;
        private DevExpress.XtraGrid.Columns.GridColumn colDevpAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colDevpCode;
        private DevExpress.XtraGrid.Columns.GridColumn colIsTwoWay;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colSendFormat;
        private DevExpress.XtraGrid.Columns.GridColumn colUserStatus;
        private DevExpress.XtraBars.BarButtonItem bbtnEnsure;
        private DevExpress.XtraBars.BarButtonItem bbtnExit;
        private System.ComponentModel.BackgroundWorker BGW1;
    }
}