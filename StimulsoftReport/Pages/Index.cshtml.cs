using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stimulsoft.Base;
using Stimulsoft.Report.Mvc;
using StimulsoftReport.Services.Interfaces;
using StimulsoftReport.ViewModels.Employee;

namespace StimulsoftReport.Pages
{
    public class IndexModel : PageModel
    {
        private IEmployeeService _employeeService;
        private IWebHostEnvironment _env;
        public IEnumerable<ProductViewModel> Employee { get; set; }

        public IndexModel(IWebHostEnvironment env, IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            _env = env;
            string path = Path.Combine(_env.WebRootPath, "Reports\\license\\license.key");
            StiLicense.LoadFromFile(path);
        }

        public void OnGet()
        {
            Employee = _employeeService.GetListEmployees();
        }

    }
}