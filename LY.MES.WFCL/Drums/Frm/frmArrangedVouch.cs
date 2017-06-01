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

namespace LY.MES.WFCL.Drums.Frm
{
    public partial class frmArrangedVouch : BaseForm
    {
        private string strArrangedVouchCode;

        public frmArrangedVouch(UserContext context, string strArrangedVouchCode)
            : base(context)
        {
            InitializeComponent();
            gridView1.CustomDrawRowIndicator += new GridViewEventTool().GridView_CustomDrawRowIndicator;
            bgwWait.ProgressChanged += this.backgroundWorker_ProgressChanged;
            this.strArrangedVouchCode = strArrangedVouchCode;
        }

        private void frmArrangedVouch_Load(object sender, EventArgs e)
        {
            try
            {
                UserStatusLookUpEdit.Properties.DataSource = DataEnum.GetEnumData(context, "CF.UserStatus");
            }
            catch (Exception ex) { Utils.Logger.Error(ex.ToString()); }
            bgwWait.RunWorkerAsync();
        }

        private void bgwWait_DoWork(object sender, DoWorkEventArgs e)
        {
            bgwWait.ReportProgress(PubConstant.WaitMessageStatus.START);
            try
            {
                using (SRArrangedVouch.ArrangedVServiceClient client = new SRArrangedVouch.ArrangedVServiceClient())
                using (SRCfPExecute.CfPExecuteServiceClient client1 = new SRCfPExecute.CfPExecuteServiceClient())
                {
                    var ret = client.GetArrangedVouchByCode(context.SessionID, strArrangedVouchCode);
                    var ret1 = client1.GetArrangedVouchLogByCode(context.SessionID, strArrangedVouchCode);

                    if (ret.IsSuccess && ret1.IsSuccess)
                    {
                        this.Invoke((MethodInvoker)delegate()
                        {
                            arrangedVouchBindingSource.DataSource = ret.Data;
                            arrangedVouchLogBindingSource.DataSource = ret1.Data;
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                bgwWait.ReportProgress(PubConstant.WaitMessageStatus.ERROR, ex.Message);
            }
            bgwWait.ReportProgress(PubConstant.WaitMessageStatus.END);
        }
    }
}
