namespace AutomapperDemo.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string? SKU { get; set; }

        // Renamed properties to simulate different naming conventions
        public string ProductName { get; set; }

        public string? ShortDescription { get; set; }

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }

        public string Category { get; set; }

        public string Brand { get; set; }

        public DateTime CreatedDate { get; set; }
        // Sensitive fields like SupplierCost, SupplierInfo, and StockQuantity are intentionally omitted.
    }
}
