using AAIB.Challenge.Web.AppServices;
using AAIB.Challenge.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AAIB.Challenge.Web.Controllers
{
    public class ReportsController : Controller
    {

        private IReportService ReportService;

        public ReportsController(IReportService reportService)
        {
            ReportService = reportService;
        }

        [Route("reports")]
        public IActionResult Index()
        {
            var reportViewModel = new ReportViewModel(ReportService.LoadSpamTickets());
            return View(reportViewModel);
        }

        [HttpPut]
        [Route("reports/{reportId}")]
        public IActionResult ResolveReport(string reportId)
        {
            return new JsonResult(ReportService.ResolveReport(reportId));
        }

        [HttpPut]
        [Route("reports/block/{reportId}")]
        public IActionResult BlockReport(string reportId)
        {
            return new JsonResult(ReportService.BlockReport(reportId));
        }

    }
}
