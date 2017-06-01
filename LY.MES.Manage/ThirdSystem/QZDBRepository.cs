using Server.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using LY.MES.Manage.Common;
using System.Data.Entity;

using LY.MES.Model.VModel;


namespace LY.MES.Manage.ThirdSystem
{
    /// <summary>
    /// Author:xxp
    /// Remark:勤哲系统DB处理类
    /// CreateTime:20161108
    /// </summary>
    public class QZDBRepository
    {
        private DbContext context = new DbContext("name=LYMesSystemEntities");

        /// <summary>
        /// 获取车间班次表质检员数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetQualityInspector()
        {
            string sql = string.Format("select distinct [姓名] from [车间班次表_明细] where [岗位]='质检'");
            var dataset = SqlHelper.Query(DbProvider.QZ_DBConnect, sql);
            return dataset.Tables[0];
        }

        /// <summary>
        /// 获取订单排产汇总数据-许长庆
        /// </summary>
        /// <returns></returns>
        public DataTable GetOrderSchData(DataTable dtFilter, int PageSize, int CurrPage, ref int iTotalNum)
        {

            StringBuilder strWhere = new StringBuilder();
            var LstParameter = Server.Utility.Db.SqlDBProcess.GetParameterList(dtFilter, ref strWhere);
            iTotalNum = SqlHelper.ExecuteScalar<Int32>(DbProvider.QZ_DBConnect, string.Format("select count(1) from [ZG7_质检拉力订单选择视图] where 1=1 {0}", strWhere), LstParameter.ToArray());

            string sql = string.Format("select 生产日期,销售方式,明细ID,机台,线号,强度,规格 from (select row_number()over(order by 生产日期 desc) Num,temp.* from [ZG7_质检拉力订单选择视图] as temp where 1=1 {0}) temp1 where Num BETWEEN {1} AND {2}", strWhere.ToString(), ((CurrPage - 1) * PageSize) + 1, (CurrPage * PageSize));

            var dataset = SqlHelper.Query(DbProvider.QZ_DBConnect, sql, LstParameter.ToArray());
            return dataset.Tables[0];
        }

        /// <summary>
        /// 获取拉力计算规则
        /// </summary>
        /// <returns>拉力计算规则集合</returns>
        public DataTable GetPullCompute()
        {
            string strSql = "select [优先级],[产品级别],[强度],[订单类型],[宽度],[厚度],[拉力上限],[拉力下限] from [产品拉力计算基础表_明细]";
            var dataset = SqlHelper.Query(DbProvider.QZ_DBConnect, strSql);
            return dataset.Tables[0];
        }

        /// <summary>
        /// 获取工艺信息表
        /// </summary>
        /// <returns>返回DataTable对象:WorkShop(车间)、CraftsCode(工艺编号)、CraftsName(工艺名称)</returns>
        public DataTable GetCraftsTable()
        {
            string strSql = "select [所在工段] as WorkShop,[工艺编号] as CraftsCode,[工艺名称] as CraftsName from [工艺信息1_主表] where [审核状态]='已通过' order by [所在工段],[工艺编号]";
            var dataset = SqlHelper.Query(DbProvider.QZ_DBConnect, strSql);
            return dataset.Tables[0];
        }
        /// <summary>
        /// 获取转鼓工艺领料视图 XCQ20161217
        /// </summary>
        /// <param name="RFIDCode"></param>
        /// <returns></returns>
        public DataTable GetQZRFIDCodeData(string RFIDCode)
        {
            string strSql = string.Format("select RFID卡号,号码,每鼓合计总重,供应商编码,供应商名称,原料编码,原料名称,合计重量,制单日期,品种,领料任务单号,单据编号,工单单号,上料状态,明细上料状态 from Z2专用_转鼓工艺领料视图 where 明细上料状态 != '已上料' and   RFID卡号 = '{0}'", RFIDCode);
            var dataset = SqlHelper.Query(DbProvider.QZ_DBConnect, strSql);
            return dataset.Tables[0];

        }

