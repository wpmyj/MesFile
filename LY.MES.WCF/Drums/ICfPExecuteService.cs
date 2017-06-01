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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“ICfPExecute”。
    [ServiceContract]
    public interface ICfPExecuteService
    {





        /// <summary>
        /// 查询工艺参数设置主表和子表集合
        /// </summary>
        /// <param name="ID">编号</param>
        /// <returns>返回工艺参数主表和子表</returns>
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<CraftsProcessExecute, CraftsProcessExecuteDetail> GetCfPExecute(string sessionId, int ExecuteID);



        //[Server.Utility.CHKUserAuth]
        //[FaultContract(typeof(CustomFaultMessage))]
        //[OperationContract]
        //CommonResult<List<CraftsProcessExecute>> GetCfPExecute(string sessionId);


        //只查询主表字段
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<List<CraftsProcessExecute>> GetCfPExecutes(string sessionId, string ArrangedVouchCode);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<List<vw_DurmsUpFeeding>> GetDurmsUpFeedingByArrCode(string sessionId, string ArrangedVouchCode);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<List<vw_DurmsUpFeeding>> GetDurmsUpFeedingByDevCode(string sessionId, string DevCode);


        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<List<ArrangedVouchLog>> GetArrangedVouchLog(string sessionId);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<List<ArrangedVouchLog>> GetArrangedVouchLogByCode(string sessionId, string ArrangedVouchCode);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<ArrangedVouch> InsterArrVouchByVw(string sessionId, vw_DurmsUpFeeding model);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<ArrangedVouchLog> InsterArrVouchLog(string sessionId, ArrangedVouchLog model);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<CraftsProcessExecute> GeCraftsProcessdByWorkbrachName(string sessionId, string WorkbrachName);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<ArrangedVouch> GetArrangedBySameTime(string sessionId);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<ArrangedVouch> UpdateArrangedVouchCode(string sessionId, vw_DurmsUpFeeding model);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<CraftsProcessExecute> UpdateCraftsProcessExecute(string sessionId, string ArrangedVouchCode, int Order, int ExecuteStatus);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<vw_DurmsUpFeeding> Getvw_DurmsUpFeedingByWorkbrachName(string sessionId, string WorkbrachName);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<ArrangedVouch> UpdateArrangedVouchWeight(string sessionId, vw_DurmsUpFeeding model);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<ArrangedVouch> GetArrangedVouchCodeByLicensenNum(string sessionId, string LicenseNum);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<CraftsProcessExecute> GetCfPExecuteByArrangedVouchCode(string sessionId, string ArrangedVouchCode);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<bool> UpdateCraftsProcessByExID(string sessionId, string ArrangedVouchCode, int ExecuteID, int ExecuteStatus, Nullable<DateTime> StartTime = null, Nullable<DateTime> EndTime = null);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<Person> GetPersonByPerCode(string sessionId, string PerCode);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<DeviceWorkingCondition> GetDevStatusByCode(string sessionId, string DevCode);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<DeviceWorkingCondition> UpdateDevWStatusByCode(string sessionId, string DevCode, int WorkingStatus);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<vw_DurmsUpFeeding> Getvw_DurmsUpFeedingByLnum(string sessionId, string LicenseNum);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<List<IPRegistForm>> GetAllIPRegistForm(string sessionId);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<IPRegistForm> InsterRegistForm(string sessionId, IPRegistForm model);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<IPRegistForm> UpdateRegistForm(string sessionId, IPRegistForm model);

        [OperationContract]
        Server.Utility.CommonResult<IPRegistForm> DeleteRegistFormById(string sessionId, IPRegistForm model);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<bool> GetArrCuteByArrCode(string sessionId, string ArrangedVouchCode, int ExecuteOrder);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<bool> InsterCraProDataById(string sessionId, string ProPlanNum, vw_DurmsUpFeeding model);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        Server.Utility.CommonResult<CraftsProcessExecute> UpdateCraftsProcessData(string sessionId, string ProPlanNum, vw_DurmsUpFeeding model);

    }
}
