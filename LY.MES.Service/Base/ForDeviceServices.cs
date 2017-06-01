
using LY.MES.Model;
using LY.MES.Model.VModel;
using Server.Utility;
using Server.Utility.UserAuth;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Server.Utility.Logging;
using LY.MES.Manage.Common;
using System.Transactions;

namespace LY.MES.Service.Base
{
    /// <summary>
    /// Author:xxp
    /// Remark:设备服务类
    /// CreateTime:20161013
    /// </summary>
    public class ForDeviceServices
    {
        protected UserSession currUserSession;

        /// <summary>
        /// 获取设备信息类
        /// </summary>
        /// <param name="sessionId">会话ID</param>
        /// <returns></returns>
        public static ForDeviceServices GetInstance(string sessionId)
        {
            return new ForDeviceServices(sessionId);
        }

        private ForDeviceServices() { }

        /// <summary>
        /// 设备信息服务类
        /// </summary>
        /// <param name="sessionId">会话Id</param>
        protected ForDeviceServices(string sessionId)
        {
            currUserSession = SvrUserSession.GetCurrSession(sessionId);
        }

        #region 设备分类

        /// <summary>
        /// 新增设备分类
        /// </summary>
        /// <param name="model">设备分类对象</param>
        /// <returns>返回处理结果</returns>
        public CommonResult<DeviceClass> AddDeviceClass(DeviceClass model)
        {
            var result = new CommonResult<DeviceClass>();
            try
            {
                CheckDeviceClass(model, result);
                if (result.IsSuccess)
                {
                    var dbSession = new DBService<DeviceClass>().DbSession;
                    if (dbSession.GetQueryable(t => t.DevCCode == model.DevCCode).FirstOrDefault() != null)
                    {
                        result.IsSuccess = false;
                        result.Message = "设备分类编码不能重复！";
                    }
                    else if (string.IsNullOrEmpty(model.SupCCode) == false && dbSession.GetQueryable(t => t.DevCCode == model.SupCCode).FirstOrDefault() == null)
                    {
                        result.IsSuccess = false;
                        result.Message = "设备分类上级不存在！";
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
        /// 更新设备分类
        /// </summary>
        /// <param name="model">设备分类对象</param>
        /// <returns>返回处理结果</returns>
        public CommonResult<DeviceClass> UpdateDeviceClass(DeviceClass model)
        {
            var result = new CommonResult<DeviceClass>();
            try
            {
                CheckDeviceClass(model, result);
                if (result.IsSuccess)
                {
                    var dbSession = new DBService<DeviceClass>().DbSession;
                    if (dbSession.GetQueryable(t => t.DevCCode == model.DevCCode).FirstOrDefault() == null)
                    {
                        result.IsSuccess = false;
                        result.Message = "设备分类信息不存在";
                    }
                    else if (string.IsNullOrEmpty(model.SupCCode) == false && dbSession.GetQueryable(t => t.DevCCode == model.SupCCode).FirstOrDefault() == null)
                    {
                        result.IsSuccess = false;
                        result.Message = "设备分类上级不存在！";
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
        /// 获取单个设备分类
        /// </summary>
        /// <param name="strCode">设备分类编码</param>
        /// <returns>返回处理结果</returns>
        public CommonResult<DeviceClass> GetDeviceClassByCode(string strCode)
        {
            var result = new CommonResult<DeviceClass>();
            try
            {
                var dbSession = new DBService<DeviceClass>().DbSession;
                result.Data = dbSession.GetQueryable(t => t.DevCCode == strCode).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 获取设备分类集合
        /// </summary>
        /// <returns>返回处理结果</returns>
        public CommonResult<List<DeviceClass>> GetDeviceClassList()
        {
            var result = new CommonResult<List<DeviceClass>>();
            try
            {
                var dbSession = new DBService<DeviceClass>().DbSession;
                result.Data = dbSession.GetQueryable().OrderBy(t => t.DevCCode).OrderBy(t => t.Grade).ToList();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 删除单个设备分类
        /// </summary>
        /// <param name="strCode">设备分类编码</param>
        /// <returns>返回处理结果</returns>
        public CommonResult<bool> DelDeviceClassByCode(string strCode)
        {
            var result = new CommonResult<bool>();
            try
            {
                var dbSession = new DBService<DeviceClass>().DbSession;
                var dbSession1 = new DBService<Device>().DbSession;
                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {
                    var model = dbSession.GetQueryable(t => t.DevCCode == strCode).FirstOrDefault();
                    if (model == null)
                    {
                        result.IsSuccess = false;
                        result.Message = "该设备分类信息已经不存在";
                    }
                    else if (dbSession.GetQueryable(t => t.SupCCode == strCode).Count() > 0)
                    {
                        result.IsSuccess = false;
                        result.Message = "不能直接删除上级分类";
                    }
                    else if (dbSession1.GetQueryable(t => t.DevCCode == strCode).Count() > 0)
                    {
                        result.IsSuccess = false;
                        result.Message = "分类已经与设备档案关联，不能删除";
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
        private void CheckDeviceClass(DeviceClass model, CommonResult<DeviceClass> result)
        {
            if (model == null)
            {
                result.IsSuccess = false;
                result.Message = "设备分类对象不能为空";
            }
            else if (string.IsNullOrEmpty(model.DevCCode))
            {
                result.IsSuccess = false;
                result.Message = "设备分类编码不能为空！";
            }
            else if (string.IsNullOrEmpty(model.DevCName))
            {
                result.IsSuccess = false;
                result.Message = "设备分类名称不能为空!";
            }
        }

        #endregion

        #region 设备档案

        /// <summary>
        /// 新增设备
        /// </summary>
        /// <param name="model">设备分类</param>
        /// <returns>返回处理结果</returns>
        public CommonResult<Device> AddDevice(Device model)
        {
            var result = new CommonResult<Device>();
            try
            {
                CheckDevice(model, result);
                if (result.IsSuccess)
                {
                    var dbSession = new DBService<Device>().DbSession;
                    var dbSession1 = new DBService<DeviceClass>(dbSession.Context).DbSession;
                    var dbSession2 = new DBService<DeviceWorkingCondition>(dbSession.Context).DbSession;

                    if (dbSession.GetQueryable(t => t.DevCode == model.DevCode).FirstOrDefault() != null)
                    {
                        result.IsSuccess = false;
                        result.Message = "设备编码不能重复";
                    }
                    else if (dbSession.GetQueryable(t => t.DevName == model.DevName).FirstOrDefault() != null)
                    {
                        result.IsSuccess = false;
                        result.Message = "设备名称不能重复";
                    }
                    else if (dbSession1.GetQueryable(t => t.DevCCode == model.DevCCode).FirstOrDefault() == null)
                    {
                        result.IsSuccess = false;
                        result.Message = "设备的分类编码不存在！";
                    }
                    else
                    {
                        using (TransactionScope ts = new TransactionScope())
                        {
                            var newModel = dbSession.Insert(model);
                            dbSession2.Insert(new DeviceWorkingCondition()
                            {
                                DevCode = newModel.DevCode,
                                DevName = newModel.DevName,
                                WorkingStatus = 0
                            });
                            ts.Complete();
                            result.Data = newModel;
                        }
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
        /// 更新设备档案
        /// </summary>
        /// <param name="model">设备档案对象</param>
        /// <returns>返回处理结果</returns>
        public CommonResult<Device> UpdateDevice(Device model)
        {
            var result = new CommonResult<Device>();
            try
            {
                CheckDevice(model, result);
                if (result.IsSuccess)
                {
                    var dbSession = new DBService<Device>().DbSession;
                    var dbSession1 = new DBService<DeviceClass>(dbSession.Context).DbSession;
                    if (dbSession.GetQueryable(t => t.DevCode == model.DevCode).FirstOrDefault() == null)
                    {
                        result.IsSuccess = false;
                        result.Message = "设备档案信息不存在！";
                    }
                    else if (dbSession.GetQueryable(t => t.DevName == model.DevName && t.DevCode != model.DevCode).FirstOrDefault() != null)
                    {
                        result.IsSuccess = false;
                        result.Message = "设备名称不能重复!";
                    }
                    else if (dbSession1.GetQueryable(t => t.DevCCode == model.DevCCode).FirstOrDefault() == null)
                    {
                        result.IsSuccess = false;
                        result.Message = "设备的分类编码不存在！";
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
        /// 获取单个设备档案
        /// </summary>
        /// <param name="strCode">设备档案编码</param>
        /// <returns>返回处理结果</returns>
        public CommonResult<Device> GetDeviceByCode(string strCode)
        {
            var result = new CommonResult<Device>();
            try
            {
                var dbSession = new DBService<Device>().DbSession;
                result.Data = dbSession.GetQueryable(t => t.DevCode == strCode).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 获取设备档案集合
        /// </summary>
        /// <param name="PageSize">每页大小</param>
        /// <param name="CurrPage">当前页面</param>
        /// <returns></returns>
        public CommonResult<List<VDeviceInfo>> GetVDeviceInfoPagedList(Tuple<string, List<object>> tFilter, int PageSize, int CurrPage)
        {
            var result = new CommonResult<List<VDeviceInfo>>();
            try
            {
                using (var dbSession = new DBService<Device>().DbSession)
                using (var dbSession1 = new DBService<DeviceClass>(dbSession.Context).DbSession)
                {
                    var query = dbSession.GetQueryable();
                    var queryClass = dbSession1.GetQueryable();

                    var query1 = (from d in query
                                  join c in queryClass on d.DevCCode equals c.DevCCode
                                  select new VDeviceInfo()
                                  {
                                      DevCode = d.DevCode,
                                      DevName = d.DevName,
                                      DevCCode = d.DevCCode,
                                      DevCName = c.DevCName,
                                      DevStd = d.DevStd,
                                      AdminPerson = d.AdminPerson,
                                      AdminPhone = d.AdminPhone,
                                      CreateDate = d.CreateDate,
                                      CreatePerson = d.CreatePerson,
                                      FactoryContacts = d.FactoryContacts,
                                      FactoryName = d.FactoryName,
                                      FContactsTel = d.FContactsTel,
                                      LastDate = d.LastDate,
                                      LastPerson = d.LastPerson,
                                      LocalAddress = d.LocalAddress,
                                      Origin = d.Origin,
                                      Remark = d.Remark,
                                      IPUrl = d.IPUrl,
                                      SerialPort = d.SerialPort,
                                      UseStatus = d.UseStatus

                                  });

                    if (tFilter != null && tFilter.Item2.Count() > 0)
                    {
                        Expression<Func<VDeviceInfo, bool>> eWhere = System.Linq.Dynamic.DynamicExpression.ParseLambda<VDeviceInfo, bool>(
                            tFilter.Item1, tFilter.Item2.ToArray());

                        query1 = query1.Where(eWhere);
                    }

                    result.TotalNum = query1.Count();
                    result.Data = query1.ToList().Take(PageSize * CurrPage).Skip(PageSize * (CurrPage - 1)).ToList();
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
        /// pjh 20161102 获取设备档案分页列表
        /// </summary>
        /// <param name="tWhere">过滤条件对象</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="CurrPage">页码</param>
        /// <returns>返回对象</returns>
        public CommonResult<List<Device>> GetDevicePagedList(Tuple<string, List<object>> tWhere, int PageSize, int CurrPage)
        {
            var result = new CommonResult<List<Device>>();
            try
            {
                var dbSession = new DBService<Device>().DbSession;

                var query = dbSession.GetQueryable();

                if (tWhere != null && tWhere.Item2.Count() > 0)
                {
                    Expression<Func<Device, bool>> eWhere = System.Linq.Dynamic.DynamicExpression.ParseLambda<Device, bool>(
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
        /// 删除单个设备档案
        /// </summary>
        /// <param name="strCode">设备编码</param>
        /// <returns>返回处理结果</returns>
        public CommonResult<bool> DelDeviceByCode(string strCode)
        {
            var result = new CommonResult<bool>();
            try
            {
                var dbSession = new DBService<Device>().DbSession;
                var dbSession1 = new DBService<DeviceWorkingCondition>(dbSession.Context).DbSession;
                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {
                    var model = dbSession.GetQueryable(t => t.DevCode == strCode).FirstOrDefault();
                    if (model == null)
                    {
                        result.Message = "该设备信息已经不存在";
                    }

                    if (result.IsSuccess)
                    {
                        dbSession.Delete(model);
                        var dwcModel = dbSession1.GetQueryable(t => t.DevCode == model.DevCode).FirstOrDefault();
                        if (dwcModel != null)
                        {
                            dbSession1.Delete(dwcModel);
                        }
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
        private void CheckDevice(Device model, CommonResult<Device> result)
        {
            if (model == null)
            {
                result.IsSuccess = false;
                result.Message = "设备对象不能为空";
            }
            else if (string.IsNullOrEmpty(model.DevCode))
            {
                result.IsSuccess = false;
                result.Message = "设备编码不能为空！";
            }
            else if (string.IsNullOrEmpty(model.DevName))
            {
                result.IsSuccess = false;
                result.Message = "设备名称不能为空!";
            }
            else if (string.IsNullOrEmpty(model.DevCCode))
            {
                result.IsSuccess = false;
                result.Message = "设备分类编码不能为空!";
            }
        }
        #endregion

        #region 设备参数

        /// <summary>
        /// 删除设备参数数据
        /// </summary>
        /// <param name="strCode"></param>
        /// <returns></returns>
        public CommonResult<bool> DelDevParameterByCode(string strCode)
        {
            var result = new CommonResult<bool>();
            try
            {
                var dbSession = new DBService<DeviceParameter>().DbSession;

                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {
                    var model = dbSession.GetQueryable(t => t.DevpCode == strCode).FirstOrDefault();

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
        /// 设备参数采集修改功能
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public CommonResult<DeviceParameter> UpdatDevParameter(DeviceParameter model)
        {
            var result = new CommonResult<DeviceParameter>();
            try
            {
                //    CheckDeviceClass(model, result);
                if (result.IsSuccess)
                {
                    var dbSession = new DBService<DeviceParameter>().DbSession;
                    if (dbSession.GetQueryable(t => t.DevpCode == model.DevpCode).FirstOrDefault() == null)
                    {
                        result.IsSuccess = false;
                        result.Message = "不存在该设备参数";
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
        /// 测试设备参数获取当前设备编号列表数据
        /// </summary>
        /// <param name="strCode"></param>
        /// <returns></returns>

        public CommonResult<List<DeviceParameter>> GetDevParameterByCode(string strCode)
        {
            var result = new CommonResult<List<DeviceParameter>>();
            try
            {
                var dbSession = new DBService<DeviceParameter>().DbSession;
                //   result.Data = dbSession.GetQueryable(t => t.DevCode == strCode).FirstOrDefault();
                result.Data = dbSession.GetQueryable(t => t.DevCode == strCode).ToList();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 根据设备编号显示参数列表数据，并根据传入参数进行分页
        /// </summary>
        /// <param name="strCode"></param>
        /// <param name="PageSize">每页大小</param>
        /// <param name="CurrPage">当前页面</param>
        /// <param name="TotalNum">总条数</param>
        /// <param name="strDevCCode">分类编码</param>
        /// <param name="strDevCode">设备编码</param>
        /// <param name="strDevName">设备名称</param>
        /// <returns></returns>
        public CommonResult<List<DeviceParameter>> GetDevParByCodePaging(int PageSize, int CurrPage, ref int TotalNum, string strCode)
        {
            var result = new CommonResult<List<DeviceParameter>>();
            try
            {

                var dbSession = new DBService<DeviceParameter>().DbSession;

                var query = dbSession.GetQueryable();

                query = query.Where(t => t.DevCode == strCode);

                var lst = query.ToList();

                TotalNum = lst.Count();

                result.Data = lst.Take(PageSize * CurrPage).Skip(PageSize * (CurrPage - 1)).ToList();


            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// xxp 20161102 获取设备参数分页列表
        /// </summary>
        /// <param name="tWhere">过滤条件对象</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="CurrPage">页码</param>
        /// <returns>返回对象</returns>
        public CommonResult<List<DeviceParameter>> GetDevParameterPagedList(Tuple<string, List<object>> tWhere, int PageSize, int CurrPage)
        {
            var result = new CommonResult<List<DeviceParameter>>();
            try
            {

                var dbSession = new DBService<DeviceParameter>().DbSession;

                var query = dbSession.GetQueryable();

                if (tWhere != null && tWhere.Item2.Count() > 0)
                {
                    Expression<Func<DeviceParameter, bool>> eWhere = System.Linq.Dynamic.DynamicExpression.ParseLambda<DeviceParameter, bool>(
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
        /// 测试设备参数增加功能
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CommonResult<DeviceParameter> AddDevParameter(DeviceParameter model)
        {
            var result = new CommonResult<DeviceParameter>();
            try
            {
                var dbSession = new DBService<DeviceParameter>().DbSession;
                result.Data = dbSession.Insert(model);
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
            return result;
        }
        #endregion

    }
}
