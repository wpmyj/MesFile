using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Server.Utility;
using LY.MES.Model;
using LY.MES.Service.Pipeline;
using LY.MES.WCF.Dispatch;

namespace LY.MES.WCF.Pipeline
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“PipelineService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 PipelineService.svc 或 PipelineService.svc.cs，然后开始调试。
    public class PipelineService : IPipelineService
    {

        public CommonResult<List<MainPipelineInfo>> GetOperatingRecord(string sessionId, Tuple<string, List<object>> tFilter, int CurrPage, int PageSize)
        {
            try
            {
                return ForPipelineServices.GetInstance(sessionId).GetOperatingRecord(tFilter, CurrPage, PageSize);
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

        public CommonResult<MainPipelineInfo> AddOperatingData(string sessionId, MainPipelineInfo model)
        {
            try
            {
                var ret = ForPipelineServices.GetInstance(sessionId).AddOperatingData(model);
                //xxp 20170515 添加主管道阀门操作推送调度中心
                if (ret.Data.DeveCode.Equals("MP001"))
                {
                    DispatchCenterSerivce.DispatchArrangedCraftsProcessAsync(DisCenterHandler.ValveGroup, ValveGroupValue: ret.Data.PromptDes);
                }
                return ret;
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

        public CommonResult<Device> GetDaviceData(string sessionId, string DevCode)
        {
            try
            {
                return ForPipelineServices.GetInstance(sessionId).GetDaviceData(DevCode);
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

        public CommonResult<Device> GetDaviceInformation(string sessionId, string DevCCode, string DevCode)
        {
            try
            {
                return ForPipelineServices.GetInstance(sessionId).GetDaviceInformation(DevCCode, DevCode);
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
