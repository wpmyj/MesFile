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
    public partial class vw_CraftsLineParamSetDetail
    {
    	/// <summary>  
    	///   
    	/// </summary>  
        public int ParameterID { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public string ParamType { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public string ParamName { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public string DevepName { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public Nullable<int> ID { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public int Priority { get; set; }
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
        public bool IsValveCheck { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public bool IsValveControl { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public bool IsFixedParameters { get; set; }
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
        public string UserStatus { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public Nullable<int> CraftsID { get; set; }
    	/// <summary>  
    	///   
    	/// </summary>  
        public int AutoID { get; set; }
    }
}
