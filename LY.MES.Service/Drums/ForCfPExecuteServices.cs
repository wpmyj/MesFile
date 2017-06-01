using LY.MES.Manage.Common;
using LY.MES.Manage.ThirdSystem;
using LY.MES.Model;
using Server.Utility;
using Server.Utility.Logging;
using Server.Utility.UserAuth;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LY.MES.Service.Drums
{
    /// <summary>
    ///  Author:xxp
    /// Remark:勤哲系统移动端UI类
    /// CreateTime:20161205
    /// name:cwh
    /// </summary>
    public class ForCfPExecuteServices
    {


        protected UserSession currUserSession;

        // #region 设备执行表增，查
        public static ForCfPExecuteServices GetInstance(string sessionId)
        {
            return new ForCfPExecuteServices(sessionId);
        }

        private ForCfPExecuteServices() { }

        public ForCfPExecuteServices(string sessionId)
        {
            // currUserSession = SvrUserSession.GetCurrSession(sessionId);
        }

        /// <summary>
        /// 获取工艺参数设置
        /// </summary>
        /// <param name="ArrangedVouchCode">编号</param>
        /// <returns>返回工艺参数主表和子表</returns>
        public CommonResult<CraftsProcessExecute, CraftsProcessExecuteDetail> GetCfPExecute(int ExecuteID)
        {
            var result = new CommonResult<CraftsProcessExecute, CraftsProcessExecuteDetail>();
            try
            {
                var dbSession = new DBService<CraftsProcessExecute>().DbSession;
                var dbSession1 = new DBService<CraftsProcessExecuteDetail>().DbSession;
                result.HeadData = dbSession.GetQueryable(t => t.ExecuteID == ExecuteID).FirstOrDefault();
                result.BodyData = dbSession1.GetQueryable(t => t.ExecuteID == ExecuteID).ToList();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;
        }



        /// <summary>
        /// 获取CraftsProcessExecute工艺参数设置
        /// </summary>
        /// <param name="ArrangedVouchCode">编号</param>
        /// <returns>返回工艺参数主表和子表</returns>
        public CommonResult<CraftsProcessExecute> GetCfPExecuteByExecuteID(int ExecuteID)
        {
            var result = new CommonResult<CraftsProcessExecute>();
            try
            {
                var dbSession = new DBService<CraftsProcessExecute>().DbSession;
                result.Data = dbSession.GetQueryable(t => t.ExecuteID == ExecuteID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;
        }


        /// <summary>
        /// 查询执行主表数据CraftsProcessExecute，用于初期对象建立
        /// </summary>
        /// <returns></returns>
        public CommonResult<List<CraftsProcessExecute>> GetCfPExecutes(string ArrangedVouchCode)
        {
            var result = new CommonResult<List<CraftsProcessExecute>>();
            // string strArrangedVouchCode = null;
            try
            {
                var dbSession = new DBService<CraftsProcessExecute>().DbSession;
                result.Data = dbSession.GetQueryable(t => t.ArrangedVouchCode == ArrangedVouchCode).ToList();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 根据设备编码获取vw_DurmsUpFeeding数据，初期用于设备状态的获取XCQ20161217
        /// </summary>
        /// <param name="Devcode"></param>
        /// <returns></returns>
        public CommonResult<List<vw_DurmsUpFeeding>> GetDurmsUpFeedingByDevCode(string Devcode)
        {
            var result = new CommonResult<List<vw_DurmsUpFeeding>>();
            try
            {
                var dbSession = new DBService<vw_DurmsUpFeeding>().DbSession;
                result.Data = dbSession.GetQueryable(t => t.DevCode == Devcode).ToList();

            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;

            }
            return result;
        }


        /// <summary>
        /// 直接获取操作日志ArrangedVouchLog列表XCQ20161217
        /// </summary>
        /// <returns></returns>

        public CommonResult<List<ArrangedVouchLog>> GetArrangedVouchLog()
        {
            var result = new CommonResult<List<ArrangedVouchLog>>();
            try
            {
                var dbSession = new DBService<ArrangedVouchLog>().DbSession;
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
        /// 获取当天的排配数据ArrangedVouch
        /// </summary>
        /// <returns></returns>
        public CommonResult<ArrangedVouch> GetArrangedBySameTime()
        {
            var result = new CommonResult<ArrangedVouch>();
            try
            {
                var dbSession = new DBService<ArrangedVouch>().DbSession;
                result.Data = dbSession.GetQueryable(t => t.VouchDate.Year == DateTime.Now.Year && t.VouchDate.Month == DateTime.Now.Month && t.VouchDate.Day == DateTime.Now.Day).OrderByDescending(t => t.ID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 根据排配单号获取ArrangedVouchLog当前工艺操作明细列表 XCQ20161217
        /// </summary>
        /// <param name="ArrangedVouchCode"></param>
        /// <returns></returns>
        public CommonResult<List<ArrangedVouchLog>> GetArrangedVouchLogByCode(string ArrangedVouchCode)
        {
            var result = new CommonResult<List<ArrangedVouchLog>>();
            try
            {
                var dbSession = new DBService<ArrangedVouchLog>().DbSession;
                result.Data = dbSession.GetQueryable(t => t.ArrangedVouchCode == ArrangedVouchCode).OrderByDescending(t => t.AutoID).ToList();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 根据工作台名称即转鼓号码获取执行主表CraftsProcessExecute中的执行状态，后面有可能改成根据转鼓编码获取
        /// </summary>
        /// <param name="WorkbrachName"></param>
        /// <returns></returns>
        public CommonResult<CraftsProcessExecute> GeCraftsProcessdByWorkbrachName(string WorkbrachCode)
        {
            var result = new CommonResult<CraftsProcessExecute>();
            try
            {
                var dbSession = new DBService<CraftsProcessExecute>().DbSession;

                result.Data = dbSession.GetQueryable(t => t.WorkbrachCode == WorkbrachCode && t.ExecuteStatus != 0 && t.ExecuteStatus != 99).OrderByDescending(t => t.ExecuteID).FirstOrDefault();

                if (result.Data == null)
                {
                    result.Data = new CraftsProcessExecute();
                    result.Data.CraftsName = "空鼓";
                    result.Data.ExecuteStatus = 2;
                    result.Data.WorkbrachCode = WorkbrachCode;
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
        /// 传入对象，保存数据到ArrangedVouch车间排配单表中XCQ20161217
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CommonResult<ArrangedVouch> InsertArrangedVouch(ArrangedVouch model)
        {
            var result = new CommonResult<ArrangedVouch>();
            try
            {
                if (result.IsSuccess)
                {
                    var dbSession = new DBService<ArrangedVouch>().DbSession;
                    result.Data = dbSession.Insert(model);
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
        /// 传入对象，保存数据到ArrangedVouchLog排配单操作日志中XCQ20161217
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CommonResult<ArrangedVouchLog> InsertArrangedVouchLog(ArrangedVouchLog model)
        {
            var result = new CommonResult<ArrangedVouchLog>();
            try
            {
                if (result.IsSuccess)
                {
                    var dbSession = new DBService<ArrangedVouchLog>().DbSession;
                    result.Data = dbSession.Insert(model);
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
        /// 传入对象，保存数据到CraftsProcessExecute工艺流程执行主表中XCQ20161217
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CommonResult<CraftsProcessExecute> InsertCraftsProcessExecute(CraftsProcessExecute model)
        {
            var result = new CommonResult<CraftsProcessExecute>();
            try
            {
                if (result.IsSuccess)
                {
                    var dbSession = new DBService<CraftsProcessExecute>().DbSession;
                    result.Data = dbSession.Insert(model);
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
        /// 传入排配单，执行主表，操作日志汇总视图，保存ArrangedVouch排配单数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CommonResult<ArrangedVouch> InsterArrVouchByVw(vw_DurmsUpFeeding model)
        {
            // var result = new CommonResult<vw_DurmsUpFeeding>();
            var Myresult = new CommonResult<ArrangedVouch>();
            string MyArrangedVouchCode;
            try
            {

                var dbSession = new DBService<ArrangedVouch>().DbSession;

                MyArrangedVouchCode = PubRepository.GetAutomaticNumber(dbSession.Context.Database.Connection.ConnectionString, "PPDH", 5, "ArrangedVouchCode", "ArrangedVouch", DateTime.Now);
                Myresult.Data = dbSession.Insert(new ArrangedVouch()
                {
                    ArrangedVouchCode = MyArrangedVouchCode,
                    VouchDate = DateTime.Now,
                    MaterialVouchCode = model.MaterialVouchCode,
                    FormulaCode = model.FormulaCode,
                    FormulaName = model.FormulaName,
                    InputWeight = model.InputWeight,
                    OutputWeight = model.OutputWeight,
                    WeighingPounds = model.WeighingPounds,
                    UserStatus = 1,
                    InterruptionRemark = model.InterruptionRemark,
                    InterruptionTime = model.InterruptionTime,
                    Creator = model.Creator,
                    CreateTime = DateTime.Now,
                    ModifyPerson = model.ModifyPerson,
                    ModifyTime = model.ModifyTime,
                    LicenseNum = model.LicenseNum,
                    VehicleWeight = model.VehicleWeight,
                    WeightMan = model.WeightMan,
                    TeachProgress = model.TeachProgress,
                    RFIDCode = model.RFIDCode,
                    VouchType = "DW01"    //20170107新增排配类型字段
                });

                var dbSessionLineSet = new DBService<CraftsLineParamSet>().DbSession;
                var ParamdbSession = new DBService<CraftsLineParamSetDetail>(dbSessionLineSet.Context).DbSession;

                var resultLineSet = dbSessionLineSet.GetQueryable().OrderBy(t => t.Order).ToList();
                var CraftParameList = ParamdbSession.GetQueryable().ToList();

                var dbSessionCraftsProcess = new DBService<CraftsProcessExecute>().DbSession;
                var dbSessionCraftsProcessDetail = new DBService<CraftsProcessExecuteDetail>().DbSession;

                foreach (CraftsLineParamSet MyresultLine in resultLineSet)
                {
                    var Craftsmodel = new CraftsProcessExecute()
                    {
                        ArrangedVouchCode = MyArrangedVouchCode,
                        WorkbrachCode = model.WorkbrachCode,
                        WorkbrachName = model.WorkbrachName,
                        WorkshopName = MyresultLine.WorkShop,
                        ExecuteOrder = MyresultLine.Order,
                        CraftsCode = MyresultLine.CraftsCode,
                        CraftsName = MyresultLine.CraftsName,
                        PlanDuration = MyresultLine.CraftsTaskTime,
                        ExecuteMode = MyresultLine.Treatment,
                    };
                    if (Craftsmodel.ExecuteOrder == 1)
                    {
                        Craftsmodel.ExecuteStatus = 1;
                        Craftsmodel.StartTime = DateTime.Now;
                    }
                    else if (Craftsmodel.ExecuteOrder == 2)
                    {
                        Craftsmodel.ExecuteStatus = 99;
                    }
                    else
                    {
                        Craftsmodel.ExecuteStatus = 0;
                    }

                    var ParamList = new List<CraftsProcessExecuteDetail>();
                    var CraftsProcessModel = dbSessionCraftsProcess.Insert(Craftsmodel);

                    var CurrParameSetDetailList = CraftParameList.Where(t => t.ID == MyresultLine.ID && t.UserStatus == "0").ToList();

                    CurrParameSetDetailList.ForEach(item =>
                    {
                        CraftsProcessExecuteDetail detail = new CraftsProcessExecuteDetail();
                        detail.ExecuteID = CraftsProcessModel.ExecuteID;
                        detail.ExecuteStatus = 0;
                        detail.Priority = item.Priority;
                        detail.IntervalDuration = item.IntervalDuration;
                        detail.IsValveCheck = item.IsValveCheck;
                        detail.IsValveControl = item.IsValveControl;
                        detail.LowerValue = item.LowerValue;
                        detail.ParameterID = item.ParameterID;
                        detail.StandardValue = item.StandardValue;
                        detail.TriggerDuration = item.TriggerDuration;
                        detail.UpperValue = item.UpperValue;
                        ParamList.Add(detail);
                    });

                    if (ParamList.Count > 0)
                    {
                        dbSessionCraftsProcessDetail.Insert(ParamList);
                    }
                }


            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;

            }
            //   string CraftsArrangedVouchCode = PubRepository.GetAutomaticNumber(dbSessionCraftsProcess.Context.Database.Connection.ConnectionString, "PPDH", 5, "ArrangedVouchCode", "ArrangedVouch", DateTime.Now);

            return Myresult;

        }

        /// <summary>
        ///2017-02-23BY -XCQ 更改数据源，将原来238XCQ设计的数据源修正为即将使用的ZJY的数据源，并修正流程，原有是在上料的时候生成排配单，工艺执行主表还有工艺执行字表
        /// </summary>现有需要秀正在在上料的时候生成排配单，在扫卡绑定的时候才进行生成工艺执行主表还有子表的操作，其中技术节点需要处理工艺规划编号引起的变动在生成表单的时候一并处理
        /// <param name="ProPlanNum"></param>工艺规划编号
        /// <returns></returns>20170226BY XCQ 停用
        public CommonResult<bool> InsterCraProDataById(string ProPlanNum, vw_DurmsUpFeeding model)
        {
            var result = new CommonResult<bool>();

            try
            {
                var dbSessionLineSet = new DBService<CraftsLineParamSet>().DbSession;
                var ParamdbSession = new DBService<vw_CraftsLineParamSetDetail>(dbSessionLineSet.Context).DbSession;

                var resultLineSet = dbSessionLineSet.GetQueryable().OrderBy(t => t.Order).ToList();
                var CraftParameList = ParamdbSession.GetQueryable().ToList();

                var dbSessionCraftsProcess = new DBService<CraftsProcessExecute>().DbSession;
                var dbSessionCraftsProcessDetail = new DBService<CraftsProcessExecuteDetail>().DbSession;


                var ActProData = QZDBRepository.GetQZProPlanNumData(ProPlanNum);
                //    var DBActProData = new DBService<ActProData>().DbSession;




                foreach (CraftsLineParamSet MyresultLine in resultLineSet)
                {
                    var Craftsmodel = new CraftsProcessExecute()
                    {
                        ArrangedVouchCode = model.ArrangedVouchCode,
                        WorkbrachCode = model.WorkbrachCode,
                        WorkbrachName = model.WorkbrachName,
                        WorkshopName = MyresultLine.WorkShop,
                        ExecuteOrder = MyresultLine.Order,
                        CraftsCode = MyresultLine.CraftsCode,
                        CraftsName = MyresultLine.CraftsName,
                        PlanDuration = MyresultLine.CraftsTaskTime,
                        ExecuteMode = MyresultLine.Treatment,
                    };

                    //----------------------------------------------------------------------------------------------------------------//
                    if (Craftsmodel.ExecuteMode == "1")
                    {
                        var ret = ActProData.Select(string.Format("[工艺编号]='{0}' and [项名称]='工艺总耗时' and [属性]='主表项' ", Craftsmodel.CraftsCode)).FirstOrDefault();
                        if (ret != null && ret.ItemArray.Count() > 0)
                        {
                            Craftsmodel.PlanDuration = (ret["[标准值]"] != null && ret["[标准值]"].ToString() != "") ? Convert.ToInt32(ret["[标准值]"].ToString()) : Craftsmodel.PlanDuration;
                        }
                    }
                    //----------------------------------------------------------------------------------------------------------------//

                    if (Craftsmodel.ExecuteOrder == 1)
                    {
                        Craftsmodel.ExecuteStatus = 1;
                        Craftsmodel.StartTime = DateTime.Now;
                    }
                    else if (Craftsmodel.ExecuteOrder == 2)
                    {
                        Craftsmodel.ExecuteStatus = 99;
                    }
                    else
                    {
                        Craftsmodel.ExecuteStatus = 0;
                    }




                    var CraftsProcessModel = dbSessionCraftsProcess.Insert(Craftsmodel);

                    var ParamList = new List<CraftsProcessExecuteDetail>();

                    //--------------------------------------分割线，上面是生成执行主表数据，下面是生成执行子表数据--------------------------------------------------------------//
                    var CurrParameSetDetailList = CraftParameList.Where(t => t.ID == MyresultLine.ID).OrderBy(t => t.AutoID).ToList();
                    foreach (var item in CurrParameSetDetailList)
                    {
                        CraftsProcessExecuteDetail detail = new CraftsProcessExecuteDetail();
                        detail.ExecuteID = CraftsProcessModel.ExecuteID;
                        detail.ExecuteStatus = 0;
                        detail.Priority = item.Priority;
                        detail.IntervalDuration = item.IntervalDuration;
                        detail.IsValveCheck = item.IsValveCheck;
                        detail.IsValveControl = item.IsValveControl;
                        detail.LowerValue = item.LowerValue;
                        detail.ParameterID = item.ParameterID;
                        detail.StandardValue = item.StandardValue;

                        detail.TriggerDuration = item.TriggerDuration;
                        detail.UpperValue = item.UpperValue;

                        //  if (true)
                        //{
                        //    var ret = ActProData.Select(string.Format("[工艺编号]='{0}' and [项名称]='{1}'", Craftsmodel.CraftsCode, detail.ParameterName)).FirstOrDefault();
                        //    if (ret != null && ret.ItemArray.Count() > 0)
                        //    {

                        //    }
                        //}
                        //else
                        //{  }
                        //var ret = ActProData.Select(string.Format("[工艺编号]='{0}' and [项名称]='{1}' and [标志]={2} and [属性]='明细项'", Craftsmodel.CraftsCode, detail.ParameterName, item.CraftsID)).FirstOrDefault();
                        var ret = ActProData.Select(string.Format("[工艺编号]='{0}' and [项名称]='{1}' and [标志]={2} and [属性]='明细项'", Craftsmodel.CraftsCode, item.ParamName, item.CraftsID)).FirstOrDefault();
                        if (ret != null && ret.ItemArray.Count() > 0)
                        {

                            detail.StandardValue = (ret["[标准值]"] != null && ret["[标准值]"].ToString() != "") ? ret["[标准值]"].ToString() : detail.StandardValue;
                            detail.UpperValue = (ret["[上限值]"] != null && ret["[上限值]"].ToString() != "") ? ret["[上限值]"].ToString() : detail.UpperValue;
                            detail.LowerValue = (ret["[下限值]"] != null && ret["[下限值]"].ToString() != "") ? ret["[下限值]"].ToString() : detail.LowerValue;
                        }



                        ParamList.Add(detail);
                    }

                    if (ParamList.Count > 0)
                    {
                        dbSessionCraftsProcessDetail.Insert(ParamList);
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
        /// 修改原来思路，在上料时生成三个表单，在绑卡时修正数据
        /// </summary>
        /// <param name="ProPlanNum"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public CommonResult<CraftsProcessExecute> UpdateCraftsProcessData(string ProPlanNum, vw_DurmsUpFeeding model)
        {
            var result = new CommonResult<CraftsProcessExecute>();
            try
            {
                var dbSession = new DBService<CraftsProcessExecute>().DbSession;
                var ActProData = QZDBRepository.GetQZProPlanNumData(ProPlanNum);

                var TestUpate = new QZDBRepository().UpdateRFIDStatus(model.RFIDCode); //测试修改勤哲RFID卡号

                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {


                    var Updatemodel = dbSession.GetQueryable(t => t.ArrangedVouchCode == model.ArrangedVouchCode && t.ExecuteOrder == 5).FirstOrDefault();
                    if (Updatemodel == null)
                    {
                        result.IsSuccess = false;
                        result.Message = "该设备信息已经不存在";
                    }

                    if (result.IsSuccess)
                    {
                        // and [属性]='主表项' 
                        var ret = ActProData.Select(string.Format("[工艺名称]='烘料' and [项名称]='工艺总耗时'")).FirstOrDefault();
                        if (ret != null && ret.ItemArray.Count() > 0)
                        {
                            string Test = ret["标准值"].ToString();
                            Updatemodel.PlanDuration = Convert.ToInt32(Convert.ToDecimal(ret["标准值"]));
                            //   Updatemodel.PlanDuration = (ret["标准值"] != null && ret["标准值"].ToString() != "") ? Convert.ToInt32(ret["标准值"].ToString()) : Updatemodel.PlanDuration;
                        }

                        result.Data = dbSession.Update(Updatemodel);
                        //  ts.Complete();
                    }

                    // var ActProDataTail = QZDBRepository.GetQZProPlanNumData(ProPlanNum);
                    //修改执行字表
                    var dbSessionTail = new DBService<CraftsProcessExecuteDetail>().DbSession;
                    var listParam = new DBService<CraftsParameterContrast>().DbSession.GetQueryable().ToList();
                    var CraftsProcessData = dbSession.GetQueryable(t => t.ArrangedVouchCode == model.ArrangedVouchCode).ToList();

                    foreach (var item in CraftsProcessData)
                    {
                        var CraftsProcessTailData = dbSessionTail.GetQueryable(t => t.ExecuteID == item.ExecuteID).ToList();

                        foreach (var itemTail in CraftsProcessTailData)
                        {
                            //and [标志]={2} 暂时取消标志
                            //var UpdatemodelTail = dbSessionTail.GetQueryable(t => t.ExecuteID == item.ExecuteID && t.ParameterName == itemTail.ParameterName).FirstOrDefault();
                            var UpdatemodelTail = dbSessionTail.GetQueryable(t => t.ExecuteID == item.ExecuteID && t.ParameterID == itemTail.ParameterID).FirstOrDefault();

                            // and [属性]='明细项'

                            //var retTail = ActProData.Select(string.Format("[工艺编号]='{0}' and [项名称]='{1}'", item.CraftsCode, itemTail.ParameterName)).FirstOrDefault();

                            var paramName = listParam.Where(t => t.ParameterID == itemTail.ParameterID).FirstOrDefault();
                            var retTail = ActProData.Select(string.Format("[工艺编号]='{0}' and [项名称]='{1}'", item.CraftsCode, paramName.ParamName)).FirstOrDefault();
                            //if (item.CraftsName == "烘料" && (itemTail.ParameterName == "温度"))
                            //{
                            if (retTail != null && retTail.ItemArray.Count() > 0)
                            {

                                UpdatemodelTail.StandardValue = (retTail["标准值"] != null && retTail["标准值"].ToString() != "") ? retTail["标准值"].ToString() : UpdatemodelTail.StandardValue;
                                UpdatemodelTail.UpperValue = (retTail["上限值"] != null && retTail["上限值"].ToString() != "") ? retTail["上限值"].ToString() : UpdatemodelTail.UpperValue;
                                UpdatemodelTail.LowerValue = (retTail["下限值"] != null && retTail["下限值"].ToString() != "") ? retTail["下限值"].ToString() : UpdatemodelTail.LowerValue;
                            }

                            dbSessionTail.Update(UpdatemodelTail);

                            //    }
                        }

                    }

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
        /// 传入ArrangedVouchLog操作日志对象，保存操作日志数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CommonResult<ArrangedVouchLog> InsterArrVouchLog(ArrangedVouchLog model)
        {

            var result = new CommonResult<ArrangedVouchLog>();

            try
            {
                if (result.IsSuccess)
                {
                    var dbSession = new DBService<ArrangedVouchLog>().DbSession;
                    result.Data = dbSession.Insert(model);
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
        /// 更新ArrangedVouch排配单工艺数据，用于转鼓空鼓上料XCQ20161228
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CommonResult<ArrangedVouch> UpdateArrangedVouchCode(vw_DurmsUpFeeding model)
        {
            var Myresult = new CommonResult<ArrangedVouch>();

            try
            {
                if (Myresult.IsSuccess)
                {
                    var dbSession = new DBService<ArrangedVouch>().DbSession;
                    var currModel = dbSession.GetQueryable(t => t.ArrangedVouchCode == model.ArrangedVouchCode).FirstOrDefault();
                    if (currModel != null)
                    {

                        currModel.MaterialVouchCode = model.MaterialVouchCode;
                        currModel.FormulaCode = model.FormulaCode;
                        currModel.FormulaName = model.FormulaName;
                        currModel.InputWeight = model.InputWeight;
                        currModel.RFIDCode = model.RFIDCode;
                        currModel.ProPlanNum = model.ProPlanNum;

                    }

                    Myresult.Data = dbSession.Update(currModel);

                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return Myresult;

        }

        /// <summary>
        /// 更新ArrangedVouch转鼓排配单车号信息，包括车重，毛重，皮重，等信息20170104XCQ
        /// </summary>
        /// <param name="model">传入vw_DurmsUpFeeding模型数据进来</param>
        /// <returns></returns>
        public CommonResult<ArrangedVouch> UpdateArrangedVouchWeight(vw_DurmsUpFeeding model)
        {
            var Myresult = new CommonResult<ArrangedVouch>();

            try
            {

                var dbSession = new DBService<ArrangedVouch>().DbSession;
                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {
                    var currModel = dbSession.GetQueryable(t => t.ArrangedVouchCode == model.ArrangedVouchCode).FirstOrDefault();
                    if (currModel == null)
                    {
                        Myresult.IsSuccess = false;
                        Myresult.Message = "该设备信息已经不存在";

                    }
                    else if (currModel != null)
                    {

                        currModel.WeighingPounds = model.WeighingPounds;
                        currModel.InputWeight = model.InputWeight;
                        currModel.OutputWeight = model.OutputWeight;
                        currModel.LicenseNum = model.LicenseNum;
                        currModel.VehicleWeight = model.VehicleWeight;
                        currModel.WeightMan = model.WeightMan;
                    }
                    if (Myresult.IsSuccess)
                    {
                        Myresult.Data = dbSession.Update(currModel);
                        ts.Complete();

                    }
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }

            return Myresult;

        }


        /// <summary>
        /// 更新CraftsProcessExecute执行状态，用于转鼓空鼓上料XCQ20161228
        /// </summary>更新执行状态，用于转鼓空鼓上料XCQ20161229,增加传入字段执行状态，由客户端确定执行状态的变更情况
        /// 20161229更新，对更新执行做了修正，增加了事务处理
        /// <param name="ArrangedVouchCode"></param>
        /// <param name="Order"></param>
        /// <returns></returns>

        public CommonResult<CraftsProcessExecute> UpdateCraftsProcessExecute(string ArrangedVouchCode, int Order, int ExecuteStatus)
        {
            var Myresult = new CommonResult<CraftsProcessExecute>();
            try
            {
                var dbSession = new DBService<CraftsProcessExecute>().DbSession;

                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {
                    //   var currModel = dbSession.GetQueryable(t => t.ArrangedVouchCode == ArrangedVouchCode && t.ExecuteOrder == Order).FirstOrDefault();
                    var model = dbSession.GetQueryable(t => t.ArrangedVouchCode == ArrangedVouchCode && t.ExecuteOrder == Order).FirstOrDefault();
                    if (model == null)
                    {
                        Myresult.IsSuccess = false;
                        Myresult.Message = "该设备信息已经不存在";
                    }

                    if (Myresult.IsSuccess)
                    {
                        if (ExecuteStatus == 1)
                        {
                            model.StartTime = DateTime.Now;
                        }
                        else if (ExecuteStatus == 2)
                        {
                            model.EndTime = DateTime.Now;
                        }

                        model.ExecuteStatus = ExecuteStatus;
                        Myresult.Data = dbSession.Update(model);
                        ts.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
            return Myresult;
        }

        /// <summary>
        /// 公用方法，根据传入的排配单号，执行ID，还有要修改的执行状态，可选参数传入开始时间，结束时间
        /// </summary>
        /// <param name="ArrangedVouchCode">排配单号</param>
        /// <param name="ExecuteID">执行ID</param>
        /// <param name="ExecuteStatus">要变更的执行状态</param>
        /// <returns></returns>

        public CommonResult<bool> UpdateCraftsProcessByExID(string ArrangedVouchCode, int ExecuteID, int ExecuteStatus, Nullable<DateTime> StartTime = null, Nullable<DateTime> EndTime = null)
        {
            var result = new CommonResult<bool>();
            try
            {
                var dbSession = new DBService<CraftsProcessExecute>().DbSession;
                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {
                    var model = dbSession.GetQueryable(t => t.ArrangedVouchCode == ArrangedVouchCode && t.ExecuteID == ExecuteID).FirstOrDefault();
                    if (model == null)
                    {
                        result.Data = false;
                    }
                    if (result.IsSuccess)
                    {
                        model.ExecuteStatus = ExecuteStatus;
                        if (StartTime.HasValue)
                            model.StartTime = StartTime.Value;
                        if (EndTime.HasValue)
                            model.EndTime = EndTime.Value;

                        dbSession.Update(model);
                        ts.Complete();
                        result.Data = true;
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
        ///  xxp 更新工艺执行参数状态
        /// </summary>
        /// <param name="AutoID">工艺执行参数ID</param>
        /// <param name="ExecuteStatus">执行状态</param>
        /// <param name="StartTime">开始时间</param>
        /// <param name="EndTime">结束时间</param>
        /// <returns></returns>
        public CommonResult<bool> UpdateCPEDetailExecuteStatusByAutoID(int AutoID, int ExecuteStatus, Nullable<DateTime> StartTime = null, Nullable<DateTime> EndTime = null)
        {
            var result = new CommonResult<bool>();
            try
            {
                var dbSession = new DBService<CraftsProcessExecuteDetail>().DbSession;
                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {
                    var model = dbSession.GetQueryable(t => t.AutoID == AutoID).FirstOrDefault();
                    if (model == null)
                    {
                        result.Data = false;
                    }
                    if (result.IsSuccess)
                    {
                        model.ExecuteStatus = ExecuteStatus;
                        if (StartTime.HasValue)
                            model.StartDateTime = StartTime.Value;
                        if (EndTime.HasValue)
                            model.EndDateTime = EndTime.Value;

                        dbSession.Update(model);
                        ts.Complete();
                        result.Data = true;
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
        /// 传入转鼓号码，获取当前vw_DurmsUpFeeding转鼓工艺状态配方名称等详细数据，一般用于转鼓工艺流转
        /// </summary>XCQ20161228
        /// <param name="WorkbrachName">转鼓号码</param>
        /// <returns></returns>
        public CommonResult<vw_DurmsUpFeeding> Getvw_DurmsUpFeedingByWorkbrachName(string WorkbrachCode)
        {
            var result = new CommonResult<vw_DurmsUpFeeding>();
            try
            {
                var dbSession = new DBService<vw_DurmsUpFeeding>().DbSession;

                result.Data = dbSession.GetQueryable(t => t.WorkbrachCode == WorkbrachCode && t.ExecuteStatus != 0 && t.ExecuteStatus != 99).OrderByDescending(t => t.ExecuteID).FirstOrDefault();


            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// 根据排配单号获取vw_DurmsUpFeeding视图数据，初期用于对象的建立XCQ20161217
        /// </summary>更新与20161228 用于转鼓工艺流转
        /// <param name="ArrangedVouchCode"></param>
        /// <returns></returns>
        public CommonResult<List<vw_DurmsUpFeeding>> GetDurmsUpFeedingByArrCode(string ArrangedVouchCode)
        {
            var result = new CommonResult<List<vw_DurmsUpFeeding>>();
            try
            {
                var dbSession = new DBService<vw_DurmsUpFeeding>().DbSession;
                result.Data = dbSession.GetQueryable(t => t.ArrangedVouchCode == ArrangedVouchCode).ToList();

            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// 根据车号获取当前的ArrangedVouch排配单单号，从而为后续获取工艺做处理20170104XCQ
        /// </summary>
        /// <param name="LicenseNum"></param>
        /// <returns></returns>
        public CommonResult<ArrangedVouch> GetArrangedVouchCodeByLicensenNum(string LicenseNum)
        {
            var result = new CommonResult<ArrangedVouch>();
            try
            {
                var dbSession = new DBService<ArrangedVouch>().DbSession;

                result.Data = dbSession.GetQueryable(t => t.LicenseNum == LicenseNum).OrderByDescending(t => t.ID).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }

            return result;
        }
        /// <summary>
        /// 根据传入的车号获取当前的排配单号，必须当前处理执行顺序第八步，并且执行状态为1或98，及当前是装车完毕或过磅完毕状态
        /// </summary>20170110XCQ
        /// <param name="LicenseNum"></param>
        /// <returns></returns>
        public CommonResult<vw_DurmsUpFeeding> Getvw_DurmsUpFeedingByLnum(string LicenseNum)
        {
            var result = new CommonResult<vw_DurmsUpFeeding>();
            try
            {
                var dbSession = new DBService<vw_DurmsUpFeeding>().DbSession;
                result.Data = dbSession.GetQueryable(t => t.ExecuteOrder == 8 && t.LicenseNum == LicenseNum && (t.ExecuteStatus == 1 || t.ExecuteStatus == 98)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// 根据排配单号获取最新执行主表CraftsProcessExecute数据
        /// 2017-01-09修正为当前最新执行状态数据，增加t.ExecuteStatus != 0 && t.ExecuteStatus != 99判断条件
        /// </summary>20170110XC1
        /// <param name="ArrangedVouchCode"></param>
        /// <returns></returns>
        public CommonResult<CraftsProcessExecute> GetCfPExecuteByArrangedVouchCode(string ArrangedVouchCode)
        {
            var result = new CommonResult<CraftsProcessExecute>();
            try
            {
                var dbSession = new DBService<CraftsProcessExecute>().DbSession;
                result.Data = dbSession.GetQueryable(t => t.ArrangedVouchCode == ArrangedVouchCode && t.ExecuteStatus != 0 && t.ExecuteStatus != 99).OrderByDescending(t => t.ExecuteID).FirstOrDefault();
                //   result.Data = dbSession.GetQueryable().OrderBy(t => t.ExecuteID).OrderBy(t => t.CraftsName).ToList();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// 获取Person体重信息，根据登录人的登录账号20170110XC1
        /// </summary>
        /// <param name="PerCode"></param>
        /// <returns></returns>
        public CommonResult<Person> GetPersonByPerCode(string PerCode)
        {
            var result = new CommonResult<Person>();
            try
            {
                var dbSession = new DBService<Person>().DbSession;
                result.Data = dbSession.GetQueryable(t => t.OparatorCode == PerCode).FirstOrDefault();


            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// 获取DeviceWorkingCondition当前车号工作状态，判断其处于空车状态还是已经转料20170110XC1
        /// </summary>
        /// <param name="DevCode"></param>
        /// <returns></returns>
        public CommonResult<DeviceWorkingCondition> GetDevStatusByCode(string DevCode)
        {
            var result = new CommonResult<DeviceWorkingCondition>();
            try
            {
                var dbSession = new DBService<DeviceWorkingCondition>().DbSession;
                result.Data = dbSession.GetQueryable(t => t.DevCode == DevCode).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// 更新DeviceWorkingCondition设备状态信息，初期主要用于车号的状态更新，装车时将其WorkingStatus更新为1，卸料时将其更新为0，20170110XC1
        /// </summary>
        /// <param name="DevCode"></param>
        /// <param name="WorkingStatus"></param>
        /// <returns></returns>
        public CommonResult<DeviceWorkingCondition> UpdateDevWStatusByCode(string DevCode, int WorkingStatus)
        {
            var result = new CommonResult<DeviceWorkingCondition>();
            try
            {
                var dbSession = new DBService<DeviceWorkingCondition>().DbSession;
                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {
                    var model = dbSession.GetQueryable(t => t.DevCode == DevCode).FirstOrDefault();
                    if (model == null)
                    {
                        result.IsSuccess = false;
                        result.Message = "该设备信息已经不存在";
                    }
                    model.WorkingStatus = WorkingStatus;
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
        /// 遍历获取IP登记表所有IP数据，暂定匹配条件为状态是0的时候，登记表中新建数据默认status为0
        /// </summary>20170117XCQ
        /// <returns></returns>
        public CommonResult<List<IPRegistForm>> GetAllIPRegistForm()
        {
            var result = new CommonResult<List<IPRegistForm>>();
            try
            {
                var dbSession = new DBService<IPRegistForm>().DbSession;
                result.Data = dbSession.GetQueryable(t => t.Status == 0).ToList();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
                throw ex;
            }

            return result;
        }
        /// <summary>
        /// IP登记表的保存服务，status默认为0
        /// </summary>20170117XCQ
        /// <param name="model"></param>
        /// <returns></returns>
        public CommonResult<IPRegistForm> InsterRegistForm(IPRegistForm model)
        {
            var result = new CommonResult<IPRegistForm>();
            try
            {
                var dbSession = new DBService<IPRegistForm>().DbSession;
                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {
                    model.Status = 0;
                    result.Data = dbSession.Insert(model);
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
        /// IP登记表的更新服务，传入对象为该数据表的model
        /// </summary>20170117XCQ
        /// <param name="model"></param>
        /// <returns></returns>
        public CommonResult<IPRegistForm> UpdateRegistForm(IPRegistForm model)
        {
            var result = new CommonResult<IPRegistForm>();
            try
            {
                var dbSession = new DBService<IPRegistForm>().DbSession;
                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {
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
        /// IP登记表删除服务，传入对象进行删除操作
        /// </summary>20170117XCQ
        /// <param name="model"></param>
        /// <returns></returns>
        public CommonResult<IPRegistForm> DeleteRegistFormById(IPRegistForm model)
        {
            var result = new CommonResult<IPRegistForm>();
            try
            {
                var dbSession = new DBService<IPRegistForm>().DbSession;
                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {
                    var ServerModel = dbSession.GetQueryable(t => t.ID == model.ID).FirstOrDefault();
                    if (ServerModel != null)
                    {
                        dbSession.Delete(ServerModel);
                        ts.Complete();
                        result.IsSuccess = true;

                    }
                    else
                    {
                        result.IsSuccess = false;
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
        /// 根据传入值排配单号查找高温排水跟自然排水的工艺字表状态，查看优先度不为100的工艺执行是否已完成，全部完成则返回true，反之false
        /// </summary>
        /// <param name="ArrangedVouchCode"></param>
        /// <returns></returns>
        public CommonResult<bool> GetArrCuteByArrCode(string ArrangedVouchCode, int ExecuteOrder)
        {
            var result = new CommonResult<bool>();
            try
            {
                var dbSession = new DBService<vw_ArrangedCraftsProcessExecute>().DbSession;
                var model = dbSession.GetQueryable(t => t.ArrangedVouchCode == ArrangedVouchCode && t.Priority != 100 && t.ExecuteOrder == ExecuteOrder && t.ParamExecuteStatus != 2).FirstOrDefault();
                if (model == null)
                {
                    result.Data = true;
                }
                else
                {
                    result.Data = false;
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
