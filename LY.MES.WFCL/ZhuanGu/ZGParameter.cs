using Client.Utility;
using Client.Utility.Caching;
using Client.Utility.Controls;
using DevExpress.XtraCharts;
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
using LY.MES.WFCL.Refer;

namespace LY.MES.WFCL.ZhuanGu
{
    public partial class ZGParameter : BaseForm
    {
        private SRZhuanGu.ZhuanGuServiceClient ZGClient;
        private SRDataColl.CollectDataInfo Model = null;
        private string ZGPressure = null; //压力
        private string ZGTemperature = null; //温度
        private string ZGVacuo = null; //真空
        private string Pressure_Key = null;
        private string Temperature_Key = null;
        private string ZGVacuo_Key = null;
        private DataTable dtPressure = new DataTable();
        private DataTable dtTemperature = new DataTable();
        private DataTable dtVacuo = new DataTable();
        private System.Timers.Timer Coll_Timer;

        public static int MaxSPointCount = 0;
        public ZGParameter(UserContext context)
            : base(context)
        {
            try
            {
                
                InitializeComponent();
                ZGClient = new SRZhuanGu.ZhuanGuServiceClient();
                dtPressure.Columns.AddRange(new DataColumn[] { new DataColumn("dDate", typeof(string)), new DataColumn("dValue", typeof(decimal)) });
                dtTemperature = dtPressure.Clone();
                dtVacuo = dtPressure.Clone();
                //dtTemperature.Columns.AddRange(new DataColumn[] { new DataColumn("dDate", typeof(string)), new DataColumn("dValue", typeof(decimal)) });
                //dtVacuo.Columns.AddRange(new DataColumn[] { new DataColumn("dDate", typeof(string)), new DataColumn("dValue", typeof(decimal)) });
                MaxSPointCount = 30;
                Model = new SRDataColl.CollectDataInfo();
                Coll_Timer = new System.Timers.Timer();
                Coll_Timer.Elapsed += new System.Timers.ElapsedEventHandler(coll_timer_Tick);
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                lb_Prompt.Text  = ex.Message;
            }
        }

