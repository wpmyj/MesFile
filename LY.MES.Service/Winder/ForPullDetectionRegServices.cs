using LY.MES.Model;
using Server.Utility;
using Server.Utility.UserAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LY.MES.Service.Winder
{

    /// <summary>
    /// Author:xxp
    /// Remark:QC_拉力检测登记服务
    /// CreateTime:20161107
    /// </summary>
    public class ForPullDetectionRegServices
    {
        protected UserSession currUserSession;

        public static ForPullDetectionRegServices GetInstance(string sessionId)
        {
            return new ForPullDetectionRegServices(sessionId);
        }

        private ForPullDetectionRegServices() { }

        protected ForPullDetectionRegServices(string sessionId)
        {
            currUserSession = SvrUserSession.GetCurrSession(sessionId);
        }

        #region 拉力检测登记表

        /// <summary>
        /// 新增拉力检测登记表
        /// </summary>
        /// <param name="model">实体Model</param>
        /// <returns></returns>
        public CommonResult<QC_PullDetectionReg> AddPullDetectionReg(QC_PullDetectionReg model)
        {
            var result = new CommonResult<QC_PullDetectionReg>();

            if (model == null)
            {
                result.IsSuccess = false;
                result.Message = "拉力检测登记不能为空！";
            }
            else
            {
                var dbSession = new DBService<QC_PullDetectionReg>().DbSession;

                model.CreateDate = DateTime.Now;

             

                result.Data = dbSession.Insert(model);
            }
            return result;
        }

        /// <summary>
        /// 修改拉力检测登记表
        /// </summary>
        /// <param name="model">实体Model</param>
        /// <returns></returns>
        public CommonResult<QC_PullDetectionReg> UpdatePullDetectionReg(QC_PullDetectionReg model)
        {
            var result = new CommonResult<QC_PullDetectionReg>();

            if (model == null)
            {
                result.IsSuccess = false;
                result.Message = "拉力检测登记对象不能为空！";
            }
            else
            {
                var dbSession = new DBService<QC_PullDetectionReg>().DbSession;
                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {


                    if (dbSession.GetQueryable(t => t.AutoID == model.AutoID).FirstOrDefault() == null)
                    {
                        result.IsSuccess = false;
                        result.Message = "修改数据已经不存在！";
                    }
                    else
                    {
                        result.Data = dbSession.Update(model);
                    }
                    ts.Complete();
                }
            }
            return result;
        }

        /// <summary>
        /// 删除拉力检测登记表
        /// </summary>
        /// <param name="AutoId">登记编号</param>
        /// <returns></returns>
        public CommonResult<bool> DelPullDetectionReg(int AutoId)
        {
            var result = new CommonResult<bool>();

            var dbSession = new DBService<QC_PullDetectionReg>().DbSession;
            using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
            {
                var model = dbSession.GetQueryable(t => t.AutoID == AutoId).FirstOrDefault();
                if (model == null)
                {
                    result.IsSuccess = false;
                    result.Message = "修改数据已经不存在！";
                }
                else
                {
                    dbSession.Delete(model);
                    ts.Complete();
                    result.Data = true;
                }
            }
            return result;
        }

        /// <summary>
        /// 拉力检测登记表单个查询
        /// </summary>
        /// <param name="AutoId">登记编号</param>
        /// <returns></returns>
        public CommonResult<QC_PullDetectionReg> GetPullDetectionRegAutoID(int AutoId)
        {
            var result = new CommonResult<QC_PullDetectionReg>();
            var dbSession = new DBService<QC_PullDetectionReg>().DbSession;
            result.Data = dbSession.GetQueryable(t => t.AutoID == AutoId).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// 拉力检测登记表分页查询
        /// </summary>
        /// <param name="TWhere">过滤条件</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="CurrPage">当前页码</param>
        /// <returns>返回数据集合</returns>
        public CommonResult<List<QC_PullDetectionReg>> GetPullDetectionRegPagedList(Tuple<string, object[]> TWhere, int PageSize, int CurrPage)
        {
            var result = new CommonResult<List<QC_PullDetectionReg>>();
            var dbSession = new DBService<QC_PullDetectionReg>().DbSession;
            var query = dbSession.GetQueryable();

            if (TWhere != null && TWhere.Item2.Count() > 0)
            {
                Expression<Func<QC_PullDetectionReg, bool>> eWhere = System.Linq.Dynamic.DynamicExpression.ParseLambda<QC_PullDetectionReg, bool>(
                    TWhere.Item1, TWhere.Item2);

                query = query.Where(eWhere);
            }
            result.TotalNum = query.Count();
            result.Data = query.ToList().Take(PageSize * CurrPage).Skip(PageSize * (CurrPage - 1)).ToList();

            return result;
        } 
        #endregion

    }
}
