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

namespace LY.MES.WFCL.Base.Frm
{
    /// <summary>
    /// Author:xxp
    /// Remark:设备信息
    /// CreateDate:20161014
    /// </summary>
    public partial class frmDevice : BaseForm
    {
        private string strDevCCode = null, strDevCode = null;
        private SRDevice.Device model;

        /// <summary>
        /// 设备信息明细
        /// </summary>
        /// <param name="context">用户上下文</param>
        /// <param name="strDevCode">设备编码</param>
        /// <param name="strDevCCode">设备分类编码</param>
        public frmDevice(UserContext context, string strDevCode = null, string strDevCCode = null)
            : base(context)
        {
            InitializeComponent();
            bgwWait.ProgressChanged += backgroundWorker_ProgressChanged;

            this.strDevCCode = strDevCCode;
            this.strDevCode = strDevCode; //devcategory
            DevCategorySpinEdit.Properties.DataSource = Client.Utility.DataEnum.GetEnumData("devcategory");
            UseStatusSpinEdit.Properties.DataSource = Client.Utility.DataEnum.GetEnumData("devstatus");

            //DevQRUrlTextEdit.DataBindings[0].Parse += frmDevice_Parse;

            DevQRUrlTextEdit.DataBindings[0].Format += frmDevice_Format;
            DevImageUrlTextEdit.DataBindings[0].Format += frmDevice_Format;
        }

