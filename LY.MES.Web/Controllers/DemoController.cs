using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LY.MES.Web.Controllers
{
    public class DemoController : BaseController
    {
        //
        // GET: /Demo/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Query()
        {
            var r = new Random();
            return Json(new { Num = r.Next() },JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }

    }
}
