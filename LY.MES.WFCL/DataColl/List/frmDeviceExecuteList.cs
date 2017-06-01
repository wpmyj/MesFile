using Client.Utility;
using Client.Utility.Controls;
using LY.MES.WFCL.Base.Frm;
using LY.MES.WFCL.DataColl.Frm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Utility.Filter;
using LY.MES.WFCL.Refer;
using Client.Utility.Logging;


namespace LY.MES.WFCL.DataColl.List
{
    public partial class frmDeviceExecuteList : BaseForm
    {
        /// <summary>
        /// 设备执行登记表主窗体
        /// lastupdate：20161115XXQ
        /// </summary>
        private Paging page;
        public string Flag_i;
        public string strDeviCode;

        public frmDeviceExecuteList(UserContext context)
            : base(context)
        {
            InitializeComponent();
            page = gridViewPaging1.DataPaging;
            BgWait1.ProgressChanged += this.backgroundWorker_ProgressChanged;

        }
        #region    隐藏按钮

        private void frmDeviceExecute_Load(object sender, EventArgs e)
        {

            this.AddSysOperLogs(this.Text, OperateStatus.查询);

        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {



        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        /// <summary>
        /// 搜索按钮响应时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            BgWait1.RunWorkerAsync("SearchData");
        }

        #endregion

        /// <summary>
        /// barManager控件响应事件，打开新窗体，传入参数区分新增跟修改，等待窗体数据返回更新列表数据
        /// lastupdata:20161115XXQ
        /// /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frmExecute AddExetue = null;
                strDeviCode = null;
                if (BgWait1.IsBusy == false)
                {
                    switch (e.Item.Name)
                    {
                        case "bbtniAdd":

                            AddExetue = new frmExecute(context, strDeviCode);

                            if (AddExetue.ShowDialog() == DialogResult.OK)
                            {
                                BgWait1.RunWorkerAsync("SearchData");
                            }

                            break;

                        case "bbtniUpdate":

                            if (gridView1.FocusedRowHandle >= 0)
                            {
                                var model1 = gridView1.GetRow(gridView1.FocusedRowHandle) as SRExcute.DeviceExecute;

                                AddExetue = new frmExecute(context, model1.DeviCode);

                                if (AddExetue.ShowDialog() == DialogResult.OK)
                                {
                                    BgWait1.RunWorkerAsync("SearchData");
                                }
                            }
                            else
                            {
                                ClsMsg.ShowWarningMsg("选中要修改的设备信息");
                            }

                            break;

                        case "bbtnExit":

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
        /// 线程控件响应事件，只需响应搜索事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BgWait1_DoWork(object sender, DoWorkEventArgs e)
        {
            BgWait1.ReportProgress(0);
            try
            {
                switch (e.Argument.ToString())
                {

                    case "SearchData":

                        Tuple<StringBuilder, List<object>> dtFilter = Tuple.Create<StringBuilder, List<object>>(new StringBuilder(), new List<object>());
                        dtFilter.Item1.Append("1=1");
                        FilterProcess.MergeFilterCondition("DevCode", textEdit1.EditValue, ref dtFilter);
                        FilterProcess.MergeFilterCondition("DevpCode", textEdit2.EditValue, ref dtFilter, strCompare: "like");
                        FilterProcess.MergeFilterCondition("DeviCode", textEdit3.EditValue, ref dtFilter);

                        int iCurrPage = (int)page.CurrentPage;
                        int iPageSize = (int)page.PageSize;
                        using (var client = new SRExcute.DevExecuteServiceClient())
                        {
                            var ret = client.GetDevExecutePagedList(context.SessionID, Tuple.Create<string, object[]>(dtFilter.Item1.ToString(), dtFilter.Item2.ToArray()), iPageSize, iCurrPage);


                            if (ret.IsSuccess)
                            {
                                page.CurrentPage = iCurrPage;
                                page.RowCount = ret.TotalNum;
                                e.Result = ret.Data;

                            }
                            else
                                BgWait1.ReportProgress(101, ret.Message);
                        }


                        break;


                    default:
                        break;
                }
            }


            catch (Exception ex)
            {
                BgWait1.ReportProgress(102, ex.Message);
            }

            BgWait1.ReportProgress(100);

        }

        private void BgWait1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //  ClsMsg.ShowWarningMsg("执行指令完成!");
            if (e.Result != null)
            {
                if (e.Result is SRExcute.DeviceExecute[])
                {
                    gridControl1.RefreshDataSource();
                    deviceExecuteBindingSource.DataSource = (e.Result as SRExcute.DeviceExecute[]);
                    this.gridViewPaging1.DataPaging = page;
                    this.gridViewPaging1.PagingReflash();
                }
            }


        }

        private void BgWait1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            bbtniUpdate.PerformClick();
        }

        private void frmDeviceExecuteList_KeyDown(object sender, KeyEventArgs e)
        {

        }

        /// <summary>
        /// 回车键响应事件，在光标在三个搜索栏时，回车键直接响应搜索事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region
        private void textEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//判断回车键
            {
                simpleButton1.PerformClick();//触发按钮事件

            }
        }

        private void textEdit3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//判断回车键
            {
                simpleButton1.PerformClick();//触发按钮事件

            }
        }

        private void textEdit2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//判断回车键
            {
                simpleButton1.PerformClick();//触发按钮事件

            }
        }
        #endregion

        /// <summary>
        /// 上一页以及下一页的跳转功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewPaging1_PagingChanged(object sender, MyPagingEventArgs e)
        {

            if (BgWait1.IsBusy == false)
            {
                gridControl1.RefreshDataSource();
                BgWait1.RunWorkerAsync("SearchData");

            }
        }

    }
}
