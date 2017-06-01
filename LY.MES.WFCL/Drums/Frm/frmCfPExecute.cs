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
using LY.MES.WFCL.Drums.Frm;
using Client.Utility.Logging;

namespace LY.MES.WFCL.Drums.Frm
{
    public partial class frmCfPExecute : BaseForm
    {
        private SRCfPExecute.CraftsProcessExecute model = new SRCfPExecute.CraftsProcessExecute();
        private SRCfPExecute.CraftsProcessExecute headModel = new SRCfPExecute.CraftsProcessExecute();
        private List<SRCfPExecute.CraftsProcessExecute> lstheadModel = new List<SRCfPExecute.CraftsProcessExecute>();
        private List<SRCfPExecute.CraftsProcessExecuteDetail> lstbodyModel = new List<SRCfPExecute.CraftsProcessExecuteDetail>();

        private string ArrangedVouchCode;
        public frmCfPExecute(UserContext context, string ArrangedVouchCode)
            : base(context)
        {

            InitializeComponent();
            this.ArrangedVouchCode = ArrangedVouchCode;
            gridView1.CustomDrawRowIndicator += new GridViewEventTool().GridView_CustomDrawRowIndicator;
            bgwWait.ProgressChanged += this.backgroundWorker_ProgressChanged;
            UseAuthProcess.FormButtonAuthProcess(this.Name, context, barManager1, null);
        }

        private void CfPExecute_Load(object sender, EventArgs e)
        {
            try
            {
                var ExecuteStatus = DataEnum.GetEnumData(context, "CF.ExecuteStatus");

                ExecuteModeTextEdit.Properties.DataSource = DataEnum.GetEnumData("treatment");
                riluePriority.DataSource = DataEnum.GetEnumData(context, "CF.Priority");
                repositoryItemExecuteStatusLookUpEdit.DataSource = ExecuteStatus;
                ExecuteStatusTextEdit.Properties.DataSource = ExecuteStatus;
                this.AddSysOperLogs(this.Text, OperateStatus.查询);
                using (SRBase.BaseServiceClient client = new SRBase.BaseServiceClient())
                {
                    var ret = client.GetCraftsParameterContrastList(context.SessionID);
                    if (ret.IsSuccess)
                    {
                        rilueParameterName.DataSource = ret.Data;
                    }
                    else
                        ClsMsg.ShowWarningMsg(ret.Message);
                }
                bgwWait.RunWorkerAsync("LoadTreeData");
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                ClsMsg.ShowErrMsg(ex.Message);
            }
        }

        private void barManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (bgwWait.IsBusy == false)
                {
                    switch (e.Item.Name)
                    {
                        case "bbtniGet":
                            
                            model = new SRCfPExecute.CraftsProcessExecute()
                            {
                                ExecuteOrder = 0
                            };
                            craftsProcessExecuteBindingSource.DataSource = model;
                            break;

                        case "bbtniGet2":
                            craftsProcessExecuteBindingSource.EndEdit();
                            if (model != null)
                            {
                                bgwWait.RunWorkerAsync("SearchData");
                            }
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

        /// <summary>
        /// 组件工作事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void bgwWait_DoWork(object sender, DoWorkEventArgs e)
        {
            bgwWait.ReportProgress(PubConstant.WaitMessageStatus.START);
            try
            {
                switch (e.Argument.ToString())
                {
                    case "LoadTreeData":
                        GetTreeData(e);
                        break;

                    case "SearchData":
                        using (SRCfPExecute.CfPExecuteServiceClient client = new SRCfPExecute.CfPExecuteServiceClient())
                        {
                            var ret = client.GetCfPExecute(context.SessionID, model.ExecuteID);
                            if (ret.IsSuccess)
                            {
                                model = ret.HeadData;
                                lstbodyModel = ret.BodyData.ToList();
                                this.Invoke((MethodInvoker)delegate()
                                {
                                    craftsProcessExecuteBindingSource.DataSource = ret.HeadData;
                                    if (ret.BodyData.Count() > 0)
                                        craftsProcessExecutesBindingSource.DataSource = ret.BodyData.OrderBy(t => t.Priority);
                                    else
                                        craftsProcessExecutesBindingSource.DataSource = ret.BodyData;
                                    gridControl1.RefreshDataSource();
                                });
                            }
                            else
                                bgwWait.ReportProgress(PubConstant.WaitMessageStatus.WARNING, ret.Message);
                        }
                        break;

                    default:
                        break;
                }
            }
            catch (System.ServiceModel.FaultException<SRCfPExecute.CustomFaultMessage> fex)
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




        //树形选择事件
        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {

            if (bgwWait.IsBusy == false)
            {
                model = e.Node.Tag as SRCfPExecute.CraftsProcessExecute;
                bgwWait.RunWorkerAsync("SearchData");
            }
        }


        /// <summary>
        /// 获取树形数据
        /// </summary>
        /// <param name="e"></param>
        private void GetTreeData(DoWorkEventArgs e)
        {
            using (SRCfPExecute.CfPExecuteServiceClient client = new SRCfPExecute.CfPExecuteServiceClient())
            {
                var ret = client.GetCfPExecutes(context.SessionID, ArrangedVouchCode);
                if (ret.IsSuccess)
                {
                    e.Result = ret.Data;
                }
                else
                {
                    bgwWait.ReportProgress(101, ret.Message);
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
            var lstModel = lstheadModel.OrderBy(t => t.ExecuteOrder).ThenBy(t => t.ExecuteID);
            foreach (var item in lstModel)
            {
                TreeNode fristNode = new TreeNode();
                fristNode.Text = string.Format("{0} {1}", item.ExecuteOrder, item.CraftsName);
                fristNode.Tag = item;
                treeView1.Nodes.Add(fristNode);
            }
        }

        //完成组件事件
        private void bgwWait_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                if (e.Result is SRCfPExecute.CraftsProcessExecute[])
                {
                    lstheadModel = (e.Result as SRCfPExecute.CraftsProcessExecute[]).ToList();
                    LoadTreeData();
                }
            }

        }
       
    }
}
