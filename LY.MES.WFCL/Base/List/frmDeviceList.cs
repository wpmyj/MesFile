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
using Client.Utility.Filter;

namespace LY.MES.WFCL.Base.List
{
    /// <summary>
    /// Author:xxp
    /// Remark:设备档案列表
    /// CreateDate:20161014
    /// </summary>
    public partial class frmDeviceList : BaseForm
    {
        private Paging page;

        public frmDeviceList(UserContext context)
            : base(context)
        {
            InitializeComponent();
            bgwWait.ProgressChanged += this.backgroundWorker_ProgressChanged;
            gvDevice.CustomDrawEmptyForeground += new GridViewEventTool().GridView_CustomDrawEmptyForeground;
            gvDevice.CustomDrawRowIndicator += new GridViewEventTool().GridView_CustomDrawRowIndicator;
            page = gridViewPaging1.DataPaging;
            UseAuthProcess.FormButtonAuthProcess("frmDevice", context, bmTool, null);
        }

        private void frmDeviceList_Load(object sender, EventArgs e)
        {
            this.AddSysOperLogs(this.Text, OperateStatus.查询);

            this.WindowState = FormWindowState.Maximized;
            try
            {
                var task = Task.Run(() =>
                {
                    InitData();
                });

            }
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.Message);
            }
        }

        #region Event

        /// <summary>
        /// 工具栏事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bmTool_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Frm.frmDevice dev = null;
                switch (e.Item.Name)
                {
                    case "bbtniAdd":
                        if (tvDevClass.Nodes.Count > 0)
                        {
                            string strDevCCode = null;

                            if (tvDevClass.SelectedNode != null && tvDevClass.SelectedNode.Nodes.Count == 0)    //末级判断
                            {
                                strDevCCode = (tvDevClass.SelectedNode.Tag as SRDevice.DeviceClass).DevCCode;
                            }
                            dev = new Frm.frmDevice(context, strDevCCode: strDevCCode);
                            if (dev.ShowDialog() == DialogResult.OK)
                            {
                                bgwWait.RunWorkerAsync("SearchData");
                            }
                        }
                        else
                        {
                            ClsMsg.ShowWarningMsg("需要先建立设备分类");
                        }
                        break;
                    case "bbtniModify":

                        if (gvDevice.FocusedRowHandle >= 0)
                        {
                            var model = gvDevice.GetRow(gvDevice.FocusedRowHandle) as SRDevice.VDeviceInfo;
                            dev = new Frm.frmDevice(context, model.DevCode);
                            if (dev.ShowDialog() == DialogResult.OK)
                            {
                                bgwWait.RunWorkerAsync("SearchData");
                            }
                        }
                        else
                        {
                            ClsMsg.ShowWarningMsg("选中要修改的设备信息");
                        }
                        break;
                    case "bbtniParameter":
                        if (gvDevice.FocusedRowHandle >= 0)
                        {
                            var model = gvDevice.GetRow(gvDevice.FocusedRowHandle) as SRDevice.VDeviceInfo;
                            frmDevParamList devp = new frmDevParamList(context, model.DevCode, model.DevName);
                            if (devp.ShowDialog() == DialogResult.OK)
                            {
                                //   // bgwWait.RunWorkerAsync("SearchData");
                            }
                        }
                        else
                        {
                            ClsMsg.ShowWarningMsg("选中设备信息");
                        }
                        break;
                    case "bbtniInterface":
                        if (gvDevice.FocusedRowHandle >= 0)
                        {
                            var model = gvDevice.GetRow(gvDevice.FocusedRowHandle) as SRDevice.VDeviceInfo;
                            frmDevInterfaceList interfacelist = new frmDevInterfaceList(context, model.DevCode, model.DevName);

                            if (interfacelist.ShowDialog() == DialogResult.OK)
                            {
                            }
                        }
                        else
                        {
                            ClsMsg.ShowWarningMsg("选中设备信息");
                        }
                        break;
                    case "bbtniExit":
                        this.Close();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
        }

        /// <summary>
        /// 搜索事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (bgwWait.IsBusy == false)
            {
                page.CurrentPage = 1;
                bgwWait.RunWorkerAsync("SearchData");
            }
        }

        /// <summary>
        /// 异步事务工作事件
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
                    case "SearchData":
                        Tuple<StringBuilder, List<object>> dtFilter = Tuple.Create<StringBuilder, List<object>>(new StringBuilder(), new List<object>());
                        dtFilter.Item1.Append("1=1");
                        FilterProcess.MergeFilterCondition("DevCode", txtDevCode.EditValue, ref dtFilter);
                        FilterProcess.MergeFilterCondition("DevName", txtDevName.EditValue, ref dtFilter, strCompare: "like");
                        FilterProcess.MergeFilterCondition("DevCCode", txtDevCCode.EditValue, ref dtFilter);

                        int iCurrPage = (int)page.CurrentPage;
                        int iPageSize = (int)page.PageSize;
                        using (var client = new SRDevice.DeviceServiceClient())
                        {
                            var ret = client.GetVDeviceInfoPagedList(context.SessionID, Tuple.Create<string, object[]>(dtFilter.Item1.ToString(), dtFilter.Item2.ToArray()), iPageSize, iCurrPage);
                            if (ret.IsSuccess)
                            {
                                page.CurrentPage = iCurrPage;
                                page.RowCount = ret.TotalNum;
                                e.Result = ret.Data;
                            }
                            else
                                bgwWait.ReportProgress(101, ret.Message);
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
        /// 异步控件完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwWait_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                if (e.Result is SRDevice.VDeviceInfo[])
                {
                    gcDevice.RefreshDataSource();
                    vDeviceInfoBindingSource.DataSource = (e.Result as SRDevice.VDeviceInfo[]);
                    this.gridViewPaging1.DataPaging = page;
                    this.gridViewPaging1.PagingReflash();
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
            if (bgwWait.IsBusy == false && tvDevClass.SelectedNode != null)
            {
                txtDevCCode.Text = (tvDevClass.SelectedNode.Tag as SRDevice.DeviceClass).DevCCode;
                bgwWait.RunWorkerAsync("SearchData");
            }
        }

        private void tvDevClass_MouseClick(object sender, MouseEventArgs e)
        {

        }

        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewPaging1_PagingChanged(object sender, MyPagingEventArgs e)
        {
            if (bgwWait.IsBusy == false)
            {
                gcDevice.RefreshDataSource();
                bgwWait.RunWorkerAsync("SearchData");
            }
        }

        private void gcDevice_DoubleClick(object sender, EventArgs e)
        {
            bbtniModify.PerformClick();
        }

        #endregion

        #region Method

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            try
            {
                using (SRDevice.DeviceServiceClient client = new SRDevice.DeviceServiceClient())
                {
                    var ret = client.GetDeviceClassList(context.SessionID);
                    if (ret.IsSuccess)
                    {
                        this.Invoke((MethodInvoker)delegate()
                        {
                            LoadTreeData(ret.Data.ToList());
                        });
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
        /// 加载树形数据
        /// </summary>
        private void LoadTreeData(List<SRDevice.DeviceClass> lstModel)
        {
            tvDevClass.Nodes.Clear();
            var FirstModel = lstModel.Where(t => t.Grade == 0).OrderBy(t => t.DevCCode);
            foreach (var item in FirstModel)
            {
                TreeNode firstNode = new TreeNode();
                firstNode.Text = string.Format("{0} {1}", item.DevCCode, item.DevCName);
                firstNode.Tag = item;
                firstNode.Nodes.AddRange(GetChildNode(item.DevCCode, item.Grade, lstModel).ToArray());
                tvDevClass.Nodes.Add(firstNode);
            }
        }

        /// <summary>
        /// 获取下级数据
        /// </summary>
        /// <param name="strDevCCode"></param>
        /// <param name="iGrade"></param>
        /// <returns></returns>
        private List<TreeNode> GetChildNode(string strDevCCode, int iGrade, List<SRDevice.DeviceClass> lstModel)
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
                    node.Nodes.AddRange(GetChildNode(item.DevCCode, item.Grade, lstModel).ToArray());
                    nodes.Add(node);
                }
            }
            return nodes;
        }

        #endregion


    }
}
