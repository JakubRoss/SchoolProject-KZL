using Microsoft.Extensions.DependencyInjection;
using School.Application.Services;

namespace School.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
        }
    }
}
