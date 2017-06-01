using LY.MES.Model;
using LY.MES.Service.Drums;
using LY.MES.WCF.Dispatch;
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
    public class CfPExecuteService : ICfPExecuteService
    {

        public CommonResult<CraftsProcessExecute, CraftsProcessExecuteDetail> GetCfPExecute(string sessionId, int ExecuteID)
        {
            try
            {
                return ForCfPExecuteServices.GetInstance(sessionId).GetCfPExecute(ExecuteID);
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
        public Server.Utility.CommonResult<List<CraftsProcessExecute>> GetCfPExecutes(string sessionId, string ArrangedVouchCode)
        {
            try
            {
                //  return ForDeviceExecute.GetInstance(sessionId).GetDeviceExecute(strDeviCode);
                return ForCfPExecuteServices.GetInstance(sessionId).GetCfPExecutes(ArrangedVouchCode);
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

                return ForCfPExecuteServices.GetInstance(sessionId).GetDurmsUpFeedingByArrCode(ArrangedVouchCode);

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

                return ForCfPExecuteServices.GetInstance(sessionId).GetDurmsUpFeedingByDevCode(DevCode);

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

                return ForCfPExecuteServices.GetInstance(sessionId).GetArrangedVouchLog();

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

                return ForCfPExecuteServices.GetInstance(sessionId).GetArrangedVouchLogByCode(ArrangedVouchCode);

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
                var result = ForCfPExecuteServices.GetInstance(sessionId).InsterArrVouchByVw(model);
                //对接调度中心
                //if (result.IsSuccess)
                //    DispatchCenterSerivce.DispatchArrangedCraftsProcessAsync(DisCenterHandler.Start, result.Data.ArrangedVouchCode);
                return result;
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
                return ForCfPExecuteServices.GetInstance(sessionId).InsterArrVouchLog(model);
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
                return ForCfPExecuteServices.GetInstance(sessionId).GeCraftsProcessdByWorkbrachName(WorkbrachName);
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
                return ForCfPExecuteServices.GetInstance(sessionId).GetArrangedBySameTime();
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
                return ForCfPExecuteServices.GetInstance(sessionId).UpdateArrangedVouchCode(model);

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
                var result = ForCfPExecuteServices.GetInstance(sessionId).UpdateCraftsProcessExecute(ArrangedVouchCode, Order, ExecuteStatus);
                if (result.IsSuccess)
                    DispatchCenterSerivce.DispatchArrangedCraftsProcessAsync(DisCenterHandler.UpdateCrafts, result.Data.ArrangedVouchCode, result.Data.ExecuteID);
                return result;

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
                return ForCfPExecuteServices.GetInstance(sessionId).Getvw_DurmsUpFeedingByWorkbrachName(WorkbrachName);
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
                return ForCfPExecuteServices.GetInstance(sessionId).UpdateArrangedVouchWeight(model);

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
                return ForCfPExecuteServices.GetInstance(sessionId).GetArrangedVouchCodeByLicensenNum(LicenseNum);

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
                return ForCfPExecuteServices.GetInstance(sessionId).GetCfPExecuteByArrangedVouchCode(ArrangedVouchCode);

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

        public Server.Utility.CommonResult<bool> UpdateCraftsProcessByExID(string sessionId, string ArrangedVouchCode, int ExecuteID, int ExecuteStatus, Nullable<DateTime> StartTime = null, Nullable<DateTime> EndTime = null)
        {
            try
            {
                return ForCfPExecuteServices.GetInstance(sessionId).UpdateCraftsProcessByExID(ArrangedVouchCode, ExecuteID, ExecuteStatus, StartTime, EndTime);
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
                return ForCfPExecuteServices.GetInstance(sessionId).GetPersonByPerCode(PerCode);

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

        public Server.Utility.CommonResult<DeviceWorkingCondition> GetDevStatusByCode(string sessionId, string DevCode)
        {
            try
            {
                return ForCfPExecuteServices.GetInstance(sessionId).GetDevStatusByCode(DevCode);
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

        public Server.Utility.CommonResult<DeviceWorkingCondition> UpdateDevWStatusByCode(string sessionId, string DevCode, int WorkingStatus)
        {
            try
            {
                return ForCfPExecuteServices.GetInstance(sessionId).UpdateDevWStatusByCode(DevCode, WorkingStatus);

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

        public Server.Utility.CommonResult<vw_DurmsUpFeeding> Getvw_DurmsUpFeedingByLnum(string sessionId, string LicenseNum)
        {
            try
            {
                return ForCfPExecuteServices.GetInstance(sessionId).Getvw_DurmsUpFeedingByLnum(LicenseNum);
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

        public CommonResult<List<IPRegistForm>> GetAllIPRegistForm(string sessionId)
        {
            try
            {
                return ForCfPExecuteServices.GetInstance(sessionId).GetAllIPRegistForm();

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


        public CommonResult<IPRegistForm> InsterRegistForm(string sessionId, IPRegistForm model)
        {
            try
            {
                return ForCfPExecuteServices.GetInstance(sessionId).InsterRegistForm(model);

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

        public CommonResult<IPRegistForm> UpdateRegistForm(string sessionId, IPRegistForm model)
        {
            try
            {
                return ForCfPExecuteServices.GetInstance(sessionId).UpdateRegistForm(model);

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

        public CommonResult<IPRegistForm> DeleteRegistFormById(string sessionId, IPRegistForm model)
        {
            try
            {
                return ForCfPExecuteServices.GetInstance(sessionId).DeleteRegistFormById(model);

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

        public CommonResult<bool> GetArrCuteByArrCode(string sessionId, string ArrangedVouchCode, int ExecuteOrder)
        {
            try
            {
                return ForCfPExecuteServices.GetInstance(sessionId).GetArrCuteByArrCode(ArrangedVouchCode, ExecuteOrder);
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

        public CommonResult<bool> InsterCraProDataById(string sessionId, string ProPlanNum, vw_DurmsUpFeeding model)
        {
            try
            {
                return ForCfPExecuteServices.GetInstance(sessionId).InsterCraProDataById(ProPlanNum, model);
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

        public CommonResult<CraftsProcessExecute> UpdateCraftsProcessData(string sessionId, string ProPlanNum, vw_DurmsUpFeeding model)
        {
            try
            {
                var result = ForCfPExecuteServices.GetInstance(sessionId).UpdateCraftsProcessData(ProPlanNum, model);
                //    对接调度中心
                if (result.IsSuccess)
                    DispatchCenterSerivce.DispatchArrangedCraftsProcessAsync(DisCenterHandler.Start, result.Data.ArrangedVouchCode);

                return result;
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
