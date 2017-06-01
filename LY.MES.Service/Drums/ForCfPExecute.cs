using LY.MES.Manage.Common;
using LY.MES.Model;
using Server.Utility;
using Server.Utility.Logging;
using Server.Utility.UserAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LY.MES.Service.CfPExecute
{
    /// <summary>
    ///  Author:xxp
    /// Remark:勤哲系统移动端UI类
    /// CreateTime:20161205
    /// name:cwh
    /// </summary>
    public class ForCfPExecute
    {


        protected UserSession currUserSession;

        // #region 设备执行表增，查
        public static ForCfPExecute GetInstance(string sessionId)
        {
            return new ForCfPExecute(sessionId);
        }

        private ForCfPExecute() { }

        public ForCfPExecute(string sessionId)
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
        /// 查询执行主表数据，用于初期对象建立
        /// </summary>
        /// <returns></returns>
        public CommonResult<List<CraftsProcessExecute>> GetCfPExecutes()
        {
            var result = new CommonResult<List<CraftsProcessExecute>>();
            // string strArrangedVouchCode = null;
            try
            {
                var dbSession = new DBService<CraftsProcessExecute>().DbSession;
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
        /// 根据设备编码获取数据，初期用于设备状态的获取XCQ20161217
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
                result.IsSuccess = false;
                result.Message = ex.Message;
                result.StackTrace = ex.StackTrace;

            }
            return result;
        }


        /// <summary>
        /// 直接获取操作日志列表XCQ20161217
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
                result.IsSuccess = false;
                result.Message = ex.Message;
                result.StackTrace = ex.StackTrace;
            }
            return result;
        }
        /// <summary>
        /// 获取当天的排配数据
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
                result.IsSuccess = false;
                result.Message = ex.Message;
                result.StackTrace = ex.StackTrace;
            }
            return result;
        }

        /// <summary>
        /// 根据排配单号获取当前工艺操作明细列表 XCQ20161217
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
                result.IsSuccess = false;
                result.Message = ex.Message;
                result.StackTrace = ex.StackTrace;
            }
            return result;
        }

        /// <summary>
        /// 根据工作台名称即转鼓号码获取执行主表中的执行状态，后面有可能改成根据转鼓编码获取
        /// </summary>
        /// <param name="WorkbrachName"></param>
        /// <returns></returns>
        public CommonResult<CraftsProcessExecute> GeCraftsProcessdByWorkbrachName(string WorkbrachName)
        {
            var result = new CommonResult<CraftsProcessExecute>();
            try
            {
                var dbSession = new DBService<CraftsProcessExecute>().DbSession;

                result.Data = dbSession.GetQueryable(t => t.WorkbrachName == WorkbrachName && t.ExecuteStatus != 0 && t.ExecuteStatus != 99).OrderByDescending(t => t.ExecuteID).FirstOrDefault();

                if (result.Data == null)
                {
                    result.Data = new CraftsProcessExecute();
                    result.Data.CraftsName = "空鼓";
                    result.Data.ExecuteStatus = 2;
                    result.Data.WorkbrachName = WorkbrachName;
                }


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
        /// 传入对象，保存数据到车间排配单表中XCQ20161217
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
                result.IsSuccess = false;
                result.Message = ex.Message;
                result.StackTrace = ex.StackTrace;
            }

            return result;

        }
        /// <summary>
        /// 传入对象，保存数据到排配单操作日志中XCQ20161217
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
                result.IsSuccess = false;
                result.Message = ex.Message;
                result.StackTrace = ex.StackTrace;
            }

            return result;

        }
        /// <summary>
        /// 传入对象，保存数据到工艺流程执行主表中XCQ20161217
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
                result.IsSuccess = false;
                result.Message = ex.Message;
                result.StackTrace = ex.StackTrace;
            }

            return result;

        }
        /// <summary>
        /// 传入排配单，执行主表，操作日志汇总视图，保存排配单数据
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
                    //  VouchDate = model.VouchDate,
                    VouchDate = DateTime.Now,
                    MaterialVouchCode = model.MaterialVouchCode,
                    FormulaCode = model.FormulaCode,
                    FormulaName = model.FormulaName,
                    InputWeight = model.InputWeight,
                    OutputWeight = model.OutputWeight,
                    WeighingPounds = model.WeighingPounds,

                    // UserStatus = model.UserStatus,
                    UserStatus = 1,


                    InterruptionRemark = model.InterruptionRemark,
                    InterruptionTime = model.InterruptionTime,
                    Creator = model.Creator,
                    //  CreateTime = model.CreateTime,
                    CreateTime = DateTime.Now,
                    ModifyPerson = model.ModifyPerson,
                    ModifyTime = model.ModifyTime,
                    LicenseNum = model.LicenseNum,
                    VehicleWeight = model.VehicleWeight,
                    WeightMan = model.WeightMan,
                    TeachProgress = model.TeachProgress,
                    RFIDCode = model.RFIDCode
                });

                var dbSessionLineSet = new DBService<CraftsLineParamSet>().DbSession;
                var resultLineSet = dbSessionLineSet.GetQueryable().OrderBy(t => t.Order).ToList();

                var dbSessionCraftsProcess = new DBService<CraftsProcessExecute>().DbSession;

                foreach (CraftsLineParamSet MyresultLine in resultLineSet)
                {
                    var Craftsmodel = new CraftsProcessExecute()
                    {
                        ArrangedVouchCode = MyArrangedVouchCode,
                        WorkbrachCode = model.WorkbrachName,
                        WorkbrachName = model.WorkbrachName,
                        WorkshopName = MyresultLine.WorkShop,
                        ExecuteOrder = MyresultLine.Order,
                        CraftsCode = MyresultLine.CraftsCode,
                        CraftsName = MyresultLine.CraftsName,
                        PlanDuration = MyresultLine.CraftsTaskTime,
                        ExecuteMode = MyresultLine.Treatment,
                        //         ExecuteStatus = MyresultLine.Order == 1 ? 1 : 0
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

                    dbSessionCraftsProcess.Insert(Craftsmodel);
                }


            }
            catch (Exception ex)
            {
                Myresult.IsSuccess = false;
                Myresult.Message = ex.Message;
                Myresult.StackTrace = ex.StackTrace;

            }




            //   string CraftsArrangedVouchCode = PubRepository.GetAutomaticNumber(dbSessionCraftsProcess.Context.Database.Connection.ConnectionString, "PPDH", 5, "ArrangedVouchCode", "ArrangedVouch", DateTime.Now);

            return Myresult;

        }

        /// <summary>
        /// 传入操作日志对象，保存操作日志数据
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
                result.IsSuccess = false;
                result.Message = ex.Message;
                result.StackTrace = ex.StackTrace;

            }
            return result;

        }
        /// <summary>
        /// 更新排配单工艺数据，用于转鼓空鼓上料XCQ20161228
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

                    }

                    Myresult.Data = dbSession.Update(currModel);

                }
            }
            catch (Exception ex)
            {
                Myresult.IsSuccess = false;
                Myresult.Message = ex.Message;
                Myresult.StackTrace = ex.StackTrace;
            }
            return Myresult;

        }

        /// <summary>
        /// 更新转鼓排配单车号信息，包括车重，毛重，皮重，等信息20170104XCQ
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
        /// 更新执行状态，用于转鼓空鼓上料XCQ20161228
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

                        model.ExecuteStatus = ExecuteStatus;
                        model.EndTime = DateTime.Now;
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

        public CommonResult<bool> UpdateCraftsProcessByExID(string ArrangedVouchCode, int ExecuteID, int ExecuteStatus,Nullable<DateTime> StartTime = null,Nullable< DateTime> EndTime=null  )
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
        /// 传入转鼓号码，获取当前转鼓工艺状态配方名称等详细数据，一般用于转鼓工艺流转
        /// </summary>XCQ20161228
        /// <param name="WorkbrachName">转鼓号码</param>
        /// <returns></returns>
        public CommonResult<vw_DurmsUpFeeding> Getvw_DurmsUpFeedingByWorkbrachName(string WorkbrachName)
        {
            var result = new CommonResult<vw_DurmsUpFeeding>();
            try
            {
                var dbSession = new DBService<vw_DurmsUpFeeding>().DbSession;

                result.Data = dbSession.GetQueryable(t => t.WorkbrachName == WorkbrachName && t.ExecuteStatus != 0 && t.ExecuteStatus != 99).OrderByDescending(t => t.ExecuteID).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.Message);
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
                result.IsSuccess = false;
                result.Message = ex.Message;
                result.StackTrace = ex.StackTrace;
            }
            return result;
        }
        /// <summary>
        /// 根据车号获取当前的排配单单号，从而为后续获取工艺做处理20170104XCQ
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
        /// 根据排配单号获取最新一条工艺执行主表的数据
        /// </summary>
        /// <param name="ArrangedVouchCode"></param>
        /// <returns></returns>
        public CommonResult<CraftsProcessExecute> GetCfPExecuteByArrangedVouchCode(string ArrangedVouchCode)
        {
            var result = new CommonResult<CraftsProcessExecute>();
            try
            {
                var dbSession = new DBService<CraftsProcessExecute>().DbSession;
                result.Data = dbSession.GetQueryable(t => t.ArrangedVouchCode == ArrangedVouchCode).OrderByDescending(t => t.ExecuteID).FirstOrDefault();
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
        /// 根据登录名称获取体重数据
        /// </summary>
        /// <param name="PerCode"></param>
        /// <returns></returns>
        public CommonResult<Person> GetPersonByPerCode(string PerCode)
        {
            var result = new CommonResult<Person>();
            try
            {
                var dbSession = new DBService<Person>().DbSession;
                result.Data = dbSession.GetQueryable(t => t.PersonCode == PerCode).FirstOrDefault();

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
