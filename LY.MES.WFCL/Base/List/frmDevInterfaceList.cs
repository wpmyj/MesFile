using Client.Utility;
using Client.Utility.Controls;
using LY.MES.WFCL.Refer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Utility.Logging;
using System.Windows.Forms;

namespace LY.MES.WFCL.Base.List
{

    /// <summary>
    /// Author:pjh
    /// Remark:设备接口登记表
    /// CreateDate:20161021
    /// </summary>
    public partial class frmDevInterfaceList : BaseForm
    {
        private SRDevice.DeviceServiceClient client = null;
        private SRDevice.DeviceInterface table = null;
        private string strDevCode;
        private List<Tuple<String, string>> lstUserStatus = null;

        private Paging page;
        public frmDevInterfaceList(UserContext context, string strDevCode, string strDevName)
            : base(context)
        {
            InitializeComponent();
            this.strDevCode = strDevCode;
            this.DevCodeTextEdit.Text = strDevCode;
            this.Text = string.Format("{0} -设备名称:{1}", this.Text, strDevName);
            page = gridViewPaging1.DataPaging;
            this.bgwWait1.ProgressChanged += this.backgroundWorker_ProgressChanged;
            UseAuthProcess.FormButtonAuthProcess(this.Name, context, bmButton, null);
        }


        /// <summary>
        /// 窗体打开加载数据
        /// </summary>     
        private void Interface_Load(object sender, EventArgs e)
        {
            this.AddSysOperLogs(this.Text, OperateStatus.查询);
            this.WindowState = FormWindowState.Maximized;
            client = new SRDevice.DeviceServiceClient();
            bgwWait1.RunWorkerAsync("SearchData");
            lstUserStatus = DataEnum.GetEnumData("status");
            UserStatusEdit.Properties.DataSource = lstUserStatus;
            UserStatusEdit.EditValue = -1;
            this.DeviCodeTextEdit.Properties.ReadOnly = true;
            this.bbtnSave.Enabled = false;

        }

        #region Event

        /// <summary>
        /// 异步事务工作事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwWait_DoWork(object sender, DoWorkEventArgs e)
        {
            bgwWait1.ReportProgress(0);
            try
            {
                switch (e.Argument.ToString())
                {
                    case "SearchData":
                        string strDevCode = DevCodeTextEdit.Text;
                        int TotalNum = 0;
                        int CurrPage = (int)page.CurrentPage;
                        int PageSize = (int)page.PageSize;
                        using (var client = new SRDevice.DeviceServiceClient())
                        {
                            var ret = client.GetDeviceInterfaceList(context.SessionID, PageSize, CurrPage, ref TotalNum, strDevCode);
                            if (ret.IsSuccess)
                            {
                                page.CurrentPage = CurrPage;
                                page.RowCount = TotalNum;
                                e.Result = ret.Data;
                            }
                            else
                                bgwWait1.ReportProgress(101, ret.Message);
                        }
                        break;

                    case "SaveData":

                        this.AddSysOperLogs(this.Text, OperateStatus.增加, strCode: table.DeviCode);

                        using (SRDevice.DeviceServiceClient client = new SRDevice.DeviceServiceClient())
                        {

                            var ret = client.AddDeviceInterface(context.SessionID, table);

                            if (ret.IsSuccess)
                            {
                                SearchData(e);
                                bgwWait1.ReportProgress(99, "保存成功！");

                            }
                            break;
                        }
                    case "DelData":

                        this.AddSysOperLogs(this.Text, OperateStatus.删除, strCode: table.DeviCode);

                        using (SRDevice.DeviceServiceClient client = new SRDevice.DeviceServiceClient())
                        {
                            string DeviCode = this.DeviCodeTextEdit.Text;
                            string DevCode = this.DevCodeTextEdit.Text;
                            var ret = client.DelDeviceInterface(context.SessionID, DeviCode, DevCode);
                            if (ret.IsSuccess)
                            {
                                SearchData(e);
                                bgwWait1.ReportProgress(99, "删除成功！");
                            }
                            else
                            {
                                bgwWait1.ReportProgress(99, "不存在此数据！");
                            }

                            break;
                        }

                    case "UpdData":

                        this.AddSysOperLogs(this.Text, OperateStatus.修改, strCode: table.DeviCode);

                        using (SRDevice.DeviceServiceClient client = new SRDevice.DeviceServiceClient())
                        {

                            var ret = client.UpdateDeviceInterface(context.SessionID, table);

                            if (ret.IsSuccess)
                            {
                                SearchData(e);
                                bgwWait1.ReportProgress(99, "修改成功！");
                            }

                            break;
                        }
                    default:
                        break;
                }
            }
            catch (System.ServiceModel.FaultException<SRDevice.CustomFaultMessage> fex)
            {
                bgwWait1.ReportProgress(102, fex.Message);
                Utils.Logger.Error(fex.ToString());
            }
            catch (Exception ex)
            {
                bgwWait1.ReportProgress(102, ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
            bgwWait1.ReportProgress(100);
        }


        /// <summary>
        /// 异步控件完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwWait_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                if (e.Result is SRDevice.DeviceInterface[])
                {
                    gridControl1.RefreshDataSource();
                    deviceInterfaceBindingSource1.DataSource = (e.Result as SRDevice.DeviceInterface[]);
                    this.gridViewPaging1.DataPaging = page;
                    this.gridViewPaging1.PagingReflash();
                }
            }
        }


