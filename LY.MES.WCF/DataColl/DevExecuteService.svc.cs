using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LY.MES.Model;
using LY.MES.Service.Base;
using LY.MES.Service.DataColl;
using LY.MES.Model.VModel;

using Server.Utility;
using Server.Utility.Logging;




namespace LY.MES.WCF.DataColl
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“DevExecuteService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 DevExecuteService.svc 或 DevExecuteService.svc.cs，然后开始调试。
    public class DevExecuteService : IDevExecuteService
    {
        public void DoWork()
        {
        }

        public Server.Utility.CommonResult<List<DeviceExecute>> GetDeviceExecuteList(string sessionId)
        {

            try
            {
                return ForDevExecuteServices.GetInstance(sessionId).GetDeviceExecuteList();

            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }

        //  GetDeviceExecute



        public Server.Utility.CommonResult<DeviceExecute> GetDeviceExecute(string sessionId, string strDeviCode)
        {
            //  return ForDeviceExecute.GetInstance(sessionId).GetDeviceExecute(strDeviCode);
            try
            {
                return ForDevExecuteServices.GetInstance(sessionId).GetDeviceExecute(strDeviCode);

            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }



        public Server.Utility.CommonResult<DeviceExecute> AddDeviceExecute(string sessionId, DeviceExecute model)
        {
            try
            {
                return ForDevExecuteServices.GetInstance(sessionId).AddDeviceExecute(model);

            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }

        }

        public Server.Utility.CommonResult<DeviceExecute> UpdateDeviceExecute(string sessionId, DeviceExecute model)
        {
            //  return ForDeviceExecute.GetInstance(sessionId).UpdateDeviceExecute(model);
            try
            {
                return ForDevExecuteServices.GetInstance(sessionId).UpdateDeviceExecute(model);

            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }

        }

        public Server.Utility.CommonResult<bool> DelDeviceExecute(string sessionId, int StrDeveCode)
        {

            try
            {
                return ForDevExecuteServices.GetInstance(sessionId).DelDeviceExecute(StrDeveCode);

            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }

        }

        public Server.Utility.CommonResult<List<DeviceExecute>> GetDevExecutePagedList(string sessionId, Tuple<string, List<object>> tWhere, int PageSize, int CurrPage)
        {
            try
            {
                return ForDevExecuteServices.GetInstance(sessionId).GetDevExecutePagedList(tWhere, PageSize, CurrPage);
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }


        }



        //public Server.Utility.CommonResult<List<DeviceExecute>> IDevExecuteService.GetDevViewList(string sessionId)
        //{
        //    throw new NotImplementedException();
        //}

        public Server.Utility.CommonResult<List<V_DV_DevExecute>> GetDevViewList(string sessionId)
        {
            try
            {
                return ForDevExecuteServices.GetInstance(sessionId).GetDevViewList();

            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }

        //  public Server.Utility.CommonResult<List<V_DV_DevExecute>>

        public Server.Utility.CommonResult<List<V_DV_DevExecute>> GetDevViewListByAddress(string sessionId, string Address)
        {
            try
            {
                return ForDevExecuteServices.GetInstance(sessionId).GetDevViewListByAddress(Address);

            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }

        }


        public Server.Utility.CommonResult<List<V_DV_DevExecute>> GetDevViewListByZGName(string sessionId, string Address)
        {
            try
            {
                return ForDevExecuteServices.GetInstance(sessionId).GetDevViewListByZGName(Address);

            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }

        }


        public Server.Utility.CommonResult<V_DV_DevExecute> GetDeviceExecuteByID(string sessionId, int strExctueID)
        {
            try
            {
                return ForDevExecuteServices.GetInstance(sessionId).GetDeviceExecuteByID(strExctueID);

            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }


        public List<string> GetDevViewListAllAddress(string sessionId)
        {
            try
            {
                return ForDevExecuteServices.GetInstance(sessionId).GetDevViewListAllAddress();

            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }

        }

        public List<string> GetDevViewListAllDevName(string sessionId)
        {
            try
            {
                return ForDevExecuteServices.GetInstance(sessionId).GetDevViewListAllDevName();

            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }

        }


        public List<System.Linq.IGrouping<string, V_DV_DevExecute>> GetDevViewListAllIP(string sessionId)
        {
            try
            {
                return ForDevExecuteServices.GetInstance(sessionId).GetDevViewListAllIP();

            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }

        }

        public CommonResult<List<V_DV_DevExecute>> GetDeviceExecuteByDevCode(string sessionId, string strDevCode)
        {
            try
            {
                return ForDevExecuteServices.GetInstance(sessionId).GetDeviceExecuteByDevCode(strDevCode);
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }

        public CommonResult<List<V_DV_DevExecute>> GetViewExecIDByDeviName(string sessionId, string JiHao, string IrconTroughName, string Serial)
        {
            try
            {
                return ForDevExecuteServices.GetInstance(sessionId).GetViewExecIDByDeviName(JiHao, IrconTroughName, Serial);
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }


        public CommonResult<List<V_DV_DevExecute>> GetViewExecIDByIrcon(string sessionId, string JiHao, string IrconTroughName)
        {
            try
            {
                return ForDevExecuteServices.GetInstance(sessionId).GetViewExecIDByIrcon(JiHao, IrconTroughName);
            }
            catch (Exception ex)
            {
                throw new FaultException<CustomFaultMessage>(new CustomFaultMessage()
                {
                    ErrorCode = ex.HResult,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                }, ex.Message);
            }
        }

    }
}
