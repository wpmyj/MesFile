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


namespace LY.MES.WFCL.CustomControl
{
    public partial class StockPanel : BaseForm
    {
        public StockPanel(UserContext context)
            : base(context)
        {


            InitializeComponent();

            setGridKanbanCallbak = new SetGridKanbanCallbak(DataTableAssign);
            try
            {
                ProgramDataInit();

                GridInit();

                ListViewInit();

                StockInit();

                ZKDataInit();

                timer1.Interval = 10000;

                timer1.Enabled = true;
            }

            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
            }

        }

        #region Init

        DataTable dt = new DataTable();

        DataTable Newret;
        DataTable ret = null;
        object query1, query2, queryWeight1, queryWeight2;//query1每鼓合计重量，原料未上料绑卡合计重量
        decimal? ArrInputWeight11 = 0;
        decimal? ArrInputWeight21 = 0;
        decimal? ArrInputWeight12 = 0;
        decimal? ArrInputWeight22 = 0;

        private DataTable DrumDryData = null; //类变量，获取转鼓状态数据
        private DataTable DrumColor = null; //获取转鼓配方单的颜色代码
        private DataTable QZFunColor = null; //获取勤哲看板颜色基础表
        private DataTable RFIDData = null; //获取勤哲未上料数据集合

        DataView TestRfidData = null;   //左上角基础表视图 为颜色唯一性做准备
        DataTable TestRfidDistinct = null;  //左上角基础表视图 存储颜色唯一性数据

        DataView TestZGData = null;   //右上角基础表视图 为颜色唯一性做准备
        DataTable TestZGDistinct = null;  //右上角基础表视图 存储颜色唯一性数据

        DataTable TestData4 = null;
        DataTable TestData5 = null;


        private string[] ColorDataArray = new string[20];

        private delegate void SetGridKanbanCallbak(object queryWeight, decimal? ArrInputWeight1, decimal? ArrInputWeight2, object query, int StartLocation, int StartCount);
        private SetGridKanbanCallbak setGridKanbanCallbak = null;  //订阅委托事件，用于处理左下角异步修改控件值的情况


        #endregion

        #region Event

        /// <summary>
        /// 定时器更新三个控件的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!BgWait.IsBusy)
                    BgWait.RunWorkerAsync("GetCrafData");

                if (!BgWaitDrumDry.IsBusy)
                {
                    ZGNullColor.Items.Clear();
                    ZGFundaVW.Items.Clear();
                    listView1.Items.Clear();
                    BgWaitDrumDry.RunWorkerAsync("GetInitDrumDryData");
                }


                if (!BgWaitStockArea.IsBusy)
                {
                    listView2.Items.Clear();
                    StockFundaVW.Items.Clear();
                    BgWaitStockArea.RunWorkerAsync("GetInitRFIDData");
                }


