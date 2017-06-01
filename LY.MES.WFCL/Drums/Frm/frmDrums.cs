using Client.Utility;
using Client.Utility.Controls;
using LY.MES.WFCL.CustomControl;
using LY.MES.WFCL.SRExcute;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LY.MES.WFCL.Drums.Frm
{
    public partial class frmDrums : BaseForm
    {

        private SRCfPExecute.vw_DurmsUpFeeding vw_DurmsUpFeedingModel = null;
        public frmDrums(UserContext context)
            : base(context)
        {
            InitializeComponent();
            BgWait.ProgressChanged += this.backgroundWorker_ProgressChanged;

            DeveUseStatusSpinEdit.Properties.DataSource = Client.Utility.DataEnum.GetEnumData("devstatus");

        }

        private void frmDrums_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InsterData();
        }

        private void ScanCodeBtn_Click(object sender, EventArgs e)
        {
            var result = Client.Utility.BarCode.frmScannCode1.Instance();
            WorkbrachNameTextEdit.Text = result;




        }
        /// <summary>
        /// 根据RFID卡号获取明细信息，包括残留的排配单号获取上一步数据
        /// </summary>&& CraftsNameTextEdit.Text == "上料"  第一个判断条件因为界面遗留数据简便操作，暂时注释20170109XCQ
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RFIDCodeTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            //  if (RFIDCodeTextEdit.Text.Length == 10)
            if (RFIDCodeTextEdit.Text.Length == 10)
            {
                if (DeveUseStatusSpinEdit.Text != "正常")
                {
                    ClsMsg.ShowErrMsg("当前鼓号设备状态异常，请先扫描正确的鼓号");

                    return;
                }

                if (NewCraftsName.Text != "上料")
                {
                    ClsMsg.ShowErrMsg("当前鼓号设备工艺状态异常，不处于可上料状态，无法上料，请先扫描正确的鼓号");
                    return;
                }

                string Flag_ID = RFIDCodeTextEdit.Text.Substring(0, 2);
                //   string a=  RFIDCodeTextEdit.EditValue.ToString();
                if (Flag_ID != "ID")
                {
                    if (!BgWait.IsBusy)
                        BgWait.RunWorkerAsync("SearchRFID");
                }
            }


            if (RFIDCodeTextEdit.Text.Length == 13)
            {
                string Flag_ID = RFIDCodeTextEdit.Text.Substring(0, 2);

                RFIDCodeTextEdit.EditValue = RFIDCodeTextEdit.Text.Substring(3, 10);

                RFIDCodeTextEdit.Refresh();

                if (Flag_ID == "ID")
                {
                    if (!BgWait.IsBusy)
                        BgWait.RunWorkerAsync("SearchRFID");
                }
            }



        }

        private void SuBmitBtn_Click(object sender, EventArgs e)
        {

            using (var MESclient = new SRCfPExecute.CfPExecuteServiceClient())
            {
                var ret = MESclient.GetDurmsUpFeedingByDevCode(context.SessionID, WorkbrachNameTextEdit.Text);
                vw_DurmsUpFeedingModel.CreateTime = DateTime.Now;
                if (ret.Data[0].DevName != vw_DurmsUpFeedingModel.DevName)
                {
                    ClsMsg.ShowErrMsg("该转鼓跟二维码编码不一致，请重新扫描转鼓号码！");
                    return;
                }

                if (ret.Data != null)
                {
                    DeveUseStatusSpinEdit.EditValue = ret.Data[0].DeveUseStatus.ToString();

                }
                else
                {
                    ClsMsg.ShowErrMsg("无该设备状态数据，请跟管理员沟通");
                }

                var Proret = MESclient.GeCraftsProcessdByWorkbrachName(context.SessionID, WorkbrachNameTextEdit.Text);



                if (Proret.Data.ExecuteOrder != vw_DurmsUpFeedingModel.ExecuteOrder || Proret.Data.ExecuteStatus != vw_DurmsUpFeedingModel.ExecuteStatus)
                {
                    vw_DurmsUpFeedingModel.WorkbrachCode = "";
                    vw_DurmsUpFeedingModel.DevName = "";
                    ClsMsg.ShowErrMsg("该转鼓在同一时间被进行了操作，请重新扫描转鼓号码！");
                    return;

                }
            }
            if (WorkbrachNameTextEdit.Text == "")
            {
                ClsMsg.ShowErrMsg("当前二维码为空，请扫描正确的鼓号！");
                return;
            }

            if (FrequencyEdit.Text == "")
            {
                ClsMsg.ShowErrMsg("当前没有选择班次，请先选择班次！");
                return;
            }
            if (CraftsNameTextEdit.Text != "空鼓" && CraftsNameTextEdit.Text != "上料")
            {
                ClsMsg.ShowErrMsg("当前鼓号工艺状态异常，请扫描正确的鼓号,或者完成刷卡操作！");
                return;
            }

            if (OperatDescEdit.Text != "" && WorkbrachNameTextEdit.Text != "" && CraftsNameTextEdit.Text == "空鼓" && DeveUseStatusSpinEdit.Text == "正常" && ClsMsg.ShowQuestionMsg("是否要保存空鼓上料信息呢？") == DialogResult.Yes)
            {
                BgWait.RunWorkerAsync("InsterArrangedVouchCode");
            }
            else if (OperatDescEdit.Text != "" && RFIDCodeTextEdit.Text != "" && CraftsNameTextEdit.Text == "上料" && DeveUseStatusSpinEdit.Text == "正常" && ClsMsg.ShowQuestionMsg("是否要保存原料绑卡信息呢？") == DialogResult.Yes)
            {
                BgWait.RunWorkerAsync("UpdateArrangedVouchCode");
            }

            else if (RFIDCodeTextEdit.Text == "" && CraftsNameTextEdit.Text != "空鼓" && CraftsNameTextEdit.Text != "上料")
            {
                ClsMsg.ShowErrMsg("当前鼓号工艺状态异常，请扫描正确的鼓号,或者完成刷卡操作！");
                return;

            }

            else if (RFIDCodeTextEdit.Text == "" && CraftsNameTextEdit.Text == "上料")
            {
                ClsMsg.ShowErrMsg("当前工艺为刷卡绑定操作，请正确刷卡！");
                return;

            }
            else if (DeveUseStatusSpinEdit.Text != "正常")
            {
                ClsMsg.ShowErrMsg("当前鼓号设备状态异常，请扫描正确的鼓号！");
                return;
            }
            else if (OperatDescEdit.Text == "")
            {

                ClsMsg.ShowErrMsg("当前鼓号信息异常，操作项目为空，请扫描正确卡号！");
                return;
            }
        }



        private void BgWait_DoWork(object sender, DoWorkEventArgs e)
        {
            BgWait.ReportProgress(PubConstant.WaitMessageStatus.START);
            try
            {
                switch (e.Argument.ToString())
                {

                    case "SearchRFID":

                        using (var QZclient = new SRQZData.QZDataServiceClient())
                        {
                            var ret = QZclient.GetQZRFIDCodeData(context.SessionID, RFIDCodeTextEdit.Text);
                            var Newret = QZclient.GetNewQZRFIDCodeData(context.SessionID, RFIDCodeTextEdit.Text);
                            if (Newret != null && Newret.Rows.Count > 0)
                            {
                                //该位置应存储过磅单号，RFID卡号，配方编号，配方名称，合计重量

                                //vw_DurmsUpFeedingModel.RFIDCode = ret.Rows[0][0].ToString();
                                //vw_DurmsUpFeedingModel.FormulaName = ret.Rows[0][9].ToString();
                                //vw_DurmsUpFeedingModel.MaterialVouchCode = ret.Rows[0][10].ToString();

                                //vw_DurmsUpFeedingModel.InputWeight = Decimal.Parse(ret.Rows[0][2].ToString());


                                NewCraftsName.Text = "上料";
                                vw_DurmsUpFeedingModel.RFIDCode = Newret.Rows[0]["RFID卡号"].ToString();
                                vw_DurmsUpFeedingModel.FormulaName = Newret.Rows[0]["配方名称"].ToString();

                                vw_DurmsUpFeedingModel.ProPlanNum = Newret.Rows[0]["参数表编码"].ToString();

                                vw_DurmsUpFeedingModel.MaterialVouchCode = Newret.Rows[0]["过磅单号"].ToString();
                                vw_DurmsUpFeedingModel.FormulaCode = Newret.Rows[0]["配方单号"].ToString();

                                vw_DurmsUpFeedingModel.InputWeight = Decimal.Parse(Newret.Rows[0]["每鼓合计重量"].ToString());


                            }
                            else
                            {
                                ClsMsg.ShowErrMsg("没有该卡号信息，请重新刷卡");
                                BgWait.ReportProgress(PubConstant.WaitMessageStatus.END);
                                return;
                            }

                        }


                        using (var MESclient = new SRCfPExecute.CfPExecuteServiceClient())
                        {
                            //    GetCfPExecuteByArrangedVouchCode        WorkbrachName
                            var ArrRet = MESclient.GetCfPExecuteByArrangedVouchCode(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode);

                            vw_DurmsUpFeedingModel.WorkbrachCode = ArrRet.Data.WorkbrachCode;
                            vw_DurmsUpFeedingModel.ExecuteOrder = ArrRet.Data.ExecuteOrder;
                            vw_DurmsUpFeedingModel.ExecuteStatus = ArrRet.Data.ExecuteStatus;//暂定用于判断保存时数据是否被后台或同一时间进行了修正
                            vw_DurmsUpFeedingModel.CraftsName = ArrRet.Data.CraftsName;
                            vw_DurmsUpFeedingModel.CraftsCode = ArrRet.Data.CraftsCode;
                            vw_DurmsUpFeedingModel.ArrangedVouchCode = ArrRet.Data.ArrangedVouchCode;

                            if (vw_DurmsUpFeedingModel.CraftsName != "上料" && vw_DurmsUpFeedingModel.CraftsName != "空鼓")
                            {
                                ClsMsg.ShowErrMsg("本转鼓不处于空鼓或上料开始阶段，无法使用保存功能");
                                vw_DurmsUpFeedingModel.WorkbrachCode = "";
                                RFIDCodeTextEdit.Properties.ReadOnly = true;
                            }
                            else if (vw_DurmsUpFeedingModel.CraftsName == "空鼓")
                            {
                                vw_DurmsUpFeedingModel.ArrangedVouchCode = "";
                                OperatDescEdit.Text = "上料开始";
                                NewCraftsName.Text = "上料";
                                RFIDCodeTextEdit.Properties.ReadOnly = true;
                            }

                            else if (vw_DurmsUpFeedingModel.CraftsName == "上料" && ArrRet.Data.ExecuteStatus != 2)
                            {
                                vw_DurmsUpFeedingModel.ArrangedVouchCode = ArrRet.Data.ArrangedVouchCode;
                                OperatDescEdit.Text = "原料扫卡绑定";
                                NewCraftsName.Text = "上料";
                                RFIDCodeTextEdit.Properties.ReadOnly = false;
                            }

                            else
                            {
                                ClsMsg.ShowErrMsg("本转鼓不处于空鼓或上料开始阶段，无法使用保存功能");
                                vw_DurmsUpFeedingModel.WorkbrachCode = "";
                                RFIDCodeTextEdit.Properties.ReadOnly = true;
                            }


                        }

                        using (var MESclient = new SRCfPExecute.CfPExecuteServiceClient())
                        {
                            var ret = MESclient.GetArrangedVouchLogByCode(context.SessionID, ArrangedVouchCodeTextEdit.Text);
                            if (ret.Data != null)
                            {
                                e.Result = ret.Data;
                            }
                            else
                                BgWait.ReportProgress(PubConstant.WaitMessageStatus.WARNING, ret.Message);
                        }
                        break;

                    case "SearchDevStatus":
                        using (var MESclient = new SRCfPExecute.CfPExecuteServiceClient())
                        {

                            var ret = MESclient.GetDurmsUpFeedingByDevCode(context.SessionID, WorkbrachNameTextEdit.Text);
                            if (ret.Data != null)
                            {

                                DeveUseStatusSpinEdit.EditValue = ret.Data[0].DeveUseStatus.ToString();
                                vw_DurmsUpFeedingModel.DevName = ret.Data[0].DevName;

                                vw_DurmsUpFeedingModel.WorkbrachName = ret.Data[0].DevName;

                                vw_DurmsUpFeedingModel.WorkbrachCode = ret.Data[0].DevCode;
                            }
                            else
                            {
                                ClsMsg.ShowErrMsg("无该设备状态数据，请跟管理员沟通");
                            }

                            //vw_DurmsUpFeedingModel.WorkbrachName = ret.Data[0].DevCode;


                            var Proret = MESclient.GeCraftsProcessdByWorkbrachName(context.SessionID, WorkbrachNameTextEdit.Text);
                            //  vw_DurmsUpFeedingModel.WorkbrachName = Proret.Data.WorkbrachName;
                            vw_DurmsUpFeedingModel.ExecuteOrder = Proret.Data.ExecuteOrder;

                            vw_DurmsUpFeedingModel.ExecuteStatus = Proret.Data.ExecuteStatus; //暂定用于判断保存时数据是否被后台或同一时间进行了修正

                            vw_DurmsUpFeedingModel.CraftsName = Proret.Data.CraftsName;
                            vw_DurmsUpFeedingModel.RFIDCode = "";
                            vw_DurmsUpFeedingModel.FormulaName = "";
                            vw_DurmsUpFeedingModel.InputWeight = null;


                            if (vw_DurmsUpFeedingModel.CraftsName != "上料" && vw_DurmsUpFeedingModel.CraftsName != "空鼓")
                            {
                                ClsMsg.ShowErrMsg("本转鼓不处于空鼓或上料开始阶段，无法使用保存功能");
                                vw_DurmsUpFeedingModel.WorkbrachCode = "";
                                RFIDCodeTextEdit.Properties.ReadOnly = true;
                            }
                            else if (vw_DurmsUpFeedingModel.CraftsName == "空鼓")
                            {
                                vw_DurmsUpFeedingModel.ArrangedVouchCode = "";
                                OperatDescEdit.Text = "上料开始";
                                NewCraftsName.Text = "上料";
                                RFIDCodeTextEdit.Properties.ReadOnly = true;
                            }

                            else if (vw_DurmsUpFeedingModel.CraftsName == "上料" && Proret.Data.ExecuteStatus != 2)
                            {
                                vw_DurmsUpFeedingModel.ArrangedVouchCode = Proret.Data.ArrangedVouchCode;
                                //   OperatDescEdit.Text = "原料扫卡绑定";
                                NewCraftsName.Text = "上料";
                                RFIDCodeTextEdit.Properties.ReadOnly = false;
                            }

                            else
                            {
                                ClsMsg.ShowErrMsg("本转鼓不处于空鼓或上料开始阶段，无法使用保存功能");
                                vw_DurmsUpFeedingModel.WorkbrachCode = "";
                                RFIDCodeTextEdit.Properties.ReadOnly = true;
                            }



                            using (var MESclientLog = new SRCfPExecute.CfPExecuteServiceClient())
                            {
                                var retLog = MESclientLog.GetArrangedVouchLogByCode(context.SessionID, ArrangedVouchCodeTextEdit.Text);

                                if (retLog.Data != null)
                                {

                                    e.Result = retLog.Data;
                                }
                                else
                                    BgWait.ReportProgress(PubConstant.WaitMessageStatus.WARNING, retLog.Message);
                            }
                        }
                        vw_DurmsUpFeedingModel.CreateTime = DateTime.Now;
                        break;

                    case "SearchArrangedVouchLogCode":

                        using (var MESclient = new SRCfPExecute.CfPExecuteServiceClient())
                        {
                            var ret = MESclient.GetArrangedVouchLogByCode(context.SessionID, ArrangedVouchCodeTextEdit.Text);
                            if (ret.Data != null)
                            {
                                e.Result = ret.Data;
                            }
                            else
                                BgWait.ReportProgress(PubConstant.WaitMessageStatus.WARNING, ret.Message);
                        }
                        break;

                    case "InsterArrangedVouchCode":


                        using (var MESclient = new SRCfPExecute.CfPExecuteServiceClient())
                        {
                            var ret = MESclient.InsterArrVouchByVw(context.SessionID, vw_DurmsUpFeedingModel); //保存排配单数据
                            if (ret.IsSuccess)
                            {
                                var logModel = new SRCfPExecute.ArrangedVouchLog()
                                {
                                    ArrangedVouchCode = ret.Data.ArrangedVouchCode,
                                    OperatingTime = vw_DurmsUpFeedingModel.CreateTime,
                                    OperatDesc = OperatDescEdit.Text,
                                    Operator = OperatorEdit.Text,
                                    Frequency = FrequencyEdit.Text,
                                    CraftsName = CraftsNameTextEdit.Text,
                                };

                                vw_DurmsUpFeedingModel.ArrangedVouchCode = ret.Data.ArrangedVouchCode;

                                MESclient.InsterArrVouchLog(context.SessionID, logModel);  //保存操作日志数据
                                BgWait.ReportProgress(99, "保存成功！");
                                vw_DurmsUpFeedingModel.WorkbrachCode = "";
                                OperatDescEdit.Text = "";
                                RFIDCodeTextEdit.Properties.ReadOnly = false;
                                vw_DurmsUpFeedingModel.CreateTime = DateTime.Now;
                                vw_DurmsUpFeedingModel.Creator = context.UserName;

                                using (var MESclientLog = new SRCfPExecute.CfPExecuteServiceClient())
                                {
                                    var retLog = MESclientLog.GetArrangedVouchLogByCode(context.SessionID, ArrangedVouchCodeTextEdit.Text);
                                    if (retLog.Data != null)
                                    {
                                        e.Result = retLog.Data;
                                    }
                                    else
                                        BgWait.ReportProgress(PubConstant.WaitMessageStatus.WARNING, retLog.Message);
                                }


                            }


                        }
                        break;

                    case "InsterCraProDataById":

                        using (var MESclient = new SRCfPExecute.CfPExecuteServiceClient())
                        {
                            var ret = MESclient.UpdateCraftsProcessData(context.SessionID, "CSGH17011", vw_DurmsUpFeedingModel); //保存排配单数据 
                            if (ret.IsSuccess)
                            {
                                BgWait.ReportProgress(99, "保存成功！");
                            }
                            else
                                BgWait.ReportProgress(PubConstant.WaitMessageStatus.WARNING, ret.Message);
                        }
                        break;


                    case "UpdateArrangedVouchCode":
                        using (var MESclient = new SRCfPExecute.CfPExecuteServiceClient())
                        {
                            var ret = MESclient.UpdateArrangedVouchCode(context.SessionID, vw_DurmsUpFeedingModel); //保存排配单数据



                            var retTail = MESclient.UpdateCraftsProcessData(context.SessionID, vw_DurmsUpFeedingModel.ProPlanNum, vw_DurmsUpFeedingModel); //修改执行子表跟主表数据 


                            var TestRet = MESclient.UpdateCraftsProcessExecute(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode, 1, 2);


                            if (ret.IsSuccess)
                            {
                                var logModel = new SRCfPExecute.ArrangedVouchLog()
                                {
                                    ArrangedVouchCode = ret.Data.ArrangedVouchCode,
                                    OperatingTime = vw_DurmsUpFeedingModel.CreateTime,
                                    OperatDesc = OperatDescEdit.Text,
                                    Operator = OperatorEdit.Text,
                                    Frequency = FrequencyEdit.Text,
                                    CraftsName = CraftsNameTextEdit.Text,
                                };

                                MESclient.InsterArrVouchLog(context.SessionID, logModel);  //保存操作日志数据
                                BgWait.ReportProgress(99, "保存成功！");
                                vw_DurmsUpFeedingModel.WorkbrachCode = "";
                                OperatDescEdit.Text = "";
                                RFIDCodeTextEdit.Properties.ReadOnly = true;
                                vw_DurmsUpFeedingModel.CreateTime = DateTime.Now;
                                vw_DurmsUpFeedingModel.Creator = context.UserName;
                                using (var MESclientLog = new SRCfPExecute.CfPExecuteServiceClient())
                                {
                                    var retLog = MESclientLog.GetArrangedVouchLogByCode(context.SessionID, ArrangedVouchCodeTextEdit.Text);

                                    if (retLog.Data != null)
                                    {
                                        e.Result = retLog.Data;
                                    }
                                    else
                                        BgWait.ReportProgress(PubConstant.WaitMessageStatus.WARNING, retLog.Message);
                                }
                            }
                        }
                        break;


                    default:
                        break;
                }
            }


            catch (Exception ex)
            {
                BgWait.ReportProgress(PubConstant.WaitMessageStatus.ERROR, ex.Message);
            }

            BgWait.ReportProgress(PubConstant.WaitMessageStatus.END);

        }

        private void BgWait_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                if (e.Result is SRCfPExecute.ArrangedVouchLog[])
                {
                    gridControl1.RefreshDataSource();
                    arrangedVouchLogBindingSource.DataSource = (e.Result as SRCfPExecute.ArrangedVouchLog[]);

                }
            }
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            //if (ClsMsg.ShowQuestionMsg("是否要测试工艺规划明细数据？") == DialogResult.Yes)
            //{
            //    BgWait.RunWorkerAsync("InsterCraProDataById");
            //}

            if (ClsMsg.ShowQuestionMsg("是否要清除该界面所有信息呢？") == DialogResult.Yes)
            {
                vw_DurmsUpFeedingModel = new SRCfPExecute.vw_DurmsUpFeeding();
                vwDurmsUpFeedingBindingSource.DataSource = vw_DurmsUpFeedingModel;
                DeveUseStatusSpinEdit.Text = "";
                DeveUseStatusSpinEdit.EditValue = null;
                OperatDescEdit.Text = "";
                NewCraftsName.Text = "";
                FrequencyEdit.Text = "";
                vw_DurmsUpFeedingModel.CreateTime = DateTime.Now;
                vw_DurmsUpFeedingModel.Creator = context.UserName;


                gridControl1.RefreshDataSource();
                arrangedVouchLogBindingSource.DataSource = null;

            }

        }

        private void InsterData()
        {
            vw_DurmsUpFeedingModel = new SRCfPExecute.vw_DurmsUpFeeding() { DeveUseStatus = 1 };
            vwDurmsUpFeedingBindingSource.DataSource = vw_DurmsUpFeedingModel;
            vw_DurmsUpFeedingModel.CreateTime = DateTime.Now;
            vw_DurmsUpFeedingModel.Creator = context.UserName;
            vw_DurmsUpFeedingModel.VouchDate = DateTime.Today.Date;
            RFIDCodeTextEdit.Properties.ReadOnly = true;
        }


        private void RFIDCodeTextEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue.Equals(e.OldValue))
                e.Cancel = true;
        }

        private void WorkbrachNameTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (WorkbrachNameTextEdit.Text.Length == 6 && !BgWait.IsBusy)
                BgWait.RunWorkerAsync("SearchDevStatus");
        }

        private void WorkbrachNameTextEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SuBmitBtn.PerformClick();
            }
        }

   

    }
}
