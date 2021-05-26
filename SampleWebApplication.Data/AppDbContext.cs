using Microsoft.EntityFrameworkCore;
using SampleWebApplication.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleWebApplication.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeePosition> EmployeePositions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<EmployeePosition>().ToTable("EmployeePosition");
        }
    }
}