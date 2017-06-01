namespace LY.MES.WFCL.Base.Frm
{
    partial class frmUserList
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.bt_Search = new DevExpress.XtraEditors.SimpleButton();
            this.te_UserCode = new DevExpress.XtraEditors.TextEdit();
            this.te_UserName = new DevExpress.XtraEditors.TextEdit();
            this.gcUser = new DevExpress.XtraGrid.GridControl();
            this.UserbindingSource = new System.Windows.Forms.BindingSource();
            this.gvUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colcUserCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.bgWait = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.te_UserCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_UserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.bt_Search);
            this.layoutControl1.Controls.Add(this.te_UserCode);
            this.layoutControl1.Controls.Add(this.te_UserName);
            this.layoutControl1.Controls.Add(this.gcUser);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(479, 320);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // bt_Search
            // 
            this.bt_Search.Location = new System.Drawing.Point(343, 44);
            this.bt_Search.Name = "bt_Search";
            this.bt_Search.Size = new System.Drawing.Size(112, 22);
            this.bt_Search.StyleController = this.layoutControl1;
            this.bt_Search.TabIndex = 7;
            this.bt_Search.Text = "搜索";
            this.bt_Search.Click += new System.EventHandler(this.bt_Search_Click);
            // 
            // te_UserCode
            // 
            this.te_UserCode.Location = new System.Drawing.Point(75, 44);
            this.te_UserCode.Name = "te_UserCode";
            this.te_UserCode.Size = new System.Drawing.Size(98, 20);
            this.te_UserCode.StyleController = this.layoutControl1;
            this.te_UserCode.TabIndex = 6;
            // 
            // te_UserName
            // 
            this.te_UserName.Location = new System.Drawing.Point(228, 44);
            this.te_UserName.Name = "te_UserName";
            this.te_UserName.Size = new System.Drawing.Size(111, 20);
            this.te_UserName.StyleController = this.layoutControl1;
            this.te_UserName.TabIndex = 5;
            // 
            // gcUser
            // 
            this.gcUser.DataSource = this.UserbindingSource;
            this.gcUser.Location = new System.Drawing.Point(12, 82);
            this.gcUser.MainView = this.gvUser;
            this.gcUser.Name = "gcUser";
            this.gcUser.Size = new System.Drawing.Size(455, 226);
            this.gcUser.TabIndex = 4;
            this.gcUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUser});
            this.gcUser.DoubleClick += new System.EventHandler(this.gcUser_DoubleClick);
            // 
            // UserbindingSource
            // 
            this.UserbindingSource.DataSource = typeof(Client.Utility.SRSysBase.User);
            // 
            // gvUser
            // 
            this.gvUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colcUserCode,
            this.colcUserName});
            this.gvUser.GridControl = this.gcUser;
            this.gvUser.Name = "gvUser";
            this.gvUser.OptionsBehavior.Editable = false;
            this.gvUser.OptionsView.ShowGroupPanel = false;
            // 
            // colcUserCode
            // 
            this.colcUserCode.Caption = "用户编码";
            this.colcUserCode.FieldName = "cUserCode";
            this.colcUserCode.Name = "colcUserCode";
            this.colcUserCode.Visible = true;
            this.colcUserCode.VisibleIndex = 0;
            // 
            // colcUserName
            // 
            this.colcUserName.Caption = "用户名";
            this.colcUserName.FieldName = "cUserName";
            this.colcUserName.Name = "colcUserName";
            this.colcUserName.Visible = true;
            this.colcUserName.VisibleIndex = 1;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(479, 320);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcUser;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 70);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(459, 230);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(459, 70);
            this.layoutControlGroup2.Text = "搜索条件";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.te_UserName;
            this.layoutControlItem2.CustomizationFormText = "用户姓名";
            this.layoutControlItem2.Location = new System.Drawing.Point(153, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(166, 26);
            this.layoutControlItem2.Text = "用户姓名";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.te_UserCode;
            this.layoutControlItem3.CustomizationFormText = "用户编码";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(153, 26);
            this.layoutControlItem3.Text = "用户编码";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.bt_Search;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(319, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(116, 26);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // bgWait
            // 
            this.bgWait.WorkerReportsProgress = true;
            this.bgWait.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWait_DoWork);
            this.bgWait.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWait_RunWorkerCompleted);
            // 
            // frmUserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 320);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmUserList";
            this.Text = "用户列表";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.te_UserCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_UserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton bt_Search;
        private DevExpress.XtraEditors.TextEdit te_UserCode;
        private DevExpress.XtraEditors.TextEdit te_UserName;
        private DevExpress.XtraGrid.GridControl gcUser;
        private System.Windows.Forms.BindingSource UserbindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUser;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private System.ComponentModel.BackgroundWorker bgWait;
        private DevExpress.XtraGrid.Columns.GridColumn colcUserCode;
        private DevExpress.XtraGrid.Columns.GridColumn colcUserName;

    }
}