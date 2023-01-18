using Contracts.Requests.Product;
using Contracts.Responses.Department;
using Contracts.Responses.Product;
using Entities.Models;
using FastEndpoints;

namespace Warehouse.Mappers.ProductMappers
{
    public class PutProductMapper : Mapper<PutProduct, ProductDTOWithDetails, Product>
    {
        public override Product UpdateEntity(PutProduct pp, Product p)
        {
            p.Name = pp.Name ?? p.Name;
            p.DepartmentId = pp.DepartmentId ?? p.DepartmentId;
            return p;
        }

        public override ProductDTOWithDetails FromEntity(Product p) => new()
        {
            Id = p.Id,
            Name = p.Name,
            Department = p.Department == null ? null : new DepartmentDTO() { Id = p.Department.Id, Name = p.Department.Name },
        };
    }
}
