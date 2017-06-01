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

namespace LY.MES.WFCL.Base.List
{
    public partial class frmDevParamList : BaseForm
    {
        private string strDevCode = null;
        private Paging page;


        private SRDevice.DeviceParameter model = null;
        //  private List<SRDevice.DeviceParameter> lstModel = null;
        public frmDevParamList(UserContext context, string strDevCode, string strDevName)
            : base(context)
        {
            InitializeComponent();
            BgwWait.ProgressChanged += this.backgroundWorker_ProgressChanged;

            this.strDevCode = strDevCode;
            DevCodeTextEdit.Text = strDevCode;

            this.Text = string.Format("{0} -设备名称:{1}", Text, strDevName);
            gridViewPaging1.DataPaging.PageSize = 9;
            page = gridViewPaging1.DataPaging;
            bbtniSave.Enabled = false;


            BgwWait.RunWorkerAsync("SearchData");

            //    GetFirstData();


        }

        private void RemarkTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void BgwWait_DoWork(object sender, DoWorkEventArgs e)
        {
            //BgwWait.ReportProgress(0);



            try
            {
                switch (e.Argument.ToString())
                {

                    case "SaveData":

                        this.AddSysOperLogs(this.Text, OperateStatus.增加, strCode: model.DevpCode);

                        using (SRDevice.DeviceServiceClient client = new SRDevice.DeviceServiceClient())
                        {

                            var ret = client.AddDevParameter(context.SessionID, model);

                            if (ret.IsSuccess)
                            {
                                SearchData(e);
                                BgwWait.ReportProgress(99, "保存成功！");

                            }
                            break;
                        }
                    case "DelData":

                        this.AddSysOperLogs(this.Text, OperateStatus.删除, strCode: model.DevpCode);

                        using (SRDevice.DeviceServiceClient client = new SRDevice.DeviceServiceClient())
                        {
                            var ret = client.DelDevParameterByCode(context.SessionID, DevpCodeTextEdit.Text);
                            if (ret.IsSuccess)
                            {
                                SearchData(e);
                                BgwWait.ReportProgress(99, "删除成功！");
                            }

                            break;
                        }

                    case "SearchData":

                        //earchData(e);strDevCode

                        int iTotalNum = 1;
                        int iCurrPage = (int)page.CurrentPage;
                        int iPageSize = (int)page.PageSize;
                        //    int iPageSize = 2;


                        using (var client = new SRDevice.DeviceServiceClient())
                        {
                            var ret = client.GetDevParByCodePaging(context.SessionID, iPageSize, iCurrPage, ref iTotalNum, strDevCode);
                            if (ret.IsSuccess)
                            {
                                page.CurrentPage = iCurrPage;
                                page.RowCount = iTotalNum;
                                e.Result = ret.Data;
                            }
                            else
                                BgwWait.ReportProgress(101, ret.Message);
                        }
                        break;

                    case "UpdData":

                        this.AddSysOperLogs(this.Text, OperateStatus.修改, strCode: model.DevpCode);

                        using (SRDevice.DeviceServiceClient client = new SRDevice.DeviceServiceClient())
                        {

                            var ret = client.UpdatDevParameter(context.SessionID, model);

                            if (ret.IsSuccess)
                            {
                                SearchData(e);
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

        }

        private void SearchData(DoWorkEventArgs e)
        {
            using (SRDevice.DeviceServiceClient client = new SRDevice.DeviceServiceClient())
            {

                var ret = client.GetDevParameterByCode(context.SessionID, strDevCode);

                if (ret.IsSuccess)
                {
                    e.Result = ret.Data;

                }
            }
        }



        private void BgwWait_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            #region 测试搜索功能
            //using (SRDevice.DeviceServiceClient client = new SRDevice.DeviceServiceClient())
            //{

            //    var ret = client.GetDevParameterByCode(strDevCode);

            //    if (ret.IsSuccess)
            //    {
            //        deviceParameterBindingSource1.DataSource = ret.Data;
            //        //  BgwWait.ReportProgress(99, "保存成功！");
            //        //this.Invoke((MethodInvoker)delegate() { deviceParameterBindingSource1.DataSource = ret.Data; });

            //    }
            //} 
            #endregion

            if (e.Result != null)
            {
                if (e.Result is SRDevice.DeviceParameter[])
                {

                    deviceParameterBindingSource1.DataSource = e.Result;
                    this.gridViewPaging1.DataPaging = page;
                    this.gridViewPaging1.PagingReflash();


                }
            }




        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //    ClsMsg.ShowWarningMsg("测试增加功能!");
        }



        private void bmTool_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (BgwWait.IsBusy == false)
                {
                    switch (e.Item.Name)
                    {

                        case "bbtnseach":
                            BgwWait.RunWorkerAsync("SearchData");


                            break;

                        case "bbtniAdd":

                            DevpCodeTextEdit.Properties.ReadOnly = false;
                            model = new SRDevice.DeviceParameter()
                            {
                                DevCode = strDevCode
                            };
                            deviceParameterBindingSource.DataSource = model;
                            //  DevpCodeTextEdit.Properties.ReadOnly = true;

                            bbtniSave.Enabled = true;
                            bbtniUpdate.Enabled = false;

                            bbtniDel.Enabled = false;

                            //    ClsMsg.ShowWarningMsg("开启设备编辑模式!");

                            break;
                        case "bbtniSave":

                            //  deviceParameterBindingSource.DataSource = model;
                            //  model = new SRDevice.DeviceClass();
                            deviceParameterBindingSource.EndEdit();
                            //      if (this.DeviCodeTextEdit.Text != "" && this.DeviNameTextEdit.Text != "" && this.DevpCodeTextEdit.Text != "" && this.DataTypeTextEdit.Text != "" && this.DevpAddressTextEdit.Text != "" && this.SendFormatTextEdit.Text != "")
                            if (model == null || this.DevCodeTextEdit.Text == "" || this.DevpCodeTextEdit.Text == "" || this.DevpNameTextEdit.Text == "" || this.StandardValueTextEdit.Text == "" || this.MaxValueTextEdit.Text == "" || this.MinValueTextEdit.Text == "")
                            {
                                ClsMsg.ShowWarningMsg("请输入完整数据!");
                            }

                            else if (ClsMsg.ShowQuestionMsg("是否要保存当前数据呢？") == DialogResult.Yes)
                            {
                                BgwWait.RunWorkerAsync("SaveData");
                            }

                            break;
                        case "bbtniDel":
                            deviceParameterBindingSource.EndEdit();
                            if (model != null && ClsMsg.ShowQuestionMsg("是否要删除当前数据呢?") == DialogResult.Yes)
                            {
                                BgwWait.RunWorkerAsync("DelData");
                            }
                            break;

                        case "bbtniUpdate":

                            deviceParameterBindingSource.EndEdit();
                            if (model != null && ClsMsg.ShowQuestionMsg("是否要更新当前数据呢?") == DialogResult.Yes)
                            {
                                BgwWait.RunWorkerAsync("UpdData");
                            }
                            break;

                        case "bbtnExit":
                            this.Close();
                            break;


                        case "barButtonItem2":

                            if (BgwWait.IsBusy == false)
                            {
                                gridControl1.RefreshDataSource();
                                BgwWait.RunWorkerAsync("SearchData");
                            }

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

        private void DevParamter_Load(object sender, EventArgs e)
        {

        }

        private void bbtniSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.AddSysOperLogs(this.Text, OperateStatus.查询);
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            var model1 = gridView1.GetRow(gridView1.FocusedRowHandle) as SRDevice.DeviceParameter;
            model = new SRDevice.DeviceParameter()
            {
                DevCode = model1.DevCode,
                DevpCode = model1.DevpCode,
                DevpName = model1.DevpName,
                MaxValue = model1.MaxValue,
                MinValue = model1.MinValue,
                StandardValue = model1.StandardValue,
                Remark = model1.Remark,
                SerialPort = model1.SerialPort,
                BaudRate = model1.BaudRate,
                CheckBit = model1.CheckBit,
                DataBit = model1.DataBit,
                StopBit = model1.StopBit,
                ConvertType = model1.ConvertType,


            };
            deviceParameterBindingSource.DataSource = model;

            DevpCodeTextEdit.Properties.ReadOnly = true;
        }

        /// <summary>
        /// 获取首行数据用于初始显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void GetFirstData()
        {
            var model2 = gridView1.GetRow(1) as SRDevice.DeviceParameter;
            model = new SRDevice.DeviceParameter()
            {
                DevCode = model2.DevCode,
                DevpCode = model2.DevpCode,
                DevpName = model2.DevpName,
                MaxValue = model2.MaxValue,
                MinValue = model2.MinValue,
                StandardValue = model2.StandardValue,
                Remark = model2.Remark,
                ConvertType = model2.ConvertType

            };
            deviceParameterBindingSource.DataSource = model;

        }

        private void gridViewPaging1_PagingChanged(object sender, MyPagingEventArgs e)
        {

        }

        private void gridViewPaging1_PagingChanged_1(object sender, MyPagingEventArgs e)
        {
            if (BgwWait.IsBusy == false)
            {
                gridControl1.RefreshDataSource();
                BgwWait.RunWorkerAsync("SearchData");
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

    }
}
