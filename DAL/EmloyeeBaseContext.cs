using EmployeeBase.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBase.DAL
{
    public class EmloyeeBaseContext : DbContext
    {
        public EmloyeeBaseContext(DbContextOptions<EmloyeeBaseContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(a => a.IsDeleted)
                .HasDefaultValue(0);
        }
    }
}
