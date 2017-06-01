using LY.MES.Model;
using Server.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LY.MES.WCF.Drums
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IArrangedVService”。
    [ServiceContract]
    public interface IArrangedVService
    {
        //查询
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<ArrangedVouch> GetArrangedVouchByCode(string sessionId, string ArrangedVouchCode);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<List<ArrangedVouch>> GetArrangedVouchList(string sessionId, Tuple<string, List<object>> tWhere, int PageSize, int CurrPage);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<ArrangedVouch> UdateArrUserStatusByArrCode(string sessionId, string ArrangedVouchCode, int UserStatus);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<List<ArrangedVouch>> GetArrangedVouchByMulaCode(string sessionId, string ForMulaCode, int UserStatus);
    }
}
