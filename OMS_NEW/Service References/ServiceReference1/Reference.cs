﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OMS_NEW.ServiceReference1 {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.Service1Soap")]
    public interface Service1Soap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get_Company", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet Get_Company();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get_Company", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> Get_CompanyAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get_Circle", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet Get_Circle(string company, string circle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get_Circle", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> Get_CircleAsync(string company, string circle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get_Division", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet Get_Division(string circle, string divisionc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get_Division", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> Get_DivisionAsync(string circle, string divisionc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get_Sub_Division", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet Get_Sub_Division(string subdivision, string subdivision_1, string division, string divisionc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get_Sub_Division", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> Get_Sub_DivisionAsync(string subdivision, string subdivision_1, string division, string divisionc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get_Complaint_Centre", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet Get_Complaint_Centre(string facilityid, string subdivision, string subdivisionc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Get_Complaint_Centre", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> Get_Complaint_CentreAsync(string facilityid, string subdivision, string subdivisionc);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface Service1SoapChannel : OMS_NEW.ServiceReference1.Service1Soap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1SoapClient : System.ServiceModel.ClientBase<OMS_NEW.ServiceReference1.Service1Soap>, OMS_NEW.ServiceReference1.Service1Soap {
        
        public Service1SoapClient() {
        }
        
        public Service1SoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1SoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1SoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1SoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet Get_Company() {
            return base.Channel.Get_Company();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> Get_CompanyAsync() {
            return base.Channel.Get_CompanyAsync();
        }
        
        public System.Data.DataSet Get_Circle(string company, string circle) {
            return base.Channel.Get_Circle(company, circle);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> Get_CircleAsync(string company, string circle) {
            return base.Channel.Get_CircleAsync(company, circle);
        }
        
        public System.Data.DataSet Get_Division(string circle, string divisionc) {
            return base.Channel.Get_Division(circle, divisionc);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> Get_DivisionAsync(string circle, string divisionc) {
            return base.Channel.Get_DivisionAsync(circle, divisionc);
        }
        
        public System.Data.DataSet Get_Sub_Division(string subdivision, string subdivision_1, string division, string divisionc) {
            return base.Channel.Get_Sub_Division(subdivision, subdivision_1, division, divisionc);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> Get_Sub_DivisionAsync(string subdivision, string subdivision_1, string division, string divisionc) {
            return base.Channel.Get_Sub_DivisionAsync(subdivision, subdivision_1, division, divisionc);
        }
        
        public System.Data.DataSet Get_Complaint_Centre(string facilityid, string subdivision, string subdivisionc) {
            return base.Channel.Get_Complaint_Centre(facilityid, subdivision, subdivisionc);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> Get_Complaint_CentreAsync(string facilityid, string subdivision, string subdivisionc) {
            return base.Channel.Get_Complaint_CentreAsync(facilityid, subdivision, subdivisionc);
        }
    }
}
