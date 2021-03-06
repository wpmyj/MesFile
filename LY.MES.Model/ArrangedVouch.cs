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
    public partial class ArrangedVouch
    {
    	/// <summary>  
    	/// 自动编号  
    	/// </summary>  
        public int ID { get; set; }
    	/// <summary>  
    	/// 排配单号  
    	/// </summary>  
        public string ArrangedVouchCode { get; set; }
    	/// <summary>  
    	/// 单据日期  
    	/// </summary>  
        public System.DateTime VouchDate { get; set; }
    	/// <summary>  
    	/// 领料单号  
    	/// </summary>  
        public string MaterialVouchCode { get; set; }
    	/// <summary>  
    	/// 配方编码  
    	/// </summary>  
        public string FormulaCode { get; set; }
    	/// <summary>  
    	/// 配方名称  
    	/// </summary>  
        public string FormulaName { get; set; }
    	/// <summary>  
    	/// 投入重量(KG)  
    	/// </summary>  
        public Nullable<decimal> InputWeight { get; set; }
    	/// <summary>  
    	/// 产出重量(KG)  
    	/// </summary>  
        public Nullable<decimal> OutputWeight { get; set; }
    	/// <summary>  
    	/// 过磅毛重(KG)  
    	/// </summary>  
        public Nullable<decimal> WeighingPounds { get; set; }
    	/// <summary>  
    	/// 状态(0:未开始,1:进行中,98:废料中断,99:设备中断,100:已经完成)  
    	/// </summary>  
        public int UserStatus { get; set; }
    	/// <summary>  
    	/// 中断说明  
    	/// </summary>  
        public string InterruptionRemark { get; set; }
    	/// <summary>  
    	/// 中断时间  
    	/// </summary>  
        public Nullable<System.DateTime> InterruptionTime { get; set; }
    	/// <summary>  
    	/// 创建人  
    	/// </summary>  
        public string Creator { get; set; }
    	/// <summary>  
    	/// 创建时间  
    	/// </summary>  
        public System.DateTime CreateTime { get; set; }
    	/// <summary>  
    	/// 修改人  
    	/// </summary>  
        public string ModifyPerson { get; set; }
    	/// <summary>  
    	/// 修改时间  
    	/// </summary>  
        public Nullable<System.DateTime> ModifyTime { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public string LicenseNum { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public Nullable<double> VehicleWeight { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public Nullable<double> WeightMan { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public string TeachProgress { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public string RFIDCode { get; set; }
    	/// <summary>  
    	/// 单据类型  
    	/// </summary>  
        public string VouchType { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public string ProPlanNum { get; set; }
    }
}
