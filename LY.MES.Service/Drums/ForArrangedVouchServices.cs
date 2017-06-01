using LY.MES.Model;
using Server.Utility;
using Server.Utility.UserAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Server.Utility.Logging;

namespace LY.MES.Service.Drums
{
    /// <summary>
    /// Author:cwh
    /// Remark:排配单
    /// CreateDate:2016/12/19
    /// </summary>
    public class ForArrangedVouchServices
    {
        protected UserSession iUserSession;

        public static ForArrangedVouchServices GetInstance(string sessionId)
        {
            return new ForArrangedVouchServices(sessionId);
        }

        private ForArrangedVouchServices() { }
        protected ForArrangedVouchServices(string sessionId)
        {
            iUserSession = SvrUserSession.GetCurrSession(sessionId);
        }


        //查询
        public CommonResult<ArrangedVouch> GetArrangedVouchByCode(string ArrangedVouchCode)
        {
            var result = new CommonResult<ArrangedVouch>();

            try
            {
                var dbSession = new DBService<ArrangedVouch>().DbSession;
                result.Data = dbSession.GetQueryable(t => t.ArrangedVouchCode == ArrangedVouchCode).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;
        }

        ////根据设备三个参数进行搜索
        /////chenweihua 20161219 获取设备参数分页列表
        ///// </summary>
        ///// <param name="tWhere">过滤条件对象</param>
        ///// <param name="PageSize">每页条数</param>
        ///// <param name="CurrPage">页码</param>
        ///// <returns>返回对象</returns>
        public CommonResult<List<ArrangedVouch>> GetArrangedVouchList(Tuple<string, List<object>> tWhere, int PageSize, int CurrPage)
        {
            var result = new CommonResult<List<ArrangedVouch>>();
            try
            {

                var dbSession = new DBService<ArrangedVouch>().DbSession;

                var query = dbSession.GetQueryable();

                if (tWhere != null && tWhere.Item2.Count() > 0)
                {
                    Expression<Func<ArrangedVouch, bool>> eWhere = System.Linq.Dynamic.DynamicExpression.ParseLambda<ArrangedVouch, bool>(
                        tWhere.Item1, tWhere.Item2.ToArray());

                    query = query.Where(eWhere);
                }
                result.TotalNum = query.Count();

                result.Data = query.ToList().Take(PageSize * CurrPage).Skip(PageSize * (CurrPage - 1)).ToList();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// xxp 获取当前工作的排配单集合
        /// </summary>
        /// <param name="ArrangedVouchCode">排配单号</param>
        /// <returns>排配单</returns>
        public CommonResult<List<vw_ArrangedCraftsProcessExecute>> GetArrangedCraftsProcessExecuteList(string ArrangedVouchCode = null)
        {
            var result = new CommonResult<List<vw_ArrangedCraftsProcessExecute>>();
            try
            {
                var dbSession = new DBService<vw_ArrangedCraftsProcessExecute>().DbSession;
                result.Data = dbSession.GetQueryable(t => t.UserStatus == 1 && (string.IsNullOrEmpty(ArrangedVouchCode) || t.ArrangedVouchCode == ArrangedVouchCode) && string.IsNullOrEmpty(t.FormulaCode) == false).ToList();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// 用于修改排配单执行状态，传入值为排配单号以及要修改成的执行状态UserStatus，暂定用于转鼓工艺流转，因为转鼓空鼓上料默认上料之后执行状态为1
        /// </summary>20170111XCQ
        /// <param name="ArrangedVouchCode"></param>
        /// <param name="UserStatus"></param>
        /// <returns></returns>
        public CommonResult<ArrangedVouch> UdateArrUserStatusByArrCode(string ArrangedVouchCode, int UserStatus)
        {
            var result = new CommonResult<ArrangedVouch>();
            try
            {
                var dbSession = new DBService<ArrangedVouch>().DbSession;
                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {
                    var model = dbSession.GetQueryable(t => t.ArrangedVouchCode == ArrangedVouchCode).FirstOrDefault();
                    if (model == null)
                    {
                        result.IsSuccess = false;
                        result.Message = "该设备信息已经不存在";
                    }
                    model.UserStatus = UserStatus;
                    result.Data = dbSession.Update(model);
                    ts.Complete();
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
        /// 用于原来备料看板，用于已完成烘料，烘料中两个进度条的数据提取，当UserStatus传入值为1的时候是烘料中的状态，2的时候则为已完成烘料的状态，取相同配方单号下的合计值
        /// </summary>
        /// <param name="ForMulaCode"></param>
        /// <param name="UserStatus"></param>
        /// <returns></returns>
        public CommonResult<List<ArrangedVouch>> GetArrangedVouchByMulaCode(string ForMulaCode, int UserStatus)
        {
            var result = new CommonResult<List<ArrangedVouch>>();
            try
            {
                var dbSession = new DBService<ArrangedVouch>().DbSession;

                result.Data = dbSession.GetQueryable(t => t.FormulaCode == ForMulaCode && t.UserStatus == UserStatus).ToList();


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

