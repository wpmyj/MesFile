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
    /// System.Data.SqlClient  
    /// </summary>  
    public partial class vw_ArrangedCraftsProcessExecute
    {
    	/// <summary>  
    	///   
    	/// </summary>  
        public long vwID { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public string ArrangedVouchCode { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public System.DateTime VouchDate { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public string MaterialVouchCode { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public string FormulaCode { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public string FormulaName { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public int UserStatus { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public Nullable<int> ExecuteID { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public string WorkshopName { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public string WorkshopCode { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public string WorkbrachCode { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public string WorkbrachName { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public string CraftsCode { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public string CraftsName { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public Nullable<int> ExecuteOrder { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public string ExecuteMode { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public Nullable<int> PlanDuration { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public Nullable<System.DateTime> StartTime { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public Nullable<System.DateTime> EndTime { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public Nullable<int> ExecuteStatus { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public Nullable<int> AutoID { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public Nullable<int> Priority { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public string DevepName { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public string StandardValue { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public string UpperValue { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public string LowerValue { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public Nullable<int> IntervalDuration { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public Nullable<int> TriggerDuration { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public Nullable<bool> IsValveCheck { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public Nullable<bool> IsValveControl { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public Nullable<System.DateTime> StartDateTime { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public Nullable<System.DateTime> EndDateTime { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public Nullable<int> ParamExecuteStatus { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public System.DateTime ArrangedVTime { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public string ParamType { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public Nullable<int> ParameterID { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public string ParameterName { get; set; }
    }
}