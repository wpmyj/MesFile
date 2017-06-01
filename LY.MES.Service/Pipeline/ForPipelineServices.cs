using LY.MES.Model;
using Server.Utility;
using Server.Utility.UserAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Utility.Logging;
using System.Linq.Expressions;

namespace LY.MES.Service.Pipeline
{
    public class ForPipelineServices
    {
        protected UserSession currUserSession;
        public static ForPipelineServices GetInstance(string sessionId)
        {
            return new ForPipelineServices(sessionId);
        }
        private ForPipelineServices()
        { }

        protected ForPipelineServices(string sessionId)
        {
            currUserSession = SvrUserSession.GetCurrSession(sessionId);
        }

        /// <summary>
        /// 获取主管道操作记录
        /// </summary>
        /// <param name="tFilter">过滤条件</param>
        /// <param name="CurrPage">当前页码</param>
        /// <param name="PageSize">每页最大行数</param>
        /// <returns></returns>
        public CommonResult<List<MainPipelineInfo>> GetOperatingRecord(Tuple<string, List<object>> tFilter, int CurrPage, int PageSize)
        {
            var result = new CommonResult<List<MainPipelineInfo>>();
            try
            {
                var dbsession = new DBService<MainPipelineInfo>().DbSession;
                var query = dbsession.GetQueryable();
                if (tFilter != null && tFilter.Item2.Count() > 0)
                {
                    Expression<Func<MainPipelineInfo, bool>> ewhere = System.Linq.Dynamic.DynamicExpression.ParseLambda<MainPipelineInfo, bool>(tFilter.Item1, tFilter.Item2.ToArray());

                    query = query.Where(ewhere).OrderByDescending(t => t.OperatingTime);
                }

                result.TotalNum = query.Count();
                if (CurrPage != 0 && PageSize != 0)
                {
                    result.Data = query.OrderByDescending(t => t.OperatingTime).ToList().Take(CurrPage * PageSize).Skip((CurrPage - 1) * PageSize).ToList();
                }
                else if (CurrPage == 0 && PageSize == 0)
                {
                    result.Data = query.ToList();
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
        /// 保存主管道操作数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CommonResult<MainPipelineInfo> AddOperatingData(MainPipelineInfo model)
        {
            var result = new CommonResult<MainPipelineInfo>();
            try
            {
                var dbsession = new DBService<MainPipelineInfo>().DbSession;
                result.Data = dbsession.Insert(model);
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 获取设备信息
        /// </summary>
        /// <param name="DevCode">设备编号</param>
        /// <returns></returns>
        public CommonResult<Device> GetDaviceData(string DevCode)
        {
            var result = new CommonResult<Device>();
            try
            {
                var dbsession = new DBService<Device>().DbSession;
                var ret = dbsession.GetQueryable(t => t.DevCode == DevCode).FirstOrDefault();
                if (ret == null)
                {
                    result.IsSuccess = false;
                    result.Message = "该设备编号不存在！";
                }
                else if (ret.DevCCode != "04" && string.IsNullOrEmpty(ret.DevCCode) == false)
                {
                    result.IsSuccess = false;
                    result.Message = "该二维码为: " + ret.DevName + " ，不是“阀门设备”二维码！";
                }
                else if (ret.DevCCode == "04") //判断阀门转台是否为可用
                {
                    if (ret.UseStatus == 1)
                    {
                        result.IsSuccess = false;
                        result.Message = ret.DevName + " 处于维修状态,不可用！";
                    }
                    else if (ret.UseStatus == 2)
                    {
                        result.IsSuccess = false;
                        result.Message = ret.DevName + " 处于停用状态,不可用！";
                    }
                    else if (ret.UseStatus == 3)
                    {
                        result.IsSuccess = false;
                        result.Message = ret.DevName + " 处于报废状态,不可用！";
                    }
                    else
                    {
                        result.Data = ret;
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
        /// 获取设备信息
        /// </summary>
        /// <param name="DevCCode">设备分类编码</param>
        /// <param name="DevCode">设备编号</param>
        /// <returns></returns>
        public CommonResult<Device> GetDaviceInformation(string DevCCode, string DevCode)
        {
            var result = new CommonResult<Device>();
            try
            {
                var dbsession = new DBService<Device>().DbSession;
                var dbsession1 = new DBService<DeviceClass>().DbSession;

                var ret = dbsession.GetQueryable(t => t.DevCode == DevCode).FirstOrDefault();
                var ret1 = dbsession1.GetQueryable(t => t.DevCCode == DevCCode).FirstOrDefault();

                if (ret1 == null)
                {
                    result.IsSuccess = false;
                    result.Message = "该设备分类不存在！";
                }
                else if (ret == null)
                {
                    result.IsSuccess = false;
                    result.Message = "该设备编号不存在！";
                }
                else if (ret.DevCCode != DevCCode && string.IsNullOrEmpty(ret.DevCCode) == false)
                {
                    result.IsSuccess = false;
                    result.Message = "该二维码为: " + ret.DevName + " ，不是"+ ret1.DevCName+"二维码！";
                }
                else if (ret.DevCCode == DevCCode) //判断阀门状态是否为可用
                {
                    if (ret.UseStatus == 1)
                    {
                        result.IsSuccess = false;
                        result.Message = ret.DevName + " 处于维修状态,不可用！";
                    }
                    else if (ret.UseStatus == 2)
                    {
                        result.IsSuccess = false;
                        result.Message = ret.DevName + " 处于停用状态,不可用！";
                    }
                    else if (ret.UseStatus == 3)
                    {
                        result.IsSuccess = false;
                        result.Message = ret.DevName + " 处于报废状态,不可用！";
                    }
                    else
                    {
                        result.Data = ret;
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
    }
}
