
using LY.MES.Model;
using LY.MES.Model.VModel;
using Server.Utility;
using System;
using LY.MES.Manage;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LY.MES.Manage.Commonn;
using Server.Utility.Logging;
using System.Linq.Expressions;
using Server.Utility.UserAuth;
using System.Data;
using Server.Framework;
using LY.MES.Manage.Common;



namespace LY.MES.Service.DataColl
{
    /// <summary> 
    /// Author:xxp
    /// Remark:设备服务类
    /// CreateTime:20161013
    /// </summary>
    public class ForDevExecuteServices
    {

        protected UserSession currUserSession;

        #region 设备执行表增删改查

        /// <summary>
        /// 新增设备接口
        /// </summary>
        /// <param name="model">设备接口对象</param>
        /// <returns>返回处理结果</returns>
        public CommonResult<DeviceExecute> AddDeviceExecute(DeviceExecute model)
        {
            var result = new CommonResult<DeviceExecute>();
            try
            {
                //   CheckDeviceExecute(model, result);
                if (result.IsSuccess)
                {
                    var dbSession = new DBService<DeviceExecute>().DbSession;



                    if (dbSession.GetQueryable(t => t.DeviCode == model.DeviCode).FirstOrDefault() != null)
                    {
                        result.IsSuccess = false;
                        result.Message = "接口名称不能重复！";
                    }
                    //else if (dbSession.GetQueryable(t => t.DevCode == model.DevCode).FirstOrDefault() == null)
                    //{
                    //    result.IsSuccess = false;
                    //    result.Message = "设备编码不能重复！";
                    //}
                    else
                    {
                        result.Data = dbSession.Insert(model);
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
        /// 更新设备接口
        /// </summary>
        /// <param name="model">设备接口对象</param>
        /// <returns>返回处理结果</returns>
        public CommonResult<DeviceExecute> UpdateDeviceExecute(DeviceExecute model)
        {
            var result = new CommonResult<DeviceExecute>();

            try
            {
                var dbSession = new DBService<DeviceExecute>().DbSession;


                dbSession.GetQueryable(t => t.DeviCode == model.DeviCode).FirstOrDefault();


                result.Data = dbSession.Update(model);
            }
            /*
            CheckDeviceExecute(model, result);
            if (result.IsSuccess)
            {
                var dbSession = new DBService<DeviceExecute>().DbSession;
                //var dbSession1 = new DBService<DeviceInterface>().DbSession;
                if (dbSession.GetQueryable(t => t.DeviCode == model.DeviCode && t.DeviCode == model.DeviCode).FirstOrDefault() == null)
                {
                    result.IsSuccess = false;
                    result.Message = "设备编码不存在！";
                }
                //else if (dbSession.GetQueryable(t => t.DeviName == model.DeviName && t.DevCode != model.DevCode).FirstOrDefault() != null)
                //{
                //    result.IsSuccess = false;
                //    result.Message = "接口名称不能重复！";
                //}
                //else if (dbSession.GetQueryable(t => t.DevCode == model.DevCode).FirstOrDefault() == null)
                //{
                //    result.IsSuccess = false;
                //    result.Message = "设备编码不能重复！";
                //
             *    * */

            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 获取单个设备接口
        /// </summary>
        /// <param name="strCode">设备接口编码</param>
        /// <returns>返回处理结果</returns>
        public CommonResult<DeviceExecute> GetDeviceExecute(string strDeviCode)
        {
            var result = new CommonResult<DeviceExecute>();
            try
            {
                var dbSession = new DBService<DeviceExecute>().DbSession;
                result.Data = dbSession.GetQueryable(t => t.DeviCode == strDeviCode).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
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
        public CommonResult<List<DeviceExecute>> GetDeviceExecuteList()//int PageSize, int CurrPage, ref int TotalNum,string DevpCodet => t.DevpCode == DevpCode
        {
            var result = new CommonResult<List<DeviceExecute>>();
            try
            {
                var dbSession = new DBService<DeviceExecute>().DbSession;
                result.Data = dbSession.GetQueryable().ToList();
                //using (var dbSession = new DBService<DeviceInterface>().DbSession)
                //using (var dbSession1 = new DBService<Device>(dbSession.Context).DbSession)
                //{
                //    var query = dbSession.GetQueryable();
                //    var queryClass = dbSession1.GetQueryable();
                //    var lst = (from d in query
                //               join c in queryClass on d.DevCode equals c.DevCode
                //               select new DeviceInterface()
                //               {
                //                   DevCode = d.DevCode,
                //                   DeviName = d.DeviName,
                //                   DeviCode = d.DeviCode, 
                //                   SendFormat=d.SendFormat,
                //                   Remark = d.Remark,                                      
                //                   UserStatus = d.UserStatus

                //               }).ToList();
                //    TotalNum = lst.Count();
                //    result.Data = lst.Take(PageSize * CurrPage).Skip(PageSize * (CurrPage - 1)).ToList();
                //}

            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;
        }


        public CommonResult<List<DeviceExecute>> GetAllExecute()
        {
            var result = new CommonResult<List<DeviceExecute>>();


            try
            {


                var dbSession = new DBService<DeviceExecute>().DbSession;
                result.Data = dbSession.GetQueryable().ToList();

            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;

        }

        /// <summary>
        /// 删除单个设备接口
        /// </summary>
        /// <param name="strCode">设备接口编码</param>
        /// <returns>返回处理结果</returns>
        public CommonResult<bool> DelDeviceExecute(int StrDeveCode)
        {
            var result = new CommonResult<bool>();
            try
            {
                var dbSession = new DBService<DeviceExecute>().DbSession;
                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {
                    var model = dbSession.GetQueryable(t => t.DeveCode == StrDeveCode).FirstOrDefault();
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
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 检查设备数据
        /// </summary>
        /// <param name="model">实体对象</param>
        /// <param name="result">返回值</param>
        private void CheckDeviceExecute(DeviceExecute model, CommonResult<DeviceExecute> result)
        {
            if (model == null)
            {
                result.IsSuccess = false;
                result.Message = "设备对象不能为空";
            }
            else if (string.IsNullOrEmpty(model.DeviCode))
            {
                result.IsSuccess = false;
                result.Message = "设备编码不能为空!";
            }
        }




        #endregion

        public static ForDevExecuteServices GetInstance(string sessionId)
        {
            return new ForDevExecuteServices(sessionId);
        }

        private ForDevExecuteServices() { }

        protected ForDevExecuteServices(string sessionId)
        {
            currUserSession = SvrUserSession.GetCurrSession(sessionId);
        }


        //根据设备三个参数进行搜索
        ///许长庆 20161102 获取设备参数分页列表
        /// </summary>
        /// <param name="tWhere">过滤条件对象</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="CurrPage">页码</param>
        /// <returns>返回对象</returns>
        public CommonResult<List<DeviceExecute>> GetDevExecutePagedList(Tuple<string, List<object>> tWhere, int PageSize, int CurrPage)
        {
            var result = new CommonResult<List<DeviceExecute>>();
            try
            {

                var dbSession = new DBService<DeviceExecute>().DbSession;

                var query = dbSession.GetQueryable();

                if (tWhere != null && tWhere.Item2.Count() > 0)
                {
                    Expression<Func<DeviceExecute, bool>> eWhere = System.Linq.Dynamic.DynamicExpression.ParseLambda<DeviceExecute, bool>(
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

        #region   视图查询测试XCQ   20161125增加传入存储位置查询数据 20161125下午更新存入执行ID查询数据
        //V_DV_DevExecute
        public CommonResult<List<V_DV_DevExecute>> GetDevViewList()
        {
            var result = new CommonResult<List<V_DV_DevExecute>>();
            try
            {
                var dbSession = new DBService<V_DV_DevExecute>().DbSession;
                result.Data = dbSession.GetQueryable().ToList();

            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;
        }

        //public DataTable GetPullCompute()
        //{
        //    string strSql = "select [优先级],[产品级别],[强度],[订单类型],[宽度],[厚度],[拉力上限],[拉力下限] from [产品拉力计算基础表_明细]";
        //    var dataset = SqlHelper.Query(DbProvider.QZ_DBConnect, strSql);
        //    return dataset.Tables[0];
        //}

        public CommonResult<List<V_DV_DevExecute>> GetDevViewListByAddress(string Address)
        {
            var result = new CommonResult<List<V_DV_DevExecute>>();
            try
            {
                var dbSession = new DBService<V_DV_DevExecute>().DbSession;
                result.Data = dbSession.GetQueryable(t => t.LocalAddress == Address && t.InterFaceStatus == 0 && t.WorkStatus == 0 && t.EquipStatus == 0 && t.CollFrequency != 0).ToList();
                //&& t.ZGCode == "ZG0102"
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// 根据转鼓名称获取数采仪数据20170414-BY XCQ
        /// </summary>
        /// <param name="Address"></param>
        /// <returns></returns>
        public CommonResult<List<V_DV_DevExecute>> GetDevViewListByZGName(string ZGName)
        {
            var result = new CommonResult<List<V_DV_DevExecute>>();
            try
            {
                var dbSession = new DBService<V_DV_DevExecute>().DbSession;
                result.Data = dbSession.GetQueryable(t => t.ZGName == ZGName && t.InterFaceStatus == 0 && t.WorkStatus == 0 && t.EquipStatus == 0).ToList();
                //&& t.ZGCode == "ZG0102"&& t.ZGCode == "ZG0102"
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;
        }



        /// <summary>
        /// 获取存放位置，只取唯一性存放数据
        /// </summary>
        /// <param name="strExctueID"></param>
        /// <returns></returns>
        /// 
        public List<string> GetDevViewListAllAddress()
        {
            var result = new CommonResult<List<V_DV_DevExecute>>();

            try
            {
                var dbSession = new DBService<V_DV_DevExecute>().DbSession;
                // var lst = dbSession.GetQueryable().GroupBy(t => t.存放位置).ToList().ConvertAll(t => t.Key).ToList();

                var lst = dbSession.GetQueryable(t => t.InterFaceStatus == 0 && t.EquipStatus == 0 && t.CollFrequency!=0).GroupBy(t => t.LocalAddress).ToList().ConvertAll(t => t.Key).ToList();
                return lst;

            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
                //return null
            }
        }


        /// <summary>
        /// 采集所有接口数据2017-04-14 BY XCQ
        /// </summary>
        /// <returns></returns>
        public List<string> GetDevViewListAllDevName()
        {
            var result = new CommonResult<List<V_DV_DevExecute>>();

            try
            {
                var dbSession = new DBService<V_DV_DevExecute>().DbSession;
                // var lst = dbSession.GetQueryable().GroupBy(t => t.存放位置).ToList().ConvertAll(t => t.Key).ToList();

                var lst = dbSession.GetQueryable(t => t.InterFaceStatus == 0 && t.EquipStatus == 0).GroupBy(t => t.ZGName).ToList().ConvertAll(t => t.Key).ToList();
                return lst;

            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
                //return null
            }
        }

        public CommonResult<List<V_DV_DevExecute>> GetViewExecIDByDeviName(string JiHao, string IrconTroughName, string Serial)
        {
            var result = new CommonResult<List<V_DV_DevExecute>>();
            try
            {
                var dbSession = new DBService<V_DV_DevExecute>().DbSession;
                result.Data = dbSession.GetQueryable(t => t.LocalAddress == JiHao && t.ZGName == IrconTroughName&&t.DeviName==Serial).Distinct().ToList();
                return result;
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
        }

        public CommonResult<List<V_DV_DevExecute>> GetViewExecIDByIrcon(string JiHao, string IrconTroughName)
        {
            var result = new CommonResult<List<V_DV_DevExecute>>();
            try
            {
                var dbSession = new DBService<V_DV_DevExecute>().DbSession;
                result.Data = dbSession.GetQueryable(t => t.LocalAddress == JiHao && t.ZGName == IrconTroughName).ToList();
                return result;

            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
        }



        public CommonResult<List<V_DV_DevExecute>> GetMyDecCodeData()
        {
            var result = new CommonResult<List<V_DV_DevExecute>>();
            try
            {
                var dbSession = new DBService<V_DV_DevExecute>().DbSession;
                // var lst = dbSession.GetQueryable().GroupBy(t => t.存放位置).ToList().ConvertAll(t => t.Key).ToList();
                result.Data = dbSession.GetQueryable(t => t.InterFaceStatus == 0 && t.EquipStatus == 0).Distinct().ToList();
                return result;
            }

            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;

            }
        }


        public List<System.Linq.IGrouping<string, V_DV_DevExecute>> GetDevViewListAllIP()
        {
            // var result = new CommonResult<List<V_DV_DevExecute>>();

            try
            {
                var dbSession = new DBService<V_DV_DevExecute>().DbSession;
                // var lst = dbSession.GetQueryable().GroupBy(t => t.存放位置).ToList().ConvertAll(t => t.Key).ToList();
                var lst = dbSession.GetQueryable(t => t.InterFaceStatus == 0 && t.EquipStatus == 0 && t.ZGCode == "ZG0102").GroupBy(t => t.LocalAddress).ToList();
                return lst;

            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
                //  return null;

            }


        }




        public CommonResult<V_DV_DevExecute> GetDeviceExecuteByID(int strExctueID)
        {
            var result = new CommonResult<V_DV_DevExecute>();
            try
            {
                var dbSession = new DBService<V_DV_DevExecute>().DbSession;
                result.Data = dbSession.GetQueryable(t => t.ExecuteID == strExctueID).FirstOrDefault();
                //   result.Data = dbSession.GetQueryable(t => t.== strExctueID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// xxp 获取设备的执行信息
        /// </summary>
        /// <param name="strDevCode">设备编码</param>
        /// <returns></returns>
        public CommonResult<List<V_DV_DevExecute>> GetDeviceExecuteByDevCode(string strDevCode)
        {
            var result = new CommonResult<List<V_DV_DevExecute>>();
            try
            {
                var dbSession = new DBService<V_DV_DevExecute>().DbSession;
                result.Data = dbSession.GetQueryable(t => t.ZGCode == strDevCode).ToList();
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

