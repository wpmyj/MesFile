using LY.MES.Model;
using LY.MES.Service.CfPExecute;
using Server.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LY.MES.WCF.Drums
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“CfPExecute”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 CfPExecute.svc 或 CfPExecute.svc.cs，然后开始调试。
    public class CfPExecute : ICfPExecute
    {

        public CommonResult<CraftsProcessExecute, CraftsProcessExecuteDetail> GetCfPExecute(string sessionId, int ExecuteID)
        {
            try
            {
                return ForCfPExecute.GetInstance(sessionId).GetCfPExecute(ExecuteID);
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



        //public Server.Utility.CommonResult<List<CraftsProcessExecute>> GetCfPExecute(string sessionId)
        //{
        //    try
        //    {
        //        return ForCfPExecute.GetInstance(sessionId).GetCfPExecute();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
        //        {
        //            ErrorCode = ex.HResult,
        //            Message = ex.Message,
        //            StackTrace = ex.StackTrace
        //        }, ex.Message);
        //    }
        //}

        //只查询主表字段
        public Server.Utility.CommonResult<List<CraftsProcessExecute>> GetCfPExecutes(string sessionId)
        {
            try
            {
                //  return ForDeviceExecute.GetInstance(sessionId).GetDeviceExecute(strDeviCode);
                return ForCfPExecute.GetInstance(sessionId).GetCfPExecutes();
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

        public Server.Utility.CommonResult<List<vw_DurmsUpFeeding>> GetDurmsUpFeedingByArrCode(string sessionId, string ArrangedVouchCode)
        {

            try
            {

                return ForCfPExecute.GetInstance(sessionId).GetDurmsUpFeedingByArrCode(ArrangedVouchCode);

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

        public Server.Utility.CommonResult<List<vw_DurmsUpFeeding>> GetDurmsUpFeedingByDevCode(string sessionId, string DevCode)
        {

            try
            {

                return ForCfPExecute.GetInstance(sessionId).GetDurmsUpFeedingByDevCode(DevCode);

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


        public Server.Utility.CommonResult<List<ArrangedVouchLog>> GetArrangedVouchLog(string sessionId)
        {

            try
            {

                return ForCfPExecute.GetInstance(sessionId).GetArrangedVouchLog();

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

        public Server.Utility.CommonResult<List<ArrangedVouchLog>> GetArrangedVouchLogByCode(string sessionId, string ArrangedVouchCode)
        {

            try
            {

                return ForCfPExecute.GetInstance(sessionId).GetArrangedVouchLogByCode(ArrangedVouchCode);

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
        public Server.Utility.CommonResult<ArrangedVouch> InsterArrVouchByVw(string sessionId, vw_DurmsUpFeeding model)
        {
            try
            {
                return ForCfPExecute.GetInstance(sessionId).InsterArrVouchByVw(model);

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

        public Server.Utility.CommonResult<ArrangedVouchLog> InsterArrVouchLog(string sessionId, ArrangedVouchLog model)
        {
            try
            {
                return ForCfPExecute.GetInstance(sessionId).InsterArrVouchLog(model);
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

        public Server.Utility.CommonResult<CraftsProcessExecute> GeCraftsProcessdByWorkbrachName(string sessionId, string WorkbrachName)
        {
            try
            {
                return ForCfPExecute.GetInstance(sessionId).GeCraftsProcessdByWorkbrachName(WorkbrachName);
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

        public Server.Utility.CommonResult<ArrangedVouch> GetArrangedBySameTime(string sessionId)
        {
            try
            {
                return ForCfPExecute.GetInstance(sessionId).GetArrangedBySameTime();
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

        public Server.Utility.CommonResult<ArrangedVouch> UpdateArrangedVouchCode(string sessionId, vw_DurmsUpFeeding model)
        {
            try
            {
                return ForCfPExecute.GetInstance(sessionId).UpdateArrangedVouchCode(model);

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
        public Server.Utility.CommonResult<CraftsProcessExecute> UpdateCraftsProcessExecute(string sessionId, string ArrangedVouchCode, int Order, int ExecuteStatus)
        {
            try
            {
                return ForCfPExecute.GetInstance(sessionId).UpdateCraftsProcessExecute(ArrangedVouchCode, Order,ExecuteStatus);

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

        public Server.Utility.CommonResult<vw_DurmsUpFeeding> Getvw_DurmsUpFeedingByWorkbrachName(string sessionId, string WorkbrachName)
        {
            try
            {
                return ForCfPExecute.GetInstance(sessionId).Getvw_DurmsUpFeedingByWorkbrachName(WorkbrachName);
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

        public Server.Utility.CommonResult<ArrangedVouch> UpdateArrangedVouchWeight(string sessionId, vw_DurmsUpFeeding model)
        {
            try
            {
                return ForCfPExecute.GetInstance(sessionId).UpdateArrangedVouchWeight(model);

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


        public Server.Utility.CommonResult<ArrangedVouch> GetArrangedVouchCodeByLicensenNum(string sessionId, string LicenseNum)
        {
            try
            {
                return ForCfPExecute.GetInstance(sessionId).GetArrangedVouchCodeByLicensenNum(LicenseNum);

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

        public Server.Utility.CommonResult<CraftsProcessExecute> GetCfPExecuteByArrangedVouchCode(string sessionId, string ArrangedVouchCode)
        {
            try
            {
                return ForCfPExecute.GetInstance(sessionId).GetCfPExecuteByArrangedVouchCode(ArrangedVouchCode);

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

        public Server.Utility.CommonResult<bool>UpdateCraftsProcessByExID(string sessionId,string ArrangedVouchCode, int ExecuteID, int ExecuteStatus,Nullable<DateTime> StartTime = null,Nullable< DateTime> EndTime=null  )
        {
            try
            {
                return ForCfPExecute.GetInstance(sessionId).UpdateCraftsProcessByExID(ArrangedVouchCode, ExecuteID, ExecuteStatus, StartTime, EndTime);
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

        public Server.Utility.CommonResult<Person> GetPersonByPerCode(string sessionId, string PerCode)
        {
            try
            {
                return ForCfPExecute.GetInstance(sessionId).GetPersonByPerCode(PerCode);
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
