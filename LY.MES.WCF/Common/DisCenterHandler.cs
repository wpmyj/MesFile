using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LY.MES.WCF
{
    /// <summary>
    /// Author:xxp
    /// Remark:调度中心操作枚举
    /// CreateDate:20161228
    /// </summary>
    public enum DisCenterHandler
    {
        /// <summary>
        /// 开始工艺任务
        /// </summary>
        Start,
        /// <summary>
        /// 更新工艺
        /// </summary>
        UpdateCrafts,
        /// <summary>
        /// 更新参数
        /// </summary>
        UpdateParam,

        /// <summary>
        /// 停止工艺任务
        /// </summary>
        Stop,
        /// <summary>
        /// 阀门组(主管道)
        /// </summary>
        ValveGroup,
        /// <summary>
        /// 完成
        /// </summary>
        Complete
    }
}