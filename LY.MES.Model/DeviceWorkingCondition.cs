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
    /// 设备工作状态  
    /// </summary>  
    public partial class DeviceWorkingCondition
    {
    	/// <summary>  
    	/// 设备编码  
    	/// </summary>  
        public string DevCode { get; set; }
    	/// <summary>  
    	/// 设备名称  
    	/// </summary>  
        public string DevName { get; set; }
    	/// <summary>  
    	/// 单据类型  
    	/// </summary>  
        public string VouchType { get; set; }
    	/// <summary>  
    	/// 单据编码  
    	/// </summary>  
        public string VouchCode { get; set; }
    	/// <summary>  
    	/// 工作状态(0:未使用,1:使用中)  
    	/// </summary>  
        public int WorkingStatus { get; set; }
    }
}