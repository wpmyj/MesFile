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
using LY.MES.WFCL.SRZhuanGu;
using System.ServiceModel;
using DevExpress.XtraCharts;
using LY.MES.WFCL.Refer;

namespace LY.MES.WFCL.ZhuanGu
{
    public partial class ParameterMonitoring : BaseForm
    {
        ZhuanGuServiceClient ZGClient;
        private string SourceControlName = null; //调用 contextMenuStrip 的控件名
        private string[] TSeriesName = null;
        private string[] VSeriesName = null;
        private string[] yBindNames = null;
        private DateTime NextExecuteTime;

        private System.Timers.Timer Timer1;
        public ParameterMonitoring(UserContext context)
            : base(context)
        {
            InitializeComponent();
            ZGClient = new ZhuanGuServiceClient();
            TSeriesName = new string[] { "温度上限 ℃", "实际温度 ℃", "温度下限 ℃" };
            VSeriesName = new string[] { "真空上限 Pa", "实际真空 Pa", "真空下限 Pa" };
            yBindNames = new string[] { "MaxValue", "ActualValue", "MinValue" };

            Timer1 = new System.Timers.Timer();
            Timer1.Elapsed += new System.Timers.ElapsedEventHandler(Timer1_Tick);
            Timer1.Interval = 1000;
        }

