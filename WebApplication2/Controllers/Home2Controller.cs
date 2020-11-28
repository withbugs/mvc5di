using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class Home2Controller : Controller
    {
        private ISomeService _someService;
        private ISomeService _someService2;

        public Home2Controller(ISomeService someService, ISomeService someService2)
        {
            _someService = someService;
            _someService2 = someService2;
        }

        public ActionResult Index()
        {
            ViewBag.Message = _someService.Greeting();
            ViewBag.Message2 = _someService2.Greeting();
            return View();
        }
    }
}