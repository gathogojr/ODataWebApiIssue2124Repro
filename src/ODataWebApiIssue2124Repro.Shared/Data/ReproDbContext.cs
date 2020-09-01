using Microsoft.EntityFrameworkCore;
using NS.Models;

namespace NS.Data
{
    public partial class ReproDbContext : DbContext
    {
        public ReproDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
