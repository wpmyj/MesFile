using LY.MES.Model;
using Server.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LY.MES.WCF.Dispatch
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IDispatchCenterSerivce”。
    [ServiceContract(CallbackContract = typeof(IDCToDoCallBack))]
    public interface IDispatchCenterSerivce
    {
        /// <summary>
        /// 上线
        /// </summary>
        /// <param name="sessionId"></param>
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        void OnLine(string sessionId);

        /// <summary>
        /// 离线
        /// </summary>
        /// <param name="sessionId"></param>
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        void OffLine(string sessionId);

        /// <summary>
        /// xxp 获取当前工作的排配单集合
        /// </summary>
        /// <param name="sessionId">会话</param>
        /// <returns>排配单</returns>
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<List<vw_ArrangedCraftsProcessExecute>> GetArrangedCraftsProcessExecuteList(string sessionId);

        /// <summary>
        /// xxp 获取当前工作的排配单集合
        /// </summary>
        /// <param name="ArrangedVouchCode">排配单号</param>
        /// <returns>排配单</returns>
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<List<vw_ArrangedCraftsProcessExecute>> GetArrangedCraftsProcessExecuteListByCode(string sessionId, string ArrangedVouchCode);

        /// <summary>
        /// 接收工艺流程
        /// </summary>
        /// <param name="model"></param>
        [OperationContract(IsOneWay = true)]
        void AcceptCraftsProcess(CraftsProcessExecute model);

        /// <summary>
        /// 接收工艺参数
        /// </summary>
        /// <param name="model"></param>
        [OperationContract(IsOneWay = true)]
        void AcceptCraftsProcessDetail(CraftsProcessExecuteDetail model);
    }

    /// <summary>
    /// 回调函数接口，在客户端实现。
    /// </summary>
    public interface IDCToDoCallBack
    {
        /// <summary>
        /// 开始工艺流转
        /// </summary>
        /// <param name="lstArrangedCrafts"></param>
        [OperationContract(IsOneWay = true)]
        void StartCraftsProcess(List<vw_ArrangedCraftsProcessExecute> lstArrangedCrafts);

        /// <summary>
        /// 发送工艺流转更改
        /// </summary>
        /// <param name="strArrangedVouchCode">排配单号</param>
        /// <param name="model"></param>
        [OperationContract(IsOneWay = true)]
        void SendCraftsProcess(ArrangedVouchExecute<CraftsProcessExecute> model);

        /// <summary>
        /// 发送工艺参数更改
        /// </summary>
        /// <param name="model"></param>
        [OperationContract(IsOneWay = true)]
        void SendCraftsProcessDetail(ArrangedVouchExecute<CraftsProcessExecuteDetail> model);

        /// <summary>
        /// 终止工艺流程
        /// </summary>
        /// <param name="strArrangedVouchCode">排配单号</param>
        [OperationContract(IsOneWay = true)]
        void StopCraftsProcess(string strArrangedVouchCode);

        /// <summary>
        /// 完成工艺流程
        /// </summary>
        /// <param name="strArrangedVouchCode">排配单号</param>
        [OperationContract(IsOneWay = true)]
        void CompleteCraftsProcess(string strArrangedVouchCode);

        /// <summary>
        /// 主管道阀门操作值
        /// </summary>
        /// <param name="strValveGroup">值</param>
        [OperationContract(IsOneWay = true)]
        void ValveGroupValue(string strValveGroup);

    }
}
