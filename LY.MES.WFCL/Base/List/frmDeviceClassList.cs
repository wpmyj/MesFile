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
using System.Diagnostics;

namespace LY.MES.WFCL.Base.List
{
    /// <summary>
    /// Author:xxp
    /// Remark:设备分类
    /// CreateDate:20161014
    /// </summary>
    public partial class frmDeviceClassList : BaseForm
    {
        private SRDevice.DeviceClass model = null;
        private List<SRDevice.DeviceClass> lstModel = null;

        /// <summary>
        /// 设备分类
        /// </summary>
        /// <param name="context"></param>
        public frmDeviceClassList(UserContext context)
            : base(context)
        {
            InitializeComponent();
            bgwWait.ProgressChanged += this.backgroundWorker_ProgressChanged;
            UseAuthProcess.FormButtonAuthProcess(this.Name, context, bmTool, null);
        }

        private void frmDeviceClassList_Load(object sender, EventArgs e)
        {
            try
            {
                this.AddSysOperLogs(this.Text, OperateStatus.查询);
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
            bgwWait.ReportProgress(0);
            try
            {
                switch (e.Argument.ToString())
                {
                    case "LoadTreeData":
                        GetTreeData(e);
                        break;
                    case "SaveData":
                        using (SRDevice.DeviceServiceClient client = new SRDevice.DeviceServiceClient())
                        {
                            if (DevCCodeTextEdit.Properties.ReadOnly) //编辑
                            {
                                this.AddSysOperLogs(this.Text, OperateStatus.修改, strCode: model.DevCCode);
                                var ret = client.UpdateDeviceClass(context.SessionID, model);
                                if (ret.IsSuccess)
                                {
                                    bgwWait.ReportProgress(99, "保存成功！");
                                    GetTreeData(e);
                                }
                                else
                                {
                                    bgwWait.ReportProgress(101, ret.Message);
                                }
                            }
                            else //新增
                            {
                                this.AddSysOperLogs(this.Text, OperateStatus.增加, strCode: model.DevCCode);
                                var ret = client.AddDeviceClass(context.SessionID, model);
                                if (ret.IsSuccess)
                                {
                                    bgwWait.ReportProgress(99, "新增成功！");
                                    GetTreeData(e);
                                }
                                else
                                {
                                    bgwWait.ReportProgress(101, ret.Message);
                                }
                            }
                        }
                        break;
                    case "DelData":
                        using (SRDevice.DeviceServiceClient client = new SRDevice.DeviceServiceClient())
                        {
                            this.AddSysOperLogs(this.Text, OperateStatus.删除, strCode: model.DevCCode);
                            var retDel = client.DelDeviceClassByCode(context.SessionID, model.DevCCode);
                            if (retDel.IsSuccess)
                            {
                                bgwWait.ReportProgress(99, "删除成功！");
                                GetTreeData(e);
                            }
                            else
                            {
                                bgwWait.ReportProgress(101, retDel.Message);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (System.ServiceModel.FaultException<SRDevice.CustomFaultMessage> fex)
            {
                bgwWait.ReportProgress(102, fex.Message);
                Utils.Logger.Error(fex.ToString());
            }
            catch (Exception ex)
            {
                bgwWait.ReportProgress(102, ex.Message);
                Utils.Logger.Error(ex.ToString());
            }

            bgwWait.ReportProgress(100);
        }


        /// <summary>
        /// 组件工作完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwWait_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                if (e.Result is SRDevice.DeviceClass[])
                {
                    lstModel = (e.Result as SRDevice.DeviceClass[]).ToList();
                    deviceClassBindingSource.DataSource = new SRDevice.DeviceClass();
                    LoadTreeData();
                }
            }
        }

        /// <summary>
        /// 树形选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvDevClass_AfterSelect(object sender, TreeViewEventArgs e)
        {
            model = e.Node.Tag as SRDevice.DeviceClass;
            deviceClassBindingSource.DataSource = model;
            DevCCodeTextEdit.Properties.ReadOnly = true;
        }

        private void bmTool_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (bgwWait.IsBusy == false)
                {
                    switch (e.Item.Name)
                    {
                        case "bbtniAdd":
                            DevCCodeTextEdit.Properties.ReadOnly = false;
                            model = new SRDevice.DeviceClass()
                            {
                                Grade = 0
                            };
                            deviceClassBindingSource.DataSource = model;
                            break;
                        case "bbtniSave":
                            deviceClassBindingSource.EndEdit();

                            if (model == null)
                            {
                                ClsMsg.ShowWarningMsg("无任何可保存的数据!");
                            }
                            else if (model.DevCCode.IsNullOrEmpty())
                            {
                                ClsMsg.ShowWarningEmptyMsg(ItemForDevCCode.Text);
                                DevCCodeTextEdit.Focus();
                            }
                            else if (model.DevCName.IsNullOrEmpty())
                            {
                                ClsMsg.ShowWarningEmptyMsg(ItemForDevCName.Text);
                                DevCNameTextEdit.Focus();
                            }
                            else if (ClsMsg.ShowQuestionMsg("是否要保存当前数据呢？") == DialogResult.Yes)
                            {
                                bgwWait.RunWorkerAsync("SaveData");
                            }
                            break;
                        case "bbtniDel":
                            deviceClassBindingSource.EndEdit();
                            if (model != null && ClsMsg.ShowQuestionMsg("是否要删除当前数据呢?") == DialogResult.Yes)
                            {
                                bgwWait.RunWorkerAsync("DelData");
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
                ClsMsg.ShowErrMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
        }

        /// <summary>
        /// 右击菜单展开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmsTreeMenu_Opening(object sender, CancelEventArgs e)
        {
            tsmiAddChildren.Visible = (tvDevClass.SelectedNode == null) ? false : true;
        }

        private void tsmiAddChildren_Click(object sender, EventArgs e)
        {
            if (tvDevClass.SelectedNode != null)
            {
                DevCCodeTextEdit.Properties.ReadOnly = false;
                var supModel = tvDevClass.SelectedNode.Tag as SRDevice.DeviceClass;
                model = new SRDevice.DeviceClass()
                {
                    SupCCode = supModel.DevCCode,
                    Grade = supModel.Grade + 1
                };
                deviceClassBindingSource.DataSource = model;
            }
        }


        #endregion

        #region Method

        /// <summary>
        /// 获取树形数据
        /// </summary>
        /// <param name="e"></param>
        private void GetTreeData(DoWorkEventArgs e)
        {
            Stopwatch ww = new Stopwatch();
            ww.Start();
            using (SRDevice.DeviceServiceClient client = new SRDevice.DeviceServiceClient())
            {
                var ret = client.GetDeviceClassList(context.SessionID);
                if (ret.IsSuccess)
                {
                    e.Result = ret.Data;
                }
                else
                {
                    bgwWait.ReportProgress(101, ret.Message);
                }
            }
            ww.Stop();
            long l = ww.ElapsedMilliseconds;
            Utils.Logger.Debug("时长:" + l.ToString());
        }

        /// <summary>
        /// 加载树形数据
        /// </summary>
        public void LoadTreeData()
        {
            tvDevClass.Nodes.Clear();
            var FirstModel = lstModel.Where(t => t.Grade == 0).OrderBy(t => t.DevCCode);
            foreach (var item in FirstModel)
            {
                TreeNode firstNode = new TreeNode();
                firstNode.Text = string.Format("{0} {1}", item.DevCCode, item.DevCName);
                firstNode.Tag = item;
                firstNode.Nodes.AddRange(GetChildNode(item.DevCCode, item.Grade).ToArray());
                tvDevClass.Nodes.Add(firstNode);
            }
        }
        /// <summary>
        /// 获取下级数据
        /// </summary>
        /// <param name="strDevCCode"></param>
        /// <param name="iGrade"></param>
        /// <returns></returns>
        public List<TreeNode> GetChildNode(string strDevCCode, int iGrade)
        {
            List<TreeNode> nodes = new List<TreeNode>();

            var data = lstModel.Where(t => t.SupCCode == strDevCCode && t.Grade == iGrade + 1).OrderBy(t => t.DevCCode).ToList();
            if (data != null)
            {
                foreach (var item in data)
                {
                    TreeNode node = new TreeNode();
                    node.Text = string.Format("{0} {1}", item.DevCCode, item.DevCName);
                    node.Tag = item;
                    node.Nodes.AddRange(GetChildNode(item.DevCCode, item.Grade).ToArray());
                    nodes.Add(node);
                }
            }
            return nodes;
        }

        #endregion
    }
}
