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

namespace LY.MES.WFCL.Refer
{
    public partial class frmOrderChoose : BaseForm
    {
        private BindingSource modelSource = null;

        //private SRExcute.DevExecuteServiceClient client = null;

        private Paging page;
        /// <summary>
        /// 订单类型
        /// </summary>
        public string OrderType;
        /// <summary>
        /// 订单单号
        /// </summary>
        public string OrderID;
        /// <summary>
        /// 机台号
        /// </summary>
        public string Machine;
        /// <summary>
        /// 产线
        /// </summary>
        public string LineNum;
        /// <summary>
        /// 强度
        /// </summary>
        public string Strength;
        /// <summary>
        /// 规格
        /// </summary>
        public string Specifications;

        public frmOrderChoose(UserContext context)
            : base(context)
        {
            InitializeComponent();
            modelSource = new BindingSource();
            page = gridViewPaging1.DataPaging;

            backgroundWorker1.ProgressChanged += this.backgroundWorker_ProgressChanged;

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void frmOrderChoose_Load(object sender, EventArgs e)
        {

            backgroundWorker1.RunWorkerAsync("SearchData");

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //using (SRQZData.QZDataServiceClient client = new SRQZData.QZDataServiceClient())
            //{
            //    modelSource.DataSource = client.GetOrderSchData(context.SessionID, null);
            //    gridControl1.DataSource = modelSource;
            //}


            //if (backgroundWorker1.IsBusy == false)
            //{
            //    gridControl1.RefreshDataSource();
            //    backgroundWorker1.RunWorkerAsync("SearchData");
            //}

            backgroundWorker1.RunWorkerAsync("SearchData");


        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {

            bbtnensure.PerformClick();


        }

        private void bbtnensure_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {
                if (backgroundWorker1.IsBusy == false)
                {
                    switch (e.Item.Name)
                    {
                        case "bbtnensure":
                            string a = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "销售方式").ToString();
                            OrderType = a;


                            string b = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "明细ID").ToString();
                            OrderID = b;

                            string c = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "机台").ToString();
                            Machine = c;

                            string d = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "线号").ToString();
                            LineNum = d;

                            string f = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "强度").ToString();
                            Strength = f;

                            string g = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "规格").ToString();
                            Specifications = g;



                            this.DialogResult = DialogResult.OK;
                            break;


                        case "bbtnexit":
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

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                if (e.Result is DataTable)
                {
                    gridControl1.RefreshDataSource();
                    modelSource.DataSource = e.Result;
                    gridControl1.DataSource = modelSource;
                    this.gridViewPaging1.DataPaging = page;
                    this.gridViewPaging1.PagingReflash();
                }
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


                        //Tuple<string, object[]> tWhere = null;
                        //if (ChecktextEdit.Text.IsNullOrEmpty() == false)
                        //{a
                        //    string strWhere = "1=1 and (  明细ID.Contains(@0) ) ";
                        //    tWhere = Tuple.Create<string, object[]>(strWhere, new object[] { ChecktextEdit.Text });ref int iTotalNum
                        //}

                        var dtWhere = FilterProcess.CreateFilterTable();
                        FilterProcess.MergeFilterCondition("明细ID", ChecktextEdit.Text, ref dtWhere, strCompare: "like");

                        using (SRQZData.QZDataServiceClient client = new SRQZData.QZDataServiceClient())
                        {
                            int TotalNum = 0;
                            var ret = client.GetOrderSchData(context.SessionID, dtWhere, PageSize, CurrPage, ref TotalNum);

                            page.CurrentPage = CurrPage;
                            page.RowCount = TotalNum;
                            e.Result = ret;
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                backgroundWorker1.ReportProgress(102, ex.Message);
            }
            backgroundWorker1.ReportProgress(100);
        }

        private void frmOrderChoose_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void ChecktextEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//判断回车键
            {
                simpleButton1.PerformClick();//触发按钮事件
                //    MessageBox.Show("123321");
            }
        }

        private void gridViewPaging1_PagingChanged(object sender, MyPagingEventArgs e)
        {
            if (backgroundWorker1.IsBusy == false)
            {
               // gcDevice.RefreshDataSource();
                backgroundWorker1.RunWorkerAsync("SearchData");
            }
        }

    }
}