        /// <summary>
        /// 获取新的转鼓工艺领料视图 XCQ20170227  BY XCQ
        /// </summary>
        /// <param name="RFIDCode"></param>
        /// <returns></returns>
        public DataTable GetNewQZRFIDCodeData(string RFIDCode)
        {
            string strSql = string.Format("select RFID卡号,号码,每鼓合计重量,物料编码,物料名称,合计重量,绑卡制单日期,领出单号,过磅单号,配方单号,明细上料状态,绑卡单号,参数规划表,参数表编码,配方名称,颜色代码 from ZI1专用_转鼓绑卡上料视图 where 明细上料状态 != '已上料' and   RFID卡号 = '{0}'", RFIDCode);
            var dataset = SqlHelper.Query(DbProvider.QZ_DBConnect, strSql);
            return dataset.Tables[0];

        }


        /// <summary>
        /// 获取工艺参数规划表数据，增加筛选条件参数属性是可变量，返回数据集合，
        /// </summary>
        /// <param name="ProPlanNum"></param>
        /// <returns></returns>
        public static DataTable GetQZProPlanNumData(string ProPlanNum)
        {
            string strSql = string.Format("select 规划表编码,参数规划表,工艺编号,工艺名称,项编号,项名称,标识,单位,标准值,上限值,下限值,参数属性,备注 from ZI4工艺参数规划表视图 where 参数属性 = '可变量' and   规划表编码 = '{0}'", ProPlanNum);
            var dataset = SqlHelper.Query(DbProvider.QZ_DBConnect, strSql);
            return dataset.Tables[0];
        }

        /// <summary>
        ///传入日期时间值，一般传入当前日期， 对比当前时间，获取转鼓配方单_主表中生产周期结束字段的日期+2天大于等于当前日期的最新两条数据，最新是指填报时间最新
        /// </summary>
        /// <param name="SysTime"></param>
        /// <returns></returns>
        public DataTable GetQZZGData(DateTime SysTime)
        {
            DateTime MySysTime = SysTime.AddDays(-3d);
            //"
            string strSql = string.Format("select 配方名称,配方单号,实际备料累计T,预计备料量T,周期产量T,生产周期结束,品种,品种类型,生产周期开始 from 转鼓配方单_主表 WITH(NOLOCK) where 生产周期结束 >= '{0}' order by 制单日期 desc", MySysTime);
            var dataset = SqlHelper.Query(DbProvider.QZ_DBConnect, strSql);
            return dataset.Tables[0];
        }

        public DataTable GetQZWeight(DateTime StartTime, DateTime EndTime, string VarietyName, string Type)
        {
            //string strSql = string.Format("select * from ZI04订单明细过磅记录视图 where timeA >= '{0}' and  timeA<={1}  and 品种名称='{2}'  and 类型='{3}'", StartTime, EndTime, VarietyName, Type);
            string strSql; 
            //if(Type=="全部")
            //strSql = string.Format("select 明细ID,品种名称,类型,颜色,强度,weightA,timeA from ZI04订单明细过磅记录视图 where 品种名称='{0}'  and timeA > '{2}'  and timeA<='{3}'", VarietyName, Type, StartTime, EndTime);

            //else
            //    strSql = string.Format("select 明细ID,品种名称,类型,颜色,强度,weightA,timeA from ZI04订单明细过磅记录视图 where 品种名称='{0}'  and 类型='{1}' and timeA > '{2}'  and timeA<='{3}'", VarietyName, Type, StartTime, EndTime);


            if (Type == "全部")
                strSql = string.Format("select 明细ID,品种名称,类型,颜色,强度,weightA,timeA from ZI04_2订单明细过磅记录视图 where 品种名称='{0}'  and timeA > '{2}'  and timeA<='{3}'", VarietyName, Type, StartTime, EndTime);

            else
                strSql = string.Format("select 明细ID,品种名称,类型,颜色,强度,weightA,timeA from ZI04_2订单明细过磅记录视图 where 品种名称='{0}'  and 类型='{1}' and timeA > '{2}'  and timeA<='{3}'", VarietyName, Type, StartTime, EndTime);


            var dataset = SqlHelper.Query(DbProvider.QZ_DBConnect, strSql);
            return dataset.Tables[0];
        }
        /// <summary>
        /// 获取备料区合计重量,返回每鼓合计重量
        /// </summary>
        /// <returns></returns>
        public DataTable GetRFIDWeight(string FormulaCode)
        {
            //    string strSql = string.Format("select 每鼓合计重量 from 原料RFID绑卡_明细新 WITH(NOLOCK) where 上料状态 = ''");
            string sqlTest = string.Format(" select  每鼓合计重量  from 原料RFID绑卡_明细新 where 上料状态 = '' and ExcelServerRCID in (select ExcelServerRCID from 原料RFID绑卡_主表 where 配方单号 = '{0}')", FormulaCode);
            var dataset = SqlHelper.Query(DbProvider.QZ_DBConnect, sqlTest);
            return dataset.Tables[0];
            //return dataset.Tables[0][0];
        }
        /// <summary>
        /// 获取转鼓当前状态,用于备料看板
        /// </summary>
        /// <returns></returns>
        public DataTable GetZGStatus()
        {
            string sqlZGSsatus = string.Format("SELECT DevCode,Max(FormulaName) AS FormulaName,Max(FormulaCode) AS FormulaCode FROM  ("
                                             + "   SELECT  DevCode,CASE WHEN UserStatus=1  THEN FormulaName ELSE NULL END AS FormulaName,"
                                             + "   CASE WHEN UserStatus=1   THEN FormulaCode ELSE NULL END AS FormulaCode"
                                             + "   from vw_DurmsUpFeeding WITH(NOLOCK) ) temp  GROUP BY DevCode "
                                             );
            var dataset = SqlHelper.Query(context.Database.Connection.ConnectionString, sqlZGSsatus);
            return dataset.Tables[0];
            //return dataset.Tables[0][0];
        }

