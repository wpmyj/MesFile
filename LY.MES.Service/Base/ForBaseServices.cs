using Server.Utility;
using Server.Utility.UserAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LY.MES.Model;
using Server.Utility.Logging;

namespace LY.MES.Service.Base
{
    /// <summary>
    /// Author:xxp
    /// Remark：基础的服务类
    /// CreateTime:20161209
    /// </summary>
    public class ForBaseServices
    {
        private UserSession currUserSession;

        /// <summary>
        /// 基础的服务类
        /// </summary>
        /// <param name="sessionId">会话ID</param>
        /// <returns></returns>
        public static ForBaseServices GetInstance(string sessionId)
        {
            return new ForBaseServices(sessionId);
        }

        private ForBaseServices(string sessionId)
        {
            currUserSession = SvrUserSession.GetCurrSession(sessionId);
        }

        #region 参数对照表

        /// <summary>
        /// 增加参数对照表
        /// </summary>
        /// <param name="model">新增参数对照表</param>
        /// <returns>参数对照表</returns>
        public CommonResult<CraftsParameterContrast> AddCraftsParameterContrast(CraftsParameterContrast model)
        {
            var result = new CommonResult<CraftsParameterContrast>();

            try
            {
                SaveCheck(model, result);
                if (result.IsSuccess)
                {
                    var dbSession = new DBService<CraftsParameterContrast>().DbSession;
                    var Max = dbSession.GetMaxId("ParameterID");
                    model.ParameterID = Max.ParameterID + 1;
                    result.Data = dbSession.Insert(model);
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 增加参数对照表
        /// </summary>
        /// <param name="model">新增参数对照表</param>
        /// <returns>参数对照表</returns>
        public CommonResult<CraftsParameterContrast> UpdateCraftsParameterContrast(CraftsParameterContrast model)
        {
            var result = new CommonResult<CraftsParameterContrast>();

            try
            {
                SaveCheck(model, result);
                if (result.IsSuccess)
                {
                    var dbSession = new DBService<CraftsParameterContrast>().DbSession;
                    if (dbSession.GetQueryable(t => t.ParameterID == model.ParameterID).FirstOrDefault() == null)
                    {
                        result.IsSuccess = false;
                        result.Message = "该参数对照表的数据不存在";
                    }
                    else
                    {
                        result.Data = dbSession.Update(model);
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 保存判断
        /// </summary>
        /// <param name="model"></param>
        /// <param name="result"></param>
        private void SaveCheck(CraftsParameterContrast model, CommonResult<CraftsParameterContrast> result)
        {
            if (model == null)
            {
                result.IsSuccess = false;
                result.Message = "参数对照表不能为空";
            }
            else if (string.IsNullOrEmpty(model.ParamName))
            {
                result.IsSuccess = false;
                result.Message = "参数对照表的参数名称不能为空";
            }
            //else if (string.IsNullOrEmpty(model.DevepName))
            //{
            //    result.IsSuccess = false;
            //    result.Message = "参数对照表的设备参数名称不能为空";
            //}
        }

        /// <summary>
        /// 获取单个参数对照表
        /// </summary>
        /// <param name="ParameterID">编号</param>
        /// <returns></returns>
        public CommonResult<CraftsParameterContrast> GetCraftsParameterContrastListByID(int ParameterID)
        {
            var result = new CommonResult<CraftsParameterContrast>();

            try
            {
                var dbSession = new DBService<CraftsParameterContrast>().DbSession;
                result.Data = dbSession.GetQueryable(t => t.ParameterID == ParameterID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;

        }


        /// <summary>
        /// 删除单个参数对照表
        /// </summary>
        /// <param name="ID">编号</param>
        /// <returns></returns>
        public CommonResult<bool> DelCraftsParameterContrastListByID(int ParameterID)
        {
            var result = new CommonResult<bool>();

            try
            {
                var dbSession = new DBService<CraftsParameterContrast>().DbSession;
                var model = dbSession.GetQueryable(t => t.ParameterID == ParameterID).FirstOrDefault();
                if (model == null)
                {
                    result.IsSuccess = false;
                    result.Message = "该参数对照表的数据不存在";
                }
                else
                {
                    dbSession.Delete(model);
                    result.Data = true;
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;

        }

        /// <summary>
        /// 获取参数对照表集合
        /// </summary>
        /// <returns>参数对照表集合</returns>
        public CommonResult<List<CraftsParameterContrast>> GetCraftsParameterContrastList()
        {
            var result = new CommonResult<List<CraftsParameterContrast>>();

            try
            {
                var dbSession = new DBService<CraftsParameterContrast>().DbSession;
                result.Data = dbSession.GetQueryable().ToList();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;
        }
        #endregion
    }
}
