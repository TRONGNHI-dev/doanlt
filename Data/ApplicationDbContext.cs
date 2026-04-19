using Microsoft.EntityFrameworkCore;
using TravelProject.Models;

namespace TravelProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<DiaDiem> DiaDiems => Set<DiaDiem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("tblUsers");
            });

            modelBuilder.Entity<DiaDiem>(entity =>
            {
                entity.ToTable("tblDiaDiem");
            });
        }
    }
}
