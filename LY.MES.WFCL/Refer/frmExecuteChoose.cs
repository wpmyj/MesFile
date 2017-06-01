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


    public partial class frmExecuteChoose : BaseForm
    {

       // private SRDevice.DeviceServiceClient client = null;
        private SRExcute.DevExecuteServiceClient client = null;

        private Paging page;
        public string DeveCode;
        public string DevCode;
        public string DeviCode;
        public string DevpCode;
     

        public frmExecuteChoose(UserContext context)
            : base(context)
        {
            InitializeComponent();
            page = gridViewPaging1.DataPaging;

        }

        private void frmExecuteChoose_Load(object sender, EventArgs e)
        {

            client = new SRExcute.DevExecuteServiceClient();
            backgroundWorker1.RunWorkerAsync("SearchData");


        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {

            bbtnEnsure.PerformClick();


            //string a = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DevCode").ToString();
            //DevCode = a;


            //string b = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DeviCode").ToString();
            //DeviCode = b;

            //string c = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DevpCode").ToString();
            //DevpCode = c;

            //string d = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DeveCode").ToString();
            //DeveCode = d;

            //this.DialogResult = DialogResult.OK;
        }

        private void barManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (backgroundWorker1.IsBusy == false)
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

                             string d = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DeveCode").ToString();
                             DeveCode = d;

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
                        if (CheckTextEdit.Text.IsNullOrEmpty() == false)
                        {
                            string strWhere = "1=1 and ( DeviCode.Contains(@0) or DeviCode.Contains(@0) or DevpCode.Contains(@0) ) ";
                            tWhere = Tuple.Create<string, object[]>(strWhere, new object[] { CheckTextEdit.Text });
                        }

                        using (SRExcute.DevExecuteServiceClient client = new SRExcute.DevExecuteServiceClient())
                        {
                            var ret = client.GetDevExecutePagedList(context.SessionID, tWhere, PageSize, CurrPage);
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

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy == false)
            {
                gridControl1.RefreshDataSource();
                backgroundWorker1.RunWorkerAsync("SearchData");
            }
        }
    }
}
