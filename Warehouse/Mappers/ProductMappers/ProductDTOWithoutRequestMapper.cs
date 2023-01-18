using Contracts.Responses.Product;
using Entities.Models;
using FastEndpoints;

namespace Warehouse.Mappers.ProductMappers
{
    public class ProductDTOWithoutRequestMapper : ResponseMapper<ProductDTO, Product>
    {
        public override ProductDTO FromEntity(Product p) => new()
        {
            Id = p.Id,
            Name = p.Name,
            DepartmentId = p.DepartmentId
        };
    }
}
