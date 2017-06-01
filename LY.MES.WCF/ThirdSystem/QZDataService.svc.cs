using LY.MES.Service.ThirdSystem;
using Server.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.Data;
using LY.MES.Model.VModel;



namespace LY.MES.WCF.ThirdSystem
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“QZDataService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 QZDataService.svc 或 QZDataService.svc.cs，然后开始调试。
    public class QZDataService : IQZDataService
    {
        public System.Data.DataTable GetQualityInspector(string sessionId)
        {
            try
            {
                return new ForQZDBServices().GetQualityInspector();
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }

        public System.Data.DataTable GetOrderSchData(string sessionId, DataTable dtFilter, int PageSize, int CurrPage, ref int iTotalNum)
        {
            try
            {
                return new ForQZDBServices().GetOrderSchData(dtFilter, PageSize, CurrPage, ref iTotalNum);
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }



        public void GetOrderSchData1(string sessionId, int PageSize, int CurrPage, ref int iTotalNum)
        {
            try
            {
                var data = new ForQZDBServices().GetOrderSchData(null, PageSize, CurrPage, ref iTotalNum);
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }


        public DataTable GetPullCompute(string sessionId)
        {
            try
            {
                return new ForQZDBServices().GetPullCompute();
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }

        /// <summary>
        /// 获取工艺信息表
        /// </summary>
        /// <returns>返回DataTable对象:WorkShop(车间)、CraftsCode(工艺编号)、CraftsName(工艺名称)</returns>
        public DataTable GetCraftsTable(string sessionId)
        {
            try
            {
                return new ForQZDBServices().GetCraftsTable();
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }

        public DataTable GetQZRFIDCodeData(string sessionId, string RFIDCode)
        {
            try
            {
                return new ForQZDBServices().GetQZRFIDCodeData(RFIDCode);
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }

        public DataTable GetNewQZRFIDCodeData(string sessionId, string RFIDCode)
        {
            try
            {
                return new ForQZDBServices().GetNewQZRFIDCodeData(RFIDCode);
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }

        public DataTable GetQZZGData(string sessionId, DateTime SysTime)
        {
            try
            {
                return new ForQZDBServices().GetQZZGData(SysTime);
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }

        public DataTable GetQZWeight(string sessionId, DateTime StartTime, DateTime EndTime, string VarietyName, string Type)
        {
            try
            {
                return new ForQZDBServices().GetQZWeight(StartTime, EndTime, VarietyName, Type);
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }

        public DataTable GetRFIDWeight(string sessionId, string FormulaCode)
        {
            try
            {
                return new ForQZDBServices().GetRFIDWeight(FormulaCode);
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }

        public DataTable GetZGStatus(string sessionId)
        {
            try
            {
                return new ForQZDBServices().GetZGStatus();
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }

        public DataTable GetColorData(string sessionId, string FormulaCode)
        {
            try
            {
                return new ForQZDBServices().GetColorData(FormulaCode);
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }

        public DataTable GetQZFunColor(string sessionId)
        {
            try
            {
                return new ForQZDBServices().GetQZFunColor();
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }

        public DataTable GetRFIDData(string sessionId)
        {
            try
            {
                return new ForQZDBServices().GetRFIDData();
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }

        public DataTable GetNullZGColor(string sessionId)
        {
            try
            {
                return new ForQZDBServices().GetNullZGColor();
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }

        public DataTable GetL4Data1(string sessionId)
        {
            try
            {
                return new ForQZDBServices().GetL4Data1();

            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }


        public DataTable GetL5Data1(string sessionId)
        {
            try
            {
                return new ForQZDBServices().GetL5Data1();

            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }

        public object UpdateRFIDStatus(string sessionId, string RFIDNum)
        {
            try
            {
                return new ForQZDBServices().UpdateRFIDStatus(RFIDNum);

            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }

        public DataTable GetQZPcDataByJH(string sessionId, string JiHao)
        {
            try
            {
                return new ForQZDBServices().GetQZPcDataByJH(JiHao);
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }


        public DataTable GetQZPcDataByOrder(string sessionId, string Order)
        {
            try
            {
                return new ForQZDBServices().GetQZPcDataByOrder(Order);
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }


        public DataTable GetSJDataByJH(string sessionId, string line)
        {
            try
            {
                return new ForQZDBServices().GetSJDataByJH(line);
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }

        public object InsertSJData(string sessionId, sj_line model)
        {
            try
            {
                return new ForQZDBServices().InsertSJData(model);
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }


        public DataTable GetSJDataByPC(string sessionId)
        {
            try
            {
                return new ForQZDBServices().GetSJDataByPC();
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }


    }
}
