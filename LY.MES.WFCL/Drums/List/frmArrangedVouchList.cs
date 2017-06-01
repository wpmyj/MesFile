using Client.Utility;
using Client.Utility.Controls;
using Client.Utility.Filter;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Utility.Logging;
using LY.MES.WFCL.Drums.Frm;

namespace LY.MES.WFCL.Drums.List
{
    public partial class frmArrangedVouchList : BaseForm
    {
        private Paging page;

        public frmArrangedVouchList(UserContext context)
            : base(context)
        {
            InitializeComponent();
            page = gridViewPaging2.DataPaging;
            BgWait1.ProgressChanged += this.backgroundWorker_ProgressChanged;
            gridView1.CustomDrawEmptyForeground += new GridViewEventTool().GridView_CustomDrawEmptyForeground;
            gridView1.CustomDrawRowIndicator += new GridViewEventTool().GridView_CustomDrawRowIndicator;

            dStartDate.Text = DateTime.Now.ToShortDateString();
            dEndDate.Text = DateTime.Now.ToShortDateString();
        }

        private void frmArrangedVouch_Load(object sender, EventArgs e)
        {
            try
            {
                var UserStatusData = DataEnum.GetEnumData(context, "CF.UserStatus");
                UserStatusLookUpEdit.DataSource = UserStatusData;
                UseStatusLookUpEdit.Properties.DataSource = UserStatusData;
                UseStatusLookUpEdit.EditValue = "1";
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (BgWait1.IsBusy == false)
            {
                page.CurrentPage = 1;
                BgWait1.RunWorkerAsync("SearchData");
            }
        }

        private void BgWait1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Result is SRArrangedVouch.ArrangedVouch[])
            {
                gridControl1.RefreshDataSource();

                arrangedVouchBindingSource.DataSource = (e.Result
                    as SRArrangedVouch.ArrangedVouch[]);

                this.gridViewPaging2.DataPaging = page;
                this.gridViewPaging2.PagingReflash();
            }
        }

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

                        FilterProcess.MergeFilterCondition("ArrangedVouchCode", textEdit1.EditValue, ref dtFilter);
                        FilterProcess.MergeFilterCondition("MaterialVouchCode", textEdit2.EditValue, ref dtFilter);
                        FilterProcess.MergeFilterCondition("FormulaCode", textEdit3.EditValue, ref dtFilter);
                        FilterProcess.MergeFilterCondition("FormulaName", textEdit4.EditValue, ref dtFilter);
                        FilterProcess.MergeFilterCondition("UserStatus", Convert.ToInt32(UseStatusLookUpEdit.EditValue), ref dtFilter, dataType: FilterProcess.DataType.Int);

                        FilterProcess.MergeFilterCondition("VouchDate", dStartDate.EditValue, ref dtFilter, objValues1: dEndDate.EditValue, dataType: FilterProcess.DataType.DateTime);//按日期区间查询

                        int iCurrPage = (int)page.CurrentPage;
                        int iPageSize = (int)page.PageSize;

                        //using (var client = new SRArrangedVouch.ArrangedVServiceClient())
                        //{


                        var ret = WCFHelper.InvokeService<SRArrangedVouch.IArrangedVServiceChannel, SRArrangedVouch.CommonResultOfArrayOfArrangedVouchdYMi5huk>(context, wcf => wcf.GetArrangedVouchList(context.SessionID, Tuple.Create<string, object[]>(dtFilter.Item1.ToString(), dtFilter.Item2.ToArray()), iPageSize, iCurrPage));
                        //var ret = client.GetArrangedVouchList(context.SessionID, Tuple.Create<string, object[]>(dtFilter.Item1.ToString(), dtFilter.Item2.ToArray()), iPageSize, iCurrPage);
                        if (ret.IsSuccess)
                        {
                            page.CurrentPage = iCurrPage;
                            page.RowCount = ret.TotalNum;
                            e.Result = ret.Data;
                        }
                        else
                            BgWait1.ReportProgress(101, ret.Message);
                        // }
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

        private void gridViewPaging2_PagingChanged(object sender, MyPagingEventArgs e)
        {
            if (BgWait1.IsBusy == false)
            {
                gridControl1.RefreshDataSource();
                BgWait1.RunWorkerAsync("SearchData");
            }
        }

        private void barManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                switch (e.Item.Name)
                {
                    case "bbtniCarftsExecute":
                        if (gridView1.FocusedRowHandle >= 0)
                        {
                            string ArrangedVouchCode = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ArrangedVouchCode").ToString();
                            frmCfPExecute frm = new frmCfPExecute(context, ArrangedVouchCode);
                            frm.ShowDialog();
                        }
                        break;
                    case "bbtniDetails":
                        if (gridView1.FocusedRowHandle >= 0)
                        {
                            string ArrangedVouchCode = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ArrangedVouchCode").ToString();
                            frmArrangedVouch frm = new frmArrangedVouch(context, ArrangedVouchCode);
                            frm.ShowDialog();
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                ClsMsg.ShowErrMsg(ex.Message);
            }
        }

        private void cmsList_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "tsmiCraftExecute":
                    bbtniCarftsExecute.PerformClick();
                    break;
                case "tsmiDetails":
                    bbtniDetails.PerformClick();
                    break;
                default:
                    break;
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            bbtniDetails.PerformClick();
        }
    }
}
