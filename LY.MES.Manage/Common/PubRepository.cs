using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Framework;
using System.Data.SqlClient;
using System.Data;

namespace LY.MES.Manage.Common
{
    /// <summary>
    /// Author:xxp
    /// Remark:公用数据库SQL数据处理
    /// </summary>
    public class PubRepository
    {

        /// <summary>
        /// 单据号自动生成
        /// </summary>
        /// <param name="strConn">数据库连接</param>
        /// <param name="strPrefix">前缀</param>
        /// <param name="iSNLength">流水长度</param>
        /// <param name="strCol">单据号字段名称</param>
        /// <param name="strTableName">表名</param>
        /// <param name="dVouchDate">单据日期</param>
        /// <returns>新单据号</returns>
        public static string GetAutomaticNumber(string strConn, string strPrefix, int iSNLength, string strCol, string strTableName, DateTime dVouchDate)
        {
            List<SqlParameter> lstParameter = new List<SqlParameter>();
            lstParameter.Add(new SqlParameter("@prefix", strPrefix));
            lstParameter.Add(new SqlParameter("@SNLength", iSNLength));
            lstParameter.Add(new SqlParameter("@t_Col", strCol));
            lstParameter.Add(new SqlParameter("@t_TableName", strTableName));
            lstParameter.Add(new SqlParameter("@vouchDate", dVouchDate));
            SqlParameter outParameter = new SqlParameter("@NewCode", SqlDbType.NVarChar, 20);
            outParameter.Direction = ParameterDirection.Output;
            lstParameter.Add(outParameter);
            int outValue = 0;
            SqlHelper.RunProcedure(strConn, "proc_AutomaticNumber", lstParameter.ToArray(), out outValue);
            return outParameter.Value.ToString();

        }
    }
}
