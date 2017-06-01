using Client.Utility;
using Client.Utility.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Utility.Logging;
using Client.Utility.Filter;

namespace LY.MES.WFCL.ZhuanGu.List
{
    public partial class ArrangedVouchCodeList : BaseForm
    {
        private SRArrangedVouch.ArrangedVServiceClient AVClient = null;
        private Paging Page = null;
        private ParameterMonitoring PMonit;
        public ArrangedVouchCodeList(UserContext context,ParameterMonitoring PM)
            :base(context)
        {
            InitializeComponent();
            Page = new Paging();
            this.PMonit = PM;
        }

        private void bt_Search_Click(object sender, EventArgs e)
        {
            try
            {
                if(bgWait.IsBusy == false)
                {
                    bgWait.RunWorkerAsync("LoadArrangedVouchCodeList");
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                ClsMsg.ShowInfoMsg(ex.Message);
            }
        }


        private void bgWait_DoWork(object sender, DoWorkEventArgs e)
        {
            bgWait.ReportProgress(0);
            try
            {
                switch (e.Argument.ToString())
                {
                    case "LoadArrangedVouchCodeList":
                        if (string.IsNullOrEmpty(te_Date.Text) == false)
                        {
                            using (AVClient = new SRArrangedVouch.ArrangedVServiceClient())
                            {
                                var mindate = Convert.ToDateTime(te_Date.Text).Date;
                                var maxdate = Convert.ToDateTime(te_Date.Text).Date.AddHours(23.99);
                                int iPageSize = (int)Page.PageSize;
                                int iCurrPage = (int)Page.CurrentPage;

                                Tuple<StringBuilder, List<object>> dtFilter = Tuple.Create<StringBuilder, List<object>>(new StringBuilder(), new List<object>());
                                dtFilter.Item1.Append("1=1");
                                FilterProcess.MergeFilterCondition("CreateTime", mindate, ref dtFilter,objValues1:maxdate, dataType: FilterProcess.DataType.DateTime);
                                //FilterProcess.MergeFilterCondition("CreateTime", maxdate, ref dtFilter, "<=", dataType: FilterProcess.DataType.DateTime);
                                FilterProcess.MergeFilterCondition("UserStatus", "1", ref dtFilter, "!=", dataType: FilterProcess.DataType.Int);

                                var ret = AVClient.GetArrangedVouchList(context.SessionID,Tuple.Create<string,object[]>(dtFilter.Item1.ToString(),dtFilter.Item2.ToArray()),iPageSize,iCurrPage);
                                if (ret.IsSuccess)
                                {
                                    Page.PageSize = iPageSize;
                                    Page.CurrentPage = iCurrPage;
                                    e.Result = ret.Data;
                                }
                                else
                                {
                                    ClsMsg.ShowInfoMsg(ret.Message);
                                }
                            }

                        }
                        else
                        {
                            ClsMsg.ShowWarningEmptyMsg(lb_Date.Text);
                        }
                        break;
                    default:
                        break;
                }

            }
            catch (FaultException<SRZhuanGu.CustomFaultMessage> fex)
            {
                bgWait.ReportProgress(102, fex.Message);
                Utils.Logger.Error(fex.ToString());
            }
            catch (Exception ex)
            {
                bgWait.ReportProgress(102, ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
            bgWait.ReportProgress(100);
        }

        private void bgWait_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    if (e.Result is SRArrangedVouch.ArrangedVouch[])
                    {
                        bindingSource.DataSource = (e.Result as SRArrangedVouch.ArrangedVouch[]);
                        if ((e.Result as SRArrangedVouch.ArrangedVouch[]).Count()==0)
                        {
                            ClsMsg.ShowInfoMsg(te_Date.Text + " 当天没有已完成的排配单！");
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

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gv_ArrangedVouchCode.FocusedRowHandle >= 0)
                {
                    var model = gv_ArrangedVouchCode.GetRow(gv_ArrangedVouchCode.FocusedRowHandle) as SRArrangedVouch.ArrangedVouch;

                    var value = model.ArrangedVouchCode;
                    PMonit.Tag = value;
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                ClsMsg.ShowInfoMsg(ex.Message);
            }
        }

        private void gridViewPaging1_PagingChanged(object sender, MyPagingEventArgs e)
        {
            try
            {
                if(bgWait.IsBusy == false)
                {
                    bgWait.RunWorkerAsync("LoadArrangedVouchCodeList");
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
