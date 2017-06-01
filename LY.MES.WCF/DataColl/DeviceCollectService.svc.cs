using LY.MES.Model;
using LY.MES.Service.DataColl;
using Server.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LY.MES.WCF.DataColl
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“DeviceCollectService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 DeviceCollectService.svc 或 DeviceCollectService.svc.cs，然后开始调试。
    public class DeviceCollectService : IDeviceCollectService
    {
        public Server.Utility.CommonResult<List<Model.VModel.VCollectDataInfo>> GetCollectDataPagedList(string sessionId, Tuple<string, List<object>> twhere, int PageSize, int CurrPage)
        {
            try
            {
                return ForDeviceCollectServices.GetInstance(sessionId).GetCollectDataPagedList(twhere, PageSize, CurrPage);
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

        public CommonResult<CollectDataInfo> AddZGParameter(string sessionId, CollectDataInfo model)
        {
            try
            {
                return ForDeviceCollectServices.GetInstance(sessionId).AddZGParameter(model);
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                    {
                        ErrorCode = ex.HResult,
                        Message = ex.Message,
                        StackTrace = ex.StackTrace
                    },ex.Message);
            }
        }

    }
}

