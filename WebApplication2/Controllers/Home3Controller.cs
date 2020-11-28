using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class Home3Controller : Controller
    {
        private IScopedSomeService1 _someService;
        private IScopedSomeService2 _someService2;

        public Home3Controller(IScopedSomeService1 someService, IScopedSomeService2 someService2)
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