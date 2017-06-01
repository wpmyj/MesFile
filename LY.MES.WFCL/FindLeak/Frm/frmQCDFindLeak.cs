using Client.Utility;
using Client.Utility.Controls;
using Client.Utility.Filter;
using LY.MES.WFCL.SRQZDDrumesSet;
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

namespace LY.MES.WFCL.FindLeak.List
{
    public partial class frmQCDFindLeak : BaseForm
    {
        private SRFindLeak.QC_DrumsFindLeakReport model;
        private List<SRQZDDrumesSet.vw_QC_FindLeakDrumsSet> lstVW_QC_FindLeakDrumsSet;

        // private SRQZDDrumesSet.vw_QC_FindLeakDrumsSet model3;

        public string strLeakDrums;
        // public string strWeek;
        public DateTime dCurrDate;


        public frmQCDFindLeak(UserContext context)
            : base(context)
        {

            InitializeComponent();//加载组件
            BgWait.ProgressChanged += this.backgroundWorker_ProgressChanged;
            gridView1.CustomDrawEmptyForeground += new GridViewEventTool().GridView_CustomDrawEmptyForeground;
            gridView1.CustomDrawRowIndicator += new GridViewEventTool().GridView_CustomDrawRowIndicator;
            AddFun();

            lstVW_QC_FindLeakDrumsSet = new List<vw_QC_FindLeakDrumsSet>();
        }

        private void AddFun()
        {
            model = new SRFindLeak.QC_DrumsFindLeakReport();//定义model   数据库
            model.CreatePerson = context.UserName;
            model.CreateTime = DateTime.Now;
            string time1 = DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();//得到····月···天
            model.Month = DateTime.Now.Month;// 显示月份

            //目标日期
            DateTime dt = DateTime.Now;

            //该年月所在的周，定义为第一周，sunday为0，monday为1
            DateTime dtFirst = new DateTime(dt.Year, dt.Month, 1);

            //目标日期距离第一天的天数
            int daysCount = Convert.ToInt32((dt - dtFirst).TotalDays);

            //将第一天的日期补齐
            daysCount += Convert.ToInt32(dtFirst.DayOfWeek);

            //目标日期所在的周
            int weeksCount = daysCount / 7;

            //目标日期所在的天
            int dayIdx = Convert.ToInt32(dt.DayOfWeek);
            //显示周次
            model.Week = (weeksCount + 1);
            model.Year = DateTime.Now.Year;
            model.CreateDate = DateTime.Now.Date;

            qCDrumsFindLeakReportBindingSource.DataSource = model;
        }


        private void frmQCDrumsFindLeak_Load(object sender, EventArgs e)
        {
            try
            {
                var FLSituationData = DataEnum.GetEnumData(context, "CF.FLSituation");
                FLSituationTextEdit.Properties.DataSource = FLSituationData;
                BgWait.RunWorkerAsync("SearchData2");//打开窗口显示列表数据
            }
            catch (Exception ex) { Utils.Logger.Error(ex.ToString()); }
        }

        //重置
        private void Butreset_Click(object sender, EventArgs e)
        {
            AddFun();
        }

