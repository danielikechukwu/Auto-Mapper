using AutomapperDemo.Data;
using AutomapperDemo.DTOs;
using AutomapperDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutomapperDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductDbContext _context;

        public ProductsController(ProductDbContext context)
        {
            _context = context;
        }


        [HttpGet("GetProducts")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            var productDTOs = await _context.Products.AsNoTracking()
                .Select((Product product) => new ProductDTO
                {
                    Id = product.Id,
                    SKU = product.SKU,
                    ProductName = product.Name,         // Mapping Name to ProductName
                    ShortDescription = product.Description, // Mapping Description to ShortDescription
                    Price = product.Price,
                    IsAvailable = product.IsAvailable,
                    Category = product.Category,
                    Brand = product.Brand,
                    CreatedDate = product.CreatedDate
                }).ToListAsync();

            return Ok(productDTOs);
        }

        [HttpGet("GetProductById/{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById([FromRoute] int id)
        {
            var productDTO = await _context.Products.AsNoTracking()
                .Select((Product product) => new ProductDTO
                {
                    Id = product.Id,
                    SKU = product.SKU,
                    ProductName = product.Name, // Mapping Name to ProductName
                    ShortDescription = product.Description, // Mapping Description to ShortDescription
                    Price = product.Price,
                    IsAvailable = product.IsAvailable,
                    Category = product.Category,
                    Brand = product.Brand,
                    CreatedDate = product.CreatedDate
                })
                .FirstOrDefaultAsync(prd => prd.Id == id);

            if(productDTO == null)
                return NotFound();

            return Ok(productDTO);
        }

        [HttpPost("AddProduct")]
        public async Task<ActionResult<ProductDTO>> AddProduct([FromBody] ProductCreateDTO productCreateDTO)
        {
            var product = new Product
            {
                Name = productCreateDTO.Name,
                Description = productCreateDTO.Description,
                Price = productCreateDTO.Price,
                Category = productCreateDTO.Category,
                Brand = productCreateDTO.Brand,
                SupplierCost = productCreateDTO.SupplierCost,
                SupplierInfo = productCreateDTO.SupplierInfo,
                StockQuantity = productCreateDTO.StockQuantity,
                IsAvailable = productCreateDTO.StockQuantity > 0,
                CreatedDate = DateTime.UtcNow
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            product.SKU = GenerateSKU(product);
            await _context.SaveChangesAsync();

            var productDTO = new ProductDTO
            {
                Id = product.Id,
                SKU = product.SKU,
                ProductName = product.Name, // Mapping Name to ProductName
                ShortDescription = product.Description, // Mapping Description to ShortDescription
                Price = product.Price,
                IsAvailable = product.IsAvailable,
                Category = product.Category,
                Brand = product.Brand,
                CreatedDate = product.CreatedDate
            };

            return Ok(productDTO);
        }

        // Generates a SKU based on:
        //  - First three letters of Category
        //  - First three letters of Brand
        //  - First three letters of Product Name
        //  - Year of CreatedDate
        //  - Product.Id
        // Example: If Category="Electronics", Brand="Samsung", Name="Galaxy", CreatedDate is 2025 and Id is 15, 
        // The SKU would be "ELE-SAM-GAL-2025-15".
        private string GenerateSKU(Product product)
        {
            // Use default values if any fields are missing
            string category = string.IsNullOrEmpty(product.Category) ? "GEN" : product.Category;
            string brand = string.IsNullOrEmpty(product.Brand) ? "BRD" : product.Brand;
            string name = string.IsNullOrEmpty(product.Name) ? "PRD" : product.Name;
            // Extract the first three letters of each, padding if necessary
            string catPrefix = category.Length >= 3
                ? category.Substring(0, 3).ToUpper()
                : category.ToUpper().PadRight(3, 'X');
            string brandPrefix = brand.Length >= 3
                ? brand.Substring(0, 3).ToUpper()
                : brand.ToUpper().PadRight(3, 'X');
            string prodPrefix = name.Length >= 3
                ? name.Substring(0, 3).ToUpper()
                : name.ToUpper().PadRight(3, 'X');
            // Use the year from CreatedDate and the generated Id
            int year = product.CreatedDate.Year;
            int id = product.Id;
            // Assemble SKU with hyphen separators
            return $"{catPrefix}-{brandPrefix}-{prodPrefix}-{year}-{id}";
        }

    }
}
