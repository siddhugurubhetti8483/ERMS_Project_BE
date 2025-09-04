using ERMS_Project.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERMS_Project.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employees> Employees { get; set; }
    }
}
