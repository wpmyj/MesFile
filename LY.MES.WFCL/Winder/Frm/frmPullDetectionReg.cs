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
using System.ServiceModel;
using LY.MES.WFCL.Refer;
using Client.Utility.Protocol;

namespace LY.MES.WFCL.Winder.Frm
{

    /// <summary>
    /// Author:xxp
    /// Remark:拉力登记表
    /// CreateTime:20161107
    /// </summary>
    public partial class frmPullDetectionReg : BaseForm
    {
        private List<SRPullDetectionReg.QC_PullDetectionReg> lstModel = null;
        private SRPullDetectionReg.QC_PullDetectionReg model = null;
        private List<Tuple<string, string>> TProcessType = null;
        private DataTable dtPullRule = null;
        private MasterPort mp = new MasterPort();


        public frmPullDetectionReg(UserContext context)
            : base(context)
        {
            InitializeComponent();
            bgwWait.ProgressChanged += this.backgroundWorker_ProgressChanged;
            TProcessType = DataEnum.GetEnumData("wd.processtype");
            gridView1.CustomDrawRowIndicator += new GridViewEventTool().GridView_CustomDrawRowIndicator;

        }

        private void frmPullDetectionReg_Load(object sender, EventArgs e)
        {
            try
            {
                ProcessTypeSpinEdit.Properties.DataSource = TProcessType;
                AddFun();

                this.BeginInvoke((MethodInvoker)delegate()
                {
                    using (SRQZData.QZDataServiceClient client = new SRQZData.QZDataServiceClient())
                    {
                        var data = client.GetQualityInspector(context.SessionID);
                        this.Invoke((MethodInvoker)delegate()
                        {
                            QualityInspectorTextEdit.Properties.DataSource = data;
                        });
                        dtPullRule = client.GetPullCompute(context.SessionID);
                    }
                });
            }
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
        }

        #region Event

