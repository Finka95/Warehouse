using Contracts.Requests.Product;
using Contracts.Responses.Product;
using Contracts.Responses.Department;
using Entities.Models;
using FastEndpoints;

namespace Warehouse.Mappers.ProductMappers
{
    public class ProductDTOWithDetailsMapper : Mapper<PostProduct, ProductDTOWithDetails, Product>
    {
        public override ProductDTOWithDetails FromEntity(Product p) => new()
        {
            Id = p.Id,
            Name = p.Name,
            Department = p.Department == null ? null : new DepartmentDTO() { Id = p.Department.Id , Name = p.Department.Name},
        };

        public override Product ToEntity(PostProduct r) => new()
        {
            Name = r.Name,
            DepartmentId = r.DepartmentId
        };
    }
}
