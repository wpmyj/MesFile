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
using Client.Utility.Protocol;
using System.IO.Ports;
using Client.Utility.Caching;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace LY.MES.WFCL.Winder.Frm
{
    public partial class frmSJAutoWind : BaseForm
    {

        DataTable SJData = null;
        DataTable OrderData = null;
        DataTable SaveData = null;
        private MasterPort mp = new MasterPort();
        private MasterPort mp2 = new MasterPort();
        private MasterPort mp3 = new MasterPort();
        private MasterPort mp4 = new MasterPort();
        int TieCaoCount;
        IronTrough IronTrough1;
        IronTrough IronTrough2;
        IronTrough IronTrough3;
        IronTrough IronTrough4;
        private IPAddress IP;
        private EndPoint endpoint;
        private Socket socket;
        Thread TieCao1;
        Thread TieCao2;
        Thread TieCao3;
        Thread TieCao4;
        string SJ_lineName;
        public frmSJAutoWind(UserContext context)
            : base(context)
        {
            InitializeComponent();
            BgWait1.ProgressChanged += this.backgroundWorker_ProgressChanged;
            BgWait2.ProgressChanged += this.backgroundWorker_ProgressChanged;
            InitGridControl();
            GetMySerialPort();
            mp.sp.DataReceived += new SerialDataReceivedEventHandler(SJWeight_DataReceived);
            mp2.sp.DataReceived += new SerialDataReceivedEventHandler(SJWeight2_DataReceived);
            mp3.sp.DataReceived += new SerialDataReceivedEventHandler(SJWeight3_DataReceived);
            mp4.sp.DataReceived += new SerialDataReceivedEventHandler(SJWeight4_DataReceived);
        }

        #region Init
        /// <summary>
        /// 初始化gridControl1控件
        /// </summary>
        private void InitGridControl()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("铁槽");
            dt.Columns.Add("生产单号");
            dt.Columns.Add("规格");
            dt.Columns.Add("纸芯");
            dt.Columns.Add("重量（KG）");
            dt.Columns.Add("排产件数");
            dt.Columns.Add("班次");
            dt.Columns.Add("包装");
            dt.Columns.Add("印字内容");
            dt.Columns.Add("特殊要求");
            dt.Columns.Add("入库状态");
            dt.Columns.Add("状态");
            dt.Rows.Add("1号铁槽");
            dt.Rows.Add("2号铁槽");
            dt.Rows.Add("3号铁槽");
            dt.Rows.Add("4号铁槽");
            gridControl1.DataSource = dt;
        }
        /// <summary>
        /// 获取当前电脑的串口名称,并传值到SJWSerial中用于选择,并默认机号，设定铁槽四个
        /// </summary>
        private void GetMySerialPort()
        {

            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            SJWSerial.Items.AddRange(ports);
            TieCaoCount = 4;//获取订单数量以及校验数量     
            JiHaoComboBox.SelectedIndex = 2; //默认机号六号机
            SJWSerial.SelectedIndex = 0; //默认串口号COM1

        }

        #endregion

        #region MeThod



        private void TieCao1Run()
        {
            while (true)
            {
                try
                {
                    string TieCaoControlStatus = IronTrough1.GetDevIStatusOrIDBySerial("Status", "端口4");
                    string TieCaoStatus1 = IronTrough1.GetDevIStatusOrIDBySerial("Status", "端口1");
                    Thread.Sleep(1000);
                    string TieCaoStatus2 = IronTrough1.GetDevIStatusOrIDBySerial("Status", "端口1");

                    if (TieCaoControlStatus != null && TieCaoControlStatus == "0" && TieCaoStatus1 == "1" && TieCaoStatus1 != null && TieCaoStatus1 == TieCaoStatus2 && gridView1.GetRowCellValue(0, "生产单号").ToString() != "" && gridView1.GetRowCellValue(0, "生产单号").ToString() != null)
                    {
                        string DataStab1, DataStab2, DataStab3;
                        SRQZData.sj_line model = new SRQZData.sj_line();
                        if (this.NewSJweight.Text != "0" && this.NewSJweight.Text != "" && Convert.ToDouble(NewSJweight.Text) > 8)
                        {
                            do
                            {
                                DataStab1 = this.NewSJweight.Text;
                                Thread.Sleep(1000);
                                DataStab2 = this.NewSJweight.Text;
                                Thread.Sleep(1000);
                                DataStab3 = this.NewSJweight.Text;
                                Thread.Sleep(1000);
                                if (DataStab1 == DataStab2 && DataStab1 == DataStab3)
                                {
                                    try
                                    {
                                        if (Convert.ToDouble(NewSJweight.Text.ToString()) < (Convert.ToDouble(gridView1.GetRowCellValue(0, "重量（KG）").ToString()) + 0.3) && Convert.ToDouble(NewSJweight.Text.ToString()) > (Convert.ToDouble(gridView1.GetRowCellValue(0, "重量（KG）").ToString()) - 0.3))
                                        {

                                        }
                                        else
                                        {
                                            //不合格报警
                                            Utils.Logger.Error("不合格铁槽一记录实际：{0}  订单：{1}", DataStab3, gridView1.GetRowCellValue(0, "重量（KG）").ToString());

                                            //ControlDeviStatus(IronTrough1.GetDevIStatusOrIDBySerial("ExecID", "端口4"), "1");

                                            //Thread.Sleep(3000);

                                            //ControlDeviStatus(IronTrough1.GetDevIStatusOrIDBySerial("ExecID", "端口4"), "0");

                                            break;
                                        }

                                        this.BeginInvoke((MethodInvoker)delegate()
                                        {

                                            model.line = Convert.ToInt16(JiHaoComboBox.Text.ToString().Substring(0, 1));
                                            model.type = ClassComboBox.Text;
                                            model.paichan = gridView1.GetRowCellValue(0, "生产单号").ToString();
                                            model.timeA = DateTime.Now;
                                            model.weightA = Convert.ToDecimal(NewSJweight.Text);
                                            model.qk = gridView1.GetRowCellValue(0, "入库状态").ToString() == "正品" ? "1" : "2";

                                            using (SRQZData.QZDataServiceClient client = new SRQZData.QZDataServiceClient())
                                            {
                                                client.InsertSJData(context.SessionID, model);

                                            }
                                        });

                                        ControlDeviStatus(IronTrough1.GetDevIStatusOrIDBySerial("ExecID", "端口4"), "1");

                                        Thread.Sleep(3000);

                                        ControlDeviStatus(IronTrough1.GetDevIStatusOrIDBySerial("ExecID", "端口4"), "0");
                                        break;
                                    }
                                    catch (Exception ex)
                                    {

                                        Utils.Logger.Error(ex.ToString());
                                    }

                                }

                                else
                                {
                                    break;
                                }
                            }
                            while (DataStab1 != DataStab2 || DataStab1 != DataStab3 || DataStab2 != DataStab3);

                        }

                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    Utils.Logger.Error(ex.ToString());
                }
            }

        }


        private void TieCao2Run()
        {
            while (true)
            {
                try
                {
                    string TieCaoControlStatus = IronTrough2.GetDevIStatusOrIDBySerial("Status", "端口8");
                    string TieCaoStatus1 = IronTrough1.GetDevIStatusOrIDBySerial("Status", "端口2");
                    Thread.Sleep(1000);
                    string TieCaoStatus2 = IronTrough1.GetDevIStatusOrIDBySerial("Status", "端口2");

                    if (TieCaoControlStatus != null && TieCaoControlStatus == "0" && TieCaoStatus1 == "1" && TieCaoStatus1 != null && TieCaoStatus1 == TieCaoStatus2 && gridView1.GetRowCellValue(1, "生产单号").ToString() != "" && gridView1.GetRowCellValue(1, "生产单号").ToString() != null)
                    {
                        string DataStab1, DataStab2, DataStab3;
                        SRQZData.sj_line model = new SRQZData.sj_line();
                        if (this.NewSJweight.Text != "0" && this.NewSJweight.Text != "" && Convert.ToDouble(NewSJweight.Text) > 8)
                        {
                            do
                            {
                                DataStab1 = this.NewSJweight2.Text;
                                Thread.Sleep(1000);
                                DataStab2 = this.NewSJweight2.Text;
                                Thread.Sleep(1000);
                                DataStab3 = this.NewSJweight2.Text;
                                Thread.Sleep(1000);
                                if (DataStab1 == DataStab2 && DataStab1 == DataStab3)
                                {
                                    try
                                    {
                                        if (Convert.ToDouble(NewSJweight2.Text.ToString()) < (Convert.ToDouble(gridView1.GetRowCellValue(1, "重量（KG）").ToString()) + 0.3) && Convert.ToDouble(NewSJweight2.Text.ToString()) > (Convert.ToDouble(gridView1.GetRowCellValue(1, "重量（KG）").ToString()) - 0.3))
                                        {
                                            //不合格报警
                                        }
                                        else
                                        {
                                            Utils.Logger.Error("不合格铁槽二记录实际：{0}  订单：{1}", DataStab3, gridView1.GetRowCellValue(1, "重量（KG）").ToString());

                                            break;

                                        }

                                        this.BeginInvoke((MethodInvoker)delegate()
                                        {
                                            model.line = Convert.ToInt16(JiHaoComboBox.Text.ToString().Substring(0, 1));
                                            model.type = ClassComboBox.Text;
                                            model.paichan = gridView1.GetRowCellValue(1, "生产单号").ToString();
                                            model.timeA = DateTime.Now;
                                            model.weightA = Convert.ToDecimal(NewSJweight.Text);
                                            model.qk = gridView1.GetRowCellValue(1, "入库状态").ToString() == "正品" ? "1" : "2";

                                            using (SRQZData.QZDataServiceClient client = new SRQZData.QZDataServiceClient())
                                            {
                                                client.InsertSJData(context.SessionID, model);

                                            }
                                        });

                                        ControlDeviStatus(IronTrough2.GetDevIStatusOrIDBySerial("ExecID", "端口8"), "1");

                                        Thread.Sleep(3000);

                                        ControlDeviStatus(IronTrough2.GetDevIStatusOrIDBySerial("ExecID", "端口8"), "0");
                                        break;
                                    }
                                    catch (Exception ex)
                                    {

                                        Utils.Logger.Error(ex.ToString());
                                    }

                                }
                                else
                                {
                                    break;
                                }
                            }
                            while (DataStab1 != DataStab2 || DataStab1 != DataStab3 || DataStab2 != DataStab3);

                        }
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    Utils.Logger.Error(ex.ToString());
                }
            }
        }


        private void TieCao3Run()
        {
            while (true)
            {
                try
                {
                    string TieCaoControlStatus = IronTrough3.GetDevIStatusOrIDBySerial("Status", "端口12");
                    string TieCaoStatus1 = IronTrough1.GetDevIStatusOrIDBySerial("Status", "端口3");
                    Thread.Sleep(1000);
                    string TieCaoStatus2 = IronTrough1.GetDevIStatusOrIDBySerial("Status", "端口3");
                    if (TieCaoControlStatus != null && TieCaoControlStatus == "0" && TieCaoStatus1 == "1" && TieCaoStatus1 != null && TieCaoStatus1 == TieCaoStatus2 && gridView1.GetRowCellValue(2, "生产单号").ToString() != "" && gridView1.GetRowCellValue(2, "生产单号").ToString() != null)
                    {
                        string DataStab1, DataStab2, DataStab3;
                        SRQZData.sj_line model = new SRQZData.sj_line();
                        if (this.NewSJweight3.Text != "0" && this.NewSJweight3.Text != "" && Convert.ToDouble(NewSJweight3.Text) > 8)
                        {
                            do
                            {
                                DataStab1 = this.NewSJweight3.Text;
                                Thread.Sleep(1000);
                                DataStab2 = this.NewSJweight3.Text;
                                Thread.Sleep(1000);
                                DataStab3 = this.NewSJweight3.Text;
                                Thread.Sleep(1000);
                                if (DataStab1 == DataStab2 && DataStab1 == DataStab3)
                                {
                                    try
                                    {
                                        if (Convert.ToDouble(NewSJweight3.Text.ToString()) < (Convert.ToDouble(gridView1.GetRowCellValue(2, "重量（KG）").ToString()) + 0.3) && Convert.ToDouble(NewSJweight3.Text.ToString()) > (Convert.ToDouble(gridView1.GetRowCellValue(2, "重量（KG）").ToString()) - 0.3))
                                        {
                                            //不合格报警
                                        }
                                        else
                                        {
                                            Utils.Logger.Error("不合格铁槽三记录实际：{0}  订单：{1}", DataStab3, gridView1.GetRowCellValue(2, "重量（KG）").ToString());

                                            break;
                                        }

                                        this.BeginInvoke((MethodInvoker)delegate()
                                        {
                                            model.line = Convert.ToInt16(JiHaoComboBox.Text.ToString().Substring(0, 1));
                                            model.type = ClassComboBox.Text;
                                            model.paichan = gridView1.GetRowCellValue(2, "生产单号").ToString();
                                            model.timeA = DateTime.Now;
                                            model.weightA = Convert.ToDecimal(NewSJweight.Text);
                                            model.qk = gridView1.GetRowCellValue(2, "入库状态").ToString() == "正品" ? "1" : "2";
                                            using (SRQZData.QZDataServiceClient client = new SRQZData.QZDataServiceClient())
                                            {
                                                client.InsertSJData(context.SessionID, model);

                                            }
                                        });

                                        ControlDeviStatus(IronTrough3.GetDevIStatusOrIDBySerial("ExecID", "端口12"), "1");
                                        Thread.Sleep(3000);
                                        ControlDeviStatus(IronTrough3.GetDevIStatusOrIDBySerial("ExecID", "端口12"), "0");
                                        break;
                                    }
                                    catch (Exception ex)
                                    {
                                        Utils.Logger.Error(ex.ToString());
                                    }

                                }
                                else
                                {
                                    break;
                                }
                            }
                            while (DataStab1 != DataStab2 || DataStab1 != DataStab3 || DataStab2 != DataStab3);
                        }
                    }
                    else
                    {
                    }
                }
                catch (Exception ex)
                {
                    Utils.Logger.Error(ex.ToString());
                }
            }
        }


        private void TieCao4Run()
        {
            while (true)
            {
                try
                {
                    string TieCaoControlStatus = IronTrough4.GetDevIStatusOrIDBySerial("Status", "端口15");
                    string TieCaoStatus1 = IronTrough1.GetDevIStatusOrIDBySerial("Status", "端口4");
                    Thread.Sleep(1000);
                    string TieCaoStatus2 = IronTrough1.GetDevIStatusOrIDBySerial("Status", "端口4");

                    if (TieCaoControlStatus != null && TieCaoControlStatus == "0" && TieCaoStatus1 == "1" && TieCaoStatus1 != null && TieCaoStatus1 == TieCaoStatus2 && gridView1.GetRowCellValue(3, "生产单号").ToString() != "" && gridView1.GetRowCellValue(3, "生产单号").ToString() != null)
                    {
                        string DataStab1, DataStab2, DataStab3;
                        SRQZData.sj_line model = new SRQZData.sj_line();
                        if (this.NewSJweight3.Text != "0" && this.NewSJweight3.Text != "" && Convert.ToDouble(NewSJweight3.Text) > 8)
                        {
                            do
                            {
                                DataStab1 = this.NewSJweight3.Text;
                                Thread.Sleep(1000);
                                DataStab2 = this.NewSJweight3.Text;
                                Thread.Sleep(1000);
                                DataStab3 = this.NewSJweight3.Text;
                                Thread.Sleep(1000);
                                if (DataStab1 == DataStab2 && DataStab1 == DataStab3)
                                {
                                    try
                                    {
                                        if (Convert.ToDouble(NewSJweight3.Text.ToString()) < (Convert.ToDouble(gridView1.GetRowCellValue(3, "重量（KG）").ToString()) + 0.3) && Convert.ToDouble(NewSJweight3.Text.ToString()) > (Convert.ToDouble(gridView1.GetRowCellValue(3, "重量（KG）").ToString()) - 0.3))
                                        {
                                            //不合格报警
                                        }
                                        else
                                        {
                                            Utils.Logger.Error("不合格铁槽四记录实际：{0}  订单：{1}", DataStab3, gridView1.GetRowCellValue(3, "重量（KG）").ToString());

                                            break;
                                        }

                                        this.BeginInvoke((MethodInvoker)delegate()
                                        {
                                            model.line = Convert.ToInt16(JiHaoComboBox.Text.ToString().Substring(0, 1));
                                            model.type = ClassComboBox.Text;
                                            model.paichan = gridView1.GetRowCellValue(3, "生产单号").ToString();
                                            model.timeA = DateTime.Now;
                                            model.weightA = Convert.ToDecimal(NewSJweight.Text);
                                            model.qk = gridView1.GetRowCellValue(3, "入库状态").ToString() == "正品" ? "1" : "2";
                                            using (SRQZData.QZDataServiceClient client = new SRQZData.QZDataServiceClient())
                                            {
                                                client.InsertSJData(context.SessionID, model);

                                            }
                                        });

                                        ControlDeviStatus(IronTrough4.GetDevIStatusOrIDBySerial("ExecID", "端口15"), "1");

                                        Thread.Sleep(3000);

                                        ControlDeviStatus(IronTrough4.GetDevIStatusOrIDBySerial("ExecID", "端口15"), "0");
                                        break;
                                    }
                                    catch (Exception ex)
                                    {

                                        Utils.Logger.Error(ex.ToString());
                                    }

                                }

                                else
                                {
                                    break;
                                }
                            }
                            while (DataStab1 != DataStab2 || DataStab1 != DataStab3 || DataStab2 != DataStab3);
                        }
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    Utils.Logger.Error(ex.ToString());
                }
            }
        }

        /// <summary>
        /// 启动前校验检测，需要对应选择了生产单号的行选择入库状态，并且班次以及串口号和机号不能为空
        /// </summary>
        /// <returns></returns>
        private bool GetGVStatus()
        {
            gridView1.CloseEditor();
            for (int i = 0; i < TieCaoCount; i++)
            {
                if (gridView1.GetRowCellValue(i, "生产单号").ToString() != "")
                {
                    if (gridView1.GetRowCellValue(i, "入库状态").ToString() == "")
                    {
                        ClsMsg.ShowErrMsg("该订单入库状态为空,请选择对应的入库状态！");
                        return false;
                    }
                }
                else if (gridView1.GetRowCellValue(i, "生产单号").ToString() == "" && i == 3)
                {
                    if (gridView1.GetRowCellValue(0, "生产单号").ToString() == "" && gridView1.GetRowCellValue(1, "生产单号").ToString() == "" && gridView1.GetRowCellValue(2, "生产单号").ToString() == "" && gridView1.GetRowCellValue(3, "生产单号").ToString() == "")
                    {
                        ClsMsg.ShowErrMsg("请至少选择一张订单在启动自动化收卷！");
                        return false;
                    }
                }
            }

            if (JiHaoComboBox.Text == "" || JiHaoComboBox.Text == null)
            {
                ClsMsg.ShowErrMsg("未选择机号,请选择对应的机号！");
                return false;
            }
            if (ClassComboBox.Text == "" || ClassComboBox.Text == null)
            {
                ClsMsg.ShowErrMsg("未选择班次,请选择对应的班次！");
                return false;
            }
            if (SJWSerial.Text == "" || SJWSerial.Text == null)
            {
                ClsMsg.ShowErrMsg("未选择串口号,请选择对应的串口号！");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获取相对应行的订单的明细信息
        /// </summary>
        private void GetOrderDataByGV()
        {
            gridView1.CloseEditor();
            using (var Client = new SRQZData.QZDataServiceClient())
            {
                try
                {
                    for (int i = 0; i < TieCaoCount; i++)
                    {
                        if (gridView1.GetRowCellValue(i, "生产单号").ToString() != "")
                        {
                            OrderData = Client.GetQZPcDataByOrder(context.SessionID, gridView1.GetRowCellValue(i, "生产单号").ToString());

                            gridView1.SetRowCellValue(i, "规格", OrderData.Rows[0]["cspecifications"]);
                            gridView1.SetRowCellValue(i, "纸芯", OrderData.Rows[0]["fweightpapercore"]);
                            gridView1.SetRowCellValue(i, "重量（KG）", OrderData.Rows[0]["fvolumekg"]);
                            gridView1.SetRowCellValue(i, "排产件数", OrderData.Rows[0]["fschedulingnumber"]);
                            gridView1.SetRowCellValue(i, "包装", OrderData.Rows[0]["bundle"]);
                            gridView1.SetRowCellValue(i, "印字内容", OrderData.Rows[0]["content"]);
                            gridView1.SetRowCellValue(i, "特殊要求", OrderData.Rows[0]["claim"]);

                        }
                        else if (gridView1.GetRowCellValue(i, "生产单号").ToString() == "")
                        {
                            gridView1.SetRowCellValue(i, "规格", "");
                            gridView1.SetRowCellValue(i, "纸芯", "");
                            gridView1.SetRowCellValue(i, "重量（KG）", "");
                            gridView1.SetRowCellValue(i, "排产件数", "");
                            gridView1.SetRowCellValue(i, "入库状态", "");
                            gridView1.SetRowCellValue(i, "包装", "");
                            gridView1.SetRowCellValue(i, "印字内容", "");
                            gridView1.SetRowCellValue(i, "特殊要求", "");
                            gridView1.SetRowCellValue(i, "班次", "");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Utils.Logger.Error(ex.ToString());
                }
            }
        }

        private delegate void myDelegate(string s);
        /// <summary>
        /// 串口监听事件，串口一有数据接收，立刻响应该事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SJWeight_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            myDelegate md = new myDelegate(this.SetText);
            try
            {
                if (this.mp.sp.IsOpen)
                {
                    byte[] readBuffer = new byte[this.mp.sp.ReadBufferSize];
                    this.mp.sp.Read(readBuffer, 0, readBuffer.Length);
                    string readstr = Encoding.UTF8.GetString(readBuffer);
                    base.Invoke(md, new object[]
                    {
                        readstr
                    });
                }
            }
            catch (Exception err)
            {
                throw err;
            }

        }

        /// <summary>
        /// 串口监听事件，串口一有数据接收，立刻响应该事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SJWeight2_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            myDelegate md = new myDelegate(this.Set2Text);
            try
            {
                if (this.mp2.sp.IsOpen)
                {
                    byte[] readBuffer = new byte[this.mp2.sp.ReadBufferSize];
                    this.mp2.sp.Read(readBuffer, 0, readBuffer.Length);
                    string readstr = Encoding.UTF8.GetString(readBuffer);
                    base.Invoke(md, new object[]
                    {
                        readstr
                    });
                }
            }
            catch (Exception err)
            {
                throw err;
            }

        }

        /// <summary>
        /// 串口监听事件，串口一有数据接收，立刻响应该事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SJWeight3_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            myDelegate md = new myDelegate(this.Set3Text);
            try
            {
                if (this.mp3.sp.IsOpen)
                {
                    byte[] readBuffer = new byte[this.mp3.sp.ReadBufferSize];
                    this.mp3.sp.Read(readBuffer, 0, readBuffer.Length);
                    string readstr = Encoding.UTF8.GetString(readBuffer);
                    base.Invoke(md, new object[]
                    {
                        readstr
                    });
                }
            }
            catch (Exception err)
            {
                throw err;
            }

        }

        /// <summary>
        /// 串口监听事件，串口一有数据接收，立刻响应该事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SJWeight4_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            myDelegate md = new myDelegate(this.Set4Text);
            try
            {
                if (this.mp4.sp.IsOpen)
                {
                    byte[] readBuffer = new byte[this.mp4.sp.ReadBufferSize];
                    this.mp4.sp.Read(readBuffer, 0, readBuffer.Length);
                    string readstr = Encoding.UTF8.GetString(readBuffer);
                    base.Invoke(md, new object[]
                    {
                        readstr
                    });
                }
            }
            catch (Exception err)
            {
                throw err;
            }

        }


        private static ICacheManager cache = new RedisCacheManager("CacheFileServer");
        /// <summary>
        /// 显示重量并保存到247缓存中
        /// </summary>
        /// <param name="s"></param>
        private void SetText(string s)
        {
            try
            {
                this.NewSJweight.Text = s;
            }
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.ToString());
            }

        }

        private void Set2Text(string s)
        {
            try
            {
                this.NewSJweight2.Text = s;
            }
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.ToString());
            }

        }

        private void Set3Text(string s)
        {
            try
            {
                this.NewSJweight3.Text = s;
            }
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.ToString());
            }

        }

        private void Set4Text(string s)
        {
            try
            {
                this.NewSJweight4.Text = s;
            }
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.ToString());
            }

        }

        private void ControlDeviStatus(string Serial, string Status)
        {
            Byte[] bs;
            string TestString = string.Format("{0}-{2}-{1}", "XXL", Serial, Status);
            if (socket.Connected == true)
            {
                bs = System.Text.Encoding.UTF8.GetBytes(TestString); //发现UTF8可支持中文,就用之
                socket.BeginSend(bs, 0, bs.Length, 0, new AsyncCallback(SendCallback), socket);

            }
        }

        private static void SendCallback(IAsyncResult er)
        {

            try
            {
                //获取异步对象异步操作信息
                Socket Client = (Socket)er.AsyncState;
                //挂起异步 发送请求
                int byteSend = Client.EndSend(er);

            }
            catch (Exception ex)
            {

                Utils.Logger.Error(ex.ToString());
            }
        }


        #endregion

        #region Event

        /// <summary>
        /// 按钮响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "StartOrStop":

                    if (GetGVStatus() == false)
                        break;
                    if (StartOrStop.Text == "启动")
                    {
                        try
                        {
                            //获取对应机号的铁槽的的执行ID信息
                            mp.OpenSJWeight("COM1", 8, 2400);
                            mp2.OpenSJWeight("COM3", 8, 2400);
                            mp3.OpenSJWeight("COM5", 8, 2400);
                            mp4.OpenSJWeight("COM7", 8, 2400);
                            if (mp.modbusStatus == false)
                            {
                                ClsMsg.ShowErrMsg(mp.modbusMsg);
                                return;
                            }
                            if (mp.modbusStatus == true)
                            {
                                StartOrStop.Text = "停止";
                                ClassComboBox.Enabled = false;
                                SJWSerial.Enabled = false;
                                JiHaoComboBox.Enabled = false;
                                //Test.Enabled = false;
                                UpdateOrder.Enabled = false;
                                gridView1.OptionsBehavior.ReadOnly = true;
                                gridView2.OptionsBehavior.ReadOnly = true;
                                gridView1.OptionsBehavior.Editable = false;
                                gridView2.OptionsBehavior.Editable = false;
                                try
                                {
                                    //网络连接异常抛出
                                    //int iNum = 0;
                                    //PingReply reply = null;
                                    //do
                                    //{
                                    //    if (iNum > 0)
                                    //        System.Threading.Thread.Sleep(1000);
                                    //    Ping pingSener = new Ping();
                                    //    reply = pingSener.Send("192.168.1.183", 8899);
                                    //    iNum++;
                                    //} while (reply.Status != IPStatus.Success && iNum < 1);
                                    //if (reply.Status == IPStatus.Success)
                                    //{
                                    //    IP = IPAddress.Parse("192.168.3.51");
                                    //    int point = Convert.ToInt32("8899");
                                    //    endpoint = new IPEndPoint(IP, point);                //建立Socket       
                                    //    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                                    //    socket.Connect(new IPEndPoint(IP, point));
                                    //}
                                    //else if (reply.Status != IPStatus.Success)
                                    //{
                                    //    Utils.Logger.Error("No can connecting Server");
                                    //}


                                    IronTrough1 = new IronTrough(context.SessionID, "6号机", "1号铁槽");

                                    IronTrough2 = new IronTrough(context.SessionID, "6号机", "2号铁槽");
                                    IronTrough3 = new IronTrough(context.SessionID, "6号机", "3号铁槽");
                                    IronTrough4 = new IronTrough(context.SessionID, "6号机", "4号铁槽");



                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("连接尚未建立！无法发送数据!" + ex.Message);
                                }


                                TieCao1 = new Thread(TieCao1Run);
                                TieCao1.Start();

                                TieCao2 = new Thread(TieCao2Run);
                                TieCao2.Start();

                                TieCao3 = new Thread(TieCao3Run);
                                TieCao3.Start();

                                TieCao4 = new Thread(TieCao4Run);
                                TieCao4.Start();
                                SJ_lineName = JiHaoComboBox.Text.ToString().Substring(0, 1);

                                UpdateSJData.Enabled = true;

                            }

                        }
                        catch (Exception ex)
                        {
                            ClsMsg.ShowErrMsg(ex.Message);
                        }

                        return;
                    }


                    if (StartOrStop.Text == "停止")
                    {
                        try
                        {
                            mp.Close();
                            StartOrStop.Text = "启动";
                            ClassComboBox.Enabled = true;
                            SJWSerial.Enabled = true;
                            JiHaoComboBox.Enabled = true;
                            UpdateOrder.Enabled = true;
                            gridView1.OptionsBehavior.ReadOnly = false;
                            gridView2.OptionsBehavior.ReadOnly = false;
                            gridView1.OptionsBehavior.Editable = true;
                            gridView2.OptionsBehavior.Editable = true;
                            socket.Close();
                            socket.Dispose();

                            UpdateSJData.Enabled = false;

                            try
                            {
                                mp.Close();
                                mp2.Close();
                                mp3.Close();
                                mp4.Close();
                                TieCao1.Abort();
                                TieCao2.Abort();
                                TieCao3.Abort();
                                TieCao4.Abort();

                                if (socket != null && socket.Connected == true)
                                {
                                    socket.Shutdown(SocketShutdown.Both);
                                }
                            }
                            catch (Exception ex)
                            {
                                ClsMsg.ShowErrMsg(ex.Message);

                            }

                        }
                        catch (Exception ex)
                        {
                            ClsMsg.ShowErrMsg(ex.Message);

                        }
                        return;
                    }
                    break;

                case "UpdateOrder":

                    repositoryItemComboBox2.Items.Clear();

                    if (!BgWait1.IsBusy)
                        BgWait1.RunWorkerAsync("GetQZPcDataByJH");


                    break;

                case "Test":

                    //if (!BgWait2.IsBusy)
                    //    BgWait2.RunWorkerAsync("GetSJDataByJH");
                    UpdateSJData.Enabled = true;

                    break;


                default:
                    break;

            }

        }

        /// <summary>
        /// 该BgWait1控件用于获取最新能选取的订单，数据来源于勤哲系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void BgWait1_DoWork(object sender, DoWorkEventArgs e)
        {

            BgWait1.ReportProgress(PubConstant.WaitMessageStatus.START);

            try
            {
                switch (e.Argument.ToString())
                {

                    case "GetQZPcDataByJH":

                        e.Result = "GetQZPcDataByJH";

                        using (var Client = new SRQZData.QZDataServiceClient())
                        {
                            try
                            {
                                SJData = Client.GetQZPcDataByJH(context.SessionID, "6号机");
                                BgWait1.ReportProgress(PubConstant.WaitMessageStatus.PROMPT, "更新订单成功！");
                            }

                            catch (Exception ex)
                            {
                                BgWait1.ReportProgress(PubConstant.WaitMessageStatus.END);
                                Utils.Logger.Error(ex.ToString());
                            }
                        }

                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
            }

            BgWait1.ReportProgress(PubConstant.WaitMessageStatus.END);
        }

        private void BgWait1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            repositoryItemComboBox2.Items.Add("");
            try
            {
                if (SJData != null && SJData.Rows.Count > 0)
                {
                    for (int i = 0; i < SJData.Rows.Count; i++)
                    {
                        repositoryItemComboBox2.Items.Add(SJData.Rows[i]["cbatchnumber"].ToString());
                    }
                }
            }

            catch (Exception ex)
            {

                Utils.Logger.Error(ex.ToString());
            }
        }

        /// <summary>
        /// 该BgWait2线程控件用于获取最新的四张订单的已完成数量以及最新录入时间，事务处理使用sql语句
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BgWait2_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                switch (e.Argument.ToString())
                {
                    case "GetSJDataByPC":
                        using (var Client = new SRQZData.QZDataServiceClient())
                        {
                            try
                            {
                                SaveData = Client.GetSJDataByJH(context.SessionID, SJ_lineName);

                            }

                            catch (Exception ex)
                            {
                                Utils.Logger.Error(ex.ToString());
                            }

                        }

                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
            }
        }

        private void BgWait2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (SaveData != null && SaveData.Rows.Count > 0)
            {
                gridControl2.RefreshDataSource();
                gridControl2.DataSource = SaveData;
                bool Warm_Flag = false;

                if (gridView1.GetRowCellValue(0, "排产件数").ToString() != "")
                {

                    string NumTC1 = gridView1.GetRowCellValue(0, "排产件数").ToString();
           
                    for (int i = 0; i < SaveData.Rows.Count; i++)
                    {
                        if (SaveData.Rows[i]["paichan"].ToString() == gridView1.GetRowCellValue(0, "生产单号").ToString())
                        {
                            int Num = Convert.ToInt32(NumTC1) - Convert.ToInt32(SaveData.Rows[i]["serial"].ToString());
                            gridView1.SetRowCellValue(0, "状态", Num.ToString());
                        }
                    }

                }

                if (gridView1.GetRowCellValue(1, "排产件数").ToString() != "")
                {
                    string NumTC2 = gridView1.GetRowCellValue(1, "排产件数").ToString();
                    for (int i = 0; i < SaveData.Rows.Count; i++)
                    {
                        if (SaveData.Rows[i]["paichan"].ToString() == gridView1.GetRowCellValue(1, "生产单号").ToString())
                        {
                            int Num = Convert.ToInt32(NumTC2) - Convert.ToInt32(SaveData.Rows[i]["serial"].ToString());
                            gridView1.SetRowCellValue(1, "状态", Num.ToString());
                        }
                    }


                }

                if (gridView1.GetRowCellValue(2, "排产件数").ToString() != "")
                {
                    string NumTC3 = gridView1.GetRowCellValue(2, "排产件数").ToString();
                    for (int i = 0; i < SaveData.Rows.Count; i++)
                    {
                        if (SaveData.Rows[i]["paichan"].ToString() == gridView1.GetRowCellValue(2, "生产单号").ToString())
                        {
                            int Num = Convert.ToInt32(NumTC3) - Convert.ToInt32(SaveData.Rows[i]["serial"].ToString());
                            gridView1.SetRowCellValue(2, "状态", Num.ToString());
                        }
                    }

                }

                if (gridView1.GetRowCellValue(3, "排产件数").ToString() != "")
                {
                    string NumTC4 = gridView1.GetRowCellValue(3, "排产件数").ToString();
                    for (int i = 0; i < SaveData.Rows.Count; i++)
                    {
                        if (SaveData.Rows[i]["paichan"].ToString() == gridView1.GetRowCellValue(3, "生产单号").ToString())
                        {
                            int Num = Convert.ToInt32(NumTC4) - Convert.ToInt32(SaveData.Rows[i]["serial"].ToString());
                            gridView1.SetRowCellValue(3, "状态", Num.ToString());
                        }
                    }

                }
            }
        }

        /// <summary>
        /// 获取相对应行的订单的明细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemComboBox2_EditValueChanged(object sender, EventArgs e)
        {

            GetOrderDataByGV();

        }


        private void frmSJAutoWind_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (mp != null)
                {
                    mp.Close();
                    mp2.Close();
                    mp3.Close();
                    mp4.Close();
                }
                if (TieCao1 != null)
                    TieCao1.Abort();

                if (socket != null && socket.Connected == true)
                {
                    socket.Shutdown(SocketShutdown.Both);
                }
            }
            catch (Exception ex)
            {

                Utils.Logger.Error(ex.ToString());

            }
        }

        private void UpdateSJData_Tick(object sender, EventArgs e)
        {
            if (!BgWait2.IsBusy)
                BgWait2.RunWorkerAsync("GetSJDataByPC");
        }


        #endregion

        #region  IronTrough

        /// <summary>
        /// 铁槽类，属性暂定铁槽名称，接口名称，执行ID
        /// </summary>
        private class IronTrough
        {
            #region 端口，机号，铁槽号定义
            string IronTroughName
            {
                set;
                get;
            }
            string JiHao
            {
                set;
                get;
            }
            string SessionID
            {
                set;
                get;
            }

            int[] TestExecID = new int[4];
            string[] DevipName = new string[4];


            #endregion

            public IronTrough(string _SessionID, string _JiHao, string _IronTroughName)
            {
                IronTroughName = _IronTroughName;
                JiHao = _JiHao;
                SessionID = _SessionID;

                try
                {
                    using (var Client = new SRExcute.DevExecuteServiceClient())
                    {
                        var result = Client.GetViewExecIDByIrcon(SessionID, JiHao, IronTroughName);
                        if (result.Data.Count() > 0 && result.Data != null)
                        {
                            for (int i = 0; i < result.Data.Count(); i++)
                            {

                                TestExecID[i] = result.Data[i].ExecuteID;
                                DevipName[i] = result.Data[i].DeviName;

                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    Utils.Logger.Error(ex.ToString());
                }
            }

            public string GetDevIStatusOrIDBySerial(string DataType, string _Serial)
            {
                int ResultData = 0;
                string ResultStatus;
                try
                {
                    if (_Serial != "")
                    {
                        for (int i = 0; i < DevipName.Count(); i++)
                        {
                            if (DevipName[i] == _Serial)
                                ResultData = TestExecID[i];

                        }
                        ResultStatus = cache.ListGetByIndex(string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMdd"), ResultData.ToString()), 0);
                        if (DataType == "Status")
                            return ResultStatus;
                        else if (DataType == "ExecID")
                            return ResultData.ToString();
                        else
                            return null;
                    }
                    else
                        return null;

                }
                catch (Exception ex)
                {
                    Utils.Logger.Error(ex.ToString());
                    throw ex;
                }
            }

        }

        #endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //SJ_lineName = JiHaoComboBox.Text.ToString().Substring(0, 1);
            ////  ControlDeviStatus(IronTrough1.GetDevIStatusOrIDBySerial("ExecID", "端口4"), "1");
            //UpdateSJData.Enabled = true;

            //   gridView1.SetRowCellValue(0, "状态", "");
            //     UpdateSJData.Enabled = true;
            //string A = IronTrough1.GetDevIStatusOrIDBySerial("Status", "端口1");
            //  string b = IronTrough2.GetDevIStatusOrIDBySerial("ExecID", "端口5");
            //string c = IronTrough3.GetDevIStatusOrIDBySerial("Status", "端口9");
            //string d = IronTrough4.GetDevIStatusOrIDBySerial("ExecID", "端口13");



            //       ControlDeviStatus(IronTrough2.GetDevIStatusOrIDBySerial("ExecID", "端口5"), "1");

            for (int i = 163; i < 177; i++)
                cache.ListLeftPush(string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMdd"), i.ToString()), "1", 24 * 60);


            // IronTrough1.GetDevIStatusBySerial("端口1");

            //using (var Client = new SRExcute.DevExecuteServiceClient())
            //{
            //    var result = Client.GetViewExecIDByDeviName(context.SessionID,"6号机", "1号铁槽", "端口1");

            //    var Myresult = Client.GetViewExecIDByIrcon(context.SessionID, "6号机", "1号铁槽");

            //   var  ResultData = result.Data.FirstOrDefault().ExecuteID.ToString();

            //}


            //mp.OpenSJWeight("COM1", 8, 2400);
            //mp2.OpenSJWeight("COM3", 8, 2400);
            //mp3.OpenSJWeight("COM5", 8, 2400);
            //mp4.OpenSJWeight("COM7", 8, 2400);
            //if (mp.modbusStatus == false)
            //{
            //    ClsMsg.ShowErrMsg(mp.modbusMsg);
            //    return;
            //}

        }

    }
}
