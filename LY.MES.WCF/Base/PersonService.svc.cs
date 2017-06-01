using LY.MES.Model;
using LY.MES.Service.Base;
using Server.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LY.MES.WCF.Base
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“PersonService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 PersonService.svc 或 PersonService.svc.cs，然后开始调试。
    public class PersonService : IPersonService
    {
        public CommonResult<Person> GetPersonByCode(string sessionId,string strCode)
        {
            try
            {
                return ForPersonalInfoServices.GetInstance(sessionId).GetPersonByCode(strCode);
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage(){
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                },ex.Message);
            }
        }

        public CommonResult<List<Person>> GetPersonList(string sessionId,Tuple<string, List<object>> tFilter, int PageSize, int CurrPage)
        {
            try
            {
                return ForPersonalInfoServices.GetInstance(sessionId).GetPersonList(tFilter,PageSize,CurrPage);
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage(){
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                },ex.Message);
            }
        }

        public CommonResult<Person> AddPersonData(string sessionId,Person Model)
        {
            try
            {
                return ForPersonalInfoServices.GetInstance(sessionId).AddPersonData(Model);
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                },ex.Message);
            }
        }

        public CommonResult<Person> UpdataPersonData(string sessionId ,Person Model)
        {
            try
            {
                return ForPersonalInfoServices.GetInstance(sessionId).UpdataPersonData(Model);
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage() { 
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                });
            }
        }

        public CommonResult<bool> DelPersonData(string sessionId,string strPersonCode)
        {
            try
            {
                return ForPersonalInfoServices.GetInstance(sessionId).DelPersonData(strPersonCode);
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                },ex.Message);
            }
        }
    }
}
