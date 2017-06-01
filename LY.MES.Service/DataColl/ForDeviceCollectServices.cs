using LY.MES.Model;
using LY.MES.Model.VModel;
using Server.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Server.Utility.Logging;
using Server.Utility.UserAuth;
using Server.Utility.Caching;


namespace LY.MES.Service.DataColl
{

    /// <summary>
    /// Author:Cyb
    /// Remark:设备采集服务类
    /// CreateDate:20161108
    /// </summary>
    public class ForDeviceCollectServices
    {
        protected UserSession iUserSession;

        public static ForDeviceCollectServices GetInstance(string sessionId)
        {
            return new ForDeviceCollectServices(sessionId);
        }

        private ForDeviceCollectServices(){}
        protected ForDeviceCollectServices(string sessionId)
        {
            iUserSession = SvrUserSession.GetCurrSession(sessionId);
        }


        public CommonResult<CollectDataInfo> AddZGParameter(CollectDataInfo model)
        {
            var result = new CommonResult<CollectDataInfo>();
            try
            {
                var dbsession = new DBService<CollectDataInfo>().DbSession;
                result.Data = dbsession.Insert(model);
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
            return result;
        }

        #region 数据分页
        /// <summary>
        /// 数据采集分页
        /// </summary>
        /// <param name="tFilter">过滤条件对象</param>
        /// <param name="PageSize">每页大小</param>
        /// <param name="CurrPage">当前页</param>
        /// <returns></returns>
        public CommonResult<List<VCollectDataInfo>> GetCollectDataPagedList(Tuple<string, List<object>> tFilter, int PageSize, int CurrPage)
        {
            var result = new CommonResult<List<VCollectDataInfo>>();
            try
            {
                var colldbsession = new DBService<CollectDataInfo>().DbSession;
                var execQuery = new DBService<DeviceExecute>(colldbsession.Context).DbSession.GetQueryable();
                var paraQuery = new DBService<DeviceParameter>(colldbsession.Context).DbSession.GetQueryable();
                var interfaceQuery = new DBService<DeviceInterface>(colldbsession.Context).DbSession.GetQueryable();
                var devQuery = new DBService<Device>(colldbsession.Context).DbSession.GetQueryable();
                var query = colldbsession.GetQueryable();
                var lst = (
                   from coll in query
                   join exec in execQuery on coll.DeveCode equals exec.DeveCode
                   join ifq in interfaceQuery on exec.DeviCode equals ifq.DeviCode
                   join para in paraQuery on ifq.DevpCode equals para.DevpCode
                   join dev in devQuery on para.DevCode equals dev.DevCode
                   join dev1 in devQuery on ifq.DevCode equals dev1.DevCode
                   select new VCollectDataInfo()
                   {
                       AutoId = coll.AutoId,
                       DeveCode = coll.DeveCode,
                       CollValue = coll.CollValue,
                       OriginalValue = coll.OriginalValue,
                       CreateDate = coll.CreateDate,
                       DevpCode = para.DevpCode,
                       DeviCode = ifq.DeviCode,
                       DeviName = ifq.DeviName,
                       DevpName = para.DevpName,
                       IFDevCode = dev1.DevCode,
                       IFDevName = dev1.DevName,
                       PDevCode = dev.DevCode,
                       PDevName = dev.DevName
                   });
                if(tFilter !=null && tFilter.Item2.Count()>0)
                {
                    Expression<Func<VCollectDataInfo, bool>> ewhere = System.Linq.Dynamic.DynamicExpression.ParseLambda<VCollectDataInfo, bool>(
                        tFilter.Item1, tFilter.Item2.ToArray());
                    lst = lst.Where(ewhere);
                }
                result.TotalNum = lst.Count();
                result.Data = lst.OrderByDescending(t=>t.CreateDate).Take(PageSize * CurrPage).Skip(PageSize * (CurrPage - 1)).ToList();
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

    #endregion 