using Microsoft.EntityFrameworkCore;

namespace NS.Data
{
    public partial class ReproDbContext
    {
        // Required for migration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(@"Data Source=Repro2124Db.db");
            }
        }
    }
}
