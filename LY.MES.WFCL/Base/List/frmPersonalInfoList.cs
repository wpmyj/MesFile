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
using LY.MES.WFCL.SRPersonInfo;
using Client.Utility.Filter;
using LY.MES.WFCL.Base.Frm;

namespace LY.MES.WFCL.Base.List
{
    public partial class frmPersonalInfoList : BaseForm
    {
        List<SRDepartment.Department> lstModel = null;
        Paging Page = null;
        public frmPersonalInfoList(UserContext context)
            :base(context)
        {
            InitializeComponent();
            bgWait.ProgressChanged += backgroundWorker_ProgressChanged;
            lstModel = new List<SRDepartment.Department>();
            Page = gridViewPaging1.DataPaging;
            personInfobindingSource.DataSource = new SRPersonInfo.Person();
        }

        private void frmPersonalInfoList_Load(object sender, EventArgs e)
        {
            bgWait.RunWorkerAsync("LoadDepartmentData");
        }
        private void bgWait_DoWork(object sender, DoWorkEventArgs e)
        {
            bgWait.ReportProgress(PubConstant.WaitMessageStatus.START);
            try
            {
                switch (e.Argument.ToString())
                {
                    case"LoadDepartmentData":
                        LoadDepartmentData(e);
                        break;
                    case "LoadPersonData":
                        LoadPersonData(e);
                        break;
                    default:
                        break;
                }
            }
            catch (System.ServiceModel.FaultException<SRDepartment.CustomFaultMessage> dex)
            {
                bgWait.ReportProgress(PubConstant.WaitMessageStatus.ERROR,dex.Message);
                Utils.Logger.Error(dex.ToString());
            }
            catch(System.ServiceModel.FaultException<SRPersonInfo.CustomFaultMessage>fex)
            {
                bgWait.ReportProgress(PubConstant.WaitMessageStatus.ERROR, fex.Message);
                Utils.Logger.Error(fex.ToString());
            }
            catch (Exception ex)
            {
                bgWait.ReportProgress(PubConstant.WaitMessageStatus.ERROR, ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
            bgWait.ReportProgress(PubConstant.WaitMessageStatus.END);
        }

        private void bgWait_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if(e.Result != null)
                {
                    if (e.Result is SRDepartment.Department[])
                    {
                        lstModel = (e.Result as SRDepartment.Department[]).ToList();
                        LoadFristTree();

                    }
                    else if(e.Result is SRPersonInfo.Person[])
                    {
                        gcPerson.RefreshDataSource();
                        personInfobindingSource.DataSource = e.Result as SRPersonInfo.Person[];
                        this.gridViewPaging1.DataPaging = Page;
                        this.gridViewPaging1.PagingReflash();
                    }
                }
            }
            catch (Exception ex)
            {
                bgWait.ReportProgress(102, ex.Message);
                Utils.Logger.Error(ex.ToString());
            }

        }

        public void LoadDepartmentData(DoWorkEventArgs e)
        {
            try
            {
                using(var Client = new SRDepartment.DepartmentServiceClient())
                {
                    var ret = Client.GetDepartmentList(context.SessionID);
                    if(ret.IsSuccess)
                    {
                        e.Result = ret.Data;
                    }
                }
            }
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
        }

        public void LoadFristTree()
        {
            tvPersonInfo.Nodes.Clear();
            lstModel.Where(t => t.Grade == 0).OrderBy(t => t.DepCode).ToList().ForEach(item =>
            {
                TreeNode fristNode = new TreeNode();
                fristNode.Name = item.DepCode;
                fristNode.Text = item.DepName;
                fristNode.Tag = item;
                fristNode.Nodes.AddRange(LoadChildTree(item.DepCode, item.Grade).ToArray());
                tvPersonInfo.Nodes.Add(fristNode);
            });
        }

