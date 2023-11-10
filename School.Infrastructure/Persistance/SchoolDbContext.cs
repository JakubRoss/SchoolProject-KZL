using Microsoft.EntityFrameworkCore;
using School.WebAPI.Domain.Entities;

namespace School.Infrastructure.Persistance
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<SchoolClass> SchoolClass { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=OMEN;Database=School.EF.KZL;Trusted_Connection=True;Integrated Security=true;TrustServerCertificate=true;");
        }
    }
}
