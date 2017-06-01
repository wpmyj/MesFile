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
    public class ForDepartmentServices
    {
        private UserSession currUserSession;
        private ForDepartmentServices() { }
        protected ForDepartmentServices(string sessionId)
        {
            currUserSession = SvrUserSession.GetCurrSession(sessionId);
        }
        
        public static ForDepartmentServices GetInstance(string sessionId)
        {
            return new ForDepartmentServices(sessionId);
        }

        public CommonResult<List<Department>>GetDepartmentList()
        {
            var result = new CommonResult<List<Department>>();
            try
            {
                var dbsession = new DBService<Department>().DbSession;
                result.Data = dbsession.GetQueryable().ToList();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;
        }

        public CommonResult<Department>AddDepartmentData(Department Model)
        {
            var result = new CommonResult<Department>();
            try
            {
                var dbsession = new DBService<Department>().DbSession;
                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {
                    if (dbsession.GetQueryable().Where(t => t.DepCode == Model.DepCode).FirstOrDefault() != null)
                    {
                        result.IsSuccess = false;
                        result.Message = "该部门编码已存在！";
                    }
                    else if (dbsession.GetQueryable().Where(t => t.DepName == Model.DepName).FirstOrDefault() != null)
                    {
                        result.IsSuccess = false;
                        result.Message = "该部门名称已存在！";
                    }
                    else
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

        public CommonResult<Department> UpdataDepartmentData(Department Model,string strDepartmentNameOriginal,string strDepartmentNameNow)
        {
            var result = new CommonResult<Department>();
            try
            {
                var dbsession = new DBService<Department>().DbSession;
                if (dbsession.GetQueryable().Where(t => t.DepCode == Model.DepCode).FirstOrDefault() == null)
                {
                    result.IsSuccess = false;
                    result.Message = "该部门数据不存在！";
                }
                else if (dbsession.GetQueryable().Where(t => t.DepName == Model.DepName).FirstOrDefault() != null && strDepartmentNameOriginal != strDepartmentNameNow)
                {
                    result.IsSuccess = false;
                    result.Message = "该部门名称已存在！";
                }
                else if (Model.SupDepCode != null && dbsession.GetQueryable().Where(t => t.DepCode == Model.SupDepCode).FirstOrDefault() == null)
                {
                    result.IsSuccess = false;
                    result.Message = "该部门上级不存在！";
                }
                else
                {
                    result.Data = dbsession.Update(Model);
                }

            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;
        }

        public CommonResult<bool> DelDepartmentData(string strDepCode)
        {
            var result = new CommonResult<bool>();
            try
            {
                var dbsession = new DBService<Department>().DbSession;
                using(System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {
                    var Model = dbsession.GetQueryable(t => t.DepCode == strDepCode).FirstOrDefault();
                    if (Model == null)
                    {
                        result.IsSuccess = false;
                        result.Message = "该部门数据已不存在！";
                    }
                    else if (dbsession.GetQueryable().Where(t => t.SupDepCode == strDepCode).Count() > 0)
                    {
                        result.IsSuccess = false;
                        result.Message = "不能直接删除上级分类！";
                    }
                    else if(result.IsSuccess)
                    {
                        dbsession.Delete(Model);
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

        public CommonResult<List<Person>> GetPersonList(Tuple<string, List<object>> tFilter, int PageSize, int CurrPage)
        {
            var result = new CommonResult<List<Person>>();
            try
            {
                var dbsession = new DBService<Person>().DbSession;
                var quary = dbsession.GetQueryable();
                if (tFilter != null && tFilter.Item2.Count()>0)
                {
                    Expression<Func<Person, bool>> ewhere = System.Linq.Dynamic.DynamicExpression.ParseLambda<Person, bool>(tFilter.Item1, tFilter.Item2.ToArray());
                    quary = quary.Where(ewhere);
                }
                result.TotalNum = quary.Count();
                result.Data = quary.OrderBy(t => t.PersonCode).Take(PageSize * CurrPage).Skip((CurrPage - 1) * PageSize).ToList();
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
                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {
                    if (dbsession.GetQueryable().Where(t => t.PersonCode == Model.PersonCode).FirstOrDefault() != null)
                    {
                        result.IsSuccess = false;
                        result.Message = "该人员编号已存在！";
                    }
                    else
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
                using(System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {
                    var dbsesion = new DBService<Person>().DbSession;
                    if (dbsesion.GetQueryable().Where(t => t.PersonCode == Model.PersonCode).FirstOrDefault() == null)
                    {
                        result.IsSuccess = false;
                        result.Message = "该学生数据已不存在！";
                    }
                    else
                    {
                        result.Data = dbsesion.Update(Model);
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

        public CommonResult<bool> DelPersonData(Person Model)
        {
            var result = new CommonResult<bool>();
            try
            {
               using(System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
               {
                   var dbsession = new DBService<Person>().DbSession;
                   if (dbsession.GetQueryable().Where(t => t.PersonCode == Model.PersonCode).FirstOrDefault() == null)
                   {
                       result.IsSuccess = false;
                       result.Message = "该学生数据不存在！";
                   }
                   else
                   {
                       dbsession.Delete(Model);
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
