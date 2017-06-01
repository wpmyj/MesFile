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
using Client.Utility.Filter;

namespace LY.MES.WFCL.Base.Frm
{
    public partial class frmPersonalInfo : BaseForm
    {
        private  string strDepCode = null, strPersonCode = null;
        private SRPersonInfo.Person Model = null;
        private static List<string> SexList = null;
        public frmPersonalInfo(UserContext context, string strDepCode = null,string strPersonCode = null)
            :base(context)
        {
            InitializeComponent();
            bgWait.ProgressChanged += this.backgroundWorker_ProgressChanged;
            this.strDepCode = strDepCode;
            this.strPersonCode = strPersonCode;
            Model = new SRPersonInfo.Person();
            SexList = new List<string>();
        }

        private void frmPersonalInfo_Load(object sender, EventArgs e)
        {
            try
            {
                //性别下拉列表
                var ret = Client.Utility.DataEnum.GetEnumData(context, "BS.Sex");
                if (ret != null)
                {
                    ret.ForEach(item => { SexList.Add(item.Item2); });
                    SexTextEdit.Properties.DataSource = SexList;
                }

                DepCodeTextEdit.Properties.ReadOnly = true;
                if (this.strDepCode != null && this.strPersonCode != null)
                {
                    PersonCodeTextEdit.Properties.ReadOnly = true;
                    this.BeginInvoke((MethodInvoker)delegate() { LoadPersonData(); });
                }
                else if (this.strDepCode != null && this.strPersonCode == null)
                {
                    AddPersonData();
                }

                //if (IsOperatorCheckEdit.CheckState.Equals(CheckState.Unchecked))
                //{
                //    OparatorCodeTextEdit.Properties.ReadOnly = true;
                //    OparatorNameTextEdit.Properties.ReadOnly = true;
                //}
                //else
                //{
                //    OparatorCodeTextEdit.Properties.ReadOnly = false;
                //    OparatorNameTextEdit.Properties.ReadOnly = false;
                //}
            }
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
        }

