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
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB; Integrated Security=True; Persist Security Info=True; MultipleActiveResultSets=True; Database=Repro2124Db");
            }
        }
    }
}