        private void barManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                qCPullDetectionRegBindingSource.EndEdit();
                switch (e.Item.Name)
                {
                    case "bbtniSave":

                        if (model.RegDate.ToString().IsNullOrEmpty())
                        {
                            ClsMsg.ShowWarningEmptyMsg(ItemForRegDate.Text);
                            RegDateDateEdit.Focus();
                        }
                        else if (model.QualityInspector.IsNullOrEmpty())
                        {
                            ClsMsg.ShowWarningEmptyMsg(ItemForQualityInspector.Text);
                            QualityInspectorTextEdit.Focus();
                        }
                        else if (model.Frequency.IsNullOrEmpty())
                        {
                            ClsMsg.ShowWarningEmptyMsg(ItemForFrequency.Text);
                            FrequencyTextEdit.Focus();
                        }
                        else if (model.ProductionLine.IsNullOrEmpty())
                        {
                            ClsMsg.ShowWarningEmptyMsg(ItemForProductionLine.Text);
                            ProductionLineTextEdit.Focus();
                        }
                        else if (model.OrderCode.IsNullOrEmpty())
                        {
                            ClsMsg.ShowWarningEmptyMsg(ItemForOrderCode.Text);
                            OrderCodeTextEdit.Focus();
                        }
                        else if (model.ProductLevel.IsNullOrEmpty())
                        {
                            ClsMsg.ShowWarningEmptyMsg(ItemForProductLevel.Text);
                            ProductLevelComboBoxEdit.Focus();
                        }
                        else if (model.TestResults.IsNullOrEmpty())
                        {
                            ClsMsg.ShowWarningEmptyMsg(ItemForTestResults.Text);
                            //TestResultsTextEdit.Focus();
                        }
                        else
                        {
                            if (ClsMsg.ShowQuestionMsg("是否要保存当前数据呢？") == DialogResult.Yes)
                            {
                                bgwWait.RunWorkerAsync("SaveData");
                            }
                        }
                        break;
                    case "bbtniStart":
                        if (bbtniStart.Caption.Equals("开始检测"))
                        {
                            if (model.ProductLevel.IsNullOrEmpty())
                            {
                                ClsMsg.ShowWarningEmptyMsg(ItemForProductLevel.Text);
                                ProductLevelComboBoxEdit.Focus();
                            }
                            else if (model.OrderType.IsNullOrEmpty())
                            {
                                ClsMsg.ShowWarningEmptyMsg(ItemForOrderType.Text);
                            }
                            else if (model.Width.HasValue == false)
                            {
                                ClsMsg.ShowWarningEmptyMsg(ItemForWidth.Text);
                            }
                            else if (model.Thick.HasValue == false)
                            {
                                ClsMsg.ShowWarningEmptyMsg(ItemForThick.Text);
                            }
                            else if (dtPullRule == null || dtPullRule.Rows.Count == 0)
                            {
                                ClsMsg.ShowWarningMsg("请先维护拉力检测计算规则！");
                            }
                            else
                            {
                                iNum = 0;
                                bool bSuccess = mp.Open("COM7");
                                if (bSuccess)
                                {
                                    timer1.Start();
                                    bbtniStart.Caption = "停止检测";
                                }
                                else
                                    ClsMsg.ShowWarningMsg(mp.modbusMsg);
                            }
                        }
                        else
                        {
                            timer1.Stop();
                            mp.Close();
                         //   model.ActualPull = 0;
                         //   model.TestResults = "aaa";
                         //   ItemCurrPull.Text = "0";
                            qCPullDetectionRegBindingSource.DataSource = model;
                            //#if DEBUG
                            //                            model.ActualPull = Convert.ToDecimal(textEdit1.Text);
                            //#endif


                            bbtniStart.Caption = "开始检测";
                        }
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

        /// <summary>
        /// 检测拉力计算
        /// </summary>
        /// <returns></returns>
        private string CheckPullRull()
        {
            decimal dCurrPull = model.ActualPull.Value;
            bool ifValue = true;
            if (model.ProductLevel.Equals("二级品")) //1、当产品级别为二级品时,根据实际拉力判断上下限;
            {
                var dFilterRows = dtPullRule.Select(string.Format("[产品级别]='{0}'", model.ProductLevel), "[优先级],[强度] asc");
                if (dFilterRows.Length == 0)
                {
                    ClsMsg.ShowWarningMsg(string.Format("检测拉力计算规则中,无产品级别=[{0}]的计算规则！",
                         model.ProductLevel));
                    return null;
                }
                var dRow = dFilterRows[0];
                var val = (new DataTable().Compute(string.Format("{0}+{1}>={2} and {2}>={1}-{3}", dRow["拉力上限"].ToString(), model.StandardPull.Value, dCurrPull, dRow["拉力下限"].ToString()), "")); //拉力上限+标准拉力>=实际拉力>=标准拉力-拉力下限
                ifValue = (Boolean)val;
            }
            else
            {
                if (model.Strength.ToString().Equals("40强") && model.OrderType.Equals("*AAR外贸订单") == false)  //2、产品级别为一级品 且强度等于40强 订单类型不等于外贸订单
                {
                    var val = (new DataTable().Compute(string.Format("{0}>={1} and {1}>={2}", model.Width * model.Thick * 40, dCurrPull, model.Width * model.Thick * 38), "")); //拉力上限(订单宽度*厚度*40)>=实际拉力>=拉力下限(订单宽度*厚度*38)
                    ifValue = (Boolean)val;
                }
                else
                {
                    string strfilter = string.Format("[产品级别]='{0}' and [订单类型]='{1}'", model.ProductLevel, model.OrderType);
                    var dFilterRows = dtPullRule.Select(strfilter, "[优先级],[强度] asc");
                    if (dFilterRows.Length == 0)
                    {
                        ClsMsg.ShowWarningMsg(string.Format("检测拉力计算规则中,无产品级别=[{0}]+订单类型=[{1}]的计算组合！",
                             model.ProductLevel, model.OrderType));
                        return null;
                    }
                    var dRow = dFilterRows[0];

                    if (dRow["产品级别"].ToString().Equals("一级品"))//3、产品级别为一级品 且强度不等于40强
                    {
                        if (dRow["订单类型"].ToString().Equals("*AAR外贸订单")) //3.1、订单类型：外贸订单
                        {
                            var val = (new DataTable().Compute(string.Format("{0}+{1}>={2} and {2}>={1}-{3}", dRow["拉力上限"].ToString(), model.StandardPull.Value, dCurrPull, dRow["拉力下限"].ToString()), "")); //拉力上限+标准拉力>=实际拉力>=标准拉力-拉力下限
                            ifValue = (Boolean)val;
                        }
                        else if (dRow["优先级"].ToString().Equals("4")) //3.2、优先级等于4
                        {
                            var dt = new DataTable();
                            DataRow dRow1 = null;
                            foreach (var item in dFilterRows)
                            {
                                var v = (Boolean)dt.Compute(string.Format("{0}{1} and {2}{3}", model.Width, item["宽度"].ToString(), model.Thick, item["厚度"].ToString()), "");
                                if (v)
                                {
                                    dRow1 = item;
                                    break;
                                }
                            }
                            if (dRow1 != null)
                            {
                                var val = (new DataTable().Compute(string.Format("{0}+{1}>={2} and {2}>={1}-{3}", dRow1["拉力上限"].ToString(), model.StandardPull.Value, dCurrPull, dRow1["拉力下限"].ToString()), "")); //拉力上限+标准拉力>=实际拉力>=标准拉力-拉力下限
                                ifValue = (Boolean)val;
                            }
                            else
                            {
                                ClsMsg.ShowWarningMsg(string.Format("检测拉力计算规则中,无产品级别=[{0}]+订单类型=[{1}]的计算范围！", model.ProductLevel, model.OrderType));
                                return null;
                            }
                        }
                    }
                }
            }
            return ifValue ? "合格" : "不合格";
        }

        private void bgwWait_DoWork(object sender, DoWorkEventArgs e)
        {
            bgwWait.ReportProgress(0);
            try
            {
                switch (e.Argument.ToString())
                {
                    case "SaveData":

                   
                      
                        using (SRPullDetectionReg.PullDetectionRegServiceClient client = new SRPullDetectionReg.PullDetectionRegServiceClient())
                        {
                            var ret = client.AddPullDetectionReg(context.SessionID, model);
                            this.AddSysOperLogs(this.Text, OperateStatus.增加);
                            if (ret.IsSuccess)
                            {
                                //bgwWait.ReportProgress(99, "保存成功！");
                                e.Result = ret.Data;
                            }
                            else
                            {
                                Utils.Logger.Debug("保存失败！" + ret.Message);
                            }
                        }

                      

                        break;
                    default:
                        break;
                }
            }
            catch (FaultException<SRPullDetectionReg.CustomFaultMessage> fex)
            {
                bgwWait.ReportProgress(102, fex.Message);
                Utils.Logger.Error(fex.ToString());
            }
            catch (Exception ex)
            {
                bgwWait.ReportProgress(102, ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
            bgwWait.ReportProgress(100);
        }

        private void bgwWait_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                if (e.Result is SRPullDetectionReg.QC_PullDetectionReg)
                {
                    if (lstModel == null)
                        lstModel = new List<SRPullDetectionReg.QC_PullDetectionReg>();
                    lstModel.Add(e.Result as SRPullDetectionReg.QC_PullDetectionReg);
                    qCPullDetectionRegBindingSource1.DataSource = lstModel;
                    gridControl1.RefreshDataSource();
                    //AddFun();
                }
            }
        }

        int iNum = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                iNum++;
                layoutControlGroup3.Text = string.Format("当前拉力值-读取{0}次数", iNum);
                Task.Run(() =>
                {
                    var ret = mp.GetPullDeviceValue();
                    string strValue = ret.Result;
                    if (strValue.Equals(ItemCurrPull.Text) == false) //当前拉力或记录当前拉力不一致
                    {
                        this.Invoke((MethodInvoker)delegate()
                        {

                            if(strValue!="0")
                            { 

                            ItemCurrPull.Text = strValue;
                            model.ActualPull = Convert.ToDecimal(strValue);
                            model.TestResults = CheckPullRull(); //计算规则
                            if (bgwWait.IsBusy == false  &&  model.ActualPull!=0 )
                                bgwWait.RunWorkerAsync("SaveData");  //自动保存

                            }


                        });



                    }

                });
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
            }
        }

