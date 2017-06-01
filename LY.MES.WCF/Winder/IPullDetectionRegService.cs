using LY.MES.Model;
using Server.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LY.MES.WCF.Winder
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IPullDetectionRegService”。
    [ServiceContract]
    public interface IPullDetectionRegService
    {

        #region 拉力检测登记表

        /// <summary>
        /// 新增拉力检测登记表
        /// </summary>
        /// <param name="model">实体Model</param>
        /// <returns></returns>
        [OperationContract, Server.Utility.CHKUserAuth, FaultContract(typeof(CustomFaultMessage))]
        CommonResult<QC_PullDetectionReg> AddPullDetectionReg(string sessionId, QC_PullDetectionReg model);

        /// <summary>
        /// 修改拉力检测登记表
        /// </summary>
        /// <param name="model">实体Model</param>
        /// <returns></returns>
        [OperationContract, Server.Utility.CHKUserAuth, FaultContract(typeof(CustomFaultMessage))]
        CommonResult<QC_PullDetectionReg> UpdatePullDetectionReg(string sessionId, QC_PullDetectionReg model);

        /// <summary>
        /// 删除拉力检测登记表
        /// </summary>
        /// <param name="AutoId">登记编号</param>
        /// <returns></returns>
        [OperationContract, Server.Utility.CHKUserAuth, FaultContract(typeof(CustomFaultMessage))]
        CommonResult<bool> DelPullDetectionReg(string sessionId, int AutoId);

        /// <summary>
        /// 拉力检测登记表单个查询
        /// </summary>
        /// <param name="AutoId">登记编号</param>
        /// <returns></returns>
        [OperationContract, Server.Utility.CHKUserAuth, FaultContract(typeof(CustomFaultMessage))]
        CommonResult<QC_PullDetectionReg> GetPullDetectionRegAutoID(string sessionId, int AutoId);

        /// <summary>
        /// 拉力检测登记表分页查询
        /// </summary>
        /// <param name="TWhere">过滤条件</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="CurrPage">当前页码</param>
        /// <returns>返回数据集合</returns>
        [OperationContract, Server.Utility.CHKUserAuth, FaultContract(typeof(CustomFaultMessage))]
        CommonResult<List<QC_PullDetectionReg>> GetPullDetectionRegPagedList(string sessionId, Tuple<string, object[]> TWhere, int PageSize, int CurrPage);

        #endregion
    }
}
