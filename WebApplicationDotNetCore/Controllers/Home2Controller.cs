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
    public class Home2Controller : Controller
    {
        private readonly ILogger<Home2Controller> _logger;
        private ISomeService _someService;
        private ISomeService _someService2;

        public Home2Controller(ILogger<Home2Controller> logger, ISomeService someService, ISomeService someService2)
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
