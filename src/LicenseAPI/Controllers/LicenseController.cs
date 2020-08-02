using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LicenseAPI.Models;
using LicenseData;

namespace LicenseAPI.Controllers
{
    public class LicenseController : Controller
    {
        private readonly ILogger<LicenseController> _logger;

        public LicenseController(ILogger<LicenseController> logger)
        {
            _logger = logger;
        }

        public ActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                _logger.LogDebug("Hit the get route on the license controller with no url parameter.");
            }
            else
            {
                _logger.LogDebug($"Hit the get route on the license controller with the ID: {id}.");
            }

            var licenseData = new License();
            var licenses = licenseData.GetAvailableLicenseIDs();

            if (string.IsNullOrEmpty(id))
            {
                return new JsonResult(new {Licenses = licenses});
            }

            if (licenses.Contains(id))
            {
                var license = licenseData.GetLicense(id);
                _logger.LogDebug(license.LicenseText);
                license.LicenseText = license.ReplaceYear();
                return new JsonResult(license);
            }
            else 
            {
                _logger.LogError($"Failed to call API with ID: {id}");
                return NotFound(new {result = $"{id} not found."});
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogError("Oh No.");
            return View(new ErrorViewModel() { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}