                if (!CylinderBgWait.IsBusy)
                {


                    CylinderBgWait.RunWorkerAsync("GetZKLData");
                }

            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
            }

        }

        private void bandedGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == bandedGridColumn7)
            {
                DrawProgressBar(e);

                e.Handled = true;

            }
        }

        /// <summary>
        /// 合并行，第6列以后进行行合并操作，并且已5行为基数进行合并
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bandedGridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {

            if (e.Column.ColumnHandle < 5)
            {
                if (e.RowHandle2 != 5)
                    e.Merge = true;
                e.Handled = true;
            }
            else
            {
                e.Merge = false;
                e.Handled = true;
            }


        }

        /// <summary>
        /// 获取更新左下角看板数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BgWait_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                switch (e.Argument.ToString())
                {

                    case "GetWeight":

                        e.Result = "GetWeight";

                        break;

                    case "GetCrafData":

                        e.Result = "GetCrafData";
                        using (var QZclient = new SRQZData.QZDataServiceClient())
                        {
                            //      var Newret = QZclient.GetQZZGData(context.SessionID, DateTime.Now);
                            Newret = QZclient.GetQZZGData(context.SessionID, DateTime.Now);
                            try
                            {
                                try
                                {
                                    if (Newret != null && Newret.Rows.Count > 0)
                                    {
                                        if (Newret.Rows[0] != null)
                                        {

                                            ArrInputWeight11 = 0;
                                            ArrInputWeight21 = 0;

                                            using (var Arrclient = new SRArrangedVouch.ArrangedVServiceClient())
                                            {

                                                var NewArr2 = Arrclient.GetArrangedVouchByMulaCode(context.SessionID, Newret.Rows[0]["配方单号"].ToString(), 100);
                                                if (NewArr2.Data != null)
                                                {
                                                    ArrInputWeight21 = NewArr2.Data.Sum(t => t.InputWeight) / 1000;

                                                }

                                                var NewArr1 = Arrclient.GetArrangedVouchByMulaCode(context.SessionID, Newret.Rows[0]["配方单号"].ToString(), 1);
                                                if (NewArr1.Data != null)
                                                {
                                                    ArrInputWeight11 = NewArr1.Data.Sum(t => t.InputWeight) / 1000;

                                                }
                                            }



                                            var RFIDWeight1 = QZclient.GetRFIDWeight(context.SessionID, Newret.Rows[0]["配方单号"].ToString());

                                            queryWeight1 = TestQueryWeight(QZclient, Newret, 0);

                                            query1 = RFIDWeight1.Compute("sum(每鼓合计重量)/1000", "1=1");

                                            if (query1.ToString() == "")
                                            {
                                                query1 = 0;
                                            }

                                            setGridKanbanCallbak(queryWeight1, ArrInputWeight11, ArrInputWeight21, query1, 0, 0);
                                        }
                                        if (Newret.Rows[1] != null)
                                        {

                                            ArrInputWeight12 = 0;
                                            ArrInputWeight22 = 0;
                                            using (var Arrclient = new SRArrangedVouch.ArrangedVServiceClient())
                                            {
                                                var NewArr2 = Arrclient.GetArrangedVouchByMulaCode(context.SessionID, Newret.Rows[1]["配方单号"].ToString(), 100);
                                                if (NewArr2.Data != null)
                                                {
                                                    ArrInputWeight22 = NewArr2.Data.Sum(t => t.InputWeight) / 1000;

                                                }
                                                var NewArr1 = Arrclient.GetArrangedVouchByMulaCode(context.SessionID, Newret.Rows[1]["配方单号"].ToString(), 1);
                                                if (NewArr1.Data != null)
                                                {
                                                    ArrInputWeight12 = NewArr1.Data.Sum(t => t.InputWeight) / 1000;

                                                }

                                                var RFIDWeight = QZclient.GetRFIDWeight(context.SessionID, Newret.Rows[1]["配方单号"].ToString());

                                                queryWeight2 = TestQueryWeight(QZclient, Newret, 1);

                                                query2 = RFIDWeight.Compute("sum(每鼓合计重量)/1000", "1=1");

                                                if (query2.ToString() == "")
                                                {
                                                    query2 = 0;
                                                }
                                                //   DataTableAssign(Newret, queryWeight1, ArrInputWeight1, ArrInputWeight2, query1, 5, 1);
                                                setGridKanbanCallbak(queryWeight2, ArrInputWeight12, ArrInputWeight22, query2, 5, 1);
                                            }
                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show("没有该备料数据信息");
                                    }


                                }
                                catch (Exception ex)
                                {
                                    //   ClsMsg.ShowErrMsg(ex.Message);
                                    Utils.Logger.Error(ex.ToString());
                                }
                                //    });
                                //}
                            }
                            catch (Exception ex)
                            {
                                //  ClsMsg.ShowErrMsg(ex.Message);
                                Utils.Logger.Error(ex.ToString());
                                //    Utils.Logger.Error(ex.ToString());
                            }

                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                // Utils.Logger.Error(ex.ToString());
                Utils.Logger.Error(ex.ToString());
            }
        }

        /// <summary>
        /// 线程完成时间，更新控件数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BgWait_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


            //   DataTableAssign(Newret, queryWeight1, ArrInputWeight11, ArrInputWeight21, query1, 0, 0);


            //    DataTableAssign(Newret, queryWeight2, ArrInputWeight12, ArrInputWeight22, query2, 5, 1);
            try
            {
                UpdateRealData();
            }

            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
            }


        }

        /// <summary>
        /// 实时估算未备余量数据更新
        /// </summary>
        private void UpdateRealData()
        {
            try
            {


                if (TestData4 != null && TestData4.Rows.Count > 0 && TestData5 != null && TestData5.Rows.Count > 0)
                {
                    string ArrInputWeight1 = ArrInputWeight11.ToString();//烘料中合计重量     ArrInputWeight1
                    string ArrInputWeight2 = ArrInputWeight21.ToString();//烘料后合计重量     ArrInputWeight2
                    string query = query1.ToString();//备料区，每鼓合计重量         query
                    string queryWeight = queryWeight1.ToString();//合计已产成品           queryWeight    
                    string ActCumulative = Newret.Rows[0]["实际备料累计T"].ToString(); //ActCumulative
                    string ExpStock = Newret.Rows[0]["预计备料量T"].ToString();   //ExpStock
                    string CycleProData = Newret.Rows[0]["周期产量T"].ToString();    //CycleProData
                    string CylinderWeight4 = TestData4.Rows[0]["料缸重量"].ToString();   //CylinderWeight4
                    string CylinderWeight5 = TestData5.Rows[0]["料缸重量"].ToString();   //CylinderWeight5


                    string ArrInputWeight23 = ArrInputWeight12.ToString();//烘料中合计重量     ArrInputWeight1
                    string ArrInputWeight24 = ArrInputWeight22.ToString();//烘料后合计重量     ArrInputWeight2
                    string query22 = query2.ToString();//备料区，每鼓合计重量         query
                    string queryWeight22 = queryWeight2.ToString();//合计已产成品           queryWeight
                    string ActCumulative22 = Newret.Rows[1]["实际备料累计T"].ToString(); //ActCumulative
                    string ExpStock22 = Newret.Rows[1]["预计备料量T"].ToString();   //ExpStock
                    string CycleProData22 = Newret.Rows[1]["周期产量T"].ToString();    //CycleProData

                    if (Convert.ToDecimal(queryWeight) == 0)
                    {
                        dt.Rows[0][4] = Convert.ToDecimal(ExpStock) - Convert.ToDecimal(ActCumulative);
                    }
                    else if (Convert.ToDecimal(queryWeight) >= Convert.ToDecimal(CycleProData))
                    {
                        dt.Rows[0][4] = "0";
                    }
                    else if (Convert.ToDecimal(queryWeight) < Convert.ToDecimal(CycleProData))
                    {
                        dt.Rows[0][4] = CalcuRealData(query, queryWeight, ArrInputWeight1, ArrInputWeight2, ActCumulative, ExpStock, CycleProData, CylinderWeight4, CylinderWeight5);

                    }



                    if (Convert.ToDecimal(queryWeight22) == 0)
                    {
                        dt.Rows[5][4] = Convert.ToDecimal(ExpStock22) - Convert.ToDecimal(ActCumulative22);
                    }
                    else if (Convert.ToDecimal(queryWeight22) >= Convert.ToDecimal(CycleProData22))
                    {
                        dt.Rows[5][4] = "0";
                    }
                    else if (Convert.ToDecimal(queryWeight22) < Convert.ToDecimal(CycleProData22))
                    {
                        dt.Rows[5][4] = CalcuRealData(query22, queryWeight22, ArrInputWeight23, ArrInputWeight24, ActCumulative22, ExpStock22, CycleProData22, CylinderWeight4, CylinderWeight5);

                    }

                }

            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
            }


        }

        private string CalcuRealData(string query, string queryWeight, string ArrInputWeight1, string ArrInputWeight2, string ActCumulative, string ExpStock, string CycleProData, string CylinderWeight4, string CylinderWeight5)
        {
            string result = "0";
            try
            {

                decimal BeforeResult = 0;
                if (queryWeight == "0")
                    queryWeight = "1";

                BeforeResult = (Convert.ToDecimal(CycleProData) - Convert.ToDecimal(queryWeight)) / Convert.ToDecimal(queryWeight) / (Convert.ToDecimal(ArrInputWeight2) - Convert.ToDecimal(CylinderWeight4) - Convert.ToDecimal(CylinderWeight5)) - (Convert.ToDecimal(ExpStock) - Convert.ToDecimal(ActCumulative)) - Convert.ToDecimal(ArrInputWeight1) - Convert.ToDecimal(query);

                result = GetRoundData(BeforeResult.ToString());
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
            }

            return result;


        }
        /// <summary>
        /// 左上角跟右上角思路处理定时器更新时统一去除viewlist控件的数据同时统一add该控件的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BgWaitDrumDry_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                switch (e.Argument.ToString())
                {
                    case "GetInitDrumDryData":

                        using (var Client = new SRQZData.QZDataServiceClient())
                        {


                            QZFunColor = Client.GetQZFunColor(context.SessionID);    //获取勤哲基础颜色设置

                            for (int i = 0; i < QZFunColor.Rows.Count; i++)
                            {
                                imageList1.Images.Add(ImageProcess.GetFillEllipseBitmap(28, 28, System.Drawing.ColorTranslator.FromHtml(QZFunColor.Rows[i]["颜色代码"].ToString()), "", Color.Black));
                                ColorDataArray[i] = QZFunColor.Rows[i]["颜色代码"].ToString();

                            }
                            //转鼓号，转鼓状态，转鼓颜色
                            DrumDryData = Client.GetZGStatus(context.SessionID);  //获取转鼓状态
                            TestZGData = DrumDryData.DefaultView;
                            TestZGDistinct = TestZGData.ToTable(true, "FormulaCode");//获取唯一性配方名称


                            e.Result = "GetInitDrumDryData";
                        }
                        break;


                    case "GetDrumDryData":

                        using (var Client = new SRQZData.QZDataServiceClient())
                        {
                            DrumDryData = Client.GetZGStatus(context.SessionID);
                            e.Result = "GetDrumDryData";
                        }
                        break;
                }
            }
            catch (Exception ex)
            {

                Utils.Logger.Error(ex.ToString());
            }

        }
        private void BgWaitDrumDry_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


            if (e.Result == "GetDrumDryData")
            {

                using (var Client = new SRQZData.QZDataServiceClient())
                {
                    for (int i = 0; i < DrumDryData.Rows.Count; i++)
                    {

                        if (DrumDryData.Rows[i]["FormulaCode"].ToString() == null || DrumDryData.Rows[i]["FormulaCode"].ToString() == "")
                        {
                            DataTable NullZGStatus = Client.GetNullZGColor(context.SessionID);
                            for (int j = 0; j < QZFunColor.Rows.Count; j++)
                            {
                                if (ColorDataArray[j].ToString() == NullZGStatus.Rows[0]["颜色代码"].ToString())
                                {
                                    listView1.Items[i].ImageIndex = j;
                                    //  listView1.Items[i].ImageIndex = 0;
                                    break;
                                }
                            }


                        }
                        else
                        {

                            DrumColor = Client.GetColorData(context.SessionID, DrumDryData.Rows[i]["FormulaCode"].ToString()); //根据转鼓状态中的配方单号获取该转鼓的颜色代码
                            for (int j = 0; j < QZFunColor.Rows.Count; j++)
                            {
                                if (ColorDataArray[j].ToString() == DrumColor.Rows[0]["颜色代码"].ToString())
                                {
                                    listView1.Items[i].ImageIndex = j;
                                    break;
                                }
                                else if (ColorDataArray[j].ToString() != DrumColor.Rows[0]["颜色代码"].ToString() && j == QZFunColor.Rows.Count - 1)
                                {
                                    imageList1.Images.Add(ImageProcess.GetFillEllipseBitmap(28, 28, System.Drawing.ColorTranslator.FromHtml(DrumColor.Rows[0]["颜色代码"].ToString()), "", Color.Black));

                                    ColorDataArray[imageList1.Images.Count] = DrumColor.Rows[0]["颜色代码"].ToString();
                                    //    listView1.Items.Add(string.Format("{0}#", Convert.ToInt32(DrumDryData.Rows[i][0].ToString().Substring(DrumDryData.Rows[i][0].ToString().Length - 2))), 0);
                                }
                            }
                        }
                    }
                }

            }

            else if (e.Result == "GetInitDrumDryData")
            {

                using (var Client = new SRQZData.QZDataServiceClient())
                {

                    DataTable NullZGFunStatus = Client.GetNullZGColor(context.SessionID);
                    for (int j = 0; j < QZFunColor.Rows.Count; j++)
                    {
                        if (ColorDataArray[j].ToString() == NullZGFunStatus.Rows[0]["颜色代码"].ToString())
                        {

                            ZGNullColor.Items.Add(NullZGFunStatus.Rows[0]["品种"].ToString(), j);
                            break;
                        }
                    }


                    for (int i = 0; i < TestZGDistinct.Rows.Count; i++)
                    {
                        if (TestZGDistinct.Rows[i]["FormulaCode"].ToString() == null || TestZGDistinct.Rows[i]["FormulaCode"].ToString() == "")
                        {

                        }
                        else
                        {
                            DataTable DrumFunColor = Client.GetColorData(context.SessionID, TestZGDistinct.Rows[i]["FormulaCode"].ToString());
                            if (DrumFunColor.Rows.Count > 0 && DrumFunColor != null)
                            {
                                for (int j = 0; j < QZFunColor.Rows.Count; j++)
                                {
                                    if (ColorDataArray[j].ToString() == DrumFunColor.Rows[0]["颜色代码"].ToString())
                                    {
                                        ZGFundaVW.Items.Add(DrumFunColor.Rows[0]["配方名称"].ToString(), j);
                                    }
                                    else
                                    {

                                    }
                                }


                            }

                        }
                    }



                    for (int i = 0; i < DrumDryData.Rows.Count; i++)
                    {

                        if (DrumDryData.Rows[i]["FormulaCode"].ToString() == null || DrumDryData.Rows[i]["FormulaCode"].ToString() == "")
                        {
                            DataTable NullZGStatus = Client.GetNullZGColor(context.SessionID);
                            for (int j = 0; j < QZFunColor.Rows.Count; j++)
                            {
                                if (ColorDataArray[j].ToString() == NullZGStatus.Rows[0]["颜色代码"].ToString())
                                {
                                    //    listView1.Items[i].ImageIndex = j;
                                    //  listView1.Items[i].ImageIndex = 0;

                                    listView1.Items.Add(string.Format("{0}#", Convert.ToInt32(DrumDryData.Rows[i]["DevCode"].ToString().Substring(DrumDryData.Rows[i]["DevCode"].ToString().Length - 2))), j);
                                    break;
                                }
                            }



                        }
                        else
                        {

                            DrumColor = Client.GetColorData(context.SessionID, DrumDryData.Rows[i]["FormulaCode"].ToString()); //根据转鼓状态中的配方单号获取该转鼓的颜色代码

                            if (DrumColor.Rows.Count > 0 && DrumColor != null)
                            {
                                for (int j = 0; j < QZFunColor.Rows.Count; j++)
                                {
                                    if (ColorDataArray[j].ToString() == DrumColor.Rows[0]["颜色代码"].ToString())
                                    {
                                        listView1.Items.Add(string.Format("{0}#", Convert.ToInt32(DrumDryData.Rows[i]["DevCode"].ToString().Substring(DrumDryData.Rows[i]["DevCode"].ToString().Length - 2))), j);
                                    }
                                    else
                                    {


                                        //    listView1.Items.Add(string.Format("{0}#", Convert.ToInt32(DrumDryData.Rows[i][0].ToString().Substring(DrumDryData.Rows[i][0].ToString().Length - 2))), 0);
                                    }
                                }

                            }
                        }
                    }
                }

            }


        }
        private void BgWaitStockArea_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                switch (e.Argument.ToString())
                {
                    case "GetInitRFIDData":

                        using (var Client = new SRQZData.QZDataServiceClient())
                        {
                            DataTable MYFunColor = Client.GetQZFunColor(context.SessionID);    //获取勤哲基础颜色设置
                            RFIDData = Client.GetRFIDData(context.SessionID);
                            TestRfidData = RFIDData.DefaultView;
                            TestRfidDistinct = TestRfidData.ToTable(true, "颜色代码", "配方名称");

                            for (int i = 0; i < MYFunColor.Rows.Count; i++)
                            {
                                imageList2.Images.Add(ImageProcess.GetFillrectangleBitmap(28, 28, System.Drawing.ColorTranslator.FromHtml(MYFunColor.Rows[i]["颜色代码"].ToString()), "", Color.Black));

                            }


                        }

                        e.Result = "GetInitRFIDData";

                        break;

                }
            }
            catch (Exception ex)
            {

                Utils.Logger.Error(ex.ToString());
            }
        }

        private void BgWaitStockArea_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


            if (e.Result == "GetInitRFIDData")
            {
                //根据转鼓状态中的配方单号获取该转鼓的颜色代码

                for (int i = 0; i < RFIDData.Rows.Count; i++)
                {
                    for (int j = 0; j < QZFunColor.Rows.Count; j++)
                    {
                        if (ColorDataArray[j].ToString() == RFIDData.Rows[i]["颜色代码"].ToString())
                        {
                            listView2.Items.Add("", j);
                            break;
                        }
                        else if (ColorDataArray[j].ToString() != RFIDData.Rows[i]["颜色代码"].ToString() && j == QZFunColor.Rows.Count - 1)
                        {
                            imageList2.Images.Add(ImageProcess.GetFillEllipseBitmap(28, 28, System.Drawing.ColorTranslator.FromHtml(RFIDData.Rows[i]["颜色代码"].ToString()), "", Color.Black));

                        }
                    }
                }

                //==================================================================================================================//

                for (int i = 0; i < TestRfidDistinct.Rows.Count; i++)
                {
                    for (int j = 0; j < QZFunColor.Rows.Count; j++)
                    {
                        if (ColorDataArray[j].ToString() == TestRfidDistinct.Rows[i]["颜色代码"].ToString())
                        {
                            StockFundaVW.Items.Add(TestRfidDistinct.Rows[i]["配方名称"].ToString(), j);
                            break;
                        }
                        else if (ColorDataArray[j].ToString() != TestRfidDistinct.Rows[i]["颜色代码"].ToString() && j == QZFunColor.Rows.Count - 1)
                        {
                            imageList2.Images.Add(ImageProcess.GetFillEllipseBitmap(28, 28, System.Drawing.ColorTranslator.FromHtml(TestRfidDistinct.Rows[i]["颜色代码"].ToString()), "", Color.Black));

                        }
                    }
                }


            }
        }

        #endregion

        #region Method
        private object TestQueryWeight(SRQZData.QZDataServiceClient QZclient, DataTable Newret, int StartLocation)
        {
            decimal queryWeight;
            var retWeight = QZclient.GetQZWeight(context.SessionID, Convert.ToDateTime(Newret.Rows[StartLocation]["生产周期开始"].ToString()), Convert.ToDateTime(Newret.Rows[StartLocation]["生产周期结束"].ToString()), Newret.Rows[StartLocation]["品种"].ToString(), Newret.Rows[StartLocation]["品种类型"].ToString());
            // var queryWeight = retWeight.Compute("sum(weightA)", "");
            if (retWeight.Rows.Count > 0 && retWeight != null)
            {
                queryWeight = Math.Round(Convert.ToDecimal(retWeight.Compute("sum(weightA)", "")), MidpointRounding.AwayFromZero) / 1000;

            }
            else
            {
                queryWeight = 0;
            }

            return queryWeight;
        }
        /// <summary>
        /// 给开始背景以及结束背景单行进行上色，
        /// </summary>
        /// <param name="e"></param>
        private void DrawProgressBar(DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            decimal percent = Convert.ToDecimal(e.CellValue);
            var Test = e.RowHandle;
            int width = (int)(Math.Abs(percent) * e.Bounds.Width / 100);//涨跌幅最大为10%，所以要乘以10来计算比例，沾满一个单元格为10%  100*
            Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y, width, e.Bounds.Height);
            Rectangle rect1 = new Rectangle(e.Bounds.X + width, e.Bounds.Y, e.Bounds.Width - width, e.Bounds.Height); //处理未完成颜色
            Brush StartColor = Brushes.Green;
            Brush EndColor = Brushes.Green;

            switch (Test)
            {
                case 0:
                    StartColor = Brushes.Blue;
                    EndColor = Brushes.AliceBlue;

                    break;

                case 1:
                    StartColor = Brushes.Orange;
                    EndColor = Brushes.LightYellow;
                    break;

                case 2:
                    StartColor = Brushes.Green;
                    EndColor = Brushes.LightGreen;
                    break;

                case 3:
                    StartColor = Brushes.Red;
                    EndColor = Brushes.PaleVioletRed;
                    break;

                case 4:
                    StartColor = Brushes.Purple;
                    EndColor = Brushes.MediumPurple;
                    break;

                case 5:
                    StartColor = Brushes.Blue;
                    EndColor = Brushes.AliceBlue;
                    break;

                case 6:
                    StartColor = Brushes.Orange;
                    EndColor = Brushes.LightYellow;
                    break;

                case 7:
                    StartColor = Brushes.Green;
                    EndColor = Brushes.LightGreen;
                    break;

                case 8:
                    StartColor = Brushes.Red;
                    EndColor = Brushes.PaleVioletRed;
                    break;

                case 9:
                    StartColor = Brushes.Purple;
                    EndColor = Brushes.MediumPurple;
                    break;
                default:
                    StartColor = Brushes.Black;
                    EndColor = Brushes.Black;
                    break;

            }
            e.Graphics.FillRectangle(StartColor, rect);
            e.Graphics.FillRectangle(EndColor, rect1);


        }

        /// <summary>
        /// 优先完成一部分数据的初始化
        /// </summary>
        private void ProgramDataInit()
        {
            //    DataTable dt = new DataTable();
            dt.Columns.Add("配方名称");
            dt.Columns.Add("结束日期");
            dt.Columns.Add("成品产量/T");
            dt.Columns.Add("备料量/T");
            dt.Columns.Add("未备余量/T");
            dt.Columns.Add("备料进度");
            dt.Columns.Add("数据");
            dt.Columns.Add("百分比");
            dt.Columns.Add("进度");
            for (int i = 0; i <= 1; i++)
            {
                dt.Rows.Add(" ", " ", " ", " ", " ", "成品产量 ", "0", " ", " ");
                dt.Rows.Add(" ", " ", " ", " ", " ", "备料量 ", "0", " ", " ");
                dt.Rows.Add(" ", " ", " ", " ", " ", "已完成烘料 ", "0", " ", " ");
                dt.Rows.Add(" ", " ", " ", " ", " ", "烘料中 ", "0", " ", " ");
                dt.Rows.Add(" ", " ", " ", " ", " ", "备料区 ", "0", " ", " ");
            }

            this.gridControl1.DataSource = dt;

            bandedGridView1.OptionsView.AllowCellMerge = true;
        }

        private void GridInit()
        {
            try
            {
                if (!BgWait.IsBusy)
                    BgWait.RunWorkerAsync("GetCrafData");
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
            }

        }

        private void ListViewInit()
        {

            try
            {
                if (!BgWaitDrumDry.IsBusy)
                    BgWaitDrumDry.RunWorkerAsync("GetInitDrumDryData");

            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
            }

        }


        private void StockInit()
        {
            try
            {
                if (!BgWaitStockArea.IsBusy)
                    BgWaitStockArea.RunWorkerAsync("GetInitRFIDData");
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
            }

        }


        private void ZKDataInit()
        {
            try
            {
                if (!CylinderBgWait.IsBusy)
                    CylinderBgWait.RunWorkerAsync("GetZKLData");
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
            }

        }

        public static string GetPerData(string Molecule, string Denominator)
        {
            string result;

            if (Denominator == null || Convert.ToDecimal(Denominator) == 0 || Convert.ToDouble(Denominator) < 0.5)
            {
                result = "0";
            }
            else
            {
                // result = string.Format("{0}%", Math.Round(Convert.ToDecimal(((100 * Math.Round(Convert.ToDecimal(Molecule), MidpointRounding.AwayFromZero)) / (Math.Round(Convert.ToDecimal(Denominator), MidpointRounding.AwayFromZero)))), MidpointRounding.AwayFromZero));
                result = string.Format("{0}", Math.Round(Convert.ToDecimal(((100 * Math.Round(Convert.ToDecimal(Molecule), MidpointRounding.AwayFromZero)) / (Math.Round(Convert.ToDecimal(Denominator), MidpointRounding.AwayFromZero)))), MidpointRounding.AwayFromZero));
            }
            return result;
        }

        public static string GetRoundData(string NValue)
        {
            string result;

            if (NValue == null || Convert.ToDecimal(NValue) == 0)
            {
                result = "0";
            }
            else
            {
                // result = string.Format("{0}%", Math.Round(Convert.ToDecimal(((100 * Math.Round(Convert.ToDecimal(Molecule), MidpointRounding.AwayFromZero)) / (Math.Round(Convert.ToDecimal(Denominator), MidpointRounding.AwayFromZero)))), MidpointRounding.AwayFromZero));
                result = string.Format("{0}", Math.Round(Convert.ToDecimal(NValue), MidpointRounding.AwayFromZero));
            }
            return result;
        }


        /// <summary>
        /// 将通过wcf获取到的数据赋值到datatable表中
        /// </summary>
        /// <param name="Newret"></param>转鼓配方单数据
        /// <param name="queryWeight"></param>收卷称重数据
        /// <param name="ArrInputWeight1"></param>备料累计
        /// <param name="ArrInputWeight2"></param>备料累计
        /// <param name="query"></param>收卷称重数据合计
        /// <param name="StartLocation"></param>开始地址，默认间隔为先要显示行数间隔，第一行为0，第二行为5，第三行为10
        /// <param name="StartCount"></param>需要显示的配方数量第一行0，第二行2
        private void DataTableAssign(object queryWeight, decimal? ArrInputWeight1, decimal? ArrInputWeight2, object query, int StartLocation, int StartCount)
        {



            try
            {
                DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;

                if (this.gridControl1.InvokeRequired)
                {


                    //------------------------------------------前四列赋值------------------------------------//
                    dt.Rows[StartLocation][0] = Newret.Rows[StartCount]["配方名称"].ToString();
                    dt.Rows[StartLocation][1] = Newret.Rows[StartCount]["生产周期结束"].ToString();
                    dt.Rows[StartLocation][2] = Newret.Rows[StartCount]["周期产量T"].ToString();
                    dt.Rows[StartLocation][3] = Newret.Rows[StartCount]["预计备料量T"].ToString();
                    //------------------------------------------前四列赋值------------------------------------//



                    //------------------------------------------进度条赋值------------------------------------//
                    dt.Rows[StartLocation][6] = GetPerData(queryWeight.ToString(), Newret.Rows[StartCount]["周期产量T"].ToString());
                    dt.Rows[StartLocation + 1][6] = GetPerData(Newret.Rows[StartCount]["实际备料累计T"].ToString(), Newret.Rows[StartCount]["预计备料量T"].ToString());
                    dt.Rows[StartLocation + 2][6] = GetPerData(ArrInputWeight2.ToString(), Newret.Rows[StartCount]["实际备料累计T"].ToString());
                    dt.Rows[StartLocation + 3][6] = GetPerData(ArrInputWeight1.ToString(), Newret.Rows[StartCount]["实际备料累计T"].ToString());
                    dt.Rows[StartLocation + 4][6] = GetPerData(query.ToString(), Newret.Rows[StartCount]["实际备料累计T"].ToString());

                    //------------------------------------------进度条赋值------------------------------------//

                    //------------------------------------------百分比赋值------------------------------------//
                    dt.Rows[StartLocation][7] = string.Format("{0}%", GetPerData(queryWeight.ToString(), Newret.Rows[StartCount]["周期产量T"].ToString()));
                    dt.Rows[StartLocation + 1][7] = string.Format("{0}%", GetPerData(Newret.Rows[StartCount]["实际备料累计T"].ToString(), Newret.Rows[StartCount]["预计备料量T"].ToString()));
                    dt.Rows[StartLocation + 2][7] = string.Format("{0}%", GetPerData(ArrInputWeight2.ToString(), Newret.Rows[StartCount]["实际备料累计T"].ToString()));
                    dt.Rows[StartLocation + 3][7] = string.Format("{0}%", GetPerData(ArrInputWeight1.ToString(), Newret.Rows[StartCount]["实际备料累计T"].ToString()));
                    dt.Rows[StartLocation + 4][7] = string.Format("{0}%", GetPerData(query.ToString(), Newret.Rows[StartCount]["实际备料累计T"].ToString()));
                    //------------------------------------------百分比赋值------------------------------------//

                    //------------------------------------------汇总赋值------------------------------------//
                    dt.Rows[StartLocation + 0][8] = string.Format("{0}t/{1}", Math.Round(Convert.ToDecimal(queryWeight.ToString()), MidpointRounding.AwayFromZero), Math.Round(Convert.ToDecimal(Newret.Rows[StartCount]["周期产量T"].ToString()), MidpointRounding.AwayFromZero));
                    dt.Rows[StartLocation + 1][8] = string.Format("{0}t/{1}", Math.Round(Convert.ToDecimal(Newret.Rows[StartCount]["实际备料累计T"].ToString()), MidpointRounding.AwayFromZero), Math.Round(Convert.ToDecimal(Newret.Rows[StartCount]["预计备料量T"].ToString()), MidpointRounding.AwayFromZero));
                    dt.Rows[StartLocation + 2][8] = string.Format("{0}t/{1}", Math.Round(Convert.ToDecimal(ArrInputWeight2), MidpointRounding.AwayFromZero), Math.Round(Convert.ToDecimal(Newret.Rows[StartCount]["实际备料累计T"].ToString()), MidpointRounding.AwayFromZero));
                    dt.Rows[StartLocation + 3][8] = string.Format("{0}t/{1}", Math.Round(Convert.ToDecimal(ArrInputWeight1), MidpointRounding.AwayFromZero), Math.Round(Convert.ToDecimal(Newret.Rows[StartCount]["实际备料累计T"].ToString()), MidpointRounding.AwayFromZero));
                    dt.Rows[StartLocation + 4][8] = string.Format("{0}t/{1}", Math.Round(Convert.ToDecimal(query.ToString()), MidpointRounding.AwayFromZero), Math.Round(Convert.ToDecimal(Newret.Rows[StartCount]["实际备料累计T"].ToString()), MidpointRounding.AwayFromZero));
                    //------------------------------------------汇总赋值------------------------------------//
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
            }
        }

        #endregion


        private void CylinderBgWait_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                switch (e.Argument.ToString())
                {
                    case "GetZKLData":

                        using (var Client = new SRQZData.QZDataServiceClient())
                        {
                            TestData4 = Client.GetL4Data1(context.SessionID);
                            TestData5 = Client.GetL5Data1(context.SessionID);
                        }
                        e.Result = "GetZKLData";

                        break;

                }
            }
            catch (Exception ex)
            {

                Utils.Logger.Error(ex.ToString());
            }
        }

        private void CylinderBgWait_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Result == "GetZKLData")
            {
                if (TestData4.Rows.Count > 0 && TestData4 != null)
                {

                    Line4CyPic.Image = ImageProcess.GetCylinderBitmap(100, 150, Color.PapayaWhip, Color.Pink, Convert.ToDouble(TestData4.Rows[0]["料缸重量"].ToString()) / 5000, Color.White, "");
                    FourLWeight.Text = string.Format("余量:" + "{0}" + "kg", Math.Round(Convert.ToDecimal(TestData4.Rows[0]["料缸重量"].ToString()), MidpointRounding.AwayFromZero));
                    FourLMTime.Text = string.Format("{0}" + "min", Math.Round(Convert.ToDecimal(TestData4.Rows[0]["料斗剩余时间"].ToString()), MidpointRounding.AwayFromZero));
                    FourLRate.Text = string.Format("{0}" + "kg/min", Convert.ToDouble(GetPerData(TestData4.Rows[0]["料缸重量"].ToString(), TestData4.Rows[0]["料斗剩余时间"].ToString())) / 100);

                }

                if (TestData5.Rows.Count > 0 && TestData5 != null)
                {
                    Line5CyPic.Image = ImageProcess.GetCylinderBitmap(100, 150, Color.PapayaWhip, Color.Pink, Convert.ToDouble(TestData5.Rows[0]["料缸重量"].ToString()) / 5000, Color.White, "");
                    FiveLWeight.Text = string.Format("余量:" + "{0}" + "kg", Math.Round(Convert.ToDecimal(TestData5.Rows[0]["料缸重量"].ToString()), MidpointRounding.AwayFromZero));
                    FiveLMTime.Text = string.Format("{0}" + "min", Math.Round(Convert.ToDecimal(TestData5.Rows[0]["料斗剩余时间"].ToString()), MidpointRounding.AwayFromZero));
                    FiveLRate.Text = string.Format("{0}" + "kg/min", Convert.ToDouble(GetPerData(TestData5.Rows[0]["料缸重量"].ToString(), TestData5.Rows[0]["料斗剩余时间"].ToString())) / 100);
                }


            }
        }


    }
}
