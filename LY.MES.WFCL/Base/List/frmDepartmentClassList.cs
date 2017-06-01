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

namespace LY.MES.WFCL.Base.List
{
    public partial class frmDepartmentClassList : BaseForm
    {
        private List<SRDepartment.Department> lstModel = null;
        private SRDepartment.Department Model = null;

        private string strDepartmentNameOriginal = null;
        private string strDepartmentNameNow = null;
        public frmDepartmentClassList(UserContext context)
            :base(context)
        {
            InitializeComponent();
            bgWait.ProgressChanged += this.backgroundWorker_ProgressChanged;
        }
        private void frmDepartmentClassList_Load(object sender, EventArgs e)
        {
            bgWait.RunWorkerAsync("InitDepartmentData");
            SetTextEditReadOnly("Check");
        }

        public void InitDepartmenList(DoWorkEventArgs e)
        { 
            using(SRDepartment.DepartmentServiceClient Client = new SRDepartment.DepartmentServiceClient())
            {
                var ret = Client.GetDepartmentList(context.SessionID);
                if(ret.IsSuccess)
                {
                    e.Result = ret.Data;
                }
            }
        }

        private void bgWait_DoWork(object sender, DoWorkEventArgs e)
        {
            bgWait.ReportProgress(0);
            try
            {
                switch (e.Argument.ToString())
                {
                    case"InitDepartmentData":
                        InitDepartmenList(e);
                        break;
                    case "SaveDepartmentClass":
                        if (DepCodeTextEdit.Properties.ReadOnly == false) //新增保存
                        {
                            AddDepartmentClass(e);
                        }
                        else if (DepCodeTextEdit.Properties.ReadOnly == true) //修改保存 
                        {
                            UpdataDepartmentClass(e);
                        }
                        if(e.Result.Equals(true))
                        {
                             InitDepartmenList(e);
                        }
                        break;
                    case"DeleteDepartmentClass":
                        DeleteDepartmentClass(e);
                        if(e.Result.Equals(true))
                        {
                           InitDepartmenList(e); 
                        }
                        break;
                    default:
                        break;
                }
            }
            catch(System.ServiceModel.FaultException<SRDepartment.CustomFaultMessage>fex)
            {
                bgWait.ReportProgress(102,fex.Message);
                Utils.Logger.Error(fex.ToString());
            }
            catch (Exception ex)
            {
                bgWait.ReportProgress(102,ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
            bgWait.ReportProgress(100);
        }

        private void bgWait_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if(e.Result != null)
                {
                    if(e.Result is SRDepartment.Department[])
                    {
                        lstModel = (e.Result as SRDepartment.Department[]).ToList();
                        LoadFristTree();
                        SetTextEditReadOnly("Check");
                        tvDepartmentClass.ExpandAll();
                        tvDepartmentClass.Focus();
                    }                    
                }
            }
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
        }

        public void AddDepartmentClass(DoWorkEventArgs e)
        {
            if (string.IsNullOrEmpty(DepCodeTextEdit.Text) == true)
            {
                 ClsMsg.ShowWarningEmptyMsg(ItemForDepCode.Text);
            }
            else if (string.IsNullOrEmpty(DepNameTextEdit.Text) == true)
            {
                 ClsMsg.ShowWarningEmptyMsg(ItemForDepName.Text);
            }
            else if (string.IsNullOrEmpty(GradeSpinEdit.Text) == true)
            {
                 ClsMsg.ShowWarningEmptyMsg(ItemForGrade.Text);
            }
            else if(ClsMsg.ShowQuestionMsg("是否保存本部门数据？") == DialogResult.Yes)
            {
                using (var AddClient = new SRDepartment.DepartmentServiceClient())
                {
                    departmentBindingSource.EndEdit();
                    Model = new SRDepartment.Department();
                    Model = departmentBindingSource.DataSource as SRDepartment.Department;
                    var ret = AddClient.AddDepartmentData(context.SessionID, Model);
                    if (ret.IsSuccess)
                    {
                        this.AddSysOperLogs(this.Text, OperateStatus.增加, strCode: Model.DepCode);
                        e.Result = true;
                        ClsMsg.ShowWarningMsg("新增数据成功！");
                    }
                    else
                    {
                        e.Result = false;
                        bgWait.ReportProgress(101,ret.Message);
                    }
                 }                
             }
        }

