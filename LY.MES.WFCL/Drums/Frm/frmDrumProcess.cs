using Client.Utility;
using Client.Utility.Caching;
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

namespace LY.MES.WFCL.Drums.Frm
{
    public partial class frmDrumProcess : BaseForm
    {
        private static ICacheManager cache = new RedisCacheManager("CacheFileServer");
        private SRCfPExecute.vw_DurmsUpFeeding vw_DurmsUpFeedingModel = null;
        // private string[] StrArray = new string[] { "正常", "维修中", "停用", "报废" };


        public frmDrumProcess(UserContext context)
            : base(context)
        {
            InitializeComponent();
            BgWait.ProgressChanged += this.backgroundWorker_ProgressChanged;
            WeightTimer.Enabled = false;

            DeveUseStatusSpinEdit.Properties.DataSource = Client.Utility.DataEnum.GetEnumData("devstatus");

        }

        private void ScanCodeBtn_Click(object sender, EventArgs e)
        {
            var result = Client.Utility.BarCode.frmScannCode1.Instance();
            WorkbrachNameTextEdit.Text = result;
            WorkbrachNameTextEdit.Refresh();
        }

        private void WorkbrachNameTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (WorkbrachNameTextEdit.Text.Length == 6)
            {


                string CheckCode = WorkbrachNameTextEdit.Text.Substring(0, 2);
                if (CheckCode == "ZG" && !BgWait.IsBusy)
                {
                    //   ClearData();
                    vw_DurmsUpFeedingModel.WorkbrachCode = WorkbrachNameTextEdit.Text;
                    vwDurmsUpFeedingBindingSource.EndEdit();
                    vw_DurmsUpFeedingModel.LicenseNum = "";
                    vw_DurmsUpFeedingModel.VehicleWeight = 0;
                    vw_DurmsUpFeedingModel.WeightMan = 0;
                    OperatDescEdit.Text = "";


                    if (!BgWait.IsBusy)
                        BgWait.RunWorkerAsync("SearchDevStatus");
                }


                if (CheckCode == "CH")
                {

                    //   vwDurmsUpFeedingBindingSource.EndEdit();  string CheckCode = WorkbrachNameTextEdit.Text.Substring(0, 2);CheckCode == "ZG" && CheckCode == "CH"
                    string NewWoekName = WorkbrachNameTextEdit.Text;
                    using (var MESclient = new SRCfPExecute.CfPExecuteServiceClient())
                    {
                        var NewCraSet = MESclient.GetCfPExecuteByArrangedVouchCode(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode);
                        if (NewCraSet.Data == null)
                        {

                            SearchNumCH();
                            return;

                        }
                        vw_DurmsUpFeedingModel.ExecuteOrder = NewCraSet.Data.ExecuteOrder;
                        vw_DurmsUpFeedingModel.ExecuteStatus = NewCraSet.Data.ExecuteStatus;
                        vw_DurmsUpFeedingModel.WorkbrachCode = NewWoekName;


                        if (CheckCode == "CH" && NewCraSet.Data.ExecuteOrder == 7 && NewCraSet.Data.ExecuteStatus == 2)
                        {
                            var DevStatus = MESclient.GetDevStatusByCode(context.SessionID, WorkbrachNameTextEdit.Text);

                            if (DevStatus.Data.WorkingStatus == 1)
                            {
                                ClsMsg.ShowErrMsg("该车号已被占用，请将该车号卸料完毕");
                                return;
                            }
                            else if (DevStatus.Data.WorkingStatus == 0)
                            {
                                vw_DurmsUpFeedingModel.LicenseNum = WorkbrachNameTextEdit.Text;
                                SearchNumCHWinthArr();
                            }
                            else
                            {
                                ClsMsg.ShowErrMsg("设备状态异常，请跟管理员沟通，请将该车号卸料完毕");
                                return;
                            }
                        }

                        else
                        {
                            SearchNumCH();
                        }



                    }
                }



            }
            //BgWait.RunWorkerAsync("SearchArrangedVouchCode");
        }

