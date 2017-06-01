using LY.MES.WFCL;
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
using LY.MES.WFCL.Refer;

namespace LY.MES.WFCL.DataColl.Frm
{
    public partial class frmExecute : BaseForm
    {
        /// <summary>
        /// 设备执行表增删改界面
        /// lastupdata201115XCQ
        /// </summary>
        private string  strDeviCode = null;
        private SRExcute.DeviceExecute model = null;
        public string Flag_j = "";

        public frmExecute(UserContext context,string DeviCode=null)
            : base(context)
        {
          
            InitializeComponent();
            strDeviCode = DeviCode;

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void frmExecute_Load(object sender, EventArgs e)
        {
           
                try
                {
                    if (strDeviCode.IsNullOrEmpty() == false)
                    {   
                     //   DevCodeTextEdit.Properties.ReadOnly = true;
                        this.BeginInvoke((MethodInvoker)delegate() { InitData(); });
                    }
                    else
                    {
                        AddData();
                    }
                }
                catch (Exception ex)
                {
                    ClsMsg.ShowErrMsg(ex.Message);            
                }    
        }

        private void DevCodeTextEdit_Click(object sender, EventArgs e)
        {

            try
            {
                frmDeviceChoose frmDevface = new frmDeviceChoose(context,null);
                if (frmDevface.ShowDialog() == DialogResult.OK)
                {
                    model.DevCode = frmDevface.DeviCode;
                    //model.DeviCode = frmInterface.DeviCode;
                    //model.DevpCode = frmInterface.DevpCode;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void DeviCodeTextEdit_Click(object sender, EventArgs e)
        {
            if (strDeviCode.IsNullOrEmpty())
            { 
            try
            {
                frmInterfaceChoose frmInterface = new frmInterfaceChoose(context);
                if (frmInterface.ShowDialog() == DialogResult.OK)
                {
                  //  model.DevCode = frmInterface.DevCode;
                    model.DeviCode = frmInterface.DeviCode;
                    model.DevpCode = frmInterface.DevpCode;
  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           }
                else
            {

                DeviCodeTextEdit.Properties.ReadOnly = true;

            }

        }

        private void barManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {
                if (BgWait2.IsBusy == false)
                {
                    switch (e.Item.Name)
                    {
                        case "bbtniAdd":

                            EndEditOnAllBindingSources();
                            if (strDeviCode.IsNullOrEmpty() && ClsMsg.ShowQuestionMsg("是否要保存设备档案信息呢？") == DialogResult.Yes)
                            {

                                BgWait2.RunWorkerAsync("SaveData");
                            }

                            else if (CollFrequencyTextEdit.IsNullOrEmpty())
                            {
                                ClsMsg.ShowWarningEmptyMsg(ItemForCollFrequency.Text);
                                CollFrequencyTextEdit.Focus();
                            }
                            else if (UserStatusSpinEdit.IsNullOrEmpty())
                            {
                                ClsMsg.ShowWarningEmptyMsg(ItemForUserStatus.Text);
                                UserStatusSpinEdit.Focus();
                            }
                       
                            else
                            {
                                if (ClsMsg.ShowQuestionMsg("是否要修改设备档案信息呢？") == DialogResult.Yes)
                                {

                                    EndEditOnAllBindingSources();
                                    BgWait2.RunWorkerAsync("UpdData");

                                }
                              

                            }
                            break;
               
                        case "bbtniUpdate":


                            BgWait2.RunWorkerAsync("UpdData");

                            break;
                         case "bbtniDelete":

                            if (strDeviCode.IsNullOrEmpty())
                        {
                            ClsMsg.ShowWarningMsg("无任何数据可删除！");
                            return;
                        }
                        if (ClsMsg.ShowQuestionMsg("是否要删除设备档案呢？") == DialogResult.Yes)
                        {
                            BgWait2.RunWorkerAsync("Delete");
                        }

                            break;

                        case "bbtnExit":

                            this.Close();
                         
                          
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.ToString());
            }
        }

        private void BgWait2_DoWork(object sender, DoWorkEventArgs e)
        {
            BgWait2.ReportProgress(0);
            try
            {
                switch (e.Argument.ToString())
                {

                    case "SaveData":

                        this.AddSysOperLogs(this.Text, OperateStatus.增加, strCode: model.DeviCode);
      
                        using (SRExcute.DevExecuteServiceClient client = new SRExcute.DevExecuteServiceClient())
                        {

                            var ret = client.AddDeviceExecute(context.SessionID, model);

                            if (ret.IsSuccess)
                            {
                              
                                e.Result = ret.Data;
                                BgWait2.ReportProgress(99, "保存成功！");

                            }
                        }
                          
                        break;

                    case "UpdData":

                        this.AddSysOperLogs(this.Text, OperateStatus.修改, strCode: model.DeviCode);

                          using (SRExcute.DevExecuteServiceClient client = new SRExcute.DevExecuteServiceClient())
                        {
                            var ret = client.UpdateDeviceExecute(context.SessionID, model);

                         if (ret.IsSuccess)
                         {
                            
                             e.Result = true;
                             BgWait2.ReportProgress(99, "修改成功");

                         }

                            }


                        break;

                    case "Delete":

                        this.AddSysOperLogs(this.Text, OperateStatus.删除, strCode: model.DeviCode);

                        using (SRExcute.DevExecuteServiceClient client = new SRExcute.DevExecuteServiceClient())
                        {
                            var ret = client.DelDeviceExecute(context.SessionID, model.DeveCode);

                         if (ret.IsSuccess)
                         {
                         
                             e.Result = true;
                             BgWait2.ReportProgress(99, "删除成功");

                         }
                            }

                        break;

                       default:

                        break;
                }
            }

            catch (Exception ex)
            {
                BgWait2.ReportProgress(102, ex.Message);
            }

            BgWait2.ReportProgress(100);
        }

        private void BgWait2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Result != null)
            {
                if (e.Result is SRExcute.DeviceExecute)
                {
                    if (ClsMsg.ShowQuestionMsg("新增成功！\n是否继续增加设备档案呢？") == DialogResult.Yes)
                    {
                        AddData();
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (e.Result is bool)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void InitData()
        {
            using (SRExcute.DevExecuteServiceClient client = new SRExcute.DevExecuteServiceClient())
            {
                var ret = client.GetDeviceExecute(context.SessionID, strDeviCode);
                if (ret.IsSuccess)
                {
                    model = ret.Data;
                    this.Invoke((MethodInvoker)delegate()
                    {
                        deviceExecuteBindingSource.DataSource = model;
                    });
                }
                else
                    ClsMsg.ShowErrMsg(ret.Message);
            }
        }


        private void AddData()
        {
            DeviCodeTextEdit.Properties.ReadOnly = false;

            model = new SRExcute.DeviceExecute();
            deviceExecuteBindingSource.DataSource = model;

            model.CreateDate = DateTime.Now;
            model.CreatePerson = context.UserName;

        }

        private void EndEditOnAllBindingSources()
        {
            var BindingSourcesQuery =
                from Component bindingSources in this.components.Components
                where bindingSources is BindingSource
                select bindingSources;

            foreach (BindingSource bindingSource in BindingSourcesQuery)
            {
                bindingSource.EndEdit();
            }
        }

      

    }

}