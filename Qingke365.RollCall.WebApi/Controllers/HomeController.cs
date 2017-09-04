using Qingke365.RollCall.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Qingke365.RollCall.WebApi.Controllers
{

    public class HomeController : Controller
    {
        private IClassBll bll;

        public HomeController(IClassBll  bll)
        {
            this.bll = bll;
            
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            bll.SayHello();
            return View();
        }
    }
}
