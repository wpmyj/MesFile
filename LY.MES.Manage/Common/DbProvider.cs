using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LY.MES.Manage.Common
{
    /// <summary>
    /// Author:xxp
    /// Remark:数据库提供
    /// CreateTime:20161108
    /// </summary>
    public class DbProvider
    {
        /// <summary>
        /// 勤哲数据库连接串
        /// </summary>
        public readonly static string QZ_DBConnect = ConfigurationManager.ConnectionStrings["QZ_DBConnect"].ConnectionString;
        public readonly static string ZK_DBConnect = ConfigurationManager.ConnectionStrings["ZK_DBConnect"].ConnectionString;
        public readonly static string SJ_DBConnect = ConfigurationManager.ConnectionStrings["SJ_DBConnect"].ConnectionString;

        public readonly static string LY_DBConnect = ConfigurationManager.ConnectionStrings["SJTest_DBConnect"].ConnectionString;

    }
}
