using LY.MES.Model;
using Server.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LY.MES.WCF.Pipeline
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IPipelineService”。
    [ServiceContract]
    public interface IPipelineService
    {
        #region 主管道操作方法
        [OperationContract, CHKUserAuth, FaultContract(typeof(CustomFaultMessage))]
        CommonResult<List<MainPipelineInfo>> GetOperatingRecord(string sessionId, Tuple<string, List<object>> tFilter, int CurrPage, int PageSize);

       [OperationContract, CHKUserAuth, FaultContract(typeof(CustomFaultMessage))]
       CommonResult<MainPipelineInfo> AddOperatingData(string sessionId, MainPipelineInfo model);

       [OperationContract, CHKUserAuth, FaultContract(typeof(CustomFaultMessage))]
       CommonResult<Device> GetDaviceData(string sessionId, string DevCode);

        #endregion

       [OperationContract, CHKUserAuth, FaultContract(typeof(CustomFaultMessage))]
       CommonResult<Device> GetDaviceInformation(string sessionId, string DevCCode, string DevCode);
    }
}