        /// <summary>
        /// 工具栏事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bmButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (bgwWait1.IsBusy == false)
                {
                    switch (e.Item.Name)
                    {
                        case "bbtnAdd1":

                            table = new SRDevice.DeviceInterface()
                            {
                                DevCode = strDevCode

                            };
                            deviceInterfaceBindingSource.DataSource = table;
                            this.DeviCodeTextEdit.Properties.ReadOnly = false;
                            this.bbtnModify.Enabled = false;
                            this.bbtnDel.Enabled = false;
                            this.bbtnSave.Enabled = true;
                            break;

                        case "bbtnSave":
                            deviceInterfaceBindingSource.EndEdit();
                            if (this.DeviCodeTextEdit.IsNullOrEmpty())
                            {
                                ClsMsg.ShowWarningMsg("无任何可保存的数据!");
                                return;
                            }
                            if (this.DeviCodeTextEdit.Text != "" && this.DeviNameTextEdit.Text != "" && this.DevpCodeTextEdit.Text != "" && this.DataTypeTextEdit.Text != "" && this.DevpAddressTextEdit.Text != "" && this.SendFormatTextEdit.Text != "")
                            {
                                if (ClsMsg.ShowQuestionMsg("是否要保存当前数据呢？") == DialogResult.Yes)
                                {
                                    bgwWait1.RunWorkerAsync("SaveData");
                                    this.DeviCodeTextEdit.Properties.ReadOnly = true;
                                    this.bbtnModify.Enabled = true;
                                    this.bbtnDel.Enabled = true;
                                    this.bbtnSave.Enabled = false;
                                }
                            }
                            else
                            {
                                ClsMsg.ShowWarningMsg("请填写完整，不能留空!");
                                return;
                            }


                            break;

                        case "bbtnDel":
                            deviceInterfaceBindingSource.EndEdit();
                            this.DeviCodeTextEdit.Properties.ReadOnly = true;
                            if (this.DeviCodeTextEdit.IsNullOrEmpty())
                            {
                                ClsMsg.ShowWarningMsg("请选中数据再进行删除！");
                                return;
                            }
                            if (ClsMsg.ShowQuestionMsg("是否要删除当前数据呢?") == DialogResult.Yes)
                            {
                                this.DeviNameTextEdit.Text = null;
                                this.RemarkTextEdit.Text = null;
                                this.SendFormatTextEdit.Text = null;
                                this.DevpAddressTextEdit.Text = null;
                                this.DevpCodeTextEdit.Text = null;
                                this.DataTypeTextEdit.Text = null;
                                bgwWait1.RunWorkerAsync("DelData");
                            }
                            break;

                        case "bbtnModify":

                            deviceInterfaceBindingSource.EndEdit();
                            this.DeviCodeTextEdit.Properties.ReadOnly = true;
                            if (this.DeviCodeTextEdit.IsNullOrEmpty())
                            {
                                ClsMsg.ShowWarningMsg("请选中数据再进行修改！");
                                return;
                            }
                            if (ClsMsg.ShowQuestionMsg("是否要更新当前数据呢?") == DialogResult.Yes)
                            {
                                bgwWait1.RunWorkerAsync("UpdData");
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
                ClsMsg.ShowErrMsg(ex.Message);
                Utils.Logger.Error(ex.ToString());
            }
        }


        private void SearchData(DoWorkEventArgs e)
        {
            int TotalNum = 0;
            int CurrPage = (int)page.CurrentPage;
            int PageSize = (int)page.PageSize;
            using (SRDevice.DeviceServiceClient client = new SRDevice.DeviceServiceClient())
            {
                var ret = client.GetDeviceInterfaceList(context.SessionID, PageSize, CurrPage, ref TotalNum, strDevCode);

                if (ret.IsSuccess)
                {
                    page.CurrentPage = CurrPage;
                    page.RowCount = TotalNum;
                    e.Result = ret.Data;

                }
            }

        }

        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewPaging1_PagingChanged(object sender, MyPagingEventArgs e)
        {
            if (bgwWait1.IsBusy == false)
            {
                gridControl1.RefreshDataSource();
                bgwWait1.RunWorkerAsync("SearchData");
            }
        }


        #endregion


        #region Method
        /// <summary>
        /// 列表填入值转换  由int类型转为填入string类型
        /// </summary>      
        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "UserStatus")
            {
                if (e.Value != null)
                {
                    var model = lstUserStatus.Where(t => t.Item1 == e.Value.ToString()).FirstOrDefault();
                    if (model != null)
                        e.DisplayText = model.Item2;
                }
            }
        }


        /// <summary>
        /// 单击选择参数列表数据
        /// </summary> 
        private void DevpCodeTextEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                frmParChoose frmpar = new frmParChoose(context);
                if (frmpar.ShowDialog() == DialogResult.OK)
                {
                    DevpCodeTextEdit.Text = frmpar.DevpCode;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 双击获取列表数据
        /// </summary>       
        private void gridControl1_DoubleClick_1(object sender, EventArgs e)
        {
            var table1 = gridView1.GetRow(gridView1.FocusedRowHandle) as SRDevice.DeviceInterface;
            table = new SRDevice.DeviceInterface()
            {
                DevCode = table1.DevCode,
                DeviCode = table1.DeviCode,
                DeviName = table1.DeviName,
                SendFormat = table1.SendFormat,
                UserStatus = table1.UserStatus,
                Remark = table1.Remark,
                DevpCode = table1.DevpCode,
                DevpAddress = table1.DevpAddress,
                IsTwoWay = table1.IsTwoWay,
                DataType = table1.DataType,
                ConAccAddress = table1.ConAccAddress

            };

            deviceInterfaceBindingSource.DataSource = table;
        }

        #endregion
    }
}