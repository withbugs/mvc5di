using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private ISomeClient _someClient;
        private ISomeClient _someClient2;

        public HomeController(ISomeClient someClient, ISomeClient someClient2)
        {
            _someClient = someClient;
            _someClient2 = someClient2;
        }

        public ActionResult Index()
        {
            ViewBag.Message = _someClient.Id;
            ViewBag.Message2 = _someClient2.Id;
            return View();
        }
    }
}