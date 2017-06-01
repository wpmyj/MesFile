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

namespace LY.MES.WFCL.Refer
{
    /// <summary>
    /// Author:pjh
    /// Remark:设备接口列表选择
    /// CreateDate:20161031
    /// </summary>
    /// 

    public partial class frmInterfaceChoose : BaseForm
    {

        private SRDevice.DeviceServiceClient client = null;
        private Paging page;
        public string DevCode;
        public string DeviCode;
        public string DevpCode;

        public frmInterfaceChoose(UserContext context)
            : base(context)
        {
            InitializeComponent();
            page = gridViewPaging1.DataPaging;
        }

        /// <summary>
        /// 窗体初始化加载
        /// </summary>    
        private void frmInterfaceChoose_Load(object sender, EventArgs e)
        {
            client = new SRDevice.DeviceServiceClient();
            BGW1.RunWorkerAsync("SearchData");
        }

        #region Event

        /// <summary>
        /// 异步事务工作事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BGW1_DoWork(object sender, DoWorkEventArgs e)
        {
            BGW1.ReportProgress(0);
            try
            {
                switch (e.Argument.ToString())
                {
                    case "SearchData":
                        int CurrPage = (int)page.CurrentPage;
                        int PageSize = (int)page.PageSize;
                        Tuple<string, object[]> tWhere = null;
                        if (CheckTextEdit.Text.IsNullOrEmpty() == false)
                        {
                            string strWhere = "1=1 and (DevCode.Contains(@0) or DeviCode.Contains(@0) or DeviName.Contains(@0) or DevpCode.Contains(@0) ) ";
                            tWhere = Tuple.Create<string, object[]>(strWhere, new object[] { CheckTextEdit.Text });
                        }

                        using (SRDevice.DeviceServiceClient client = new SRDevice.DeviceServiceClient())
                        {
                            var ret = client.GetDevInterfacePagedList(context.SessionID, tWhere, PageSize, CurrPage);
                            if (ret.IsSuccess)
                            {
                                page.CurrentPage = CurrPage;
                                page.RowCount = ret.TotalNum;
                                e.Result = ret.Data;
                            }
                            else
                                BGW1.ReportProgress(101, ret.Message);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                BGW1.ReportProgress(101, ex.Message);
            }
            BGW1.ReportProgress(100);
        }

        /// <summary>
        /// 异步控件完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BGW1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                if (e.Result is SRDevice.DeviceInterface[])
                {
                    gridControl1.RefreshDataSource();
                    deviceInterfaceBindingSource.DataSource = (e.Result as SRDevice.DeviceInterface[]);
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
                if (BGW1.IsBusy == false)
                {
                    switch (e.Item.Name)
                    {
                        case "bbtnEnsure":
                             string a = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DevCode").ToString();
            DevCode = a;


            string b = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DeviCode").ToString();
            DeviCode = b;

            string c = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DevpCode").ToString();
            DevpCode = c;

                            this.DialogResult = DialogResult.OK;
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
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewPaging1_PagingChanged(object sender, MyPagingEventArgs e)
        {
            if (BGW1.IsBusy == false)
            {
                gridControl1.RefreshDataSource();
                BGW1.RunWorkerAsync("SearchData");
            }
        }

        /// <summary>
        /// 模糊搜索事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckSimpleButton_Click(object sender, EventArgs e)
        {
            if (BGW1.IsBusy == false)
            {
                gridControl1.RefreshDataSource();
                BGW1.RunWorkerAsync("SearchData");
            }
        }

        #endregion


        #region Mothod
        /// <summary>
        /// 双击列表选择当前选定的参数数据
        /// </summary>  
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {

            string a = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DevCode").ToString();
            DevCode = a;


            string b = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DeviCode").ToString();
            DeviCode = b;

            string c = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DevpCode").ToString();
            DevpCode = c;

            this.DialogResult = DialogResult.OK;
        }

        #endregion
       
    }
}
