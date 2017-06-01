using Client.Utility;
using Client.Utility.Controls;
using Client.Utility.Filter;
using LY.MES.WFCL.FindLeak.Frm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LY.MES.WFCL.FindLeak.List
{
    public partial class frmQueryFindLeakList : BaseForm
    {
        private Paging page;

        public frmQueryFindLeakList(UserContext context)
            : base(context)
        {
            InitializeComponent();
            gridView1.CustomDrawEmptyForeground += new GridViewEventTool().GridView_CustomDrawEmptyForeground;
            gridView1.CustomDrawRowIndicator += new GridViewEventTool().GridView_CustomDrawRowIndicator;
            page = gridViewPaging1.DataPaging;

            BgWait1.ProgressChanged += this.backgroundWorker_ProgressChanged;

        }
        public frmQueryFindLeakList()
        {
            InitializeComponent();
        }

        private void QueryFindLeak_Load(object sender, EventArgs e)
        {
            dateEdit1.EditValue = DateTime.Now.Date;
            // TODO:  这行代码将数据加载到表“lYMesSystemDataSet7.QC_DrumsFindLeakReport”中。您可以根据需要移动或删除它。
            // this.qC_DrumsFindLeakReportTableAdapter.Fill(this.lYMesSystemDataSet7.QC_DrumsFindLeakReport);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            BgWait1.RunWorkerAsync("SearchData");
        }

        private void BgWait1_DoWork(object sender, DoWorkEventArgs e)
        {

            BgWait1.ReportProgress(PubConstant.WaitMessageStatus.START);
            try
            {
                switch (e.Argument.ToString())
                {

                    case "SearchData":

                        Tuple<StringBuilder, List<object>> dtFilter = Tuple.Create<StringBuilder, List<object>>(new StringBuilder(), new List<object>());
                        dtFilter.Item1.Append("1=1");
                        FilterProcess.MergeFilterCondition("FLVCode", textEdit1.EditValue, ref dtFilter, strCompare: "like");
                        FilterProcess.MergeFilterCondition("CreateDate", dateEdit1.EditValue, ref dtFilter, dataType: FilterProcess.DataType.Date, strCompare: ">=");

                        int iCurrPage = (int)page.CurrentPage;
                        int iPageSize = (int)page.PageSize;
                        using (var client = new SRFindLeak.QCDFindLeakServiceClient())
                        {
                            var ret = client.GetQCDrumsFindLeakList(context.SessionID, Tuple.Create<string, object[]>(dtFilter.Item1.ToString(), dtFilter.Item2.ToArray()), iPageSize, iCurrPage);
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
                
                BgWait1.ReportProgress(PubConstant.WaitMessageStatus.ERROR, ex.Message);
            }

            BgWait1.ReportProgress(100);
        }

        private void BgWait1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Result != null)
            {

                if (e.Result is SRFindLeak.QC_DrumsFindLeakReport[])
                {
                    gridControl1.RefreshDataSource();

                    qCDrumsFindLeakReportBindingSource.DataSource = (e.Result as SRFindLeak.QC_DrumsFindLeakReport[]);

                    this.gridViewPaging1.DataPaging = page;
                    this.gridViewPaging1.PagingReflash();
                }
            }
        }

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
