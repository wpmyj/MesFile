﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace LY.MES.WFCL.SRDataColl {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CommonResultOfArrayOfVCollectDataInfo1w0wSc2f", Namespace="http://schemas.datacontract.org/2004/07/Server.Utility")]
    [System.SerializableAttribute()]
    public partial class CommonResultOfArrayOfVCollectDataInfo1w0wSc2f : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private LY.MES.WFCL.SRDataColl.VCollectDataInfo[] DataField;
        
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
        public LY.MES.WFCL.SRDataColl.VCollectDataInfo[] Data {
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
    [System.Runtime.Serialization.DataContractAttribute(Name="VCollectDataInfo", Namespace="http://schemas.datacontract.org/2004/07/LY.MES.Model.VModel")]
    [System.SerializableAttribute()]
    public partial class VCollectDataInfo : LY.MES.WFCL.SRDataColl.CollectDataInfo {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DeviCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DeviNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DevpCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DevpNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IFDevCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IFDevNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PDevCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PDevNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DeviCode {
            get {
                return this.DeviCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.DeviCodeField, value) != true)) {
                    this.DeviCodeField = value;
                    this.RaisePropertyChanged("DeviCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DeviName {
            get {
                return this.DeviNameField;
            }
            set {
                if ((object.ReferenceEquals(this.DeviNameField, value) != true)) {
                    this.DeviNameField = value;
                    this.RaisePropertyChanged("DeviName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DevpCode {
            get {
                return this.DevpCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.DevpCodeField, value) != true)) {
                    this.DevpCodeField = value;
                    this.RaisePropertyChanged("DevpCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DevpName {
            get {
                return this.DevpNameField;
            }
            set {
                if ((object.ReferenceEquals(this.DevpNameField, value) != true)) {
                    this.DevpNameField = value;
                    this.RaisePropertyChanged("DevpName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IFDevCode {
            get {
                return this.IFDevCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.IFDevCodeField, value) != true)) {
                    this.IFDevCodeField = value;
                    this.RaisePropertyChanged("IFDevCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IFDevName {
            get {
                return this.IFDevNameField;
            }
            set {
                if ((object.ReferenceEquals(this.IFDevNameField, value) != true)) {
                    this.IFDevNameField = value;
                    this.RaisePropertyChanged("IFDevName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PDevCode {
            get {
                return this.PDevCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.PDevCodeField, value) != true)) {
                    this.PDevCodeField = value;
                    this.RaisePropertyChanged("PDevCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PDevName {
            get {
                return this.PDevNameField;
            }
            set {
                if ((object.ReferenceEquals(this.PDevNameField, value) != true)) {
                    this.PDevNameField = value;
                    this.RaisePropertyChanged("PDevName");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CollectDataInfo", Namespace="http://schemas.datacontract.org/2004/07/LY.MES.Model")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(LY.MES.WFCL.SRDataColl.VCollectDataInfo))]
    public partial class CollectDataInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AutoIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<decimal> CollValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime CreateDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int DeveCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OriginalValueField;
        
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
        public int AutoId {
            get {
                return this.AutoIdField;
            }
            set {
                if ((this.AutoIdField.Equals(value) != true)) {
                    this.AutoIdField = value;
                    this.RaisePropertyChanged("AutoId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> CollValue {
            get {
                return this.CollValueField;
            }
            set {
                if ((this.CollValueField.Equals(value) != true)) {
                    this.CollValueField = value;
                    this.RaisePropertyChanged("CollValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime CreateDate {
            get {
                return this.CreateDateField;
            }
            set {
                if ((this.CreateDateField.Equals(value) != true)) {
                    this.CreateDateField = value;
                    this.RaisePropertyChanged("CreateDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int DeveCode {
            get {
                return this.DeveCodeField;
            }
            set {
                if ((this.DeveCodeField.Equals(value) != true)) {
                    this.DeveCodeField = value;
                    this.RaisePropertyChanged("DeveCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OriginalValue {
            get {
                return this.OriginalValueField;
            }
            set {
                if ((object.ReferenceEquals(this.OriginalValueField, value) != true)) {
                    this.OriginalValueField = value;
                    this.RaisePropertyChanged("OriginalValue");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="CommonResultOfCollectDataInfodYMi5huk", Namespace="http://schemas.datacontract.org/2004/07/Server.Utility")]
    [System.SerializableAttribute()]
    public partial class CommonResultOfCollectDataInfodYMi5huk : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private LY.MES.WFCL.SRDataColl.CollectDataInfo DataField;
        
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
        public LY.MES.WFCL.SRDataColl.CollectDataInfo Data {
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SRDataColl.IDeviceCollectService")]
    public interface IDeviceCollectService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeviceCollectService/GetCollectDataPagedList", ReplyAction="http://tempuri.org/IDeviceCollectService/GetCollectDataPagedListResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(LY.MES.WFCL.SRDataColl.CustomFaultMessage), Action="http://tempuri.org/IDeviceCollectService/GetCollectDataPagedListCustomFaultMessag" +
            "eFault", Name="CustomFaultMessage", Namespace="http://schemas.datacontract.org/2004/07/Server.Utility")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(LY.MES.WFCL.SRDataColl.CommonResultOfArrayOfVCollectDataInfo1w0wSc2f))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(LY.MES.WFCL.SRDataColl.CustomFaultMessage))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(LY.MES.WFCL.SRDataColl.CommonResultOfCollectDataInfodYMi5huk))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(LY.MES.WFCL.SRDataColl.VCollectDataInfo[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(LY.MES.WFCL.SRDataColl.VCollectDataInfo))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(LY.MES.WFCL.SRDataColl.CollectDataInfo))]
        LY.MES.WFCL.SRDataColl.CommonResultOfArrayOfVCollectDataInfo1w0wSc2f GetCollectDataPagedList(string sessionId, System.Tuple<string, object[]> twhere, int PageSize, int CurrPage);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeviceCollectService/GetCollectDataPagedList", ReplyAction="http://tempuri.org/IDeviceCollectService/GetCollectDataPagedListResponse")]
        System.Threading.Tasks.Task<LY.MES.WFCL.SRDataColl.CommonResultOfArrayOfVCollectDataInfo1w0wSc2f> GetCollectDataPagedListAsync(string sessionId, System.Tuple<string, object[]> twhere, int PageSize, int CurrPage);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeviceCollectService/AddZGParameter", ReplyAction="http://tempuri.org/IDeviceCollectService/AddZGParameterResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(LY.MES.WFCL.SRDataColl.CustomFaultMessage), Action="http://tempuri.org/IDeviceCollectService/AddZGParameterCustomFaultMessageFault", Name="CustomFaultMessage", Namespace="http://schemas.datacontract.org/2004/07/Server.Utility")]
        LY.MES.WFCL.SRDataColl.CommonResultOfCollectDataInfodYMi5huk AddZGParameter(string sessionId, LY.MES.WFCL.SRDataColl.CollectDataInfo model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeviceCollectService/AddZGParameter", ReplyAction="http://tempuri.org/IDeviceCollectService/AddZGParameterResponse")]
        System.Threading.Tasks.Task<LY.MES.WFCL.SRDataColl.CommonResultOfCollectDataInfodYMi5huk> AddZGParameterAsync(string sessionId, LY.MES.WFCL.SRDataColl.CollectDataInfo model);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDeviceCollectServiceChannel : LY.MES.WFCL.SRDataColl.IDeviceCollectService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DeviceCollectServiceClient : System.ServiceModel.ClientBase<LY.MES.WFCL.SRDataColl.IDeviceCollectService>, LY.MES.WFCL.SRDataColl.IDeviceCollectService {
        
        public DeviceCollectServiceClient() {
        }
        
        public DeviceCollectServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DeviceCollectServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DeviceCollectServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DeviceCollectServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public LY.MES.WFCL.SRDataColl.CommonResultOfArrayOfVCollectDataInfo1w0wSc2f GetCollectDataPagedList(string sessionId, System.Tuple<string, object[]> twhere, int PageSize, int CurrPage) {
            return base.Channel.GetCollectDataPagedList(sessionId, twhere, PageSize, CurrPage);
        }
        
        public System.Threading.Tasks.Task<LY.MES.WFCL.SRDataColl.CommonResultOfArrayOfVCollectDataInfo1w0wSc2f> GetCollectDataPagedListAsync(string sessionId, System.Tuple<string, object[]> twhere, int PageSize, int CurrPage) {
            return base.Channel.GetCollectDataPagedListAsync(sessionId, twhere, PageSize, CurrPage);
        }
        
        public LY.MES.WFCL.SRDataColl.CommonResultOfCollectDataInfodYMi5huk AddZGParameter(string sessionId, LY.MES.WFCL.SRDataColl.CollectDataInfo model) {
            return base.Channel.AddZGParameter(sessionId, model);
        }
        
        public System.Threading.Tasks.Task<LY.MES.WFCL.SRDataColl.CommonResultOfCollectDataInfodYMi5huk> AddZGParameterAsync(string sessionId, LY.MES.WFCL.SRDataColl.CollectDataInfo model) {
            return base.Channel.AddZGParameterAsync(sessionId, model);
        }
    }
}
