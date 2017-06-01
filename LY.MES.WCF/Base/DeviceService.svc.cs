using LY.MES.Model;
using LY.MES.Model.VModel;
using LY.MES.Service.Base;
using Server.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Server.Utility.Logging;

namespace LY.MES.WCF.Base
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“DeviceService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 DeviceService.svc 或 DeviceService.svc.cs，然后开始调试。
    public class DeviceService : IDeviceService
    {
        public Server.Utility.CommonResult<DeviceParameter> AddDevParameter(string sessionId, DeviceParameter model)
        {
            try
            {
                return ForDeviceServices.GetInstance(sessionId).AddDevParameter(model);
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

        public Server.Utility.CommonResult<List<DeviceParameter>> GetDevParameterByCode(string sessionId, string strCode)
        {
            try
            {
                return ForDeviceServices.GetInstance(sessionId).GetDevParameterByCode(strCode);
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

        public Server.Utility.CommonResult<List<DeviceParameter>> GetDevParByCodePaging(string sessionId, int PageSize, int CurrPage, ref int TotalNum, string strCode)
        {
            try
            {
                return ForDeviceServices.GetInstance(sessionId).GetDevParByCodePaging(PageSize, CurrPage, ref TotalNum, strCode);
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

        /// <summary>
        /// xxp 20161102 获取设备参数分页列表
        /// </summary>
        /// <param name="tWhere">过滤条件对象</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="CurrPage">页码</param>
        /// <returns>返回对象</returns>
        public CommonResult<List<DeviceParameter>> GetDevParameterPagedList(string sessionId, Tuple<string, List<object>> tWhere, int PageSize, int CurrPage)
        {
            try
            {
                return ForDeviceServices.GetInstance(sessionId).GetDevParameterPagedList(tWhere, PageSize, CurrPage);
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

        public CommonResult<List<VDeviceInfo>> GetVDeviceInfoPagedList(string sessionId, Tuple<string, List<object>> tFilter, int PageSize, int CurrPage)
        {
            try
            {
                return ForDeviceServices.GetInstance(sessionId).GetVDeviceInfoPagedList(tFilter, PageSize, CurrPage);
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
        /// <summary>
        /// pjh 20161102 获取设备档案分页列表
        /// </summary>
        /// <param name="tWhere">过滤条件对象</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="CurrPage">页码</param>
        /// <returns>返回对象</returns>
        public CommonResult<List<Device>> GetDevicePagedList(string sessionId, Tuple<string, List<object>> tWhere, int PageSize, int CurrPage)
        {
            try
            {
                return ForDeviceServices.GetInstance(sessionId).GetDevicePagedList(tWhere, PageSize, CurrPage);
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


        /// <summary>
        /// pjh 20161102 获取设备档案分页列表
        /// </summary>
        /// <param name="tWhere">过滤条件对象</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="CurrPage">页码</param>
        /// <returns>返回对象</returns>
        public CommonResult<List<DeviceInterface>> GetDevInterfacePagedList(string sessionId, Tuple<string, List<object>> tWhere, int PageSize, int CurrPage)
        {
            try
            {
                return ForDevInterfaceServices.GetInstance(sessionId).GetDevInterfacePagedList(tWhere, PageSize, CurrPage);
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

        public Server.Utility.CommonResult<DeviceParameter> UpdatDevParameter(string sessionId, DeviceParameter model)
        {
            try
            {
                return ForDeviceServices.GetInstance(sessionId).UpdatDevParameter(model);
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

        public Server.Utility.CommonResult<bool> DelDevParameterByCode(string sessionId, string strCode)
        {
            try
            {
                return ForDeviceServices.GetInstance(sessionId).DelDevParameterByCode(strCode);
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


        public Server.Utility.CommonResult<DeviceClass> AddDeviceClass(string sessionId, DeviceClass model)
        {
            try
            {
                return ForDeviceServices.GetInstance(sessionId).AddDeviceClass(model);
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

        /// <summary>
        /// 增加设备参数数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Server.Utility.CommonResult<DeviceClass> UpdateDeviceClass(string sessionId, DeviceClass model)
        {
            try
            {
                return ForDeviceServices.GetInstance(sessionId).UpdateDeviceClass(model);
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

        public Server.Utility.CommonResult<DeviceClass> GetDeviceClassByCode(string sessionId, string strCode)
        {
            try
            {
                return ForDeviceServices.GetInstance(sessionId).GetDeviceClassByCode(strCode);
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

        public Server.Utility.CommonResult<List<DeviceClass>> GetDeviceClassList(string sessionId)
        {
            try
            {
                var result = new Server.Utility.CommonResult<List<DeviceClass>>();
                Stopwatch ww = new Stopwatch();
                ww.Start();
                result = ForDeviceServices.GetInstance(sessionId).GetDeviceClassList();
                ww.Stop();
                long l = ww.ElapsedMilliseconds;
                Utils.Logger.Debug("时长:" + l.ToString());
                return result;
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

        public Server.Utility.CommonResult<bool> DelDeviceClassByCode(string sessionId, string strCode)
        {
            try
            {
                return ForDeviceServices.GetInstance(sessionId).DelDeviceClassByCode(strCode);
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

        public Server.Utility.CommonResult<Device> AddDevice(string sessionId, Device model)
        {
            try
            {
                return ForDeviceServices.GetInstance(sessionId).AddDevice(model);
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

        public Server.Utility.CommonResult<Device> UpdateDevice(string sessionId, Device model)
        {
            try
            {
                return ForDeviceServices.GetInstance(sessionId).UpdateDevice(model);
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

        public Server.Utility.CommonResult<Device> GetDeviceByCode(string sessionId, string strCode)
        {
            try
            {
                return ForDeviceServices.GetInstance(sessionId).GetDeviceByCode(strCode);
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

        public Server.Utility.CommonResult<bool> DelDeviceByCode(string sessionId, string strCode)
        {
            try
            {
                return ForDeviceServices.GetInstance(sessionId).DelDeviceByCode(strCode);
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


        /// <summary>
        /// 新增设备接口信息
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public Server.Utility.CommonResult<DeviceInterface> AddDeviceInterface(string sessionId, DeviceInterface model)
        {

            try
            {

                return ForDevInterfaceServices.GetInstance(sessionId).AddDeviceInterface(model);
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
        /// <summary>
        /// 修改更新设备接口信息
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public Server.Utility.CommonResult<DeviceInterface> UpdateDeviceInterface(string sessionId, DeviceInterface model)
        {
            try
            {
                return ForDevInterfaceServices.GetInstance(sessionId).UpdateDeviceInterface(model);
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

        /// <summary>
        /// 双主键设备编码、设备接口查询
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="strDeviCode"></param>
        /// <param name="strDevCode"></param>
        /// <returns></returns>
        public Server.Utility.CommonResult<DeviceInterface> GetDeviceInterface(string sessionId, string strDeviCode, string strDevCode)
        {
            try
            {
                return ForDevInterfaceServices.GetInstance(sessionId).GetDeviceInterface(strDeviCode, strDevCode);
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
        /// <summary>
        /// 删除设备接口信息
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="strDeviCode"></param>
        /// <param name="strDevCode"></param>
        /// <returns></returns>
        public Server.Utility.CommonResult<bool> DelDeviceInterface(string sessionId, string strDeviCode, string strDevCode)
        {
            try
            {
                return ForDevInterfaceServices.GetInstance(sessionId).DelDeviceInterface(strDeviCode, strDevCode);
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

        /// <summary>
        /// 查询同属一设备编码中的接口列表信息
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="PageSize"></param>
        /// <param name="CurrPage"></param>
        /// <param name="TotalNum"></param>
        /// <param name="strDevCode"></param>
        /// <returns></returns>
        public Server.Utility.CommonResult<List<DeviceInterface>> GetDeviceInterfaceList(string sessionId, int PageSize, int CurrPage, ref int TotalNum, string strDevCode)
        {
            try
            {
                return ForDevInterfaceServices.GetInstance(sessionId).GetDeviceInterfaceList(PageSize, CurrPage, ref TotalNum, strDevCode);
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