        /// <summary>
        /// 获取转鼓工艺领料视图中的颜色代码，传入转鼓配方单号 XCQ20170314  BY XCQ
        /// </summary>
        /// <param name="RFIDCode"></param>
        /// <returns></returns>
        public DataTable GetColorData(string FormulaCode)
        {
            string strSql = string.Format("select distinct 配方单号, 颜色代码,配方名称  from 转鼓配方单_主表 where  颜色代码 is not null and 颜色代码 !='' and 配方单号 = '{0}'", FormulaCode);
            var dataset = SqlHelper.Query(DbProvider.QZ_DBConnect, strSql);
            return dataset.Tables[0];

        }
        /// <summary>
        /// 获取看板颜色定义基础数据,返回唯一性颜色代码
        /// </summary>
        /// <returns></returns>
        public DataTable GetQZFunColor()
        {
            string strSql = string.Format("select distinct 颜色代码  from 看板配方颜色定义_明细 where 颜色代码 is not null");
            var dataset = SqlHelper.Query(DbProvider.QZ_DBConnect, strSql);
            return dataset.Tables[0];
        }
        /// <summary>
        /// 获取空鼓颜色代码,返回颜色代码以及品种字段
        /// </summary>
        /// <returns></returns>
        public DataTable GetNullZGColor()
        {
            string strSql = string.Format("select  颜色代码,品种  from 看板配方颜色定义_明细 where 颜色代码 is not null and 品种 ='空鼓'");
            var dataset = SqlHelper.Query(DbProvider.QZ_DBConnect, strSql);
            return dataset.Tables[0];
        }


        public DataTable GetRFIDData()
        {
            string strSql = string.Format("select 配方单号,RFID卡号,号码,每鼓合计重量,颜色代码,配方名称 from ZI5MES转鼓未上料RFID数据 WITH(NOLOCK) where  颜色代码 is not null and 颜色代码 !='' ");
            var dataset = SqlHelper.Query(DbProvider.QZ_DBConnect, strSql);
            return dataset.Tables[0];
            //return dataset.Tables[0][0];
        }

        /// <summary>
        /// 无参数传入,获取4号线料缸重量,去前100条数据，按照时间倒序排列,返回表字段为料缸重量,料斗剩余时间,时间 
        /// </summary>
        /// <returns></returns>
        public DataTable GetL4Data1()
        {
            string strSql = string.Format("select top 100 料缸重量,料斗剩余时间,时间 from L4Data1 WITH(NOLOCK) order by 时间 desc ");
            var dataset = SqlHelper.Query(DbProvider.ZK_DBConnect, strSql);
            return dataset.Tables[0];
        }

        /// <summary>
        /// 无参数传入,获取5号线料缸重量,去前100条数据，按照时间倒序排列,返回表字段为料缸重量,料斗剩余时间,时间
        /// </summary>
        /// <returns></returns>
        public DataTable GetL5Data1()
        {
            string strSql = string.Format("select top 100 料缸重量,料斗剩余时间,时间 from L5Data1 WITH(NOLOCK) order by 时间 desc ");
            var dataset = SqlHelper.Query(DbProvider.ZK_DBConnect, strSql);
            return dataset.Tables[0];
        }


