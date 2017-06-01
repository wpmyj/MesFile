using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Utility;
using Client.Utility.Controls;
using Client.Utility.Caching;
using Client.Utility.Logging;
using Client.Utility.Extension;

using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;
using System.Text.RegularExpressions;
using LY.MES.WFCL.SRExcute;
using LY.MES.WFCL.Drums.Frm;

namespace LY.MES.WFCL.CustomControl
{
    public partial class SingleDrumsControl : BaseForm
    {

        #region Define

        AutoSizeFormClass asc = new AutoSizeFormClass();
        private static ICacheManager cache = new RedisCacheManager("CacheFileServer");
        SRExcute.DevExecuteServiceClient client = new SRExcute.DevExecuteServiceClient();

        private IPAddress IP;
        private EndPoint endpoint;
        private Socket socket;
        private Thread MyThread;
        private System.IO.Stream stream = null;
        private System.Reflection.Assembly ass = null;
        private System.Media.SoundPlayer pl = null;
        private string txt;

        public delegate void UpdateControlList(Object sender, EventArgs e, String Str);
        public static UpdateControlList UpdateList;

        public delegate void UpdateControl(Object sender, EventArgs e);
        public static UpdateControl UpdateStatus;

        private static ManualResetEvent connectDone = new ManualResetEvent(false);
        private static ManualResetEvent sendDone = new ManualResetEvent(false);
        private static ManualResetEvent receiveDone = new ManualResetEvent(false);

        private static string response = string.Empty;

        #endregion

        #region Main

        public SingleDrumsControl(UserContext context)
        {
            InitializeComponent();
            //异步通信初始数据定义
            UpdateList += new UpdateControlList(this.listTest);
            UpdateStatus += new UpdateControl(this.Status);
        }

        private void SingleDrumsControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            //  TheradScoket();
            if (socket != null && socket.Connected == true)
            {
                socket.Shutdown(SocketShutdown.Both);
            }
        }

        #endregion

        #region Event


