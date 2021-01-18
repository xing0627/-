using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrdosHealthPortraitsystemServer.Bll;
using OrdosHealthPortraitsystemServer.Model;
using OrdosHealthPortraitsystemServer.Utility;

namespace OrdosHealthPortraitsystemServer.Controllers
{
    public class HttpServerController : Controller
    {
        public ActionResult HealtyInfo(string idCard, string passWord)
        {
            ResponseTotleInfo result = new DealHttpRequestBll().GetHealthDatumInfo(idCard, passWord);
            return Json(result, JsonRequestBehavior.DenyGet);
        }
    }
}