        //添加
        private void ButAdd_Click(object sender, EventArgs e)
        {
            try
            {
                qCDrumsFindLeakReportBindingSource.EndEdit();//获取文本框数据
                if (model.FLResult.IsNullOrEmpty())
                {
                    FLResultTextEdit.Focus();
                    ClsMsg.ShowWarningEmptyMsg(ItemForFLResult.Text);
                }
                else if (model.Frequency.IsNullOrEmpty())
                {
                    FrequencyTextEdit.Focus();
                    ClsMsg.ShowWarningEmptyMsg(ItemForFrequency.Text);
                }
                else if (model.DevName.IsNullOrEmpty())
                {
                    ClsMsg.ShowWarningEmptyMsg(ItemForDrumsName.Text);
                }
                else if (model.FLSituation.IsNullOrEmpty())
                {
                    FLSituationTextEdit.Focus();
                    ClsMsg.ShowWarningEmptyMsg(ItemForFLSituation.Text);
                }
                else if (model.FLResult.Equals("合格") || ClsMsg.ShowQuestionMsg("当前检漏结果为：不合格！\r\n是否继续提交呢？") == DialogResult.Yes)
                {
                    BgWait.RunWorkerAsync("SaveData");
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                ClsMsg.ShowErrMsg(ex.Message);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var result = Client.Utility.BarCode.frmScannCode1.Instance();
            if (result.IsNullOrEmpty() == false)
            {
                var currDrums = lstVW_QC_FindLeakDrumsSet.Where(t => t.DevCode == result).FirstOrDefault();
                if (currDrums != null)
                {
                    model.DevCode = currDrums.DevCode;
                    model.DevName = currDrums.DevName;
                    model.SourceCode = currDrums.ArrangedVouchCode;
                }
                else
                {
                    model.DevCode = null;
                    model.DevName = null;
                    ClsMsg.ShowWarningMsg("该转鼓未设定检漏或已经检漏。");
                }
            }
            else
            {
                model.DevCode = null;
                model.DevName = null;
            }


            //BgWait.RunWorkerAsync("SearchData");//提交页面数据
        }


        private void DeveCodeTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (model != null)
            {
                if (DeveCodeTextEdit.Text.Length == 6)
                {
                    var currDrums = lstVW_QC_FindLeakDrumsSet.Where(t => t.DevCode == DeveCodeTextEdit.Text).FirstOrDefault();
                    if (currDrums != null)
                    {
                        model.DevCode = currDrums.DevCode;
                        model.DevName = currDrums.DevName;
                        model.SourceCode = currDrums.ArrangedVouchCode.ToString();
                    }
                    else
                    {
                        model.DevCode = null;
                        model.DevName = null;
                        model.SourceCode = null;
                        ClsMsg.ShowWarningMsg("该转鼓未设定检漏或已经检漏。");
                    }
                }
                else
                {
                    model.DevCode = null;
                    model.DevName = null;
                    model.SourceCode = null;
                }
            }
        }


        private void BgWait_DoWork(object sender, DoWorkEventArgs e)
        {

            BgWait.ReportProgress(0);
            try
            {
                switch (e.Argument.ToString())
                {

                    case "SearchData":
                        //清空列表
                        //model2 = new SRQZDDrumesSet.QC_FindLeakDrumsSet();
                        //qCFindLeakDrumsSetBindingSource.DataSource = model2;

                        using (var client = new SRQZDDrumesSet.QCDrumsSetServiceClient())
                        {
                            strLeakDrums = DeveCodeTextEdit.Text;

                            var ret = client.GetQCDrumsSetQRCode(context.SessionID, strLeakDrums);
                            if (ret.IsSuccess)
                            {
                                e.Result = ret.Data;
                            }
                            else
                                BgWait.ReportProgress(101, ret.Message);
                        }
                        break;

                    case "SearchData2":
                        SearchData2(e);
                        break;
                    case "SaveData":
                        using (var client = new SRFindLeak.QCDFindLeakServiceClient())//引用服务
                        {
                            var ret = client.AddQCDrumsFindLeakReport(context.SessionID, model);//应用,增加的方法
                            if (ret.IsSuccess)
                            {
                                BgWait.ReportProgress(PubConstant.WaitMessageStatus.PROMPT, "提交成功！");
                                this.Invoke((MethodInvoker)delegate()
                                {
                                    AddFun();
                                });
                                SearchData2(e);
                            }
                            else
                            {
                                BgWait.ReportProgress(PubConstant.WaitMessageStatus.WARNING, ret.Message);
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
                BgWait.ReportProgress(PubConstant.WaitMessageStatus.ERROR, ex.Message);
            }

            BgWait.ReportProgress(PubConstant.WaitMessageStatus.END);
        }

        private void SearchData2(DoWorkEventArgs e)
        {
            //打开窗口显示列表数据
            using (var client = new SRQZDDrumesSet.QCDrumsSetServiceClient())//引用服务
            {
                dCurrDate = Convert.ToDateTime(CreateTimeDateEdit.Text);

                var retlog = client.Getvw_QC_FindLeakDrumsSetList(context.SessionID, dCurrDate); // 转鼓当天待检漏信息

                if (retlog.IsSuccess)
                {
                    e.Result = retlog.Data;

                }
                else { ClsMsg.ShowWarningMsg(retlog.Message); }
            }
        }

        private void BgWait_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                if (e.Result is SRQZDDrumesSet.vw_QC_FindLeakDrumsSet[])
                {
                    gridControl1.RefreshDataSource();

                    lstVW_QC_FindLeakDrumsSet = (e.Result
                        as SRQZDDrumesSet.vw_QC_FindLeakDrumsSet[]).ToList();
                    vwQCFindLeakDrumsSetBindingSource.DataSource = lstVW_QC_FindLeakDrumsSet;
                }
            }
        }
    }
}




