﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18444
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace LY.MES.WFCL.SRPersonInfo {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CommonResultOfPersondYMi5huk", Namespace="http://schemas.datacontract.org/2004/07/Server.Utility")]
    [System.SerializableAttribute()]
    public partial class CommonResultOfPersondYMi5huk : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private LY.MES.WFCL.SRPersonInfo.Person DataField;
        
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
        public LY.MES.WFCL.SRPersonInfo.Person Data {
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Person", Namespace="http://schemas.datacontract.org/2004/07/LY.MES.Model")]
    [System.SerializableAttribute()]
    public partial class Person : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DepCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> HeightField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsOperatorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OparatorCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OparatorNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PersonCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PersonEmaiField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PersonNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PersonPhoneField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PersonTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SexField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<decimal> WeightField;
        
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
        public string DepCode {
            get {
                return this.DepCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.DepCodeField, value) != true)) {
                    this.DepCodeField = value;
                    this.RaisePropertyChanged("DepCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Height {
            get {
                return this.HeightField;
            }
            set {
                if ((this.HeightField.Equals(value) != true)) {
                    this.HeightField = value;
                    this.RaisePropertyChanged("Height");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsOperator {
            get {
                return this.IsOperatorField;
            }
            set {
                if ((this.IsOperatorField.Equals(value) != true)) {
                    this.IsOperatorField = value;
                    this.RaisePropertyChanged("IsOperator");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OparatorCode {
            get {
                return this.OparatorCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.OparatorCodeField, value) != true)) {
                    this.OparatorCodeField = value;
                    this.RaisePropertyChanged("OparatorCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OparatorName {
            get {
                return this.OparatorNameField;
            }
            set {
                if ((object.ReferenceEquals(this.OparatorNameField, value) != true)) {
                    this.OparatorNameField = value;
                    this.RaisePropertyChanged("OparatorName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PersonCode {
            get {
                return this.PersonCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.PersonCodeField, value) != true)) {
                    this.PersonCodeField = value;
                    this.RaisePropertyChanged("PersonCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PersonEmai {
            get {
                return this.PersonEmaiField;
            }
            set {
                if ((object.ReferenceEquals(this.PersonEmaiField, value) != true)) {
                    this.PersonEmaiField = value;
                    this.RaisePropertyChanged("PersonEmai");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PersonName {
            get {
                return this.PersonNameField;
            }
            set {
                if ((object.ReferenceEquals(this.PersonNameField, value) != true)) {
                    this.PersonNameField = value;
                    this.RaisePropertyChanged("PersonName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PersonPhone {
            get {
                return this.PersonPhoneField;
            }
            set {
                if ((object.ReferenceEquals(this.PersonPhoneField, value) != true)) {
                    this.PersonPhoneField = value;
                    this.RaisePropertyChanged("PersonPhone");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PersonType {
            get {
                return this.PersonTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.PersonTypeField, value) != true)) {
                    this.PersonTypeField = value;
                    this.RaisePropertyChanged("PersonType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Sex {
            get {
                return this.SexField;
            }
            set {
                if ((object.ReferenceEquals(this.SexField, value) != true)) {
                    this.SexField = value;
                    this.RaisePropertyChanged("Sex");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> Weight {
            get {
                return this.WeightField;
            }
            set {
                if ((this.WeightField.Equals(value) != true)) {
                    this.WeightField = value;
                    this.RaisePropertyChanged("Weight");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="CommonResultOfArrayOfPersondYMi5huk", Namespace="http://schemas.datacontract.org/2004/07/Server.Utility")]
    [System.SerializableAttribute()]
    public partial class CommonResultOfArrayOfPersondYMi5huk : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private LY.MES.WFCL.SRPersonInfo.Person[] DataField;
        
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
        public LY.MES.WFCL.SRPersonInfo.Person[] Data {
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SRPersonInfo.IPersonService")]
    public interface IPersonService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/GetPersonByCode", ReplyAction="http://tempuri.org/IPersonService/GetPersonByCodeResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(LY.MES.WFCL.SRPersonInfo.CustomFaultMessage), Action="http://tempuri.org/IPersonService/GetPersonByCodeCustomFaultMessageFault", Name="CustomFaultMessage", Namespace="http://schemas.datacontract.org/2004/07/Server.Utility")]
        LY.MES.WFCL.SRPersonInfo.CommonResultOfPersondYMi5huk GetPersonByCode(string sessionId, string strCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/GetPersonByCode", ReplyAction="http://tempuri.org/IPersonService/GetPersonByCodeResponse")]
        System.Threading.Tasks.Task<LY.MES.WFCL.SRPersonInfo.CommonResultOfPersondYMi5huk> GetPersonByCodeAsync(string sessionId, string strCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/GetPersonList", ReplyAction="http://tempuri.org/IPersonService/GetPersonListResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(LY.MES.WFCL.SRPersonInfo.CustomFaultMessage), Action="http://tempuri.org/IPersonService/GetPersonListCustomFaultMessageFault", Name="CustomFaultMessage", Namespace="http://schemas.datacontract.org/2004/07/Server.Utility")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(LY.MES.WFCL.SRPersonInfo.CommonResultOfPersondYMi5huk))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(LY.MES.WFCL.SRPersonInfo.CustomFaultMessage))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(LY.MES.WFCL.SRPersonInfo.CommonResultOfArrayOfPersondYMi5huk))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Client.Utility.SRSysBase.CommonResultOfboolean))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(LY.MES.WFCL.SRPersonInfo.Person))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(LY.MES.WFCL.SRPersonInfo.Person[]))]
        LY.MES.WFCL.SRPersonInfo.CommonResultOfArrayOfPersondYMi5huk GetPersonList(string sessionId, System.Tuple<string, object[]> tFilter, int PageSize, int CurrPage);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/GetPersonList", ReplyAction="http://tempuri.org/IPersonService/GetPersonListResponse")]
        System.Threading.Tasks.Task<LY.MES.WFCL.SRPersonInfo.CommonResultOfArrayOfPersondYMi5huk> GetPersonListAsync(string sessionId, System.Tuple<string, object[]> tFilter, int PageSize, int CurrPage);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/AddPersonData", ReplyAction="http://tempuri.org/IPersonService/AddPersonDataResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(LY.MES.WFCL.SRPersonInfo.CustomFaultMessage), Action="http://tempuri.org/IPersonService/AddPersonDataCustomFaultMessageFault", Name="CustomFaultMessage", Namespace="http://schemas.datacontract.org/2004/07/Server.Utility")]
        LY.MES.WFCL.SRPersonInfo.CommonResultOfPersondYMi5huk AddPersonData(string sessionId, LY.MES.WFCL.SRPersonInfo.Person Model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/AddPersonData", ReplyAction="http://tempuri.org/IPersonService/AddPersonDataResponse")]
        System.Threading.Tasks.Task<LY.MES.WFCL.SRPersonInfo.CommonResultOfPersondYMi5huk> AddPersonDataAsync(string sessionId, LY.MES.WFCL.SRPersonInfo.Person Model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/UpdataPersonData", ReplyAction="http://tempuri.org/IPersonService/UpdataPersonDataResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(LY.MES.WFCL.SRPersonInfo.CustomFaultMessage), Action="http://tempuri.org/IPersonService/UpdataPersonDataCustomFaultMessageFault", Name="CustomFaultMessage", Namespace="http://schemas.datacontract.org/2004/07/Server.Utility")]
        LY.MES.WFCL.SRPersonInfo.CommonResultOfPersondYMi5huk UpdataPersonData(string sessionId, LY.MES.WFCL.SRPersonInfo.Person Model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/UpdataPersonData", ReplyAction="http://tempuri.org/IPersonService/UpdataPersonDataResponse")]
        System.Threading.Tasks.Task<LY.MES.WFCL.SRPersonInfo.CommonResultOfPersondYMi5huk> UpdataPersonDataAsync(string sessionId, LY.MES.WFCL.SRPersonInfo.Person Model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/DelPersonData", ReplyAction="http://tempuri.org/IPersonService/DelPersonDataResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(LY.MES.WFCL.SRPersonInfo.CustomFaultMessage), Action="http://tempuri.org/IPersonService/DelPersonDataCustomFaultMessageFault", Name="CustomFaultMessage", Namespace="http://schemas.datacontract.org/2004/07/Server.Utility")]
        Client.Utility.SRSysBase.CommonResultOfboolean DelPersonData(string sessionId, string strPersonCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/DelPersonData", ReplyAction="http://tempuri.org/IPersonService/DelPersonDataResponse")]
        System.Threading.Tasks.Task<Client.Utility.SRSysBase.CommonResultOfboolean> DelPersonDataAsync(string sessionId, string strPersonCode);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPersonServiceChannel : LY.MES.WFCL.SRPersonInfo.IPersonService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PersonServiceClient : System.ServiceModel.ClientBase<LY.MES.WFCL.SRPersonInfo.IPersonService>, LY.MES.WFCL.SRPersonInfo.IPersonService {
        
        public PersonServiceClient() {
        }
        
        public PersonServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PersonServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PersonServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PersonServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public LY.MES.WFCL.SRPersonInfo.CommonResultOfPersondYMi5huk GetPersonByCode(string sessionId, string strCode) {
            return base.Channel.GetPersonByCode(sessionId, strCode);
        }
        
        public System.Threading.Tasks.Task<LY.MES.WFCL.SRPersonInfo.CommonResultOfPersondYMi5huk> GetPersonByCodeAsync(string sessionId, string strCode) {
            return base.Channel.GetPersonByCodeAsync(sessionId, strCode);
        }
        
        public LY.MES.WFCL.SRPersonInfo.CommonResultOfArrayOfPersondYMi5huk GetPersonList(string sessionId, System.Tuple<string, object[]> tFilter, int PageSize, int CurrPage) {
            return base.Channel.GetPersonList(sessionId, tFilter, PageSize, CurrPage);
        }
        
        public System.Threading.Tasks.Task<LY.MES.WFCL.SRPersonInfo.CommonResultOfArrayOfPersondYMi5huk> GetPersonListAsync(string sessionId, System.Tuple<string, object[]> tFilter, int PageSize, int CurrPage) {
            return base.Channel.GetPersonListAsync(sessionId, tFilter, PageSize, CurrPage);
        }
        
        public LY.MES.WFCL.SRPersonInfo.CommonResultOfPersondYMi5huk AddPersonData(string sessionId, LY.MES.WFCL.SRPersonInfo.Person Model) {
            return base.Channel.AddPersonData(sessionId, Model);
        }
        
        public System.Threading.Tasks.Task<LY.MES.WFCL.SRPersonInfo.CommonResultOfPersondYMi5huk> AddPersonDataAsync(string sessionId, LY.MES.WFCL.SRPersonInfo.Person Model) {
            return base.Channel.AddPersonDataAsync(sessionId, Model);
        }
        
        public LY.MES.WFCL.SRPersonInfo.CommonResultOfPersondYMi5huk UpdataPersonData(string sessionId, LY.MES.WFCL.SRPersonInfo.Person Model) {
            return base.Channel.UpdataPersonData(sessionId, Model);
        }
        
        public System.Threading.Tasks.Task<LY.MES.WFCL.SRPersonInfo.CommonResultOfPersondYMi5huk> UpdataPersonDataAsync(string sessionId, LY.MES.WFCL.SRPersonInfo.Person Model) {
            return base.Channel.UpdataPersonDataAsync(sessionId, Model);
        }
        
        public Client.Utility.SRSysBase.CommonResultOfboolean DelPersonData(string sessionId, string strPersonCode) {
            return base.Channel.DelPersonData(sessionId, strPersonCode);
        }
        
        public System.Threading.Tasks.Task<Client.Utility.SRSysBase.CommonResultOfboolean> DelPersonDataAsync(string sessionId, string strPersonCode) {
            return base.Channel.DelPersonDataAsync(sessionId, strPersonCode);
        }
    }
}
