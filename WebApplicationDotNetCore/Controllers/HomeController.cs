using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplicationDotNetCore.Models;

namespace WebApplicationDotNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ISomeClient _someClient;
        private ISomeClient _someClient2;

        public HomeController(ILogger<HomeController> logger, ISomeClient someClient, ISomeClient someClient2)
        {
            _logger = logger;
            _someClient = someClient;
            _someClient2 = someClient2;
        }

        public IActionResult Index()
        {
            ViewBag.Message = _someClient.Id;
            ViewBag.Message2 = _someClient2.Id;
            return View();
        }
    }
}
