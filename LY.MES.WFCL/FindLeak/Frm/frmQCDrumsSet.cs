using Client.Utility;
using Client.Utility.Controls;
using LY.MES.WFCL.Properties;
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

namespace LY.MES.WFCL.FindLeak.Frm
{
    public partial class frmQCDrumsSet : BaseForm
    {
        private SRQZDDrumesSet.QC_FindLeakDrumsSet model;
        private List<SRQZDDrumesSet.QC_FindLeakDrumsSetDetail> detailList;
        private Nullable<int> ID;

        public frmQCDrumsSet(UserContext context)
            : base(context)
        {
            InitializeComponent();
            bgwWait.ProgressChanged += backgroundWorker_ProgressChanged;
            gridView2.CustomDrawRowIndicator += new GridViewEventTool().GridView_CustomDrawRowIndicator;
            AddFun();
        }

        public frmQCDrumsSet(UserContext context, int ID)
            : base(context)
        {
            InitializeComponent();
            bgwWait.ProgressChanged += backgroundWorker_ProgressChanged;
            gridView2.CustomDrawRowIndicator += new GridViewEventTool().GridView_CustomDrawRowIndicator;
            AddFun();
            this.ID = ID;
        }

        private void AddFun()
        {

            //定义数据库
            model = new SRQZDDrumesSet.QC_FindLeakDrumsSet();
            model.CreatePerson = context.UserName;
            model.CreateDateTime = DateTime.Now;
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
            model.CreateDate = DateTime.Now.Date;
            model.CreatePerson = context.UserName;
            model.Year = DateTime.Now.Year;

            qCFindLeakDrumsSetBindingSource.DataSource = model;

            detailList = new List<SRQZDDrumesSet.QC_FindLeakDrumsSetDetail>();
            qCFindLeakDrumsSetDetailBindingSource.DataSource = detailList;
        }

        private void FrmQCDrumsSet_Load(object sender, EventArgs e)
        {
            if (ID.HasValue)
            {
                simpleButton3.Enabled = simpleButton2.Enabled = simpleButton1.Enabled = false;
                bgwWait.RunWorkerAsync("LoadData");
            }
        }


        //清空
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            AddFun();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            qCFindLeakDrumsSetBindingSource.EndEdit();
            qCFindLeakDrumsSetDetailBindingSource.EndEdit();
            if (model.Frequency.IsNullOrEmpty())
            {
                ClsMsg.ShowWarningEmptyMsg(ForItemFrequency.Text);
                FrequencyTextEdit.Focus();
            }
            else if (detailList.Count == 0)
            {
                ClsMsg.ShowWarningMsg("未选择需要检漏转鼓信息，请选择转鼓");
            }
            else
            {
                bgwWait.RunWorkerAsync("SaveData");
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("弹出筛选视图");
            frmReferQCDFindLeak frm = new frmReferQCDFindLeak(context, model.Year, Convert.ToInt32(model.Month), model.Week);//首先实例化
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var lst = frm.gmc.GetSelectedRows();
                detailList.Clear();
                foreach (var item in lst)
                {
                    var duf = item as SRQZDDrumesSet.vw_DurmsUpFeeding;
                    //var Curr = detailList.Where(t => t.DevCode == duf.DevCode).FirstOrDefault();
                    //if (Curr != null)
                    //{
                    //    detailList.Remove(Curr);
                    //}
                    detailList.Add(new SRQZDDrumesSet.QC_FindLeakDrumsSetDetail()
                    {
                        DevCode = duf.DevCode,
                        ID = model.ID,
                        DevName = duf.DevName,
                        IsLeak = 0,
                        ArrangedVouchCode = duf.ArrangedVouchCode,
                        ExecuteID = duf.ExecuteID
                    });
                }
                qCFindLeakDrumsSetDetailBindingSource.DataSource = detailList;
                gridControl2.RefreshDataSource();
            }
        }

        private void bgwWait_DoWork(object sender, DoWorkEventArgs e)
        {
            bgwWait.ReportProgress(PubConstant.WaitMessageStatus.START);
            try
            {
                switch (e.Argument.ToString())
                {
                    case "SaveData":
                        using (var client = new SRQZDDrumesSet.QCDrumsSetServiceClient())//引用服务
                        {
                            var ret = client.AddQCDrumsSet(context.SessionID, model, detailList.ToArray());//应用增加的方法
                            if (ret.IsSuccess)
                            {
                                e.Result = true;
                            }
                            else { bgwWait.ReportProgress(PubConstant.WaitMessageStatus.WARNING, ret.Message); }
                        }
                        break;
                    case "LoadData":
                        using (var client = new SRQZDDrumesSet.QCDrumsSetServiceClient())//引用服务
                        {
                            var ret = client.GetQCDrumsSet(context.SessionID, ID.Value);
                            model = ret.HeadData;
                            detailList = ret.BodyData.ToList();
                            e.Result = "LoadData";
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                bgwWait.ReportProgress(PubConstant.WaitMessageStatus.ERROR, ex.Message);
            }
            bgwWait.ReportProgress(PubConstant.WaitMessageStatus.END);
        }

        private void bgwWait_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    if (e.Result is bool)
                    {
                        ClsMsg.ShowInfoMsg("提交成功！");
                        this.Close();
                    }
                    else if (e.Result is string && e.Result.ToString().Equals("LoadData"))
                    {
                        qCFindLeakDrumsSetBindingSource.DataSource = model;
                        qCFindLeakDrumsSetDetailBindingSource.DataSource = detailList;
                    }
                }
            }
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.Message);
            }
        }
    }
}
