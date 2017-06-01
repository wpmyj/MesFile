using LY.MES.Model;
using LY.MES.Model.VModel;
using Server.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LY.MES.WCF.DataColl
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IDeviceCollectService”。
    [ServiceContract]
    public interface IDeviceCollectService
    {
        [OperationContract, Server.Utility.CHKUserAuth, FaultContract(typeof(CustomFaultMessage))]
        CommonResult<List<VCollectDataInfo>> GetCollectDataPagedList(string sessionId,Tuple<string,List<object>>twhere ,int PageSize,int CurrPage);

        [OperationContract, Server.Utility.CHKUserAuth, FaultContract(typeof(CustomFaultMessage))]
        CommonResult<CollectDataInfo> AddZGParameter(string sessionId, CollectDataInfo model);

    }
}