        /// <summary>
        /// 定时器事件，每秒的频率更新设备状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CollectTime_Tick(object sender, EventArgs e)
        {
            try
            {
                string PreKey_ID = string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMdd"), 37);
                string Pre = cache.ListGetByIndex(PreKey_ID, 0);
                //   string[] PreArray = Pre.Split('-');
                // PressText.Text = DevDataConvert.ConverTPData(Pre.ToString(), "0.16", "0", "0");
                PressText.Text = Pre;
                //压力最大量程0.16    最小量程  0   偏差   0

                string TemKey_ID = string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMdd"), 38);
                string Tem = cache.ListGetByIndex(TemKey_ID, 0);
                //   string[] TemArray = Tem.Split('-');
                // TemperText.Text = TemArray[0].ToString();
                // TemperText.Text = DevDataConvert.ConverTPData(Tem.ToString(), "420", "-200", "-30");
                TemperText.Text = Tem;

                //温度最大量程 420    最小量程  -200    偏差 -30

                string VacKey_ID = string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMdd"), 39);
                string Vac = cache.ListGetByIndex(VacKey_ID, 0);
                //  string[] VacArray = Vac.Split('-');
                //   VacuumText.Text = DevDataConvert.ConverVacuumData(Vac.ToString());

                string TextVac = String.Format("{0:F}", Convert.ToDouble(Vac));
                VacuumText.Text = TextVac;

                string Tap1Key_ID = string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMdd"), 50);
                string Tap1 = cache.ListGetByIndex(Tap1Key_ID, 0);
                //   string[] Tap1Array = Tap1.Split('-');
                if (Tap1.ToString() == "0")
                {
                    button2.Image = Properties.Resources.开阀门;
                    //   button2.Image = Properties.Resources.关阀门;
                }
                else if (Tap1.ToString() == "1")
                {
                    button2.Image = Properties.Resources.关阀门;
                }
                string Tap2Key_ID = string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMdd"), 51);
                string Tap2 = cache.ListGetByIndex(Tap2Key_ID, 0);
                //  string[] Tap2Array = Tap2.Split('-');
                if (Tap2.ToString() == "0")
                {
                    button3.Image = Properties.Resources.开阀门;
                }
                else if (Tap2.ToString() == "1")
                {
                    button3.Image = Properties.Resources.关阀门;
                }
                string Tap3Key_ID = string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMdd"), 52);
                string Tap3 = cache.ListGetByIndex(Tap3Key_ID, 0);
                // string[] Tap3Array = Tap3.Split('-');
                if (Tap3.ToString() == "0")
                {
                    button1.Image = Properties.Resources.开阀门;
                }
                else if (Tap3.ToString() == "1")
                {
                    button1.Image = Properties.Resources.关阀门;
                }

                //D04，DI7中真空阀门状态
                string Tap4Key_ID = string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMdd"), 53);
                string Tap4 = cache.ListGetByIndex(Tap4Key_ID, 0);
                // string[] Tap3Array = Tap3.Split('-');
                if (Tap4.ToString() == "0")
                {
                    button7.Image = Properties.Resources.开阀门;
                }
                else if (Tap4.ToString() == "1")
                {
                    button7.Image = Properties.Resources.关阀门;
                }
            }
            catch (Exception ex)
            {
                CollectTime.Enabled = false;
                Utils.Logger.Error(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 连接设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (ClsMsg.ShowQuestionMsg("是否连接设备?") == DialogResult.Yes)
            {
                button4.Enabled = false;
                try
                {
                    // 获取到本机IP
                    GetServerIP();
                    //自动获取到本机电脑端口
                  //  IP = IPAddress.Parse("192.168.1.238");
                    IP = IPAddress.Parse("192.168.1.238");

                    int point = Convert.ToInt32("8899");

                    endpoint = new IPEndPoint(IP, point);                //建立Socket       
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    CollectTime.Start();
                    System.Threading.Thread th = new System.Threading.Thread(this.ToConnect);
                    th.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("连接尚未建立！无法发送数据!" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 数采仪接口②控制前真空阀门
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ; Byte[] bs;

                //  string Tap1 = cache.ListGetByIndex("50", 0);
                string Tap1 = string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMdd"), 50);

                string Tap1Array = cache.ListGetByIndex(Tap1, 0);

                if (socket.Connected == true)
                {

                    if (Tap1Array[0].ToString() == "1")
                    {
                        if (ClsMsg.ShowQuestionMsg("是否要打开前真空阀门？") == DialogResult.Yes)
                        {
                            bs = System.Text.Encoding.UTF8.GetBytes("XXL-1-50"); //发现UTF8可支持中文,就用之
                            socket.BeginSend(bs, 0, bs.Length, 0, new AsyncCallback(SendCallback), socket);
                        }
                    }
                    else if (Tap1Array[0].ToString() == "0")
                    {
                        if (ClsMsg.ShowQuestionMsg("是否要关闭前真空阀门？") == DialogResult.Yes)
                        {
                            bs = System.Text.Encoding.UTF8.GetBytes("XXL-0-50"); //发现UTF8可支持中文,就用之
                            socket.BeginSend(bs, 0, bs.Length, 0, new AsyncCallback(SendCallback), socket);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("网络设备无法连接，请根据右上角提示进行处理！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接尚未建立！无法发送数据!" + ex.Message);
            }
        }

        /// <summary>
        /// 数采仪接口③控制排水阀门
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                Byte[] bs;
                string Tap1 = string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMdd"), 51);
                //  string Tap1 = cache.ListGetByIndex("51", 0);
                string Tap1Array = cache.ListGetByIndex(Tap1, 0);

                if (socket.Connected == true)
                {
                    if (Tap1Array.ToString() == "1")
                    {
                        if (ClsMsg.ShowQuestionMsg("是否要打开排水阀门？") == DialogResult.Yes)
                        {
                            bs = System.Text.Encoding.UTF8.GetBytes("XXL-1-51"); //发现UTF8可支持中文,就用之
                            socket.BeginSend(bs, 0, bs.Length, 0, new AsyncCallback(SendCallback), socket);
                        }
                    }
                    else if (Tap1Array.ToString() == "0")
                    {
                        if (ClsMsg.ShowQuestionMsg("是否要关闭排水阀门？") == DialogResult.Yes)
                        {
                            bs = System.Text.Encoding.UTF8.GetBytes("XXL-0-51"); //发现UTF8可支持中文,就用之
                            socket.BeginSend(bs, 0, bs.Length, 0, new AsyncCallback(SendCallback), socket);
                        }
                    }

                }

                else
                {
                    MessageBox.Show("网络设备无法连接，请根据右上角提示进行处理！");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("连接尚未建立！无法发送数据!" + ex.Message);
            }
        }

        /// <summary>
        /// 数采仪接口控制后真空阀门
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                Byte[] bs;

                //string Tap1 = cache.ListGetByIndex("52", 0);
                //string[] Tap1Array = Tap1.Split('-');

                string Tap1 = string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMdd"), 52);

                string Tap1Array = cache.ListGetByIndex(Tap1, 0);

                if (socket.Connected == true)
                {
                    if (Tap1Array[0].ToString() == "1")
                    {
                        if (ClsMsg.ShowQuestionMsg("是否要打开后真空阀门？") == DialogResult.Yes)
                        {
                            bs = System.Text.Encoding.UTF8.GetBytes("XXL-1-52"); //发现UTF8可支持中文,就用之
                            socket.BeginSend(bs, 0, bs.Length, 0, new AsyncCallback(SendCallback), socket);
                        }
                    }
                    else if (Tap1Array[0].ToString() == "0")
                    {
                        if (ClsMsg.ShowQuestionMsg("是否要关闭后真空阀门？") == DialogResult.Yes)
                        {
                            bs = System.Text.Encoding.UTF8.GetBytes("XXL-0-52"); //发现UTF8可支持中文,就用之
                            socket.BeginSend(bs, 0, bs.Length, 0, new AsyncCallback(SendCallback), socket);
                        }
                    }
                }

                else
                {
                    MessageBox.Show("网络设备无法连接，请根据右上角提示进行处理！");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("连接尚未建立！无法发送数据!" + ex.Message);
            }
        }

        /// <summary>
        /// IP登记表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IPRegtion_Click(object sender, EventArgs e)
        {
            frmIPRegitForm IPRegtion = new frmIPRegitForm(new UserContext("test"));
            IPRegtion.ShowDialog();

        }

        #endregion

        #region Method

        /// <summary>
        /// 无引用，准备删除
        /// </summary>
        //private void TheradScoket()
        //{
        //    try
        //    {
        //        Thread TempThread;
        //        //开启接收线程    
        //        TempThread = new Thread(new ThreadStart(this.ToConnect));
        //        TempThread.IsBackground = true;//设置为后台线程    
        //        TempThread.Start();
        //        TempThread.Abort();//关闭线程   
        //        Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //        //关闭套接字    
        //        client.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Utils.Logger.Error(ex.ToString());
        //    }


        //}

        /// <summary>
        /// 异步挂起 需要优化
        /// </summary>
        /// <param name="er"></param>
        private static void ReceiveCallback(IAsyncResult er)
        {
            try
            {
                //异步操作获取用户定义信息
                StateObjcet state = (StateObjcet)er.AsyncState;
                Socket client = state.workSocket;

                //结束挂起异步读取
                int bytebuffer = client.EndReceive(er);
                if (bytebuffer > 0)
                {

                    UpdateList(new SingleDrumsControl(new UserContext("test")), new EventArgs(), Encoding.ASCII.GetString(state.buffer, 0, state.buffer.Length));
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytebuffer));
                    client.BeginReceive(state.buffer, 0, StateObjcet.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);

                }
                else
                {
                    if (state.sb.Length > 1)
                    {
                        response = state.sb.ToString();
                    }
                    receiveDone.Set();
                    client.Close();
                }

            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
            }

        }


        /// <summary>
        ///读取Socket 套接字
        /// </summary>
        /// <param name="client"></param>
        private static void Receive(Socket client)
        {
            try
            {
                StateObjcet state = new StateObjcet();
                state.workSocket = client;

                client.BeginReceive(state.buffer, 0, StateObjcet.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);

            }
            catch (Exception ex)
            {
                // MessageBox.Show(e.ToString());
                Utils.Logger.Error(ex.ToString());
            }

        }

        //异步发送信息
        /// <summary>
        /// 异步发送
        /// </summary>
        /// <param name="er"></param>
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
                // MessageBox.Show(e.ToString());
                Utils.Logger.Error(ex.ToString());
            }
        }


        private static void ConnectCallback(IAsyncResult er)
        {
            try
            {

                // 获取到异步操作信息
                Socket client = (Socket)er.AsyncState;
                UpdateStatus(new SingleDrumsControl(new UserContext("test")), new EventArgs());
                StateObjcet state = new StateObjcet();
                state.workSocket = client;

                client.BeginReceive(state.buffer, 0, StateObjcet.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);

                //  Receive(client);
                // 结束挂起异步连接操作请求
                //client.EndConnect(er);


            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                return;

            }

        }

        // 接收数据信息
        public void ReceiveMsg()
        {

            while (true)
            {

                try
                {

                    byte[] date = new byte[1024];

                    int recv = socket.Receive(date);
                    string str = Encoding.UTF8.GetString(date, 0, recv);
                }
                catch (SocketException ex)
                {
                    Utils.Logger.Error(ex.ToString());
                }
            }

        }

        public void listTest(Object o, EventArgs e, String str)
        {
            //  this.richTextBox1.Text = str;

            label5.Text = str;



        }

        public void Status(Object o, EventArgs e)
        {
            //    lblStatus.Text = "连接成功.";
            //    button1.Enabled = false;
        }

        private void ToConnect()
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            try
            {
                //连接成功   
                socket.BeginConnect(endpoint, new AsyncCallback(ConnectCallback), socket);
                String str = button1.Text.ToString();
                if (socket.Connected == false)
                    label5.Text = "Wait for connection server";
                //Receive(socket);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("IP error OR Point error");
                Utils.Logger.Error(ex.ToString());


            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("IP error OR Point error");
                Utils.Logger.Error(ex.ToString());


            }
            catch (Exception ex)
            {
                // lblStatus.Text = "连接失败，原因: 服务器已停止.";
                MessageBox.Show("连接失败，原因: 服务器已停止.");
                Utils.Logger.Error(ex.ToString());
            }

        }


