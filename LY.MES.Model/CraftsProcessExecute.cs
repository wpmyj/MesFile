//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace LY.MES.Model
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    ///   
    /// </summary>  
    public partial class CraftsProcessExecute
    {
        public CraftsProcessExecute()
        {
            this.CraftsProcessExecuteDetail = new HashSet<CraftsProcessExecuteDetail>();
        }
    	 
    	/// <summary>  
    	/// ExecuteID  
    	/// </summary>  
        public int ExecuteID { get; set; }
    	/// <summary>  
    	/// 排配单号  
    	/// </summary>  
        public string ArrangedVouchCode { get; set; }
    	/// <summary>  
    	/// 执行顺序  
    	/// </summary>  
        public int ExecuteOrder { get; set; }
    	/// <summary>  
    	/// 车间编码  
    	/// </summary>  
        public string WorkshopCode { get; set; }
    	/// <summary>  
    	/// 车间名称  
    	/// </summary>  
        public string WorkshopName { get; set; }
    	/// <summary>  
    	/// 工作台编码  
    	/// </summary>  
        public string WorkbrachCode { get; set; }
    	/// <summary>  
    	/// 工作台名称  
    	/// </summary>  
        public string WorkbrachName { get; set; }
    	/// <summary>  
    	/// 工艺编码  
    	/// </summary>  
        public string CraftsCode { get; set; }
    	/// <summary>  
    	/// 工艺名称  
    	/// </summary>  
        public string CraftsName { get; set; }
    	/// <summary>  
    	/// 执行方式  
    	/// </summary>  
        public string ExecuteMode { get; set; }
    	/// <summary>  
    	/// 计划执行时长(分钟)  
    	/// </summary>  
        public Nullable<int> PlanDuration { get; set; }
    	/// <summary>  
    	/// 开始执行时间  
    	/// </summary>  
        public Nullable<System.DateTime> StartTime { get; set; }
    	/// <summary>  
    	/// 结束执行时间  
    	/// </summary>  
        public Nullable<System.DateTime> EndTime { get; set; }
    	/// <summary>  
    	/// 执行状态(0:未开始,1:进行中,2:已完成,99:终止执行)  
    	/// </summary>  
        public int ExecuteStatus { get; set; }
    
        public virtual ICollection<CraftsProcessExecuteDetail> CraftsProcessExecuteDetail { get; set; }
    }
}
