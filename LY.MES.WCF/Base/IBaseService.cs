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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IBaseService”。
    /// <summary>
    /// Author:xxp
    /// Remark：基础WCF服务接口
    /// CreateTime:20161209
    /// </summary>
    [ServiceContract]
    public interface IBaseService
    {
        #region 参数对照表

        /// <summary>
        /// 增加参数对照表
        /// </summary>
        /// <param name="model">新增参数对照表</param>
        /// <returns>参数对照表</returns>
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<CraftsParameterContrast> AddCraftsParameterContrast(string sessionId, CraftsParameterContrast model);

        /// <summary>
        /// 增加参数对照表
        /// </summary>
        /// <param name="model">新增参数对照表</param>
        /// <returns>参数对照表</returns>
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<CraftsParameterContrast> UpdateCraftsParameterContrast(string sessionId, CraftsParameterContrast model);

        /// <summary>
        /// 获取单个参数对照表
        /// </summary>
        /// <param name="ID">编号</param>
        /// <returns></returns>
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<CraftsParameterContrast> GetCraftsParameterContrastListByID(string sessionId, int ID);

        /// <summary>
        /// 删除单个参数对照表
        /// </summary>
        /// <param name="ID">编号</param>
        /// <returns></returns>
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<bool> DelCraftsParameterContrastListByID(string sessionId, int ID);


        /// <summary>
        /// 获取参数对照表集合
        /// </summary>
        /// <returns>参数对照表集合</returns>
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<List<CraftsParameterContrast>> GetCraftsParameterContrastList(string sessionId);
        #endregion
    }
}