        private void bt_Start_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(te_DevCode.Text) == false)
                {

                    if (bt_Start.Text == "开始监测")
                    {
                        if (te_interval.Text.IsNullOrEmpty())
                        {
                            // ClsMsg.ShowInfoMsg("请数据数据更新时间间隔！");
                            lb_Prompt.Text = "请数据数据更新时间间隔！";
                            Coll_Timer.Stop();
                        }
                        else
                        {
                            Coll_Timer.Interval = Convert.ToInt32(te_interval.Text) * 1000;//以秒为单位
                            //Coll_Timer.Interval = Convert.ToInt32(te_interval.Text) * 1000 * 60;//以分钟为单位
                            Coll_Timer.Start();
                            LoadParamterData();
                            bt_Start.Text = "停止监测";
                            lb_Prompt.Text = ""; //清除报错信息
                        }
                    }
                    else if (bt_Start.Text == "停止监测")
                    {
                        Coll_Timer.Stop();
                        bt_Start.Text = "开始监测";
                    }
                }
                else
                {
                    //ClsMsg.ShowWarningEmptyMsg(lb_DevCode.Text);
                    lb_Prompt.Text = lb_DevCode.Text+"不能为空！";
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                lb_Prompt.Text = ex.Message;
            }

        }

        private void coll_timer_Tick(object sender, EventArgs e)
        {
            try
            {
                LoadParamterData();
                this.Invoke((MethodInvoker)delegate() { lb_Prompt.Text = ""; }); //清除报错信息
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                this.Invoke((MethodInvoker)delegate() { lb_Prompt.Text = ex.Message; });
                Coll_Timer.Stop();
            }
        }

        public void LoadParamterData()
        {
            //Pressure_Key = string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMdd"), 37);
            //Temperature_Key = string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMdd"), 38);
            //ZGVacuo_Key = string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMdd"), 39);

            //获取相应转鼓相应设备接口的接口的执行ID
            Pressure_Key = ZGClient.GetDevExecuteId(context.SessionID, te_DevCode.Text, "压力传感器").Data;
            Temperature_Key = ZGClient.GetDevExecuteId(context.SessionID, te_DevCode.Text, "温度传感器").Data;
            ZGVacuo_Key = ZGClient.GetDevExecuteId(context.SessionID, te_DevCode.Text, "真空传感器").Data;

            RedisCacheManager cache = new RedisCacheManager("CacheFileServer");

            ZGPressure = cache.ListGetByIndex(Pressure_Key, 0);
            ZGTemperature = cache.ListGetByIndex(Temperature_Key, 0);
            ZGVacuo = cache.ListGetByIndex(ZGVacuo_Key, 0);

            SetAdd(Convert.ToDecimal(ZGPressure), dtPressure);
            SetAdd(Convert.ToDecimal(ZGTemperature), dtTemperature);
            SetAdd(Convert.ToDecimal(ZGVacuo), dtVacuo);

            if (YaLIChart.Series.Count == 0)
            {
                YaLIChart.Series.Clear();
                WenDuChart.Series.Clear();
                ZhenKongChart.Series.Clear();

                this.Invoke((MethodInvoker)delegate() { YaLIChart.CreateSeries("压力 Pa", ViewType.Spline, dtPressure, "dDate", "dValue", null); });
                this.Invoke((MethodInvoker)delegate() { WenDuChart.CreateSeries("温度 ℃", ViewType.Spline, dtTemperature, "dDate", "dValue", null); });
                this.Invoke((MethodInvoker)delegate() { ZhenKongChart.CreateSeries("真空 Pa", ViewType.Spline, dtVacuo, "dDate", "dValue", null); });
            }
            else
            {
                YaLIChart.DataSource = dtPressure;
                WenDuChart.DataSource = dtTemperature;
                ZhenKongChart.DataSource = dtVacuo;

                this.Invoke((MethodInvoker)delegate() { YaLIChart.Refresh(); });
                this.Invoke((MethodInvoker)delegate() { WenDuChart.Refresh(); });
                this.Invoke((MethodInvoker)delegate() { ZhenKongChart.Refresh(); });
            }

            
           // SaveCollDataAsync(Pressure_Key, ZGPressure);
           // SaveCollDataAsync(Temperature_Key, ZGTemperature);
           // SaveCollDataAsync(ZGVacuo_Key, ZGVacuo);
        }

        //将采集数据保存
        private async void SaveCollDataAsync(string key, string data)
        {
            using (var Client = new SRDataColl.DeviceCollectServiceClient())
            {
                Model.CollValue = Convert.ToDecimal(data);
                Model.CreateDate = DateTime.Now;
                Model.DeveCode = Convert.ToInt32(key.Split('_').ElementAt(1));
                await Client.AddZGParameterAsync(context.SessionID, Model);
            }
        }

        private void SetAdd(decimal dValue, DataTable dt)
        {
            DataRow dRow = dt.NewRow();
            dRow["dDate"] = DateTime.Now.ToString("HH:mm:ss");
            dRow["dValue"] = dValue;
            dt.Rows.Add(dRow);
            if (dt.Rows.Count > 30) //界面上最多显示30条数据
            {
                dt.Rows.RemoveAt(0);
            }
        }

        private void te_DevCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var frmDevChoose = new frmDeviceChoose(context, "01");
                if (frmDevChoose.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    te_DevCode.Text = frmDevChoose.DeviCode;
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                this.Invoke((MethodInvoker)delegate() { lb_Prompt.Text = ex.Message; });
            }
        }

        private void ZGParameter_FormClosing(object sender, FormClosingEventArgs e)
        {
            Coll_Timer.Stop();
            Coll_Timer.Dispose();
        }



    }
    public static class ChartToolV3
    {
        /// <summary>
        /// 创建Series
        /// </summary>
        /// <param name="chat">ChartControl</param>
        /// <param name="seriesName">Series名字『诸如：理论电量』</param>
        /// <param name="seriesType">seriesType『枚举』</param>
        /// <param name="dataSource">数据源</param>
        /// <param name="xBindName">ChartControl的X轴绑定</param>
        /// <param name="yBindName">ChartControl的Y轴绑定</param>
        public static void CreateSeries(this ChartControl chat, string seriesName, ViewType seriesType, object dataSource, string xBindName, string yBindName)
        {
            CreateSeries(chat, seriesName, seriesType, dataSource, xBindName, yBindName, null);
        }
        /// <summary>
        /// 创建Series
        /// </summary>
        /// <param name="chat">ChartControl</param>
        /// <param name="seriesName">Series名字『诸如：理论电量』</param>
        /// <param name="seriesType">seriesType『枚举』</param>
        /// <param name="dataSource">数据源</param>
        /// <param name="xBindName">ChartControl的X轴绑定</param>
        /// <param name="yBindName">ChartControl的Y轴绑定</param>
        /// <param name="createSeriesRule">Series自定义『委托』</param>
        public static void CreateSeries(this ChartControl chat, string seriesName, ViewType seriesType, object dataSource, string xBindName, string yBindName, Action<Series> createSeriesRule)
        {
            if (chat == null)
                throw new ArgumentNullException("chat");
            if (string.IsNullOrEmpty(seriesName))
                throw new ArgumentNullException("seriesType");
            if (string.IsNullOrEmpty(xBindName))
                throw new ArgumentNullException("xBindName");
            if (string.IsNullOrEmpty(yBindName))
                throw new ArgumentNullException("yBindName");

            Series _series = new Series(seriesName, seriesType);
            _series.ArgumentScaleType = ScaleType.Qualitative;
            _series.ArgumentDataMember = xBindName;
            _series.ValueDataMembers[0] = yBindName;

           // _series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

            if ((dataSource as DataTable).Rows.Count > 0)
                _series.DataSource = dataSource;
            if (createSeriesRule != null)
                createSeriesRule(_series);
            chat.Series.Add(_series);
        }

    }

}
