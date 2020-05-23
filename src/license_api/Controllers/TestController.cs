using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using license_api.Models;
using System.Text.Encodings.Web;

namespace license_api.Controllers
{
    public class TestController : Controller
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        public string Index () {
            _logger.LogDebug("Hit the index route on the test controller");
            return "Hello World";
        }

        public string HelloHTML (string Name) {
            _logger.LogDebug($"Hit the Hello World HTML route with parameter {Name}");
            return HtmlEncoder.Default.Encode($"Hello {Name}");
        }

        public JsonResult HelloJSON (string Name) {
            _logger.LogDebug($"Hit the Hello World JSON route with parameter {Name}");
            return new JsonResult(new {Name = Name});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogError("Oh No.");
            return View(new ErrorViewModel() { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}