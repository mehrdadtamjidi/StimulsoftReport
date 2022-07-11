using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using StimulsoftReport.Services.Interfaces;

namespace StimulsoftReport.Controllers
{
    public class ViewerController : Controller
    {
        private IEmployeeService _employeeService;
        private IProductService _productService;
        private IWebHostEnvironment _env;
        public ViewerController(IWebHostEnvironment env, IEmployeeService employeeService, IProductService productService)
        {
            _employeeService = employeeService;
            _productService = productService;
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetReport(string id)
        {
            StiReport report = new StiReport();

            // Load report
            switch (id)
            {
                // Load report Employee
                case "1":
                    report.RegData("dtEmployee", _employeeService.GetListEmployees());
                    report.Load(StiNetCoreHelper.MapPath(this, "wwwroot/Reports/Employee.mrt"));
                    break;

                // Load report Product
                case "2":
                    report.RegData("dtEmployee", _productService.GetListProducts());
                    report.Load(StiNetCoreHelper.MapPath(this, "wwwroot/Reports/Product.mrt"));
                    break;

                // Load report Employee
                default:
                    report.RegData("dtEmployee", _employeeService.GetListEmployees());
                    report.Load(StiNetCoreHelper.MapPath(this, "wwwroot/Reports/Employee.mrt"));
                    break;
            }

            return StiNetCoreViewer.GetReportResult(this, report);
        }

        public IActionResult ViewerEvent()
        {
            return StiNetCoreViewer.ViewerEventResult(this);
        }

        public IActionResult ExportReport()
        {
            return StiNetCoreViewer.ExportReportResult(this);
        }
    }
}
