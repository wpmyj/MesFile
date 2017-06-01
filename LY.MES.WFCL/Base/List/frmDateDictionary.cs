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
using Client.Utility;
using Client.Utility.Controls;
using Client.Utility.SRSysBase;

namespace LY.MES.WFCL.Base.List
{
    public partial class frmDateDictionary : BaseForm
    {
        Client.Utility.SRSysBase.SysBaseServiceClient SbsClient = null;
        private static UA_Enum Model = null;
        public frmDateDictionary(UserContext context)
            :base(context)
        {
            InitializeComponent();
        }
        private void frmDateDictionary_Load(object sender, EventArgs e)
        {
            SbsClient = new Client.Utility.SRSysBase.SysBaseServiceClient();
            Model = new UA_Enum();
            uAEnumBindingSource.DataSource = Model;
            SysCodeTextEdit.Properties.ReadOnly = true;
            AutoIDSpinEdit.Properties.ReadOnly = true;

            if(bgWait.IsBusy == false)
            {
                bgWait.RunWorkerAsync("LoadTreeDate");
            }
        }

        private void bgWait_DoWork(object sender, DoWorkEventArgs e)
        {
            bgWait.ReportProgress(PubConstant.WaitMessageStatus.START);
            try
            {
                switch (e.Argument.ToString())
                {
                    case "LoadTreeDate":
                        LoadTreeDate();
                        break;
                    case"LoadDateDictionaryList":
                        if(string.IsNullOrEmpty(te_Selected.Text) == false)
                        {
                            var ret = SbsClient.GetEnumByEnumType(context.SessionID,context.SysCode,te_Selected.Text);
                            e.Result = ret.Data;
                        }
                        break;
                    case "AddDateDictionary":
                        uAEnumBindingSource.EndEdit();
                        Model = uAEnumBindingSource.DataSource as UA_Enum;
                        var existornot = SbsClient.GetEnumByEnumType(context.SessionID, context.SysCode, Model.EnumType).Data;
                        var addret = SbsClient.AddEnum(context.SessionID,Model);
                        if (addret.Data)
                        {
                            if (existornot.Count() >0)
                            {
                                e.Result = true;
                            }
                            else
                            {
                                e.Result = "LoadTreeDate";
                            }
                            ClsMsg.ShowInfoMsg("新增数据成功！");
                        }
                        else
                        {
                            e.Result = false;
                            ClsMsg.ShowInfoMsg(addret.Message);
                        }
                        break;
                    case"DelDateDictionary":
                        uAEnumBindingSource.EndEdit();
                        Model = uAEnumBindingSource.DataSource as UA_Enum;
                        var delret = SbsClient.DelEnumByID(context.SessionID,Model.AutoID);
                        var existornot2 = SbsClient.GetEnumByEnumType(context.SessionID, context.SysCode, Model.EnumType).Data;
                        if (delret.Data)
                        {
                            if (existornot2.Count() > 0)
                            {
                                e.Result = true;
                            }
                            else
                            {
                                e.Result = "LoadTreeDate";
                            }
                            ClsMsg.ShowInfoMsg("数据删除成功！");
                        }
                        else
                        {
                            e.Result = false;
                            ClsMsg.ShowInfoMsg(delret.Message);
                        }
                        break;
                    case "UpdateDateDictionary":
                        uAEnumBindingSource.EndEdit();
                        Model = uAEnumBindingSource.DataSource as UA_Enum;
                        var upret = SbsClient.UpdateEnum(context.SessionID, Model);
                        if (upret.Data)
                        {
                            e.Result = true;
                            ClsMsg.ShowInfoMsg("数据更新成功！");
                        }
                        else
                        {
                            e.Result = false;
                            ClsMsg.ShowInfoMsg(upret.Message);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                ClsMsg.ShowInfoMsg(ex.Message);
            }
            bgWait.ReportProgress(PubConstant.WaitMessageStatus.END);
        }

        private void bgWait_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    if (e.Result is UA_Enum[])
                    {
                        bindingSource.DataSource = e.Result;
                    }
                    else if (e.Result is bool)
                    {
                        if ((bool)e.Result)
                        {
                            bgWait.RunWorkerAsync("LoadDateDictionaryList");
                        }
                    }
                    else if (e.Result.ToString() == "LoadTreeDate")
                    {
                        bgWait.RunWorkerAsync("LoadTreeDate");
                    }
                    Model = new UA_Enum();
                    uAEnumBindingSource.DataSource = Model;
                    EnumTypeTextEdit.Properties.ReadOnly = false;
                    TypeNameTextEdit.Properties.ReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                ClsMsg.ShowInfoMsg(ex.Message);
            }
        }
        public void LoadTreeDate()
        { 
            var ret = SbsClient.GetEnumBySysCode(context.SessionID,context.SysCode);
            if(ret != null)
            {
                this.Invoke((MethodInvoker)delegate() { tv_DateDictionary.Nodes.Clear(); });
                ret.Data.GroupBy(t => t.EnumType).ToList().ForEach(item => 
                {
                    TreeNode FristNode = new TreeNode();
                    var typename = ret.Data.Where(t => t.EnumType == item.Key).GroupBy(t => t.TypeName).FirstOrDefault().Key;
                    FristNode.Name = item.Key;
                    FristNode.Text = string.Format("{0}({1})", typename, item.Key);
                    FristNode.Tag = typename;
                    this.Invoke((MethodInvoker)delegate() { tv_DateDictionary.Nodes.Add(FristNode); });
                });
            }
        }

