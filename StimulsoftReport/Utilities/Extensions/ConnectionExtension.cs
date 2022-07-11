using Microsoft.EntityFrameworkCore;
using StimulsoftReport.Entities;

namespace StimulsoftReport.Utilities.Extensions
{
    public static class ConnectionExtension
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection service,
           IConfiguration configuration)
        {
            service.AddDbContext<StimulsoftDBContext>(options =>
            {
                var connectionString = "ConnectionStrings:StimulsoftConnection";
                options.UseSqlServer(configuration[connectionString]);
            });

            return service;
        }
    }
}
