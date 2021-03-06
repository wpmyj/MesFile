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
    /// 转鼓检漏设定子表用于记录设定要检漏的鼓号信息  
    /// </summary>  
    public partial class QC_FindLeakDrumsSetDetail
    {
    	/// <summary>  
    	/// 自动编号  
    	/// </summary>  
        public int AutoID { get; set; }
    	/// <summary>  
    	/// 主表编号  
    	/// </summary>  
        public int ID { get; set; }
    	/// <summary>  
    	/// 转鼓编码  
    	/// </summary>  
        public string DevCode { get; set; }
    	/// <summary>  
    	/// 转鼓名称  
    	/// </summary>  
        public string DevName { get; set; }
    	/// <summary>  
    	/// 是否检漏(0:未检漏,1:已检漏)  
    	/// </summary>  
        public int IsLeak { get; set; }
    	/// <summary>  
    	/// 排配单号  
    	/// </summary>  
        public string ArrangedVouchCode { get; set; }
    	/// <summary>  
    	/// 执行编号  
    	/// </summary>  
        public Nullable<int> ExecuteID { get; set; }
    
        public virtual QC_FindLeakDrumsSet QC_FindLeakDrumsSet { get; set; }
    }
}
