using LY.MES.Model;
using Server.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LY.MES.WCF.Base
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IPersonService”。
    [ServiceContract]
    public interface IPersonService
    {
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<Person> GetPersonByCode(string sessionId, string strCode);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<List<Person>> GetPersonList(string sessionId, Tuple<string, List<object>> tFilter, int PageSize, int CurrPage);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<Person> AddPersonData(string sessionId, Person Model);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<Person> UpdataPersonData(string sessionId, Person Model);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<bool> DelPersonData(string sessionId, string strPersonCode);
    }
}
