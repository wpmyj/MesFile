using Client.Utility;
using Client.Utility.Controls;
using LY.MES.WFCL.SRPiPeline;
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

namespace LY.MES.WFCL.Pipeline
{
    public partial class PipelineOperatingRecord : BaseForm
    {
        private Paging page = null;
        public PipelineOperatingRecord(UserContext context)
            :base(context)
        {
            InitializeComponent();
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            page = gridViewPaging1.DataPaging;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker.ReportProgress(0);
            try
            {
                switch (e.Argument.ToString())
                {
                    case "SearchData":
                        GetOperatingData(e);
                        break;
                    default:
                        break;
                }
            }
            catch(System.ServiceModel.FaultException<CustomFaultMessage> fex)
            {
                backgroundWorker.ReportProgress(102,fex.Message);
                Utils.Logger.Error(fex.ToString());
            }
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
            backgroundWorker.ReportProgress(100);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if(e.Result != null)
                {
                    if(e.Result is SRPiPeline.MainPipelineInfo[])
                    {
                        gridControl1.RefreshDataSource(); 
                        mainPipelineInfoBindingSource.DataSource = e.Result as SRPiPeline.MainPipelineInfo[];
                        this.gridViewPaging1.DataPaging = page;
                        this.gridViewPaging1.PagingReflash();
                    }
                }
            }
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
        }

        public void GetOperatingData(DoWorkEventArgs e)
        {
            using (var Client = new SRPiPeline.PipelineServiceClient())
            {

                int iPageSize = (int)page.PageSize;
                int iCurrPage = (int)page.CurrentPage;

                Tuple<StringBuilder, List<object>> dtFilter = Tuple.Create<StringBuilder, List<object>>(new StringBuilder(), new List<object>());
                dtFilter.Item1.Append("1 = 1");
                if (string.IsNullOrEmpty(te_CheckStartTime.Text) == false && string.IsNullOrEmpty(te_CheckEndTime.Text) == false)
                {
                    var mindate = Convert.ToDateTime(te_CheckStartTime.Text).Date;
                    var maxdate = Convert.ToDateTime(te_CheckEndTime.Text).Date.AddHours(23.99);

                    FilterProcess.MergeFilterCondition("OperatingTime", mindate, ref dtFilter, objValues1: maxdate, dataType: FilterProcess.DataType.DateTime);
                     //FilterProcess.MergeFilterCondition("OperatingTime", Convert.ToDateTime(te_CheckEndTime.Text).Date.AddHours(23.99), ref dtFilter, "<=");
                }
                var ret = Client.GetOperatingRecord(context.SessionID, Tuple.Create<string, object[]>(dtFilter.Item1.ToString(), dtFilter.Item2.ToArray()), iCurrPage, iPageSize);
                if (ret.IsSuccess)
                {
                    page.CurrentPage = iCurrPage;
                    page.RowCount = ret.TotalNum;
                    e.Result = ret.Data;
                }
                else
                {
                    backgroundWorker.ReportProgress(101, ret.Message);
                }
            }
        }

        private void gridViewPaging1_PagingChanged(object sender, Client.Utility.Controls.MyPagingEventArgs e)
        {
            try
            {
                if(backgroundWorker.IsBusy == false)
                {
                    backgroundWorker.RunWorkerAsync("SearchData");
                }
            }
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                if(backgroundWorker.IsBusy == false)
                {
                    backgroundWorker.RunWorkerAsync("SearchData");
                }
            }
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
        }



    }
}
