using StimulsoftReport.Entities;
using StimulsoftReport.Services.Interfaces;
using StimulsoftReport.ViewModels.Employee;

namespace StimulsoftReport.Services.Implantation
{
    public class EmployeeService : IEmployeeService
    {
        private StimulsoftDBContext _context;
        public EmployeeService(StimulsoftDBContext context)
        {
            _context = context;
        }
        public List<ProductViewModel> GetListEmployees()
        {
            try
            {
                var employee = _context.Employees.Select(e => new ProductViewModel
                {
                    EmployeeId = e.EmployeeId,
                    LastName = e.LastName,
                    FirstName = e.FirstName,
                    Title = e.Title,
                    TitleOfCourtesy = e.TitleOfCourtesy,
                    BirthDate = e.BirthDate,
                    HireDate = e.HireDate,
                    Address = e.Address,
                    City = e.City,
                    Region = e.Region,
                    PostalCode = e.PostalCode,
                    Country = e.Country,
                    HomePhone = e.HomePhone,
                    Extension = e.Extension

                }).ToList();
                return employee;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
