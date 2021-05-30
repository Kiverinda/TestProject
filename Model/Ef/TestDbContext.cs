using Microsoft.EntityFrameworkCore;
using TestProject.Model.Models;

namespace TestProject.Model.Ef
{
    public class TestDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=test123;Username=postgres;Password=111");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>();
            modelBuilder.Entity<Department>();
            modelBuilder.Entity<Order>();
        }
    }
}