using LY.MES.Manage;
using LY.MES.Manage.Common;
using LY.MES.Model;
using LY.MES.Model.VModel;
using LY.MES.Service.Drums;
using LY.MES.Service.FindLeak;
using Server.Framework;
using Server.Utility;
using Server.Utility.Logging;
using Server.Utility.UserAuth;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LY.MES.Service.FindLeak
{
    /// <summary>
    ///  Author:xxp
    /// Remark:勤哲系统移动端UI类
    /// CreateTime:20161126
    /// name:cwh
    /// </summary>
    public class ForQCDFindLeakServices
    {


        protected UserSession currUserSession;

        // #region 设备执行表增，查
        public static ForQCDFindLeakServices GetInstance(string sessionId)
        {
            return new ForQCDFindLeakServices(sessionId);
        }

        private ForQCDFindLeakServices() { }

        public ForQCDFindLeakServices(string sessionId)
        {
            currUserSession = SvrUserSession.GetCurrSession(sessionId);
        }
        /// <summary>
        /// 增加
        /// 
        /// </summary>
        /// <param name="model">设备接口对象</param>
        /// <returns>返回处理结果</returns>
        public CommonResult<QC_DrumsFindLeakReport> AddQCDrumsFindLeakReport(QC_DrumsFindLeakReport model)
        {
            var result = new CommonResult<QC_DrumsFindLeakReport>();
            try
            {
                var dbSession = new DBService<QC_DrumsFindLeakReport>().DbSession;
                var dbSession1 = new DBService<QC_FindLeakDrumsSetDetail>(dbSession.Context).DbSession;

                string strConnn = dbSession.Context.Database.Connection.ConnectionString;

                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {
                    model.FLVCode = PubRepository.GetAutomaticNumber(strConnn, "QCDF", 5, "FLVCode", "QC_DrumsFindLeakReport", model.CreateDate);
                    var newModel = dbSession.Insert(model);
                    //更新已检状态
                    var CurrQCDetail = dbSession1.GetQueryable(t => t.ArrangedVouchCode == newModel.SourceCode).FirstOrDefault();
                    if (CurrQCDetail != null)
                    {
                        CurrQCDetail.IsLeak = 1;
                        dbSession1.Update(CurrQCDetail);
                    }
                    ForCfPExecuteServices.GetInstance(currUserSession.SessionId).InsertArrangedVouchLog(new ArrangedVouchLog()
                    {
                        ArrangedVouchCode = newModel.SourceCode,
                        CraftsName = "检漏",
                        OperatDesc = "检漏完成",
                        Operator = currUserSession.UserName,
                        OperatingTime = DateTime.Now,
                        Frequency = newModel.Frequency
                    });
                    ts.Complete();
                    result.Data = newModel;
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;
        }


        //查询
        public CommonResult<QC_DrumsFindLeakReport> GetQCDrumsFindLeak(string FLVCode)
        {
            var result = new CommonResult<QC_DrumsFindLeakReport>();
            string strFLVCode = null;
            try
            {
                var dbSession = new DBService<QC_DrumsFindLeakReport>().DbSession;
                result.Data = dbSession.GetQueryable(t => t.FLVCode == strFLVCode).FirstOrDefault();
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                result.StackTrace = ex.StackTrace;
            }
            return result;
        }





        ///2016/12/02
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
        public CommonResult<List<QC_DrumsFindLeakReport>> GetQCDrumsFindLeak()//int PageSize, int CurrPage, ref int TotalNum,string DevpCodet => t.DevpCode == DevpCode
        {
            var result = new CommonResult<List<QC_DrumsFindLeakReport>>();
            try
            {
                var dbSession = new DBService<QC_DrumsFindLeakReport>().DbSession;
                result.Data = dbSession.GetQueryable().ToList();


            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                result.StackTrace = ex.StackTrace;
            }
            return result;
        }



        //根据设备三个参数进行搜索
        ///chenweihua 20161202 获取设备参数分页列表
        /// </summary>
        /// <param name="tWhere">过滤条件对象</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="CurrPage">页码</param>
        /// <returns>返回对象</returns>
        public CommonResult<List<QC_DrumsFindLeakReport>> GetQCDrumsFindLeakList(Tuple<string, List<object>> tWhere, int PageSize, int CurrPage)
        {
            var result = new CommonResult<List<QC_DrumsFindLeakReport>>();
            try
            {

                var dbSession = new DBService<QC_DrumsFindLeakReport>().DbSession;

                var query = dbSession.GetQueryable();

                if (tWhere != null && tWhere.Item2.Count() > 0)
                {
                    Expression<Func<QC_DrumsFindLeakReport, bool>> eWhere = System.Linq.Dynamic.DynamicExpression.ParseLambda<QC_DrumsFindLeakReport, bool>(
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



    }
}


