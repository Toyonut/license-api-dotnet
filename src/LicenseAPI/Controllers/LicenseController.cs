using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using license_api.Models;
using System.Text.Encodings.Web;
using LicenseData;

namespace license_api.Controllers
{
    public class LicenseController : Controller
    {
        private readonly ILogger<LicenseController> _logger;

        public LicenseController(ILogger<LicenseController> logger)
        {
            _logger = logger;
        }

        public JsonResult Find (string id) {
            _logger.LogInformation($"Hit the find route on the license controller with the url parameter {Content(id).Content}");

            var dbContext = new LicenseContext();

            var licenseNames = dbContext.licenses.Select( l => l.Name ).ToList();

            foreach (var item in licenseNames)
            {
                Console.WriteLine($"{item}");
            }

            return new JsonResult(new {Names = licenseNames});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogError("Oh No.");
            return View(new ErrorViewModel() { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}