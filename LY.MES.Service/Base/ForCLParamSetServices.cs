using LY.MES.Model;
using Server.Utility;
using Server.Utility.UserAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Utility.Logging;
using System.Data.Entity.Validation;
using LY.MES.Model.VModel;

namespace LY.MES.Service.Base
{
    /// <summary>
    ///  Author:xxp
    /// Remark:工艺流程基础参数设置服务
    /// CreateTime:20161205
    /// name:cwh
    /// </summary>
    public class ForCLParamSetServices
    {
        protected UserSession currUserSession;

        // #region 设备执行表增，查
        public static ForCLParamSetServices GetInstance(string sessionId)
        {
            return new ForCLParamSetServices(sessionId);
        }

        public ForCLParamSetServices(string sessionId)
        {
            currUserSession = SvrUserSession.GetCurrSession(sessionId);
        }

        /// <summary>
        /// 新增工艺参数设置数据
        /// </summary>
        /// <param name="model">主表数据</param>
        /// <param name="listModels">子表数据</param>
        /// <returns></returns>
        public CommonResult<CraftsLineParamSet, VCraftsLineParamSetDetail> AddCLParamSet(CraftsLineParamSet model, List<VCraftsLineParamSetDetail> listModels)
        {
            var result = new CommonResult<CraftsLineParamSet, VCraftsLineParamSetDetail>();
            try
            {
                var dbSession = new DBService<CraftsLineParamSet>().DbSession;
                var dbSession1 = new DBService<CraftsLineParamSetDetail>(dbSession.Context).DbSession;

                using (System.Transactions.TransactionScope tsc = new System.Transactions.TransactionScope())
                {
                    if (dbSession.GetQueryable(t => t.CraftsCode == model.CraftsCode).FirstOrDefault() != null)
                    {
                        result.Message = "工艺编码不能重复出现！";
                    }
                    else if (dbSession.GetQueryable(t => t.Order == model.Order).FirstOrDefault() != null)
                    {
                        result.Message = "执行顺序不能重复出现！";
                    }
                    else if (result.IsSuccess)
                    {
                        var newModel = dbSession.Insert(model);
                        listModels.ForEach(item => item.ID = newModel.ID);
                        var newListModel = dbSession1.Insert(Utils.ObjectMapper<CraftsLineParamSetDetail, VCraftsLineParamSetDetail>(listModels));
                        tsc.Complete();
                        result.HeadData = newModel;
                        var modellist = new List<VCraftsLineParamSetDetail>();
                        result.BodyData = Utils.ObjectMapper<VCraftsLineParamSetDetail, CraftsLineParamSetDetail>(newListModel.ToList());
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
        /// 更新工艺参数设置
        /// </summary>
        /// <param name="model">主表数据</param>
        /// <param name="listModels">子表数据</param>
        /// <returns>更新是否成功</returns>
        public CommonResult<CraftsLineParamSet, VCraftsLineParamSetDetail> UpdateCLParamSet(CraftsLineParamSet model, List<VCraftsLineParamSetDetail> listModels)
        {
            var result = new CommonResult<CraftsLineParamSet, VCraftsLineParamSetDetail>();
            try
            {
                var dbSession = new DBService<CraftsLineParamSet>().DbSession;

                var dbSession1 = new DBService<CraftsLineParamSetDetail>().DbSession;

                if (dbSession.GetQueryable(t => t.ID == model.ID).FirstOrDefault() == null)
                {
                    result.IsSuccess = false;
                    result.Message = "数据已经被修改或删除，请刷新！";
                }
                else if (dbSession.GetQueryable(t => t.Order == model.Order && t.ID != model.ID).FirstOrDefault() != null)
                {
                    result.Message = "执行顺序不能重复出现！";
                }
                if (result.IsSuccess)
                {
                    using (System.Transactions.TransactionScope tsc = new System.Transactions.TransactionScope())
                    {
                        var newModel = dbSession.Update(model);

                        for (int i = 0; i < listModels.Count; i++)
                        {
                            var currBodyModel = listModels[i];
                            if (string.IsNullOrEmpty(currBodyModel.Editprop) == false)
                            {
                                if (currBodyModel.Editprop.Equals("A"))
                                {
                                    currBodyModel.ID = model.ID;
                                    dbSession1.Insert(Utils.ObjectMapper<CraftsLineParamSetDetail, VCraftsLineParamSetDetail>(currBodyModel));
                                }
                                else
                                {
                                    var bodyModel = dbSession1.GetQueryable(t => t.AutoID == currBodyModel.AutoID && t.ID == model.ID).FirstOrDefault();
                                    if (bodyModel != null)
                                    {
                                        if (currBodyModel.Editprop.Equals("E"))
                                        {
                                            dbSession1.Update(Utils.ObjectMapper<CraftsLineParamSetDetail, VCraftsLineParamSetDetail>(currBodyModel));
                                        }
                                        else if (currBodyModel.Editprop.Equals("D"))
                                        {
                                            dbSession1.Delete(bodyModel);
                                        }
                                    }
                                }
                            }
                        }
                        tsc.Complete();
                    }
                    result.HeadData = dbSession.GetQueryable(t => t.ID == model.ID).FirstOrDefault();
                    result.BodyData = Utils.ObjectMapper<VCraftsLineParamSetDetail, CraftsLineParamSetDetail>(dbSession1.GetQueryable(t => t.ID == model.ID).ToList());
                }
            }
            catch (DbEntityValidationException dbvex)
            {
                Utils.Logger.Error(dbvex.ToString());
                throw dbvex;
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 删除工艺参数设置
        /// </summary>
        /// <param name="ID">编号</param>
        /// <returns></returns>
        public CommonResult<bool> DelCLParamSet(int ID)
        {
            var result = new CommonResult<bool>();
            try
            {   



                var dbSession = new DBService<CraftsLineParamSet>().DbSession;
                var dbSession1 = new DBService<CraftsLineParamSetDetail>(dbSession.Context).DbSession;
                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {
                    var model = dbSession.GetQueryable(t => t.ID == ID).FirstOrDefault();
                    var modelList = dbSession1.GetQueryable(t => t.ID == ID).ToList();
                    if (modelList != null && modelList.Count > 0)
                        dbSession1.Delete(modelList);
                    dbSession.Delete(model);
                    ts.Complete();
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
        /// 查询工艺参数设置集合
        /// </summary>
        /// <returns></returns>
        public CommonResult<List<CraftsLineParamSet>> GetCLParamSetList()
        {
            var result = new CommonResult<List<CraftsLineParamSet>>();
            try
            {
                var dbSession = new DBService<CraftsLineParamSet>().DbSession;
                result.Data = dbSession.GetQueryable().OrderBy(t => t.CraftsName).OrderBy(t => t.CraftsName).ToList();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 查询工艺参数设置主表和子表集合
        /// </summary>
        /// <param name="ID">编号</param>
        /// <returns>返回工艺参数主表和子表</returns>
        public CommonResult<CraftsLineParamSet, VCraftsLineParamSetDetail> GetCLParamSetsList(int ID)
        {
            var result = new CommonResult<CraftsLineParamSet, VCraftsLineParamSetDetail>();
            try
            {
                var dbSession = new DBService<CraftsLineParamSet>().DbSession;
                var dbSession1 = new DBService<CraftsLineParamSetDetail>().DbSession;
                result.HeadData = dbSession.GetQueryable(t => t.ID == ID).FirstOrDefault();
                result.BodyData = Utils.ObjectMapper<VCraftsLineParamSetDetail, CraftsLineParamSetDetail>(dbSession1.GetQueryable(t => t.ID == ID).ToList()); ;
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