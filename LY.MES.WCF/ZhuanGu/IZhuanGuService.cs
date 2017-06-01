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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IZhuanGuService”。
    [ServiceContract]
    public interface IZhuanGuService
    {
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        DataTable GetZhuanGuStatus(string sessionId);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<string> GetDevExecuteId(string sessionId, string DevCode, string DevInterfaceNeme);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<DataSet> GetTempPressureTable(string sessionId,string PairCraftsName,string DevCode = null, string ArrangedVouchCode = null);
    }

}
