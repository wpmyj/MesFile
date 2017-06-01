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
using Client.Utility.Logging;

namespace LY.MES.WFCL.FindLeak.Frm
{
    public partial class frmQueryDrumsSetList : BaseForm
    {
        private Paging page;
       
        public frmQueryDrumsSetList(UserContext context)
            : base(context)
        {
            InitializeComponent();
            page = gridViewPaging1.DataPaging;
            gridView1.CustomDrawEmptyForeground += new GridViewEventTool().GridView_CustomDrawEmptyForeground;
            gridView1.CustomDrawRowIndicator += new GridViewEventTool().GridView_CustomDrawRowIndicator;
            BgWait1.ProgressChanged += this.backgroundWorker_ProgressChanged;

        }
        public frmQueryDrumsSetList()
        {
            InitializeComponent();
        }

        private void QuyryDrumsSet_Load(object sender, EventArgs e)
        {
            dateEdit1.EditValue = DateTime.Now.Date;
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

                        FilterProcess.MergeFilterCondition("ID", textEdit1.EditValue, ref dtFilter, dataType: FilterProcess.DataType.Int);
                        FilterProcess.MergeFilterCondition("CreateDate", dateEdit1.EditValue, ref dtFilter, dataType: FilterProcess.DataType.Date, strCompare: ">=");
                        int iCurrPage = (int)page.CurrentPage;
                        int iPageSize = (int)page.PageSize;

                        using (var client = new SRQZDDrumesSet.QCDrumsSetServiceClient())
                        {
                            var ret = client.GetQCDrumsFindLeakList1(context.SessionID, Tuple.Create<string, object[]>(dtFilter.Item1.ToString(), dtFilter.Item2.ToArray()), iPageSize, iCurrPage);
                            if (ret.IsSuccess)
                            {
                                page.CurrentPage = iCurrPage;
                                page.RowCount = ret.TotalNum;
                                e.Result = ret.Data;
                            }
                            else
                                BgWait1.ReportProgress(PubConstant.WaitMessageStatus.WARNING, ret.Message);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                BgWait1.ReportProgress(PubConstant.WaitMessageStatus.ERROR, ex.Message);
            }
            BgWait1.ReportProgress(PubConstant.WaitMessageStatus.END);
        }

        private void BgWait1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Result is SRQZDDrumesSet.QC_FindLeakDrumsSet[])
            {
                gridControl1.RefreshDataSource();

                qCFindLeakDrumsSetBindingSource.DataSource = (e.Result
                    as SRQZDDrumesSet.QC_FindLeakDrumsSet[]);

                this.gridViewPaging1.DataPaging = page;
                this.gridViewPaging1.PagingReflash();
            }

        }
        //private void gridViewPaging1_PagingChanged(object sender, MyPagingEventArgs e)
        //{
        //    if (BgWait1.IsBusy == false)
        //    {
        //        gridControl1.RefreshDataSource();
        //        BgWait1.RunWorkerAsync("SearchData");
        //    }

        //}


        private void gridViewPaging1_PagingChanged_1(object sender, MyPagingEventArgs e)
        {
            if (BgWait1.IsBusy == false)
            {
                gridControl1.RefreshDataSource();
                BgWait1.RunWorkerAsync("SearchData");
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                int ID = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString());
                var frm = new frmQCDrumsSet(context, ID);
                frm.ShowDialog();
            }
        }
    }
}

