using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MercatorWebshop.Models;

namespace MercatorWebshop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MercatorWebshop.Models.Artikl> Artikl { get; set; }
        public DbSet<MercatorWebshop.Models.Prodavnica> Prodavnica { get; set; }
    }
}