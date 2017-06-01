using LY.MES.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LY.MES.Model.VModel;
using LY.MES.Service.DataColl;
using Server.Utility;


namespace LY.MES.WCF.DataColl
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IDevExecuteService”。
    [ServiceContract]
    public interface IDevExecuteService
    {
        [OperationContract]
        void DoWork();

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<List<DeviceExecute>> GetDeviceExecuteList(string sessionId);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<List<V_DV_DevExecute>> GetDevViewList(string sessionId);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]

        CommonResult<List<V_DV_DevExecute>> GetDevViewListByAddress(string sessionId, string Address);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]

        CommonResult<List<V_DV_DevExecute>> GetDevViewListByZGName(string sessionId, string Address);



        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]

        List<string> GetDevViewListAllAddress(string sessionId);


        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        List<string> GetDevViewListAllDevName(string sessionId);


        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]

        List<System.Linq.IGrouping<string, V_DV_DevExecute>> GetDevViewListAllIP(string sessionId);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]

        CommonResult<V_DV_DevExecute> GetDeviceExecuteByID(string sessionId, int strExctueID);

        /// <summary>
        /// xxp 获取设备的执行信息
        /// </summary>
        /// <param name="strDevCode">设备编码</param>
        /// <returns></returns>
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<List<V_DV_DevExecute>> GetDeviceExecuteByDevCode(string sessionId, string strDevCode);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<DeviceExecute> GetDeviceExecute(string sessionId, string strDeviCode);


        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]

        CommonResult<DeviceExecute> AddDeviceExecute(string sessionId, DeviceExecute model);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]

        CommonResult<DeviceExecute> UpdateDeviceExecute(string sessionId, DeviceExecute model);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]

        CommonResult<bool> DelDeviceExecute(string sessionId, int StrDeveCode);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<List<DeviceExecute>> GetDevExecutePagedList(string sessionId, Tuple<string, List<object>> tWhere, int PageSize, int CurrPage);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<List<V_DV_DevExecute>> GetViewExecIDByDeviName(string sessionId,string JiHao, string IrconTroughName, string Serial);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<List<V_DV_DevExecute>> GetViewExecIDByIrcon(string sessionId, string JiHao, string IrconTroughName );



    }
}