        public List<TreeNode> LoadChildTree(string strDepCode, int iGrade)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            lstModel.Where(t => t.SupDepCode == strDepCode && t.Grade == iGrade + 1).OrderBy(t => t.DepCode).ToList().ForEach(items =>
            {
                TreeNode childNode = new TreeNode();
                childNode.Name = items.DepCode;
                childNode.Text = items.DepName;
                childNode.Tag = items;
                childNode.Nodes.AddRange(LoadChildTree(items.DepCode, items.Grade).ToArray());
                nodes.Add(childNode);
            });
            return nodes;
        }
        private void tvPersonInfo_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if(tvPersonInfo.SelectedNode != null && bgWait.IsBusy == false)
                {
                    te_DepCode.Text = (e.Node.Tag as SRDepartment.Department).DepCode;
                    bgWait.RunWorkerAsync("LoadPersonData");
                }
            }
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
        }

        public void LoadPersonData(DoWorkEventArgs e)
        { 
            using(var Client = new SRPersonInfo.PersonServiceClient())
            {
                Tuple<StringBuilder, List<object>> dtFilter = Tuple.Create<StringBuilder, List<object>>(new StringBuilder(), new List<object>());
                dtFilter.Item1.Append("1 = 1");
                FilterProcess.MergeFilterCondition("DepCode",te_DepCode.Text, ref dtFilter);
                if (string.IsNullOrEmpty(te_PersonCode.Text) == false)
                    FilterProcess.MergeFilterCondition("PersonCode",te_PersonCode.Text,ref dtFilter);
                if (string.IsNullOrEmpty(te_PersonName.Text) == false)
                    FilterProcess.MergeFilterCondition("PersonName", te_PersonName.Text, ref dtFilter,"like");
                if (string.IsNullOrEmpty(te_PersonType.Text) == false)
                    FilterProcess.MergeFilterCondition("PersonType", te_PersonType.Text, ref dtFilter);

                int iPageSize = (int)Page.PageSize;
                int iCurrPage = (int)Page.CurrentPage;

                var ret = Client.GetPersonList(context.SessionID, Tuple.Create<string, object[]>(dtFilter.Item1.ToString(), dtFilter.Item2.ToArray()), iPageSize, iCurrPage);
                if(ret.IsSuccess)
                {
                    Page.CurrentPage = iCurrPage;
                    Page.RowCount = ret.TotalNum;
                    e.Result = ret.Data;
                }
            }
        }

        private void gridViewPaging1_PagingChanged(object sender, MyPagingEventArgs e)
        {
            try
            {
                if(bgWait.IsBusy == false)
                {
                    bgWait.RunWorkerAsync("LoadPersonData");
                }
            }
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
        }

        private void bt_Search_Click(object sender, EventArgs e)
        {
            try
            {
                if ((string.IsNullOrEmpty(te_DepCode.Text) == false || string.IsNullOrEmpty(te_PersonCode.Text) == false || string.IsNullOrEmpty(te_PersonName.Text) == false || string.IsNullOrEmpty(te_PersonType.Text) == false)&&bgWait.IsBusy == false)
                {
                    bgWait.RunWorkerAsync("LoadPersonData");
                }
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
                    case "bbtniAdd":
                        if (string.IsNullOrEmpty(te_DepCode.Text))
                        {
                            ClsMsg.ShowInfoMsg("请选择相应的部门！");
                        }
                        else
                        {
                           var frm= new frmPersonalInfo(context, te_DepCode.Text);
                           if(frm.ShowDialog()==DialogResult.OK)
                           {
                               bgWait.RunWorkerAsync("LoadPersonData");
                           }
                        }
                        break;
                    case "bbtniModify":
                        if (gvPerson.FocusedRowHandle >=0)
                        {
                            var model = gvPerson.GetRow(gvPerson.FocusedRowHandle) as SRPersonInfo.Person;
                            var fPI = new frmPersonalInfo(context, model.DepCode,model.PersonCode);
                            if(fPI.ShowDialog() == DialogResult.OK)
                            {
                                bgWait.RunWorkerAsync("LoadPersonData");
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

        private void gcPerson_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //if (gvPerson.FocusedRowHandle >= 0)
                //{
                //    var model = gvPerson.GetRow(gvPerson.FocusedRowHandle) as SRPersonInfo.Person;
                //    var fPI = new frmPersonalInfo(context, model.DepCode, model.PersonCode);
                //    fPI.Show();
                //}
                bbtniModify.PerformClick();
            }
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
        }

    }
}
