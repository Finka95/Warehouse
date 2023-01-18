using Contracts.Requests.Department;
using Contracts.Responses.Worker;
using Contracts.Responses.Department;
using Contracts.Responses.Product;
using Entities.Models;
using FastEndpoints;

namespace Warehouse.Mappers.DepartmentMappers
{
    public class PutDepartmentMapper : Mapper<PutDepartment, DepartmentDTOWithDetails, Department>
    {
        public override Department UpdateEntity(PutDepartment pd, Department d)
        {
            d.Name = pd.Name ?? d.Name;
            return d;
        }

        public override DepartmentDTOWithDetails FromEntity(Department d) => new()
        {
            Id = d.Id,
            Name = d.Name,
            Workers = d.Workers?.Select(w => new WorkerDTO() { Id = w.Id, FirstName = w.FirstName, LastName = w.LastName }).ToArray() ?? null,
            Products = d.Products?.Select(p => new ProductDTO() { Id = p.Id, Name = p.Name }).ToArray() ?? null
        };
    }
}
