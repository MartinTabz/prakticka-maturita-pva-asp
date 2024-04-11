using Microsoft.EntityFrameworkCore;

namespace Maturita.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
            
        }
        // public DbSet<Priklad> Priklady { get; set; }
    }
}
