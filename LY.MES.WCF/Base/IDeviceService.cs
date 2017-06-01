
using LY.MES.Model;
using LY.MES.Model.VModel;
using Server.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LY.MES.WCF.Base
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IDeviceService”。
    [ServiceContract]
    public interface IDeviceService
    {

        #region 设备分类

        /// <summary>
        /// 新增设备分类
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<DeviceClass> AddDeviceClass(string sessionId, DeviceClass model);
        /// <summary>
        /// 增加设备参数数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<DeviceParameter> AddDevParameter(string sessionId, DeviceParameter model);
        /// <summary>
        /// 按照设备编号查询设备参数列表
        /// 
        /// </summary>
        /// <param name="strCode"></param>
        /// <returns></returns>
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        //  CommonResult<DeviceParameter> GetDevParameterByCode(string strCode);
        CommonResult<List<DeviceParameter>> GetDevParameterByCode(string sessionId, string strCode);

        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<List<DeviceParameter>> GetDevParByCodePaging(string sessionId, int PageSize, int CurrPage, ref int TotalNum, string strCode);

        /// <summary>
        /// xxp 20161102 获取设备参数分页列表
        /// </summary>
        /// <param name="tWhere">过滤条件对象</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="CurrPage">页码</param>
        /// <returns>返回对象</returns>
        [OperationContract, FaultContract(typeof(CustomFaultMessage)), Server.Utility.CHKUserAuth]
        CommonResult<List<DeviceParameter>> GetDevParameterPagedList(string sessionId, Tuple<string, List<object>> tWhere, int PageSize, int CurrPage);

        [Server.Utility.CHKUserAuth]
        [FaultContract(typeof(CustomFaultMessage))]
        [OperationContract]
        CommonResult<DeviceParameter> UpdatDevParameter(string sessionId, DeviceParameter model);

        [Server.Utility.CHKUserAuth]
        [FaultContract(typeof(CustomFaultMessage))]
        [OperationContract]
        CommonResult<bool> DelDevParameterByCode(string sessionId, string strCode);


        /// <summary>
        /// 更新设备分类
        /// </summary>
        /// <param name="model">设备分类对象</param>
        /// <returns>返回处理结果</returns>
        [Server.Utility.CHKUserAuth]
        [FaultContract(typeof(CustomFaultMessage))]
        [OperationContract]
        CommonResult<DeviceClass> UpdateDeviceClass(string sessionId, DeviceClass model);

        /// <summary>
        /// 获取单个设备分类
        /// </summary>
        /// <param name="strCode">设备分类编码</param>
        /// <returns>返回处理结果</returns>
        [Server.Utility.CHKUserAuth]
        [FaultContract(typeof(CustomFaultMessage))]
        [OperationContract]
        CommonResult<DeviceClass> GetDeviceClassByCode(string sessionId, string strCode);

        /// <summary>
        /// 获取设备分类集合
        /// </summary>
        /// <returns>返回处理结果</returns>
        [Server.Utility.CHKUserAuth]
        [FaultContract(typeof(CustomFaultMessage))]
        [OperationContract]
        CommonResult<List<DeviceClass>> GetDeviceClassList(string sessionId);


        /// <summary>
        /// 删除单个设备分类
        /// </summary>
        /// <param name="strCode">设备分类编码</param>
        /// <returns>返回处理结果</returns>
        [Server.Utility.CHKUserAuth]
        [FaultContract(typeof(CustomFaultMessage))]
        [OperationContract]
        CommonResult<bool> DelDeviceClassByCode(string sessionId, string strCode);

        #endregion

        #region 设备档案

        /// <summary>
        /// 新增设备
        /// </summary>
        /// <param name="model">设备分类</param>
        /// <returns>返回处理结果</returns>
        [Server.Utility.CHKUserAuth]
        [FaultContract(typeof(CustomFaultMessage))]
        [OperationContract]
        CommonResult<Device> AddDevice(string sessionId, Device model);

        /// <summary>
        /// 更新设备档案
        /// </summary>
        /// <param name="model">设备档案对象</param>
        /// <returns>返回处理结果</returns>
        [Server.Utility.CHKUserAuth]
        [FaultContract(typeof(CustomFaultMessage))]
        [OperationContract]
        CommonResult<Device> UpdateDevice(string sessionId, Device model);

        /// <summary>
        /// 获取单个设备档案
        /// </summary>
        /// <param name="strCode">设备档案编码</param>
        /// <returns>返回处理结果</returns>
        [Server.Utility.CHKUserAuth]
        [FaultContract(typeof(CustomFaultMessage))]
        [OperationContract]
        CommonResult<Device> GetDeviceByCode(string sessionId, string strCode);



        /// <summary>
        /// 删除单个设备档案
        /// </summary>
        /// <param name="strCode">设备编码</param>
        /// <returns>返回处理结果</returns>
        [Server.Utility.CHKUserAuth]
        [FaultContract(typeof(CustomFaultMessage))]
        [OperationContract]
        CommonResult<bool> DelDeviceByCode(string sessionId, string strCode);

        /// <summary>
        /// pjh 20161102 获取设备档案分页列表
        /// </summary>
        /// <param name="tWhere">过滤条件对象</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="CurrPage">页码</param>
        /// <returns>返回对象</returns>
        [OperationContract, Server.Utility.CHKUserAuth, FaultContract(typeof(CustomFaultMessage))]
        CommonResult<List<Device>> GetDevicePagedList(string sessionId, Tuple<string, List<object>> tWhere, int PageSize, int CurrPage);

        [OperationContract, Server.Utility.CHKUserAuth, FaultContract(typeof(CustomFaultMessage))]
        CommonResult<List<VDeviceInfo>> GetVDeviceInfoPagedList(string sessionId, Tuple<string, List<object>> tFilter, int PageSize, int CurrPage);

        #endregion

        #region 设备接口

        /// <summary>
        /// 新增设备接口
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Server.Utility.CHKUserAuth]
        [FaultContract(typeof(CustomFaultMessage))]
        [OperationContract]
        CommonResult<DeviceInterface> AddDeviceInterface(string sessionId, DeviceInterface model);

        /// <summary>
        /// 更新设备接口
        /// </summary>
        /// <param name="model">设备接口对象</param>
        /// <returns>返回处理结果</returns>
        [Server.Utility.CHKUserAuth]
        [FaultContract(typeof(CustomFaultMessage))]
        [OperationContract]
        CommonResult<DeviceInterface> UpdateDeviceInterface(string sessionId, DeviceInterface model);

        /// <summary>
        /// 获取单个设备接口
        /// </summary>
        /// <param name="strCode">设备接口编码</param>
        /// <returns>返回处理结果</returns>
        [Server.Utility.CHKUserAuth]
        [FaultContract(typeof(CustomFaultMessage))]
        [OperationContract]
        CommonResult<DeviceInterface> GetDeviceInterface(string sessionId, string strDeviCode, string strDevCode);

        /// <summary>
        /// 获取设备分类集合
        /// </summary>
        /// <returns>返回处理结果</returns>
        [Server.Utility.CHKUserAuth]
        [FaultContract(typeof(CustomFaultMessage))]
        [OperationContract]
        CommonResult<List<DeviceInterface>> GetDeviceInterfaceList(string sessionId, int PageSize, int CurrPage, ref int TotalNum, string strDevCode);


        /// <summary>
        /// 删除单个设备分类
        /// </summary>
        /// <param name="strCode">设备接口编码</param>
        /// <returns>返回处理结果</returns>
        [Server.Utility.CHKUserAuth]
        [FaultContract(typeof(CustomFaultMessage))]
        [OperationContract]
        CommonResult<bool> DelDeviceInterface(string sessionId, string strDeviCode, string strDevCode);

        /// <summary>
        /// pjh 20161102 获取设备档案分页列表
        /// </summary>
        /// <param name="tWhere">过滤条件对象</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="CurrPage">页码</param>
        /// <returns>返回对象</returns>
        [Server.Utility.CHKUserAuth]
        [FaultContract(typeof(CustomFaultMessage))]
        [OperationContract]
        CommonResult<List<DeviceInterface>> GetDevInterfacePagedList(string sessionId, Tuple<string, List<object>> tWhere, int PageSize, int CurrPage);

        #endregion
    }
}
