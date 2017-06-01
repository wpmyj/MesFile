using LY.MES.Service.ZhuanGu;
using Server.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LY.MES.WCF.ZhuanGu
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“ZhuanGuService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 ZhuanGuService.svc 或 ZhuanGuService.svc.cs，然后开始调试。
    public class ZhuanGuService : IZhuanGuService
    {
        public DataTable GetZhuanGuStatus(string sessionId)
        {
            try
            {
                return ForZhuanGuServices.GetInstance(sessionId).GetZhuanGuStatus();
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

        public CommonResult<string> GetDevExecuteId(string sessionId, string DevCode, string DevInterfaceNeme)
        {
            try
            {
                return ForZhuanGuServices.GetInstance(sessionId).GetDevExecuteId(DevCode, DevInterfaceNeme);
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


        public CommonResult<DataSet> GetTempPressureTable(string sessionId,string PairCraftsName,string DevCode = null, string ArrangedVouchCode = null)
        {
            try
            {
                return ForZhuanGuServices.GetInstance(sessionId).GetTempPressureTable(PairCraftsName,DevCode, ArrangedVouchCode);
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
