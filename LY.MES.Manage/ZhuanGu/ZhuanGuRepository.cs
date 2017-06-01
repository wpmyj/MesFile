using LY.MES.Manage.Common;
using LY.MES.Manage.Commonn;
using Server.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LY.MES.Manage.ZhuanGu
{
    public class ZhuanGuRepository
    {
        private DbContext context = new DbContext("name=LYMesSystemEntities");
        
        //public readonly static string dbContext = ConfigurationManager.ConnectionStrings["dbContext"].ConnectionString;
        //获取转鼓流转状态
        public DataTable GetZhuanGuStatus() 
        {   
            string sqlcontent = string.Format("declare @sql varchar(8000) "
            + "set @sql = 'select ExecuteOrder as 执行编号,CraftsName as 工艺名称,CraftsCode as 工艺编号'"
            +"select @sql = @sql + ' , max(case DevCode when ''' + DevCode + ''' then ExecuteStatus else null end) [' + DevName + ']'"
            + "from (select DISTINCT DevCode,DevName  from dbo.Device WHERE DevCCode='01') as a "
            + "set @sql = @sql + ' from vw_DurmsUpFeeding WITH(NOLOCK) where UserStatus=1 group by CraftsName,CraftsCode,ExecuteOrder order by ExecuteOrder  '"
            + "exec(@sql) ");

            var dataset = SqlHelper.Query(context.Database.Connection.ConnectionString,sqlcontent);
            return dataset.Tables[0];
        }
        /// <summary>
        /// 获取规划表编码、工艺名称
        /// </summary>
        /// <param name="ProPlanNum">规划表编码</param>
        /// <returns></returns>
        public DataTable GetCraftParameter(string ProPlanNum)
        {
            string sqlcontent = string.Format("select  b.配对表编号 as PairTableNum ,工艺名称 as CraftName from 新工艺参数规划表_主表 a,工艺参数规划表_关联检测表明细 b" 
            +" where a.ExcelServerRCID = b.ExcelServerRCID and 规划表编码 = '{0}'", ProPlanNum);

            var dataset = SqlHelper.Query(DbProvider.QZ_DBConnect, sqlcontent);

            return dataset.Tables[0];
        }

        /// <summary>
        /// 获取监测配对表
        /// </summary>
        /// <param name="PairTableNum">监测表编号</param>
        /// <returns></returns>
        public DataTable GetMonitorPairTable(string PairTableNum)
        {
            string sqlcontent = string.Format("select 序号, Max(case when 自定义='时间/h' then 数据 end) as [时间/h],"  
            +" Max(case when 自定义='温度上限' then 数据 end) as 温度上限,"
            +" Max(case when 自定义='温度下限' then 数据 end) as 温度下限,"
            +" Max(case when 自定义='真空上限' then 数据 end) as 真空上限, "
            +" Max(case when 自定义='真空下限' then 数据 end) as 真空下限 "
            +" from 监测配对表_主表 a,监测配对表_明细 b "
            +" where a.ExcelServerRCID = b.ExcelServerRCID "
            +" and a.配对表编号 = '{0}' "
            + " group by 序号 ", PairTableNum);

            var dataset = SqlHelper.Query(DbProvider.QZ_DBConnect,sqlcontent);
            return dataset.Tables[0];
        }


    }
}
