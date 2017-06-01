using LY.MES.Model;
using LY.MES.Model.VModel;
using Server.Utility;
using Server.Utility.UserAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Server.Utility.Logging;
using LY.MES.Service.Drums;

namespace LY.MES.Service.FindLeak
{
    public class ForQCDrumsSetServices
    {
        protected UserSession currUserSession;

        // #region 设备执行表增
        public static ForQCDrumsSetServices GetInstance(string sessionId)
        {
            return new ForQCDrumsSetServices(sessionId);
        }

        private ForQCDrumsSetServices() { }

        public ForQCDrumsSetServices(string sessionId)
        {
            currUserSession = SvrUserSession.GetCurrSession(sessionId);
        }
        ///// <summary>
        ///// 增加
        ///// 
        ///// </summary>
        ///// <param name="model">设备接口对象</param>
        ///// <returns>返回处理结果</returns>
        //public CommonResult<QC_FindLeakDrumsSet> AddQCDrumsSet(QC_FindLeakDrumsSet model)
        //{
        //    var result = new CommonResult<QC_FindLeakDrumsSet>();
        //    try
        //    {
        //        //   CheckDeviceExecute(model, result);
        //        var dbSession = new DBService<QC_FindLeakDrumsSet>().DbSession;

        //        if (dbSession.GetQueryable(t => t.AutoId == model.AutoId).FirstOrDefault() != null)
        //        {
        //            result.IsSuccess = false;
        //            result.Message = "漏检单号不能重复！";
        //        }
        //        else
        //        {
        //            result.Data = dbSession.Insert(model);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result.IsSuccess = false;
        //        result.Message = ex.Message;
        //        result.StackTrace = ex.StackTrace;
        //    }
        //    return result;
        //}