        public void UpdataDepartmentClass(DoWorkEventArgs e)
        {
            departmentBindingSource.EndEdit();
            this.strDepartmentNameNow = DepNameTextEdit.Text;
            Model = new SRDepartment.Department();
            Model = departmentBindingSource.DataSource as SRDepartment.Department;

            if (string.IsNullOrEmpty(DepNameTextEdit.Text))
            {
                ClsMsg.ShowWarningEmptyMsg(ItemForDepName.Text);
            }
            else
            { 
                if(ClsMsg.ShowQuestionMsg("是否修改该模板数据？") == DialogResult.Yes)
                {
                    using(var upClient = new SRDepartment.DepartmentServiceClient())
                    {
                        var ret = upClient.UpdataDepartmentData(context.SessionID, Model, strDepartmentNameOriginal, strDepartmentNameNow);
                        if(ret.IsSuccess)
                        {
                            this.AddSysOperLogs(this.Text, OperateStatus.修改, strCode: Model.DepCode);
                            e.Result = true;
                            ClsMsg.ShowWarningMsg("数据更新完毕！");
                        }
                        else
                        {
                            e.Result = false;
                            bgWait.ReportProgress(101, ret.Message);
                        }
                    }
                }
            }
        }

        public void DeleteDepartmentClass(DoWorkEventArgs e)
        {
            departmentBindingSource.EndEdit();
            if (string.IsNullOrEmpty(DepCodeTextEdit.Text))
            {
                ClsMsg.ShowWarningEmptyMsg(ItemForDepCode.Text);
            }
            else 
            {
                if(ClsMsg.ShowQuestionMsg("是否删除"+DepNameTextEdit.Text+"部门数据？") == DialogResult.Yes)
                {
                    using(var DelClient = new SRDepartment.DepartmentServiceClient())
                    {
                        Model = new SRDepartment.Department();
                        Model = departmentBindingSource.DataSource as SRDepartment.Department;
                        var ret = DelClient.DelDepartmentData(context.SessionID, Model.DepCode);
                        if (ret.IsSuccess)
                        {
                            this.AddSysOperLogs(this.Text, OperateStatus.删除, strCode: Model.DepCode);
                            e.Result = true;
                            ClsMsg.ShowWarningMsg("数据删除成功！");
                        }
                        else
                        {
                            e.Result = true;
                            bgWait.ReportProgress(101, ret.Message);
                        }
                    }
                }
            }
        }

        public void LoadFristTree()
        {
            tvDepartmentClass.Nodes.Clear();
            lstModel.Where(t => t.Grade == 0).OrderBy(t => t.DepCode).ToList().ForEach(item => {
                TreeNode fristNode = new TreeNode();
                fristNode.Name = item.DepCode;
                fristNode.Text = item.DepCode +" "+item.DepName;
                fristNode.Tag = item;
                fristNode.Nodes.AddRange(LoadChildTree(item.DepCode, item.Grade).ToArray());
                tvDepartmentClass.Nodes.Add(fristNode);
            });
        }

        public List<TreeNode> LoadChildTree(string strDepCode,int iGrade)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            lstModel.Where(t => t.SupDepCode == strDepCode && t.Grade == iGrade + 1).OrderBy(t=>t.DepCode).ToList().ForEach(items => {
                TreeNode childNode = new TreeNode();
                childNode.Name = items.DepCode;
                childNode.Text = items.DepCode +" "+items.DepName;
                childNode.Tag = items;
                childNode.Nodes.AddRange(LoadChildTree(items.DepCode,items.Grade).ToArray());
                nodes.Add(childNode);
            });
            return nodes;
        }

