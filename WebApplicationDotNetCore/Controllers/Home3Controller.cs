using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplicationDotNetCore.Services;

namespace WebApplicationDotNetCore.Controllers
{
    public class Home3Controller : Controller
    {
        private readonly ILogger<Home3Controller> _logger;
        private IScopedSomeService1 _someService;
        private IScopedSomeService2 _someService2;

        public Home3Controller(ILogger<Home3Controller> logger, IScopedSomeService1 someService, IScopedSomeService2 someService2)
        {
            _logger = logger;
            _someService = someService;
            _someService2 = someService2;
        }

        public IActionResult Index()
        {
            ViewBag.Message = _someService.Greeting();
            ViewBag.Message2 = _someService2.Greeting();
            return View();
        }
    }
}