        void frmDevice_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value != null)
            {
                string url = e.Value.ToString();
                if (((System.Windows.Forms.Binding)(sender)).BindingMemberInfo.BindingField.Equals("DevQRUrl") && DevQRUrlTextEdit.Image == null)
                {
                    this.Invoke((MethodInvoker)delegate()
                    {
                        DevQRUrlTextEdit.Image = new Bitmap((new System.Net.WebClient()).OpenRead(url));
                    });
                }
                else if (((System.Windows.Forms.Binding)(sender)).BindingMemberInfo.BindingField.Equals("DevImageUrl") && DevImageUrlTextEdit.Image == null)
                {
                    this.Invoke((MethodInvoker)delegate()
                    {
                        DevImageUrlTextEdit.Image = new Bitmap((new System.Net.WebClient()).OpenRead(url));
                    });
                }
            }
            //byte[] imageBytes = Convert.FromBase64String(e.Value.ToString());
            //e.Value = imageBytes;
        }

        void frmDevice_Parse(object sender, ConvertEventArgs e)
        {
            // e.Value = Convert.ToBase64String(e.Value as byte[]);
        }

        private void frmDevice_Load(object sender, EventArgs e)
        {
            try
            {
                if (strDevCode.IsNullOrEmpty() == false)
                {
                    DevCodeTextEdit.Properties.ReadOnly = true;
                    this.BeginInvoke((MethodInvoker)delegate() { InitData(); });
                }
                else
                {
                    AddData();
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                ClsMsg.ShowErrMsg(ex.Message);
            }
        }


        #region Event

        private void bmTool_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                switch (e.Item.Name)
                {
                    case "bbtniSave":
                        //EndEditOnAllBindingSources();
                        deviceBindingSource.EndEdit();
                        if (model.DevCode.IsNullOrEmpty())
                        {
                            ClsMsg.ShowWarningEmptyMsg(ItemForDevCode.Text);
                            DevCodeTextEdit.Focus();
                        }
                        else if (model.DevName.IsNullOrEmpty())
                        {
                            ClsMsg.ShowWarningEmptyMsg(ItemForDevName.Text);
                            DevNameTextEdit.Focus();
                        }
                        else if (model.DevCCode.IsNullOrEmpty())
                        {
                            ClsMsg.ShowWarningEmptyMsg(ItemForDevCCode.Text);
                            DevCCodeTextEdit.Focus();
                        }
                        else if (ClsMsg.ShowQuestionMsg("是否要保存设备档案信息呢？") == DialogResult.Yes)
                        {
                            bgwWait.RunWorkerAsync("SaveData");
                        }
                        break;
                    case "bbtniDel":
                        if (strDevCode.IsNullOrEmpty())
                        {
                            ClsMsg.ShowWarningMsg("无任何数据可删除！");
                            return;
                        }
                        if (ClsMsg.ShowQuestionMsg("是否要删除设备档案呢？") == DialogResult.Yes)
                        {
                            bgwWait.RunWorkerAsync("DeleteData");
                        }
                        break;
                    case "bbtniExit":
                        this.Close();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());
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
                        using (SRDevice.DeviceServiceClient client = new SRDevice.DeviceServiceClient())
                        {
                            if (strDevCode.IsNullOrEmpty()) //新增
                            {
                                this.AddSysOperLogs(this.Text, OperateStatus.增加, strCode: model.DevCode);
                                model.DevQRUrl = BarCodeTool.GenerateQRUpFile(model.DevCode);
                                var ret = client.AddDevice(context.SessionID, model);
                                if (ret.IsSuccess)
                                {
                                    //bgwWait.ReportProgress(99, "新增成功！");
                                    e.Result = ret.Data;
                                }
                                else
                                    bgwWait.ReportProgress(PubConstant.WaitMessageStatus.WARNING, ret.Message);
                            }
                            else  //修改
                            {
                                model.LastDate = DateTime.Now;
                                model.LastPerson = context.UserName;
                                this.AddSysOperLogs(this.Text, OperateStatus.修改, strCode: model.DevCode);
                                var ret = client.UpdateDevice(context.SessionID, model);
                                if (ret.IsSuccess)
                                {
                                    bgwWait.ReportProgress(PubConstant.WaitMessageStatus.PROMPT, "修改成功！");
                                    e.Result = true;
                                }
                                else
                                    bgwWait.ReportProgress(PubConstant.WaitMessageStatus.WARNING, ret.Message);
                            }
                        }
                        break;
                    case "DeleteData":
                        using (SRDevice.DeviceServiceClient client = new SRDevice.DeviceServiceClient())
                        {
                            this.AddSysOperLogs(this.Text, OperateStatus.删除, strCode: model.DevCode);
                            var ret1 = client.DelDeviceByCode(context.SessionID, model.DevCode);
                            if (ret1.IsSuccess)
                            {
                                bgwWait.ReportProgress(PubConstant.WaitMessageStatus.PROMPT, "删除成功！");
                                e.Result = true;
                            }
                            else
                                bgwWait.ReportProgress(PubConstant.WaitMessageStatus.WARNING, ret1.Message);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (System.ServiceModel.FaultException<SRDevice.CustomFaultMessage> fex)
            {
                bgwWait.ReportProgress(PubConstant.WaitMessageStatus.ERROR, fex.Message);
                Utils.Logger.Error(fex.ToString());
            }
            catch (Exception ex)
            {
                bgwWait.ReportProgress(PubConstant.WaitMessageStatus.ERROR, ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
            bgwWait.ReportProgress(PubConstant.WaitMessageStatus.END);
        }

        private void bgwWait_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                if (e.Result is SRDevice.Device)
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

        //处理日期控件Null
        //private void StopDateTextEdit_Properties_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        //{
        //    if (e.Value != DBNull.Value)
        //    {
        //        if (e.Value.ToString().IsNullOrEmpty())
        //            e.Value = DBNull.Value;
        //    }
        //}
        #endregion

        #region Method

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            using (SRDevice.DeviceServiceClient client = new SRDevice.DeviceServiceClient())
            {
                var ret = client.GetDeviceByCode(context.SessionID, strDevCode);
                if (ret.IsSuccess)
                {
                    model = ret.Data;
                    this.Invoke((MethodInvoker)delegate()
                    {
                        deviceBindingSource.DataSource = model;
                    });
                }
                else
                    ClsMsg.ShowErrMsg(ret.Message);
            }
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        private void AddData()
        {
            model = new SRDevice.Device()
            {
                DevCCode = strDevCCode,
                CreateDate = DateTime.Now,
                CreatePerson = context.UserName
            };
            deviceBindingSource.DataSource = model;
        }

        #endregion
    }
}
