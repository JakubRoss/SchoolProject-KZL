using Microsoft.Extensions.DependencyInjection;
using School.Application.Model;
using School.Application.Services.SchoolClass;
using School.Application.Services.Student;
using School.Application.Services.Teacher;

namespace School.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddAutoMapper(typeof(SchoolMappingProfile));
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ISchoolClassService, SchoolClassService>();
        }
    }
}
