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
        public DbSet<Poznamka> Poznamky { get; set; }
    }
}
