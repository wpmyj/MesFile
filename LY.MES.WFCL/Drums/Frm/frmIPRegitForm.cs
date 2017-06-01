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

namespace LY.MES.WFCL.Drums.Frm
{
    public partial class frmIPRegitForm : BaseForm
    {
        private SRCfPExecute.IPRegistForm model = null;

        public frmIPRegitForm(UserContext context)
            : base(context)
        {
            InitializeComponent();
            BgwWait.ProgressChanged += this.backgroundWorker_ProgressChanged;
        }

        private void barManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (BgwWait.IsBusy == false)
                {
                    switch (e.Item.Name)
                    {

                        case "bbtnseach":

                            BgwWait.RunWorkerAsync("SearchData");

                            bbtniAdd.Enabled = true;
                            bbtniSave.Enabled = false;
                            bbtniUpdate.Enabled = true;
                            bbtniDel.Enabled = true;

                            break;

                        case "bbtniAdd":

                            InsterData();

                            bbtniAdd.Enabled = false;
                            bbtniSave.Enabled = true;
                            bbtniUpdate.Enabled = false;
                            bbtniDel.Enabled = false;

                            break;
                        case "bbtniSave":

                            iPRegistFormBindingSource.EndEdit();

                            if (IPTextEdit.Text == "")
                            {
                                ClsMsg.ShowWarningMsg("IP为必填项，请输入完整数据!");
                            }

                            else if (ClsMsg.ShowQuestionMsg("是否要保存当前数据呢？") == DialogResult.Yes)
                            {
                                BgwWait.RunWorkerAsync("SaveData");
                            }

                            bbtniAdd.Enabled = true;
                            bbtniSave.Enabled = false;
                            bbtniUpdate.Enabled = true;
                            bbtniDel.Enabled = true;

                            break;
                        case "bbtniDel":
                            iPRegistFormBindingSource.EndEdit();
                            if (model != null && ClsMsg.ShowQuestionMsg("是否要删除当前数据呢?") == DialogResult.Yes)
                            {
                                BgwWait.RunWorkerAsync("DelData");
                            }

                            break;

                        case "bbtniUpdate":

                            iPRegistFormBindingSource.EndEdit();
                            if (model != null && ClsMsg.ShowQuestionMsg("是否要更新当前数据呢?") == DialogResult.Yes)
                            {
                                BgwWait.RunWorkerAsync("UpdData");
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

        private void frmIPRegitForm_Load(object sender, EventArgs e)
        {
            bbtniSave.Enabled = false;


        }

        private void BgwWait_DoWork(object sender, DoWorkEventArgs e)
        {

            BgwWait.ReportProgress(PubConstant.WaitMessageStatus.START);
            try
            {
                switch (e.Argument.ToString())
                {
                    case "SearchData":
                        using (SRCfPExecute.CfPExecuteServiceClient client = new SRCfPExecute.CfPExecuteServiceClient())
                        {

                            var ret = client.GetAllIPRegistForm(context.SessionID);
                            e.Result = ret.Data;

                        }

                        break;
                    case "SaveData":
                        using (SRCfPExecute.CfPExecuteServiceClient client = new SRCfPExecute.CfPExecuteServiceClient())
                        {

                            var ret = client.InsterRegistForm(context.SessionID, model);

                            if (ret.IsSuccess)
                            {
                                e.Result = client.GetAllIPRegistForm(context.SessionID).Data;

                                BgwWait.ReportProgress(99, "保存成功！");

                            }

                            break;
                        }
                    case "DelData":

                        using (SRCfPExecute.CfPExecuteServiceClient client = new SRCfPExecute.CfPExecuteServiceClient())
                        {
                            var ret = client.DeleteRegistFormById(context.SessionID, model);
                            if (ret.IsSuccess)
                            {
                                e.Result = client.GetAllIPRegistForm(context.SessionID).Data;
                                BgwWait.ReportProgress(99, "删除成功！");
                            }

                            break;
                        }
                    case "UpdData":


                        using (SRCfPExecute.CfPExecuteServiceClient client = new SRCfPExecute.CfPExecuteServiceClient())
                        {

                            var ret = client.UpdateRegistForm(context.SessionID, model);
                            if (ret.IsSuccess)
                            {
                                e.Result = client.GetAllIPRegistForm(context.SessionID).Data;
                                BgwWait.ReportProgress(99, "修改成功！");
                            }

                            break;
                        }
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                BgwWait.ReportProgress(101, ex.Message);
            }

            BgwWait.ReportProgress(PubConstant.WaitMessageStatus.END);

        }

        private void BgwWait_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                if (e.Result is SRCfPExecute.IPRegistForm[])
                {
                    gridControl1.RefreshDataSource();
                    iPRegistFormBindingSource1.DataSource = (e.Result as SRCfPExecute.IPRegistForm[]);

                }
            }
        }

        private void InsterData()
        {
            model = new SRCfPExecute.IPRegistForm();

            model.CreatorTime = DateTime.Now;
            model.CreatorName = context.UserName;
            model.Status = 0;

            iPRegistFormBindingSource.DataSource = model;

        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            var model1 = gridView1.GetRow(gridView1.FocusedRowHandle) as SRCfPExecute.IPRegistForm;
            model = new SRCfPExecute.IPRegistForm()
            {
                ID = model1.ID,
                IP = model1.IP,
                MACAddress = model1.MACAddress,
                Status = model1.Status,
                CreatorName = model1.CreatorName,
                CreatorTime = model1.CreatorTime,

            };
            iPRegistFormBindingSource.DataSource = model;
        }

    }
}
