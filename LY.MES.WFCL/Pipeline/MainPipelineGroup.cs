using Client.Utility;
using Client.Utility.Controls;
using LY.MES.WFCL.SRPiPeline;
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
using Client.Utility.Filter;

namespace LY.MES.WFCL.Pipeline
{
    public partial class MainPipelineGroup : BaseForm
    {
        public SRPiPeline.MainPipelineInfo Model;
        private static List<string> PipelineStaus;
        private static List<string> WorkShopShift;
        public MainPipelineGroup(UserContext context)
            :base(context)
        {
            InitializeComponent();
            backgroundWorker.ProgressChanged += this.backgroundWorker_ProgressChanged;
            Model = new SRPiPeline.MainPipelineInfo();
            PipelineStaus = new List<string>();
            WorkShopShift = new List<string>();
            Client.Utility.DataEnum.GetEnumData(context, "PipelineGroupStatus").ForEach(item => PipelineStaus.Add(item.Item2));
           // PipelineStatusTextEdit.Properties.DataSource = PipelineStaus;
            PromptDesTextEdit.Properties.DataSource = PipelineStaus;
            Client.Utility.DataEnum.GetEnumData(context, "WS.Shift").ForEach(item => WorkShopShift.Add(item.Item2));
            FrequencyTextEdit.Properties.DataSource = WorkShopShift;
        }

        private void PipelineOperate_Load(object sender, EventArgs e)
        {
            Model.Creator = context.UserName;
            Model.CreateDate = DateTime.Now;
            Model.Operator = context.UserName;
            mainPipelineInfoBindingSource.DataSource = Model;

            ResetRW();
        }