        private void bgWait_DoWork(object sender, DoWorkEventArgs e)
        {
            bgWait.ReportProgress(PubConstant.WaitMessageStatus.START);
            try
            {
                switch (e.Argument.ToString())
                {
                    case"SavePersonData":
                        personBindingSource.EndEdit();
                        Model = personBindingSource.DataSource as SRPersonInfo.Person;
                        if (DepCodeTextEdit.Properties.ReadOnly == true && PersonCodeTextEdit.Properties.ReadOnly == false)
                        {
                            using (var Client = new SRPersonInfo.PersonServiceClient())
                            {
                                var ret = Client.AddPersonData(context.SessionID, Model);
                                if (ret.IsSuccess)
                                {
                                    this.AddSysOperLogs(this.Text, OperateStatus.增加, strCode: Model.PersonCode);
                                    e.Result = ret.Data;
                                }
                                else
                                {
                                    bgWait.ReportProgress(PubConstant.WaitMessageStatus.ERROR,ret.Message);
                                }
                            }
                        }
                        else if (DepCodeTextEdit.Properties.ReadOnly && PersonCodeTextEdit.Properties.ReadOnly)
                        {
                            using (var Client = new SRPersonInfo.PersonServiceClient())
                            {
                                var ret = Client.UpdataPersonData(context.SessionID, Model);
                                if (ret.IsSuccess)
                                {
                                    this.AddSysOperLogs(this.Text, OperateStatus.修改, strCode: Model.PersonCode);
                                    bgWait.ReportProgress(PubConstant.WaitMessageStatus.PROMPT, "数据修改成功！");
                                    e.Result = true;
                                }
                                else
                                {
                                    bgWait.ReportProgress(PubConstant.WaitMessageStatus.ERROR, ret.Message);
                                }
                            }
                        }
                        break;
                    case "DeletePersonData":
                        using(var Client = new SRPersonInfo.PersonServiceClient())
                        {
                            personBindingSource.EndEdit();
                            Model = new SRPersonInfo.Person();
                            Model = personBindingSource.DataSource as SRPersonInfo.Person;
                            var ret = Client.DelPersonData(context.SessionID,Model.PersonCode);
                            if (ret.Data)
                            {
                                this.AddSysOperLogs(this.Text, OperateStatus.删除, strCode: Model.PersonCode);
                                bgWait.ReportProgress(PubConstant.WaitMessageStatus.PROMPT, "数据删除成功！");
                                e.Result = true;
                            }
                            else
                            {
                                bgWait.ReportProgress(PubConstant.WaitMessageStatus.ERROR, ret.Message);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch(System.ServiceModel.FaultException<SRPersonInfo.CustomFaultMessage>fex)
            {
                ClsMsg.ShowErrMsg(fex.Message);
                Utils.Logger.Error(fex.ToString());
            }
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
            bgWait.ReportProgress(PubConstant.WaitMessageStatus.END);
        }

        private void bgWait_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    if (e.Result is SRPersonInfo.Person)
                    {
                        if (ClsMsg.ShowQuestionMsg("数据新增成功！\n 是否继续新增职员档案？") == DialogResult.Yes)
                        {
                            AddPersonData();
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
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
        }

        private void AddPersonData()
        {
            Model = new SRPersonInfo.Person()
            {
                DepCode = strDepCode,
            };
            personBindingSource.DataSource = Model;
        }

        public void LoadPersonData()
        {
            using (var Client = new SRPersonInfo.PersonServiceClient())
            {
                var ret = Client.GetPersonByCode(context.SessionID, this.strPersonCode);
                if(ret.IsSuccess && ret.Data !=null)
                {
                    Model = ret.Data as SRPersonInfo.Person;
                    personBindingSource.DataSource = Model;
                }
            }
        }

        private void barManager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                switch (e.Item.Name)
                {
                    case "bbtniSave":
                        if (string.IsNullOrEmpty(PersonCodeTextEdit.Text))
                        {
                            ClsMsg.ShowWarningEmptyMsg(ItemForPersonCode.Text);
                        }
                        else if (string.IsNullOrEmpty(PersonNameTextEdit.Text))
                        {
                            ClsMsg.ShowWarningEmptyMsg(ItemForPersonName.Text);
                        }
                        else if (string.IsNullOrEmpty(PersonTypeTextEdit.Text))
                        {
                            ClsMsg.ShowWarningEmptyMsg(ItemForPersonType.Text);
                        }
                        else if (IsOperatorCheckEdit.CheckState.Equals(CheckState.Checked) && string.IsNullOrEmpty(OparatorNameTextEdit.Text))
                        {
                            ClsMsg.ShowWarningEmptyMsg( ItemForOparatorName.Text);
                        }
                        else if (IsOperatorCheckEdit.CheckState.Equals(CheckState.Checked) && string.IsNullOrEmpty(ItemForOparatorCode.Text))
                        {
                            ClsMsg.ShowWarningEmptyMsg(ItemForOparatorCode.Text);
                        }
                        else if(bgWait.IsBusy == false)
                        {
                            if(ClsMsg.ShowQuestionMsg("是否保存该职员数据？") == DialogResult.Yes)
                            {
                                bgWait.RunWorkerAsync("SavePersonData");
                            }
                        }
                        break;
                    case "bbtniDelete":
                        if (string.IsNullOrEmpty(PersonCodeTextEdit.Text))
                        {
                            ClsMsg.ShowWarningEmptyMsg(ItemForPersonCode.Text);
                        }
                        else if (bgWait.IsBusy == false)
                        {
                            if(ClsMsg.ShowQuestionMsg("是否删除该职员数据？") == DialogResult.Yes)
                            {
                                bgWait.RunWorkerAsync("DeletePersonData");
                            }
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

        private void IsOperatorCheckEdit_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsOperatorCheckEdit.CheckState==(CheckState.Checked))
                {
                    OparatorCodeTextEdit.Properties.ReadOnly = false;
                    OparatorNameTextEdit.Properties.ReadOnly = false;
                }
                else if (IsOperatorCheckEdit.CheckState==(CheckState.Unchecked))
                {
                    OparatorCodeTextEdit.Properties.ReadOnly = true;
                    OparatorNameTextEdit.Properties.ReadOnly = true;
                    Model.OparatorCode = "";
                    Model.OparatorName = "";
                    //this.OparatorNameTextEdit.Text = null;
                    //this.OparatorCodeTextEdit.Text = null;
                }
            }
            catch (Exception ex)
            {
                ClsMsg.ShowInfoMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
        }

        private void OparatorNameTextEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (OparatorNameTextEdit.Properties.ReadOnly == false)
                {
                    var frmUser = new frmUserList(context);
                    if (frmUser.ShowDialog() == DialogResult.OK)
                    {
                        if (frmUser.Tag != null)
                        {
                            var UserModel = frmUser.Tag as Client.Utility.SRSysBase.User;
                            Model.OparatorName = UserModel.cUserName;
                            Model.OparatorCode = UserModel.cUserCode;
                            personBindingSource.DataSource = Model;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClsMsg.ShowInfoMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
        }
    }
}
