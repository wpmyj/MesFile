using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Server.Utility;
using LY.MES.Service.Base;

namespace LY.MES.WCF.Base
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“BaseService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 BaseService.svc 或 BaseService.svc.cs，然后开始调试。
    /// <summary>
    /// Author:xxp
    /// Remark：基础WCF服务
    /// CreateTime:20161209
    /// </summary>
    public class BaseService : IBaseService
    {
        #region 参数对照表
        public Server.Utility.CommonResult<Model.CraftsParameterContrast> AddCraftsParameterContrast(string sessionId, Model.CraftsParameterContrast model)
        {
            try
            {
                return ForBaseServices.GetInstance(sessionId).AddCraftsParameterContrast(model);
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

        public Server.Utility.CommonResult<Model.CraftsParameterContrast> UpdateCraftsParameterContrast(string sessionId, Model.CraftsParameterContrast model)
        {
            try
            {
                return ForBaseServices.GetInstance(sessionId).UpdateCraftsParameterContrast(model);
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

        public Server.Utility.CommonResult<Model.CraftsParameterContrast> GetCraftsParameterContrastListByID(string sessionId, int ID)
        {
            try
            {
                return ForBaseServices.GetInstance(sessionId).GetCraftsParameterContrastListByID(ID);
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

        public Server.Utility.CommonResult<bool> DelCraftsParameterContrastListByID(string sessionId, int ID)
        {
            try
            {
                return ForBaseServices.GetInstance(sessionId).DelCraftsParameterContrastListByID(ID);
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

        public Server.Utility.CommonResult<List<Model.CraftsParameterContrast>> GetCraftsParameterContrastList(string sessionId)
        {
            try
            {
                return ForBaseServices.GetInstance(sessionId).GetCraftsParameterContrastList();
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

        #endregion
    }
}
