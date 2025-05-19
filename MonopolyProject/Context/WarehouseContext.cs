using Microsoft.EntityFrameworkCore;
using Monopoly.Models;

namespace Monopoly.Data
{
    public class WarehouseContext : DbContext
    {
        public DbSet<Pallet> Pallets => Set<Pallet>();
        public DbSet<Box> Boxes => Set<Box>();

        public WarehouseContext(DbContextOptions<WarehouseContext> options)
            : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pallet>()
                .HasKey(b => b.Id);
            modelBuilder.Entity<Pallet>()
                .HasMany(p => p.Boxes)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Box>()
                .HasKey(b => b.Id);
        }
    }
}
