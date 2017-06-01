using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Server.Utility;
using Server.Utility.Logging;
using Server.Utility.Caching;

namespace LY.MES.WCF
{
    /// <summary>
    /// DeviceCacheData 的摘要说明
    /// </summary>
    public class DeviceCacheData : IHttpHandler
    {
        private static RedisCacheManager _cache = null;
        private RedisCacheManager cache
        {
            get
            {
                if (_cache == null)
                    _cache = new RedisCacheManager("DeviceCacheServer");
                return _cache;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request.QueryString.Count > 0)
            {
                string Key = context.Request.QueryString[0].ToString();
                string strValue = cache.ListGetByIndex(Key, 0);
                Utils.Logger.Info(string.Format("Key:{0},strValue:{1}", Key, strValue));
                context.Response.Write(strValue);
            }
            else
            {
                context.Response.Write("Parameter is Emty");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}