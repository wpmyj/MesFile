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
    /// 用于记录设备采集的数据  
    /// </summary>  
    public partial class CollectDataInfo
    {
    	/// <summary>  
    	///   
    	/// </summary>  
        public int AutoId { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public int DeveCode { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public string OriginalValue { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public Nullable<decimal> CollValue { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public System.DateTime CreateDate { get; set; }
    }
}
