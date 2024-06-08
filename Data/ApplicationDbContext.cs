using GS.Models;
using Microsoft.EntityFrameworkCore;

namespace GS.Data
{    
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        } 
        public DbSet<RIOS> RIOS { get; set; }
        public DbSet<MARES> MARES { get; set; }
        public DbSet<REPRESAS> REPRESAS { get; set; }
        public DbSet<OCEANOS> OCEANOS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RIOS>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<MARES>()
                .HasKey(m => m.ID);

            modelBuilder.Entity<REPRESAS>()
                .HasKey(r => r.ID);

            modelBuilder.Entity<OCEANOS>()
                .HasKey(o => o.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
