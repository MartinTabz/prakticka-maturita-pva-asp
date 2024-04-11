using Maturita.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Maturita.Data
{
    public class ApplicationDbContext : IdentityDbContext<Uzivatel>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
            
        }
        // public DbSet<Priklad> Priklady { get; set; }
    }
}
