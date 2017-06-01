using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using LY.MES.Manage.ThirdSystem;
using Server.Utility.Logging;
using Server.Utility;
using LY.MES.Model.VModel;


namespace LY.MES.Service.ThirdSystem
{
    /// <summary>
    /// Author:xxp
    /// Remark:勤哲系统DB服务类
    /// CreateTime:20161108
    /// </summary>
    public class ForQZDBServices
    {

        /// <summary>
        /// 获取车间班次表质检数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetQualityInspector()
        {
            try
            {
                return new QZDBRepository().GetQualityInspector();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
        }


        public DataTable GetOrderSchData(DataTable dtFilter, int PageSize, int CurrPage, ref int iTotalNum)
        {
            try
            {
                return new QZDBRepository().GetOrderSchData(dtFilter, PageSize, CurrPage, ref iTotalNum);
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 获取拉力计算规则
        /// </summary>
        /// <returns>拉力计算规则集合</returns>
        public DataTable GetPullCompute()
        {
            try
            {
                return new QZDBRepository().GetPullCompute();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 获取工艺信息表
        /// </summary>
        /// <returns>返回DataTable对象:WorkShop(车间)、CraftsCode(工艺编号)、CraftsName(工艺名称)</returns>
        public DataTable GetCraftsTable()
        {
            try
            {
                return new QZDBRepository().GetCraftsTable();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
        }
        /// <summary>
        /// 根据RFID卡号获取勤哲上料数据 XCQ20161216
        /// </summary>
        /// <param name="RFIDCode"></param>
        /// <returns></returns>
        public DataTable GetQZRFIDCodeData(string RFIDCode)
        {
            try
            {
                return new QZDBRepository().GetQZRFIDCodeData(RFIDCode);
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 根据RFID卡号获取新的勤哲上料数据 XCQ20170227
        /// </summary>
        /// <param name="RFIDCode"></param>
        /// <returns></returns>
        public DataTable GetNewQZRFIDCodeData(string RFIDCode)
        {
            try
            {
                return new QZDBRepository().GetNewQZRFIDCodeData(RFIDCode);
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
        }


        public DataTable GetQZZGData(DateTime SysTime)
        {
            try
            {
                return new QZDBRepository().GetQZZGData(SysTime);
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
        }

        public DataTable GetQZWeight(DateTime StartTime, DateTime EndTime, string VarietyName, string Type)
        {
            try
            {
                return new QZDBRepository().GetQZWeight(StartTime, EndTime, VarietyName, Type);
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
        }

        public DataTable GetRFIDWeight(string FormulaCode)
        {
            try
            {
                return new QZDBRepository().GetRFIDWeight(FormulaCode);
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
        }

        public DataTable GetZGStatus()
        {
            try
            {
                return new QZDBRepository().GetZGStatus();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
        }

        public DataTable GetColorData(string FormulaCode)
        {
            try
            {
                return new QZDBRepository().GetColorData(FormulaCode);

            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
        }

        public DataTable GetQZFunColor()
        {
            try
            {
                return new QZDBRepository().GetQZFunColor();

            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
        }

        public DataTable GetRFIDData()
        {
            try
            {
                return new QZDBRepository().GetRFIDData();

            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }

        }

        public DataTable GetNullZGColor()
        {
            try
            {
                return new QZDBRepository().GetNullZGColor();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
        }

        public DataTable GetL4Data1()
        {


            try
            {
                return new QZDBRepository().GetL4Data1();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
        }
        /// <summary>
        /// 获取5号位置料缸重量
        /// </summary>
        /// <returns></returns>
        public DataTable GetL5Data1()
        {
            try
            {
                return new QZDBRepository().GetL5Data1();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }

        }

        public object UpdateRFIDStatus(string RFIDNum)
        {
            try
            {

                var result = new QZDBRepository().UpdateRFIDStatus(RFIDNum);
                return result;
                //using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                //{
                //    var result = new QZDBRepository().UpdateRFIDStatus(RFIDNum);
                //    ts.Complete();
                //    return result;
                //}

            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
        }

        public DataTable GetQZPcDataByJH(string JiHao)
        {
            try
            {
                return new QZDBRepository().GetQZPcDataByJH(JiHao);
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
        }

        public DataTable GetQZPcDataByOrder(string Order)
        {
            try
            {
                return new QZDBRepository().GetQZPcDataByOrder(Order);
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
        }

        public DataTable GetSJDataByJH(string line)
        {
            try
            {
                return new QZDBRepository().GetSJDataByJH(line);
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
        }

        public object InsertSJData(sj_line model)
        {
            try
            {
                return new QZDBRepository().InsertSJData(model);
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
        }

        public DataTable GetSJDataByPC()
        {
            try
            {
                return new QZDBRepository().GetSJDataByPC();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
        }
    }
}