        private void bt_Start_Click(object sender, EventArgs e)
        {
            try
            {
                if (bgWait.IsBusy == false)
                {
                    if (bt_Start.Text == "开始监控")
                    {
                        if (string.IsNullOrEmpty(te_DevCode.Text) == false) //实时数据
                        {
                            NextExecuteTime = new DateTime();
                            bgWait.RunWorkerAsync("LoadCurrentTimeData");
                            bt_Start.Text = "停止监控";
                            Timer1.Enabled = true;
                        }
                        else if (string.IsNullOrEmpty(te_PPNum.Text) == false) //历史数据
                        {
                            bgWait.RunWorkerAsync("LoadHistoryData");
                            bt_Start.Text = "停止监控";
                        }
                    }
                    else
                    {
                        bt_Start.Text = "开始监控";
                        Timer1.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                //ClsMsg.ShowInfoMsg(ex.Message);
                lb_Prompt.Text = ex.Message;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if ((DateTime.Now.AddSeconds(-1) <= NextExecuteTime) && (NextExecuteTime <= DateTime.Now.AddSeconds(1)) ? true : false)
                {
                    if (bgWait.IsBusy == false)
                    {
                        bgWait.RunWorkerAsync("LoadCurrentTimeData");
                    }
                }
                else if (this.NextExecuteTime <= DateTime.Now) //若发现第一个条件未执行到，导致过了执行时间仍未执行数据采集，则执行该操作！
                {
                    this.NextExecuteTime = DateTime.Now.AddSeconds(20);
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                //ClsMsg.ShowInfoMsg(ex.Message);
                lb_Prompt.Text = ex.Message;
            }
        }
        private void bgWait_DoWork(object sender, DoWorkEventArgs e)
        {
            bgWait.ReportProgress(PubConstant.WaitMessageStatus.START);
            try
            {
                switch (e.Argument.ToString())
                {
                    case "LoadHistoryData":
                        var ret1 = ZGClient.GetTempPressureTable(context.SessionID, "烘料",null, te_PPNum.Text);
                        if (ret1.IsSuccess)
                        {
                            e.Result = ret1.Data;
                        }
                        else
                        {
                            e.Result = null;
                           // ClsMsg.ShowInfoMsg(ret1.Message);
                            this.Invoke((MethodInvoker)delegate() { lb_Prompt.Text = ret1.Message; });
                        }
                        break;
                    case "LoadCurrentTimeData":
                        var ret2 = ZGClient.GetTempPressureTable(context.SessionID,"烘料", te_DevCode.Text, null);
                        if (ret2.IsSuccess)
                        {
                            e.Result = ret2.Data;
                        }
                        else
                        {
                            e.Result = null;
                            //ClsMsg.ShowInfoMsg(ret2.Message);
                            Timer1.Stop();
                            this.Invoke((MethodInvoker)delegate() { lb_Prompt.Text = ret2.Message; });
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (FaultException<SRZhuanGu.CustomFaultMessage> fex)
            {
                //bgWait.ReportProgress(102, fex.Message);
                Utils.Logger.Error(fex.ToString());
                this.Invoke((MethodInvoker)delegate() { lb_Prompt.Text = fex.Message; });
                Timer1.Stop();
            }
            catch (Exception ex)
            {
               // bgWait.ReportProgress(102, ex.Message);
                Utils.Logger.Error(ex.ToString());
                this.Invoke((MethodInvoker)delegate() { lb_Prompt.Text = ex.Message; });
                Timer1.Stop();
            }
            bgWait.ReportProgress(PubConstant.WaitMessageStatus.END);
        }

        private void bgWait_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    if (e.Result is DataSet)
                    {
                        var TemperatureTable = (e.Result as DataSet).Tables["Temperature"];
                        var VacuoTable = (e.Result as DataSet).Tables["Vacuo"];
                        var ExecuteTimeTable = (e.Result as DataSet).Tables["ExecuteTime"];
                        var TemperatureTableCount = TemperatureTable.Rows.Count;

                        if (Temperature_Chart.Series.Count == 0 || string.IsNullOrEmpty(te_PPNum.Text)==false)
                        {
                            Temperature_Chart.Series.Clear();
                            Vacuo_Chart.Series.Clear();

                            Client.Utility.Controls.DevChartTool.CreateSeries(Temperature_Chart, TSeriesName, ViewType.Spline, TemperatureTable, "dDate", yBindNames, null, DevExpress.Utils.DefaultBoolean.True);
                            Client.Utility.Controls.DevChartTool.CreateSeries(Vacuo_Chart, VSeriesName, ViewType.Spline, VacuoTable, "dDate", yBindNames, null, DevExpress.Utils.DefaultBoolean.True);
                        }
                        else
                        {
                            Temperature_Chart.DataSource = TemperatureTable;
                            Vacuo_Chart.DataSource = VacuoTable;
                        }

                        //获取实时数据的下次执行时间
                        if (TemperatureTableCount + 1 < ExecuteTimeTable.Rows.Count)
                        {
                            this.NextExecuteTime = (DateTime)ExecuteTimeTable.Rows[TemperatureTableCount]["dDate"];
                        }
                        else if (string.IsNullOrEmpty(te_DevCode.Text) == false && TemperatureTableCount + 1 == ExecuteTimeTable.Rows.Count)
                        {
                            //防止刚好监控步骤完成，而导致无法获取最后一次数据，所以提前15S提取数据
                            this.NextExecuteTime = ((DateTime)ExecuteTimeTable.Rows[TemperatureTableCount]["dDate"]).AddSeconds(-15);
                        }
                        else if (TemperatureTable.Rows[TemperatureTableCount - 1]["dDate"].ToString() == ExecuteTimeTable.Rows[ExecuteTimeTable.Rows.Count - 1]["dDateHour"].ToString()) 
                        {
                            //实时数据获取完成时Timer定时器停止
                            Timer1.Enabled = false;
                        }
                        lb_Prompt.Text = "";//清除报错信息
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                //ClsMsg.ShowInfoMsg(ex.Message);
                lb_Prompt.Text = ex.Message;
                Timer1.Stop();
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "截图"; 
                saveFileDialog.Filter = "Jpeg文件(*.jpg)|*.jpg";
                DialogResult dialogResult = saveFileDialog.ShowDialog(this);

                if (dialogResult == DialogResult.OK)
                {
                    if (SourceControlName == "Temperature_Chart")
                    {
                        Temperature_Chart.ExportToImage(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    else if (SourceControlName == "Vacuo_Chart")
                    {
                        Vacuo_Chart.ExportToImage(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    ClsMsg.ShowInfoMsg(saveFileDialog.FileName + " 保存成功！");
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                //ClsMsg.ShowInfoMsg(ex.Message);
                lb_Prompt.Text = ex.Message;
            }
        }

        //获取调用contextMenuStrip 的控件
        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                SourceControlName = (sender as ContextMenuStrip).SourceControl.Name;
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
               // ClsMsg.ShowInfoMsg(ex.Message);
                lb_Prompt.Text = ex.Message;
            }
        }

        private void te_PPNum_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                ZhuanGu.List.ArrangedVouchCodeList AVCList = new ZhuanGu.List.ArrangedVouchCodeList(context, this);
                if (AVCList.ShowDialog() == DialogResult.OK)
                {
                    te_PPNum.Text = this.Tag.ToString();
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                //ClsMsg.ShowInfoMsg(ex.Message);
                lb_Prompt.Text = ex.Message;
            }
        }
        private void te_DevName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var frmDevChoose = new frmDeviceChoose(context,"01");
                if(frmDevChoose.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    te_DevCode.Text = frmDevChoose.DeviCode;
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                lb_Prompt.Text = ex.Message;
            }
        }

        private void ParameterMonitoring_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Timer1.Enabled = false;
                Timer1.Dispose();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                //ClsMsg.ShowInfoMsg(ex.Message);
                lb_Prompt.Text = ex.Message;
            }
        }


    }
}