        private void tvDepartmentClass_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                departmentBindingSource.DataSource = e.Node.Tag as SRDepartment.Department;
                SetTextEditReadOnly("Check");
            }
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());    
            }
        }

        private void barManager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                switch (e.Item.Name)
                {
                    case"bbtniAdd":
                        Model = new SRDepartment.Department();
                        departmentBindingSource.DataSource = Model;
                        SetTextEditReadOnly("Add");
                        break;
                    case "bbtniUpdata":
                        if (string.IsNullOrEmpty(DepCodeTextEdit.Text))
                        {
                            ClsMsg.ShowWarningMsg("请先选择需要修改的模板！");
                        }
                        else 
                        {
                            SetTextEditReadOnly("Update");
                            departmentBindingSource.EndEdit();
                            this.strDepartmentNameOriginal = DepNameTextEdit.Text;                        
                        }
                        break;
                    case"bbtniDelete":
                        if (string.IsNullOrEmpty(DepCodeTextEdit.Text))
                        {
                            ClsMsg.ShowWarningMsg("请先选择需要删除的模板！");
                        }
                        else if (bgWait.IsBusy == false)
                        {
                            bgWait.RunWorkerAsync("DeleteDepartmentClass");
                        }
                        break;
                    case"bbtniSave":
                        if (DepCodeTextEdit.Properties.ReadOnly == true && DepNameTextEdit.Properties.ReadOnly == true)
                        {
                            ClsMsg.ShowWarningMsg("非“新增”、“修改”模式，保存无效！");
                        }
                        else if (bgWait.IsBusy == false)
                        {
                            bgWait.RunWorkerAsync("SaveDepartmentClass");
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

        public void SetTextEditReadOnly(string Sign)
        {
            try
            {
                switch (Sign)
                {
                    case"Check":
                        DepAddressTextEdit.Properties.ReadOnly = true;
                        DepBeginDateDateEdit.Properties.ReadOnly = true;
                        DepEmailTextEdit.Properties.ReadOnly = true;
                        DepEndDateTextEdit.Properties.ReadOnly = true;
                        DepFaxTextEdit.Properties.ReadOnly = true;
                        DepMemoTextEdit.Properties.ReadOnly = true;
                        DepCodeTextEdit.Properties.ReadOnly = true;
                        DepNameTextEdit.Properties.ReadOnly = true;
                        DepPersonTextEdit.Properties.ReadOnly = true;
                        DepPhoneTextEdit.Properties.ReadOnly = true;
                        DepPostCodeTextEdit.Properties.ReadOnly = true;
                        GradeSpinEdit.Properties.ReadOnly = true;
                        SupDepCodeTextEdit.Properties.ReadOnly = true;
                        break;
                    case "Add":
                        DepAddressTextEdit.Properties.ReadOnly = false;
                        DepBeginDateDateEdit.Properties.ReadOnly = false;
                        DepEmailTextEdit.Properties.ReadOnly = false;
                        DepEndDateTextEdit.Properties.ReadOnly = false;
                        DepFaxTextEdit.Properties.ReadOnly = false;
                        DepMemoTextEdit.Properties.ReadOnly = false;
                        DepCodeTextEdit.Properties.ReadOnly = false;
                        DepNameTextEdit.Properties.ReadOnly = false;
                        DepPersonTextEdit.Properties.ReadOnly = false;
                        DepPhoneTextEdit.Properties.ReadOnly = false;
                        DepPostCodeTextEdit.Properties.ReadOnly = false;
                        GradeSpinEdit.Properties.ReadOnly = true;
                        SupDepCodeTextEdit.Properties.ReadOnly = true;
                        break;
                    case "Update":
                        DepAddressTextEdit.Properties.ReadOnly = false;
                        DepBeginDateDateEdit.Properties.ReadOnly = false;
                        DepEmailTextEdit.Properties.ReadOnly = false;
                        DepEndDateTextEdit.Properties.ReadOnly = false;
                        DepFaxTextEdit.Properties.ReadOnly = false;
                        DepMemoTextEdit.Properties.ReadOnly = false;
                        DepCodeTextEdit.Properties.ReadOnly = true;;
                        DepNameTextEdit.Properties.ReadOnly = false;
                        DepPersonTextEdit.Properties.ReadOnly = false;
                        DepPhoneTextEdit.Properties.ReadOnly = false;
                        DepPostCodeTextEdit.Properties.ReadOnly = false;
                        GradeSpinEdit.Properties.ReadOnly = true;
                        SupDepCodeTextEdit.Properties.ReadOnly = true;
                        break;
                    case "AddChild":
                        DepAddressTextEdit.Properties.ReadOnly = false;
                        DepBeginDateDateEdit.Properties.ReadOnly = false;
                        DepEmailTextEdit.Properties.ReadOnly = false;
                        DepEndDateTextEdit.Properties.ReadOnly = false;
                        DepFaxTextEdit.Properties.ReadOnly = false;
                        DepMemoTextEdit.Properties.ReadOnly = false;
                        DepCodeTextEdit.Properties.ReadOnly = false;
                        DepNameTextEdit.Properties.ReadOnly = false;
                        DepPersonTextEdit.Properties.ReadOnly = false;
                        DepPhoneTextEdit.Properties.ReadOnly = false;
                        DepPostCodeTextEdit.Properties.ReadOnly = false;
                        GradeSpinEdit.Properties.ReadOnly = true;
                        SupDepCodeTextEdit.Properties.ReadOnly = true;
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

        private void cmsTreeMenu_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                tsmiAddChildren.Visible = (tvDepartmentClass.SelectedNode == null) ? false : true;
            }
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());  
            }
        }

        private void tsmiAddChildren_Click(object sender, EventArgs e)
        {
            try
            {
                if(tvDepartmentClass.SelectedNode != null)
                {
                    SetTextEditReadOnly("AddChild");
                    var SupModel = tvDepartmentClass.SelectedNode.Tag as SRDepartment.Department;
                    Model = new SRDepartment.Department()
                    {
                        SupDepCode = SupModel.DepCode,
                        //Grade = (Convert.ToInt32(GradeSpinEdit.Text) <= SupModel.Grade) ? SupModel.Grade + 1 : Convert.ToInt32(GradeSpinEdit.Text) 
                        Grade = SupModel.Grade + 1
                    };
                    departmentBindingSource.DataSource = Model;
                }
            }
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());  
            }
        }
    }
}
