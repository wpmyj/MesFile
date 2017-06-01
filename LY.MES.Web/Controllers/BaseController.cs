using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LY.MES.Web.Controllers
{
    /// <summary>
    /// Author:xxp
    /// Remark:基本控制器
    /// 
    /// </summary>
    public class BaseController : Controller
    {
        public string CurrUser
        {
            get;
            private set;
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {

            base.OnAuthorization(filterContext);
        }
    }
}
