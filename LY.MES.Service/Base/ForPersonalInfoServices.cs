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

namespace LY.MES.Service.Base
{
    public class ForPersonalInfoServices
    {
        protected UserSession currUserSession;

        public static ForPersonalInfoServices GetInstance(string sessionId)
        {
            return new ForPersonalInfoServices(sessionId);
        }
        private ForPersonalInfoServices()
        { }

        protected ForPersonalInfoServices(string sessionId)
        {
            currUserSession = SvrUserSession.GetCurrSession(sessionId);     
        }

        public CommonResult<Person> GetPersonByCode(string strCode)
        {
            var result = new CommonResult<Person>();
            try
            {
                var dbsession = new DBService<Person>().DbSession;
                result.Data = dbsession.GetQueryable().Where(t=>t.PersonCode == strCode).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;
        }

        public CommonResult<List<Person>> GetPersonList(Tuple<string,List<object>> tFilter,int PageSize ,int CurrPage)
        {
            var result = new CommonResult<List<Person>>();
            try
            {
                var dbsession = new DBService<Person>().DbSession;
                var query = dbsession.GetQueryable();
                if(tFilter != null && tFilter.Item2.Count()>0)
                {
                    Expression<Func<Person, bool>> eWhere = System.Linq.Dynamic.DynamicExpression.ParseLambda<Person, bool>(tFilter.Item1,tFilter.Item2.ToArray());
                    query = query.Where(eWhere);
                }
                result.TotalNum = query.Count();
                result.Data = query.OrderBy(t => t.DepCode).Take(PageSize * CurrPage).Skip(PageSize * (CurrPage - 1)).ToList();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;
        }

        public CommonResult<Person> AddPersonData(Person Model)
        {
            var result = new CommonResult<Person>();
            try
            {
                var dbsession = new DBService<Person>().DbSession;
                using(System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {
                    if (dbsession.GetQueryable().Where(t => t.PersonCode == Model.PersonCode).FirstOrDefault() != null)
                    {
                        result.IsSuccess = false;
                        result.Message = "该职员编号已存在！";
                    }
                    else if(result.IsSuccess)
                    {
                        result.Data = dbsession.Insert(Model);
                        ts.Complete();
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

        public CommonResult<Person> UpdataPersonData(Person Model)
        {
            var result = new CommonResult<Person>();
            try
            {
                var dbsession = new DBService<Person>().DbSession;
                using(System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {
                    if(dbsession.GetQueryable().Where(t=>t.PersonCode == Model.PersonCode).FirstOrDefault() == null)
                    {
                        result.IsSuccess = false;
                        result.Message = "找不到该职员数据！";
                    }
                    else if(result.IsSuccess)
                    {
                        result.Data = dbsession.Update(Model);
                        ts.Complete();
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

        public CommonResult<bool>DelPersonData(string strPersonCode)
        {
            var result = new CommonResult<bool>();
            try
            {
                var dbsession = new DBService<Person>().DbSession;
                using(System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {
                    var Model  = dbsession.GetQueryable().Where(t=>t.PersonCode == strPersonCode).FirstOrDefault();
                    if(Model == null)
                    {
                        result.IsSuccess = false;
                        result.Message = "该职员的信息数据已不存在！";
                    }
                    else if(result.IsSuccess)
                    {
                        dbsession.Delete(Model);
                        result.Data = true;
                        ts.Complete();
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
    }
}