        private void BgWait_DoWork(object sender, DoWorkEventArgs e)
        {
            BgWait.ReportProgress(PubConstant.WaitMessageStatus.START);
            try
            {
                switch (e.Argument.ToString())
                {

                    case "SearchDevStatus":
                        using (var MESclient = new SRCfPExecute.CfPExecuteServiceClient())
                        {

                            var ret = MESclient.GetDurmsUpFeedingByDevCode(context.SessionID, vw_DurmsUpFeedingModel.WorkbrachCode);
                            // vw_DurmsUpFeedingModel.DeveUseStatus = ret.Data[0].DeveUseStatus;
                            if (ret.Data != null)
                            {
                                //if (ret.Data[0].DeveUseStatus == 0)
                                //{
                                //    DeveUseStatusSpinEdit.Text = "正常";
                                //}
                                //else
                                //{
                                //    DeveUseStatusSpinEdit.Text = "报修";
                                //}
                                DeveUseStatusSpinEdit.EditValue = ret.Data[0].DeveUseStatus.ToString();

                            }
                            else
                            {
                                ClsMsg.ShowErrMsg("无该设备数据，请跟管理员沟通");
                            }

                            var Proret = MESclient.Getvw_DurmsUpFeedingByWorkbrachName(context.SessionID, vw_DurmsUpFeedingModel.WorkbrachCode);
                            if (Proret.Data != null)
                            {
                                vw_DurmsUpFeedingModel.WorkbrachCode = Proret.Data.WorkbrachCode;
                                vw_DurmsUpFeedingModel.WorkbrachName = Proret.Data.WorkbrachName;

                                vw_DurmsUpFeedingModel.ExecuteOrder = Proret.Data.ExecuteOrder;
                                vw_DurmsUpFeedingModel.ExecuteStatus = Proret.Data.ExecuteStatus;

                                vw_DurmsUpFeedingModel.CraftsName = Proret.Data.CraftsName;
                                vw_DurmsUpFeedingModel.ArrangedVouchCode = Proret.Data.ArrangedVouchCode;
                                vw_DurmsUpFeedingModel.FormulaName = Proret.Data.FormulaName;
                                vw_DurmsUpFeedingModel.InputWeight = Proret.Data.InputWeight;
                                vw_DurmsUpFeedingModel.WorkbrachName = Proret.Data.DevName;
                            }
                            else
                            {
                                BgWait.ReportProgress(PubConstant.WaitMessageStatus.WARNING, "无该转鼓数据，请跟管理员沟通");

                                break;
                            }


                            var CraSet = MESclient.GetDurmsUpFeedingByArrCode(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode);
                            if (CraSet.Data == null)
                            {
                                ClsMsg.ShowErrMsg("无该标准工艺数据，请跟管理员沟通");
                                break;
                            }


                            switch (Proret.Data.ExecuteOrder)
                            {
                                case 1:

                                    if (Proret.Data.ExecuteStatus == 2)
                                    {
                                        NewCraftsName.Text = CraSet.Data[2].CraftsName;

                                        OperatDescEdit.Text = "高温排水开始";
                                    }
                                    else
                                    {
                                        ClsMsg.ShowErrMsg("上料过程中，未进行原料绑卡操作");
                                        ClearData();
                                    }

                                    break;

                                case 2:
                                    if (Proret.Data.ExecuteStatus == 2)
                                    {
                                        NewCraftsName.Text = CraSet.Data[2].CraftsName;
                                        OperatDescEdit.Text = "高温排水开始";
                                    }
                                    else
                                    {
                                        ClsMsg.ShowErrMsg("检漏过程中，未完成检漏报告操作");
                                        ClearData();
                                    }
                                    break;

                                case 3:
                                    //-----------------高温排水手动结束暂停，采用自动-------------//
                                    //if (Proret.Data.ExecuteStatus == 1)
                                    //{
                                    //    //高温排水结束

                                    //    using (var Prarmclient = new SRCfPExecute.CfPExecuteServiceClient())
                                    //    {
                                    //        var prarm = MESclient.GetArrCuteByArrCode(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode, 3);
                                    //        if (prarm.Data == true)
                                    //        {
                                    //            NewCraftsName.Text = CraSet.Data[3].CraftsName;
                                    //            OperatDescEdit.Text = "自然排水开始";
                                    //        }
                                    //        else
                                    //        {
                                    //            ClsMsg.ShowErrMsg("高温排水未结束，无法进行自然排水开始动作");
                                    //            ClearData();
                                    //        }
                                    //    }

                                    //}
                                    //else
                                    //{
                                    //    ClsMsg.ShowErrMsg("自然排水过程中，出现异常操作");
                                    //    ClearData();
                                    //}
                                    //-----------------高温排水手动结束暂停，采用自动-------------//

                                    ClsMsg.ShowErrMsg("高温排水未结束，无法进行手动操作");
                                    vw_DurmsUpFeedingModel.WorkbrachCode = "";
                                    ClearData();

                                    break;

                                case 4:
                                    //-----------------自然排水手动结束暂停，采用自动-------------//

                                    //if (Proret.Data.ExecuteStatus == 1)
                                    //{
                                    //    //自然排水结束

                                    //    using (var Prarmclient = new SRCfPExecute.CfPExecuteServiceClient())
                                    //    {
                                    //        var prarm = MESclient.GetArrCuteByArrCode(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode, 4);
                                    //        if (prarm.Data == true)
                                    //        {
                                    //            NewCraftsName.Text = CraSet.Data[3].CraftsName;
                                    //            OperatDescEdit.Text = "烘料即将开始";
                                    //        }
                                    //        else
                                    //        {
                                    //            ClsMsg.ShowErrMsg("自然排水未结束，无法进行自然排水开始动作");
                                    //            ClearData();
                                    //        }
                                    //    }


                                    //}
                                    ////增加手工烘料跟充氮功能，20160103XCQ 
                                    ////删除手工烘料跟充氮功能，20170214XCQ
                                    //if (Proret.Data.ExecuteStatus == 2)
                                    //{
                                    //    ClsMsg.ShowErrMsg("排水阶段未完成，请等待系统自动完成");
                                    //    vw_DurmsUpFeedingModel.WorkbrachCode = "";
                                    //    ClearData();

                                    //    //NewCraftsName.Text = CraSet.Data[4].CraftsName;
                                    //    //OperatDescEdit.Text = "烘料结束";

                                    //}
                                    //-----------------自然排水手动结束暂停，采用自动-------------//
                                    ClsMsg.ShowErrMsg("自然排水未结束，无法进行手动操作");
                                    vw_DurmsUpFeedingModel.WorkbrachCode = "";
                                    ClearData();
                                    break;

                                case 5:
                                    if (Proret.Data.ExecuteStatus == 1)
                                    {

                                        //删除手工烘料跟充氮功能，20170214XCQ

                                        ClsMsg.ShowErrMsg("烘料阶段未完成，请等待系统自动完成");
                                        vw_DurmsUpFeedingModel.WorkbrachCode = "";
                                        ClearData();

                                        //NewCraftsName.Text = CraSet.Data[5].CraftsName;
                                        //OperatDescEdit.Text = "充氮开始";

                                    }
                                    if (Proret.Data.ExecuteStatus == 2)
                                    {
                                        //NewCraftsName.Text = CraSet.Data[5].CraftsName;
                                        //OperatDescEdit.Text = "充氮开始";
                                        ClsMsg.ShowErrMsg("烘料阶段未完成，请等待系统自动完成");
                                        vw_DurmsUpFeedingModel.WorkbrachCode = "";
                                        ClearData();

                                    }
                                    break;

                                case 6:
                                    if (Proret.Data.ExecuteStatus == 1)
                                    {
                                        //NewCraftsName.Text = CraSet.Data[5].CraftsName;
                                        //ClsMsg.ShowErrMsg("充氮阶段未完成，请等待系统自动完成");
                                        //vw_DurmsUpFeedingModel.WorkbrachCode = "";
                                        //ClearData();

                                        NewCraftsName.Text = CraSet.Data[6].CraftsName;
                                        OperatDescEdit.Text = "充氮完成";

                                    }
                                    else if (Proret.Data.ExecuteStatus == 2)
                                    {
                                        //NewCraftsName.Text = CraSet.Data[6].CraftsName;
                                        //OperatDescEdit.Text = "放料开始";

                                        ClsMsg.ShowErrMsg("充氮阶段完成，放料未开始，请跟管理员沟通");
                                        vw_DurmsUpFeedingModel.WorkbrachCode = "";
                                        ClearData();

                                    }
                                    else
                                    {
                                        ClsMsg.ShowErrMsg("241工艺阶段异常，请跟管理员沟通");
                                        vw_DurmsUpFeedingModel.WorkbrachCode = "";
                                        ClearData();
                                    }
                                    break;

                                case 7:

                                    if (Proret.Data.ExecuteStatus == 1)
                                    {
                                        NewCraftsName.Text = CraSet.Data[6].CraftsName;
                                        OperatDescEdit.Text = "放料";
                                    }


                                    else if (Proret.Data.ExecuteStatus == 2)
                                    {
                                        NewCraftsName.Text = CraSet.Data[7].CraftsName;
                                        //   OperatDescEdit.Text = "装车";
                                        //      ClsMsg.ShowErrMsg("即将装车，请扫车号二维码");
                                    }

                                    else
                                    {
                                        ClsMsg.ShowErrMsg("265工艺阶段异常，请跟管理员沟通");
                                        vw_DurmsUpFeedingModel.WorkbrachCode = "";
                                        ClearData();
                                    }


                                    break;

                                case 8:

                                    if (Proret.Data.ExecuteStatus == 1)
                                    {
                                        ClsMsg.ShowErrMsg("277工艺阶段异常，请跟管理员沟通");
                                        vw_DurmsUpFeedingModel.WorkbrachCode = "";
                                        ClearData();

                                        //NewCraftsName.Text = CraSet.Data[6].CraftsName;
                                        //OperatDescEdit.Text = "过磅";
                                    }


                                    else if (Proret.Data.ExecuteStatus == 98)
                                    {
                                        ClsMsg.ShowErrMsg("288工艺阶段异常，请跟管理员沟通");
                                        vw_DurmsUpFeedingModel.WorkbrachCode = "";
                                        ClearData();

                                        //NewCraftsName.Text = CraSet.Data[7].CraftsName;
                                        //OperatDescEdit.Text = "卸料";
                                    }

                                    else
                                    {
                                        ClsMsg.ShowErrMsg("298工艺阶段异常，当前转鼓未进行原料上料绑卡操作，尚处于空鼓状态，无法进行转鼓工艺流转，请跟管理员沟通");
                                        vw_DurmsUpFeedingModel.WorkbrachCode = "";
                                        ClearData();
                                    }


                                    break;

                            }

                            RefreshControl(e);

                        }

                        vw_DurmsUpFeedingModel.CreateTime = DateTime.Now;

                        break;

                    case "UpdateCraftsProcessExecute":

                        //  UpdateCraftsProcess(vw_DurmsUpFeedingModel.ArrangedVouchCode,2,1);
                        UpdateCraftsProcess();

                        RefreshControl(e);

                        vw_DurmsUpFeedingModel.WorkbrachCode = "";
                        OperatDescEdit.Text = "";
                        //     ClearData();
                        break;


                    case "SearchNumCH":

                        SearchNumCH();
                        RefreshControl(e);


                        vw_DurmsUpFeedingModel.CreateTime = DateTime.Now;


                        break;

                    case "GetPerWeight":

                        using (var MESclient = new SRCfPExecute.CfPExecuteServiceClient())
                        {
                            var PersonData = MESclient.GetPersonByPerCode(context.SessionID, context.UserCode);
                            if (PersonData.Data != null)
                            {
                                this.Invoke((MethodInvoker)delegate()
                                {
                                    vw_DurmsUpFeedingModel.WeightMan = PersonData.Data != null ? Convert.ToDouble(PersonData.Data.Weight) : 0;
                                });
                            }
                            else
                            {
                                ClsMsg.ShowErrMsg("无该人员体重基础信息，请在人员体重基础表中增加");
                            }


                        }

                        using (SRDevice.DeviceServiceClient client = new SRDevice.DeviceServiceClient())
                        {
                            var CHWeight = client.GetDeviceByCode(context.SessionID, vw_DurmsUpFeedingModel.LicenseNum);
                            vw_DurmsUpFeedingModel.VehicleWeight = Convert.ToDouble(CHWeight.Data.Weight);
                        }
                        e.Result = true;
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
        /// <summary>
        /// 根据车号获取一系列排配单号，转鼓号，配方强度等信息，专用于操作项目为过磅以及卸料时，不可用于装车时
        /// </summary>
        private void SearchNumCH()
        {
            using (var MESclient = new SRCfPExecute.CfPExecuteServiceClient())
            {

                var ret = MESclient.Getvw_DurmsUpFeedingByLnum(context.SessionID, WorkbrachNameTextEdit.Text);
                if (ret.Data == null)
                {
                    ClsMsg.ShowErrMsg("无该车号的数据");
                    //   ClearData();
                    return;
                }

                DeveUseStatusSpinEdit.EditValue = ret.Data.DeveUseStatus.ToString();
                //if (ret.Data.DeveUseStatus == 0)
                //{
                //    DeveUseStatusSpinEdit.Text = "正常";
                //}
                //else
                //{
                //    DeveUseStatusSpinEdit.Text = "报修";
                //}

                vw_DurmsUpFeedingModel.ArrangedVouchCode = ret.Data.ArrangedVouchCode;
                vw_DurmsUpFeedingModel.LicenseNum = ret.Data.LicenseNum;
                vw_DurmsUpFeedingModel.FormulaName = ret.Data.FormulaName;
                vw_DurmsUpFeedingModel.InputWeight = ret.Data.InputWeight;
                vw_DurmsUpFeedingModel.WorkbrachCode = ret.Data.LicenseNum;

                vw_DurmsUpFeedingModel.WeighingPounds = ret.Data.WeighingPounds;
                vw_DurmsUpFeedingModel.VehicleWeight = ret.Data.VehicleWeight;
                vw_DurmsUpFeedingModel.WeightMan = ret.Data.WeightMan;

                var NewCraSet = MESclient.GetCfPExecuteByArrangedVouchCode(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode);
                if (NewCraSet.Data != null)
                {
                    vw_DurmsUpFeedingModel.ExecuteOrder = NewCraSet.Data.ExecuteOrder;
                    vw_DurmsUpFeedingModel.CraftsName = NewCraSet.Data.CraftsName;
                    vw_DurmsUpFeedingModel.ArrangedVouchCode = NewCraSet.Data.ArrangedVouchCode;
                    vw_DurmsUpFeedingModel.ExecuteStatus = NewCraSet.Data.ExecuteStatus;
                }
                else
                {
                    ClsMsg.ShowErrMsg("无该标准工艺信息，请跟管理员沟通");
                }


                var StdCraSet = MESclient.GetDurmsUpFeedingByArrCode(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode);
                if (StdCraSet.Data != null)
                {

                }
                else
                {
                    ClsMsg.ShowErrMsg("无该标准工艺信息，请跟管理员沟通");
                }

                if (NewCraSet.Data.ExecuteOrder == 8)
                {
                    if (NewCraSet.Data.ExecuteStatus == 1)
                    {

                        NewCraftsName.Text = StdCraSet.Data[7].CraftsName;
                        OperatDescEdit.Text = "过磅";
                        //WeighingPoundsTextEdit.Properties.ReadOnly = false;
                        //VehicleWeightTextEdit.Properties.ReadOnly = false;
                        //WeightManTextEdit.Properties.ReadOnly = false;
                        if (!BgWait.IsBusy)
                        {
                            BgWait.RunWorkerAsync("GetPerWeight");
                        }



                        //     WeightTimer.Enabled = true;

                    }
                    if (NewCraSet.Data.ExecuteStatus == 98)
                    {
                        NewCraftsName.Text = StdCraSet.Data[7].CraftsName;
                        OperatDescEdit.Text = "卸料";
                    }
                    if (NewCraSet.Data.ExecuteStatus == 2)
                    {
                        ClsMsg.ShowErrMsg("工艺阶段异常，已处于空鼓状态，请跟管理员沟通");
                        vw_DurmsUpFeedingModel.WorkbrachCode = "";
                        ClearData();
                    }
                }
                else
                {
                    ClsMsg.ShowErrMsg("工艺阶段异常，非出于，可允许过磅状态，请跟管理员沟通");
                    vw_DurmsUpFeedingModel.WorkbrachCode = "";
                    ClearData();
                }
            }

        }
        /// <summary>
        /// 专用于放料时界面有排配单号遗留时的处理，先根据界面上的排配单号获取一系列信息，在进行车号操作，只适用于当操作项目等于放料时
        /// </summary>

        private void SearchNumCHWinthArr()
        {
            using (var MESclient = new SRCfPExecute.CfPExecuteServiceClient())
            {
                var NewCraSet = MESclient.GetCfPExecuteByArrangedVouchCode(context.SessionID, ArrangedVouchCodeTextEdit.Text);
                //  NewCraSet.Data.
                if (NewCraSet.Data == null)
                {
                    ClsMsg.ShowErrMsg("无该标准工艺信息，请跟管理员沟通");
                }
                var ret = MESclient.GetDurmsUpFeedingByDevCode(context.SessionID, NewCraSet.Data.WorkbrachCode);
                if (ret.Data != null)
                {

                    //if (ret.Data[0].DeveUseStatus == 0)
                    //{
                    //    DeveUseStatusSpinEdit.Text = "正常";
                    //}
                    //else
                    //{
                    //    DeveUseStatusSpinEdit.Text = "报修";
                    //}

                    DeveUseStatusSpinEdit.EditValue = ret.Data[0].DeveUseStatus.ToString();
                }
                else
                {
                    ClsMsg.ShowErrMsg("无该转鼓信息，请跟管理员沟通");
                }


                var Proret = MESclient.Getvw_DurmsUpFeedingByWorkbrachName(context.SessionID, NewCraSet.Data.WorkbrachCode);
                if (Proret.Data != null)
                {
                    vw_DurmsUpFeedingModel.ExecuteOrder = Proret.Data.ExecuteOrder;
                    vw_DurmsUpFeedingModel.CraftsName = Proret.Data.CraftsName;
                    vw_DurmsUpFeedingModel.ArrangedVouchCode = Proret.Data.ArrangedVouchCode;
                    vw_DurmsUpFeedingModel.FormulaName = Proret.Data.FormulaName;
                    vw_DurmsUpFeedingModel.ExecuteStatus = Proret.Data.ExecuteStatus;
                    vw_DurmsUpFeedingModel.InputWeight = Proret.Data.InputWeight;
                    vw_DurmsUpFeedingModel.WorkbrachName = Proret.Data.DevName;
                }
                else
                {
                    ClsMsg.ShowErrMsg("无该转鼓工艺信息，请跟管理员沟通");
                }
                //    vw_DurmsUpFeedingModel.WorkbrachName = Proret.Data.WorkbrachName;
                vw_DurmsUpFeedingModel.WorkbrachCode = WorkbrachNameTextEdit.Text;



                var StdCraSet = MESclient.GetDurmsUpFeedingByArrCode(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode);
                if (StdCraSet.Data == null)
                {
                    ClsMsg.ShowErrMsg("无该转鼓标准工艺信息，请跟管理员沟通");
                }
                if (NewCraSet.Data.ExecuteOrder == 7)
                {
                    if (NewCraSet.Data.ExecuteStatus == 2)
                    {

                        NewCraftsName.Text = StdCraSet.Data[7].CraftsName;
                        OperatDescEdit.Text = "装车";
                        //装车时不需要体重车重等信息
                        //if (!BgWait.IsBusy)
                        //{
                        //    BgWait.RunWorkerAsync("GetPerWeight");
                        //}
                        //  WeightTimer.Enabled = true;

                    }
                    //if (NewCraSet.Data.ExecuteStatus == 98)
                    //{
                    //    NewCraftsName.Text = StdCraSet.Data[7].CraftsName;
                    //    OperatDescEdit.Text = "卸料";
                    //}
                    //if (NewCraSet.Data.ExecuteStatus == 2)
                    //{
                    //    ClsMsg.ShowErrMsg("工艺阶段异常，请跟管理员沟通");
                    //    vw_DurmsUpFeedingModel.WorkbrachName = "";
                    //    ClearData();
                    //}
                }
                else
                {
                    ClsMsg.ShowErrMsg("502工艺阶段异常，请跟管理员沟通");
                    vw_DurmsUpFeedingModel.WorkbrachCode = "";
                    ClearData();
                }
            }

        }




        /// <summary>
        /// 更新工艺执行表主表里面的执行状态
        /// 传入参数，排配单号，执行顺序，执行状态
        /// </summary>
        private void UpdateCraftsProcess()
        {
            using (var MESclient = new SRCfPExecute.CfPExecuteServiceClient())
            {

                switch (vw_DurmsUpFeedingModel.ExecuteOrder)
                {
                    case 1:

                        if (vw_DurmsUpFeedingModel.ExecuteStatus == 2)
                        {

                            var TestRet = MESclient.UpdateCraftsProcessExecute(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode, 3, 1);

                            InsterArrangedLog(MESclient, TestRet);
                        }

                        else
                        {
                            ClsMsg.ShowErrMsg("536工艺阶段异常，请跟管理员沟通");
                            vw_DurmsUpFeedingModel.WorkbrachCode = "";
                            ClearData();
                        }


                        break;

                    case 2:
                        if (vw_DurmsUpFeedingModel.ExecuteStatus == 2)
                        {
                            var TestRet = MESclient.UpdateCraftsProcessExecute(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode, 3, 1);
                            InsterArrangedLog(MESclient, TestRet);
                        }

                        else
                        {
                            ClsMsg.ShowErrMsg("553工艺阶段异常，请跟管理员沟通");
                            vw_DurmsUpFeedingModel.WorkbrachCode = "";
                            ClearData();
                        }


                        break;

                    case 3:
                        //-----------------高温排水手动结束暂停，采用自动-------------//

                        if (vw_DurmsUpFeedingModel.ExecuteStatus == 1)
                        {

                            var EndTestRet = MESclient.UpdateCraftsProcessExecute(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode, 3, 2);
                            var TestRet = MESclient.UpdateCraftsProcessExecute(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode, 4, 1);

                            InsterArrangedLog(MESclient, TestRet);
                        }
                        else
                        {
                            ClsMsg.ShowErrMsg("573工艺阶段异常，请跟管理员沟通");
                            vw_DurmsUpFeedingModel.WorkbrachCode = "";
                            ClearData();
                        }
                        //-----------------高温排水手动结束暂停，采用自动-------------//                    

                        break;

                    case 4:

                        if (vw_DurmsUpFeedingModel.ExecuteStatus == 1)
                        {
                            var EndTestRet = MESclient.UpdateCraftsProcessExecute(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode, 4, 2);
                            var TestRet = MESclient.UpdateCraftsProcessExecute(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode, 5, 1);
                            InsterArrangedLog(MESclient, TestRet);

                        }

                        else if (vw_DurmsUpFeedingModel.ExecuteStatus == 2)
                        {

                            var TestRet = MESclient.UpdateCraftsProcessExecute(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode, 5, 2);
                            InsterArrangedLog(MESclient, TestRet);
                            //ClsMsg.ShowErrMsg("排水阶段未完成，请等待系统自动完成");
                            //vw_DurmsUpFeedingModel.WorkbrachName = "";
                            //ClearData();


                        }
                        else
                        {
                            ClsMsg.ShowErrMsg("604工艺阶段异常，请跟管理员沟通");
                            vw_DurmsUpFeedingModel.WorkbrachCode = "";
                            ClearData();
                        }


                        break;

                    case 5:
                        if (vw_DurmsUpFeedingModel.ExecuteStatus == 1)
                        {
                            //ClsMsg.ShowErrMsg("烘料阶段未完成，请等待系统自动完成");
                            //vw_DurmsUpFeedingModel.WorkbrachName = "";
                            //ClearData();
                            var EndTestRet = MESclient.UpdateCraftsProcessExecute(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode, 5, 2);
                            var TestRet = MESclient.UpdateCraftsProcessExecute(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode, 6, 1);
                            InsterArrangedLog(MESclient, TestRet);


                        }
                        else if (vw_DurmsUpFeedingModel.ExecuteStatus == 2)
                        {
                            //var TestRet = MESclient.UpdateCraftsProcessExecute(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode, 6, 2);
                            //InsterArrangedLog(MESclient, TestRet);
                            ClsMsg.ShowErrMsg("烘料阶段未完成，请等待系统自动完成");
                            vw_DurmsUpFeedingModel.WorkbrachCode = "";
                            ClearData();


                        }
                        else
                        {
                            ClsMsg.ShowErrMsg("636工艺阶段异常，请跟管理员沟通");
                            vw_DurmsUpFeedingModel.WorkbrachCode = "";
                            ClearData();
                        }

                        break;

                    case 6:
                        if (vw_DurmsUpFeedingModel.ExecuteStatus == 1)
                        {

                            //ClsMsg.ShowErrMsg("充氮阶段未完成，请等待系统自动完成");
                            //vw_DurmsUpFeedingModel.WorkbrachName = "";
                            //ClearData();
                            var EndTestRet = MESclient.UpdateCraftsProcessExecute(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode, 6, 2);
                            var TestRet = MESclient.UpdateCraftsProcessExecute(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode, 7, 1);
                            InsterArrangedLog(MESclient, TestRet);


                        }
                        else if (vw_DurmsUpFeedingModel.ExecuteStatus == 2)
                        {

                            var TestRet = MESclient.UpdateCraftsProcessExecute(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode, 7, 1);
                            InsterArrangedLog(MESclient, TestRet);
                        }
                        else
                        {
                            ClsMsg.ShowErrMsg("664工艺阶段异常，请跟管理员沟通");
                            vw_DurmsUpFeedingModel.WorkbrachCode = "";
                            ClearData();
                        }

                        break;

                    case 7:

                        if (vw_DurmsUpFeedingModel.ExecuteStatus == 1)
                        {
                            //放料操作，需要将排配单工艺状态修正为待过磅

                            var TestRet = MESclient.UpdateCraftsProcessExecute(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode, 7, 2);
                            InsterArrangedLog(MESclient, TestRet);



                        }


                        else if (vw_DurmsUpFeedingModel.ExecuteStatus == 2)
                        {
                            //7-2步骤，将排配单跟车号绑定，下一步之后不刷转鼓号，只刷车号。这一步还是刷转鼓号码带出数据

                            var TestRet = MESclient.UpdateCraftsProcessExecute(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode, 8, 1);
                            var UpDevStatis = MESclient.UpdateDevWStatusByCode(context.SessionID, LicenseNumTextEdit.Text, 1);
                            InsterArrangedLog(MESclient, TestRet);
                            MESclient.UpdateArrangedVouchWeight(context.SessionID, vw_DurmsUpFeedingModel);

                            using (var Arrclient = new SRArrangedVouch.ArrangedVServiceClient())
                            {
                                var UpdateArr = Arrclient.UdateArrUserStatusByArrCode(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode, 50);
                            }


                        }
                        else
                        {
                            ClsMsg.ShowErrMsg("698工艺阶段异常，请跟管理员沟通");
                            vw_DurmsUpFeedingModel.WorkbrachCode = "";
                            ClearData();
                        }


                        break;

                    case 8:
                        //这一步直接刷车号带出数据，而不是转鼓号码
                        if (vw_DurmsUpFeedingModel.ExecuteStatus == 1)
                        {


                            var TestRet = MESclient.UpdateCraftsProcessExecute(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode, 8, 98);
                            InsterArrangedLog(MESclient, TestRet);
                            MESclient.UpdateArrangedVouchWeight(context.SessionID, vw_DurmsUpFeedingModel);

                        }

                        else if (vw_DurmsUpFeedingModel.ExecuteStatus == 98)
                        {


                            var TestRet = MESclient.UpdateCraftsProcessExecute(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode, 8, 2);
                            var UpDevStatis = MESclient.UpdateDevWStatusByCode(context.SessionID, LicenseNumTextEdit.Text, 0);
                            InsterArrangedLog(MESclient, TestRet);

                            using (var Arrclient = new SRArrangedVouch.ArrangedVServiceClient())
                            {
                                var UpdateArr = Arrclient.UdateArrUserStatusByArrCode(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode, 100);
                            }

                        }

                        else
                        {
                            ClsMsg.ShowErrMsg("730工艺阶段异常，请跟管理员沟通");
                            vw_DurmsUpFeedingModel.WorkbrachCode = "";
                            ClearData();
                        }



                        break;

                }

            }
        }
        /// <summary>
        /// 保存操作日志
        /// </summary>
        /// <param name="MESclient"></param>
        /// <param name="TestRet"></param>
        private void InsterArrangedLog(SRCfPExecute.CfPExecuteServiceClient MESclient, SRCfPExecute.CommonResultOfCraftsProcessExecutedYMi5huk TestRet)
        {

            if (TestRet.Data != null)
            {
                var logModel = new SRCfPExecute.ArrangedVouchLog()
                {
                    ArrangedVouchCode = vw_DurmsUpFeedingModel.ArrangedVouchCode,
                    OperatingTime = vw_DurmsUpFeedingModel.CreateTime,
                    OperatDesc = OperatDescEdit.Text,
                    Operator = CreatorTextEdit.Text,
                    Frequency = FrequencyEdit.Text,
                    CraftsName = NewCraftsName.Text,
                };

                MESclient.InsterArrVouchLog(context.SessionID, logModel);  //保存操作日志数据
            }
        }
        /// <summary>
        /// 刷新操作日志记录，即刷新control控件，传入值排配单号，进行刷新，改排配单在控件直接获取
        /// </summary>
        /// <param name="e"></param>
        private void RefreshControl(DoWorkEventArgs e)
        {
            if (vw_DurmsUpFeedingModel.WorkbrachCode != "")
            {
                using (var MESclientLog = new SRCfPExecute.CfPExecuteServiceClient())
                {
                    var retLog = MESclientLog.GetArrangedVouchLogByCode(context.SessionID, ArrangedVouchCodeTextEdit.Text);

                    if (retLog.Data != null)
                    {

                        e.Result = retLog.Data;
                    }

                }
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

        private void frmDrumProcess_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InsterData();
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
                else if (e.Result is Boolean && Convert.ToBoolean(e.Result))
                {
                    vwDurmsUpFeedingBindingSource.EndEdit();
                    WeightTimer.Enabled = true;
                }
            }


        }

        private void SuBmitBtn_Click(object sender, EventArgs e)
        {
            WeightTimer.Enabled = false;
            WeighingPoundsTextEdit.Properties.ReadOnly = true;
            VehicleWeightTextEdit.Properties.ReadOnly = true;
            WeightManTextEdit.Properties.ReadOnly = true;
            vw_DurmsUpFeedingModel.CreateTime = DateTime.Now;
            if (OperatDescEdit.Text == "")
            {
                //    ClsMsg.ShowErrMsg("操作项目为必填项，请根据工艺刷卡");
                ClsMsg.ShowErrMsg("放料阶段，请刷摩托车号");
                return;
            }

            if (OperatDescEdit.Text == "" && LicenseNumTextEdit.Text == "")
            {
                ClsMsg.ShowErrMsg("当前工艺状态，摩托车号为必填项！");
                return;
            }

            if (WorkbrachNameTextEdit.Text == "")
            {
                ClsMsg.ShowErrMsg("当前鼓号为空，请扫描正确的鼓号！");
                return;
            }

            string CheckCode = WorkbrachNameTextEdit.Text.Substring(0, 2);

            if (CheckCode == "ZG")
            {
                using (var MESclient = new SRCfPExecute.CfPExecuteServiceClient())
                {

                    var ret = MESclient.GetDurmsUpFeedingByDevCode(context.SessionID, WorkbrachNameTextEdit.Text);
                    if (ret.Data != null)
                    {
                        DeveUseStatusSpinEdit.EditValue = ret.Data[0].DeveUseStatus.ToString();

                    }
                    else
                    {
                        ClsMsg.ShowErrMsg("无该设备状态数据，请跟管理员沟通");
                    }

                    var NewProret = MESclient.GetDurmsUpFeedingByDevCode(context.SessionID, WorkbrachNameTextEdit.Text);

                    if (NewProret.Data[0].DevName != vw_DurmsUpFeedingModel.WorkbrachName)
                    {
                        ClsMsg.ShowErrMsg("该转鼓跟二维码编码不一致，请重新扫描转鼓号码！");
                        return;
                    }

                    var Proret = MESclient.GeCraftsProcessdByWorkbrachName(context.SessionID, WorkbrachNameTextEdit.Text);
                    if ((Proret.Data.ExecuteOrder == 1 && Proret.Data.ExecuteStatus == 2)
                        || (Proret.Data.ExecuteOrder == 2 && Proret.Data.ExecuteStatus == 2)
                        || (Proret.Data.ExecuteOrder == 3 && Proret.Data.ExecuteStatus == 1)
                        || (Proret.Data.ExecuteOrder == 4 && Proret.Data.ExecuteStatus == 1)
                        || (Proret.Data.ExecuteOrder == 5 && Proret.Data.ExecuteStatus == 1)
                        || (Proret.Data.ExecuteOrder == 6 && Proret.Data.ExecuteStatus == 1)
                        || (Proret.Data.ExecuteOrder == 7 && Proret.Data.ExecuteStatus == 1)
                        || (Proret.Data.ExecuteOrder == 7 && Proret.Data.ExecuteStatus == 2)
                        || (Proret.Data.ExecuteOrder == 8 && Proret.Data.ExecuteStatus == 1)
                        || (Proret.Data.ExecuteOrder == 8 && Proret.Data.ExecuteStatus == 98))
                    {
                        if (Proret.Data.ExecuteOrder != vw_DurmsUpFeedingModel.ExecuteOrder || Proret.Data.ExecuteStatus != vw_DurmsUpFeedingModel.ExecuteStatus)
                        {
                            vw_DurmsUpFeedingModel.WorkbrachCode = "";
                            vw_DurmsUpFeedingModel.DevName = "";
                            ClsMsg.ShowErrMsg("该转鼓在同一时间被进行了操作，请重新扫描转鼓号码！");
                            return;
                        }

                    }

                }
            }

            if (CheckCode == "CH")
            {
                using (var MESclient = new SRCfPExecute.CfPExecuteServiceClient())
                {
                    var Proret = MESclient.GetCfPExecuteByArrangedVouchCode(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode);
                    if ((Proret.Data.ExecuteOrder == 8 && Proret.Data.ExecuteStatus == 1)
                        || (Proret.Data.ExecuteOrder == 8 && Proret.Data.ExecuteStatus == 98))
                    {
                        if (Proret.Data.ExecuteOrder != vw_DurmsUpFeedingModel.ExecuteOrder || Proret.Data.ExecuteStatus != vw_DurmsUpFeedingModel.ExecuteStatus)
                        {
                            vw_DurmsUpFeedingModel.WorkbrachCode = "";
                            vw_DurmsUpFeedingModel.DevName = "";
                            ClsMsg.ShowErrMsg("该转鼓在同一时间被其他同事进行了操作，当前工艺需要重新校准，请重新扫描转鼓号码！");
                            return;
                        }

                    }

                }
            }

            if (FrequencyEdit.Text == "")
            {
                ClsMsg.ShowErrMsg("当前没有选择班次，请先选择班次！");
                return;
            }

            else if (DeveUseStatusSpinEdit.Text != "正常")
            {
                ClsMsg.ShowErrMsg("当前鼓号设备状态异常，请扫描正确的鼓号！");
                return;
            }


            else if (ClsMsg.ShowQuestionMsg("是否要保存工艺流转信息信息呢？") == DialogResult.Yes)
            {
                BgWait.RunWorkerAsync("UpdateCraftsProcessExecute");
            }

        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            if (ClsMsg.ShowQuestionMsg("是否要清除该界面所有信息呢？") == DialogResult.Yes)
            {
                ClearData();
            }
        }

        private void ClearData()
        {
            //      FrequencyEdit.Text = "";     //班次暂时去掉清空，增加保存顺畅性20170107XCQ

            this.Invoke((MethodInvoker)delegate()
            {
                vw_DurmsUpFeedingModel = new SRCfPExecute.vw_DurmsUpFeeding();
                vwDurmsUpFeedingBindingSource.DataSource = vw_DurmsUpFeedingModel;
                DeveUseStatusSpinEdit.Text = "";
                DeveUseStatusSpinEdit.EditValue = null;
                OperatDescEdit.Text = "";
                NewCraftsName.Text = "";

                vw_DurmsUpFeedingModel.CreateTime = DateTime.Now;
                vw_DurmsUpFeedingModel.Creator = context.UserName;

                WeightTimer.Enabled = false;

                gridControl1.RefreshDataSource();
                arrangedVouchLogBindingSource.DataSource = null;
            });





        }

        private void WeightTimer_Tick(object sender, EventArgs e)
        {

            string WeightData = cache.Get<string>("ZGDB001");

            vw_DurmsUpFeedingModel.WeighingPounds = Convert.ToDecimal(WeightData);
            vw_DurmsUpFeedingModel.OutputWeight = CalOutWeight(vw_DurmsUpFeedingModel.WeighingPounds, vw_DurmsUpFeedingModel.VehicleWeight, vw_DurmsUpFeedingModel.WeightMan);

        }

        private decimal CalOutWeight(decimal? WeightData, double? VehicleWeight, double? WeightMan)
        {
            try
            {
                // if(WeightData.IsNullOrEmpty()==true)
                // {
                //     WeightData = "0";
                // }

                //if(VehicleWeight.IsNullOrEmpty() == true)
                // {
                //     VehicleWeight = "0";
                // }
                //if(WeightMan.IsNullOrEmpty() == true)
                // {
                //     WeightMan = "0";
                // }

            }
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.Message);
            }
            decimal Result = Convert.ToDecimal(WeightData) - Convert.ToDecimal(VehicleWeight) - Convert.ToDecimal(WeightMan);
            return Result;
        }

        private void InterruptBtn_Click(object sender, EventArgs e)
        {
            //if (!BgWait.IsBusy)
            //{
            //    BgWait.RunWorkerAsync("GetPerWeight");
            //}
            if (DeveUseStatusSpinEdit.Text == "正常" && (vw_DurmsUpFeedingModel.ExecuteOrder != 7 || vw_DurmsUpFeedingModel.ExecuteStatus != 2))
            {
                ClsMsg.ShowErrMsg("设备状态正常，并且不在放料完毕阶段，无法进行设备中断或废料中断处理！");
                return;
            }

            if (ArrangedVouchCodeTextEdit.Text == "")
            {
                ClsMsg.ShowErrMsg("排配单不能为空！");
                return;
            }
            else if (ClsMsg.ShowQuestionMsg("是否要中断该排配单数据？") == DialogResult.Yes && ArrangedVouchCodeTextEdit.Text != "")
            {
                using (var MESclient = new SRCfPExecute.CfPExecuteServiceClient())
                {
                    var TestRet = MESclient.UpdateCraftsProcessExecute(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode, 8, 2);

                    using (var Arrclient = new SRArrangedVouch.ArrangedVServiceClient())
                    {
                        if (DeveUseStatusSpinEdit.Text != "正常")
                        {
                            var UpdateArr = Arrclient.UdateArrUserStatusByArrCode(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode, 99);
                        }
                        else
                        {
                            var UpdateArr = Arrclient.UdateArrUserStatusByArrCode(context.SessionID, vw_DurmsUpFeedingModel.ArrangedVouchCode, 98);
                        }
                    }

                    if (TestRet.IsSuccess)
                    {
                        ClsMsg.ShowErrMsg("该排配单已被中断");
                    }
                }
            }
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
