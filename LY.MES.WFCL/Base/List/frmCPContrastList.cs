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
using LY.MES.WFCL.VModel;

namespace LY.MES.WFCL.Base.List
{

    /// <summary>
    /// Author:xxp
    /// Remark:工艺参数对照表
    /// CreateTime:20161209
    /// </summary>
    public partial class frmCPContrastList : BaseForm
    {
        private List<CPContrast> lstCPContrast = new List<CPContrast>();

        public frmCPContrastList(UserContext context)
            : base(context)
        {
            InitializeComponent();
            bgwWait.ProgressChanged += this.backgroundWorker_ProgressChanged;
            gridView1.CustomDrawRowIndicator += new GridViewEventTool().GridView_CustomDrawRowIndicator;
        }

        private void frmCPContrastList_Load(object sender, EventArgs e)
        {
            bgwWait.RunWorkerAsync("LoadData");
            var ParamTypeData = DataEnum.GetEnumData(context, "CF.ParamType");
            if (ParamTypeData.Count > 0)
            {
                ParamTypeData.ForEach(t =>
                {
                    this.repositoryItemComboBox1.Items.Add(t.Item1);
                });
            }
        }

        #region Event

        private void barManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                switch (e.Item.Name)
                {
                    case "bbtniAddRow":
                        if (lstCPContrast != null)
                        {
                            lstCPContrast.Add(new CPContrast() { Editprop = "A" });
                            cPContrastBindingSource.DataSource = lstCPContrast;
                            gridControl1.RefreshDataSource();
                        }
                        break;
                    case "bbtniDelRow":
                        if (gridView1.FocusedRowHandle >= 0 && bgwWait.IsBusy == false)
                        {
                            gridView1.CloseEditor();
                            gridView1.UpdateCurrentRow();
                            var model = gridView1.GetRow(gridView1.FocusedRowHandle) as CPContrast;
                            if (model.Editprop.IsNullOrEmpty())
                            {
                                if (ClsMsg.ShowQuestionMsg("是否删除选中行呢？") == DialogResult.Yes)
                                {
                                    bgwWait.RunWorkerAsync("DelData");
                                }
                            }
                            else
                            {
                                lstCPContrast.Remove(model);
                                cPContrastBindingSource.DataSource = lstCPContrast;
                                gridControl1.RefreshDataSource();
                            }
                        }
                        break;
                    case "bbtniSave":
                        if (bgwWait.IsBusy == false && lstCPContrast != null)
                        {
                            if (ClsMsg.ShowQuestionMsg("是否要保存当前列表数据呢？") == DialogResult.Yes)
                            {
                                gridView1.CloseEditor();
                                gridView1.UpdateCurrentRow();
                                cPContrastBindingSource.EndEdit();
                                bool bEdit = false;
                                for (int i = 0; i < lstCPContrast.Count; i++)
                                {
                                    var m = lstCPContrast[i];
                                    if (m.Editprop.IsNullOrEmpty() == false)
                                    {
                                        bEdit = true;
                                        if (m.ParamName.IsNullOrEmpty())
                                        {
                                            ClsMsg.ShowWarningMsg(string.Format("第{0}行参数名称不能为空！", (i + 1).ToString()));
                                            return;
                                        }
                                        //else if (m.DevepName.IsNullOrEmpty())
                                        //{
                                        //    ClsMsg.ShowWarningMsg(string.Format("第{0}行设备参数名称不能为空！", (i + 1).ToString()));
                                        //    return;
                                        //}
                                    }
                                }
                                if (bEdit)
                                {
                                    bgwWait.RunWorkerAsync("SaveData");
                                }
                            }
                        }
                        break;
                    case "bbtniRefer":
                        if (bgwWait.IsBusy == false)
                        {
                            bgwWait.RunWorkerAsync("LoadData");
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
                Utils.Logger.Error(ex.ToString());
                ClsMsg.ShowErrMsg(ex.Message);
            }
        }

        private void bgwWait_DoWork(object sender, DoWorkEventArgs e)
        {
            bgwWait.ReportProgress(PubConstant.WaitMessageStatus.START);
            try
            {
                switch (e.Argument.ToString())
                {
                    case "LoadData":
                        LoadData(e);
                        break;
                    case "DelData":
                        using (SRBase.BaseServiceClient client = new SRBase.BaseServiceClient())
                        {
                            var model = gridView1.GetRow(gridView1.FocusedRowHandle) as CPContrast;
                            var ret = client.DelCraftsParameterContrastListByID(context.SessionID, model.ParameterID);
                            if (ret.IsSuccess)
                            {
                                e.Result = ret.Data;
                            }
                            else
                            {
                                bgwWait.ReportProgress(PubConstant.WaitMessageStatus.WARNING, ret.Message);
                            }
                        }
                        break;
                    case "SaveData":

                        using (SRBase.BaseServiceClient client = new SRBase.BaseServiceClient())
                        {
                            var modelList = lstCPContrast.Where(t => t.Editprop.IsNullOrEmpty() == false);
                            foreach (var item in modelList)
                            {
                                var model = Utils.ObjectMapper<SRBase.CraftsParameterContrast, CPContrast>(item);
                                if (item.Editprop == "A")
                                {
                                    var ret = client.AddCraftsParameterContrast(context.SessionID, model);
                                }
                                else
                                {
                                    var ret = client.UpdateCraftsParameterContrast(context.SessionID, model);
                                }
                            }
                            bgwWait.ReportProgress(PubConstant.WaitMessageStatus.PROMPT, "保存成功！");

                            LoadData(e);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (System.ServiceModel.FaultException<SRBase.CustomFaultMessage> fex)
            {
                Utils.Logger.Error(fex.ToString());
                bgwWait.ReportProgress(PubConstant.WaitMessageStatus.ERROR, fex.Message);
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
            if (e.Result != null)
            {
                if (e.Result is SRBase.CraftsParameterContrast[])
                {
                    lstCPContrast = new List<CPContrast>();
                    (e.Result as SRBase.CraftsParameterContrast[]).ToList().ForEach(item =>
                    {
                        lstCPContrast.Add(new CPContrast(item));
                    });
                    cPContrastBindingSource.DataSource = lstCPContrast;
                }
                else if (e.Result is bool)
                {
                    if (Convert.ToBoolean(e.Result))
                    {
                        lstCPContrast.Remove(gridView1.GetRow(gridView1.FocusedRowHandle) as CPContrast);
                        cPContrastBindingSource.DataSource = lstCPContrast;
                        gridControl1.RefreshDataSource();
                        ClsMsg.ShowInfoMsg("删除成功！");
                    }
                }
            }
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //处理编辑标志
            var model = lstCPContrast[e.RowHandle];
            if (model.Editprop.IsNullOrEmpty())
            {
                model.Editprop = "E";
            }
        }

        #endregion

        #region Method
        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="e"></param>
        private void LoadData(DoWorkEventArgs e)
        {
            using (SRBase.BaseServiceClient client = new SRBase.BaseServiceClient())
            {
                var ret = client.GetCraftsParameterContrastList(context.SessionID);
                if (ret.IsSuccess)
                {
                    e.Result = ret.Data;
                }
                else
                {
                    bgwWait.ReportProgress(PubConstant.WaitMessageStatus.WARNING);
                }
            }
        }



        #endregion


    }
}
