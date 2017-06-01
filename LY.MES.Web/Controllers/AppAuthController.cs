using LY.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Server.Utility;
using LY.Model;

namespace LY.MES.Web.Controllers
{
    /// <summary>
    /// Author:xxp
    /// Remark:App权限
    /// CreateDate:20170502
    /// </summary>
    public class AppAuthController : ApiController
    {

        [HttpGet]
        public string Login(string SysCode, int Platform, string UserCode, string PassWord)
        {
            var res = new UserSessionServices();
            var ret = res.UserLogin(SysCode, UserCode, PassWord, "", "", DateTime.Now);
            return JsonTool.EntityToJson<CommonResult<UserContext>>(ret);
        }

        [HttpGet]
        public string LoginOut(string SessionId)
        {
            var res = new UserSessionServices();
            var ret = res.LoginOut(SessionId);
            return JsonTool.EntityToJson<CommonResult<bool>>(new CommonResult<bool>() { Data = ret });
        }
    }
}