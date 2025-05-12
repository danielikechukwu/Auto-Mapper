using AutomapperDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomapperDemo.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        //Seed some sample data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                                new Product
                                {
                                    Id = 1,
                                    SKU = "ELE-TEC-GAM-2025-1", // Electronics, TechBrand, Gaming Laptop, 2025, Id=1
                                    Name = "Gaming Laptop",
                                    Description = "High performance gaming laptop",
                                    Price = 1500.99m,
                                    IsAvailable = true,
                                    Category = "Electronics",
                                    Brand = "TechBrand",
                                    CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                                    SupplierCost = 1200.00m,
                                    SupplierInfo = "Tech Supplier Co.",
                                    StockQuantity = 50
                                },
                new Product
                {
                    Id = 2,
                    SKU = "ELE-PHO-SMA-2025-2", // Electronics, PhoneMaker, Smartphone, 2025, Id=2
                    Name = "Smartphone",
                    Description = "Latest smartphone with cutting edge features",
                    Price = 999.99m,
                    IsAvailable = true,
                    Category = "Electronics",
                    Brand = "PhoneMaker",
                    CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    SupplierCost = 750.00m,
                    SupplierInfo = "Mobile Solutions Inc.",
                    StockQuantity = 100
                }
                );
        }

        public DbSet<Product> Products { get; set; }

    }
}
