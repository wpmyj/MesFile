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

namespace LY.MES.WFCL.Refer
{

    /// <summary>
    /// Author:xxp
    /// Remark:工艺信息选择
    /// CreateDate:20161213
    /// </summary>
    /// 
    public partial class frmReferCrafts : BaseForm
    {
        /// <summary>
        /// 所属车间
        /// </summary>
        public string WorkShop;
        /// <summary>
        /// 工艺编号
        /// </summary>
        public string CraftsCode;
        /// <summary>
        /// 工艺名称
        /// </summary>
        public string CraftsName;
        public frmReferCrafts(UserContext context)
            : base(context)
        {
            InitializeComponent();
            backgroundWorker1.ProgressChanged += this.backgroundWorker_ProgressChanged;
            gridView1.CustomDrawRowIndicator += new GridViewEventTool().GridView_CustomDrawRowIndicator;
        }

        /// <summary>
        /// 窗体初始化加载
        /// </summary>    
        private void frmReferCrafts_Load(object sender, EventArgs e)
        {
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
            backgroundWorker1.ReportProgress(PubConstant.WaitMessageStatus.START);
            try
            {
                switch (e.Argument.ToString())
                {
                    case "SearchData":
                        using (SRQZData.QZDataServiceClient client = new SRQZData.QZDataServiceClient())
                        {
                            e.Result = client.GetCraftsTable(context.SessionID);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (System.ServiceModel.FaultException<SRQZData.CustomFaultMessage> fex)
            {
                Utils.Logger.Error(fex.ToString());
                backgroundWorker1.ReportProgress(PubConstant.WaitMessageStatus.ERROR, fex.Message);
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                backgroundWorker1.ReportProgress(PubConstant.WaitMessageStatus.ERROR, ex.Message);
            }
            backgroundWorker1.ReportProgress(PubConstant.WaitMessageStatus.END);
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
                if (e.Result is DataTable)
                {
                    gridControl1.DataSource = e.Result;
                    gridControl1.RefreshDataSource();
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
                            var currModel = (gridView1.GetRow(gridView1.FocusedRowHandle) as DataRowView).Row;
                            this.WorkShop = currModel["WorkShop"].ToString();
                            this.CraftsCode = currModel["CraftsCode"].ToString();
                            this.CraftsName = currModel["CraftsName"].ToString();
                            this.DialogResult = DialogResult.OK;
                            break;
                        case "bbtiClear":
                            this.WorkShop = null;
                            this.CraftsCode = null;
                            this.CraftsName = null;
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

        #endregion

        #region Mothod

        /// <summary>
        /// 双击列表选择当前选定的参数数据
        /// </summary>  
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            bbtiEnsure.PerformClick();
        }

        #endregion

    }
}
