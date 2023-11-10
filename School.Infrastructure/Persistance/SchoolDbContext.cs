using Microsoft.EntityFrameworkCore;
using School.WebAPI.Domain.Entities;

namespace School.Infrastructure.Persistance
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<SchoolClass> SchoolClass { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }
    }
}
