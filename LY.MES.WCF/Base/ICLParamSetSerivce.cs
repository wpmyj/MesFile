using LY.MES.Model;
using LY.MES.Model.VModel;
using Server.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LY.MES.WCF.Base
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“ICLParamSet”。
    [ServiceContract]
    public interface ICLParamSetSerivce
    {
        /// <summary>
        /// 新增工艺参数设置数据
        /// </summary>
        /// <param name="model">主表数据</param>
        /// <param name="listModels">子表数据</param>
        /// <returns></returns>
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<CraftsLineParamSet, VCraftsLineParamSetDetail> AddCLParamSet(string sessionId, CraftsLineParamSet model, List<VCraftsLineParamSetDetail> listModels);


        /// <summary>
        /// 更新工艺参数设置
        /// </summary>
        /// <param name="model">主表数据</param>
        /// <param name="listModels">子表数据</param>
        /// <returns>更新是否成功</returns>
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<CraftsLineParamSet, VCraftsLineParamSetDetail> UpdateCLParamSet(string sessionId, CraftsLineParamSet model, List<VCraftsLineParamSetDetail> listModels);

        /// <summary>
        /// 删除工艺参数设置
        /// </summary>
        /// <param name="ID">编号</param>
        /// <returns></returns>
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<bool> DelCLParamSet(string sessionId, int ID);

        /// <summary>
        /// 获取设备分类集合
        /// </summary>
        /// <returns>返回处理结果</returns>
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<List<CraftsLineParamSet>> GetCLParamSetList(string sessionId);

        /// <summary>
        /// 查询工艺参数设置主表和子表集合
        /// </summary>
        /// <param name="ID">编号</param>
        /// <returns>返回工艺参数主表和子表</returns>
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<CraftsLineParamSet, VCraftsLineParamSetDetail> GetCLParamSetsList(string sessionId, int ID);
    }
}
