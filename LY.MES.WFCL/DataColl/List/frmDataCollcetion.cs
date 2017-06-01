using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Utility.Controls;
using LY.MES.WFCL.SRDataColl;
using Client.Utility;
using Client.Utility.Filter;
using Client.Utility.Logging;
using LY.MES.WFCL.SRFindLeak;

namespace LY.MES.WFCL.DataColl.List
{
    public partial class frmDataCollcetion : BaseForm
    {
        private Paging page = null;
        public frmDataCollcetion(UserContext context)
            : base(context)
        {
            InitializeComponent();
            page = gridViewPaging1.DataPaging;
            backgroundWorker1.ProgressChanged += this.backgroundWorker_ProgressChanged;
        }

        private void frmDataCollcetion_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(0);
            try
            {
                switch (e.Argument.ToString())
                {
                    case "SearchData":
                        Tuple<StringBuilder, List<object>> dtFilter = Tuple.Create<StringBuilder, List<object>>(new StringBuilder() ,new List<object>());
                        dtFilter.Item1.Append("1=1");
                        if (TE_DeveCode.Text !="")
                        {
                            FilterProcess.MergeFilterCondition("DeveCode", TE_DeveCode.Text, ref dtFilter,dataType:FilterProcess.DataType.Int);
                        }
                        FilterProcess.MergeFilterCondition("PDevCode", TE_PDevCode.Text, ref dtFilter);
                        FilterProcess.MergeFilterCondition("DevpCode", TE_DevpCode.Text, ref dtFilter);
                        FilterProcess.MergeFilterCondition("DeviCode", TE_DeviCode.Text, ref dtFilter);

                        int iCurrPage = (int)page.CurrentPage;
                        int iPageSize = (int)page.PageSize;
                        using(var client = new DeviceCollectServiceClient())
                        {
                            var ret = client.GetCollectDataPagedList(context.SessionID, Tuple.Create<string, object[]>(dtFilter.Item1.ToString(), dtFilter.Item2.ToArray()), iPageSize, iCurrPage);
                            if (ret.IsSuccess)
                            {
                                page.CurrentPage = iCurrPage;
                                page.RowCount = ret.TotalNum;
                                e.Result = ret.Data;
                            }
                            else
                            { backgroundWorker1.ReportProgress(101, ret.Message); }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (System.ServiceModel.FaultException<LY.MES.WFCL.SRDataColl.CustomFaultMessage> fex)
            {
                backgroundWorker1.ReportProgress(102, fex.Message);
                Utils.Logger.Error(fex.ToString());
            }
            catch (Exception ex)
            {
                backgroundWorker1.ReportProgress(102, ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
            backgroundWorker1.ReportProgress(100);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                if (e.Result is SRDataColl.VCollectDataInfo[])
                {
                    gridControl1.RefreshDataSource();
                    vCollectDataInfoBindingSource.DataSource = (e.Result as SRDataColl.VCollectDataInfo[]);
                    this.gridViewPaging1.DataPaging = page;
                    this.gridViewPaging1.PagingReflash();
                }
            }
        }

        private void gridViewPaging1_PagingChanged(object sender, MyPagingEventArgs e)
        {
            if (backgroundWorker1.IsBusy == false)
            {
                gridControl1.RefreshDataSource();
                backgroundWorker1.RunWorkerAsync("SearchData");
            }
        }

        private void Bt_Search_Click(object sender, EventArgs e)
        {
            if(backgroundWorker1.IsBusy == false)
            {
                backgroundWorker1.RunWorkerAsync("SearchData");
            }
           
        }
    }
}