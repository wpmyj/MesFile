using Client.Utility;
using Client.Utility.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Utility.Logging;
using LY.MES.WFCL.Refer;


namespace LY.MES.WFCL.Base.List
{

    /// <summary>
    /// Author:xxp
    /// Remark:标准工艺参数设置
    /// </summary>
    public partial class frmCLParamSetList : BaseForm
    {
        private SRCLParamSet.CraftsLineParamSet headModel = new SRCLParamSet.CraftsLineParamSet();
        private List<SRCLParamSet.CraftsLineParamSet> lstheadModel = new List<SRCLParamSet.CraftsLineParamSet>();
        private List<SRCLParamSet.VCraftsLineParamSetDetail> lstbodyModel = new List<SRCLParamSet.VCraftsLineParamSetDetail>();

        public frmCLParamSetList(UserContext context)
            : base(context)
        {
            InitializeComponent();
            bgwWait.ProgressChanged += this.backgroundWorker_ProgressChanged;
            UseAuthProcess.FormButtonAuthProcess(this.Name, context, null);
            gvDetail.CustomDrawRowIndicator += new GridViewEventTool().GridView_CustomDrawRowIndicator;
        }

        private void frmCLParamSet_Load(object sender, EventArgs e)
        {
            try
            {
                this.AddSysOperLogs(this.Text, OperateStatus.查询);
                UseStatusLookUpEdit.Properties.DataSource = DataEnum.GetEnumData("status");
                rilueStatus.DataSource = DataEnum.GetEnumData("status");
                TreatmentLookUpEdit.Properties.DataSource = DataEnum.GetEnumData("treatment");
                riluePriority.DataSource = DataEnum.GetEnumData(context, "CF.Priority");

                using (SRBase.BaseServiceClient client = new SRBase.BaseServiceClient())
                {
                    var ret = client.GetCraftsParameterContrastList(context.SessionID);
                    if (ret.IsSuccess)
                    {
                        rilueParamName.DataSource = ret.Data;
                    }
                    else
                        ClsMsg.ShowWarningMsg(ret.Message);
                }
                bgwWait.RunWorkerAsync("LoadTreeData");
            }
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
        }

