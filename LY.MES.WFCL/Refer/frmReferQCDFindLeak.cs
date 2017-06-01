using Client.Utility;
using Client.Utility.Controls;
using System;
using Client.Utility.Logging;
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

    public partial class frmReferQCDFindLeak : BaseForm
    {
        public Client.Utility.Controls.GridCheckMarksSelection gmc;

        private int iYear;
        private int iMonth;
        private int strWeek;

        public frmReferQCDFindLeak(UserContext context, int iYear, int iMonth, int strWeek)
            : base(context)
        {
            InitializeComponent();
            backgroundWorker1.ProgressChanged += this.backgroundWorker_ProgressChanged;
            gridView1.CustomDrawRowIndicator += new GridViewEventTool().GridView_CustomDrawRowIndicator;
            gridView1.CustomDrawEmptyForeground += new GridViewEventTool().GridView_CustomDrawEmptyForeground;
            gmc = new GridCheckMarksSelection(this.gridView1);

            this.iYear = iYear;
            this.iMonth = iMonth;
            this.strWeek = strWeek;
        }

        /// <summary>
        /// 窗体初始化加载
        /// </summary>  
        private void frmQCDFindLeakChoose_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync("SearchData");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(PubConstant.WaitMessageStatus.START);
            try
            {
                switch (e.Argument.ToString())
                {
                    case "SearchData":

                        //打开窗口显示列表数据
                        using (var client = new SRQZDDrumesSet.QCDrumsSetServiceClient())//引用服务
                        {
                            var retlog = client.GetQCDrumsList(context.SessionID, iYear, iMonth, strWeek); // 筛选择转鼓当天待检漏信息

                            if (retlog.IsSuccess)
                            {
                                e.Result = retlog.Data;

                            }
                            else { backgroundWorker1.ReportProgress(PubConstant.WaitMessageStatus.WARNING, retlog.Message); }

                        }

                        break;

                }
            }
            catch (Exception ex)
            {
                backgroundWorker1.ReportProgress(PubConstant.WaitMessageStatus.ERROR, ex.Message);
            }

            backgroundWorker1.ReportProgress(PubConstant.WaitMessageStatus.END);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                if (e.Result is SRQZDDrumesSet.vw_DurmsUpFeeding[])
                {
                    gridControl1.RefreshDataSource();

                    vwDurmsUpFeedingBindingSource.DataSource = (e.Result
                        as SRQZDDrumesSet.vw_DurmsUpFeeding[]);

                }
            }
        }

        private void barManager2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {
                if (backgroundWorker1.IsBusy == false)
                {
                    switch (e.Item.Name)
                    {
                        case "ButAdd":
                            if (gmc.GetSelectedRows().Count > 0)
                            {
                                this.DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                ClsMsg.ShowWarningMsg("请勾选检漏的转鼓");
                            }
                            break;

                        case "ButExit":
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

        //private void ButAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    FrmQCDrumsSet table = new FrmQCDrumsSet();
        //    table.Flag = gridControl1.Text;


        //    ////关键地方 ↓
        //    if (table != null)
        //    {
        //        gridControl1.Text = table.Flag;
        //        MessageBox.Show("选定成功");
        //        this.Close();
        //    }
        //}
    }
}