        /// <summary>
        /// 
        /// 设定转漏转鼓保存
        /// </summary>
        /// <param name="model">设备接口对象</param>
        /// <returns>返回处理结果</returns>
        public CommonResult<bool> AddQCDrumsSet(QC_FindLeakDrumsSet model, List<QC_FindLeakDrumsSetDetail> detailList)
        {
            var result = new CommonResult<bool>();
            try
            {
                //   CheckDeviceExecute(model, result);
                var dbSession = new DBService<QC_FindLeakDrumsSet>().DbSession;
                var dbSession1 = new DBService<QC_FindLeakDrumsSetDetail>().DbSession;
                //start 不为空判断

                //end 

                if (result.IsSuccess)
                {
                    using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                    {
                        var currModel = dbSession.Insert(model);
                        detailList.ForEach(item =>
                        {
                            item.ID = currModel.ID;
                        });
                        dbSession1.Insert(detailList);

                        //更新工艺执行表进入检漏状态,开启检漏工艺
                        foreach (var item in detailList)
                        {
                            item.AutoID = currModel.ID;
                            //排配单操作日志
                            ForCfPExecuteServices.GetInstance(currUserSession.SessionId).InsertArrangedVouchLog(new ArrangedVouchLog()
                            {
                                ArrangedVouchCode = item.ArrangedVouchCode,
                                CraftsName = "检漏",
                                OperatDesc = "检漏开始",
                                Operator = currUserSession.UserName,
                                OperatingTime = DateTime.Now,
                                Frequency = model.Frequency
                            });
                        }
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
        /// 查询检漏设定
        /// </summary>
        /// <param name="AutoId"></param>
        /// <returns></returns>
        public CommonResult<QC_FindLeakDrumsSet, QC_FindLeakDrumsSetDetail> GetQCDrumsSet(int AutoId)
        {
            var result = new CommonResult<QC_FindLeakDrumsSet, QC_FindLeakDrumsSetDetail>();

            try
            {
                var dbSession = new DBService<QC_FindLeakDrumsSet>().DbSession;
                var dbSession1 = new DBService<QC_FindLeakDrumsSetDetail>().DbSession;
                result.HeadData = dbSession.GetQueryable(t => t.ID == AutoId).FirstOrDefault();
                result.BodyData = dbSession1.GetQueryable(t => t.ID == AutoId).ToList();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 更新转鼓检漏状态为已检
        /// </summary>
        /// <param name="AutoId"></param>
        /// <returns></returns>
        public CommonResult<bool> UpdateQCDrumsSetIsLeak(int AutoId)
        {
            var result = new CommonResult<bool>();
            try
            {
                var dbSession = new DBService<QC_FindLeakDrumsSetDetail>().DbSession;
                var model = dbSession.GetQueryable(t => t.ID == AutoId).FirstOrDefault();
                if (model != null)
                {
                    model.IsLeak = 1;
                    dbSession.Update(model);
                    result.Data = true;
                }
                else
                    result.Data = false;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                result.StackTrace = ex.StackTrace;
            }
            return result;

        }

        //二维码查询检漏鼓号
        public CommonResult<QC_FindLeakDrumsSet> GetQCDrumsSetQRCode(string LeakDrums)
        {
            var result = new CommonResult<QC_FindLeakDrumsSet>();
            // string strLeakDrums = null;
            try
            {
                var dbSession = new DBService<QC_FindLeakDrumsSet>().DbSession;
                //result.Data = dbSession.GetQueryable(t => t.LeakDrums == LeakDrums).FirstOrDefault();
                //result.Data = dbSession.GetQueryable(t => t.CreateDateTime.Year == DateTime.Now.Year && t.CreateDateTime.Month == DateTime.Now.Month && t.CreateDateTime.Day == DateTime.Now.Day).OrderByDescending(t => t.LeakDrums).FirstOrDefault();


            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                result.StackTrace = ex.StackTrace;
            }
            return result;
        }

        //查询全部数据
        public CommonResult<List<QC_FindLeakDrumsSet>> GetQCDrumsSetQRCodes()
        {
            var result = new CommonResult<List<QC_FindLeakDrumsSet>>();
            // string strLeakDrums = null;
            try
            {
                var dbSession = new DBService<QC_FindLeakDrumsSet>().DbSession;
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

        /// <summary>
        /// 转鼓当天待检漏信息
        /// </summary>
        /// <param name="dCurrDate"></param>
        /// <returns></returns>
        public CommonResult<List<vw_QC_FindLeakDrumsSet>> Getvw_QC_FindLeakDrumsSetList(DateTime dCurrDate)
        {
            var result = new CommonResult<List<vw_QC_FindLeakDrumsSet>>();
            // string strLeakDrums = null;
            try
            {
                var dbSession = new DBService<vw_QC_FindLeakDrumsSet>().DbSession;
                //查询当天未检漏的 或上一天未检漏的
                DateTime dUpDate = dCurrDate.AddDays(-1).Date;
                result.Data = dbSession.GetQueryable(t => (t.CreateDate.CompareTo(dCurrDate.Date) == 0 || t.CreateDate.CompareTo(dUpDate) == 0) && t.IsLeak == 0).ToList();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 选择转鼓为上料阶段的待设定列表
        /// 弹窗显示列表
        /// </summary>
        /// <param name="iYear"></param>
        /// <param name="iMonth"></param>
        /// <param name="strWeek"></param>
        /// <returns></returns>
        public CommonResult<List<vw_DurmsUpFeeding>> GetQCDrumsList(int iYear, int iMonth, int strWeek)
        {
            var result = new CommonResult<List<vw_DurmsUpFeeding>>();
            // string strLeakDrums = null;
            try
            {
                var dbSession = new DBService<vw_DurmsUpFeeding>().DbSession;
                var dbSession1 = new DBService<vw_QC_FindLeakDrumsSet>().DbSession;
                var CurrWeekQCDrums = dbSession1.GetQueryable(t => t.Year == iYear && t.Month == iMonth && t.Week == strWeek).ToList();
                List<string> lstDrums = new List<string>();
                if (CurrWeekQCDrums.Count > 0)
                {
                    lstDrums = CurrWeekQCDrums.ConvertAll(t => t.DevCode);
                }

                string strSql = "SELECT * FROM dbo.vw_DurmsUpFeeding duf WHERE duf.ArrangedVouchCode IS NOT NULL AND duf.UserStatus=1 AND duf.ExecuteOrder=1 AND duf.ExecuteStatus=2 AND 0 IN (SELECT duf1.ExecuteStatus FROM vw_DurmsUpFeeding duf1 WHERE duf1.ArrangedVouchCode IS NOT NULL AND duf1.ArrangedVouchCode=duf.ArrangedVouchCode AND duf1.ExecuteOrder=1+2)";
                var query = dbSession.SqlQuery<vw_DurmsUpFeeding>(strSql).Where(t => (lstDrums.Count == 0 || lstDrums.Contains(t.WorkbrachCode) == false));
                result.Data = query.ToList();

                //result.Data = dbSession.GetQueryable(t => t.ExecuteOrder.Value == 1 && (t.ExecuteStatus.Value == 1 || t.ExecuteStatus.Value == 2) && (lstDrums.Count == 0 || lstDrums.Contains(t.WorkbrachCode) == false)).ToList();

            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
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
        public CommonResult<List<QC_FindLeakDrumsSet>> GetQueryDrumsSetLeak()//int PageSize, int CurrPage, ref int TotalNum,string DevpCodet => t.DevpCode == DevpCode
        {
            var result = new CommonResult<List<QC_FindLeakDrumsSet>>();
            try
            {
                var dbSession = new DBService<QC_FindLeakDrumsSet>().DbSession;
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



        ////根据设备三个参数进行搜索
        /////chenweihua 20161202 获取设备参数分页列表
        ///// </summary>
        ///// <param name="tWhere">过滤条件对象</param>
        ///// <param name="PageSize">每页条数</param>
        ///// <param name="CurrPage">页码</param>
        ///// <returns>返回对象</returns>
        public CommonResult<List<QC_FindLeakDrumsSet>> GetQCDrumsFindLeakList(Tuple<string, List<object>> tWhere, int PageSize, int CurrPage)
        {
            var result = new CommonResult<List<QC_FindLeakDrumsSet>>();
            try
            {

                var dbSession = new DBService<QC_FindLeakDrumsSet>().DbSession;

                var query = dbSession.GetQueryable();



                if (tWhere != null && tWhere.Item2.Count() > 0)
                {
                    Expression<Func<QC_FindLeakDrumsSet, bool>> eWhere = System.Linq.Dynamic.DynamicExpression.ParseLambda<QC_FindLeakDrumsSet, bool>(
                        tWhere.Item1, tWhere.Item2.ToArray());

                    query = query.Where(eWhere);
                }
                result.TotalNum = query.Count();

                result.Data = query.ToList().Take(PageSize * CurrPage).Skip(PageSize * (CurrPage - 1)).ToList();
            }
            catch (Exception ex)
            {
                Utils.Logger.Equals(ex.Message);

                throw ex;
            }
            return result;
        }


    }

}