        #region Event
        /// <summary>
        /// 组件工作事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwWait_DoWork(object sender, DoWorkEventArgs e)
        {
            bgwWait.ReportProgress(PubConstant.WaitMessageStatus.START);
            try
            {
                switch (e.Argument.ToString())
                {
                    case "LoadTreeData":
                        LoadTreeData(e);
                        break;
                    case "SearchData":
                        using (SRCLParamSet.CLParamSetSerivceClient client = new SRCLParamSet.CLParamSetSerivceClient())
                        {
                            var ret = client.GetCLParamSetsList(context.SessionID, headModel.ID);
                            if (ret.IsSuccess)
                            {
                                headModel = ret.HeadData;
                                lstbodyModel = ret.BodyData.OrderBy(t => t.Priority).ToList();
                                this.Invoke((MethodInvoker)delegate()
                                {
                                    craftsLineParamSetBindingSource.DataSource = ret.HeadData;
                                    craftsLineParamSetsBindingSource.DataSource = lstbodyModel;
                                    gridControl1.RefreshDataSource();
                                });
                            }
                            else
                                bgwWait.ReportProgress(PubConstant.WaitMessageStatus.WARNING, ret.Message);
                        }
                        break;
                    case "SaveData":
                        using (SRCLParamSet.CLParamSetSerivceClient client = new SRCLParamSet.CLParamSetSerivceClient())
                        {
                            if (headModel.ID > 0) //保存
                            {
                                this.AddSysOperLogs(this.Text, OperateStatus.修改, strCode: headModel.CraftsName);
                                headModel.Modify = context.UserName;
                                headModel.ModifyDate = DateTime.Now;
                                var ret = client.UpdateCLParamSet(context.SessionID, headModel, lstbodyModel.ToArray());

                                if (ret.IsSuccess)
                                {
                                    bgwWait.ReportProgress(PubConstant.WaitMessageStatus.PROMPT, "保存成功！");
                                    this.Invoke((MethodInvoker)delegate()
                                    {
                                        headModel = ret.HeadData;
                                        lstbodyModel = ret.BodyData.OrderBy(t => t.Priority).ToList();
                                        craftsLineParamSetBindingSource.DataSource = headModel;
                                        craftsLineParamSetsBindingSource.DataSource = lstbodyModel;
                                    });
                                    LoadTreeData(e);
                                }
                                else
                                {
                                    bgwWait.ReportProgress(PubConstant.WaitMessageStatus.WARNING, ret.Message);
                                }
                            }
                            else //新增
                            {
                                this.AddSysOperLogs(this.Text, OperateStatus.增加, strCode: headModel.CraftsName);
                                var ret = client.AddCLParamSet(context.SessionID, headModel, lstbodyModel.ToArray());
                                if (ret.IsSuccess)
                                {
                                    bgwWait.ReportProgress(PubConstant.WaitMessageStatus.PROMPT, "新增成功！");
                                    this.Invoke((MethodInvoker)delegate()
                                    {
                                        headModel = ret.HeadData;
                                        lstbodyModel = ret.BodyData.ToList();
                                        craftsLineParamSetBindingSource.DataSource = headModel;
                                        craftsLineParamSetsBindingSource.DataSource = lstbodyModel;
                                    });
                                    LoadTreeData(e);
                                }
                                else
                                {
                                    bgwWait.ReportProgress(PubConstant.WaitMessageStatus.WARNING, ret.Message);
                                }
                            }
                        }
                        break;
                    case "DelData":
                        using (SRCLParamSet.CLParamSetSerivceClient client = new SRCLParamSet.CLParamSetSerivceClient())
                        {
                            this.AddSysOperLogs(this.Text, OperateStatus.删除, strCode: headModel.CraftsCode);
                            var retDel = client.DelCLParamSet(context.SessionID, headModel.ID);
                            if (retDel.IsSuccess)
                            {
                                bgwWait.ReportProgress(PubConstant.WaitMessageStatus.PROMPT, "删除成功！");
                                LoadTreeData(e);
                            }
                            else
                            {
                                bgwWait.ReportProgress(PubConstant.WaitMessageStatus.WARNING, retDel.Message);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (System.ServiceModel.FaultException<SRCLParamSet.CustomFaultMessage> fex)
            {
                Utils.Logger.Error(fex.ToString());
                bgwWait.ReportProgress(PubConstant.WaitMessageStatus.ERROR, fex.Message);
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                bgwWait.ReportProgress(PubConstant.WaitMessageStatus.ERROR, ex.Message);
            }
            bgwWait.ReportProgress(PubConstant.WaitMessageStatus.END);
        }

        private void barManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (bgwWait.IsBusy == false)
                {
                    switch (e.Item.Name)
                    {
                        case "bbtniAdd":
                            headModel = new SRCLParamSet.CraftsLineParamSet();
                            headModel.CreateDateTime = DateTime.Now;
                            headModel.Creator = context.UserName;
                            craftsLineParamSetBindingSource.DataSource = headModel;
                            lstbodyModel = new List<SRCLParamSet.VCraftsLineParamSetDetail>();
                            //lstbodyModel.Add(new SRCLParamSet.CraftsLineParamSets());
                            craftsLineParamSetsBindingSource.DataSource = lstbodyModel;
                            gridControl1.RefreshDataSource();
                            break;
                        case "bbtniSave":
                            gvDetail.CloseEditor();
                            craftsLineParamSetBindingSource.EndEdit();
                            craftsLineParamSetsBindingSource.EndEdit();
                            if (headModel.CraftsName.IsNullOrEmpty())
                            {
                                ClsMsg.ShowWarningEmptyMsg(ItemForCraftsName.Text);
                                CraftsNameButtonEdit.Focus();
                                return;
                            }
                            else if (headModel.WorkShop.IsNullOrEmpty())
                            {
                                ClsMsg.ShowWarningEmptyMsg(ItemForWorkShop.Text);
                                WorkShopTextEdit.Focus();
                                return;
                            }
                            else if (headModel.Treatment.IsNullOrEmpty())
                            {
                                ClsMsg.ShowWarningEmptyMsg(ItemForTreatment.Text);
                                TreatmentLookUpEdit.Focus();
                                return;
                            }
                            else if (headModel.Treatment.Equals("1") && (headModel.CraftsTaskTime.HasValue == false || headModel.CraftsTaskTime.Value <= 0))
                            {
                                ClsMsg.ShowWarningMsg("处理方式为：自动,工艺总耗时不能小于零或为空！");
                                CraftsTaskTimeCalcEdit.Focus();
                                return;
                            }
                            else if (headModel.Order <= 0)
                            {
                                ClsMsg.ShowWarningMsg(ItemForOrder.Text + "不能小于等于零！");
                                OrderSpinEdit.Focus();
                                return;
                            }
                            else if (headModel.Treatment.Equals("1") && lstbodyModel.Count == 0)
                            {
                                ClsMsg.ShowWarningMsg("处理方式为：自动,工艺参数明细不能为空！");
                                return;
                            }
                            else if (lstbodyModel.Count > 0)
                            {
                                //if (lstbodyModel.Where(t => (t.Editprop.IsNullOrEmpty() || t.Editprop != "D")).OrderBy(t => t.Priority).First().Priority != 0)
                                //{
                                //    ClsMsg.ShowWarningMsg("工艺参数明细优先级没有开始参数");
                                //    return;
                                //}
                                //else
                                if (headModel.Treatment == "1") //处理方式:自动,判断必须有结束
                                {
                                    if (lstbodyModel.Where(t => (t.Editprop.IsNullOrEmpty() || t.Editprop != "D")).OrderByDescending(t => t.Priority).First().Priority != 100)
                                    {
                                        ClsMsg.ShowWarningMsg("工艺参数明细优先级没有结束参数");
                                        return;
                                    }
                                }

                                for (int i = 0; i < lstbodyModel.Count; i++)
                                {
                                    var item = lstbodyModel[i];
                                    if (item.Editprop.IsNullOrEmpty() || item.Editprop.Equals("E"))
                                    {
                                        if (item.ParameterID == 0)
                                        {
                                            ClsMsg.ShowWarningEmptyMsg(string.Format("第{0}行参数名称", i.ToString()));
                                            return;
                                        }
                                        else if (item.UserStatus.IsNullOrEmpty())
                                        {
                                            ClsMsg.ShowWarningEmptyMsg(string.Format("第{0}行使用状态", i.ToString()));
                                            return;
                                        }
                                    }
                                }
                            }
                            if (ClsMsg.ShowQuestionMsg("是否要保存当前数据呢？") == DialogResult.Yes)
                            {
                                bgwWait.RunWorkerAsync("SaveData");
                            }
                            break;
                        case "bbtniDel":
                            if (ClsMsg.ShowQuestionMsg("是否要删除当前数据呢？") == DialogResult.Yes)
                            {
                                bgwWait.RunWorkerAsync("DelData");
                            }
                            break;
                        case "bbtniDelRow":
                            var curr = lstbodyModel.Where(t => t.Editprop != "D").ToList()[gvDetail.FocusedRowHandle];
                            curr.Editprop = "D";
                            craftsLineParamSetsBindingSource.DataSource = lstbodyModel;
                            gridControl1.RefreshDataSource();
                            break;
                        case "bbtniAddRow":
                            lstbodyModel.Add(new SRCLParamSet.VCraftsLineParamSetDetail()
                            {
                                ID = headModel.ID,
                                Editprop = "A",
                                UserStatus = "0"
                            });
                            craftsLineParamSetsBindingSource.DataSource = lstbodyModel;
                            gridControl1.RefreshDataSource();
                            break;
                        case "bbtniExit":
                            this.Close();
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                ClsMsg.ShowErrMsg(ex.Message);
            }
        }

        //树形选择事件
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (bgwWait.IsBusy == false && e.Node.Level == 1)
            {
                headModel = e.Node.Tag as SRCLParamSet.CraftsLineParamSet;
                bgwWait.RunWorkerAsync("SearchData");
            }
        }

        //组件完成事件
        private void bgwWait_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                if (e.Result is SRCLParamSet.CraftsLineParamSet[])
                {
                    lstheadModel = (e.Result as SRCLParamSet.CraftsLineParamSet[]).ToList();
                    //craftsLineParamSetBindingSource.DataSource = new SRCLParamSet.CraftsLineParamSet();
                    LoadTreeData();
                }
            }
        }

        private void gvDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //处理编辑标志
            var currModel = lstbodyModel.Where(t => t.Editprop != "D").ToList()[e.RowHandle];
            if (currModel.Editprop.IsNullOrEmpty())
            {
                currModel.Editprop = "E";
            }
        }

