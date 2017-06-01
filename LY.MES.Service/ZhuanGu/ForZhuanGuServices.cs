using LY.MES.Manage.ZhuanGu;
using Server.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Utility.Logging;
using LY.MES.Model;

namespace LY.MES.Service.ZhuanGu
{
    public class ForZhuanGuServices
    {
        protected UserSession currUserSession;

        public static ForZhuanGuServices GetInstance(string sessionId)
        {
            return new ForZhuanGuServices(sessionId);
        }

        protected ForZhuanGuServices(string sessionId)
        {
            currUserSession = SvrUserSession.GetCurrSession(sessionId);
        }
        private ForZhuanGuServices()
        {

        }
        /// <summary>
        /// 获取当前转鼓的流转状态
        /// </summary>
        /// <returns></returns>
        public DataTable GetZhuanGuStatus()
        {
            try
            {
                return new ZhuanGuRepository().GetZhuanGuStatus();
            }
            catch (Exception ex)
            {
                Utils.Logger.Error(ex.ToString());
                throw ex;
            }
        }

        /// <summary>
        /// 获取相应转鼓的设备执行编号
        /// </summary>
        /// <param name="DevCode">转鼓编号</param>
        /// <param name="DevInterfaceNeme">设备接口名称</param>
        /// <returns></returns>
        public CommonResult<string> GetDevExecuteId(string DevCode ,string DevInterfaceNeme)
        {
            var result = new CommonResult<string>();
            try
            {
                var dbsession = new DBService<V_DV_DevExecute>().DbSession;
                var ret = dbsession.GetQueryable().Where(t => t.ZGCode == DevCode && t.DeviName == DevInterfaceNeme);
                if (ret.Count() >0)
                {
                    result.Data = string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMdd"), ret.FirstOrDefault().ExecuteID); 
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "找不到 " + DevCode +" "+ DevInterfaceNeme+" 的执行ID";
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
        /// 获取转鼓实时、历史监控数据
        /// </summary>
        /// <param name="DevCode">设备编号</param>
        /// <param name="ArrangedVouchCode">排配单号</param>
        /// <returns></returns>
        public CommonResult<DataSet> GetTempPressureTable( string PairCraftsName,string DevCode = null, string ArrangedVouchCode = null)
        {
            DataTable Temperature = new DataTable();
            DataTable Vacuo = new DataTable();
            DataTable ExecuteTime = new DataTable();

            Temperature.Columns.AddRange(new DataColumn[] { new DataColumn("dDate", typeof(DateTime)), new DataColumn("MaxValue", typeof(int)), 
                new DataColumn("MinValue", typeof(int)),new DataColumn("ActualValue",typeof(int)) });
            Temperature.TableName = "Temperature";
            Vacuo = Temperature.Clone();
            Vacuo.TableName = "Vacuo";
            ExecuteTime.Columns.AddRange(new DataColumn[] { new DataColumn("dDateHour", typeof(Double)),new DataColumn("dDate", typeof(DateTime)) });
            ExecuteTime.TableName = "ExecuteTime";

            var result = new CommonResult<DataSet>();
            try
            {
                var dbsession = new DBService<vw_DurmsUpFeeding>().DbSession;
                var Pradbsession = new DBService<V_DV_DevExecute>().DbSession; //缓存数据执行编号
                var Coldbsession = new DBService<CollectDataInfo>().DbSession; //实际采集数据

                List<vw_DurmsUpFeeding> ret = null;
                if (string.IsNullOrEmpty(DevCode) == false)
                    ret = dbsession.GetQueryable().Where(t => t.DevCode == DevCode && t.UserStatus == 1).ToList();
                else
                    ret = dbsession.GetQueryable().Where(t => t.ArrangedVouchCode == ArrangedVouchCode).ToList();

                if (ret.Count() > 0) //判断所选转鼓是否处于运作状态
                {
                    string CurrDevCode = ret.FirstOrDefault().DevCode;
                    string CurrArrangedVouchCode = ret.FirstOrDefault().ArrangedVouchCode;
                    //获取执行ID
                    var TemperatureExecuteId = Pradbsession.GetQueryable().Where(t => t.ZGCode == CurrDevCode && t.DeviName == "温度传感器").FirstOrDefault().ExecuteID;
                    var VacuoExecuteId = Pradbsession.GetQueryable().Where(t => t.ZGCode == CurrDevCode && t.DeviName == "真空传感器").FirstOrDefault().ExecuteID;


                    string CurrentProPlanNum = ret.Select(t => t.ProPlanNum).ElementAtOrDefault(0).ToString();
                    DataTable datatable = new ZhuanGuRepository().GetCraftParameter(CurrentProPlanNum);
                    if (datatable.Rows.Count > 0)
                    {
                        string CurrentPairTableNum = datatable.Rows[0]["PairTableNum"].ToString();
                       // string PairCraftsName = datatable.Rows[0]["CraftName"].ToString();

                        var query = ret.Where(t => t.CraftsName == PairCraftsName);
                        if (string.IsNullOrEmpty(DevCode) == false)
                            query = query.Where(t => t.ExecuteStatus == 1); //实时，判断是否处于监控步骤
                        var ret1 = query.FirstOrDefault();

                        if (ret1 != null)
                        {
                            DateTime CraftsStartTime = (DateTime)ret1.StartTime;
                            DataTable PairDataTable = new ZhuanGuRepository().GetMonitorPairTable(CurrentPairTableNum);//获取监测配对表
                            if (PairDataTable.Rows.Count > 0)
                            {

                                foreach (DataRow item in PairDataTable.Rows)
                                {
                                    var dDate = Convert.ToDouble(item["时间/h"].ToString()); //小时
                                    var dTemperatureMax = Convert.ToInt32(item["温度上限"].ToString());
                                    var dTemperatureMin = Convert.ToInt32(item["温度下限"].ToString());
                                    var dVacuoMax = Convert.ToInt32(item["真空上限"].ToString());
                                    var dVacuoMin = Convert.ToInt32(item["真空下限"].ToString());
                                    var dCurrrDate = ret1.StartTime.Value.AddHours(dDate);
                                    //历史采集数据
                                    var LeftTime = dCurrrDate.AddMinutes(-5);
                                    var RightTime = dCurrrDate.AddMinutes(5);

                                    var ColTemret = Coldbsession.GetQueryable().Where(t => t.CreateDate <= RightTime && LeftTime <= t.CreateDate && t.DeveCode == TemperatureExecuteId).FirstOrDefault();
                                    var ColVacret = Coldbsession.GetQueryable().Where(t => t.CreateDate <= RightTime && LeftTime <= t.CreateDate && t.DeveCode == VacuoExecuteId).FirstOrDefault();
                                    //if(ColTemret!=null)
                                    //    ColTemperature = (decimal)ColTemret.CollValue;
                                    //if(ColVacret!=null)
                                    //    ColVacuo = (decimal)ColVacret.CollValue;

                                    DataRow ExecuteRow = ExecuteTime.NewRow();//获取即将执行时间
                                    ExecuteRow["dDateHour"] = dDate; //配对表的[时间/h]
                                    ExecuteRow["dDate"] = dCurrrDate; //具体执行时间
                                    ExecuteTime.Rows.Add(ExecuteRow);

                                    if (ColTemret != null && ColVacret != null)
                                    {
                                        var ColTemperature = (decimal)ColTemret.CollValue;
                                        var ColVacuo = (decimal)ColVacret.CollValue;
                                        //温度数据
                                        DataRow TempRow = Temperature.NewRow();
                                       // TempRow["dDate"] = dCurrrDate;
                                        TempRow["dDate"] = dDate;
                                        TempRow["MaxValue"] = dTemperatureMax;
                                        TempRow["MinValue"] = dTemperatureMin;
                                        TempRow["ActualValue"] = ColTemperature;
                                        Temperature.Rows.Add(TempRow);
                                        //真空数据
                                        DataRow VacuoRow = Vacuo.NewRow();
                                        //VacuoRow["dDate"] = dCurrrDate;
                                        VacuoRow["dDate"] = dDate;
                                        VacuoRow["MaxValue"] = dVacuoMax;
                                        VacuoRow["MinValue"] = dVacuoMin;
                                        VacuoRow["ActualValue"] = ColVacuo;
                                        Vacuo.Rows.Add(VacuoRow);
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                var ds = new DataSet();
                                ds.Tables.Add(Temperature);
                                ds.Tables.Add(Vacuo);
                                ds.Tables.Add(ExecuteTime);
                                result.Data = ds;
                            }
                            else
                            {
                                result.IsSuccess = false;
                                result.Message = "找不到相应的“监测配对表”！监测配对表编号为：" + CurrentPairTableNum;
                            }
                        }
                        else if (string.IsNullOrEmpty(DevCode) == false)
                        {
                            result.IsSuccess = false;
                            result.Message = "当前该转鼓工艺步骤不是参数监控阶段！";
                        }
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.Message = "找不到相应的“新工艺参数规划表”！规划表编号为： " + CurrentProPlanNum;
                    }
                }
                else
                {
                    result.IsSuccess = false;
                    if (string.IsNullOrEmpty(DevCode) == false)
                        result.Message = "当前该转鼓未在使用中！";
                    else
                        result.Message = "找不到该排配单号相关的转鼓操作记录！排配单号：" + ArrangedVouchCode;
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
