﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace LY.MES.WFCL.SRArrangedVouch {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CommonResultOfArrangedVouchdYMi5huk", Namespace="http://schemas.datacontract.org/2004/07/Server.Utility")]
    [System.SerializableAttribute()]
    public partial class CommonResultOfArrangedVouchdYMi5huk : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private LY.MES.WFCL.SRArrangedVouch.ArrangedVouch DataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ErrorCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsSuccessField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StackTraceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TotalNumField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public LY.MES.WFCL.SRArrangedVouch.ArrangedVouch Data {
            get {
                return this.DataField;
            }
            set {
                if ((object.ReferenceEquals(this.DataField, value) != true)) {
                    this.DataField = value;
                    this.RaisePropertyChanged("Data");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ErrorCode {
            get {
                return this.ErrorCodeField;
            }
            set {
                if ((this.ErrorCodeField.Equals(value) != true)) {
                    this.ErrorCodeField = value;
                    this.RaisePropertyChanged("ErrorCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsSuccess {
            get {
                return this.IsSuccessField;
            }
            set {
                if ((this.IsSuccessField.Equals(value) != true)) {
                    this.IsSuccessField = value;
                    this.RaisePropertyChanged("IsSuccess");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StackTrace {
            get {
                return this.StackTraceField;
            }
            set {
                if ((object.ReferenceEquals(this.StackTraceField, value) != true)) {
                    this.StackTraceField = value;
                    this.RaisePropertyChanged("StackTrace");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TotalNum {
            get {
                return this.TotalNumField;
            }
            set {
                if ((this.TotalNumField.Equals(value) != true)) {
                    this.TotalNumField = value;
                    this.RaisePropertyChanged("TotalNum");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ArrangedVouch", Namespace="http://schemas.datacontract.org/2004/07/LY.MES.Model")]
    [System.SerializableAttribute()]
    public partial class ArrangedVouch : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ArrangedVouchCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime CreateTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CreatorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FormulaCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FormulaNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<decimal> InputWeightField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string InterruptionRemarkField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> InterruptionTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LicenseNumField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MaterialVouchCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ModifyPersonField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> ModifyTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<decimal> OutputWeightField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProPlanNumField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RFIDCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TeachProgressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserStatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<double> VehicleWeightField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime VouchDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string VouchTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<decimal> WeighingPoundsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<double> WeightManField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ArrangedVouchCode {
            get {
                return this.ArrangedVouchCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.ArrangedVouchCodeField, value) != true)) {
                    this.ArrangedVouchCodeField = value;
                    this.RaisePropertyChanged("ArrangedVouchCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime CreateTime {
            get {
                return this.CreateTimeField;
            }
            set {
                if ((this.CreateTimeField.Equals(value) != true)) {
                    this.CreateTimeField = value;
                    this.RaisePropertyChanged("CreateTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Creator {
            get {
                return this.CreatorField;
            }
            set {
                if ((object.ReferenceEquals(this.CreatorField, value) != true)) {
                    this.CreatorField = value;
                    this.RaisePropertyChanged("Creator");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FormulaCode {
            get {
                return this.FormulaCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.FormulaCodeField, value) != true)) {
                    this.FormulaCodeField = value;
                    this.RaisePropertyChanged("FormulaCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FormulaName {
            get {
                return this.FormulaNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FormulaNameField, value) != true)) {
                    this.FormulaNameField = value;
                    this.RaisePropertyChanged("FormulaName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> InputWeight {
            get {
                return this.InputWeightField;
            }
            set {
                if ((this.InputWeightField.Equals(value) != true)) {
                    this.InputWeightField = value;
                    this.RaisePropertyChanged("InputWeight");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string InterruptionRemark {
            get {
                return this.InterruptionRemarkField;
            }
            set {
                if ((object.ReferenceEquals(this.InterruptionRemarkField, value) != true)) {
                    this.InterruptionRemarkField = value;
                    this.RaisePropertyChanged("InterruptionRemark");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> InterruptionTime {
            get {
                return this.InterruptionTimeField;
            }
            set {
                if ((this.InterruptionTimeField.Equals(value) != true)) {
                    this.InterruptionTimeField = value;
                    this.RaisePropertyChanged("InterruptionTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LicenseNum {
            get {
                return this.LicenseNumField;
            }
            set {
                if ((object.ReferenceEquals(this.LicenseNumField, value) != true)) {
                    this.LicenseNumField = value;
                    this.RaisePropertyChanged("LicenseNum");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MaterialVouchCode {
            get {
                return this.MaterialVouchCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.MaterialVouchCodeField, value) != true)) {
                    this.MaterialVouchCodeField = value;
                    this.RaisePropertyChanged("MaterialVouchCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ModifyPerson {
            get {
                return this.ModifyPersonField;
            }
            set {
                if ((object.ReferenceEquals(this.ModifyPersonField, value) != true)) {
                    this.ModifyPersonField = value;
                    this.RaisePropertyChanged("ModifyPerson");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> ModifyTime {
            get {
                return this.ModifyTimeField;
            }
            set {
                if ((this.ModifyTimeField.Equals(value) != true)) {
                    this.ModifyTimeField = value;
                    this.RaisePropertyChanged("ModifyTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> OutputWeight {
            get {
                return this.OutputWeightField;
            }
            set {
                if ((this.OutputWeightField.Equals(value) != true)) {
                    this.OutputWeightField = value;
                    this.RaisePropertyChanged("OutputWeight");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProPlanNum {
            get {
                return this.ProPlanNumField;
            }
            set {
                if ((object.ReferenceEquals(this.ProPlanNumField, value) != true)) {
                    this.ProPlanNumField = value;
                    this.RaisePropertyChanged("ProPlanNum");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RFIDCode {
            get {
                return this.RFIDCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.RFIDCodeField, value) != true)) {
                    this.RFIDCodeField = value;
                    this.RaisePropertyChanged("RFIDCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TeachProgress {
            get {
                return this.TeachProgressField;
            }
            set {
                if ((object.ReferenceEquals(this.TeachProgressField, value) != true)) {
                    this.TeachProgressField = value;
                    this.RaisePropertyChanged("TeachProgress");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserStatus {
            get {
                return this.UserStatusField;
            }
            set {
                if ((this.UserStatusField.Equals(value) != true)) {
                    this.UserStatusField = value;
                    this.RaisePropertyChanged("UserStatus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<double> VehicleWeight {
            get {
                return this.VehicleWeightField;
            }
            set {
                if ((this.VehicleWeightField.Equals(value) != true)) {
                    this.VehicleWeightField = value;
                    this.RaisePropertyChanged("VehicleWeight");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime VouchDate {
            get {
                return this.VouchDateField;
            }
            set {
                if ((this.VouchDateField.Equals(value) != true)) {
                    this.VouchDateField = value;
                    this.RaisePropertyChanged("VouchDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string VouchType {
            get {
                return this.VouchTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.VouchTypeField, value) != true)) {
                    this.VouchTypeField = value;
                    this.RaisePropertyChanged("VouchType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> WeighingPounds {
            get {
                return this.WeighingPoundsField;
            }
            set {
                if ((this.WeighingPoundsField.Equals(value) != true)) {
                    this.WeighingPoundsField = value;
                    this.RaisePropertyChanged("WeighingPounds");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<double> WeightMan {
            get {
                return this.WeightManField;
            }
            set {
                if ((this.WeightManField.Equals(value) != true)) {
                    this.WeightManField = value;
                    this.RaisePropertyChanged("WeightMan");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CustomFaultMessage", Namespace="http://schemas.datacontract.org/2004/07/Server.Utility")]
    [System.SerializableAttribute()]
    public partial class CustomFaultMessage : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ErrorCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StackTraceField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ErrorCode {
            get {
                return this.ErrorCodeField;
            }
            set {
                if ((this.ErrorCodeField.Equals(value) != true)) {
                    this.ErrorCodeField = value;
                    this.RaisePropertyChanged("ErrorCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StackTrace {
            get {
                return this.StackTraceField;
            }
            set {
                if ((object.ReferenceEquals(this.StackTraceField, value) != true)) {
                    this.StackTraceField = value;
                    this.RaisePropertyChanged("StackTrace");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CommonResultOfArrayOfArrangedVouchdYMi5huk", Namespace="http://schemas.datacontract.org/2004/07/Server.Utility")]
    [System.SerializableAttribute()]
    public partial class CommonResultOfArrayOfArrangedVouchdYMi5huk : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private LY.MES.WFCL.SRArrangedVouch.ArrangedVouch[] DataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ErrorCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsSuccessField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StackTraceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TotalNumField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public LY.MES.WFCL.SRArrangedVouch.ArrangedVouch[] Data {
            get {
                return this.DataField;
            }
            set {
                if ((object.ReferenceEquals(this.DataField, value) != true)) {
                    this.DataField = value;
                    this.RaisePropertyChanged("Data");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ErrorCode {
            get {
                return this.ErrorCodeField;
            }
            set {
                if ((this.ErrorCodeField.Equals(value) != true)) {
                    this.ErrorCodeField = value;
                    this.RaisePropertyChanged("ErrorCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsSuccess {
            get {
                return this.IsSuccessField;
            }
            set {
                if ((this.IsSuccessField.Equals(value) != true)) {
                    this.IsSuccessField = value;
                    this.RaisePropertyChanged("IsSuccess");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StackTrace {
            get {
                return this.StackTraceField;
            }
            set {
                if ((object.ReferenceEquals(this.StackTraceField, value) != true)) {
                    this.StackTraceField = value;
                    this.RaisePropertyChanged("StackTrace");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TotalNum {
            get {
                return this.TotalNumField;
            }
            set {
                if ((this.TotalNumField.Equals(value) != true)) {
                    this.TotalNumField = value;
                    this.RaisePropertyChanged("TotalNum");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SRArrangedVouch.IArrangedVService")]
    public interface IArrangedVService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IArrangedVService/GetArrangedVouchByCode", ReplyAction="http://tempuri.org/IArrangedVService/GetArrangedVouchByCodeResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(LY.MES.WFCL.SRArrangedVouch.CustomFaultMessage), Action="http://tempuri.org/IArrangedVService/GetArrangedVouchByCodeCustomFaultMessageFaul" +
            "t", Name="CustomFaultMessage", Namespace="http://schemas.datacontract.org/2004/07/Server.Utility")]
        LY.MES.WFCL.SRArrangedVouch.CommonResultOfArrangedVouchdYMi5huk GetArrangedVouchByCode(string sessionId, string ArrangedVouchCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IArrangedVService/GetArrangedVouchByCode", ReplyAction="http://tempuri.org/IArrangedVService/GetArrangedVouchByCodeResponse")]
        System.Threading.Tasks.Task<LY.MES.WFCL.SRArrangedVouch.CommonResultOfArrangedVouchdYMi5huk> GetArrangedVouchByCodeAsync(string sessionId, string ArrangedVouchCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IArrangedVService/GetArrangedVouchList", ReplyAction="http://tempuri.org/IArrangedVService/GetArrangedVouchListResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(LY.MES.WFCL.SRArrangedVouch.CustomFaultMessage), Action="http://tempuri.org/IArrangedVService/GetArrangedVouchListCustomFaultMessageFault", Name="CustomFaultMessage", Namespace="http://schemas.datacontract.org/2004/07/Server.Utility")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(LY.MES.WFCL.SRArrangedVouch.ArrangedVouch))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(LY.MES.WFCL.SRArrangedVouch.ArrangedVouch[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(LY.MES.WFCL.SRArrangedVouch.CommonResultOfArrangedVouchdYMi5huk))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(LY.MES.WFCL.SRArrangedVouch.CustomFaultMessage))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(LY.MES.WFCL.SRArrangedVouch.CommonResultOfArrayOfArrangedVouchdYMi5huk))]
        LY.MES.WFCL.SRArrangedVouch.CommonResultOfArrayOfArrangedVouchdYMi5huk GetArrangedVouchList(string sessionId, System.Tuple<string, object[]> tWhere, int PageSize, int CurrPage);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IArrangedVService/GetArrangedVouchList", ReplyAction="http://tempuri.org/IArrangedVService/GetArrangedVouchListResponse")]
        System.Threading.Tasks.Task<LY.MES.WFCL.SRArrangedVouch.CommonResultOfArrayOfArrangedVouchdYMi5huk> GetArrangedVouchListAsync(string sessionId, System.Tuple<string, object[]> tWhere, int PageSize, int CurrPage);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IArrangedVService/UdateArrUserStatusByArrCode", ReplyAction="http://tempuri.org/IArrangedVService/UdateArrUserStatusByArrCodeResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(LY.MES.WFCL.SRArrangedVouch.CustomFaultMessage), Action="http://tempuri.org/IArrangedVService/UdateArrUserStatusByArrCodeCustomFaultMessag" +
            "eFault", Name="CustomFaultMessage", Namespace="http://schemas.datacontract.org/2004/07/Server.Utility")]
        LY.MES.WFCL.SRArrangedVouch.CommonResultOfArrangedVouchdYMi5huk UdateArrUserStatusByArrCode(string sessionId, string ArrangedVouchCode, int UserStatus);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IArrangedVService/UdateArrUserStatusByArrCode", ReplyAction="http://tempuri.org/IArrangedVService/UdateArrUserStatusByArrCodeResponse")]
        System.Threading.Tasks.Task<LY.MES.WFCL.SRArrangedVouch.CommonResultOfArrangedVouchdYMi5huk> UdateArrUserStatusByArrCodeAsync(string sessionId, string ArrangedVouchCode, int UserStatus);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IArrangedVService/GetArrangedVouchByMulaCode", ReplyAction="http://tempuri.org/IArrangedVService/GetArrangedVouchByMulaCodeResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(LY.MES.WFCL.SRArrangedVouch.CustomFaultMessage), Action="http://tempuri.org/IArrangedVService/GetArrangedVouchByMulaCodeCustomFaultMessage" +
            "Fault", Name="CustomFaultMessage", Namespace="http://schemas.datacontract.org/2004/07/Server.Utility")]
        LY.MES.WFCL.SRArrangedVouch.CommonResultOfArrayOfArrangedVouchdYMi5huk GetArrangedVouchByMulaCode(string sessionId, string ForMulaCode, int UserStatus);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IArrangedVService/GetArrangedVouchByMulaCode", ReplyAction="http://tempuri.org/IArrangedVService/GetArrangedVouchByMulaCodeResponse")]
        System.Threading.Tasks.Task<LY.MES.WFCL.SRArrangedVouch.CommonResultOfArrayOfArrangedVouchdYMi5huk> GetArrangedVouchByMulaCodeAsync(string sessionId, string ForMulaCode, int UserStatus);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IArrangedVServiceChannel : LY.MES.WFCL.SRArrangedVouch.IArrangedVService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ArrangedVServiceClient : System.ServiceModel.ClientBase<LY.MES.WFCL.SRArrangedVouch.IArrangedVService>, LY.MES.WFCL.SRArrangedVouch.IArrangedVService {
        
        public ArrangedVServiceClient() {
        }
        
        public ArrangedVServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ArrangedVServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ArrangedVServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ArrangedVServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public LY.MES.WFCL.SRArrangedVouch.CommonResultOfArrangedVouchdYMi5huk GetArrangedVouchByCode(string sessionId, string ArrangedVouchCode) {
            return base.Channel.GetArrangedVouchByCode(sessionId, ArrangedVouchCode);
        }
        
        public System.Threading.Tasks.Task<LY.MES.WFCL.SRArrangedVouch.CommonResultOfArrangedVouchdYMi5huk> GetArrangedVouchByCodeAsync(string sessionId, string ArrangedVouchCode) {
            return base.Channel.GetArrangedVouchByCodeAsync(sessionId, ArrangedVouchCode);
        }
        
        public LY.MES.WFCL.SRArrangedVouch.CommonResultOfArrayOfArrangedVouchdYMi5huk GetArrangedVouchList(string sessionId, System.Tuple<string, object[]> tWhere, int PageSize, int CurrPage) {
            return base.Channel.GetArrangedVouchList(sessionId, tWhere, PageSize, CurrPage);
        }
        
        public System.Threading.Tasks.Task<LY.MES.WFCL.SRArrangedVouch.CommonResultOfArrayOfArrangedVouchdYMi5huk> GetArrangedVouchListAsync(string sessionId, System.Tuple<string, object[]> tWhere, int PageSize, int CurrPage) {
            return base.Channel.GetArrangedVouchListAsync(sessionId, tWhere, PageSize, CurrPage);
        }
        
        public LY.MES.WFCL.SRArrangedVouch.CommonResultOfArrangedVouchdYMi5huk UdateArrUserStatusByArrCode(string sessionId, string ArrangedVouchCode, int UserStatus) {
            return base.Channel.UdateArrUserStatusByArrCode(sessionId, ArrangedVouchCode, UserStatus);
        }
        
        public System.Threading.Tasks.Task<LY.MES.WFCL.SRArrangedVouch.CommonResultOfArrangedVouchdYMi5huk> UdateArrUserStatusByArrCodeAsync(string sessionId, string ArrangedVouchCode, int UserStatus) {
            return base.Channel.UdateArrUserStatusByArrCodeAsync(sessionId, ArrangedVouchCode, UserStatus);
        }
        
        public LY.MES.WFCL.SRArrangedVouch.CommonResultOfArrayOfArrangedVouchdYMi5huk GetArrangedVouchByMulaCode(string sessionId, string ForMulaCode, int UserStatus) {
            return base.Channel.GetArrangedVouchByMulaCode(sessionId, ForMulaCode, UserStatus);
        }
        
        public System.Threading.Tasks.Task<LY.MES.WFCL.SRArrangedVouch.CommonResultOfArrayOfArrangedVouchdYMi5huk> GetArrangedVouchByMulaCodeAsync(string sessionId, string ForMulaCode, int UserStatus) {
            return base.Channel.GetArrangedVouchByMulaCodeAsync(sessionId, ForMulaCode, UserStatus);
        }
    }
}