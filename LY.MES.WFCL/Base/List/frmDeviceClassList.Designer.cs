namespace LY.MES.WFCL.Base.List
{
    partial class frmDeviceClassList
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tvDevClass = new System.Windows.Forms.TreeView();
            this.cmsTreeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddChildren = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.DevCCodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.deviceClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bmTool = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbtniAdd = new DevExpress.XtraBars.BarButtonItem();
            this.bbtniSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbtniDel = new DevExpress.XtraBars.BarButtonItem();
            this.bbtniExit = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.DevCNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.SupCCodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.RemarkTextEdit = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForDevCCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDevCName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForRemark = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.ItemForSupCCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.bgwWait = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.cmsTreeMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DevCCodeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceClassBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmTool)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DevCNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupCCodeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemarkTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDevCCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDevCName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSupCCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.splitContainerControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 24);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(487, 301, 466, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(681, 403);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Location = new System.Drawing.Point(7, 7);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.tvDevClass);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.dataLayoutControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(667, 389);
            this.splitContainerControl1.SplitterPosition = 164;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // tvDevClass
            // 
            this.tvDevClass.ContextMenuStrip = this.cmsTreeMenu;
            this.tvDevClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDevClass.Location = new System.Drawing.Point(0, 0);
            this.tvDevClass.Name = "tvDevClass";
            this.tvDevClass.Size = new System.Drawing.Size(164, 389);
            this.tvDevClass.TabIndex = 0;
            this.tvDevClass.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDevClass_AfterSelect);
            // 
            // cmsTreeMenu
            // 
            this.cmsTreeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddChildren,
            this.toolStripComboBox1});
            this.cmsTreeMenu.Name = "cmsTreeMenu";
            this.cmsTreeMenu.Size = new System.Drawing.Size(182, 77);
            this.cmsTreeMenu.Opening += new System.ComponentModel.CancelEventHandler(this.cmsTreeMenu_Opening);
            // 
            // tsmiAddChildren
            // 
            this.tsmiAddChildren.Name = "tsmiAddChildren";
            this.tsmiAddChildren.Size = new System.Drawing.Size(181, 22);
            this.tsmiAddChildren.Text = "增加下级";
            this.tsmiAddChildren.Click += new System.EventHandler(this.tsmiAddChildren_Click);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.DevCCodeTextEdit);
            this.dataLayoutControl1.Controls.Add(this.DevCNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.SupCCodeTextEdit);
            this.dataLayoutControl1.Controls.Add(this.RemarkTextEdit);
            this.dataLayoutControl1.DataSource = this.deviceClassBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(730, 226, 250, 350);
            this.dataLayoutControl1.Root = this.layoutControlGroup2;
            this.dataLayoutControl1.Size = new System.Drawing.Size(498, 389);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // DevCCodeTextEdit
            // 
            this.DevCCodeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.deviceClassBindingSource, "DevCCode", true));
            this.DevCCodeTextEdit.Location = new System.Drawing.Point(84, 7);
            this.DevCCodeTextEdit.MenuManager = this.bmTool;
            this.DevCCodeTextEdit.Name = "DevCCodeTextEdit";
            this.DevCCodeTextEdit.Size = new System.Drawing.Size(407, 20);
            this.DevCCodeTextEdit.StyleController = this.dataLayoutControl1;
            this.DevCCodeTextEdit.TabIndex = 4;
            // 
            // deviceClassBindingSource
            // 
            this.deviceClassBindingSource.DataSource = typeof(LY.MES.WFCL.SRDevice.DeviceClass);
            // 
            // bmTool
            // 
            this.bmTool.AllowMoveBarOnToolbar = false;
            this.bmTool.AllowQuickCustomization = false;
            this.bmTool.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.bmTool.DockControls.Add(this.barDockControlTop);
            this.bmTool.DockControls.Add(this.barDockControlBottom);
            this.bmTool.DockControls.Add(this.barDockControlLeft);
            this.bmTool.DockControls.Add(this.barDockControlRight);
            this.bmTool.Form = this;
            this.bmTool.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbtniSave,
            this.bbtniDel,
            this.bbtniExit,
            this.bbtniAdd});
            this.bmTool.MainMenu = this.bar2;
            this.bmTool.MaxItemId = 4;
            this.bmTool.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bmTool_ItemClick);
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
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtniDel),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtniExit)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bbtniAdd
            // 
            this.bbtniAdd.Caption = "新增";
            this.bbtniAdd.Id = 3;
            this.bbtniAdd.Name = "bbtniAdd";
            // 
            // bbtniSave
            // 
            this.bbtniSave.Caption = "保存";
            this.bbtniSave.Id = 0;
            this.bbtniSave.Name = "bbtniSave";
            // 
            // bbtniDel
            // 
            this.bbtniDel.Caption = "删除";
            this.bbtniDel.Id = 1;
            this.bbtniDel.Name = "bbtniDel";
            // 
            // bbtniExit
            // 
            this.bbtniExit.Caption = "退出";
            this.bbtniExit.Id = 2;
            this.bbtniExit.Name = "bbtniExit";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(681, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 427);
            this.barDockControlBottom.Size = new System.Drawing.Size(681, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 403);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(681, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 403);
            // 
            // DevCNameTextEdit
            // 
            this.DevCNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.deviceClassBindingSource, "DevCName", true));
            this.DevCNameTextEdit.Location = new System.Drawing.Point(84, 31);
            this.DevCNameTextEdit.MenuManager = this.bmTool;
            this.DevCNameTextEdit.Name = "DevCNameTextEdit";
            this.DevCNameTextEdit.Size = new System.Drawing.Size(407, 20);
            this.DevCNameTextEdit.StyleController = this.dataLayoutControl1;
            this.DevCNameTextEdit.TabIndex = 5;
            // 
            // SupCCodeTextEdit
            // 
            this.SupCCodeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.deviceClassBindingSource, "SupCCode", true));
            this.SupCCodeTextEdit.Location = new System.Drawing.Point(84, 55);
            this.SupCCodeTextEdit.MenuManager = this.bmTool;
            this.SupCCodeTextEdit.Name = "SupCCodeTextEdit";
            this.SupCCodeTextEdit.Properties.ReadOnly = true;
            this.SupCCodeTextEdit.Size = new System.Drawing.Size(407, 20);
            this.SupCCodeTextEdit.StyleController = this.dataLayoutControl1;
            this.SupCCodeTextEdit.TabIndex = 7;
            // 
            // RemarkTextEdit
            // 
            this.RemarkTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.deviceClassBindingSource, "Remark", true));
            this.RemarkTextEdit.Location = new System.Drawing.Point(84, 79);
            this.RemarkTextEdit.MenuManager = this.bmTool;
            this.RemarkTextEdit.Name = "RemarkTextEdit";
            this.RemarkTextEdit.Size = new System.Drawing.Size(407, 118);
            this.RemarkTextEdit.StyleController = this.dataLayoutControl1;
            this.RemarkTextEdit.TabIndex = 6;
            this.RemarkTextEdit.UseOptimizedRendering = true;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup3});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup2.Size = new System.Drawing.Size(498, 389);
            this.layoutControlGroup2.Text = "layoutControlGroup2";
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.AllowDrawBackground = false;
            this.layoutControlGroup3.CustomizationFormText = "autoGeneratedGroup0";
            this.layoutControlGroup3.GroupBordersVisible = false;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForDevCCode,
            this.ItemForDevCName,
            this.ItemForRemark,
            this.emptySpaceItem1,
            this.ItemForSupCCode});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "autoGeneratedGroup0";
            this.layoutControlGroup3.Size = new System.Drawing.Size(488, 379);
            this.layoutControlGroup3.Text = "autoGeneratedGroup0";
            // 
            // ItemForDevCCode
            // 
            this.ItemForDevCCode.Control = this.DevCCodeTextEdit;
            this.ItemForDevCCode.CustomizationFormText = "设备分类编码";
            this.ItemForDevCCode.Location = new System.Drawing.Point(0, 0);
            this.ItemForDevCCode.Name = "ItemForDevCCode";
            this.ItemForDevCCode.Size = new System.Drawing.Size(488, 24);
            this.ItemForDevCCode.Text = "设备分类编码";
            this.ItemForDevCCode.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.ItemForDevCCode.TextSize = new System.Drawing.Size(72, 14);
            this.ItemForDevCCode.TextToControlDistance = 5;
            // 
            // ItemForDevCName
            // 
            this.ItemForDevCName.Control = this.DevCNameTextEdit;
            this.ItemForDevCName.CustomizationFormText = "设备分类名称";
            this.ItemForDevCName.Location = new System.Drawing.Point(0, 24);
            this.ItemForDevCName.Name = "ItemForDevCName";
            this.ItemForDevCName.Size = new System.Drawing.Size(488, 24);
            this.ItemForDevCName.Text = "设备分类名称";
            this.ItemForDevCName.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.ItemForDevCName.TextSize = new System.Drawing.Size(72, 14);
            this.ItemForDevCName.TextToControlDistance = 5;
            // 
            // ItemForRemark
            // 
            this.ItemForRemark.Control = this.RemarkTextEdit;
            this.ItemForRemark.CustomizationFormText = "  备      注    ";
            this.ItemForRemark.Location = new System.Drawing.Point(0, 72);
            this.ItemForRemark.Name = "ItemForRemark";
            this.ItemForRemark.Size = new System.Drawing.Size(488, 122);
            this.ItemForRemark.Text = "  备      注    ";
            this.ItemForRemark.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.ItemForRemark.TextSize = new System.Drawing.Size(72, 14);
            this.ItemForRemark.TextToControlDistance = 5;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 194);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(488, 185);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ItemForSupCCode
            // 
            this.ItemForSupCCode.Control = this.SupCCodeTextEdit;
            this.ItemForSupCCode.CustomizationFormText = "上级分类编码";
            this.ItemForSupCCode.Location = new System.Drawing.Point(0, 48);
            this.ItemForSupCCode.Name = "ItemForSupCCode";
            this.ItemForSupCCode.Size = new System.Drawing.Size(488, 24);
            this.ItemForSupCCode.Text = "上级分类编码";
            this.ItemForSupCCode.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.ItemForSupCCode.TextSize = new System.Drawing.Size(72, 14);
            this.ItemForSupCCode.TextToControlDistance = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup1.Size = new System.Drawing.Size(681, 403);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.splitContainerControl1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(671, 393);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // bgwWait
            // 
            this.bgwWait.WorkerReportsProgress = true;
            this.bgwWait.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwWait_DoWork);
            this.bgwWait.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwWait_RunWorkerCompleted);
            // 
            // frmDeviceClassList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 427);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmDeviceClassList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设备分类";
            this.Load += new System.EventHandler(this.frmDeviceClassList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.cmsTreeMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DevCCodeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceClassBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmTool)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DevCNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupCCodeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemarkTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDevCCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDevCName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSupCCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraBars.BarManager bmTool;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.TreeView tvDevClass;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.TextEdit DevCCodeTextEdit;
        private System.Windows.Forms.BindingSource deviceClassBindingSource;
        private DevExpress.XtraEditors.TextEdit DevCNameTextEdit;
        private DevExpress.XtraEditors.TextEdit SupCCodeTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDevCCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDevCName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForRemark;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSupCCode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.MemoEdit RemarkTextEdit;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraBars.BarButtonItem bbtniSave;
        private DevExpress.XtraBars.BarButtonItem bbtniDel;
        private DevExpress.XtraBars.BarButtonItem bbtniExit;
        private System.ComponentModel.BackgroundWorker bgwWait;
        private DevExpress.XtraBars.BarButtonItem bbtniAdd;
        private System.Windows.Forms.ContextMenuStrip cmsTreeMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddChildren;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
    }
}