        //--------------------------------------------------------------------//

        //异步通信方法定义
        //--------------------------------------------------------------------//
        public class StateObjcet
        {
            public Socket workSocket = null;
            public const int BufferSize = 256;

            public byte[] buffer = new byte[BufferSize];
            public StringBuilder sb = new StringBuilder();
        }

        public static IPAddress GetServerIP()        //静态函数, 无需实例化即可调用.
        {
            IPHostEntry ieh = Dns.GetHostEntry(Dns.GetHostName()); //不多说了, Dns类的两个静态函数
            // Dns.GetHostEntry(Dns.GetHostName());

            //或用DNS.Resolve()代替GetHostName()
            return ieh.AddressList[0];                  //返回Address类的一个实例. 这里AddressList是数组并不奇怪,一个Server有N个IP都有可能
        }




        #endregion

        private void button5_Click(object sender, EventArgs e)
        {
            Byte[] bs;
            if (ClsMsg.ShowQuestionMsg("是否要打开排水阀门？") == DialogResult.Yes)
            {
                bs = System.Text.Encoding.UTF8.GetBytes("XXL-1-53"); //发现UTF8可支持中文,就用之
                socket.BeginSend(bs, 0, bs.Length, 0, new AsyncCallback(SendCallback), socket);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Byte[] bs;
            if (ClsMsg.ShowQuestionMsg("是否要打开排水阀门？") == DialogResult.Yes)
            {
                bs = System.Text.Encoding.UTF8.GetBytes("XXL-0-53"); //发现UTF8可支持中文,就用之
                socket.BeginSend(bs, 0, bs.Length, 0, new AsyncCallback(SendCallback), socket);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {

                Byte[] bs;
                string Tap1 = string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMdd"), 53);
                //  string Tap1 = cache.ListGetByIndex("51", 0);
                string Tap1Array = cache.ListGetByIndex(Tap1, 0);

                if (socket.Connected == true)
                {
                    if (Tap1Array.ToString() == "1")
                    {
                        if (ClsMsg.ShowQuestionMsg("是否要打开排水阀门？") == DialogResult.Yes)
                        {
                            bs = System.Text.Encoding.UTF8.GetBytes("XXL-1-53"); //发现UTF8可支持中文,就用之
                            socket.BeginSend(bs, 0, bs.Length, 0, new AsyncCallback(SendCallback), socket);
                        }
                    }
                    else if (Tap1Array.ToString() == "0")
                    {
                        if (ClsMsg.ShowQuestionMsg("是否要关闭排水阀门？") == DialogResult.Yes)
                        {
                            bs = System.Text.Encoding.UTF8.GetBytes("XXL-0-53"); //发现UTF8可支持中文,就用之
                            socket.BeginSend(bs, 0, bs.Length, 0, new AsyncCallback(SendCallback), socket);
                        }
                    }

                }

                else
                {
                    MessageBox.Show("网络设备无法连接，请根据右上角提示进行处理！");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("连接尚未建立！无法发送数据!" + ex.Message);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Byte[] bs;
            
            string TestString = textBox2.Text;
            if (socket.Connected == true)
            {
                bs = System.Text.Encoding.UTF8.GetBytes(TestString); //发现UTF8可支持中文,就用之
                socket.BeginSend(bs, 0, bs.Length, 0, new AsyncCallback(SendCallback), socket);

            }
        }



    }
}
