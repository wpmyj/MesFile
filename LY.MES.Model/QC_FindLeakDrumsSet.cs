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
    /// 设定当天需要检漏的转鼓  
    /// </summary>  
    public partial class QC_FindLeakDrumsSet
    {
        public QC_FindLeakDrumsSet()
        {
            this.QC_FindLeakDrumsSetDetail = new HashSet<QC_FindLeakDrumsSetDetail>();
        }
    	 
    	/// <summary>  
    	/// 编号  
    	/// </summary>  
        public int ID { get; set; }
    	/// <summary>  
    	/// 年份  
    	/// </summary>  
        public int Year { get; set; }
    	/// <summary>  
    	/// 月份  
    	/// </summary>  
        public int Month { get; set; }
    	/// <summary>  
    	/// 周次  
    	/// </summary>  
        public int Week { get; set; }
    	/// <summary>  
    	/// 班次  
    	/// </summary>  
        public string Frequency { get; set; }
    	/// <summary>  
    	/// 创建人  
    	/// </summary>  
        public string CreatePerson { get; set; }
    	/// <summary>  
    	/// 创建日期  
    	/// </summary>  
        public System.DateTime CreateDate { get; set; }
    	/// <summary>  
    	/// 创建时间  
    	/// </summary>  
        public System.DateTime CreateDateTime { get; set; }
    
        public virtual ICollection<QC_FindLeakDrumsSetDetail> QC_FindLeakDrumsSetDetail { get; set; }
    }
}