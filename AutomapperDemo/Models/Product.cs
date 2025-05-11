using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AutomapperDemo.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string? SKU { get; set; } // Unique Product Identifier

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Range(0.01, 1000000)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }

        public string Category { get; set; }

        public string Brand { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        // Sensitive/Internal Fields (not to be exposed to customers)
        [Column(TypeName = "decimal(18,2)")]
        public decimal SupplierCost { get; set; }

        public string SupplierInfo { get; set; }

        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }
    }
}
