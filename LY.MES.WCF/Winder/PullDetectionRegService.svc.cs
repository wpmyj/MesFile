using LY.MES.Service.Winder;
using Server.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LY.MES.WCF.Winder
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“PullDetectionRegService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 PullDetectionRegService.svc 或 PullDetectionRegService.svc.cs，然后开始调试。
    public class PullDetectionRegService : IPullDetectionRegService
    {

        public CommonResult<Model.QC_PullDetectionReg> AddPullDetectionReg(string sessionId, Model.QC_PullDetectionReg model)
        {
            try
            {
                return ForPullDetectionRegServices.GetInstance(sessionId).AddPullDetectionReg(model);
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

        public CommonResult<Model.QC_PullDetectionReg> UpdatePullDetectionReg(string sessionId, Model.QC_PullDetectionReg model)
        {
            try
            {
                return ForPullDetectionRegServices.GetInstance(sessionId).UpdatePullDetectionReg(model);
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

        public CommonResult<bool> DelPullDetectionReg(string sessionId, int AutoId)
        {
            try
            {
                return ForPullDetectionRegServices.GetInstance(sessionId).DelPullDetectionReg(AutoId);
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

        public CommonResult<Model.QC_PullDetectionReg> GetPullDetectionRegAutoID(string sessionId, int AutoId)
        {
            try
            {
                return ForPullDetectionRegServices.GetInstance(sessionId).GetPullDetectionRegAutoID(AutoId);
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

        public CommonResult<List<Model.QC_PullDetectionReg>> GetPullDetectionRegPagedList(string sessionId, Tuple<string, object[]> TWhere, int PageSize, int CurrPage)
        {
            try
            {
                return ForPullDetectionRegServices.GetInstance(sessionId).GetPullDetectionRegPagedList(TWhere, PageSize, CurrPage);
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
