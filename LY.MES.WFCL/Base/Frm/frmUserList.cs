using Client.Utility;
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
using Client.Utility.Controls;

namespace LY.MES.WFCL.Base.Frm
{
    public partial class frmUserList : BaseForm
    {
        Client.Utility.SRSysBase.SysBaseServiceClient SbsClient = null;
        private List<Client.Utility.SRSysBase.User> UserList = null;
        public frmUserList(UserContext context)
            : base(context)
        {
            InitializeComponent();
            SbsClient = new Client.Utility.SRSysBase.SysBaseServiceClient();
            bgWait.RunWorkerAsync("LoadUserData");
        }

        private void bgWait_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                switch (e.Argument.ToString())
                {
                    case"LoadUserData":
                        var ret = SbsClient.GetBaseUserList(context.SessionID);
                        if(ret.IsSuccess)
                        {
                            if (string.IsNullOrEmpty(te_UserName.Text) && string.IsNullOrEmpty(te_UserCode.Text))
                            {
                                UserList = ret.Data.ToList();
                            }
                            else if (string.IsNullOrEmpty(te_UserName.Text) == false )
                            {
                                UserList = ret.Data.Where(t => t.cUserName == te_UserName.Text).ToList();                              
                            }
                            else if (string.IsNullOrEmpty(te_UserCode.Text) == false)
                            {
                                UserList = ret.Data.Where(t => t.cUserCode == te_UserCode.Text).ToList();  
                            }
                            e.Result = UserList;
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                ClsMsg.ShowInfoMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
        }
        private void bgWait_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if(e.Result != null)
                {
                    UserbindingSource.DataSource = e.Result as List<Client.Utility.SRSysBase.User>;
                }
            }
            catch (Exception ex)
            {
                ClsMsg.ShowInfoMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());  
            }
        }

        private void gcUser_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gvUser.FocusedRowHandle >= 0)
                {
                    var ret = gvUser.GetRow(gvUser.FocusedRowHandle) as Client.Utility.SRSysBase.User;
                    this.Tag = ret;
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                ClsMsg.ShowInfoMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
        }

        private void bt_Search_Click(object sender, EventArgs e)
        {
            try
            {
               bgWait.RunWorkerAsync("LoadUserData");
            }
            catch (Exception ex)
            {
                ClsMsg.ShowInfoMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());    
            }
        }
    }
}