        private void OrderCodeTextEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                frmOrderChoose frm = new frmOrderChoose(context);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    model.OrderType = frm.OrderType;
                    model.OrderCode = frm.OrderID;
                    model.ProductionLine = string.Format("{0}{1}", frm.Machine, frm.LineNum);
                    model.Strength = frm.Strength;
                    if (frm.Specifications.IsNullOrEmpty() == false)
                    {
                        model.Width = Convert.ToDecimal(frm.Specifications.Substring(0, 3)) / 10;
                        model.Thick = Convert.ToDecimal(frm.Specifications.Substring(3, 3)) / 100;
                    }
                    else
                    {
                        model.Width = 0;
                        model.Thick = 0;
                    }
                    model.StandardPull = model.Width * model.Thick * Convert.ToDecimal((frm.Strength.Replace("强", "")));
                }
            }
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            try
            {
                if (e.Column.FieldName.Equals("ProcessType"))
                {
                    var val = TProcessType.Where(t => t.Item1 == e.Value.ToString()).FirstOrDefault();
                    if (val != null)
                    {
                        e.DisplayText = val.Item2;
                    }
                }
            }
            catch (Exception ex)
            {
                ClsMsg.ShowErrMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
        }

        #endregion

        #region Method

        /// <summary>
        /// 新增数据
        /// </summary>
        private void AddFun()
        {
            ItemCurrPull.Text = "0";
            model = new SRPullDetectionReg.QC_PullDetectionReg()
            {
                RegDate = DateTime.Now,
                CreateDate = DateTime.Now,
                CreatePerson = context.UserName,
                ProductLevel = "一级品"
            };
            qCPullDetectionRegBindingSource.DataSource = model;
        }

        #endregion

    }
}