        private void ResetRW()
        {
            DeveNameTextEdit.Properties.ReadOnly = true;
            OperatorTextEdit.Properties.ReadOnly = true;
            OperatingTimeTextEdit.Properties.ReadOnly = true;
            CreatorTextEdit.Properties.ReadOnly = true;
            CreateDateDateEdit.Properties.ReadOnly = true;
           // PipelineStatusTextEdit.Properties.ReadOnly = false;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker.ReportProgress(0);
            try
            {
                switch (e.Argument.ToString())
                {
                    case "AddOperatingData":
                        using (var Client = new SRPiPeline.PipelineServiceClient())
                        {
                            mainPipelineInfoBindingSource.EndEdit();
                            Model = mainPipelineInfoBindingSource.DataSource as SRPiPeline.MainPipelineInfo;
                            Model.OperatingTime = Convert.ToDateTime(OperatingTimeTextEdit.Text);
                           // Model.OperatorReamrk = PipelineStatusTextEdit.Text;
                            Model.PipelineStatus = PromptDesTextEdit.Text;
                            Model.CreateDate = Convert.ToDateTime(CreateDateDateEdit.Text);
                            var ret = Client.AddOperatingData(context.SessionID, Model);
                            if (ret.IsSuccess)
                            {
                                ClsMsg.ShowInfoMsg("操作数据保存成功！");
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch(System.ServiceModel.FaultException<CustomFaultMessage>fex)
            {
                backgroundWorker.ReportProgress(102, fex.Message);
                Utils.Logger.Error(fex.ToString());
            }
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
            backgroundWorker.ReportProgress(100);
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
           // mainPipelineInfoBindingSource.DataSource = Model;
            OperatingTimeTextEdit.Text = DateTime.Now.ToString();
            CreateDateDateEdit.Text = DateTime.Now.ToString();

            if (string.IsNullOrEmpty(DeveCodeTextEdit.Text))
            {
                ClsMsg.ShowWarningEmptyMsg(ItemForDeveCode.Text);
                DeveCodeTextEdit.Focus();
            }
            else if (string.IsNullOrEmpty(DeveNameTextEdit.Text))
            {
                ClsMsg.ShowWarningEmptyMsg(ItemForDeveName.Text);
                DeveNameTextEdit.Focus();
            }
            //else if (string.IsNullOrEmpty(PipelineStatusTextEdit.Text))
            //{
            //    ClsMsg.ShowWarningEmptyMsg(ItemForPipelineStatus.Text);
            //    PipelineStatusTextEdit.Focus();
            //}
            else if (string.IsNullOrEmpty(PromptDesTextEdit.Text))
            {
                ClsMsg.ShowWarningEmptyMsg(ItemForPromptDes.Text);
                PromptDesTextEdit.Focus();
            }
            //else if (string.IsNullOrEmpty(OperatorReamrkTextEdit.Text))
            //{
            //    ClsMsg.ShowWarningEmptyMsg(ItemForOperatorReamrk.Text);
            //    OperatorReamrkTextEdit.Focus();
            //}
            else if (string.IsNullOrEmpty(FrequencyTextEdit.Text))
            {
                ClsMsg.ShowWarningEmptyMsg(ItemForFrequency.Text);
                FrequencyTextEdit.Focus();
            }
            else if (string.IsNullOrEmpty(OperatorTextEdit.Text))
            {
                ClsMsg.ShowWarningEmptyMsg(ItemForOperator.Text);
                OperatorTextEdit.Focus();
            }
            else if (string.IsNullOrEmpty(CreatorTextEdit.Text))
            {
                ClsMsg.ShowWarningEmptyMsg(ItemForCreator.Text);
                CreatorTextEdit.Focus();
            }
            else if (string.IsNullOrEmpty(CreateDateDateEdit.Text))
            {
                ClsMsg.ShowWarningEmptyMsg(ItemForCreateDate.Text);
                CreateDateDateEdit.Focus();
            }
            else if(backgroundWorker.IsBusy == false)
            {
                if (ClsMsg.ShowQuestionMsg("是否保存当前操作？") == DialogResult.Yes)
                {
                    backgroundWorker.RunWorkerAsync("AddOperatingData");
                }
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            try
            {
                Model = new SRPiPeline.MainPipelineInfo();
                Model.Operator = context.UserName;
                Model.Creator = context.UserName;
                mainPipelineInfoBindingSource.DataSource = Model;

                ResetRW();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                ClsMsg.ShowErrMsg(ex.Message);
            }
        }

        private void btn_SacnCode_Click(object sender, EventArgs e)
        {
            var result = Client.Utility.BarCode.frmScannCode1.Instance();
            DeveCodeTextEdit.Text = result;
        }

        private void DeveCodeTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (DeveCodeTextEdit.Text.Length == 5)
            {
                GetPipelineOpereate(DeveCodeTextEdit.Text);
            }
        }

        private void GetPipelineOpereate(string PipelineCode)
        {
            try
            {
                using (var client = new SRPiPeline.PipelineServiceClient())
                {
                    var ret = client.GetDaviceInformation(context.SessionID,"06", PipelineCode);
                    
                    if (ret.IsSuccess)
                    {
                        Model = new SRPiPeline.MainPipelineInfo();
                        Model.Operator = context.UserName;
                        Model.Creator = context.UserName;
                        //mainPipelineInfoBindingSource.DataSource = Model;
                        Model.DeveCode = ret.Data.DevCode;
                        Model.DeveName = ret.Data.DevName;
                        mainPipelineInfoBindingSource.DataSource = Model;
                        int iCurrPage = 0;
                        int iPageSize = 0;
                        Tuple<StringBuilder, List<object>> dtFilter = Tuple.Create<StringBuilder, List<object>>(new StringBuilder(), new List<object>());
                        dtFilter.Item1.Append("1 = 1");
                        FilterProcess.MergeFilterCondition("DeveCode", ret.Data.DevCode, ref dtFilter);
                        var mp_ret = client.GetOperatingRecord(context.SessionID, Tuple.Create<string, object[]>(dtFilter.Item1.ToString(), dtFilter.Item2.ToArray()), iCurrPage, iPageSize);
                        if (mp_ret.IsSuccess && mp_ret.Data.Count() > 0)
                        {
                           // PipelineStatusTextEdit.Properties.ReadOnly = true;
                            Model.PipelineStatus = mp_ret.Data.First(t => t.OperatingTime < DateTime.Now).PipelineStatus;

                            //if (PipelineStatusTextEdit.Text == "管道打开")
                            //{
                            //    Model.PromptDes = "管道关闭";
                            //}
                            //else if (PipelineStatusTextEdit.Text == "管道关闭")
                            //{
                            //    Model.PromptDes = "管道打开";
                            //}
                            mainPipelineInfoBindingSource.DataSource = Model;
                        }
                    }
                    else
                    {
                        ClsMsg.ShowInfoMsg(ret.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                ClsMsg.ShowErrMsg(ex.Message);
            }
        }
    }
}
