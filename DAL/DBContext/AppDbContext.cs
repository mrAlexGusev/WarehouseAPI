using Microsoft.EntityFrameworkCore;
using WarehouseAPI.DAL.Models;

namespace WarehouseAPI.DAL.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.Unit).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Price).IsRequired();
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.Property(e => e.ProductId).IsRequired();
                entity.Property(e => e.WarehouseId).IsRequired();
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.LastUpdated).IsRequired();

                entity.HasOne(e => e.Product)
                    .WithMany()
                    .HasForeignKey(e => e.ProductId);

                entity.HasOne(e => e.Warehouse)
                    .WithMany()
                    .HasForeignKey(e => e.WarehouseId);
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Address).HasMaxLength(200);
                entity.Property(e => e.ContactPhone).HasMaxLength(20);
            });
        }
    }
}
