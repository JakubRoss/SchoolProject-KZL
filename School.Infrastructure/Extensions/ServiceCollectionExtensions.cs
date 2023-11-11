using Cabanoss.Core.Repositories.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using School.Infrastructure.Persistance;
using School.WebAPI.Domain.Entities;

namespace School.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddIfrastructure(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<SchoolDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SchoolDbConnection")));
            services.AddScoped<IBaseRepository<Student> , BaseRepository<Student>>();
        }
    }
}
