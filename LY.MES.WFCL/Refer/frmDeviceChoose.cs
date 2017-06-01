using Client.Utility;
using Client.Utility.Controls;
using Client.Utility.Filter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LY.MES.WFCL.Refer
{
    /// <summary>
    /// Author:pjh
    /// Remark:设备档案列表选择
    /// CreateDate:20161031
    /// </summary>
    /// 

    public partial class frmDeviceChoose : BaseForm
    {
        //private SRDevice.DeviceServiceClient client = null;
        //private SRDevice.Device model = null;
        //private List<SRDevice.Device> lstModel = null;
        private Paging page;
        public string DeviCode;
        private string strDevCCode;

        /// <summary>
        /// 当strdevccode为Null时，获取全部设备类型数据，当传入相应的设备分类编号时则获取相应设备类型数据
        /// </summary>
        /// <param name="context"></param>
        /// <param name="strdevccode">设备分类编号</param>
        public frmDeviceChoose(UserContext context, string  strdevccode)
            : base(context)
        {
            InitializeComponent();
            page = gridViewPaging1.DataPaging;
            strDevCCode = strdevccode;
        }

        /// <summary>
        /// 窗体初始化加载
        /// </summary>  
        private void frmDeviceChoose_Load(object sender, EventArgs e)
        {
            //client = new SRDevice.DeviceServiceClient();
            //BGW2.RunWorkerAsync("SearchData");

            //this.WindowState = FormWindowState.Maximized;
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
        /// 异步事务工作事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BGW2_DoWork(object sender, DoWorkEventArgs e)
        {
            BGW2.ReportProgress(0);
            try
            {
                switch (e.Argument.ToString())
                {
                    case "SearchData":
                        int CurrPage = (int)page.CurrentPage;
                        int PageSize = (int)page.PageSize;
                        Tuple<string, object[]> tWhere = null;
                        //if (SeeKTextEdit.Text.IsNullOrEmpty() == false)
                        //{
                        //    //string strWhere = "1=1 and (DevCode.Contains(@0) or DevCCode.Contains(@0) or DevName.Contains(@0)) ";
                        //    //tWhere = Tuple.Create<string, object[]>(strWhere, new object[] { SeeKTextEdit.Text });



                        //}
                            Tuple<StringBuilder, List<object>> dtFilter = Tuple.Create<StringBuilder, List<object>>(new StringBuilder(), new List<object>());
                            dtFilter.Item1.Append("1 = 1");
                            FilterProcess.MergeFilterCondition("DevCCode", DevCCodeTextEdit.Text, ref dtFilter);
                            FilterProcess.MergeFilterCondition("DevCode", DevCodeTextEdit.Text, ref dtFilter,"like");
                            FilterProcess.MergeFilterCondition("DevName", DevNameTextEdit.Text, ref dtFilter,"like");

                        using (SRDevice.DeviceServiceClient client = new SRDevice.DeviceServiceClient())
                        {
                            //var ret = client.GetDevicePagedList(context.SessionID, tWhere, PageSize, CurrPage);

                            var ret = client.GetDevicePagedList(context.SessionID, Tuple.Create<string, object[]>(dtFilter.Item1.ToString(), dtFilter.Item2.ToArray()), PageSize, CurrPage);
                            if (ret.IsSuccess)
                            {
                                page.CurrentPage = CurrPage;
                                page.RowCount = ret.TotalNum;
                                e.Result = ret.Data;
                            }
                            else
                                BGW2.ReportProgress(101, ret.Message);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                BGW2.ReportProgress(101, ex.Message);
            }
            BGW2.ReportProgress(100);
        }

        /// <summary>
        /// 异步控件完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BGW2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                if (e.Result is SRDevice.Device[])
                {
                    gridControl1.RefreshDataSource();
                    deviceBindingSource.DataSource = (e.Result as SRDevice.Device[]);
                    this.gridViewPaging1.DataPaging = page;
                    this.gridViewPaging1.PagingReflash();
                }
            }
        }

        /// <summary>
        /// 工具栏事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (BGW2.IsBusy == false)
                {
                    switch (e.Item.Name)
                    {
                        case "bbtniEnsure":
                            string b = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DevCode").ToString();
                            DeviCode = b;
                            this.DialogResult = DialogResult.OK;
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
                ClsMsg.ShowErrMsg(ex.ToString());
            }
        }


        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewPaging1_PagingChanged(object sender, MyPagingEventArgs e)
        {
            if (BGW2.IsBusy == false)
            {
                gridControl1.RefreshDataSource();
                BGW2.RunWorkerAsync("SearchData");
            }
        }



        /// <summary>
        /// 树形选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (BGW2.IsBusy == false && tvDevice.SelectedNode != null)
            {
                DevCCodeTextEdit.Text = (tvDevice.SelectedNode.Tag as SRDevice.DeviceClass).DevCCode;
            }
        }

        /// <summary>
        /// 模糊搜索事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeekSimpleButton_Click(object sender, EventArgs e)
        {
            if (BGW2.IsBusy == false)
            {
                gridControl1.RefreshDataSource();
                BGW2.RunWorkerAsync("SearchData");
            }
        }

        #endregion


        #region Method

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            using (SRDevice.DeviceServiceClient client = new SRDevice.DeviceServiceClient())
            {
                var ret = client.GetDeviceClassList(context.SessionID);
                if (ret.IsSuccess)
                {
                    this.Invoke((MethodInvoker)delegate()
                    {
                        LoadTreeData(ret.Data.ToList(),strDevCCode);
                    });
                }
            }
        }      


        /// <summary>
        /// 加载树形数据
        /// </summary>
        private void LoadTreeData(List<SRDevice.DeviceClass> lstModel,string strdevccode )
        {
            tvDevice.Nodes.Clear();
            //var FirstModel = lstModel.Where(t => t.Grade == 0).OrderBy(t => t.DevCCode);
            List<SRDevice.DeviceClass> FirstModel = lstModel;
            if(strdevccode != null)
                FirstModel = FirstModel.Where(t => t.DevCCode == strdevccode).ToList();

            FirstModel = FirstModel.Where(t => t.Grade == 0).OrderBy(t => t.DevCCode).ToList();
                
            foreach (var item in FirstModel)
            {
                TreeNode firstNode = new TreeNode();
                firstNode.Text = string.Format("{0} {1}", item.DevCCode, item.DevCName);
                firstNode.Tag = item;
                firstNode.Nodes.AddRange(GetChildNode(item.DevCCode, item.Grade, lstModel).ToArray());
                tvDevice.Nodes.Add(firstNode);
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

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            bbtniEnsure.PerformClick();
        }

    }
}