        private void gvDetail_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            try
            {
                var currModel = lstbodyModel[e.ListSourceRow];
                if (currModel != null && currModel.Editprop.IsNullOrEmpty() == false && currModel.Editprop.Equals("D"))
                {
                    e.Visible = false;
                }
                e.Handled = true;
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                ClsMsg.ShowErrMsg(ex.Message);
            }
        }

        private void cmsGridMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                switch (e.ClickedItem.Name)
                {
                    case "tsmiAddRow":
                        bbtniAddRow.PerformClick();
                        break;
                    case "tsmiDelRow":
                        bbtniDelRow.PerformClick();
                        break;
                    case "tsmiInsertRow":
                        var bodyModel = new SRCLParamSet.VCraftsLineParamSetDetail() { Editprop = "A", ID = headModel.ID, UserStatus = "0" };
                        if (gvDetail.FocusedRowHandle < 0)
                            lstbodyModel.Add(bodyModel);
                        else
                            lstbodyModel.Insert(gvDetail.FocusedRowHandle, bodyModel);
                        craftsLineParamSetsBindingSource.DataSource = lstbodyModel;
                        gridControl1.RefreshDataSource();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                ClsMsg.ShowErrMsg(ex.Message);
            }
        }

        private void CraftsNameButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmReferCrafts frm = new frmReferCrafts(context);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                headModel.WorkShop = frm.WorkShop;
                headModel.CraftsCode = frm.CraftsCode;
                headModel.CraftsName = frm.CraftsName;
            }
        }

        #endregion

        #region Method

        /// <summary>
        /// 获取树形数据
        /// </summary>
        /// <param name="e"></param>
        private void LoadTreeData(DoWorkEventArgs e)
        {
            using (SRCLParamSet.CLParamSetSerivceClient client = new SRCLParamSet.CLParamSetSerivceClient())
            {
                var ret = client.GetCLParamSetList(context.SessionID);
                if (ret.IsSuccess)
                {
                    e.Result = ret.Data;
                }
                else
                {
                    bgwWait.ReportProgress(PubConstant.WaitMessageStatus.WARNING, ret.Message);
                }
            }
        }

        /// <summary>
        /// 加载树形数据
        /// </summary>
        public void LoadTreeData()
        {
            treeView1.Nodes.Clear();
            var lstModel = lstheadModel.OrderBy(t => t.Order).GroupBy(t => t.WorkShop);
            foreach (var item in lstModel)
            {
                TreeNode firstNode = new TreeNode();
                firstNode.Text = string.Format("{0}", item.Key);
                firstNode.Tag = null;
                foreach (var item1 in item.OrderBy(t => t.Order))
                {
                    TreeNode node = new TreeNode();
                    node.Text = string.Format("{0} {1}", item1.Order, item1.CraftsName);
                    node.Tag = item1;
                    firstNode.Nodes.Add(node);
                }
                treeView1.Nodes.Add(firstNode);
            }
            treeView1.ExpandAll();
        }

        #endregion

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CraftsNameButtonEdit_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}

