using AutoMapper;
using AutomapperDemo.DTOs;
using AutomapperDemo.Models;

namespace AutomapperDemo.MappingProfiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile() {

            // The CreateMap method create a mapping configuration between the Product entity and the ProductDTO.
            // This configuration tells AutoMapper how to convert a Product instance (source)
            // into a ProductDTO instance (destination).
            CreateMap<Product, ProductDTO>()

                // The ForMember method configures a specific member mapping.
                // The following code explicitly maps the 'Name' property of the Product (source) to the 'ProductName'
                // property of the ProductDTO (destination).
                .ForMember(
                    dest => dest.ProductName,     // Destination member: ProductDTO.ProductName
                    opt => opt.MapFrom(src => src.Name) // Mapping logic: take the value from Product.Name
                )

                // Similarly, the following code explicitly maps the 'Description' property of the Product (source)
                // to the 'ShortDescription' property of the ProductDTO (destination).
                .ForMember(
                    dest => dest.ShortDescription,     // Destination member: ProductDTO.ShortDescription
                    opt => opt.MapFrom(src => src.Description) // Mapping logic: take the value from Product.Description
                );

            // Create a mapping configuration between the ProductCreateDTO and the Product entity.
            // This is used when a new product is being created from the data provided by an admin or internal source.
            // AutoMapper will automatically map properties with matching names and types.
            CreateMap<ProductCreateDTO, Product>();

        }
    }
}
