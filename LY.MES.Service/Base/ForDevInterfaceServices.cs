
using LY.MES.Model;
using LY.MES.Model.VModel;
using Server.Utility;
using Server.Utility.UserAuth;
using System;
using LY.MES.Manage;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LY.MES.Manage.Commonn;
using System.Linq.Expressions;
using Server.Utility.Logging;

namespace LY.MES.Service.Base
{
    /// <summary>
    /// Author:pjh
    /// Remark:设备接口服务类
    /// CreateTime:20161103
    /// </summary>
    public class ForDevInterfaceServices
    {
         protected UserSession currUserSession;

        /// <summary>
        /// 获取设备信息类
        /// </summary>
        /// <param name="sessionId">会话ID</param>
        /// <returns></returns>
        public static ForDevInterfaceServices GetInstance(string sessionId)
        {
            return new ForDevInterfaceServices(sessionId);
        }

        private ForDevInterfaceServices() { }

        /// <summary>
        /// 设备信息服务类
        /// </summary>
        /// <param name="sessionId">会话Id</param>
        protected ForDevInterfaceServices(string sessionId)
        {
            currUserSession = SvrUserSession.GetCurrSession(sessionId);
        }

        #region 设备接口

        /// <summary>
        /// 新增设备接口
        /// </summary>
        /// <param name="model">设备接口对象</param>
        /// <returns>返回处理结果</returns>
        public CommonResult<DeviceInterface> AddDeviceInterface(DeviceInterface model)
        {
            var result = new CommonResult<DeviceInterface>();
            try
            {
                CheckDeviceInterface(model, result);
                if (result.IsSuccess)
                {
                    var dbSession = new DBService<DeviceInterface>().DbSession;
                    if (dbSession.GetQueryable(t => t.DeviCode == model.DeviCode && t.DevCode == model.DevCode).FirstOrDefault() != null)
                    {
                        result.IsSuccess = false;
                        result.Message = "设备编码不存在！";
                    }                  
                    else
                    {
                        result.Data = dbSession.Insert(model);
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 更新设备接口
        /// </summary>
        /// <param name="model">设备接口对象</param>
        /// <returns>返回处理结果</returns>
        public CommonResult<DeviceInterface> UpdateDeviceInterface(DeviceInterface model)
        {
            var result = new CommonResult<DeviceInterface>();
            try
            {
                CheckDeviceInterface(model, result);
                if (result.IsSuccess)
                {
                    var dbSession = new DBService<DeviceInterface>().DbSession;
                    if (dbSession.GetQueryable(t => t.DeviCode == model.DeviCode && t.DevCode == model.DevCode).FirstOrDefault() == null)
                    {
                        result.IsSuccess = false;
                        result.Message = "设备编码不存在！";
                    }                 
                    else
                    {
                        result.Data = dbSession.Update(model);
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 获取单个设备接口
        /// </summary>
        /// <param name="strCode">设备接口编码</param>
        /// <returns>返回处理结果</returns>
        public CommonResult<DeviceInterface> GetDeviceInterface(string strDeviCode, string strDevCode)
        {
            var result = new CommonResult<DeviceInterface>();
            try
            {
                var dbSession = new DBService<DeviceInterface>().DbSession;
                result.Data = dbSession.GetQueryable(t => t.DeviCode == strDeviCode && t.DevCode == strDevCode).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 获取设备接口集合
        /// </summary>
        /// <param name="PageSize">每页大小</param>
        /// <param name="CurrPage">当前页面</param>
        /// <param name="TotalNum">总条数</param>
        /// <param name="strDevCode">设备编码</param>
        /// <param name="strDeviCode">设备接口编码</param>
        /// <param name="strDeviName">设备接口名称</param>
        /// <returns></returns>
        public CommonResult<List<DeviceInterface>> GetDeviceInterfaceList(int PageSize, int CurrPage, ref int TotalNum, string DevCode)//int PageSize, int CurrPage, ref int TotalNum,
        {
            var result = new CommonResult<List<DeviceInterface>>();           
                try
                {
                    var dbSession = new DBService<DeviceInterface>().DbSession;
                    var query = dbSession.GetQueryable().Where(t => t.DevCode == DevCode);
                    TotalNum = query.ToList().Count();
                    result.Data = query.ToList().Take(PageSize * CurrPage).Skip(PageSize * (CurrPage - 1)).ToList();                   
                   
                }
                catch (Exception ex)
                {
                    Utils.Logger.Error(ex.Message);
                    throw ex;
                }
            return result;
        }

        /// <summary>
        /// pjh 20161102 获取设备档案分页列表
        /// </summary>
        /// <param name="tWhere">过滤条件对象</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="CurrPage">页码</param>
        /// <returns>返回对象</returns>
        public CommonResult<List<DeviceInterface>> GetDevInterfacePagedList(Tuple<string, List<object>> tWhere, int PageSize, int CurrPage)
        {
            var result = new CommonResult<List<DeviceInterface>>();
            try
            {

                var dbSession = new DBService<DeviceInterface>().DbSession;

                var query = dbSession.GetQueryable();

                if (tWhere != null && tWhere.Item2.Count() > 0)
                {
                    Expression<Func<DeviceInterface, bool>> eWhere = System.Linq.Dynamic.DynamicExpression.ParseLambda<DeviceInterface, bool>(
                        tWhere.Item1, tWhere.Item2.ToArray());

                    query = query.Where(eWhere);
                }
                result.TotalNum = query.Count();

                result.Data = query.ToList().Take(PageSize * CurrPage).Skip(PageSize * (CurrPage - 1)).ToList();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
            return result;
        }


        /// <summary>
        /// 删除单个设备接口
        /// </summary>
        /// <param name="strCode">设备接口编码</param>
        /// <returns>返回处理结果</returns>
        public CommonResult<bool> DelDeviceInterface(string strDeviCode, string strDevCode)
        {
            var result = new CommonResult<bool>();
            try
            {
                var dbSession = new DBService<DeviceInterface>().DbSession;
                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {
                    var model = dbSession.GetQueryable(t => t.DeviCode == strDeviCode && t.DevCode == strDevCode).FirstOrDefault();
                    if (model == null)
                    {
                        result.IsSuccess = false;
                        result.Message = "该设备信息已经不存在";
                    }

                    if (result.IsSuccess)
                    {
                        dbSession.Delete(model);
                        ts.Complete();
                        result.Data = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 检查设备数据
        /// </summary>
        /// <param name="model">实体对象</param>
        /// <param name="result">返回值</param>
        private void CheckDeviceInterface(DeviceInterface model, CommonResult<DeviceInterface> result)
        {
            if (model == null)
            {
                result.IsSuccess = false;
                result.Message = "设备对象不能为空";
            }
            else if (string.IsNullOrEmpty(model.DeviCode))
            {
                result.IsSuccess = false;
                result.Message = "接口编码不能为空！";
            }
            else if (string.IsNullOrEmpty(model.DeviName))
            {
                result.IsSuccess = false;
                result.Message = "接口名称不能为空!";
            }
            else if (string.IsNullOrEmpty(model.DevCode))
            {
                result.IsSuccess = false;
                result.Message = "设备编码不能为空!";
            }
        }
        #endregion       
    }
}
