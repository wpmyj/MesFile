using Client.Utility;
using Client.Utility.Controls;
using LY.MES.WFCL.Base.List;
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
    /// Remark:参数列表选择
    /// CreateDate:20161028
    /// </summary>
    /// 
    public partial class frmParChoose : BaseForm
    {

        private SRDevice.DeviceServiceClient client = null;
        private Paging page;
        public string DevpCode;
        public string DevpName;

        public frmParChoose(UserContext context)
            : base(context)
        {
            InitializeComponent();
            page = gridViewPaging1.DataPaging;
        }


        /// <summary>
        /// 窗体初始化加载
        /// </summary>    
        private void frmParChoose_Load(object sender, EventArgs e)
        {
            client = new SRDevice.DeviceServiceClient();
            backgroundWorker1.RunWorkerAsync("SearchData");
        }

        #region Event
        /// <summary>
        /// 异步事务工作事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(0);
            try
            {
                switch (e.Argument.ToString())
                {
                    case "SearchData":
                        int CurrPage = (int)page.CurrentPage;
                        int PageSize = (int)page.PageSize;
                        Tuple<string, object[]> tWhere = null;
                        if (FiltrateTextEdit.Text.IsNullOrEmpty() == false)
                        {
                            string strWhere = "1=1 and (DevCode.Contains(@0) or DevpCode.Contains(@0) or DevpName.Contains(@0)) ";
                            tWhere = Tuple.Create<string, object[]>(strWhere, new object[] { FiltrateTextEdit.Text });
                        }

                        using (SRDevice.DeviceServiceClient client = new SRDevice.DeviceServiceClient())
                        {
                            var ret = client.GetDevParameterPagedList(context.SessionID, tWhere, PageSize, CurrPage);
                            if (ret.IsSuccess)
                            {
                                page.CurrentPage = CurrPage;
                                page.RowCount = ret.TotalNum;
                                e.Result = ret.Data;
                            }
                            else
                                backgroundWorker1.ReportProgress(101, ret.Message);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                backgroundWorker1.ReportProgress(101, ex.Message);
            }
            backgroundWorker1.ReportProgress(100);
        }

        /// <summary>
        /// 异步控件完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                if (e.Result is SRDevice.DeviceParameter[])
                {
                    gridControl1.RefreshDataSource();
                    deviceParameterBindingSource.DataSource = (e.Result as SRDevice.DeviceParameter[]);
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
                if (backgroundWorker1.IsBusy == false)
                {
                    switch (e.Item.Name)
                    {
                        case "bbtiEnsure":
                            string b = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DevpCode").ToString();
                            DevpCode = b;
                            this.DialogResult = DialogResult.OK;
                            break;


                        case "bbtiExit":
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
            if (backgroundWorker1.IsBusy == false)
            {
                gridControl1.RefreshDataSource();
                backgroundWorker1.RunWorkerAsync("SearchData");
            }
        }

        /// <summary>
        /// 模糊搜索事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FiltrateSimpleButton_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy == false)
            {
                gridControl1.RefreshDataSource();
                backgroundWorker1.RunWorkerAsync("SearchData");
            }
        }
        #endregion


        #region Mothod
        /// <summary>
        /// 双击列表选择当前选定的参数数据
        /// </summary>  
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            string b = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DevpCode").ToString();
            DevpCode = b;
            this.DialogResult = DialogResult.OK;
        }

        #endregion

    }
}
