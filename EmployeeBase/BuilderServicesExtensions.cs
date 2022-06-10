using EmployeeBase.BLL;
using EmployeeBase.BLL.Services.Interfaces;
using EmployeeBase.DAL;

namespace EmployeeBase.API
{
    public static class BuilderServicesExtensions
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }

        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
        }
    }
}