        private void tv_DateDictionary_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if(tv_DateDictionary.SelectedNode !=null)
                {
                    te_Selected.Text = e.Node.Name;
                }
                if(bgWait.IsBusy ==false)
                {
                    bgWait.RunWorkerAsync("LoadDateDictionaryList");
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                ClsMsg.ShowErrMsg(ex.Message);
            }
        }

        private void gc_DateDictionary_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if(gv_DateDictionary.FocusedRowHandle >=0)
                {
                    Model = gv_DateDictionary.GetRow(gv_DateDictionary.FocusedRowHandle) as UA_Enum;
                    uAEnumBindingSource.DataSource = Model;
                    EnumTypeTextEdit.Properties.ReadOnly = true;
                    TypeNameTextEdit.Properties.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                ClsMsg.ShowErrMsg(ex.Message);
            }
        }

        
        //新增字典类型
        private void tsmi_AddEnumType_Click(object sender, EventArgs e)
        {
            try
            {
                Model = new UA_Enum();
                Model.SysCode = context.SysCode;
                uAEnumBindingSource.DataSource = Model;
                EnumTypeTextEdit.Properties.ReadOnly = false;
                TypeNameTextEdit.Properties.ReadOnly = false;
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                ClsMsg.ShowInfoMsg(ex.Message);
            }
        }
        //新增字典子集
        private void tsmi_AddEnumSubset_Click(object sender, EventArgs e)
        {
            try
            {
                if (tv_DateDictionary.SelectedNode == null)
                {
                    ClsMsg.ShowInfoMsg("请先选择要增加子项的字典类型！");
                }
                else
                {
                    Model = new UA_Enum
                    {
                        EnumType = tv_DateDictionary.SelectedNode.Name,
                        TypeName = tv_DateDictionary.SelectedNode.Tag.ToString(),
                        SysCode = context.SysCode
                    };
                    uAEnumBindingSource.DataSource = Model;
                    EnumTypeTextEdit.Properties.ReadOnly = true;
                    TypeNameTextEdit.Properties.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                ClsMsg.ShowInfoMsg(ex.Message);
            }
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(EnumTypeTextEdit.Text))
                {
                    ClsMsg.ShowWarningEmptyMsg(ItemForEnumType.Text);
                }
                else if (string.IsNullOrEmpty(TypeNameTextEdit.Text))
                {
                    ClsMsg.ShowWarningEmptyMsg(ItemForTypeName.Text);
                }
                else if (string.IsNullOrEmpty(EnumCodeTextEdit.Text))
                {
                    ClsMsg.ShowWarningEmptyMsg(ItemForEnumCode.Text);
                }
                else if (string.IsNullOrEmpty(ItemForEnumCode.Text))
                {
                    ClsMsg.ShowWarningEmptyMsg(ItemForEnumName.Text);
                }
                else if (string.IsNullOrEmpty(IOrderTextEdit.Text))
                {
                    ClsMsg.ShowWarningEmptyMsg(ItemForIOrder.Text);
                }
                else if (string.IsNullOrEmpty(SysCodeTextEdit.Text))
                {
                    ClsMsg.ShowWarningEmptyMsg(ItemForSysCode.Text);
                }
                else
                { 
                    if(bgWait.IsBusy == false)
                    {

                        if (AutoIDSpinEdit.Text != "0")
                        {
                            if (ClsMsg.ShowQuestionMsg("是否保存修改后的数据？") == System.Windows.Forms.DialogResult.Yes)
                            {
                                bgWait.RunWorkerAsync("UpdateDateDictionary");
                            }
                        }
                        else
                        {
                            if (ClsMsg.ShowQuestionMsg("是否保存新增数据？") == System.Windows.Forms.DialogResult.Yes)
                            {
                                bgWait.RunWorkerAsync("AddDateDictionary");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                ClsMsg.ShowInfoMsg(ex.Message);
            }
        }

        private void bt_Del_Click(object sender, EventArgs e)
        {
            try
            {
                uAEnumBindingSource.EndEdit();
                Model = uAEnumBindingSource.DataSource as UA_Enum;
                if (Model.EnumType == null)
                {
                    ClsMsg.ShowInfoMsg("请选择要删除的数据");
                }
                else
                { 
                    if(bgWait.IsBusy == false)
                    {
                        if (ClsMsg.ShowQuestionMsg("是否要删除该字典名称？") == System.Windows.Forms.DialogResult.Yes)
                        {
                            bgWait.RunWorkerAsync("DelDateDictionary");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                ClsMsg.ShowInfoMsg(ex.Message);
            }
        }


    }
}
