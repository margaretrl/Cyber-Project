using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VirusTotalNet;
using VirusTotalNet.Results;
using VirusTotalNet.ResponseCodes;
using System.Collections.Generic;

namespace Cyber_Proj.Controllers
{
    public class ThreatController : Controller
    {
        private readonly VirusTotal _virusTotal;

        public ThreatController()
        {
            string apiKey = "212cfb55b279819dae84df5ba4604aad9617e0fff2cc10db29e40145b0cf0d38";
            _virusTotal = new VirusTotal(apiKey);

            // Use HTTPS instead of HTTP
            _virusTotal.UseTLS = true;
        }

        // Action to render the URL input form
        public IActionResult Index()
        {
            return View();
        }

        // Action to handle the form submission and check the URL
        public async Task<IActionResult> CheckUrl(string url)
        {
            try
            {
                // Perform a scan on the provided URL
                UrlReport urlReport = await _virusTotal.GetUrlReportAsync(url);

                // Check if the URL has been scanned before
                bool hasUrlBeenScannedBefore = urlReport.ResponseCode == UrlReportResponseCode.Present;

                if (hasUrlBeenScannedBefore)
                {
                    // If the URL has been scanned, process the result
                    return View("ScanResult", urlReport);
                }
                else
                {
                    // If the URL hasn't been scanned before, submit it for scanning
                    UrlScanResult scanResult = await _virusTotal.ScanUrlAsync(url);
                    return View("ScanResult", scanResult);
                }
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                // _logger.LogError(ex, "Error scanning the URL");

                // Pass the error message to the view
                ViewBag.ErrorMessage = "An error occurred while processing your request: " + ex.Message;
                return View("Error");
            }
        }

    }
}
