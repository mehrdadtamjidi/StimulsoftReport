using StimulsoftReport.Services.Implantation;
using StimulsoftReport.Services.Interfaces;

namespace StimulsoftReport.Utilities.Extensions
{
    public static class DependencyContainerExtension
    {
        public static void RegisterServices(this IServiceCollection service)
        {
            service.AddScoped<IEmployeeService, EmployeeService>();
            service.AddScoped<IProductService, ProductService>();
        }
    }
}
