using ERMS_Project.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERMS_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
