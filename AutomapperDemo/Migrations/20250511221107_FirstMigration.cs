using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutomapperDemo.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SupplierCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SupplierInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "Brand", "Category", "CreatedDate", "Description", "IsAvailable", "Name", "Price", "SKU", "StockQuantity", "SupplierCost", "SupplierInfo", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "TechBrand", "Electronics", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High performance gaming laptop", true, "Gaming Laptop", 1500.99m, "ELE-TEC-GAM-2025-1", 50, 1200.00m, "Tech Supplier Co.", null },
                    { 2, "PhoneMaker", "Electronics", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Latest smartphone with cutting edge features", true, "Smartphone", 999.99m, "ELE-PHO-SMA-2025-2", 100, 750.00m, "Mobile Solutions Inc.", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