        public object UpdateRFIDStatus(string RFIDNum)
        {

            string strSql = string.Format("update 原料RFID绑卡_明细新 set 上料状态 = '已上料' where RFID卡号='{0}'", RFIDNum);
            var dataset = SqlHelper.ExecuteNonQuery(DbProvider.QZ_DBConnect, strSql);

            return dataset;
        }

        public DataTable GetQZPcDataByJH(string JiHao)
        {
            string strSql = string.Format("select 订单明细ID as cbatchnumber,a.备注 as cnextnumber,规格 "
                                           + " as cspecifications,CASE WHEN 纸芯重量 is null THEN 0 ELSE 纸芯重量 END"
                                           + " as fweightpapercore,单重 as fvolumekg,任务件数 as fschedulingnumber,a.备注"
                                           + " as cweighingnumber,机台 as cdevicenumber,生产日期 as dproductiondate,件托 "
                                           + " as jt from 索带排产_明细 a ,索带排产_主表 b where 任务状态= '进行中' "
                                           + " and a.ExcelServerRCID = b.ExcelServerRCID and 机台='{0}'", JiHao);
            var dataset = SqlHelper.Query(DbProvider.QZ_DBConnect, strSql);
            return dataset.Tables[0];
        }


        public DataTable GetQZPcDataByOrder(string Order)
        {
            string strSql = string.Format("select 订单明细ID as cbatchnumber,a.备注 as cnextnumber,规格 "
                                           + " as cspecifications,CASE WHEN 纸芯重量 is null THEN 0 ELSE 纸芯重量 END"
                                           + " as fweightpapercore,单重 as fvolumekg,任务件数 as fschedulingnumber,a.备注"
                                           + " as cweighingnumber,机台 as cdevicenumber,生产日期 as dproductiondate,件托 "
                                           + " as jt,包装 as bundle,印字内容 as content,特殊要求 as claim from 索带排产_明细 a ,"
                                           + " 索带排产_主表 b where 任务状态= '进行中' and a.ExcelServerRCID = b.ExcelServerRCID "
                                           + " and 订单明细ID = '{0}'", Order);
            var dataset = SqlHelper.Query(DbProvider.QZ_DBConnect, strSql);
            return dataset.Tables[0];
        }


        public DataTable GetSJDataByJH(string line)
        {
            string strSql = string.Format(" select top 4  serial,paichan,timeA from sj_line a where line='{0}'"
                                            + " and exists(select serial,paichan,timeA from(select max(timeA) as timeA,paichan from sj_line group by paichan )"
                                            + " x where x.paichan=a.paichan and a.timeA=x.timeA )  order by timeA desc ", line);
            var dataset = SqlHelper.Query(DbProvider.LY_DBConnect, strSql);
            return dataset.Tables[0];
        }

        public object InsertSJData(sj_line mode)
        {
            int Serial;
            string strSqlNum = string.Format("select count(line) as LineNum from sj_line where paichan='{0}' ", mode.paichan);

            var datasetNum = SqlHelper.Query(DbProvider.LY_DBConnect, strSqlNum);
            if (datasetNum.Tables[0].Rows[0]["LineNum"].ToString() == null || datasetNum.Tables[0].Rows[0]["LineNum"].ToString() == "")
            {
                Serial = 0;
            }
            else
            {
                Serial = Convert.ToInt16(datasetNum.Tables[0].Rows[0]["LineNum"].ToString()) + 1;
            }

            string strSql = string.Format("insert into  sj_line(line,type,paichan,weightA,timeA,qk,serial) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", mode.line, mode.type, mode.paichan, mode.weightA, mode.timeA, mode.qk, Serial);

            var dataset = SqlHelper.ExecuteNonQuery(DbProvider.LY_DBConnect, strSql);

            return dataset;
        }

        public DataTable GetSJDataByPC()
        {
            string strSql = string.Format(" select top 4  serial,paichan,timeA from sj_line  order by timeA desc");
            var dataset = SqlHelper.Query(DbProvider.LY_DBConnect, strSql);
            return dataset.Tables[0];
        }

    }
}
