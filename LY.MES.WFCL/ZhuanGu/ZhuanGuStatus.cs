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

namespace LY.MES.WFCL.ZhuanGu
{
    public partial class ZhuanGuStatus : BaseForm
    {
        DataTable dt = null;
        DataTable ret = null;
        System.Timers.Timer Timer1;
        private string strText;
        public SRZhuanGu.ZhuanGuServiceClient Client = new SRZhuanGu.ZhuanGuServiceClient();

        public ZhuanGuStatus(UserContext context)
            : base(context)
        {
            InitializeComponent();
            Timer1 = new System.Timers.Timer(5000);
            Timer1.Elapsed += new System.Timers.ElapsedEventHandler(LoadZhuanGuStatus);
            Timer1.AutoReset = true;

            //Client.InnerChannel.Closed += InnerChannel_Closed;
        }

        private void ZhuanGuStatus_Load(object sender, EventArgs e)
        {
            try
            {
                strText = layoutControlGroup2.Text;
                Timer1.Start();
               // gridView1.OptionsBehavior.Editable = false;
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
            }
        }

        public void  LoadZhuanGuStatus(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                using (var Client = new SRZhuanGu.ZhuanGuServiceClient())
                {
                    this.ret = Client.GetZhuanGuStatus(context.SessionID);
                    this.Invoke((MethodInvoker)delegate()
                    {
                        layoutControlGroup2.Text = strText;
                      //  if (ret.Rows.Count > 0)
                       // {
                            zgstatusbindingSource.DataSource = ret;
                            gridView1.Columns[0].Visible = false;
                            gridView1.Columns[2].Visible = false;
                            //gridView1.Columns.View.ViewCaptionHeight = 30;
                            dt = ret;
                      //  }
                    });
                }
            }
            catch (System.ServiceModel.EndpointNotFoundException enfex)
            {
                this.Invoke((MethodInvoker)delegate()
                {
                    layoutControlGroup2.Text = strText + "_与服务器断开连接";
                });
                Utils.Logger.Error(enfex.ToString());
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate()
                {
                    layoutControlGroup2.Text = strText + "_与服务器断开连接";
                });
                Utils.Logger.Error(ex.ToString());
            }
        }

        public static bool IsSame(DataTable dt1, DataTable dt2)
        {
            if (dt2 == null)
            {
                return false;
            }
            else
            {
                DataTable dt3 = new DataTable();
                dt3.Merge(dt1);
                dt3.AcceptChanges();

                dt3.Merge(dt2);
                DataTable dt4 = dt3.GetChanges();
                return dt4 == null || dt4.Rows.Count == 0;
            }
        }


        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.CellValue.ToString() == "0")
                {
                    e.DisplayText = "●";
                    e.Appearance.ForeColor = Color.Red;
                }
                if (e.CellValue.ToString() == "1")
                {
                    e.DisplayText = "●";
                    e.Appearance.ForeColor = Color.Yellow;
                }
                if (e.CellValue.ToString() == "2" || e.CellValue.ToString() == "98")
                {
                    e.DisplayText = "●";
                    e.Appearance.ForeColor = Color.Green;
                }
                if (e.CellValue.ToString() == "99")
                {
                    e.DisplayText = "✘";
                    e.Appearance.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                //this.Invoke((MethodInvoker)delegate()
                //{
                //    layoutControlGroup2.Text = ex.Message;
                //});
                Utils.Logger.Error(ex.ToString());
            }
        }

        private void ZhuanGuStatus_FormClosed(object sender, FormClosedEventArgs e)
        {
            Timer1.Stop();
        }

    }
}
