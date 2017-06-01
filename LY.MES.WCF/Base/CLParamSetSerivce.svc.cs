using LY.MES.Model;
using LY.MES.Model.VModel;
using LY.MES.Service.Base;
using Server.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LY.MES.WCF.Base
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“CLParamSet”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 CLParamSet.svc 或 CLParamSet.svc.cs，然后开始调试。
    public class CLParamSetSerivce : ICLParamSetSerivce
    {

        public CommonResult<CraftsLineParamSet, VCraftsLineParamSetDetail> AddCLParamSet(string sessionId, CraftsLineParamSet model, List<VCraftsLineParamSetDetail> listModels)
        {
            try
            {
                return ForCLParamSetServices.GetInstance(sessionId).AddCLParamSet(model, listModels);
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

        public CommonResult<CraftsLineParamSet, VCraftsLineParamSetDetail> UpdateCLParamSet(string sessionId, CraftsLineParamSet model, List<VCraftsLineParamSetDetail> listModels)
        {
            try
            {
                return ForCLParamSetServices.GetInstance(sessionId).UpdateCLParamSet(model, listModels);
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

        public CommonResult<bool> DelCLParamSet(string sessionId, int ID)
        {
            try
            {
                return ForCLParamSetServices.GetInstance(sessionId).DelCLParamSet(ID);
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

        public CommonResult<List<CraftsLineParamSet>> GetCLParamSetList(string sessionId)
        {
            try
            {
                return ForCLParamSetServices.GetInstance(sessionId).GetCLParamSetList();
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

        public CommonResult<CraftsLineParamSet, VCraftsLineParamSetDetail> GetCLParamSetsList(string sessionId, int ID)
        {
            try
            {
                return ForCLParamSetServices.GetInstance(sessionId).GetCLParamSetsList(ID);
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
